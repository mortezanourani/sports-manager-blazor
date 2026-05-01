using CityApp.Models;
using CityApp.Identity;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CityApp.Data;

public class CityDbContext(DbContextOptions<CityDbContext> options) : IdentityDbContext<CityUser>(options)
{
    public DbSet<Facility> Facilities { get; set; }

    public DbSet<FacilityContract> FacilityContracts { get; set; }

    public DbSet<FacilityDocument> FacilityDocuments { get; set; }

    public DbSet<FacilityType> FacilityTypes { get; set; }

    public DbSet<Federation> Federations { get; set; }

    public DbSet<Gender> Genders { get; set; }

    public DbSet<GovernmentFacility> GovernmentFacilities { get; set; }

    public DbSet<GovernmentFacilityLicense> GovernmentFacilityLicenses { get; set; }

    public DbSet<Insurance> Insurances { get; set; }

    public DbSet<LocalFederation> LocalFederations { get; set; }

    public DbSet<LocalFederationPresident> LocalFederationPresidents { get; set; }

    public DbSet<PrivateFacility> PrivateFacilities { get; set; }

    public DbSet<PrivateFacilityLicense> PrivateFacilityLicenses { get; set; }

    public DbSet<UsersGender> UsersGenders { get; set; }

    public DbSet<Population> Population { get; set; } = default!;
}
