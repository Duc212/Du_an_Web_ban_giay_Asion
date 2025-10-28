using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Helper.Utils
{
    public static class CryptoHelperUtil
    {
        private static string? _secretKey;

        public static void Init(IConfiguration configuration)
        {
            _secretKey = configuration["EncryptionSettings:SecretKey"]
                         ?? throw new ArgumentNullException("EncryptionSettings:SecretKey", "SecretKey not found in configuration");
        }

        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(_secretKey))
                throw new InvalidOperationException("CryptoHelperUtil has not been initialized. Call Init() first.");

            using (Aes aes = Aes.Create())
            {
                aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(_secretKey));
                byte[] iv = new byte[16];
                RandomNumberGenerator.Fill(iv);
                aes.IV = iv;

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (StreamWriter writer = new StreamWriter(cs))
                    {
                        writer.Write(plainText);
                    }
                    return Base64UrlEncode(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(_secretKey))
                throw new InvalidOperationException("CryptoHelperUtil has not been initialized. Call Init() first.");

            byte[] encryptedBytes = Base64UrlDecode(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(_secretKey));

                byte[] iv = new byte[16];
                Buffer.BlockCopy(encryptedBytes, 0, iv, 0, iv.Length);
                aes.IV = iv;

                using (MemoryStream ms = new MemoryStream(encryptedBytes, iv.Length, encryptedBytes.Length - iv.Length))
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static string Base64UrlEncode(byte[] input)
        {
            return Convert.ToBase64String(input)
                .Replace("+", "-")
                .Replace("/", "_")
                .TrimEnd('=');
        }

        private static byte[] Base64UrlDecode(string input)
        {
            string base64 = input.Replace("-", "+").Replace("_", "/");
            while (base64.Length % 4 != 0)
            {
                base64 += "=";
            }
            return Convert.FromBase64String(base64);
        }
    }
}
