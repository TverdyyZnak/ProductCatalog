using Domain.Primitives.Enums;

namespace Application.DTO.UserDtos
{
    public record UserDto
    (
        Guid id,
        string login,
        bool isBlocked,
        Role userRole
    );
}
