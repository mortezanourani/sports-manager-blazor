using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddInfrastructureIdentity(
        this IServiceCollection Services,
        string connectionString)
    {
        Services.AddDbContextFactory<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
            options.SignIn.RequireConfirmedAccount = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders()
        .AddSignInManager();

        return Services;
    }
}
