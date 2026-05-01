using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProvinceApp.Identity;
using ProvinceApp.Models;

namespace ProvinceApp.Data;

public class ProvinceDbContext(DbContextOptions<ProvinceDbContext> options) : IdentityDbContext<ProvinceUser>(options)
{
    public DbSet<AgeGroup> AgeGroups { get; set; }

    public DbSet<Athlete> Athletes { get; set; }

    public DbSet<Champion> Champions { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<ConstructionProject> ConstructionProjects { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<EmploymentType> EmploymentTypes { get; set; }

    public DbSet<Facility> Facilities { get; set; }

    public DbSet<FacilityContract> FacilityContracts { get; set; }

    public DbSet<FacilityDocument> FacilityDocuments { get; set; }

    public DbSet<FacilityType> FacilityTypes { get; set; }

    public DbSet<Federation> Federations { get; set; }

    public DbSet<FundingSource> FundingSources { get; set; }

    public DbSet<Gender> Genders { get; set; }

    public DbSet<GovernmentFacility> GovernmentFacilities { get; set; }

    public DbSet<GovernmentFacilityLicense> GovernmentFacilityLicenses { get; set; }

    public DbSet<Insurance> Insurances { get; set; }

    public DbSet<LocalFederation> LocalFederations { get; set; }

    public DbSet<LocalFederationPresident> LocalFederationPresidents { get; set; }

    public DbSet<Medal> Medals { get; set; }

    public DbSet<PrivateFacility> PrivateFacilities { get; set; }

    public DbSet<PrivateFacilityLicense> PrivateFacilityLicenses { get; set; }

    public DbSet<ProjectBudget> ProjectBudgets { get; set; }

    public DbSet<ProjectProgress> ProjectProgresses { get; set; }

    public DbSet<ProjectType> ProjectTypes { get; set; }

    public DbSet<Tournament> Tournaments { get; set; }

    public DbSet<TournamentLevel> TournamentLevels { get; set; }

    public DbSet<UsersGender> UsersGenders { get; set; }

    public DbSet<Population> Population { get; set; } = default!;

}
