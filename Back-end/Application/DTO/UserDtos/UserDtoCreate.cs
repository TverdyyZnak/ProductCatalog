namespace Application.DTO.UserDtos
{
    public record UserDtoCreate
    (
        string Login,
        string Password,
        bool IsBlocked,
        string UserRole
    );
}
