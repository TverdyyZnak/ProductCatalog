namespace Application.DTO.UserDtos
{
    public record UserLogin
    (
        Guid UserId,
        string Jwt
    );
}
