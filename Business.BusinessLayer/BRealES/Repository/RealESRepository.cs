using Business.BusinessLayer.BCommon.IRepository;
using Business.BusinessLayer.BRealES.IRepository;
using Business.BusinessLayer.BUser.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Services.Mapper;
using Data.DataLayer;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessLayer.BRealES.Repository
{
    public class RealEsRepository : IRepository.IRealESRepository
    {
      
        public readonly UserManager<IdentityUser> UserManager;
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;
        private readonly IServicesRepository _servicesRepository;
        private readonly IFeatureRepository _iFeatureRepository;
        private readonly IAddressRepository _iAddressRepository;
        private readonly IRoomRepository _iRoomRepository;
        private readonly IUserRepository _userRepository;

        public RealEsRepository(IUserRepository userRepository, IRoomRepository roomRepository, IAddressRepository addressRepository, IServicesRepository servicesRepository, MyDbContext myDbContext,UserManager<IdentityUser> user, IMapper map, IFeatureRepository f)
        {
          
            UserManager = user;
            this._db = myDbContext;
            _mapper = map;
            _servicesRepository = servicesRepository;
            _iFeatureRepository = f;
            _iAddressRepository = addressRepository;
            _iRoomRepository = roomRepository;
            this._userRepository = userRepository;
        }

        public bool Create(CreateVm createVm)
        {
            var realESid = Guid.NewGuid().ToString();


            var addressid = _iAddressRepository.Create(createVm, realESid);

            var roomId = _iRoomRepository.Create(createVm, realESid);

            RealEs realEs = _mapper.Map<RealEs>(createVm);
            realEs.Id = realESid;
            realEs.RoomId = roomId;
            realEs.AddressId = addressid;
            realEs.UserId = _userRepository.GetCurrentUser().Id;
            _db.RealEs.Add(realEs);
            _db.SaveChanges();

            _servicesRepository.UploadImgPropery(createVm.ImageFiles, realESid);

            _iFeatureRepository.Create(createVm.Features, realESid);

            return true;

        }



        public List<RealEs> Filter(IQueryable<RealEs> data, FilterVm filter)
        {
            
            if (!string.IsNullOrEmpty(filter.Estate))
            {
                data = data.Where(x => x.Name.Contains(filter.Estate));
            }

            if (!string.IsNullOrEmpty(filter.Country))
            {
                data = data.Where(x => x.Address.Country.Name.Contains(filter.Country));
            }

            if (filter.CategoryId != null)
            {
                data = data.Where(x => x.CategoryId == filter.CategoryId);
            }

            if (filter.Feature != null && filter.Feature.Any(x => x.IsSelected))
            {
                var selectedFeatures = filter.Feature.Where(x => x.IsSelected)
                    .Select(x => x.Id)
                    .ToList();
                data = data.Where(x => x.RealEsFeatures.Any(f => selectedFeatures.Contains(f.FeatureId)));
            }

            if (filter.Categories != null && filter.Categories.Any(x => x.IsSelected))
            {
                var selectedCategories = filter.Categories.Where(x => x.IsSelected)
                    .Select(x => x.Id)
                    .ToList();
                data = data.Where(x => selectedCategories.Contains(x.Category.Id));
            }

            if (filter.MinPrice > 0 && filter.MaxPrice < 10e5)
            {
                data = data.Where(x => x.Price >= filter.MinPrice && x.Price <= filter.MaxPrice);
            }

            if (filter.CountryFilter != null)
            {
                data = data.Where(x => x.Address.Country.Id == filter.CountryFilter);

                if (filter.CityFilter != null)
                {
                    data = data.Where(x => x.Address.City.Id == filter.CityFilter);

                    if (filter.HoodFilter != null)
                    {
                        data = data.Where(x => x.Address.Hood.Id == filter.HoodFilter);
                    }
                }
            }

            // Return the filtered data
            return data.ToList();
        }


        public List<CardVm> GetCardsForIndexPage(List<RealEs> realEss)
        {
            List<CardVm> cardVm = new List<CardVm>();

            cardVm = _mapper.Map<List<CardVm>>(realEss);
            if (cardVm.Count() > 0)
            {

                cardVm[0].Categories = _servicesRepository.GetCategoriesAsSelecttionCategories();
                cardVm[0].Features = _servicesRepository.GetFeaturesAsSelectionFeature();
            }
            else
            {
                cardVm.Add(
                    new CardVm
                    {
                        Categories = _servicesRepository.GetCategoriesAsSelecttionCategories(),
                        Features = _servicesRepository.GetFeaturesAsSelectionFeature()
                    }
                    );
            }



            return cardVm;


        }

        public List<FavVm> GetMyPropertiesByCurrentUser()
        {
            var data = GetByUserId(_userRepository.GetCurrentUser().Id);
            var myProp = _mapper.Map<List<FavVm>>(data);


            return myProp;



        }

        public RealEs GetRealEsWithComment(string id)
        {
            var realId = _db.RealEs.Include(x => x.Comments).ThenInclude(x => x.User).Include(x => x.Images).Include(x => x.RealEsFeatures).ThenInclude(x => x.Feature).Include(x => x.Address).ThenInclude(x => x.Country).ThenInclude(x => x.Cities).ThenInclude(x => x.Hoods).Include(x => x.Room).FirstOrDefault(x => x.Id == id);
            return realId;
        }

        public void IncrementView(string realid)
        {
            var data = _db.RealEs.Where(x => x.Id == realid).FirstOrDefault();
            data.Views++;
            _db.RealEs.Update(data);
            _db.SaveChanges();

        }

        public DetailsVm GetDetails(string id)
        {
            var data = GetRealEsWithComment(id);
            var detail = _mapper.Map<DetailsVm>(data);
            return detail;
        }

        public async Task<CreateVm>  UpdateGet(string id)
        {
            var realES = 
               await _db.RealEs
                    .Include(x => x.Address)
                    .ThenInclude(x => x.Country)
                    .ThenInclude(x => x.Cities)
                    .ThenInclude(x => x.Hoods)
                    .Include(x => x.Images)
                    .Include(x => x.Room)
                    .Include(x => x.User)
                    .Include(x => x.RealEsFeatures.Where(x => x.RealEsid == id))
                    .ThenInclude(x => x.Feature)
                    .Include(x => x.Category)
                    .FirstOrDefaultAsync(x => x.Id == id);

            var d = _mapper.Map<CreateVm>(realES);
            return d;
        }

        public IQueryable<RealEs> GetAll()
        {
            var data = _db.RealEs
                .Include(x => x.Address)
                .ThenInclude(x => x.Country)
                .ThenInclude(x => x.Cities)
                .ThenInclude(x => x.Hoods)
                .Include(x => x.Images)
                .Include(x => x.Room)
                .Include(x => x.User)
                .Include(x => x.RealEsFeatures)!
                .ThenInclude(x => x.Feature)
                .Include(x => x.Category).Include(realEs => realEs.Address).ThenInclude(address => address.City)
                .Include(realEs => realEs.Address).ThenInclude(address => address.Hood)
                .AsQueryable();
            return data;
        }

        public RealEs GetById(string id)
        {
            var data = _db.RealEs.Where(x => x.Id == id)
                .Include(x => x.Images)
                .Include(x => x.Address)
                .ThenInclude(x => x.Country)
                .ThenInclude(x => x.Cities)
                .ThenInclude(x => x.Hoods)
                .FirstOrDefault();
            return data;
        }

        public List<RealEs> GetByUserId(string userId)
        {
            var data = _db.RealEs.Where(x => x.UserId == userId)
                .Include(x => x.Images)
                .Include(x => x.Address)
                .ThenInclude(x => x.Country)
                .ThenInclude(x => x.Cities)
                .ThenInclude(x => x.Hoods)
                .ToList();
            return data;
        }


        public bool Delete(string id)
        {
            var data = GetById(id);
            _db.RealEs.Remove(data);
            _db.SaveChanges();
            _iAddressRepository.Delete(id);
            _iRoomRepository.Delete(id);
            return true;
        }

        public bool Update(CreateVm updateVm)
        {

            /*if (!prop.flag)
           {*/

            /* }
             else
             {
                 var realES = await
                     db.RealES
              .Include(x => x.Address)
              .ThenInclude(x => x.Country)
              .ThenInclude(x => x.Cities)
              .ThenInclude(x => x.hoods)
              .Include(x => x.Images)
              .Include(x => x.Room)
              .Include(x => x.User)
              .Include(x => x.RealESFeatures)
              .ThenInclude(x => x.Feature)
              .Include(x => x.Category)
              .FirstOrDefaultAsync(x => x.ID == prop.IDRealES);


                 realES.Name = prop.Name.Trim();
                 realES.Price = prop.Price;
                 realES.Description = prop.Description;
                 realES.AddressID = prop.IDAddress;
                 realES.RoomID = prop.IDRoom;
                 realES.Area_Size = prop.Area_Size;
                 realES.Email = prop.Email;
                 realES.PhoneNumber = prop.PhoneNumber;
                 realES.CategoryID = prop.CategoryId;

                 var features = prop.Features
                 .Where(x => x.isSelected == true)
                 .Select(x => x.Id)
                 .ToList();
                 List<RealESFeature> r = new List<RealESFeature>();
                 foreach (var fg in features)
                 {
                     r.Add(new RealESFeature { FeatureID = fg, RealESID = prop.IDRealES });

                 }
                 realES.RealESFeatures = r;




                 realES.Room.N_Bathroom = prop.N_Bathroom;
                 realES.Room.N_Bedroom = prop.N_Bedroom;
                 realES.Room.N_Garage = prop.Carage;
                 realES.Room.N_Floors = "1";
                 realES.Room.N_Kitchen = "1";
                 realES.Room.N_LivingRoom = "1";
                 realES.Room.RealESId = prop.IDRealES;
                 realES.Room.RoomID = prop.IDRoom;
                 realES.Room.N_Rooms = prop.NRooms;

                 realES.Address.HoodID = prop.HoodId;
                 realES.Address.CityID = prop.CityId;
                 realES.Address.CountryID = prop.CountryId;
                 realES.Address.RealESID = prop.IDRealES;
                 realES.Address.AddressID = prop.IDAddress;

                 db.RealES.Update(realES);

             }*/


            /* var realES = await
                    db.RealES
             .Include(x => x.Address)
             .ThenInclude(x => x.Country)
             .ThenInclude(x => x.Cities)
             .ThenInclude(x => x.hoods)
             .Include(x => x.Images)
             .Include(x => x.Room)
             .Include(x => x.User)
             .Include(x => x.RealESFeatures.Where(x => x.RealESID == id))
             .ThenInclude(x => x.Feature)
             .Include(x => x.Category)
             .FirstOrDefaultAsync(x => x.ID == id);


             List<SelectionFeatures> r = new List<SelectionFeatures>();
             foreach (var fg in data.Features)
             {
                 bool f = true;
                 foreach (var i in realES.RealESFeatures)
                 {
                     if (fg.Id == i.FeatureID)
                     {
                         r.Add(new SelectionFeatures { Id = fg.Id, Name = fg.Name, isSelected = true });
                         f = false;
                         break;
                     }
                 }

                 if (f)
                 { r.Add(new SelectionFeatures { Id = fg.Id, Name = fg.Name, isSelected = false }); }

             }
             data.IDRealES = realES.ID;
             data.Name = realES.Name;
             data.Price = realES.Price;
             data.Description = realES.Description;
             data.IDAddress = realES.AddressID;
             data.IDRoom = realES.RoomID;
             data.Area_Size = realES.Area_Size;
             data.Email = realES.Email;
             data.PhoneNumber = realES.PhoneNumber;
             data.CategoryId = realES.CategoryID;
             data.Features = r;
             data.CountryId = realES.Address.CountryID;
             data.CityId = realES.Address.CityID;
             data.HoodId = realES.Address.HoodID;
             data.NRooms = realES.Room.N_Rooms;
             data.N_Bedroom = realES.Room.N_Bedroom;
             data.N_Bathroom = realES.Room.N_Bathroom;
             data.Carage = realES.Room.N_Garage;
             data.UserID = _userManager.GetUserId(User);

             data.flag = true;
             return View(data);*/
            return true;
        }


    }
}
