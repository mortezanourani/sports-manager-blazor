using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class Insurance : BaseInsurance
{
    public int CityId { get; set; }
    public virtual City City { get; set; } = null!;

    public int FederationId { get; set; }
    public virtual Federation Federation { get; set; } = null!;
}
