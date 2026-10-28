using Domain.Models;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Guid> UpdateAsync(Category category);
        Task<Guid> DeleteAsync(Guid id);
        Task<Guid> CreateAsync(Category category);
    }
}
