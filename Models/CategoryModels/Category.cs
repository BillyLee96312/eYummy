using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.CategoryModels
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { set; get; }
        public string CategoryImg { set; get; }
        public string CategoryDesc { set; get; }
    }
}
