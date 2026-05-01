using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public class Federation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NormalizedName { get; set; }

    public string PersianName { get; set; } = null!;

    public bool IsPara { get; set; }

    public bool IsChampionship { get; set; }

    public bool IsGeneral { get; set; }

    public bool IsRural { get; set; }
}
