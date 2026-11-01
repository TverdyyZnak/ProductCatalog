using Domain.Models;
using Domain.Primitives;

namespace Domain.Repositories
{
    public interface IUserActionRepository
    {
        Task<List<UserAction>> GetAllAsync();
        Task<Result<List<UserAction>>> GetByUserIdAsync(Guid id);
        Task<Result<Guid>> CreateAsync(UserAction userAction);
    }
}
