namespace ShopSite.Models
{
    public class Attribute
    {
        public int Id { get; set; }

        public int GroupId { get; set; }
        public string Name { get; set; }

        public virtual AttributeGroup Group { get; set; }
    }
}
