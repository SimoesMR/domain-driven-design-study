﻿using System.Security.Cryptography;
using System.Text;

namespace Application.Services.Cryptography
{
    public class PasswordEncripter
    {
        private readonly string _password;

        public PasswordEncripter(string additionalKey) => _password = additionalKey;

        public string Encrypt (string password)
        {
            var newPassword = $"{password}{_password}";

            var bytes = Encoding.UTF8.GetBytes(newPassword);
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }

        //convert um array de bytes em um string
        private static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString();
        }
    }
}
