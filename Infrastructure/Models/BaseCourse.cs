using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseCourse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public bool IsGeneral { get; set; }

    public int CourseTime { get; set; }

    public string Year { get; set; } = null!;

    public string Month { get; set; } = null!;

    public bool IsOnline { get; set; }
}
