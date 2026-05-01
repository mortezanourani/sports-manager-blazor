using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class Facility : BaseFacility
{
    public int? TypeId { get; set; }
    public virtual FacilityType? Type { get; set; }

    public int UsersGenderId { get; set; }
    public virtual UsersGender UsersGender { get; set; } = null!;

    public virtual ICollection<FacilityContract> FacilityContracts { get; set; } = new List<FacilityContract>();

    public virtual ICollection<FacilityDocument> FacilityDocuments { get; set; } = new List<FacilityDocument>();
}
