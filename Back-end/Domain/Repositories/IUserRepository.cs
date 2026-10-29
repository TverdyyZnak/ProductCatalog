using Domain.Models;
using Domain.Primitives.Enums;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByLoginAsync(string login);
        Task<List<User>> GetByRoleAsync(Role role);
        Task<Guid> DeleteByIdAsync(Guid id);
        Task<Guid> CreateAsync(User user);
        Task<Guid> UpdateAsync(User user);
    }
}
