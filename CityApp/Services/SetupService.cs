using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CityApp.Identity;
using CityApp.Data;

namespace CityApp.Services;

public class SetupService : ISetupService
{
    private readonly IDbContextFactory<CityDbContext> _dbContextFactory;
    private readonly UserManager<CityUser> _userManager;
    private readonly RoleManager<CityRole> _roleManager;

    public SetupService(
        IDbContextFactory<CityDbContext> dbContextFactory,
        UserManager<CityUser> userManager,
        RoleManager<CityRole> roleManager)
    {
        _dbContextFactory = dbContextFactory;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<SetupStatus> GetStatusAsync()
    {
        await using var db = await _dbContextFactory.CreateDbContextAsync();

        bool reachable;
        try {  reachable = await db.Database.CanConnectAsync(); }
        catch { reachable = false; }

        bool migrated = false;
        if (reachable)
        {
            var pending = await db.Database.GetPendingMigrationsAsync();
            migrated = !pending.Any();
        }

        bool hasAdmin = false;
        if (migrated)
        {
            var admins = await _userManager.GetUsersInRoleAsync("SuperAdministrator");
            hasAdmin = admins.Count > 0;
        }

        return new SetupStatus(reachable, migrated, hasAdmin);
    }

    public async Task RunSetupAsync(string adminUsername, string FirstName, string LastName, string adminEmail, string adminPassword)
    {
        await using var db = await _dbContextFactory.CreateDbContextAsync();
        await db.Database.MigrateAsync();

        if (!await _roleManager.RoleExistsAsync("SuperAdministrator"))
        {
            await _roleManager.CreateAsync(new CityRole { Name = "SuperAdministrator" });
        }

        var existing = await _userManager.FindByNameAsync(adminUsername);
        if (existing is null)
        {
            var superAdmin = new CityUser
            {
                UserName = adminUsername,
                FirstName = FirstName,
                LastName = LastName,
                Email = adminEmail,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(superAdmin, adminPassword);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        var isAdmin = await _userManager.IsInRoleAsync(existing, "SuperAdministrator");
        if (isAdmin is false)
        {
            await _userManager.AddToRoleAsync(existing, "SuperAdministrator");
        }
    }
}
