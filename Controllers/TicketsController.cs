﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Twoishday.Data;
using Twoishday.Extensions;
using Twoishday.Models;
using Twoishday.Models.Enums;
using Twoishday.Models.ViewModels;
using Twoishday.Services;
using Twoishday.Services.Interfaces;

namespace Twoishday.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly UserManager<TDUser> _userManager;
        private readonly ITDProjectService _projectSeervice;
        private readonly ITDLookupService _lookupService;
        private readonly ITDTicketService _ticketService;
        private readonly ITDFileService _fileService;
        private readonly ITDTicketHistoryService _historyService;

        public TicketsController(UserManager<TDUser> userManager, ITDProjectService projectSeervice, ITDLookupService lookupService, ITDTicketService ticketService, ITDFileService fileService, ITDTicketHistoryService historyService)
        {
            _userManager = userManager;
            _projectSeervice = projectSeervice;
            _lookupService = lookupService;
            _ticketService = ticketService;
            _fileService = fileService;
            _historyService = historyService;
        }

        // GET : user tickets
        public async Task<IActionResult> MyTickets()
        {
            TDUser tdUser = await _userManager.GetUserAsync(User);

            List<Ticket> tickets = await _ticketService.GetTicketsByUserIdAsync(tdUser.Id, tdUser.CompanyId);

            return View(tickets);
        }

        // GET : All tickets
        public async Task<IActionResult> AllTickets()
        {
            int companyId = User.Identity.GetCompanyId().Value;

            List<Ticket> tickets = await _ticketService.GetAllTicketsByCompanyAsync(companyId);

            if (User.IsInRole(nameof(Roles.Developer)) || User.IsInRole(nameof(Roles.Submitter)))
            {
                return View(tickets.Where(t => t.Archived == false));
            }
            else
            {
                return View(tickets);
            }
        }

        // GET : Archived tickets
        public async Task<IActionResult> ArchivedTickets()
        {
            int companyId = User.Identity.GetCompanyId().Value;

            List<Ticket> tickets = await _ticketService.GetArchivedTicketsAsync(companyId);

            return View(tickets);
        }

        // GET: unassigned Tickets view
        [Authorize(Roles = "Admin, ProjectManager")]
        public async Task<IActionResult> UnassignedTickets()
        {
            int companyId = User.Identity.GetCompanyId().Value;
            string tdUserId = _userManager.GetUserId(User);
            List<Ticket> tickets = await _ticketService.GetUnassignedTicketsAsync(companyId);

            if (User.IsInRole(nameof(Roles.Admin)))
            {
                return View(tickets);
            }
            else
            {
                List<Ticket> pmTickets = new(0);

                foreach (Ticket ticket in tickets)
                {
                    if (await _projectSeervice.IsAssignedProjectManagerAsync(tdUserId, ticket.ProjectId))
                    {
                        pmTickets.Add(ticket);
                    }
                }

                return View(pmTickets);

            }
        }

        //GET: Assign developer to ticket
        [Authorize(Roles = "Admin, ProjectManager")]
        [HttpGet]
        public async Task<IActionResult> AssignDeveloper(int id)
        {
            AssignDeveloperViewModel model = new();

            model.Ticket = await _ticketService.GetTicketByIdAsync(id);
            model.Developers = new SelectList(await _projectSeervice.GetProjectMembersByRoleAsync(model.Ticket.ProjectId, nameof(Roles.Developer)), "Id", "FullName");

            return View(model);
        }

        //POST: Assign developer to ticket
        [Authorize(Roles = "Admin, ProjectManager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignDeveloper(AssignDeveloperViewModel model)
        {
            if (model.DeveloperId != null)
            {
                TDUser tdUser = await _userManager.GetUserAsync(User);
                //oldTicket
                Ticket oldTicket = await _ticketService.GetTicketNoTrackingAsync(model.Ticket.Id);


                try
                {
                    await _ticketService.AssignTicketAsync(model.Ticket.Id, model.DeveloperId);
                }
                catch (Exception)
                {

                    throw;
                }

                //newTicket
                Ticket newTicket = await _ticketService.GetTicketNoTrackingAsync(model.Ticket.Id);
                await _historyService.AddHistoryAsync(oldTicket, newTicket, tdUser.Id);

                return RedirectToAction(nameof(Details), new { id = model.Ticket.Id });
            }

            return RedirectToAction(nameof(AssignDeveloper), new { id = model.Ticket.Id });
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _ticketService.GetTicketByIdAsync(id.Value);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public async Task<IActionResult> Create()
        {
            TDUser tdUser = await _userManager.GetUserAsync(User);

            int companyId = User.Identity.GetCompanyId().Value;

            if (User.IsInRole(nameof(Roles.Admin)))
            {
                ViewData["ProjectId"] = new SelectList(await _projectSeervice.GetAllProjectsByCompanyAsync(companyId), "Id", "Name");
            }
            else
            {
                ViewData["ProjectId"] = new SelectList(await _projectSeervice.GetUserProjectsAsync(tdUser.Id), "Id", "Name");
            }

            ViewData["TicketPriorityId"] = new SelectList(await _lookupService.GetTicketPrioritiesAsync(), "Id", "Name");
            ViewData["TicketTypeId"] = new SelectList(await _lookupService.GetTicketTypesAsync(), "Id", "Name");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ProjectId,TicketTypeId,TicketPriorityId")] Ticket ticket)
        {
            TDUser tdUser = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {

                try
                {
                    ticket.Created = DateTimeOffset.Now;
                    ticket.OwnerUserId = tdUser.Id;

                    ticket.TicketStatusId = (await _ticketService.LookupTicketStatusIdAsync(nameof(TDTicketStatus.New))).Value;

                    await _ticketService.AddNewTicketAsync(ticket);

                    //TODO: Ticket History
                    Ticket newTicket = await _ticketService.GetTicketNoTrackingAsync(ticket.Id);
                    await _historyService.AddHistoryAsync(null, newTicket, tdUser.Id);

                    //TODO: Ticket Notification


                }
                catch (Exception)
                {

                    throw;
                }

                //return RedirectToAction(nameof(AllTickets));
                return RedirectToAction("Details", new { id = ticket.Id });

            }

            if (User.IsInRole(nameof(Roles.Admin)))
            {
                ViewData["ProjectId"] = new SelectList(await _projectSeervice.GetAllProjectsByCompanyAsync(tdUser.CompanyId), "Id", "Name");
            }
            else
            {
                ViewData["ProjectId"] = new SelectList(await _projectSeervice.GetUserProjectsAsync(tdUser.Id), "Id", "Name");
            }

            ViewData["TicketPriorityId"] = new SelectList(await _lookupService.GetTicketPrioritiesAsync(), "Id", "Name");
            ViewData["TicketTypeId"] = new SelectList(await _lookupService.GetTicketTypesAsync(), "Id", "Name");
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Ticket ticket = await _ticketService.GetTicketByIdAsync(id.Value);


            if (ticket == null)
            {
                return NotFound();
            }

            ViewData["TicketPriorityId"] = new SelectList(await _lookupService.GetTicketPrioritiesAsync(), "Id", "Name", ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(await _lookupService.GetTicketStatusesAsync(), "Id", "Name", ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(await _lookupService.GetTicketTypesAsync(), "Id", "Name", ticket.TicketTypeId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Created,Updated,Archived,ProjectId,TicketTypeId,TicketPriorityId,TicketStatusId,OwnerUserId,DeveloperUserId")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                TDUser tdUser = await _userManager.GetUserAsync(User);
                Ticket oldTicket = await _ticketService.GetTicketNoTrackingAsync(ticket.Id);

                try
                {
                    ticket.Updated = DateTimeOffset.Now;
                    await _ticketService.UpdateTicketAsync(ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                Ticket newTicket = await _ticketService.GetTicketNoTrackingAsync(ticket.Id);
                await _historyService.AddHistoryAsync(oldTicket, newTicket, tdUser.Id);

                return RedirectToAction(nameof(AllTickets));
            }

            ViewData["TicketPriorityId"] = new SelectList(await _lookupService.GetTicketPrioritiesAsync(), "Id", "Name", ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(await _lookupService.GetTicketStatusesAsync(), "Id", "Name", ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(await _lookupService.GetTicketTypesAsync(), "Id", "Name", ticket.TicketTypeId);

            return View(ticket);
        }


        // POST: Add comments
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTicketComment([Bind("Id,TicketId,Comment")] TicketComment ticketComment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ticketComment.UserId = _userManager.GetUserId(User);
                    ticketComment.Created = DateTimeOffset.Now;

                    await _ticketService.AddTicketCommentAsync(ticketComment);

                    //add history
                    await _historyService.AddHistoryAsync(ticketComment.TicketId, nameof(TicketComment), ticketComment.UserId);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return RedirectToAction("Details", new { id = ticketComment.TicketId });
        }

        // POST: Add attachments
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTicketAttachment([Bind("Id,FormFile,Description,TicketId")] TicketAttachment ticketAttachment)
        {
            string statusMessage;

            if (ModelState.IsValid && ticketAttachment.FormFile != null)
            {
                try
                {
                    ticketAttachment.FileDate = await _fileService.ConvertFileToByteArrayAsync(ticketAttachment.FormFile);
                    ticketAttachment.FileName = ticketAttachment.FormFile.FileName;
                    ticketAttachment.FileContentType = ticketAttachment.FormFile.ContentType;

                    ticketAttachment.Created = DateTimeOffset.Now;
                    ticketAttachment.UserId = _userManager.GetUserId(User);

                    await _ticketService.AddTicketAttachmentAsync(ticketAttachment);
                    //add history
                    await _historyService.AddHistoryAsync(ticketAttachment.TicketId, nameof(TicketAttachment), ticketAttachment.UserId);


                }
                catch (Exception)
                {

                    throw;
                }
                statusMessage = "Success: New attachment added to Ticket.";
            }
            else
            {
                statusMessage = "Error: Invalid data.";

            }

            return RedirectToAction("Details", new { id = ticketAttachment.TicketId, message = statusMessage });
        }

        //GET : download file
        public async Task<IActionResult> ShowFile(int id)
        {
            TicketAttachment ticketAttachment = await _ticketService.GetTicketAttachmentByIdAsync(id);
            string fileName = ticketAttachment.FileName;
            byte[] fileData = ticketAttachment.FileDate;
            string ext = Path.GetExtension(fileName).Replace(".", "");

            Response.Headers.Add("Content-Disposition", $"inline; filename={fileName}");
            return File(fileData, $"application/{ext}");
        }


        // GET: Tickets/Archive/5
        [Authorize(Roles = "Admin, ProjectManager")]
        public async Task<IActionResult> Archive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _ticketService.GetTicketByIdAsync(id.Value);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Archive/5
        [Authorize(Roles = "Admin, ProjectManager")]
        [HttpPost, ActionName("Archive")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveConfirmed(int id)
        {
            Ticket ticket = await _ticketService.GetTicketByIdAsync(id);
            ticket.Archived = true;
            await _ticketService.UpdateTicketAsync(ticket);


            return RedirectToAction(nameof(AllTickets));
        }

        // GET: Tickets/Restore/5
        [Authorize(Roles = "Admin, ProjectManager")]
        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _ticketService.GetTicketByIdAsync(id.Value);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Restore/5
        [Authorize(Roles = "Admin, ProjectManager")]
        [HttpPost, ActionName("Restore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int id)
        {
            Ticket ticket = await _ticketService.GetTicketByIdAsync(id);
            ticket.Archived = false;
            await _ticketService.UpdateTicketAsync(ticket);


            return RedirectToAction(nameof(AllTickets));
        }

        private async Task<bool> TicketExists(int id)
        {
            int companyId = User.Identity.GetCompanyId().Value;

            return (await _ticketService.GetAllTicketsByCompanyAsync(companyId)).Any(t => t.Id == id);
        }
    }
}
