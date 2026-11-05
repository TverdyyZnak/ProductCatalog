using Application.Interfaces;
using Domain.Models;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Security
{
    public class JwtGenerator : IJwtGenerator
    {
        //ТОЛЬКО ДЛЯ ТЕСТОВОГО ЗАДАНИЯ
        public static readonly TimeSpan _timeSpan = new TimeSpan(2, 0, 0);
        public const string _jwtK = "QCNyacyyt2c6CBE6QTCW8B8CQBjKLSJihchi87773Dfdksv";

        public string GenerateToken(User user)
        {
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserRole.ToString()),
                new Claim("isBlocked", user.IsBlocked.ToString())
            };

            var jwt = new JwtSecurityToken
            (
                expires: DateTime.UtcNow.Add(_timeSpan),
                claims: claim,
                signingCredentials: new SigningCredentials
                (
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtK)),
                    SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
