namespace FinalWebApp.Entities
{
    public class CategoryEntity : BaseEntity<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}
