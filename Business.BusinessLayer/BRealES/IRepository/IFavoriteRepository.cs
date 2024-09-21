using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.ViewModels.DataRESVM;

namespace Business.BusinessLayer.BRealES.IRepository
{
    public interface IFavoriteRepository
    {
        public List<FavVm> GetFavoriteByUserId();
        public bool RemoveRealEs(string realEsId);
        public bool AddFavorite(string realEsId);
    }
}
