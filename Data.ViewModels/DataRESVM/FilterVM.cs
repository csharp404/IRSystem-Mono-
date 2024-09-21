using Microsoft.AspNetCore.Mvc.Rendering;

namespace Data.ViewModels.DataRESVM
{
    public class FilterVm
    {
        public int MaxPrice { get; set; }
        public int MinPrice { get; set; }
        public List<SelectionFeatures>? Categories { get; set; }
        public List<SelectListItem>? CategoriesList { get; set; }
        public List<SelectionFeatures>? Feature { get; set; }
        public string CategoryId { get; set; }
        public String Estate { get; set; }
        public String Country{ get; set; }
        public string CountryFilter { get; set; }
        public string CityFilter { get; set; }
        public string HoodFilter { get; set; }
    }
}
