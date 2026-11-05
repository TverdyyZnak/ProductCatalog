namespace Application.DTO.UserDtos
{
    public record UserDtoUpdate
    (
        string Login,
        string Password,
        bool IsBlocked,
        string UserRole
    );
}
