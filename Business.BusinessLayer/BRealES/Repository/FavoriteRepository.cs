
using AutoMapper;
using Business.BusinessLayer.BRealES.IRepository;
using Business.BusinessLayer.BUser.IRepository;
using Data.DataLayer;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Business.BusinessLayer.BRealES.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly MyDbContext ndb;
        public FavoriteRepository(IMapper map, IUserRepository userRepository, MyDbContext con)
        {
            _mapper = map;
            _userRepository = userRepository;
            ndb = con;
        }
        public async Task<bool> AddFavorite(string id)
        {
            try
            {
                var userId =(User) await _userRepository.GetCurrentUser();
               
                var check = await ndb.Favorites.AsNoTracking().Where(x => x.UserId == userId.Id && x.RealEsid == id).FirstAsync();
                
                if (check!=null)
                {
                    return await RemoveRealEs(id);
                }

                var fav = new Favorite
                    {
                        RealEsid = id,
                        UserId = userId.Id
                    }
                    ;
                await ndb.Favorites.AddAsync(fav);
                await ndb.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<FavVm> GetFavoriteByUserId()
        {
            var userId = _userRepository.GetCurrentUser().Result;

            var favs = ndb.Favorites
                .Where(x => x.UserId == userId.Id)
                .Select(x => x.RealEsid)
                .ToList();

            var realEs = ndb.RealEs
                .Include(x => x.Favorites)
                .Include(x => x.Images)
                .Include(x => x.Address)
                .ThenInclude(x => x.Country)
                .ThenInclude(x => x.Cities)
                .ThenInclude(x => x.Hoods)
                .Where(x => favs.Contains(x.Id))
                .ToList();

            var data = _mapper.Map<List<FavVm>>(realEs);
            return data;
        }

        public async Task<bool> RemoveRealEs(string id)
        {
            var userId = _userRepository.GetCurrentUser().Result;
            var fav = new Favorite
                {
                    RealEsid = id,
                    UserId = userId.Id
                }
                ;
            ndb.Favorites.Remove(fav);
           await ndb.SaveChangesAsync();
            return true;
        }
    }
}
