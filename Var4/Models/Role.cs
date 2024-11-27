using System;
using System.Collections.Generic;

namespace Var4.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
