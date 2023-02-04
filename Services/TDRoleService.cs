using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Models;
using Twoishday.Services.Interfaces;

namespace Twoishday.Services
{
    public class TDRoleService : ITDRolesService
    {
        public Task<bool> AddUserToRoleAsync(TDUser user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleNameByIdAsync(string roleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TDUser>> GetUserInRoleAsync(string roleName, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TDUser>> GetUserNotInRoleAsync(string roleName, int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetUserRolesAsync(TDUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsUserInRoleAsync(TDUser user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveUserFromRoleAsync(TDUser user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveUserFromRoleAsync(TDUser user, IEnumerable<string> roles)
        {
            throw new System.NotImplementedException();
        }
    }
}
