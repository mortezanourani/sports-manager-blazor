using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProvinceApp.Models;

public class ProjectBudget : BaseProjectBudget
{
    public int SourceId { get; set; }
    public virtual FundingSource Source { get; set; } = null!;

    public virtual ConstructionProject Project { get; set; } = null!;
}
