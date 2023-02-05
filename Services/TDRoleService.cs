using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<string> GetRoleNameByIdAsync(string roleId)
        {
            IdentityRole role = _context.Roles.Find(roleId);
            string result = await _roleManager.GetRoleNameAsync(role);
            return result;
        }

        public async Task<List<TDUser>> GetUserInRoleAsync(string roleName, int companyId)
        {
            List<TDUser> users = (await _userManager.GetUsersInRoleAsync(roleName)).ToList();
            List<TDUser> result = users.Where(u => u.CompanyId == companyId).ToList();
            return result;
        }

        public async Task<List<TDUser>> GetUserNotInRoleAsync(string roleName, int companyId)
        {
            List<string> userIds = (await _userManager.GetUsersInRoleAsync(roleName)).Select(u => u.Id).ToList();
            List<TDUser> roleUsers = _context.Users.Where(u => !userIds.Contains(u.Id)).ToList();
            List<TDUser> result = roleUsers.Where(u => u.CompanyId == companyId).ToList();

            return result;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(TDUser user)
        {
            IEnumerable<string> result = await _userManager.GetRolesAsync(user);
            return result;
        }

        public async Task<bool> IsUserInRoleAsync(TDUser user, string roleName)
        {
            bool result = await _userManager.IsInRoleAsync(user, roleName);
            return result;
        }

        public async Task<bool> RemoveUserFromRoleAsync(TDUser user, string roleName)
        {
            bool result = (await _userManager.RemoveFromRoleAsync(user, roleName)).Succeeded;
            return result;
        }

        public async Task<bool> RemoveUserFromRoleAsync(TDUser user, IEnumerable<string> roles)
        {
            bool result = (await _userManager.RemoveFromRolesAsync(user, roles)).Succeeded;
            return result;
        }
    }
}
