namespace Data.EntityModels
{
    
    
        public class Favorite
        {

            public string UserId { get; set; }
            public User User { get; set; }

            public string RealEsid { get; set; }
            public RealEs RealEs { get; set; }
        }
    

}
