using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Twoishday.Models.ViewModels
{
    public class ManageUserRolesViewModel
    {
        public TDUser TDUser { get; set; }
        public MultiSelectList Roles { get; set; }
        public List<string> SelectedRoles { get; set; }
    }
}
