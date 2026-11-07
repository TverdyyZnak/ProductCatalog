namespace ProductCatalog.API.Contracts.UserContracts
{
    public record UserPasswordUpdateRequest
    (
        Guid UserId,
        string OldPassword,
        string NewPassword
    );
}
