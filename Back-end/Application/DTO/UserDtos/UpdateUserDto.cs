namespace Application.DTO.UserDtos
{
    public record UpdateUserDto
    (
        Guid id,
        string? password,
        bool isBlocked,
        UserRole userRole
    );
}
