using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ReviewCommentModels
{
    public class RecipeReviewComment
    {

        public int RecipeId { get; set; }
        public int ReviewCommentId { get; set; }

        public Recipe Recipe { get; set; }
        public ReviewCommentDetail ReviewCommentDetail { get; set; }
    }
}
