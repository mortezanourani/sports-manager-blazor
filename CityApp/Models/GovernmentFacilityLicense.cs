using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class GovernmentFacilityLicense : BaseGovernmentFacilityLicense
{
    public Guid FacilityId { get; set; }
    public virtual GovernmentFacility Facility { get; set; } = null!;

    public int UsersGender { get; set; }
}
