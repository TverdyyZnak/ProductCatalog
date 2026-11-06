using Application.Commons;
using Application.DTO.UserDtos;

namespace Application.DTO.UserActionDtos
{
    public record UserActionDto(
        Guid Id,
        Guid UserId,
        string Text,
        DateTime ActionDateTime,
        string ActionType
    );
    
}
