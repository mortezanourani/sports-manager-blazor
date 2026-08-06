using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace CityApp.Models;

public class Facility : BaseFacility
{
    public int? Type { get; set; }

    public int UsersGender { get; set; }

    public virtual ICollection<FacilityContract> FacilityContracts { get; set; } = new List<FacilityContract>();

    public virtual ICollection<FacilityDocument> FacilityDocuments { get; set; } = new List<FacilityDocument>();
}
