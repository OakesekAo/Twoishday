using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Models;

namespace Twoishday.Services.Interfaces
{
    public interface ITDTicketHistoryService
    {
        Task AddHistoryAsync(Ticket oldTicket, Ticket newTicket, string userId);
        Task AddHistoryAsync(int ticketId, string model, string userId);

        Task<List<TicketHistory>> GetProjectTicketsHistoriesAsync(int projectId, int companyId);

        Task<List<TicketHistory>> GetCompanyTicketsHistoriesAsync(int companyId);


    }
}
