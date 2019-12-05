using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ReviewCommentModels
{
    public class EFReviewCommentDetailRepository : IReviewCommentDetailRepository
    {
        private ApplicationDbContext context;
        public EFReviewCommentDetailRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<ReviewCommentDetail> ReviewCommentDetails => context.ReviewCommentDetails;

        public void AddReviewCommentDetail(ReviewCommentDetail reviewCommentDetail)
        {
            context.ReviewCommentDetails.Add(reviewCommentDetail);
            context.SaveChanges();
        }
        public void DeleteReviewCommentDetail(ReviewCommentDetail reviewCommentDetail)
        {
            context.ReviewCommentDetails.Remove(reviewCommentDetail);
            context.SaveChanges();
        }
    }
}
