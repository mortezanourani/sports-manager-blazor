using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BasePrivateFacility
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? District { get; set; }

    public bool? IsRural { get; set; }

    public int? Area { get; set; }

    public int? SportHallArea { get; set; }

    public int? SportLandArea { get; set; }

    public bool IsActive { get; set; }

    public string? ZipCode { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
}
