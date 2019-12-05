using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ReviewCommentModels
{
    public interface IRecipeReviewCommentRepository
    {
        IQueryable<RecipeReviewComment> RecipeReviewComments { get; }
        void AddRecipeReviewComment(int recipeId, ReviewCommentDetail reviewComentDetail);
        void DeleteRecipeReviewComment(RecipeReviewComment recipeReviewComment);
    }
}
