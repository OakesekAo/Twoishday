using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;
using Twoishday.Models;

namespace Twoishday.Services.Factories
{
    public class TDUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<TDUser, IdentityRole>
    {
        public TDUserClaimsPrincipalFactory(UserManager<TDUser> userManager,
                                            RoleManager<IdentityRole> roleManager,
                                            IOptions<IdentityOptions> optionsAccessor)
                                            : base(userManager,roleManager,optionsAccessor)
                                            {                                                
                                            }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(TDUser user)
        {
            ClaimsIdentity identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("CompanyId", user.CompanyId.ToString()));


            return identity;
        }
    }
}
