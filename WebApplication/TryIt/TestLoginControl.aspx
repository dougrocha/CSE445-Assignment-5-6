<%@ Page Title="Test Login Control" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestLoginControl.aspx.cs" Inherits="WebApplication.TryIt.TestLoginControl" %>

<%@ Register Src="~/UserControls/LoginControl.ascx" TagPrefix="uc" TagName="LoginControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>TryIt: Login Control Test Page</h2>

    <div class="alert alert-info">
        <h4>About This User Control</h4>
        <p><strong>Component Type:</strong> User Control (.ascx)</p>
        <p><strong>Provider:</strong> Doug</p>
        <p><strong>Description:</strong> Reusable login control that validates credentials against Member.xml using hashed passwords.</p>
        <p><strong>Features:</strong></p>
        <ul>
            <li>Username and password validation</li>
            <li>Password hashing verification using Assignment5_Library</li>
            <li>Session management</li>
            <li>Forms authentication integration</li>
            <li>Customizable title and button text</li>
            <li>Event-driven architecture (LoginSuccessful event)</li>
        </ul>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h3>Test the Login Control</h3>
            <p>Use the login control below to authenticate. Test credentials can be created on the Member page.</p>

            <!-- Include the LoginControl user control -->
            <uc:LoginControl ID="LoginControl1" runat="server" />

            <div class="alert alert-warning mt-3">
                <strong>Note:</strong> Make sure you have created a user account first using the Member page's "Create Account" feature.
           
            </div>
        </div>

        <div class="col-md-6">
            <h3>Login Status Information</h3>
            <div class="card">
                <div class="card-body">
                    <h5>Current Session Information:</h5>
                    <asp:Label ID="lblSessionInfo" runat="server" Text="Not logged in"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnCheckSession" runat="server" Text="Check Session Status" OnClick="btnCheckSession_Click" CssClass="btn btn-info" />
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-secondary" />
                </div>
            </div>
        </div>
    </div>

    <div class="row mt-4">
        <div class="col-md-12">
            <h3>Component Details</h3>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>Property</th>
                        <th>Value</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><strong>Component Name</strong></td>
                        <td>LoginControl</td>
                    </tr>
                    <tr>
                        <td><strong>File Type</strong></td>
                        <td>User Control (.ascx)</td>
                    </tr>
                    <tr>
                        <td><strong>Location</strong></td>
                        <td>~/UserControls/LoginControl.ascx</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <style>
        .card {
            border: 1px solid #ddd;
            border-radius: 5px;
            padding: 15px;
        }

        .card-body {
            padding: 10px;
        }

        .alert {
            padding: 15px;
            margin-bottom: 20px;
            border: 1px solid transparent;
            border-radius: 4px;
        }

        .alert-info {
            background-color: #d9edf7;
            border-color: #bce8f1;
            color: #31708f;
        }

        .alert-warning {
            background-color: #fcf8e3;
            border-color: #faebcc;
            color: #8a6d3b;
        }

        .mt-3 {
            margin-top: 1rem;
        }

        .mt-4 {
            margin-top: 1.5rem;
        }

        .mb-2 {
            margin-bottom: 0.5rem;
        }
    </style>
</asp:Content>
