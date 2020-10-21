using System;
using System.Collections.Generic;

namespace Zh1b.Program.Models
{
    public partial class Recipes
    {
        public Recipes()
        {
            Ingredients = new HashSet<Ingredients>();
        }

        public int Id { get; set; }
        public string RecipeName { get; set; }
        public int Price { get; set; }
        public bool IsFavourite { get; set; }

        public virtual ICollection<Ingredients> Ingredients { get; set; }
    }
}
