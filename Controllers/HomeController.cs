using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Twoishday.Extensions;
using Twoishday.Models;
using Twoishday.Models.Enums;
using Twoishday.Models.ViewModels;
using Twoishday.Services.Interfaces;

namespace Twoishday.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITDCompanyInfoService _companyInfoService;
        private readonly ITDProjectService _projectService;
        private readonly ITDTicketService _ticketService;
        private readonly UserManager<TDUser> _userManager;

        public HomeController(
            ILogger<HomeController> logger, 
            ITDCompanyInfoService companyInfoService,
            ITDProjectService projectService,
            ITDTicketService ticketService,
            UserManager<TDUser> userManager)
        {
            _logger = logger;
            _companyInfoService = companyInfoService;
            _projectService = projectService;
            _ticketService = ticketService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            // Redirect logged-in users to dashboard
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Dashboard));
            }

            return View();
        }


        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            DashboardViewModel model = new();
            int companyId = User.Identity.GetCompanyId().Value;
            string userId = _userManager.GetUserId(User);

            model.Company = await _companyInfoService.GetCompanyInfoByIdAsync(companyId);

            // Get USER's projects (not all company projects)
            model.Projects = await _projectService.GetUserProjectsAsync(userId) ?? new List<Project>();
            model.Projects = model.Projects.Where(p => p.Archived == false).ToList();

            // Get USER's tickets (not all company tickets)
            model.Tickets = await _ticketService.GetTicketsByUserIdAsync(userId, companyId) ?? new List<Ticket>();
            model.Tickets = model.Tickets.Where(t => t.Archived == false).ToList();

            model.Members = model.Company?.Members?.ToList() ?? new List<TDUser>();

            // Calculate KPIs based on USER's data
            model.TotalProjects = model.Projects.Count;
            model.TotalTickets = model.Tickets.Count;
            model.OpenTickets = model.Tickets.Count(t => 
                t.TicketStatus.Name != "Resolved" && 
                t.TicketStatus.Name != "Closed");
            model.ClosedTickets = model.Tickets.Count(t => 
                t.TicketStatus.Name == "Resolved" || 
                t.TicketStatus.Name == "Closed");
            model.InProgressTickets = model.Tickets.Count(t => 
                t.TicketStatus.Name == "Development" || 
                t.TicketStatus.Name == "In Progress");
            model.UnassignedTickets = model.Tickets.Count(t => 
                t.DeveloperUserId == null);

            // My Assigned Tickets (same as model.Tickets, but take top 5)
            model.MyAssignedTickets = model.Tickets
                .OrderByDescending(t => t.Created)
                .Take(5)
                .ToList();

            // Chart Data - Tickets by Status (USER's tickets)
            model.TicketsByStatus = model.Tickets
                .GroupBy(t => t.TicketStatus.Name)
                .ToDictionary(g => g.Key, g => g.Count());

            // Chart Data - Tickets by Priority (USER's tickets)
            model.TicketsByPriority = model.Tickets
                .GroupBy(t => t.TicketPriority.Name)
                .ToDictionary(g => g.Key, g => g.Count());

            // Recent Activity (USER's last 10 tickets)
            model.RecentTickets = model.Tickets
                .OrderByDescending(t => t.Updated ?? t.Created)
                .Take(10)
                .ToList();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
