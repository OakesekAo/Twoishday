using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twoishday.Data;
using Twoishday.Models;
using Twoishday.Services.Interfaces;

namespace Twoishday.Services
{
    public class TDCompanyInfoService : ITDCompanyInfoService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<TDUser> _userManager;



        public TDCompanyInfoService(ApplicationDbContext context, UserManager<TDUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<Company> AddCompanyAsync(Company company)
        {
            try
            {
                await _context.AddAsync(company);
                await _context.SaveChangesAsync();
                return company;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<Company> AddUserAsync(string name, string description)
        {
            name  = name.ToLower();
            description = description.ToLower();

            List<Company> companies = await _context.Companies!.ToListAsync();

            foreach(Company company in companies)
            {
                if(company.Name == name && company.Description == description)
                {
                    return company;
                }
            }

            Company newCompany = new()
            {
                Name = name,
                Description = description,
            };

            await AddCompanyAsync(newCompany);

            return newCompany;


        }

        public async Task<List<TDUser>> GetAllMembersAsync(int companyId)
        {
            List<TDUser> result = new();

            result = await _context.Users.Where(u => u.CompanyId == companyId).ToListAsync();

            return result;
        }

        public async Task<List<Project>> GetAllProjectsAsync(int companyId)
        {
            List<Project> result = new();

            result = await _context.Projects.Where(p => p.CompanyId == companyId)
                                            .Include(p => p.Members)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.Comments)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.Attachments)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.History)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.DeveloperUser)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.OwnerUser)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.Notifications)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.TicketStatus)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.TicketPriority)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.TicketType)
                                            .Include(p => p.ProjectPriority)
                                            .ToListAsync();

            return result;
        }

        public async Task<List<Ticket>> GetAllTicketsAsync(int companyId)
        {
            List<Ticket> result = new();
            List<Project> projects = new();

            projects = await GetAllProjectsAsync(companyId);

            result = projects.SelectMany(p => p.Tickets).ToList();

            return result;
        }

        public async Task<Company> GetCompanyInfoByIdAsync(int? companyId)
        {
            Company result = new();

            if (companyId != null)
            {
                result = await _context.Companies
                                        .Include(c => c.Members)
                                        .Include(c => c.Projects)
                                        .Include(c => c.Invites)
                                        .FirstOrDefaultAsync(c => c.Id == companyId);
            }

            return result;
        }
    }
}
