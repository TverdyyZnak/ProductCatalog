namespace Infrastructure.DB.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string MainNote { get; set; } = string.Empty;
        public string SubNote { get; set; } = string.Empty;
        public CategoryEntity? Category { get; set; }
    }
}
