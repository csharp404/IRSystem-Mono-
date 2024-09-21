namespace Data.EntityModels
{
    public class Feature
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<RealEsFeature> RealEsFeatures { get; set; }
    }
}
