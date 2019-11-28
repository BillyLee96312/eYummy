using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ModalModels
{
    public interface IRecipeModalRepository
    {
        IQueryable<RecipeModal> RecipeModals { get; }
    }
}
