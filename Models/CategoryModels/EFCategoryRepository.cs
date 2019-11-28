using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.CategoryModels
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext context;
        public EFCategoryRepository(ApplicationDbContext ctx) { context = ctx; }
        public IQueryable<Category> Categories => context.Categories;

        public void AddCategories(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
    }

}
