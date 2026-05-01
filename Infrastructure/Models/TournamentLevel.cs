using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public class TournamentLevel
{
    public int Id { get; set; }

    public bool IsInternational { get; set; }

    public string Title { get; set; } = null!;

    public string? NormalizedTitle { get; set; }

    public string PersianTitle { get; set; } = null!;
}
