using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Assignment5_Library;

/// Created by Douglas Rocha
namespace WebApplication.Services
{
    /// <summary>
    /// Summary description for DougWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DougWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string RandomNumberGenerator(int lowBound, int highBound)
        {
            if (lowBound > highBound)
            {
                throw new ArgumentException("lowBound must be less than or equal to highBound");
            }

            Random rand = new Random();
            int randomNumber = rand.Next(lowBound, highBound + 1);
            return randomNumber.ToString();
        }

        [WebMethod]
        public string HashString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty");
            }
            
            return HashingService.ComputeHash(input);
        }

        [WebMethod]
        public bool VerifyHash(string input, string hash)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(hash))
            {
                throw new ArgumentException("Input string and hash cannot be null or empty");
            }
            return HashingService.VerifyHash(input, hash);
        }

        [WebMethod]
        public string EncryptString(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentException("Plain text cannot be null or empty");
            }
            return EncryptionService.Encrypt(plainText);
        }

        [WebMethod]
        public string DecryptString(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                throw new ArgumentException("Cipher text cannot be null or empty");
            }
            return EncryptionService.Decrypt(cipherText);
        }
    }
}
