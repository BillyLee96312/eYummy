using eYummy.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eYummy.Models.ModalModels
{
    public class RecipeModal
    {
        
        public int RecipeId { get; set; }
        public int ModalId { get; set; }
        
        public Recipe Recipe { get; set; }
        public ModalDetail ModalDetail { get; set; }
        

    }

}
