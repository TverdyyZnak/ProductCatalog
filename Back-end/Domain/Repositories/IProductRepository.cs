using Domain.Models;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<List<Product>> GetByCategoryAsync(Category category);
        Task<Product> CreateAsync(Product product);
        Task<Guid> UpdateAsync(Product product);
        Task<Guid> DeleteAsync(Guid id);
    }
}
