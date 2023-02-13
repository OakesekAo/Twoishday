using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Models;

namespace Twoishday.Services.Interfaces
{
    public interface ITDNotificationService
    {
        public Task AddNotificationAsync(Notification notification);

        public Task<List<Notification>> GetReceivedNotificationsAsync(string userId);

        public Task<List<Notification>> GetSentNotificationsAsync(string userId);

        public Task SendEmailNotificationByRoleAsync(Notification notification, int companyId, string role);

        public Task SendMembersEmailNotificatoinsAsync(Notification notification, List<TDUser> members);

        public Task<bool> SendEmailNotificationAsync(Notification notification, string emailSubject);
    }
}
