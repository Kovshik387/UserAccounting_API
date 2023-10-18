using System.Security.Cryptography;
using System.Text;

namespace UserAccounting.Helpers
{
    public class UserHashPassword
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace(".","").ToLower();
                return hash;
            }
            
            //byte[] salt;
            //byte[] buffer2;
            //if (password == null)
            //{
            //    throw new ArgumentNullException("password");
            //}
            //using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            //{
            //    salt = bytes.Salt;
            //    buffer2 = bytes.GetBytes(0x20);
            //}
            //byte[] dst = new byte[0x31];
            //Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            //Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            //return Convert.ToBase64String(dst);
        }
    }
}
