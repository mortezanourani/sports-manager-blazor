using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public abstract class BaseProjectBudget
{
    [Key]
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public int Year { get; set; }

    public int Approved { get; set; }
}
