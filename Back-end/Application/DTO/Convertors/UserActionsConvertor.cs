using Application.Commons;
using Application.DTO.UserActionDtos;
using Domain.Primitives;

namespace Application.DTO.Convertors
{
    public static class UserActionsConvertor
    {
        public static List<UserActionDto> ToDto(List<UserAction> actions)
        {
            var result = actions.Select(a => new UserActionDto(a.Id, a.UserId, a.Text, a.ActionDateTime, a.ActionType.ToString())).ToList();
            return result;
        }
    }
}
