<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="section">
        <div>
            <h3>Try It Pages:</h3>

            <asp:Button ID="btnDllPage" runat="server" Text="DLL Page"
                OnClick="btnDllPage_Click" Width="150px" />

            <asp:Button ID="btnDougWebServicePage" runat="server" Text="Doug Web Service Test Page"
                OnClick="btnDougWebService" Width="150px" />
        </div>

        <br />

        <div class="button-group">
            <h3>Page Navigation</h3>

            <asp:Button ID="btnMemberPage" runat="server" Text="Member Page"
                OnClick="btnMemberPage_Click" Width="150px" />
            <asp:Button ID="btnStaffPage" runat="server" Text="Staff Page"
                OnClick="btnStaffPage_Click" Width="150px" />
            <asp:Label ID="lblLoginStatus" runat="server" ForeColor="Green"
                Text="" Style="margin-left: 20px;"></asp:Label>
        </div>

        <br />

        <div>
            <h3>Service Directories:</h3>
            <asp:HyperLink ID="lnkDougServiceDirectory" runat="server" 
                NavigateUrl="~/DougServiceDirectory.aspx" 
                CssClass="btn btn-primary" 
                Style="display: inline-block; padding: 10px 20px; text-decoration: none; width: 200px; text-align: center;">
                Doug's Service Directory
            </asp:HyperLink>
        </div>
    </div>
</asp:Content>
