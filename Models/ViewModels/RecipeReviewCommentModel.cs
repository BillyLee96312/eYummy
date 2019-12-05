using eYummy.Models.ReviewCommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ViewModels
{
    public class RecipeReviewCommentModel
    {
        public Recipe Recipe { set; get; } = new Recipe();
        public RecipeReviewComment RecipeReviewComment { set; get;  }   =   new RecipeReviewComment();
        public ReviewCommentDetail ReviewCommentDetail { set; get; } = new ReviewCommentDetail();
        public List<RecipeReviewComment> AllRecipeReviewComments { set; get; } = new List<RecipeReviewComment>();
        public List<ReviewCommentDetail> AllReviewCommentDetail { set; get; } = new List<ReviewCommentDetail>();
    }
}
