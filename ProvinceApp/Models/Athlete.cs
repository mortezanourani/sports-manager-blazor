using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class Athlete : BaseAthlete
{
    public int CityId { get; set; }
    public virtual City City { get; set; } = null!;

    public int GenderId { get; set; }
    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<Champion> Champions { get; set; } = new List<Champion>();
}
