using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseFederationPresident
{
    public Guid Id { get; set; }

    public string? AppointmentOrder { get; set; }

    public string? AppointmentDate { get; set; }

    public string? TermEnd { get; set; }

    public bool IsPresident { get; set; }
}
