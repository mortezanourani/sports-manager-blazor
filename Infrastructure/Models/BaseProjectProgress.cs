using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public abstract class BaseProjectProgress
{
    [Key]
    public Guid Id { get; set; }

    public int Year { get; set; }

    public int Month { get; set; }

    public int Percentage { get; set; }

    public int? ContractorUnpaid { get; set; }

    public int? CompletionBudget { get; set; }

    public int? CompletionYear { get; set; }
}
