namespace Application.Interfaces
{
    public interface IPasswordHasher
    {
        string HashGenerate(string password);
        bool VerifyPassword(string password, string hash);
    }
}
