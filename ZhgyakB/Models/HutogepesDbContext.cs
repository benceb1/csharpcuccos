using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhgyakB
{
    public partial class HutogepesDbContext : DbContext
    {   // Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Receptek.mdf;Integrated Security=True
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public HutogepesDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Receptek.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity
                    .HasOne(ingredient => ingredient.Recipe)
                    .WithMany(recipe => recipe.Ingredients)
                    .HasForeignKey(ingredient => ingredient.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            Recipe recipe1 = new Recipe() {Id = 1, RecipeName = "Carbonara", Price = 1400, IsFavourite = false };

            Ingredient ingredient1 = new Ingredient() { Id = 1,IngredientName = "Spagetti tészta", Amount = 1, RecipeId = recipe1.Id };
            Ingredient ingredient2 = new Ingredient() { Id = 2, IngredientName = "Tojás", Amount = 4, RecipeId = recipe1.Id };
            Ingredient ingredient3 = new Ingredient() { Id = 3, IngredientName = "Só", Amount = 1, RecipeId = recipe1.Id };
            Ingredient ingredient4 = new Ingredient() { Id = 4, IngredientName = "Bors", Amount = 1, RecipeId = recipe1.Id };
            Ingredient ingredient5 = new Ingredient() { Id = 5, IngredientName = "Bacon", Amount = 5, RecipeId = recipe1.Id };

            modelBuilder.Entity<Recipe>().HasData(recipe1);
            modelBuilder.Entity<Ingredient>().HasData(ingredient1, ingredient2, ingredient3, ingredient4, ingredient5);
        }
    }
}
