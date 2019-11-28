using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eYummy.Models.RecipeModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eYummy.Models.IngredientModels
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        public Recipe Recipe { get; set; }
        public IngredientDetail IngredientDetail { get; set; }
    }
}
