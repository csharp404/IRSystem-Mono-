namespace Data.EntityModels
{
    public class Services
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<RealEsService> RealEsServices { get; set; }
    }
}
