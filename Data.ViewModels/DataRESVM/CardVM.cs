

namespace Data.ViewModels.DataRESVM
{
    public class CardVm
    {
        public string RealId { get; set; }
        public List<string> ImageName { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Hood { get; set; }
        public string NBedRoom { get; set; }
        public string TotalRooms { get; set; }
        public int AreaSiza { get; set; }
        public string UserName { get; set; }
        public string UserPp { get; set; }
        public string UserId{ get; set; }
        public string Date { get; set; }
       public List<SelectionFeatures> Categories { get; set; }
        public List<SelectionFeatures> Features { get; set; } 
        public bool IsFav { get; set; } = false;
        
    }
}
