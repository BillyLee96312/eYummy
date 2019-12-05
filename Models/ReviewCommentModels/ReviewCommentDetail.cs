using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ReviewCommentModels
{
    public class ReviewCommentDetail
    {
        [Key]
        public int ReviewCommentId { get; set; }
        public string AnonymousId { get; set; }
        public int Rate { get; set; }
        public string ReviewComment { get; set; }
        public DateTime ReviewDateTime { get; set; }
        public List<RecipeReviewComment> RecipeReviewComments { get; set; }
            = new List<RecipeReviewComment>();
    }
}
