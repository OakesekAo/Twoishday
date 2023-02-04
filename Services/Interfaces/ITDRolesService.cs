using System.Threading.Tasks;
using Twoishday.Models;

namespace Twoishday.Services.Interfaces
{
    public interface ITDRolesService
    {
        public Task<bool> IsUserInRoleAsync(TDUser user, string roleName);
    }
}
