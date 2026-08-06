using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class GovernmentFacility : BaseGovernmentFacility
{
    public int? Type { get; set; }

    public virtual ICollection<GovernmentFacilityLicense> GovernmentFacilityLicenses { get; set; } = new List<GovernmentFacilityLicense>();
}
