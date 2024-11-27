using System;
using System.Collections.Generic;

namespace Var4.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
