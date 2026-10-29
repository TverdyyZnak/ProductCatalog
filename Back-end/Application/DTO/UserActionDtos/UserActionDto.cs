using Application.DTO.UserDtos;

namespace Application.DTO.UserActionDtos
{
    public record UserActionDto(
        string text,
        DateTime actionDate,
        UserDto UserActor
    );
    
}
