using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment5_Library;

namespace WebApplication.TryIt
{
    public partial class DllLibraryTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            string txtToEncrypt = txtEncryptInput.Text.Trim();

            if (!string.IsNullOrEmpty(txtToEncrypt))
            {
                // Encrypt the input text
                string encryptedText = EncryptionService.Encrypt(txtToEncrypt);
                txtEncryptOutput.Text = encryptedText;
            }
        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            string txtToDecrypt = txtDecryptInput.Text.Trim();

            if (!string.IsNullOrEmpty(txtToDecrypt))
            {
                // Decrypt the input text
                string decryptedText = EncryptionService.Decrypt(txtToDecrypt);
                txtDecryptOutput.Text = decryptedText;
            }
        }

        protected void btnHash_Click(object sender, EventArgs e)
        {
            string txtToHash = txtHashInput.Text.Trim();

            if (!string.IsNullOrEmpty(txtToHash))
            {
                // Hash the input text
                string hashedText = HashingService.ComputeHash(txtToHash);
                txtHashOutput.Text = hashedText;
            }
        }
    }
}