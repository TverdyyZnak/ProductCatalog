namespace Application.DTO.UserDtos
{
    public record UserDto
    (
        Guid Id,
        string Login,
        string HashPass,
        bool IsBlocked,
        string UserRole
    );
}
