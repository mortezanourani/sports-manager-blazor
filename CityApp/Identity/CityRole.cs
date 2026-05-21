using Microsoft.AspNetCore.Identity;

namespace CityApp.Identity;

public class CityRole : IdentityRole
{
    public string? Title { get; set; }
}
