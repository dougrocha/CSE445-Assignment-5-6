<%@ Page Title="Member Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WebApplication.Member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Member Page</h2>

    <div>
        <h3>Login</h3>
        <asp:Label ID="txtUsernameLabel" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="txtUsernameText" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="txtPasswordLabel" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPasswordText" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />

        <asp:Label ID="lblLoginError" runat="server" Text="No Error" ForeColor="#CC3300"></asp:Label>
    </div>

    <div>
        <h3>Create Account</h3>
        <asp:Label ID="txtCreateUsernameLabel" runat="server" Text="Create Username"></asp:Label>
        <asp:TextBox ID="txtCreateUsernameText" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="txtCreatePasswordLabel" runat="server" Text="Create Password"></asp:Label>
        <asp:TextBox ID="txtCreatePasswordText" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" />
        <br />

        <asp:Label ID="lblCreateAccountError" runat="server" Text="No Error" ForeColor="#CC3300"></asp:Label>
    </div>
</asp:Content>
