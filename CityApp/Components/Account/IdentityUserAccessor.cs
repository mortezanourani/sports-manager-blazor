using CityApp.Data;
using CityApp.Identity;
using Microsoft.AspNetCore.Identity;

namespace CityApp.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<CityUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<CityUser> GetRequiredUserAsync(HttpContext context)
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
