using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class PrivateFacilityLicense : BasePrivateFacilityLicense
{
    public Guid FacilityId { get; set; }
    public virtual PrivateFacility Facility { get; set; } = null!;

    public int UsersGenderId { get; set; }
    public virtual UsersGender UsersGender { get; set; } = null!;
}
