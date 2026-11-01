using Application.DTO.UserActionDtos;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface IUserActionService
    {
        Task<List<UserActionDto>> UserActions();
    }
}
