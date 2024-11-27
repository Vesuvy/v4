using System;
using System.Collections.Generic;

namespace Var4.Models;

public partial class Ingredient
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? CountOnStore { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
