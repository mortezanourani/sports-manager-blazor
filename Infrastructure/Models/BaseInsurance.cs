using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseInsurance
{
    public Guid Id { get; set; }

    public int Year { get; set; }

    public int Month { get; set; }

    public int MenCount { get; set; }

    public int WomenCount { get; set; }
}
