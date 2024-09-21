namespace Data.EntityModels
{
    public class Comments
    {
        public string Id { get; set; }
        public string Description { get; set; }

        
        public string RealEsid { get; set; }
        public RealEs RealEs { get; set; }

       
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }  
    }
}

