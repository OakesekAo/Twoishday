using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Models;

namespace Twoishday.Services.Interfaces
{
	public interface ITDLookupService
	{
		public Task<List<TicketPriority>> GetTicketPrioritiesAsync();
		public Task<List<TicketStatus>> GetTicketStatusesAsync();
		public Task<List<TicketType>> GetTicketTypesAsync();
		public Task<List<ProjectPriority>> GetProjectPrioritiesAsync();
	}
}
