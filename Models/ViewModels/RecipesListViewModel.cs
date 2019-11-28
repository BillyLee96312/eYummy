using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eYummy.Models;
using eYummy.Models.CategoryModels;
using eYummy.Models.IngredientModels;
using eYummy.Models.ModalModels;

namespace eYummy.Models.ViewModels
{
    public class RecipesListViewModel
    {
        public IEnumerable<Recipe> RecipeCollection { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        //public Recipe Recipe { get; set; } = new Recipe();
        //public PagingInfo PagingInfo { get; set; }
        //public string PageAction { get; set; }
        //public string SearchRecipe { get; set; }
        //public string SearchDate { get; set; }
        //public string SearchCategory { get; set; }

        /**
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Modal> Modals { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public PagingInfo PagingInfo
        {
            get; set;
        }
        public string CurrentCategory { get; set; }
        */

    }
}
