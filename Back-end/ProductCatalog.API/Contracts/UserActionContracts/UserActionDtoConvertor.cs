using Application.DTO.UserActionDtos;

namespace ProductCatalog.API.Contracts.UserActionContracts
{
    public static class UserActionDtoConvertor
    {
        public static List<UserActionResponse> ToResponse(List<UserActionDto> dtos)
        {
            var result = dtos.Select(a => new UserActionResponse(a.Id, a.UserId, a.Text, a.ActionDateTime, a.ActionType)).ToList();
            return result;
        }
    }
}
