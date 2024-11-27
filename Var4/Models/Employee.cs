using System;
using System.Collections.Generic;

namespace Var4.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Familiya { get; set; }

    public string? Name { get; set; }

    public string? Otchestvo { get; set; }

    public int? RoleId { get; set; }

    public double? Salary { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }
}
