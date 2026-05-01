using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseFederationPresident
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string SeenCode { get; set; } = null!;

    public string BirthDate { get; set; } = null!;

    public string? Phone { get; set; }

    public string? EducationalQualification { get; set; }

    public string? EducationalMajor { get; set; }

    public string? AppointmentOrder { get; set; }

    public string? AppointmentDate { get; set; }

    public string? TermEnd { get; set; }

    public bool IsPresident { get; set; }
}
