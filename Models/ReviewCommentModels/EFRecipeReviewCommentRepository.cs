using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IQueryable<RecipeReviewComment> RecipeReviewComments =>
            context.RecipeReviewComments;
    }
}
