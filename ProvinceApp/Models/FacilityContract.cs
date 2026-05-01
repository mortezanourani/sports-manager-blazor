using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class FacilityContract : BaseFacilityContract
{
    public Guid FacilityId { get; set; }
    public virtual Facility Facility { get; set; } = null!;

    public Guid? LegalContractorId { get; set; }
    public virtual LocalFederation? LegalContractor { get; set; }
}
