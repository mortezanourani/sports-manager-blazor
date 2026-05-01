using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class LocalFederation : BaseLocalFederation
{
    public int FederationId { get; set; }
    public virtual Federation Federation { get; set; } = null!;

    public virtual ICollection<LocalFederationPresident> LocalFederationPresidents { get; set; } = new List<LocalFederationPresident>();
}
