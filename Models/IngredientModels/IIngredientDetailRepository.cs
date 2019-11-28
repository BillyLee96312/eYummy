using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.IngredientModels
{
    public interface IIngredientDetailRepository
    {
        IQueryable<IngredientDetail> IngredientDetails { get; }
        void AddIngredientDetail(IngredientDetail ingredientDetail);
    }
}
