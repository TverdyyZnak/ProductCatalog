using Application.Commons;

namespace Application.Interfaces
{
    public interface IUserActionRepository
    {
        Task<List<UserAction>> GetAllActionsAsync();
        Task<List<UserAction>> GetActionsByUserIdAsync(Guid userId);
        Task CreateActionAsync(UserAction action); 
    }
}
