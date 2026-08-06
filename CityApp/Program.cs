using CityApp.Components;
using CityApp.Data;
using CityApp.Identity;
using Microsoft.EntityFrameworkCore;
using CityApp.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using CityApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("CityConnection");

builder.Services.AddDbContextFactory<CityDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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

builder.Services.AddIdentityCore<CityUser>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
})
    .AddRoles<CityRole>()
    .AddEntityFrameworkStores<CityDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<CityUser>, IdentityNoOpEmailSender>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("FullAccess", policy =>
        policy.RequireRole("SuperAdministrator"));

    options.AddPolicy("Administrator", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("SuperAdministrator")
            ||
            context.User.IsInRole("Administrator")
        )
    );

    options.AddPolicy("Sports", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("SuperAdministrator")
            ||
            context.User.IsInRole("Administrator")
            ||
            context.User.IsInRole("SportsManager")
        )
    );

    options.AddPolicy("M88", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("SuperAdministrator")
            ||
            context.User.IsInRole("Administrator")
            ||
            context.User.IsInRole("M88Manager")
        )
    );

    options.AddPolicy("M5", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("SuperAdministrator")
            ||
            context.User.IsInRole("Administrator")
            ||
            context.User.IsInRole("M5Manager")
        )
    );

    options.AddPolicy("Insurance", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("SuperAdministrator")
            ||
            context.User.IsInRole("Administrator")
            ||
            context.User.IsInRole("InsuranceManager")
        )
    );
});

builder.Services.AddScoped<ISetupService, SetupService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.Use(async (context, next) =>
{
    var path = context.Request.Path;
    if (path.StartsWithSegments("/setup") ||
        path.StartsWithSegments("/_blazor") ||
        path.StartsWithSegments("/_framework") ||
        path.StartsWithSegments("/css") ||
        path.StartsWithSegments("/js"))
    {
        await next();
        return;
    }
    if (!SetupGate.ConfirmedComplete)
    {
        var serupService = context.RequestServices.GetRequiredService<ISetupService>();
        var status = await serupService.GetStatusAsync();

        if (status.IsComplete)
        {
            SetupGate.ConfirmedComplete = true;
        }
        else
        {
            context.Response.Redirect("/setup");
            return;
        }
    }

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

app.Run();
