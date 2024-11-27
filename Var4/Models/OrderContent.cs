using System;
using System.Collections.Generic;

namespace Var4.Models;

public partial class OrderContent
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? DishId { get; set; }

    public int? Count { get; set; }

    public string? Status { get; set; }

    public virtual Dish? Dish { get; set; }

    public virtual Order? Order { get; set; }
}
