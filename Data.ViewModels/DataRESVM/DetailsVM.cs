using Data.EntityModels;

namespace Data.ViewModels.DataRESVM
{
    public class DetailsVm
    {
        public List<string> ImageName { get; set; }
        public string Description { get; set; } 
        public string Title { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Hood { get; set; }
        public string NBedRoom { get; set; }
        public string TotalRooms { get; set; }
        public string NBathrooms { get; set; }
        public int AreaSiza { get; set; }
        public string UserName { get; set; }
        public string UserPp { get; set; }
        public string Email { get; set; }   
        public string Date { get; set; }
        public string Garage { get; set; }
        public string PhoneNumber { get; set; }
        public List<String> Features { get; set; }
        public string UserId {  get; set; }  
        public string RealId {  get; set; }  
       public  ICollection<Comments> Commentslist { get; set; }
        public string Comment { get; set; }
        public int Views { get; set; }
        
    }
}
