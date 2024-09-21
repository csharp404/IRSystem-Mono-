using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.ViewModels.DataRESVM;

namespace Business.BusinessLayer.BRealES.IRepository
{
    public interface ICommentRepository
    {
        public bool AddComment(DetailsVm vM);
    }
}
