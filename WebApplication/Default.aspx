<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Content here for Form 1</h1>

    <!-- Navigation Buttons -->
    <div class="section">
        <h2>Application Navigation</h2>
        <div class="button-group">
            <asp:Button ID="btnMemberPage" runat="server" Text="Member Page"
                OnClick="btnMemberPage_Click" Width="150px" />
            <asp:Button ID="btnStaffPage" runat="server" Text="Staff Page"
                OnClick="btnStaffPage_Click" Width="150px" />
            <asp:Label ID="lblLoginStatus" runat="server" ForeColor="Green"
                Text="" Style="margin-left: 20px;"></asp:Label>
        </div>
    </div>
</asp:Content>
