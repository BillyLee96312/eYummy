using eYummy.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ViewModels
{
    public class SearchRecipeModel
    {
        public IEnumerable<Recipe> RecipeCollection { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
