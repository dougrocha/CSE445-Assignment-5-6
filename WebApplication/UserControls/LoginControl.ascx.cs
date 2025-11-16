using Assignment5_Library;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;

namespace WebApplication.UserControls
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        private readonly string memberXmlPath = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");

        public event EventHandler LoginSuccessful;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize control if needed
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (IsValidUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);

                // Store in session
                Session["MemberUsername"] = username;
                Session["MemberLoginTime"] = DateTime.Now;

                // Clear the form
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;

                // Show success message
                ShowMessage("Login successful!", false);

                // Raise the LoginSuccessful event for parent page to handle
                LoginSuccessful?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // Error message is already set in IsValidUser method
                ShowMessage(lblMessage.Text, true);
            }
        }

        // Validates User
        private bool IsValidUser(string username, string password)
        {
            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Username and password cannot be empty.";
                return false;
            }

            // Get stored hashed password
            string storedHashedPassword = GetStoredHashedPassword(username);

            if (storedHashedPassword == null)
            {
                lblMessage.Text = "User does not exist.";
                return false;
            }

            // Verify password using hashing service
            bool isValid = HashingService.VerifyHash(password, storedHashedPassword);

            if (!isValid)
            {
                lblMessage.Text = "Incorrect password.";
                return false;
            }

            return true;
        }

        // Get Hashed Password from Member.xml
        private string GetStoredHashedPassword(string username)
        {
            try
            {
                // Load the Member.xml file
                XDocument doc = XDocument.Load(memberXmlPath);

                // Find the member element with matching username
                var member = doc.Descendants("member")
                    .FirstOrDefault(m => m.Element("username")?.Value == username);

                // Return the password element value, or null if member not found
                return member?.Element("password")?.Value;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error accessing member data: " + ex.Message;
                return null;
            }
        }

        private void ShowMessage(string message, bool isError)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            lblMessage.Visible = true;
        }

        public void ClearForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            lblMessage.Visible = false;
        }
    }
}
