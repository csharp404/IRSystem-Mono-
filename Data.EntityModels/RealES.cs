using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EntityModels
{
    public class RealEs
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AreaSize { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string YearBuilt { get; set; }

  
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("AddressID")]
        public string? AddressId { get; set; }
        public Address? Address { get; set; }

        public ICollection<RealEsFeature>? RealEsFeatures { get; set; }
        public ICollection<RealEsService>? RealEsServices { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
        public ICollection<Comments>? Comments { get; set; }
        public ICollection<RealEsImages>? Images{ get; set; }
        public int Views {  get; set; } =0;
        public string? RoomId { get; set; }
        public Room? Room { get; set; }

        public string CategoryId { get; set; }
        public Category? Category { get; set; }

      public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
