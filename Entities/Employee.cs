using System;
using System.Collections.Generic;

namespace Entities;

public partial class Employee
{
    public string Id { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public virtual ICollection<Assignment> Assignments { get; } = new List<Assignment>();
}
