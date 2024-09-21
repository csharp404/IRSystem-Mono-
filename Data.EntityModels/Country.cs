namespace Data.EntityModels
{
    public class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<City> Cities{ get; set; }

    }
}
