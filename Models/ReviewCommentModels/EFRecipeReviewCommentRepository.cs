using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eYummy.Models.ReviewCommentModels
{
    public class EFRecipeReviewCommentRepository 
        : IRecipeReviewCommentRepository
    {
        private ApplicationDbContext context;

        public EFRecipeReviewCommentRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes
                => context.Recipes.Include(
                    r => r.RecipeReviewComments);

        public IQueryable<ReviewCommentDetail> ReviewComentDetails
                => context.ReviewCommentDetails;
        public IQueryable<RecipeReviewComment> RecipeReviewComments =>
            context.RecipeReviewComments;

        public void AddRecipeReviewComment(int Id, ReviewCommentDetail reviewCommentDetail)
        {
            RecipeReviewComment recipeReviewComment =
                new RecipeReviewComment();
            recipeReviewComment.Recipe =
                context.Recipes.First(r => r.RecipeId == Id);

            recipeReviewComment.ReviewCommentDetail =
                context.ReviewCommentDetails.First(
                    rrc => rrc.ReviewCommentId == reviewCommentDetail.ReviewCommentId);    
            recipeReviewComment.Recipe.RecipeReviewComments.Add(recipeReviewComment);
            
            context.SaveChanges();
        }            
        public void DeleteRecipeReviewComment(RecipeReviewComment recipeReviewComment)
        {
            context.RecipeReviewComments.Remove(recipeReviewComment);
            context.SaveChanges();
        }
    }
}
