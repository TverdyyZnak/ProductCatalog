using Domain.Primitives;
using Domain.Primitives.Interfaces;

namespace Domain.Models
{
    public class Product : IEntity
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        public string MainNote { get; } = string.Empty;
        public string SubNote { get; } = string.Empty;
        public Guid CategoryId { get; }
        public Category? Category { get; } = null;

        private Product(Guid id, string name, string desc, decimal price, string mNote, string sNote, Guid categoryId, Category? category)
        {
            Id = id;
            Name = name;
            Description = desc;
            Price = price;
            MainNote = mNote;
            SubNote = sNote;
            CategoryId = categoryId;
            Category = category;
        }

        public static Result<Product> Create(Guid id, string name, string desc, decimal price, string mNote, string sNote, Guid categoryId, Category? category)
        {
            var errors = new List<string>();

            if(price < 0)
            {
                errors.Add("Цена не может быть меньше нуля");
            }

            if (errors.Any())
            {
                return Result<Product>.Fail(errors);
            }

            return Result<Product>.Success(new Product(id, name, desc, price, mNote, sNote, categoryId, category));
        }
    }
}
