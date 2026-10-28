using Domain.Models;

namespace Domain.Repositories
{
    public interface IUserActionRepository
    {
        Task<List<UserAction>> GetAllAsync();
        Task<List<UserAction>> GetByUserIdAsync(Guid id);
        Task<Guid> CreateAsync(UserAction userAction);
    }
}
