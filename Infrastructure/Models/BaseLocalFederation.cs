using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public abstract class BaseLocalFederation
{
    public Guid Id { get; set; }

    public string? District { get; set; }

    public string? NationalId { get; set; }

    public string? Address { get; set; }

    public string? ZipCode { get; set; }

    public string? Phone { get; set; }
}
