using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class Tournament : BaseTournament
{
    public int FederationId { get; set; }
    public virtual Federation Federation { get; set; } = null!;

    public int LevelId { get; set; }
    public virtual TournamentLevel Level { get; set; } = null!;

    public virtual ICollection<Champion> Champions { get; set; } = new List<Champion>();
}
