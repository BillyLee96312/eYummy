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
        void UpdateIngredientDetail(IngredientDetail ingredientDetail);
        void DeleteIngredientDetail(IngredientDetail ingredientDetail);



        //void AddIngredientString(IEnumerable<string> IngredientString);

        //void AddIngredientDetail(List<IngredientDetail> ingredientDetails);
    }
}
