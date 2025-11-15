<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCaptcha.aspx.cs" 
    Inherits="WebApplication.TestCaptcha" %>

<%@ Register Src="~/UserControls/CaptchaControl.ascx" TagPrefix="uc" TagName="Captcha" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Captcha User Control - TryIt Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 40px;
            background-color: #f0f0f0;
        }
        .container {
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
            max-width: 700px;
            margin: 0 auto;
        }
        h2 {
            color: #0066cc;
            border-bottom: 2px solid #0066cc;
            padding-bottom: 10px;
        }
        .info-section {
            background-color: #f9f9f9;
            padding: 15px;
            border-left: 4px solid #0066cc;
            margin: 20px 0;
        }
        .btn-submit {
            background-color: #0066cc;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            margin-top: 15px;
        }
        .btn-submit:hover {
            background-color: #0052a3;
        }
        .result-label {
            font-size: 18px;
            font-weight: bold;
            margin-top: 15px;
            padding: 10px;
            border-radius: 4px;
        }
        table {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }
        table td {
            padding: 8px;
            border-bottom: 1px solid #ddd;
        }
        table td:first-child {
            font-weight: bold;
            width: 40%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>🔐 Captcha User Control - TryIt Page</h2>
            
            <div class="info-section">
                <h3 style="margin-top: 0;">Component Information</h3>
                <table>
                    <tr>
                        <td>Provider:</td>
                        <td>Barry</td>
                    </tr>
                    <tr>
                        <td>Component Type:</td>
                        <td>Web User Control (.ascx)</td>
                    </tr>
                    <tr>
                        <td>File:</td>
                        <td>~/UserControls/CaptchaControl.ascx</td>
                    </tr>
                    <tr>
                        <td>Purpose:</td>
                        <td>Image-based CAPTCHA verifier for user registration and security</td>
                    </tr>
                    <tr>
                        <td>Input:</td>
                        <td>User text input (6 characters)</td>
                    </tr>
                    <tr>
                        <td>Output:</td>
                        <td>Boolean validation result (true/false)</td>
                    </tr>
                    <tr>
                        <td>Implementation:</td>
                        <td>C# with System.Drawing for image generation, Session state for code storage</td>
                    </tr>
                    <tr>
                        <td>Where Used:</td>
                        <td>Member.aspx registration form (Assignment 6)</td>
                    </tr>
                </table>
            </div>
            
            <hr />
            
            <h3>📋 Test the Captcha Control:</h3>
            
            <!-- Include the captcha control -->
            <uc:Captcha ID="MyCaptcha" runat="server" />
            
            <br /><br />
            
            <asp:Button ID="SubmitButton" runat="server" Text="✓ Validate Captcha" 
                        OnClick="SubmitButton_Click" CssClass="btn-submit" />
            
            <br /><br />
            
            <asp:Label ID="ResultLabel" runat="server" CssClass="result-label"></asp:Label>
            
            <hr />
            
            <h3>📖 How to Use:</h3>
            <ol>
                <li>Look at the generated captcha image above</li>
                <li>Type the 6-character code you see into the text box</li>
                <li>Click "✓ Validate Captcha" button</li>
                <li>See the validation result below</li>
                <li>Click "🔄 Refresh Code" to generate a new captcha</li>
            </ol>
            
            <h3>✨ Features:</h3>
            <ul>
                <li>Random 6-character alphanumeric code generation</li>
                <li>Visual distortion and noise for security</li>
                <li>Session-based code storage</li>
                <li>Refresh functionality to generate new codes</li>
                <li>Real-time validation with feedback</li>
                <li>Accessible error messages</li>
            </ul>
            
            <p style="margin-top: 30px; font-style: italic; color: #666;">
                <strong>Note:</strong> This control prevents automated bot registrations and will be integrated 
                into the Member.aspx registration page in Assignment 6.
            </p>
        </div>
    </form>
</body>
</html>