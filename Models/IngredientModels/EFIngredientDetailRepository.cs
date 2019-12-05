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

        public void UpdateIngredientDetail(IngredientDetail ingredientDetail)
        {
            IngredientDetail dbIngredientDetail = context.IngredientDetails.First(id => id.IngredientId == ingredientDetail.IngredientId);
            dbIngredientDetail.IngredientId     = ingredientDetail.IngredientId;
            dbIngredientDetail.IngredientString = ingredientDetail.IngredientString;

            context.SaveChanges();
        }
        public void DeleteIngredientDetail(IngredientDetail ingredientDetail)
        {
            context.IngredientDetails.Remove(ingredientDetail);
            context.SaveChanges(); 
        }

        /**
        
        public void AddIngredientDetail(List<IngredientDetail> ingredientDetails)
        {


            foreach(IngredientDetail ingredientDetail in ingredientDetails)
            {
                context.IngredientDetails.Add(ingredientDetail);
                context.SaveChanges();
            }

        }
        */
        
    }
}
