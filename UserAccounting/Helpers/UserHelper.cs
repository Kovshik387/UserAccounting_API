using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserAccounting.Common;
using UserAccounting.DAL.Entity;

namespace UserAccounting.Helpers
{
    public static class UserHelper
    {
        public static string GenerateJwtToken(this IConfiguration configuration, UserLoginData user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Secret"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Userid.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = AuthOptions.ISSUER,
                Audience = AuthOptions.AUDIENCE,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
