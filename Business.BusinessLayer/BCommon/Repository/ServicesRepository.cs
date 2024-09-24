using Business.BusinessLayer.BCommon.IRepository;
using Business.BusinessLayer.BRealES.IRepository;
using Data.DataLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.EntityModels;
using Data.ViewModels.DataRESVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Business.BusinessLayer.BCommon.Repository
{
    public class ServicesRepository : IRepository.IServicesRepository
    {
        private ICategoryRepository _category;
       
        
        private readonly MyDbContext _db;

        public ServicesRepository(ICategoryRepository category, MyDbContext db)
        {
            this._category = category;
            _db = db;
           
        }

        public List<SelectListItem> GetCategoriesAsSelectListItem()
        {
            var types = _category.GetAll();
            var data = types.Select(x => new SelectListItem { Text = x.Name, Value = x.Id }).ToList();
            return data;
        }

        public List<SelectionFeatures> GetCategoriesAsSelecttionCategories()
        {
            var data = _db.Categories.Select(x => new SelectionFeatures { Id = x.Id, Name = x.Name, IsSelected = false })
                .ToList();
            return data;
        }

        public List<SelectListItem> GetFeaturesAsSelectListItem()
        {
            throw new NotImplementedException();
        }

        public List<SelectionFeatures> GetFeaturesAsSelectionFeature()
        {
            var data = _db.Features.Select(x => new SelectionFeatures { Name = x.Name, Id = x.Id }).ToList();
            return data;
        }

        public List<SelectListItem> GetCountryAsSelectListItem()
        {
            var data = _db.Countries.Select(x => new SelectListItem { Text = x.Name, Value = x.Id }).ToList();
            return data;
        }

        public List<Country> GetCountries()
        {
            var data = _db.Countries.ToList();
            return data;
        }

        public async Task<List<City>> GetCities(string id)
        {
            var data = await _db.Cities.Where(x => x.CountryId == id).ToListAsync();
            return data;
        }

        public List<Hood> GetHoods(string id)
        {
            var data = _db.Hoods.Where(x => x.CityId == id).ToList();
            return data;
        }

       

        public async Task<bool> UploadImgPropery(List<IFormFile> images, string realEsid)
        {
            List<RealEsImages> image = new List<RealEsImages>();
            foreach (var item in images)
            {
                var guid = Guid.NewGuid().ToString();

                var path = Path.Combine("C:\\Users\\USER\\source\\repos\\IRSystem\\RESProject101\\wwwroot\\", "Images\\RealESImages", guid + item.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    item.CopyTo(stream);
                };
                image.Add(
                   new RealEsImages
                   {
                       Id = Guid.NewGuid().ToString(),
                       ImageName = guid + item.FileName,
                       ImagePath = path,
                       RealEsId = realEsid
                   }
                );
            }
          await  _db.RealEsImages.AddRangeAsync(image);
           await _db.SaveChangesAsync();
            return true;
        }

        public bool RemoveImagesPropery(string userId)
        {
            throw new NotImplementedException();
        }

        public List<string> SearchAsJson(string word)
        {
            throw new NotImplementedException();
        }

        public List<string> SearchLocationAsJson(string word)
        {
            throw new NotImplementedException();
        }
    }
}
