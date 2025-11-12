using System;
using System.Web.UI;
using Assignment5_Library;

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
    }
}