using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace FinanceApp.Encryption
{
    internal static class RsaEncryptionHelper
    {
        private static readonly RSA rsa;
        private static readonly string keyFilePath;


        static RsaEncryptionHelper() 
        {
            keyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Config/rsaKey.xml");

            rsa = RSA.Create(2048);

            if (File.Exists(keyFilePath))
            {
                string keyXml = File.ReadAllText(keyFilePath);
                rsa.FromXmlString(keyXml);
            }
            else
            {
                string keyXml = rsa.ToXmlString(true);
                File.WriteAllText(keyFilePath, keyXml);
            }
        }

        public static string EncryptFloat(float value)
        {
            byte[] data = Encoding.UTF8.GetBytes(value.ToString());
            byte[] encryptedData = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
            return Convert.ToBase64String(encryptedData);
        }

        public static float DecryptFloat(string encryptedValue)
        {
            if (string.IsNullOrEmpty(encryptedValue))
            {
                throw new ArgumentNullException("Encrypted value cannot be null or empty.");
            }

            byte[] encryptedData = Convert.FromBase64String(encryptedValue);
            byte[] decryptedData = rsa.Decrypt(encryptedData, RSAEncryptionPadding.OaepSHA256);
            string decryptedString = Encoding.UTF8.GetString(decryptedData);
            return float.Parse(decryptedString);
        }
    }
}
