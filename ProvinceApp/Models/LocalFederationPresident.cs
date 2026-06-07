using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class LocalFederationPresident : BaseFederationPresident
{
    public string Name { get; set; } = null!;

    public string SeenCode { get; set; } = null!;

    public string BirthDate { get; set; } = null!;

    public string? Phone { get; set; }

    public string? EducationalQualification { get; set; }

    public string? EducationalMajor { get; set; }

    public Guid FederationId { get; set; }
    public virtual LocalFederation Federation { get; set; } = null!;
}
