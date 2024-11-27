using System;
using System.Collections.Generic;

namespace Var4.Models;

public partial class Dish
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public double? Weight { get; set; }

    public int? CategoryId { get; set; }

    public double? Cost { get; set; }

    public string? Availability { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderContent> OrderContents { get; set; } = new List<OrderContent>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
