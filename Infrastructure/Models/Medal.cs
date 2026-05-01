using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public class Medal
{
    public int Id { get; set; }

    public bool IsIndividualMedal { get; set; }

    public string Color { get; set; } = null!;

    public string? NormalizedColor { get; set; }

    public string PersianTitle { get; set; } = null!;
}
