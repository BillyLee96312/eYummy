using eYummy.Models.IngredientModels;
using eYummy.Models.ModalModels;
using eYummy.Models.ReviewCommentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }     
        public int CategoryId { get; set; }
        public string RecipeTitle { get; set; }
        public string Description { get; set; }
        public string Prep { get; set; }
        public string Servings { get; set; }
        public int CookTime { get; set; }
        public int ServingsMax { get; set; }
        public int Total { get; set; }
        public string FileToUpload { get; set; }
        public string Yield { get; set; }
        public DateTime DateTimeUpdate { get; set; }
        
        //Many to Many Relationship
        public List<RecipeIngredient> RecipeIngredients { get; set; }
            = new List<RecipeIngredient>();
        
        public List<RecipeModal> RecipeModals { get; set; }
            = new List<RecipeModal>();

        public List<RecipeReviewComment> RecipeReviewComments { get; set; }
            = new List<RecipeReviewComment>();
    }
}
