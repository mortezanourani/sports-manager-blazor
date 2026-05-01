using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class Champion : BaseChampion
{
    public int? AgeGroupId { get; set; }
    public virtual AgeGroup? AgeGroup { get; set; }

    public Guid AthleteId { get; set; }
    public virtual Athlete Athlete { get; set; } = null!;

    public int? MedalId { get; set; }
    public virtual Medal? Medal { get; set; }

    public Guid TournamentId { get; set; }
    public virtual Tournament Tournament { get; set; } = null!;
}
