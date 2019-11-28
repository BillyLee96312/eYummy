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
        public IQueryable<RecipeIngredient> RecipeIngredients => context.RecipeIngredients;

    }
}
