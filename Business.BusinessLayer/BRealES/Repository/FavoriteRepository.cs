using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.BusinessLayer.BRealES.IRepository;
using Business.BusinessLayer.BUser.IRepository;
using Data.DataLayer;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;
using Microsoft.EntityFrameworkCore;

namespace Business.BusinessLayer.BRealES.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly MyDbContext _db;
        public FavoriteRepository(IMapper map, IUserRepository userRepository, MyDbContext context)
        {
            _mapper = map;
            this._userRepository = userRepository;
            this._db = context;
        }
        public bool AddFavorite(string id)
        {
            var userId = _userRepository.GetCurrentUser().Id;
            var check = _db.Favorites.AsNoTracking().Where(x => x.UserId == userId && x.RealEsid == id).ToList();
            if (check.Count > 0)
            {
                return RemoveRealEs(id);
            }
            var fav = new Favorite
                {
                    RealEsid = id,
                    UserId = userId
                }
                ;
            _db.Favorites.Add(fav);
            _db.SaveChanges();
            return true;
        }

        public List<FavVm> GetFavoriteByUserId()
        {
            var userId = _userRepository.GetCurrentUser().Id;

            var favs = _db.Favorites
                .Where(x => x.UserId == userId)
                .Select(x => x.RealEsid)
                .ToList();

            var realEs = _db.RealEs
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

        public bool RemoveRealEs(string id)
        {
            var userId = _userRepository.GetCurrentUser().Id;
            var fav = new Favorite
                {
                    RealEsid = id,
                    UserId = userId
                }
                ;
            _db.Favorites.Remove(fav);
            _db.SaveChanges();
            return true;
        }
    }
}
