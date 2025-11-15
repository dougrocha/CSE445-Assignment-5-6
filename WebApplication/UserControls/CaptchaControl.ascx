<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaptchaControl.ascx.cs" 
    Inherits="WebApplication.UserControls.CaptchaControl" %>

<div style="border: 2px solid #0066cc; padding: 15px; background-color: #f5f5f5; display: inline-block; border-radius: 5px;">
    <h4 style="margin-top: 0; color: #0066cc;">🔒 Security Verification</h4>
    
    <!-- Display the captcha image -->
    <asp:Image ID="CaptchaImage" runat="server" 
               Style="border: 2px solid #333; margin-bottom: 10px; display: block;" 
               AlternateText="Captcha Image" />
    
    <!-- Refresh button -->
    <asp:Button ID="RefreshButton" runat="server" Text="🔄 Refresh Code" 
                OnClick="RefreshButton_Click" 
                Style="margin-bottom: 10px; padding: 5px 10px; cursor: pointer;" />
    
    <br />
    
    <!-- User input -->
    <asp:Label ID="Label1" runat="server" Text="Enter the code shown above:" 
               Style="font-weight: bold; display: block; margin-bottom: 5px;"></asp:Label>
    <asp:TextBox ID="CaptchaTextBox" runat="server" MaxLength="6" 
                 Style="padding: 5px; font-size: 16px; width: 150px;"></asp:TextBox>
    
    <br /><br />
    
    <!-- Validation message -->
    <asp:Label ID="ValidationLabel" runat="server" 
               ForeColor="Red" Visible="false" 
               Style="font-weight: bold;"></asp:Label>
</div>