using Domain.Models;
using Domain.Primitives;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Result<Category>> GetByIdAsync(Guid categoryId);
        Task<Result<Guid>> UpdateAsync(Category category);
        Task<Result<Guid>> DeleteAsync(Guid id);
        Task<Result<Guid>> CreateAsync(Category category);
        
    }
}
