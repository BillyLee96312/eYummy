using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.IngredientModels
{
    public class EFRecipeIngredientRepository : IRecipeIngredientRepository
    {
        private ApplicationDbContext context;
        public EFRecipeIngredientRepository(ApplicationDbContext ctx) { context = ctx; }

        public IQueryable<Recipe> Recipes
                => context.Recipes.Include(r => r.RecipeIngredients);
        public IQueryable<IngredientDetail> IngredientDetails
                => context.IngredientDetails;
        public IQueryable<RecipeIngredient> RecipeIngredients
                => context.RecipeIngredients;

        public void AddRecipeIngredient(int Id, IngredientDetail ingredientDetail)
        {
            RecipeIngredient recipeIngredient   = new RecipeIngredient();

            recipeIngredient.Recipe             = context.Recipes.First(r => r.RecipeId == Id);
            recipeIngredient.IngredientDetail = context.IngredientDetails.First(
                igd => igd.IngredientId == ingredientDetail.IngredientId);
            recipeIngredient.Recipe.RecipeIngredients.Add(recipeIngredient);
            context.SaveChanges();


        }
               

        public void DeleteRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            context.RecipeIngredients.Remove(recipeIngredient);
            context.SaveChanges();
        }

    }
}
