using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseTournament
{
    public Guid Id { get; set; }

    public string Host { get; set; } = null!;

    public int Year { get; set; }

    public int? Month { get; set; }

    public int? Day { get; set; }
}
