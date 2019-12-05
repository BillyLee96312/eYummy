using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eYummy.Models;
using eYummy.Models.CategoryModels;
using eYummy.Models.IngredientModels;
using eYummy.Models.ModalModels;
using eYummy.Models.ReviewCommentModels;
using Microsoft.AspNetCore.Mvc;

namespace eYummy.Models.ViewModels
{
    public class RecipesListViewModel
    {
        public Recipe Recipe { get; set; } = new Recipe();

        [BindProperty]
        public List<IngredientDetail> SaveIngredientDetails { get; set; }

        public IngredientDetail IngredientDetail { get; set; } =
                new IngredientDetail();

        public IEnumerable<string> IngredientId { get; set; }
        public IEnumerable<string> IngredientString { get; set; }
        
        public List<string> UpdateIngredientString { get; set; }
        
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<RecipeModal> RecipeModals { get; set; }
        public IEnumerable<ModalDetail> ModalDetails { get; set; }
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }
        public IEnumerable<IngredientDetail> IngredientDetails { get; set; }
        public IEnumerable<IngredientDetail> UpdateIngredientDetails { get; set; }
        public IEnumerable<RecipeReviewComment> RecipeReviewComments { get; set; }
        public IEnumerable<ReviewCommentDetail> ReviewCommentDetails { get; set; }

        public List<RecipeIngredient> AllRecipeIngredients { get; set; }
            =   new List<RecipeIngredient>();
        //OneRecipeIngredients dictionary collection class is 
        //to Adding key-value pair in dictionary as RecipeIngredients with Ingredients Id
        public IDictionary<int, string> UpdateIngredientDetailDic { get; set; }

        public List<IngredientDetail> AllIngredientDetail {get; set;}
            =   new List<IngredientDetail>();
        public List<IngredientDetail> UpdateIngredientDetail { get; set; }
            =   new List<IngredientDetail>();

        public List<IngredientDetail> TempUpdateIngredientDetail { get; set; }
            = new List<IngredientDetail>();

        public static T First<T>(IEnumerable<T> items)
        {
            using (IEnumerator<T> iter = items.GetEnumerator())
            {
                iter.MoveNext();
                return iter.Current;
            }
        }
    }
}
