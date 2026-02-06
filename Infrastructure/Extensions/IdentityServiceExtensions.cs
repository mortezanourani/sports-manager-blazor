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

        Services.AddAuthorization(options =>
        {
            options.AddPolicy("FullAccess", policy =>
                policy.RequireRole("SuperAdministrator"));

            options.AddPolicy("HR_Admin", policy =>
                policy.RequireAssertion(context =>
                {
                    if (context.User.IsInRole("SuperAdministrator"))
                        return true;

                    if (!context.User.IsInRole("Administrator"))
                        return false;

                    var DepartmentClaim = context.User.FindFirst("HumanResource")?.Value;
                    var IsInDepartment = DepartmentClaim == true.ToString();
                    return IsInDepartment;
                })
            );

            options.AddPolicy("HR_Manager", policy =>
                policy.RequireAssertion(context =>
                {
                    if (context.User.IsInRole("SuperAdministrator"))
                        return true;

                    if (!(context.User.IsInRole("Administrator") || context.User.IsInRole("Manager")))
                        return false;

                    var DepartmentClaim = context.User.FindFirst("HumanResource")?.Value;
                    var IsInDepartment = DepartmentClaim == true.ToString();
                    return IsInDepartment;
                })
            );

            options.AddPolicy("M5_Admin", policy =>
                policy.RequireAssertion(context =>
                {
                    if (context.User.IsInRole("SuperAdministrator"))
                        return true;

                    if (!context.User.IsInRole("Administrator"))
                        return false;

                    var DepartmentClaim = context.User.FindFirst("M5")?.Value;
                    var IsInDepartment = DepartmentClaim == true.ToString();
                    return IsInDepartment;
                })
            );

            options.AddPolicy("M88_Admin", policy =>
                policy.RequireAssertion(context =>
                {
                    if (context.User.IsInRole("SuperAdministrator"))
                        return true;

                    if (!context.User.IsInRole("Administrator"))
                        return false;

                    var DepartmentClaim = context.User.FindFirst("M88")?.Value;
                    var IsInDepartment = DepartmentClaim == true.ToString();
                    return IsInDepartment;
                })
            );

            options.AddPolicy("SportsGroup_Admin", policy =>
                policy.RequireAssertion(context =>
                {
                    if (context.User.IsInRole("SuperAdministrator"))
                        return true;

                    if (!context.User.IsInRole("Administrator"))
                        return false;

                    var DepartmentClaim = context.User.FindFirst("SportsGroup")?.Value;
                    var IsInDepartment = DepartmentClaim == true.ToString();
                    return IsInDepartment;
                })
            );
        });

        return Services;
    }
}
