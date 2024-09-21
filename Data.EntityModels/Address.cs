namespace Data.EntityModels
{
    public class Address
    {
        public string? AddressId { get; set; } = Guid.NewGuid().ToString();

        public string? CountryId { get; set; }
        public Country? Country { get; set; }

        public string? CityId { get; set; }
        public City? City { get; set; }

        public string? HoodId { get; set; }
        public Hood? Hood { get; set; }

        //RealEstate
        public string? RealEsid { get; set; }
        public RealEs? RealEs { get; set; }
    }
}
