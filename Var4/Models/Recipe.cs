using System;
using System.Collections.Generic;

namespace Var4.Models;

public partial class Recipe
{
    public int Id { get; set; }

    public int? DishId { get; set; }

    public int? IngredientId { get; set; }

    public int? Count { get; set; }

    public virtual Dish? Dish { get; set; }

    public virtual Ingredient? Ingredient { get; set; }
}
