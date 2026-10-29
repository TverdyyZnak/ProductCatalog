namespace Application.DTO.UserDtos
{
    public record CreateUserDto
    (
        string login,
        string password,
        bool isBlocked,
        UserRole userRole
    );
}
