using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.CategoryModels
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }

        void AddCategories(Category category);
    }
}
