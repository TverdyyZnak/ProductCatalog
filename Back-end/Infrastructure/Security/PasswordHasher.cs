using Application.Interfaces;

namespace Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        //Сделал так ТОЛЬКО ДЛЯ ТЕСТОВОГО ЗАДАНИЯ
        //Для локальной разработки используются файлы системы (User Secrets)
        //Для коммерческой - особые сервисы
        private readonly string _passwordKey = "IleRAERdfHCLMONVnEcu3oc0NChe94buu2888gsaCKSDXNnsac73";

        public string HashGenerate(string password)
        {
            string hPass = BCrypt.Net.BCrypt.HashPassword(password + _passwordKey);
            return hPass;
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password + _passwordKey, hash);
        }
    }
}
