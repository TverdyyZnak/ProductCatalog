using Domain.Primitives;
using Domain.Primitives.Interfaces;

namespace Domain.Models
{
    public class Category : IEntity
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;

        private Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Result<Category> Create(Guid id, string name) 
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add("Название категории не указано");
            }

            if (errors.Any())
            {
                return Result<Category>.Fail(errors);
            }

            return Result<Category>.Success(new Category(id, name));
        }
    }
}
