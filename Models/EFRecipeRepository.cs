using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;
        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Recipe> Recipes => context.Recipes;

        public void AddRecipe(Recipe recipe)
        {
            context.Recipes.Add(recipe);
            context.SaveChanges();
        }

        public void DeleteRecipe(Recipe recipe)
        {
            context.Recipes.Remove(recipe);
            context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            Recipe dbRecipe = context.Recipes.First(r => r.RecipeId == recipe.RecipeId);
            dbRecipe.RecipeTitle    = recipe.RecipeTitle;
            dbRecipe.CategoryId     = recipe.CategoryId;
            dbRecipe.FileToUpload   = recipe.FileToUpload;
            dbRecipe.DateTimeUpdate = recipe.DateTimeUpdate;
            dbRecipe.CookTime       = recipe.CookTime;
            dbRecipe.Description    = recipe.Description;
            dbRecipe.Prep           = recipe.Prep;
            dbRecipe.Servings       = recipe.Servings;
            dbRecipe.ServingsMax    = recipe.ServingsMax;
            dbRecipe.Total          = recipe.Total;
            dbRecipe.Yield          = recipe.Yield;
            
            context.SaveChanges();

        }
    }
}
