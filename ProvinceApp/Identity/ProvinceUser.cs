using Microsoft.AspNetCore.Identity;

namespace ProvinceApp.Identity;

public class ProvinceUser : IdentityUser
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? FatherName { get; set; }

    public string? BirthDate { get; set; }

    public string? PersonnelId { get; set; }
}
