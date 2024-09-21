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

namespace Business.BusinessLayer.BCommon.IRepository
{
    public interface IServicesRepository
    {
        public List<SelectListItem> GetCategoriesAsSelectListItem();
        public List<SelectionFeatures> GetCategoriesAsSelecttionCategories();

        public List<SelectListItem> GetFeaturesAsSelectListItem();
        public List<SelectionFeatures> GetFeaturesAsSelectionFeature();

        public List<SelectListItem> GetCountryAsSelectListItem();

        public List<Country> GetCountries();
        public Task<List<City>> GetCities(string id);
        public List<Hood> GetHoods(string id);
        public bool UploadImgPropery(List<IFormFile> images, string realEsid);


        public bool RemoveImagesPropery(string userId);
        public List<string> SearchAsJson(string word);
        public List<string> SearchLocationAsJson(string word);
    }
}
