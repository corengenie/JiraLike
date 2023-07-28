using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Auth {
    public class AuthOptions {
        public const string ISSUER = "webapi"; // издатель токена
        public const string AUDIENCE = "vueapp"; // потребитель токена
        const string KEY = "mLuNrvjsUC3qiAGmJ3tewOXtvvP9Oj";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}