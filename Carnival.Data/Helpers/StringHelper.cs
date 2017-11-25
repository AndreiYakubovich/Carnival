#region

using System;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Carnival.Data.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        ///     Создание хеш суммы с любой строки
        /// </summary>
        /// <param name="input">Строка для создание</param>
        /// <returns>Хеш (128 бит)</returns>
        public static string ComputeStringHash(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input");

            byte[] hashBytes;
            using (var ha = MD5.Create())
                hashBytes = ha.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}