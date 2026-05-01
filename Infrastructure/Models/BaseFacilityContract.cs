using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseFacilityContract
{
    public Guid Id { get; set; }

    public string? Serial { get; set; }

    public string? StartDate { get; set; }

    public string? ExpireDate { get; set; }

    public string Name { get; set; } = null!;

    public string SeenCode { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? LicenseSerial { get; set; }

    public string? LicenseDate { get; set; }
}
