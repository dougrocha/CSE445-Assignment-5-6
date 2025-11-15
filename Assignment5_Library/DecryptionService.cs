using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Assignment5_Library
{
    public class DecryptionService
    {
        // Secret Key for AES Encryption
        private static readonly byte[] DecryptionKey = Encoding.UTF8.GetBytes("CSE445_ASSIGNMENT_KEY_32BYTES!!!");

        public static string Decrypt(string encryptedText)
        {
            // Validate input
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentException("Encrypted text cannot be null or empty", nameof(encryptedText));

            try
            {
                using (Aes aes = Aes.Create())
                {
                    // Configure AES decryption (must match encryption settings)
                    aes.Key = DecryptionKey;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    // Convert from Base64 to bytes
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

                    // Extract IV from the beginning (first 16 bytes)
                    byte[] iv = new byte[aes.IV.Length];
                    Array.Copy(encryptedBytes, 0, iv, 0, iv.Length);

                    // Extract the actual encrypted data (everything after IV)
                    byte[] encryptedDataOnly = new byte[encryptedBytes.Length - iv.Length];
                    Array.Copy(encryptedBytes, iv.Length, encryptedDataOnly, 0, encryptedDataOnly.Length);

                    // Create decryptor with the extracted IV
                    using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, iv))
                    {
                        // Decrypt the data
                        using (MemoryStream ms = new MemoryStream(encryptedDataOnly))
                        {
                            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader sr = new StreamReader(cs, Encoding.UTF8))
                                {
                                    return sr.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Decryption failed. The encrypted text may be corrupted or invalid.", ex);
            }
        }
    }
}
