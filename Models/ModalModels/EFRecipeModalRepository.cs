using Microsoft.EntityFrameworkCore;
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
        public IQueryable<Recipe> Recipes
                => context.Recipes.Include(
                    r => r.RecipeModals);

        public IQueryable<ModalDetail> ModalDetails
                => context.ModalDetails;

        public IQueryable<RecipeModal> RecipeModals => context.RecipeModals;

        public void AllRecipeModal(int Id, ModalDetail modalDetail)
        {
            RecipeModal recipeModal = new RecipeModal();
            recipeModal.Recipe = context.Recipes.First(r => r.RecipeId == Id);

            recipeModal.ModalDetail = context.ModalDetails.First(rm => rm.ModalId == modalDetail.ModalId);
            recipeModal.Recipe.RecipeModals.Add(recipeModal);

            context.SaveChanges();
        }

        public void DeleteRecipeModal(RecipeModal recipeModal)
        {
            context.RecipeModals.Remove(recipeModal);
            context.SaveChanges();
        }
    }
}
