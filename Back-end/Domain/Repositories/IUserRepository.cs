using Domain.Models;
using Domain.Primitives;
using Domain.Primitives.Enums;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<Result<User>> GetByIdAsync(Guid id);
        Task<Result<User>> GetByLoginAsync(string login);
        Task<List<User>> GetByRoleAsync(Role role);
        Task<Result<Guid>> DeleteByIdAsync(Guid id);
        Task<Result<Guid>> CreateAsync(User user);
        Task<Result<Guid>> UpdateAsync(User user);
    }
}
