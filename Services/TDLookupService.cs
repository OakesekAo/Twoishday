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

		public async Task<List<TicketPriority>> GetTicketPrioritiesAsync()
        {
            try
            {
                return await _context.TicketPriorities.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

		public async Task<List<TicketStatus>> GetTicketStatusesAsync()
        {
            try
            {
                return await _context.TicketStatuses.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

		public async Task<List<TicketType>> GetTicketTypesAsync()
        {
            try
            {
                return await _context.TicketTypes.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
	}
}
