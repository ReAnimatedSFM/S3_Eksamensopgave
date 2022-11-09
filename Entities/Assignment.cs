using System;
using System.Collections.Generic;

namespace Entities;

public partial class Assignment
{
    public int Id { get; set; }

    public string Titel { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Notes { get; set; }

    public bool Finished { get; set; }

    public string? EmployeeId { get; set; }

    public int ResidentId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Resident Resident { get; set; } = null!;
}
