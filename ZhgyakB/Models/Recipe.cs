using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZhgyakB
{
    [Table("Recipes")]
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string RecipeName { get; set; }

        public int Price { get; set; }

        public bool IsFavourite { get; set; }

        [NotMapped]
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
