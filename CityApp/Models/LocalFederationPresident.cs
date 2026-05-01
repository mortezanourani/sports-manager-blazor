using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class LocalFederationPresident : BaseFederationPresident
{
    public Guid FederationId { get; set; }
    public virtual LocalFederation Federation { get; set; } = null!;
}
