using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ReviewCommentModels
{
    public interface IReviewCommentDetailRepository
    {
        IQueryable<ReviewCommentDetail> ReviewCommentDetails { get; }
        void AddReviewCommentDetail(ReviewCommentDetail reviewCommentDetail);
        void DeleteReviewCommentDetail(ReviewCommentDetail reviewCommentDetail);

    }
}
