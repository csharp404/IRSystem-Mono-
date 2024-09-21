namespace Data.EntityModels
{
    public class Hood
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public City City { get; set; }
        public string CityId { get; set; }
    }
}
