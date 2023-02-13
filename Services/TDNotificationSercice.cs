using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twoishday.Data;
using Twoishday.Models;
using Twoishday.Services.Interfaces;

namespace Twoishday.Services
{
    public class TDNotificationSercice : ITDNotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly ITDRolesService _rolesService;

        public TDNotificationSercice(ApplicationDbContext context,
                                IEmailSender emailSender,
                                ITDRolesService rolesService)
        {
            _context = context;
            _emailSender = emailSender;
            _rolesService = rolesService;
        }
        public async Task AddNotificationAsync(Notification notification)
        {
            try
            {
                await _context.AddAsync(notification);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Notification>> GetReceivedNotificationsAsync(string userId)
        {
            try
            {
                List<Notification> notifications = await _context.Notifications
                                                                 .Include(n => n.Recipient)
                                                                 .Include(n => n.Sender)
                                                                 .Include(n => n.Ticket)
                                                                    .ThenInclude(t => t.Project)
                                                                 .Where(n => n.RecipientId == userId).ToListAsync();
                return notifications;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Notification>> GetSentNotificationsAsync(string userId)
        {
            try
            {
                List<Notification> notifications = await _context.Notifications
                                                                 .Include(n => n.Recipient)
                                                                 .Include(n => n.Sender)
                                                                 .Include(n => n.Ticket)
                                                                    .ThenInclude(t => t.Project)
                                                                 .Where(n => n.SenderId == userId).ToListAsync();
                return notifications;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SendEmailNotificationAsync(Notification notification, string emailSubject)
        {
            TDUser tdUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == notification.RecipientId);
            if (tdUser == null)
            {
                string tdUserEmail = tdUser.Email;
                string message = notification.Message;

                //send email
                try
                {
                    await _emailSender.SendEmailAsync(tdUserEmail, emailSubject, message);
                    return true;

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task SendEmailNotificationByRoleAsync(Notification notification, int companyId, string role)
        {
            try
            {
                List<TDUser> members = await _rolesService.GetUserInRoleAsync(role, companyId);
                foreach (TDUser tdUser in members)
                {
                    notification.RecipientId = tdUser.Id;
                    await SendEmailNotificationAsync(notification, notification.Title);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SendMembersEmailNotificatoinsAsync(Notification notification, List<TDUser> members)
        {
            try
            {
                foreach (TDUser tdUser in members)
                {
                    notification.RecipientId = tdUser.Id;
                    await SendEmailNotificationAsync(notification, notification.Title);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
