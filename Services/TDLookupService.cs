using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Data;
using Twoishday.Models;
using Twoishday.Services.Interfaces;

namespace Twoishday.Services
{
	public class TDLookupService : ITDLookupService
	{
		private readonly ApplicationDbContext _context;

		public TDLookupService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<ProjectPriority>> GetProjectPrioritiesAsync()
		{
			try
			{
				return await _context.ProjectPriorities.ToListAsync();
			}
			catch (System.Exception)
			{

				throw;
			}
		}

		public Task<List<TicketPriority>> GetTicketPrioritiesAsync()
		{

            throw new System.NotImplementedException();
        }

		public Task<List<TicketStatus>> GetTicketStatusesAsync()
		{
			throw new System.NotImplementedException();
		}

		public Task<List<TicketType>> GetTicketTypesAsync()
		{
			throw new System.NotImplementedException();
		}
	}
}
