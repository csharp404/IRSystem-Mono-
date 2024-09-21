namespace Data.EntityModels
{
    public class RealEsImages
    {
        public string Id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath  { get; set; }
        public string RealEsId { get; set; }
        public RealEs RealEs { get; set; }
    }
}
