using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

            return View();
        }
    }
}
