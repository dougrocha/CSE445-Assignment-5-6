using System;
using System.Web.Security;

namespace WebApplication.TryIt
{
    public partial class TestLoginControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoginControl1.LoginSuccessful += LoginControl1_LoginSuccessful;

                // Display initial session status
                UpdateSessionInfo();
            }
        }

        protected void LoginControl1_LoginSuccessful(object sender, EventArgs e)
        {
            UpdateSessionInfo();

            // Redirect to actual member page here
            // Response.Redirect("~/Member.aspx");
        }

        // Handle session info display
        private void UpdateSessionInfo()
        {
            if (Session["MemberUsername"] != null)
            {
                string username = Session["MemberUsername"].ToString();
                DateTime loginTime = Session["MemberLoginTime"] != null
                    ? (DateTime)Session["MemberLoginTime"]
                    : DateTime.Now;

                lblSessionInfo.Text = $"<strong>Logged in as:</strong> {username}<br/>" +
                                     $"<strong>Login time:</strong> {loginTime:yyyy-MM-dd HH:mm:ss}<br/>" +
                                     $"<strong>Session ID:</strong> {Session.SessionID}<br/>" +
                                     $"<strong>Authenticated:</strong> {User.Identity.IsAuthenticated}";
                lblSessionInfo.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblSessionInfo.Text = "<strong>Status:</strong> Not logged in<br/>" +
                                     $"<strong>Session ID:</strong> {Session.SessionID}<br/>" +
                                     $"<strong>Authenticated:</strong> {User.Identity.IsAuthenticated}";
                lblSessionInfo.ForeColor = System.Drawing.Color.Gray;
            }
        }

        protected void btnCheckSession_Click(object sender, EventArgs e)
        {
            UpdateSessionInfo();
        }

        // Logout button
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            FormsAuthentication.SignOut();

            LoginControl1.ClearForm();

            UpdateSessionInfo();

            Response.Write("<script>alert('Logged out successfully!');</script>");
        }
    }
}
