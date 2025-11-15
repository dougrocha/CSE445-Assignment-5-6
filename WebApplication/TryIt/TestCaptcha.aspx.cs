using System;
using System.Drawing;

namespace WebApplication
{
    public partial class TestCaptcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page initialization if needed
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // Validate the captcha using the control's public method
            if (MyCaptcha.ValidateCaptcha())
            {
                ResultLabel.Text = "✅ SUCCESS! Captcha verified correctly.";
                ResultLabel.ForeColor = Color.Green;
                ResultLabel.BackColor = Color.LightGreen;
                ResultLabel.Visible = true;
            }
            else
            {
                ResultLabel.Text = "❌ FAILED! Incorrect code. Please try again.";
                ResultLabel.ForeColor = Color.DarkRed;
                ResultLabel.BackColor = Color.LightPink;
                ResultLabel.Visible = true;
            }
        }
    }
}