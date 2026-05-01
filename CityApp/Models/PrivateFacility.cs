using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class PrivateFacility : BasePrivateFacility
{
    public int? TypeId { get; set; }
    public virtual FacilityType? Type { get; set; }

    public virtual ICollection<PrivateFacilityLicense> PrivateFacilityLicenses { get; set; } = new List<PrivateFacilityLicense>();
}
