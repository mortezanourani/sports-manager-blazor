using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class Insurance : BaseInsurance
{
    public int FederationId { get; set; }
    public virtual Federation Federation { get; set; } = null!;
}
