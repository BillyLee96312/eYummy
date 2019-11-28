using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }

        void AddRecipe(Recipe recipe);

        //Display recipe by recipeId from UserDetail.chstml
        //void RecipesByRecipeId(Recipe recipe);
    }
}
