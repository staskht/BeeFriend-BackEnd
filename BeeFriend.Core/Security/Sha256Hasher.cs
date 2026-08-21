using System.Security.Cryptography;
using System.Text;

namespace BeeFriend.Core.Security
{
    internal static class Sha256Hasher
    {
        public static string Hash(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            byte[] hash = SHA256.HashData(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
