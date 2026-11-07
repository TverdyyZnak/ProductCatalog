namespace ProductCatalog.API.Contracts.UserActionContracts
{
    public record UserActionResponse
    (
        Guid Id,
        Guid UserId,
        string Text,
        DateTime ActionDateTime,
        string ActionType
    );
}
