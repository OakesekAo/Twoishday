using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Data;
using Twoishday.Models;
using Twoishday.Services.Interfaces;

namespace Twoishday.Services
{
    public class TDRoleService : ITDRolesService
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<TDUser> _userManager;


        public TDRoleService(ApplicationDbContext context,
                            RoleManager<IdentityRole> roleManager,
                            UserManager<TDUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task<bool> AddUserToRoleAsync(TDUser user, string roleName)
        {
            bool result = (await _userManager.AddToRoleAsync(user, roleName)).Succeeded;
            return result;
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
