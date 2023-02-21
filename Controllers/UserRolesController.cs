using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twoishday.Extensions;
using Twoishday.Models;
using Twoishday.Models.ViewModels;
using Twoishday.Services.Interfaces;

namespace Twoishday.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly ITDRolesService _roleService;
        private readonly ITDCompanyInfoService _companyInfoService;
        


        public UserRolesController(ITDRolesService roleService, ITDCompanyInfoService companyInfoService)
        {
            _roleService = roleService;
            _companyInfoService = companyInfoService;
        }
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
            foreach(TDUser user in users)
            {
                ManageUserRolesViewModel viewModel = new();
                viewModel.TDUser = user;
                IEnumerable<string> selected = await _roleService.GetUserRolesAsync(user);
                viewModel.Roles = new MultiSelectList(await _roleService.)
            }


            //retun the view
            return View();
        }
    }
}
