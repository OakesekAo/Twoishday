using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Models;

namespace Twoishday.Services.Interfaces
{
    public interface ITDCompanyInfoService
    {
        public Task<Company> GetCompanyInfoByIdAsync(int? companyId);
        
        public Task<List<TDUser>> GetAllMembersAsync(int companyId);

        public Task<List<Project>> GetAllProjectsAsync(int companyId);

        public Task<List<Ticket>> GetAllTicketsAsync(int companyId);
        
    }
}
