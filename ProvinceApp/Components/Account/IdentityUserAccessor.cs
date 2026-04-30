using ProvinceApp.Data;
using ProvinceApp.Identity;
using Microsoft.AspNetCore.Identity;

namespace ProvinceApp.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<ProvinceUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<ProvinceUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
