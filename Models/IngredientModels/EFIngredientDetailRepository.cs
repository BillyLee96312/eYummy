using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.IngredientModels
{
    public class EFIngredientDetailRepository : IIngredientDetailRepository
    {
        private ApplicationDbContext context;
        public EFIngredientDetailRepository(ApplicationDbContext ctx) { context = ctx; }
        public IQueryable<IngredientDetail> IngredientDetails => context.IngredientDetails;

        public void AddIngredientDetail(IngredientDetail ingredientDetail)
        {
            context.IngredientDetails.Add(ingredientDetail);
            context.SaveChanges();
        }
    }
}
