using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BeeFriend.Core.Helpers
{
    internal static class HashHelper
    {
        public static string Hash(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            byte[] hash = SHA256.HashData(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
