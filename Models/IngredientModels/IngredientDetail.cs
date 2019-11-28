using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.IngredientModels
{
    public class IngredientDetail
    {
        [Key]
        public int IngredientId { get; set; }
        public string IngredientString { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }
            = new List<RecipeIngredient>();

    }
}
