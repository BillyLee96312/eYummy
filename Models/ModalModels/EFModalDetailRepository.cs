using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ModalModels
{
    public class EFModalDetailRepository : IModalDetailRepository
    {
        private ApplicationDbContext context;
        public EFModalDetailRepository(ApplicationDbContext ctx) { context = ctx; }
        public IQueryable<ModalDetail> ModalDetails => context.ModalDetails;
    }
}
