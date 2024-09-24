
using Data.ViewModels.DataRESVM;

namespace Business.BusinessLayer.BRealES.IRepository
{
    public interface IFavoriteRepository
    {
        public List<FavVm> GetFavoriteByUserId();
        public Task<bool> RemoveRealEs(string realEsId);
        public Task<bool> AddFavorite(string realEsId);
    }
}
