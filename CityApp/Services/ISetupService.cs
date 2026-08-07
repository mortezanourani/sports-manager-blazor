using CityApp.Identity;

namespace CityApp.Services;

public interface ISetupService
{
    Task<SetupStatus> GetStatusAsync();
    Task RunSetupAsync(string AdminUsername, string FirstName, string LastName, string AdminEmail, string AdminPassword);
}

public record SetupStatus(
    bool DbReachable,
    bool MigrationsApplied,
    bool GendersExists,
    bool UsersGendersExists,
    bool FacilityTypesExists,
    bool FederationsExists,
    bool RolesExists,
    bool SuperAdminExists)
{
    public bool IsComplete => 
        DbReachable && 
        MigrationsApplied && 
        GendersExists &&
        UsersGendersExists &&
        FacilityTypesExists &&
        FederationsExists &&
        RolesExists &&
        SuperAdminExists;
}
