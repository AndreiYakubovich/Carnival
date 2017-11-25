using System.Security.Cryptography;
using System.Text;

namespace Carnival.Data.Models
{
    public static class UserExtensions
    {
        public static string GetEmailHash(this User p)
        {
            var email = p.Email.ToLower();

            byte[] hash;
            using (var md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(email));
            }

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();

        }
    }
}