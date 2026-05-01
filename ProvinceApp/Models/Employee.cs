using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class Employee : BaseEmployee
{
    public int GenderId { get; set; }
    public virtual Gender Gender { get; set; } = null!;

    public int? TypeId { get; set; }
    public virtual EmploymentType? Type { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
