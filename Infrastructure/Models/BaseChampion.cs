using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseChampion
{
    public Guid Id { get; set; }

    public string? Field { get; set; }

    public int? MedalsCount { get; set; }
}
