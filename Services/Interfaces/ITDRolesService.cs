using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Models;

namespace Twoishday.Services.Interfaces
{
    public interface ITDRolesService
    {
        public Task<bool> IsUserInRoleAsync(TDUser user, string roleName);

        public Task<List<IdentityRole>> GetRoleAsync();

        public Task<IEnumerable<string>> GetUserRolesAsync(TDUser user);

        public Task<bool> AddUserToRoleAsync(TDUser user, string roleName);

        public Task<bool> RemoveUserFromRoleAsync(TDUser user, string roleName);

        public Task<bool> RemoveUserFromRoleAsync(TDUser user, IEnumerable<string> roles);

        

        public Task<List<TDUser>> GetUserInRoleAsync(string roleName, int companyId);

        public Task<List<TDUser>> GetUserNotInRoleAsync(string roleName, int companyId);

        public Task<string> GetRoleNameByIdAsync(string roleId);

    }
}
