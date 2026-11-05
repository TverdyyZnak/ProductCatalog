using Application.Commons;
using Application.DTO.UserActionDtos;
using Application.Interfaces;

namespace Application.Services
{
    public class UserActionService : IUserActionService
    {
        private readonly IUserActionRepository _userActionRepository;
        public UserActionService(IUserActionRepository userActionRepository)
        {
            _userActionRepository = userActionRepository;
        }
        public async Task CreateAction(Guid userId, string text, ActionType type)
        {
            UserAction action = new UserAction(Guid.NewGuid(), userId, text, DateTime.Now, type);
            await _userActionRepository.CreateActionAsync(action);
        }

        public Task<List<UserActionDto>> GetUserActionByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserActionDto>> GetUserActions()
        {
            throw new NotImplementedException();
        }
    }
}
