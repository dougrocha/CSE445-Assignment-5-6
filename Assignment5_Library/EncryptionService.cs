using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Assignment5_Library
{
    public class EncryptionService
    {
        // Secret Key for AES Encryption
        private static readonly byte[] EncryptionKey = Encoding.UTF8.GetBytes("CSE445_ASSIGNMENT_KEY_32BYTES!!!");

        public static string Encrypt(string plainText)
        {
            // Validate input
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentException("Plain text cannot be null or empty", nameof(plainText));

            using (Aes aes = Aes.Create())
            {
                // Configure AES encryption
                aes.Key = EncryptionKey;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Generate random initialization vector
                aes.GenerateIV();
                byte[] iv = aes.IV;

                // Create encryptor
                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, iv))
                {
                    // Convert plain text to bytes
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

                    // Encrypt data
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Write IV at the beginning (needed for decryption)
                        ms.Write(iv, 0, iv.Length);

                        // Write encrypted data
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(plainBytes, 0, plainBytes.Length);
                            cs.FlushFinalBlock();
                        }

                        // Convert to Base64 for storage
                        byte[] encryptedBytes = ms.ToArray();
                        return Convert.ToBase64String(encryptedBytes);
                    }
                }
            }
        }

        public static string Decrypt(string encryptedText)
        {
            // Validate input
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentException("Encrypted text cannot be null or empty", nameof(encryptedText));

            try
            {
                using (Aes aes = Aes.Create())
                {
                    // Configure AES decryption
                    aes.Key = EncryptionKey;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    // Convert from Base64
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

                    // Extract IV from the beginning of encrypted data
                    byte[] iv = new byte[aes.IV.Length];
                    Array.Copy(encryptedBytes, 0, iv, 0, iv.Length);

                    // Extract actual encrypted data
                    byte[] encryptedDataOnly = new byte[encryptedBytes.Length - iv.Length];
                    Array.Copy(encryptedBytes, iv.Length, encryptedDataOnly, 0, encryptedDataOnly.Length);

                    // Create decryptor
                    using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, iv))
                    {
                        // Decrypt data
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
