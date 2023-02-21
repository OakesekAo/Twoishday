using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twoishday.Extensions;
using Twoishday.Models;
using Twoishday.Models.ViewModels;
using Twoishday.Services.Interfaces;

namespace Twoishday.Controllers
{
    [Authorize]
    public class UserRolesController : Controller
    {
        private readonly ITDRolesService _roleService;
        private readonly ITDCompanyInfoService _companyInfoService;



        public UserRolesController(ITDRolesService roleService, ITDCompanyInfoService companyInfoService)
        {
            _roleService = roleService;
            _companyInfoService = companyInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles()
        {
            // add an instance of the ViewModel as a List (model)
            List<ManageUserRolesViewModel> model = new();

            //Get CompanyId
            int companyId = User.Identity.GetCompanyId().Value;

            //Get a;; company users
            List<TDUser> users = await _companyInfoService.GetAllMembersAsync(companyId);

            //Loop over the users to pop the ViewModel
            // - instantiate ViewModel
            // use _roleService
            // create multi-selects
            foreach (TDUser user in users)
            {
                ManageUserRolesViewModel viewModel = new();
                viewModel.TDUser = user;
                IEnumerable<string> selected = await _roleService.GetUserRolesAsync(user);
                viewModel.Roles = new MultiSelectList(await _roleService.GetRoleAsync(), "Name", "Name", selected);


                model.Add(viewModel);
            }


            //retun the view
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUserRoles(ManageUserRolesViewModel member)
        {
            //get companyId
            int companyId = User.Identity.GetCompanyId().Value;

            // instantiate user
            TDUser tdUser = (await _companyInfoService.GetAllMembersAsync(companyId)).FirstOrDefault(u => u.Id == member.TDUser.Id);

            //get roles for the user
            IEnumerable<string> roles = await _roleService.GetUserRolesAsync(tdUser);

            //get selected role
            string userRole = member.SelectedRoles.FirstOrDefault();

            if (!string.IsNullOrEmpty(userRole))
            {
                //remove user from all roles
                if(await _roleService.RemoveUserFromRoleAsync(tdUser, roles))
                {
                    //add use to the new role
                    await _roleService.AddUserToRoleAsync(tdUser, userRole);

                }

            }


            //send back to View
            return RedirectToAction(nameof(ManageUserRoles));
        }
    }
}
