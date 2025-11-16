using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Services;

namespace WebApplication.TryIt
{
    public partial class DougWebService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEncryptInput.Text))
            {
                txtDecryptOutput.Text = "Please enter text to encrypt.";
                return;
            }

            try
            {
                DougWebServiceReference.DougWebServiceSoapClient client = new DougWebServiceReference.DougWebServiceSoapClient();
                string encryptedText = client.EncryptString(txtEncryptInput.Text.Trim());
                txtEncryptOutput.Text = encryptedText;

                client.Close();
            }
            catch (Exception ex)
            {
                txtEncryptOutput.Text = "Error during encryption: " + ex.Message;
            }
        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDecryptInput.Text))
            {
                txtDecryptOutput.Text = "Please enter text to decrypt.";
                return;
            }
            try
            {
                DougWebServiceReference.DougWebServiceSoapClient client = new DougWebServiceReference.DougWebServiceSoapClient();
                string decryptedText = client.DecryptString(txtDecryptInput.Text.Trim());
                txtDecryptOutput.Text = decryptedText;
                client.Close();
            }
            catch (Exception ex)
            {
                txtDecryptOutput.Text = "Error during decryption: " + ex.Message;
            }
        }

        protected void btnHash_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHashInput.Text))
            {
                txtHashOutput.Text = "Please enter text to hash.";
                return;
            }
            try
            {
                DougWebServiceReference.DougWebServiceSoapClient client = new DougWebServiceReference.DougWebServiceSoapClient();
                string hashedText = client.HashString(txtHashInput.Text.Trim());
                txtHashOutput.Text = hashedText;
                client.Close();
            }
            catch (Exception ex)
            {
                txtHashOutput.Text = "Error during hashing: " + ex.Message;
            }
        }
    }
}