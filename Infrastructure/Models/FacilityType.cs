using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public class FacilityType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? NormalizedType { get; set; }

    public string PersianTitle { get; set; } = null!;
}
