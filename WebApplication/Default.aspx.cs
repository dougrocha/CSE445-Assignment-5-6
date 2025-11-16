using System;
using System.Web.UI;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnMemberPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member.aspx");
        }

        protected void btnStaffPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Staff.aspx");
        }

        protected void btnDllPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("TryIt/DllLibraryTest.aspx");
        }

        protected void btnDougWebService(object sender, EventArgs e)
        {
            Response.Redirect("TryIt/DougWebService.aspx");
        }

        protected void btnDougServiceDirectory_Click(object sender, EventArgs e)
        {
            Response.Redirect("DougServiceDirectory.aspx");
        }
    }
}
