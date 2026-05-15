using CityApp.Data;
using CityApp.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CityApp.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<CityUser> userManager,
            IdentityRedirectManager redirectManager,
            AuthenticationStateProvider authenticationStateProvider)
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

        public async Task<CityUser?> GetCurrentUser()
        {
            var authstate = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authstate == null)
            {
                return null;
            }

            var user = await userManager.GetUserAsync(authstate.User);
            return user;
        }
    }
}
