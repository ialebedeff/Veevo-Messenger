using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Tools
{
    internal class ConfirmationCodeGenerator
    {
        public ConfirmationCodeGenerator() { }
        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public static string Create(string email)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash($"{email}_{DateTime.UtcNow}"))
                sb.Append(b.ToString("X2"));
            return sb.ToString().ToLower();
        }
    }
}
