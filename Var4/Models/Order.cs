using System;
using System.Collections.Generic;

namespace Var4.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? Table { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<OrderContent> OrderContents { get; set; } = new List<OrderContent>();
}
