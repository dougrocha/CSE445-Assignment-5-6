using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;

namespace WebApplication.UserControls
{
    public partial class CaptchaControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// BARRY - Captcha User Control Component
        /// Generate captcha when control loads
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateNewCaptcha();
            }
        }

        /// <summary>
        /// Generate new captcha code and image
        /// </summary>
        private void GenerateNewCaptcha()
        {
            // Generate random 6-character code
            string captchaCode = GenerateRandomCode(6);

            // Store in session for validation later
            Session["CaptchaCode"] = captchaCode;

            // Create image and convert to base64
            byte[] imageBytes = GenerateCaptchaImage(captchaCode);
            string base64Image = Convert.ToBase64String(imageBytes);

            // Display image
            CaptchaImage.ImageUrl = "data:image/png;base64," + base64Image;
        }

        /// <summary>
        /// Generate random alphanumeric code (excluding confusing characters)
        /// </summary>
        private string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"; // Removed I, O, 0, 1
            Random random = new Random();
            char[] code = new char[length];

            for (int i = 0; i < length; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }

            return new string(code);
        }

        /// <summary>
        /// Create captcha image with distortion and noise
        /// </summary>
        private byte[] GenerateCaptchaImage(string code)
        {
            int width = 200;
            int height = 80;

            using (Bitmap bitmap = new Bitmap(width, height))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // Set high quality rendering
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                // Background gradient
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(0, 0, width, height),
                    Color.LightBlue,
                    Color.White,
                    45f))
                {
                    graphics.FillRectangle(brush, 0, 0, width, height);
                }

                // Add noise lines
                Random random = new Random();
                using (Pen noisePen = new Pen(Color.LightGray, 1))
                {
                    for (int i = 0; i < 25; i++)
                    {
                        int x1 = random.Next(width);
                        int y1 = random.Next(height);
                        int x2 = random.Next(width);
                        int y2 = random.Next(height);
                        graphics.DrawLine(noisePen, x1, y1, x2, y2);
                    }
                }

                // Draw the code with random colors and positions
                using (Font font = new Font("Arial", 26, FontStyle.Bold))
                {
                    int xPosition = 10;

                    foreach (char c in code)
                    {
                        // Random color for each character
                        Color color = Color.FromArgb(
                            random.Next(50, 150),
                            random.Next(50, 150),
                            random.Next(50, 150));

                        // Slight random vertical offset
                        int yOffset = random.Next(-5, 5);

                        using (SolidBrush charBrush = new SolidBrush(color))
                        {
                            graphics.DrawString(
                                c.ToString(),
                                font,
                                charBrush,
                                xPosition,
                                20 + yOffset);
                        }

                        xPosition += 30;
                    }
                }

                // Add noise dots
                for (int i = 0; i < 150; i++)
                {
                    int x = random.Next(width);
                    int y = random.Next(height);
                    bitmap.SetPixel(x, y, Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
                }

                // Convert to byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Refresh button click - generate new captcha
        /// </summary>
        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            GenerateNewCaptcha();
            CaptchaTextBox.Text = string.Empty;
            ValidationLabel.Visible = false;
        }

        /// <summary>
        /// Public method to validate captcha (called from parent page)
        /// </summary>
        public bool ValidateCaptcha()
        {
            string userInput = CaptchaTextBox.Text.Trim().ToUpper();
            string correctCode = Session["CaptchaCode"] as string;

            if (string.IsNullOrEmpty(userInput))
            {
                ValidationLabel.Text = "⚠️ Please enter the captcha code.";
                ValidationLabel.Visible = true;
                return false;
            }

            if (userInput == correctCode)
            {
                ValidationLabel.Text = "✓ Captcha verified successfully!";
                ValidationLabel.ForeColor = Color.Green;
                ValidationLabel.Visible = true;
                return true;
            }
            else
            {
                ValidationLabel.Text = "✗ Incorrect code. Please try again.";
                ValidationLabel.ForeColor = Color.Red;
                ValidationLabel.Visible = true;
                GenerateNewCaptcha(); // Generate new one
                CaptchaTextBox.Text = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Public method to reset captcha
        /// </summary>
        public void ResetCaptcha()
        {
            GenerateNewCaptcha();
            CaptchaTextBox.Text = string.Empty;
            ValidationLabel.Visible = false;
        }
    }
}