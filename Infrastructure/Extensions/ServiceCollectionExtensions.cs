using Infrastructure.Components.Account;
using Infrastructure.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection Services,
        string connectionString)
    {
        Services.AddDbContextFactory<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        //Services.AddScoped<IdentityUserAccessor>();
        Services.AddScoped<IdentityRedirectManager>();
        //Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        return Services;
    }
}
