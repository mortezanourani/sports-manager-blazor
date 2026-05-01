using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class PrivateFacility : BasePrivateFacility
{
    public int? TypeId { get; set; }
    public virtual FacilityType? Type { get; set; }

    public int CityId { get; set; }
    public virtual City City { get; set; } = null!;

    public virtual ICollection<PrivateFacilityLicense> PrivateFacilityLicenses { get; set; } = new List<PrivateFacilityLicense>();

}
