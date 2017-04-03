namespace ShopSite.Models
{
    public class ProductAttribute
    {
        public int Id { get; set; }

        public int GroupId { get; set; }
        public string Name { get; set; }

        public virtual ProductAttributeGroup Group { get; set; }
    }
}
