namespace ProductCatalog.API.Contracts.UserContracts
{
    public record UserLoginRequest
    (
        string Login,
        string Password
    );
}
