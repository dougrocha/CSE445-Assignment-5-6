using Assignment5_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication
{
    public partial class Member : System.Web.UI.Page
    {
        private readonly string memberXmlPath = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsernameText.Text;
            string password = txtPasswordText.Text;

            if (IsValidUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                Session["MemberUsername"] = username;
                Session["MemberLoginTime"] = DateTime.Now;

                // TODO: Load and display member-specific content
                // Redirect to member area or show success message
                // ShowMemberContent();
                Response.Write("Login successful!");
            }
            else
            {
                // Show error message
                Response.Write("Invalid username or password.");
            }
        }

        // Extra Helpers Section

        private bool IsValidUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblLoginError.Text = "Username and password cannot be empty.";
                return false;
            }

            string storedHashedPassword = GetStoredHashedPassword(username);

            if (storedHashedPassword == null)
            {
                lblLoginError.Text = "User does not exist.";
                return false;
            }

            bool isValid = HashingService.VerifyHash(password, storedHashedPassword);

            if (!isValid)
            {
                lblLoginError.Text = "Incorrect password.";
                return false;
            }

            return true;
        }

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
                // Log error to label and return null
                lblLoginError.Text = "Error accessing member data: " + ex.Message;
                return null;
            }
        }

        private bool UserExists(string username)
        {
            try
            {
                XDocument doc = XDocument.Load(memberXmlPath);

                // find matching username
                var existingUser = doc.Descendants("member")
                    .FirstOrDefault(m => (string)m.Element("username") == username);

                return existingUser != null;
            }
            catch (Exception)
            {
                lblLoginError.Text = "Error accessing member data.";
                return false;
            }
        }

        private void SaveMemberToXml(string username, string hashedPassword)
        {
            try
            {
                XDocument doc = XDocument.Load(memberXmlPath);
                XElement newMember = new XElement("member",
                    new XElement("username", username),
                    new XElement("password", hashedPassword),
                    new XElement("joinDate", DateTime.Now.ToString("yyyy-MM-dd"))
                );
                doc.Root.Add(newMember);
                doc.Save(memberXmlPath);
            }
            catch (Exception)
            {
                lblLoginError.Text = "Error saving member data.";
            }
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtCreateUsernameText.Text;
            string password = txtCreatePasswordText.Text;

            if (UserExists(username))
            {
                lblCreateAccountError.Text = "Username already exists.";
                return;
            }

            string hashedPassword = HashingService.ComputeHash(password);
            SaveMemberToXml(username, hashedPassword);
            Response.Write("Account created successfully!");

            txtCreateUsernameText.Text = "";
            txtCreatePasswordText.Text = "";
        }
    }
}