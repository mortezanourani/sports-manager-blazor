using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using msy.Components;
using msy.Components.Account;
using msy.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddAuthorization(options =>
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
