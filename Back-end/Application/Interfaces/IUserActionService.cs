using Application.Commons;
using Application.DTO.UserActionDtos;
using Domain.Models;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface IUserActionService
    {
        Task<List<UserActionDto>> GetUserActions();
        Task<List<UserActionDto>> GetUserActionByIdAsync(Guid id);
        Task CreateAction(Guid userId, string text, ActionType type);
    }
}
