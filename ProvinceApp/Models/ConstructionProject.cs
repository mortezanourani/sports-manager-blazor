using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class ConstructionProject : BaseConstructionProject
{
    public int CityId { get; set; }
    public virtual City City { get; set; } = null!;

    public Guid? FacilityId { get; set; }
    public virtual Facility? Facility { get; set; }

    public int? TypeId { get; set; }
    public virtual ProjectType? Type { get; set; }

    public virtual ICollection<ProjectBudget> ProjectBudgets { get; set; } = new List<ProjectBudget>();

    public virtual ICollection<ProjectProgress> ProjectProgresses { get; set; } = new List<ProjectProgress>();
}
