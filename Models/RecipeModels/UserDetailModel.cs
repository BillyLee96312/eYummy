using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eYummy.Models.ReviewCommentModels;
using eYummy.Models.IngredientModels;
namespace eYummy.Models.RecipeModels
{
    public class UserDetailModel
    {
                
        public Recipe Recipe { get; set; } = new Recipe();
        public RecipeIngredient RecipeIngredient { get; set; } = new RecipeIngredient();
        public IngredientDetail IngredientDetail { get; set; } = new IngredientDetail();
        public RecipeReviewComment RecipeReviewComment { get; set; } = new RecipeReviewComment();
        public ReviewCommentDetail ReviewCommentDetail { get; set; } = new ReviewCommentDetail();
        
        public List<Recipe> AllRecipes{ get; set; } =
                new List<Recipe>();

        public List<IngredientDetail> AllIngredientDetails { get; set; } =
                new List<IngredientDetail>();

        public List<RecipeReviewComment> AllRecipeReviewComments { get; set; } =
                new List<RecipeReviewComment>();

        public List<ReviewCommentDetail> AllReviewCommentDetails { get; set; } =
                new List<ReviewCommentDetail>();

        public List<RecipeIngredient> AllRecipeIngredients { get; set; } =
                new List<RecipeIngredient>();
        
    }
}
