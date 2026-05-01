using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseConstructionProject
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public int Year { get; set; }
}
