using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models.ModalModels
{
    public interface IModalDetailRepository
    {
        IQueryable<ModalDetail> ModalDetails { get; }
    }
}
