using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ProvinceApp.Models;

public class Course : BaseCourse
{
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
