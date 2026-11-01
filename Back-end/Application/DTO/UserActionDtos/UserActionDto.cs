using Application.DTO.UserDtos;

namespace Application.DTO.UserActionDtos
{
    public record UserActionDto(
        string Text,
        DateTime ActionDate,
        UserDto UserActor
    );
    
}
