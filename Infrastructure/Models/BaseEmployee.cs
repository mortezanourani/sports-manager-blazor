using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseEmployee
{
    public Guid Id { get; set; }

    public string SeenCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PersonnelId { get; set; }

    public string? FatherName { get; set; }

    public string? BirthDate { get; set; }

    public string? AccountId { get; set; }
}
