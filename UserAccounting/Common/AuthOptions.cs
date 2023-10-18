using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UserAccounting.Common
{
    public static class AuthOptions
    {
        public const string ISSUER = "ServerAccounting"; // издатель токена
        public const string AUDIENCE = "Client"; // потребитель токена
        public static SymmetricSecurityKey GetSymmetricSecurityKey(string option) =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(option));
    }
}
