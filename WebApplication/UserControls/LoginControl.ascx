<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="WebApplication.UserControls.LoginControl" %>

<div class="login-control">
    <h3>
        <asp:Label ID="lblTitle" runat="server" Text="Member Login"></asp:Label></h3>

    <div class="form-group">
        <asp:Label ID="lblUsername" runat="server" Text="Username:" AssociatedControlID="txtUsername"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="lblPassword" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    </div>
</div>

<style>
    .login-control {
        border: 1px solid #ddd;
        padding: 20px;
        border-radius: 5px;
        max-width: 400px;
        margin: 20px 0;
    }

    .form-group {
        margin-bottom: 15px;
    }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
</style>
