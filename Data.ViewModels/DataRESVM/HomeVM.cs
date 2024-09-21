
namespace Data.ViewModels.DataRESVM
{
    public sealed record class HomeVm
    {
        public List<CardVm>? Cards { set; get; } 
        public List<CountCategoty>? CountsCategory { set; get; }
        public string? Word { set; get; }
        public string? CategoryId { set; get; }    
        public string? PlaceCountry { set; get; }    
        public string? Price { set; get; }
        public List<SelectionFeatures> Categories { get; set; }
    }
}
