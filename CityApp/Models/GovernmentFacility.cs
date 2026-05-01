using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class GovernmentFacility : BaseGovernmentFacility
{
    public int? TypeId { get; set; }
    public virtual FacilityType? Type { get; set; }

    public virtual ICollection<GovernmentFacilityLicense> GovernmentFacilityLicenses { get; set; } = new List<GovernmentFacilityLicense>();
}
