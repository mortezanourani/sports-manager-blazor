using Microsoft.AspNetCore.Identity;

namespace CityApp.Identity;

public class CityUser : IdentityUser
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? FatherName { get; set; }
 
    public string? BirthDate { get; set; }

    public string? PersonnelId { get; set; }
}
