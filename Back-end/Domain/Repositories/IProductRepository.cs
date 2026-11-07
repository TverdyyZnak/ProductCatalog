using Domain.Models;
using Domain.Primitives;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Result<Product>> GetByIdAsync(Guid id);
        Task<List<Product>> GetByCategoryAsync(Guid categoryId);
        Task<List<Product>> GetProductByFiltre
            (
                string?
                searchName,
                decimal? minPrice,
                decimal? maxPrice,
                Guid? categoryId,
                string? sortBy
            );
        Task<Result<Guid>> CreateAsync(Product product);
        Task<Result<Guid>> UpdateAsync(Product product);
        Task<Result<Guid>> DeleteAsync(Guid id);
    }
}
