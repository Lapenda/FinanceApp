using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace FinanceApp.Encryption
{
    internal static class AesEncryptionHelper
    {
        private const string EncryptionPassword = "MojsigurniKljuczaAES123!";
        private const int SaltSize = 16;
        private const int AesKeySize = 32;
        private const int IvSize = 16;
        private const int Iterations = 10000;

        private static byte[] GenerateKeyAndSalt()
        {
            byte[] salt = new byte[SaltSize];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using(var pbkdf2 = new Rfc2898DeriveBytes(EncryptionPassword, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] key = pbkdf2.GetBytes(AesKeySize);
                byte[] keyWithSalt = new byte[SaltSize + AesKeySize];
                Buffer.BlockCopy(salt, 0, keyWithSalt, 0, SaltSize);
                Buffer.BlockCopy(key, 0, keyWithSalt, SaltSize, AesKeySize);
                return keyWithSalt;
            }
        }

        public static byte[] EncryptString(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("Text that needs to be Encrypted is null");
            }

            byte[] keyWithSalt = GenerateKeyAndSalt();
            byte[] salt = keyWithSalt.Take(SaltSize).ToArray();
            byte[] key = keyWithSalt.Skip(SaltSize).Take(AesKeySize).ToArray();
            byte[] iv = new byte[IvSize];

            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(iv);
            }

            using(var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using(var ms = new MemoryStream())
                {
                    ms.Write(salt, 0, salt.Length);
                    ms.Write(iv, 0, iv.Length);

                    using(var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using(var sw = new StreamWriter(cs))
                    {
                        sw.Write(text);
                    }

                    return ms.ToArray();
                }
            }
        }

        public static string DecryptString(byte[] cipherData)
        {
            if(cipherData == null || cipherData.Length < SaltSize + AesKeySize)
            {
                throw new ArgumentException("Cipher data is too short to contain salt and IV.");
            }

            byte[] salt = cipherData.Take(SaltSize).ToArray();
            byte[] iv = cipherData.Skip(SaltSize).Take(IvSize).ToArray();
            byte[] encryptedData = cipherData.Skip(SaltSize + IvSize).ToArray();

            using(var pbkdf2 = new Rfc2898DeriveBytes(EncryptionPassword, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] key = pbkdf2.GetBytes(AesKeySize);

                using(var aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using(var ms = new MemoryStream(encryptedData))
                    using(var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using(var sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
