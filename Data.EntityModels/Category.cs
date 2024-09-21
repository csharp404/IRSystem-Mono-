namespace Data.EntityModels
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RealEs> RealEs { get; set; }
    }
}
