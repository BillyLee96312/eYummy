using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.IngredientModels
{
    public class ChangedIngredientDetail
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientString { get; set; }
    }
}
