using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseAthlete
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? SeenCode { get; set; }

    public string? Phone { get; set; }
}
