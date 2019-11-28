using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ModalModels
{
    public class EFRecipeModalRepository : IRecipeModalRepository
    {
        private ApplicationDbContext context;
        public EFRecipeModalRepository(ApplicationDbContext ctx) { context = ctx; }
        public IQueryable<RecipeModal> RecipeModals => context.RecipeModals;
    }
}
