using Application.DTO.UserActionDtos;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface IUserActionService
    {
        Task<Result<List<UserActionDto>>> GetAllUserActions();
    }
}
