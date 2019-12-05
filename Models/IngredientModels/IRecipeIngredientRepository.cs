using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.IngredientModels
{
    public interface IRecipeIngredientRepository
    {
        IQueryable<RecipeIngredient> RecipeIngredients { get; }
        void AddRecipeIngredient(int recipeId, IngredientDetail ingredientDetail);
        void DeleteRecipeIngredient(RecipeIngredient recipeIngredient);

    }
}
