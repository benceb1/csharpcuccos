using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZhgyakB
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string IngredientName { get; set; }

        public int Amount { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }

        [NotMapped]
        public virtual Recipe Recipe { get; set; }

    }
}
