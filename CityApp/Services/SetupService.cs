using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CityApp.Identity;
using CityApp.Data;
using Infrastructure.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

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

        bool hasGenders = false;
        if (reachable)
        {
            var genders = await db.Genders.ToListAsync();
            hasGenders = genders.Count > 0;
        }

        bool hasUsersGenders = false;
        if (reachable)
        {
            var usersGenders = await db.UsersGenders.ToListAsync();
            hasUsersGenders = usersGenders.Count > 0;
        }

        bool hasFacilityTypes = false;
        if (reachable)
        {
            var facilityTypes = await db.FacilityTypes.ToListAsync();
            hasFacilityTypes = facilityTypes.Count > 0;
        }

        bool hasFederations = false;
        if (reachable)
        {
            var federations = await db.Federations.ToListAsync();
            hasFederations = federations.Count > 0;
        }

        bool hasRoles = false;
        if (reachable)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            hasRoles = roles.Count > 2;
        }

        return new SetupStatus(
            reachable,
            migrated,
            hasGenders,
            hasUsersGenders,
            hasFacilityTypes,
            hasFederations,
            hasRoles,
            hasAdmin
            );
    }

    public async Task RunSetupAsync(string adminUsername, string FirstName, string LastName, string adminEmail, string adminPassword)
    {
        await using var db = await _dbContextFactory.CreateDbContextAsync();
        await db.Database.MigrateAsync();

        var gendersExists = await db.Genders.CountAsync();
        if (gendersExists == 0)
        {
            var genders = new List<Gender>()
            {
                new Gender { Name = "Female", PersianName = "زن" },
                new Gender { Name = "Male", PersianName = "مرد" }
            };
            await db.Genders.AddRangeAsync(genders);
            await db.SaveChangesAsync();
        }

        var usersGendersExists = await db.UsersGenders.CountAsync();
        if (usersGendersExists == 0)
        {
            var usersGenders = new List<UsersGender>()
            {
                new UsersGender { Name = "Men", PersianName = "آقایان" },
                new UsersGender { Name = "Women", PersianName = "بانوان" },
                new UsersGender { Name = "Mixed", PersianName = "مشترک" }
            };
            await db.UsersGenders.AddRangeAsync(usersGenders);
            await db.SaveChangesAsync();
        }

        var facilityTypesExists = await db.FacilityTypes.CountAsync();
        if (facilityTypesExists == 0)
        {
            var facilityTypes = new List<FacilityType>()
            {
                new FacilityType { Type = "Hall", PersianTitle = "سرپوشیده" },
                new FacilityType { Type = "Land", PersianTitle = "روباز" },
                new FacilityType { Type = "Office", PersianTitle = "دفتر باشگاه" }
            };
            await db.FacilityTypes.AddRangeAsync(facilityTypes);
            await db.SaveChangesAsync();
        }

        var federationsExists = await db.Federations.CountAsync();
        if (federationsExists == 0)
        {
            var federations = new List<Federation>()
            {
                new Federation { Name = "Squash", PersianName = "اسکواش", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Skiing", PersianName = "اسکی و ورزش های زمستانی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Skate", PersianName = "اسکیت", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Fitness", PersianName = "آمادگی جسمانی و تندرستی", IsGeneral = true, IsChampionship = false, IsPara = false },
                new Federation { Name = "Martial", PersianName = "انجمن های ورزش های رزمی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "SportsAssociations", PersianName = "انجمن های ورزشی", IsGeneral = true, IsChampionship = false, IsPara = false },
                new Federation { Name = "Badminton", PersianName = "بدمینتون", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Bodybuilding", PersianName = "بدنسازی و پرورش اندام", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Basketball", PersianName = "بسکتبال", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Boxing", PersianName = "بوکس", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Bowling", PersianName = "بولینگ و بیلیارد و بولس", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Medicine", PersianName = "پزشکی ورزشی", IsGeneral = false, IsChampionship = false, IsPara = false },
                new Federation { Name = "Taekwondo", PersianName = "تکواندو", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Shooting", PersianName = "تیراندازی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Archery", PersianName = "تیر و کمان", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Tennis", PersianName = "تنیس", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "TableTennis", PersianName = "تنیس روی میز", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Judo", PersianName = "جودو", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Polo", PersianName = "چوگان", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Cycling", PersianName = "دوچرخه سواری", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "TrackAndField", PersianName = "دو و میدانی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Gymnastics", PersianName = "ژیمناستیک", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "HorsebackRiding", PersianName = "سوارکاری", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Chess", PersianName = "شطرنج", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Fencing", PersianName = "شمشیر بازی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "WaterSports", PersianName = "ورزش های آبی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Football", PersianName = "فوتبال", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Boating", PersianName = "قایقرانی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Karate", PersianName = "کاراته", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Kabaddi", PersianName = "کبدی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Wrestling", PersianName = "کشتی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "KungFu", PersianName = "کونگ فو و هنرهای رزمی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Mountaineering", PersianName = "کوهنوردی و صعودهای ورزشی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Golf", PersianName = "گلف", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "University", PersianName = "ورزش های دانشگاهی", IsGeneral = true, IsChampionship = false, IsPara = false },
                new Federation { Name = "Racing", PersianName = "موتورسواری و اتومبیل رانی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Diving", PersianName = "نجات غریق و غواصی", IsGeneral = false, IsChampionship = false, IsPara = false },
                new Federation { Name = "Volleyball", PersianName = "والیبال", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "SpecialMedical", PersianName = "ورزش بیماران خاص و پیوند اعضاء", IsGeneral = false, IsChampionship = false, IsPara = true },
                new Federation { Name = "School", PersianName = "ورزش دانش آموزی", IsGeneral = true, IsChampionship = false, IsPara = false },
                new Federation { Name = "Rural", PersianName = "ورزش روستایی و بازی های بومی محلی", IsGeneral = true, IsChampionship = false, IsPara = false },
                new Federation { Name = "Trilogy", PersianName = "سه گانه", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Labor", PersianName = "ورزش کارگری", IsGeneral = true, IsChampionship = false, IsPara = false },
                new Federation { Name = "Disabilities", PersianName = "ورزش جانبازان و توان یابان", IsGeneral = false, IsChampionship = false, IsPara = true },
                new Federation { Name = "Zourkhaneh", PersianName = "ورزش های زورخانه ای و کشتی پهلوانی", IsGeneral = true, IsChampionship = false, IsPara = false },
                new Federation { Name = "Blinds", PersianName = "نابینایان و کم بینایان", IsGeneral = false, IsChampionship = false, IsPara = true },
                new Federation { Name = "Deafs", PersianName = "ورزش های ناشنوایان", IsGeneral = false, IsChampionship = false, IsPara = true },
                new Federation { Name = "Universal", PersianName = "ورزش های همگانی", IsGeneral = true, IsChampionship = false, IsPara = false },
                new Federation { Name = "WeightLifting", PersianName = "وزنه برداری", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Wushu", PersianName = "ووشو", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Hockey", PersianName = "هاکی", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Handball", PersianName = "هندبال", IsGeneral = false, IsChampionship = true, IsPara = false },
                new Federation { Name = "Rowing", PersianName = "روئینگ", IsGeneral = false, IsChampionship = true, IsPara = false },
            };
            await db.Federations.AddRangeAsync(federations);
            await db.SaveChangesAsync();
        }

        var rolesExists = await _roleManager.Roles.CountAsync();
        if (rolesExists < 3)
        {
            var roles = new List<CityRole>()
            {
                new CityRole { Name = "SuperAdministrator", Title = "مدیر ارشد" },
                new CityRole { Name = "Administrator", Title = "مدیر" },
                new CityRole { Name = "SportsManager", Title = "کارشناس ورزش" },
                new CityRole { Name = "M88Manager", Title = "کارشناس ماده 88" },
                new CityRole { Name = "M5Manager", Title = "کارشناس امور باشگاه ها" },
                new CityRole { Name = "InsuranceManager", Title = "کارشناس بیمه ورزشی" },
                new CityRole { Name = "Federation", Title = "رئیس هیات" },
            };

            foreach (CityRole role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role.Name!))
                {
                    await _roleManager.CreateAsync(role);
                }
            }
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

        var isAdmin = await _userManager.IsInRoleAsync(existing!, "SuperAdministrator");
        if (isAdmin is false)
        {
            await _userManager.AddToRoleAsync(existing!, "SuperAdministrator");
        }
    }
}
