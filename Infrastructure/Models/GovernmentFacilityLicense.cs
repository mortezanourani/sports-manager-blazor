using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseGovernmentFacilityLicense
{
    public Guid Id { get; set; }

    public string? Serial { get; set; }

    public string? StartDate { get; set; }

    public string? ExpireDate { get; set; }

    public string? MenSports { get; set; }

    public string? WomenSports { get; set; }

    public string Name { get; set; } = null!;

    public string? SeenCode { get; set; }

    public string? Phone { get; set; }
}
