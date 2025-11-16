using System;
using System.Web.UI;

namespace WebApplication
{
    public partial class DougServiceDirectory : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page initialization if needed
        }

        protected void btnDllPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TryIt/DllLibraryTest.aspx");
        }

        protected void btnWebServicePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TryIt/DougWebService.aspx");
        }

        protected void btnLoginControlTest_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TryIt/TestLoginControl.aspx");
        }

        protected void btnBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
