using CityApp.Identity;
using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class LocalFederationPresident : BaseFederationPresident
{
    public string? PresidentId { get; set; }
    public virtual CityUser President { get; set; } = null!;

    public Guid FederationId { get; set; }
    public virtual LocalFederation Federation { get; set; } = null!;
}
