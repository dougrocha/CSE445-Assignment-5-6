<%@ Page Title="Member Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="WebApplication.Member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome Member!</h2>
    <asp:Label ID="lblMessage" runat="server" Text="This is the member area." />
</asp:Content>
