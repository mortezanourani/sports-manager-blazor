using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BasePrivateFacilityLicense
{
    public Guid Id { get; set; }

    public bool? IsBeneficial { get; set; }

    public bool? IsOwner { get; set; }

    public bool? IsRenewal { get; set; }

    public string? Serial { get; set; }

    public string? StartDate { get; set; }

    public string? ExpireDate { get; set; }

    public string? MenSports { get; set; }

    public string? WomenSports { get; set; }

    public string? Company { get; set; }

    public string Name { get; set; } = null!;

    public string? SeenCode { get; set; }

    public string? Phone { get; set; }
}
