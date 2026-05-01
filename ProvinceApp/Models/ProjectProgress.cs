using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProvinceApp.Models;

public class ProjectProgress : BaseProjectProgress
{
    public virtual ConstructionProject Project { get; set; } = null!;
}
