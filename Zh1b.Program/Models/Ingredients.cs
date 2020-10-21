using System;
using System.Collections.Generic;

namespace Zh1b.Program.Models
{
    public partial class Ingredients
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public int Amount { get; set; }
        public int RecipeId { get; set; }

        public virtual Recipes Recipe { get; set; }
    }
}
