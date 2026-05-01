using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public class AgeGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NormalizedName { get; set; }

    public string PersianName { get; set; } = null!;
}
