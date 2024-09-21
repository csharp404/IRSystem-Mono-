

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Data.ViewModels.DataRESVM
{
    public class CreateVm
    {
        public string? IdRealEs { get; set; }
        public string? IdAddress { get; set; }
       
        public string? IdRoom { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AreaSize { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? UserId { get; set; }
        public string? CountryId { get; set; }
        public string? CityId { get; set; }
        public string? HoodId { get; set; }
        public List<SelectListItem> CountriesListItems { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CitiesListItems { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> HoodsListItems { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CategoryListItems { get; set; } = new List<SelectListItem>();

        public bool Flag { get; set; }

        public string CategoryId { get; set; }

        public string NBedroom { get; set; }
        public string NBathroom { get; set; }
        public string Carage { get; set; }
        public string NRooms { get; set; }
        public string YearBuilt { get; set; }
        public string NFloors { get; set; }
        public string NKitchen { get; set; }
        public string NLivingRoom { get; set; }
          
        public List<IFormFile> ImageFiles { get; set; }

        public List<SelectionFeatures>? Features { get; set; }
        

    }
}
