using eYummy.Models.CategoryModels;
using eYummy.Models.IngredientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.RecipeModels
{
    public class RecipeModel
    {
        public Recipe Recipe { get; set; } = new Recipe();

        public IngredientDetail IngredientDetail {get; set;} = new IngredientDetail();

        public List<Category> AllCategories { get; set; } =
            new List<Category>();

        public List<IngredientDetail> IngredientDetails { get; set; } =
            new List<IngredientDetail>();
    }
}
