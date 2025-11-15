using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Assignment5_Library
{
    public class HashingService
    {
        public static string ComputeHash(string input)
        {
            // Validate input
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty", nameof(input));

            // Create SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert string to byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Compute hash
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convert hash bytes to hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static bool VerifyHash(string input, string hash)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(hash))
                return false;

            // Compute hash of input and compare with provided hash
            string inputHash = ComputeHash(input);

            // Use constant-time comparison to prevent timing attacks
            return SlowEquals(inputHash, hash);
        }

        private static bool SlowEquals(string a, string b)
        {
            // If lengths don't match, they're not equal
            if (a.Length != b.Length)
                return false;

            // Compare each character, always iterating through entire string
            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }

            return result == 0;
        }
    }
}
