using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks; 

namespace eYummy.Models.ModalModels
{
    public class ModalDetail
    {
        
        [Key]
        public int ModalId { get; set; }
        public string ModalName { get; set; }
        public string DataTarget { get; set; }
        
        public List<RecipeModal> RecipeModals { get; set; }
           = new List<RecipeModal>();
        
    }
}
