using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Apteka.Helpers
{
    public class HashProvider
    {
        private static readonly SHA256 sha256 = SHA256.Create();

        public static string GetHash(string text)
        {
            var hashData = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

            var hash = Encoding.UTF8.GetString(hashData);

            return hash;
        }
    }
}