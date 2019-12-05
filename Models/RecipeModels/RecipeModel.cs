using eYummy.Models.CategoryModels;
using eYummy.Models.IngredientModels;
using eYummy.Models.ModalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.RecipeModels
{
    public class RecipeModel
    {
        public Recipe Recipe { get; set; } = new Recipe();

        public IngredientDetail IngredientDetail {get; set;}    = new IngredientDetail();
        public RecipeIngredient RecipeIngredient { get; set; }  = new RecipeIngredient();
        public RecipeModal RecipeModal { get; set; } = new RecipeModal();
        public IEnumerable<string> IngredientString { get; set; }
        public List<RecipeModal> AllRecipeModals { get; set; } =
                new List<RecipeModal>();
        public List<ModalDetail> AllModalDetails { get; set; } =
                new List<ModalDetail>();
        public List<Category> AllCategories { get; set; } =
            new List<Category>();

        public List<IngredientDetail> AllIngredientDetails { get; set; } =
            new List<IngredientDetail>();

        public List<RecipeIngredient> AllRecipeIngredients { get; set; } =
                new List<RecipeIngredient>();



    }
}
