using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class Facility : BaseFacility
{
    public int CityId { get; set; }
    public virtual City City { get; set; } = null!;

    public int? TypeId { get; set; }
    public virtual FacilityType? Type { get; set; }

    public int UsersGenderId { get; set; }
    public virtual UsersGender UsersGender { get; set; } = null!;

    public virtual ICollection<ConstructionProject> ConstructionProjects { get; set; } = new List<ConstructionProject>();

    public virtual ICollection<FacilityContract> FacilityContracts { get; set; } = new List<FacilityContract>();

    public virtual ICollection<FacilityDocument> FacilityDocuments { get; set; } = new List<FacilityDocument>();
}
