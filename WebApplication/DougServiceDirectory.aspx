<%@ Page Title="Doug's Service Directory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DougServiceDirectory.aspx.cs" Inherits="WebApplication.DougServiceDirectory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Welcome Section -->
    <div class="jumbotron">
        <h1>Doug's Service Directory</h1>
        <p class="lead">Assignment 5 - Service-Oriented Web Application Components</p>
        <p><strong>Developer:</strong> Doug</p>
        <p><strong>Application:</strong> Member Management System with Authentication Services</p>
    </div>

    <!-- Application Overview -->
    <div class="section">
        <h2>Application Overview</h2>
        <p>This web application demonstrates service-oriented architecture with the following features:</p>
        <ul>
            <li>Secure member authentication with password hashing</li>
            <li>Reusable user controls for login functionality</li>
            <li>DLL library for cryptographic services</li>
            <li>Web services for distributed computing</li>
            <li>XML-based data persistence</li>
        </ul>
    </div>

    <!-- Service Directory -->
    <div class="section">
        <h2>Service Directory</h2>
        <p>All components developed by Doug for this application are listed below with their specifications and testing interfaces.</p>

        <div class="table-responsive">
            <table class="table table-bordered table-striped">
                <thead class="thead-dark">
                    <tr>
                        <th>Provider</th>
                        <th>Component Type</th>
                        <th>Component Name</th>
                        <th>Operations/Methods</th>
                        <th>Parameters</th>
                        <th>Return Type</th>
                        <th>Description</th>
                        <th>TryIt Link</th>
                    </tr>
                </thead>
                <tbody>
                    <!-- Component 1: DLL Library -->
                    <tr>
                        <td rowspan="4"><strong>Doug</strong></td>
                        <td rowspan="4">DLL Class Library</td>
                        <td rowspan="4">Assignment5_Library</td>
                        <td><code>EncryptString</code></td>
                        <td>string plainText, string key</td>
                        <td>string</td>
                        <td>Encrypts plaintext using AES encryption with provided key</td>
                        <td rowspan="4">
                            <asp:HyperLink ID="lnkDllTryIt" runat="server" NavigateUrl="~/TryIt/DllLibraryTest.aspx"
                                CssClass="btn btn-primary btn-sm">Test DLL</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td><code>DecryptString</code></td>
                        <td>string cipherText, string key</td>
                        <td>string</td>
                        <td>Decrypts ciphertext using AES decryption with provided key</td>
                    </tr>
                    <tr>
                        <td><code>ComputeHash</code></td>
                        <td>string input</td>
                        <td>string</td>
                        <td>Computes SHA256 hash of input string for password storage</td>
                    </tr>
                    <tr>
                        <td><code>VerifyHash</code></td>
                        <td>string input, string hash</td>
                        <td>bool</td>
                        <td>Verifies input matches stored hash (for password validation)</td>
                    </tr>

                    <!-- Component 2: User Control -->
                    <tr>
                        <td><strong>Doug</strong></td>
                        <td>User Control (.ascx)</td>
                        <td>LoginControl</td>
                        <td><code>Authenticate</code></td>
                        <td>string username, string password</td>
                        <td>Session/Cookie</td>
                        <td>Reusable login control with password hashing, session management, and Forms authentication. 
                            Validates credentials against Member.xml using HashingService.</td>
                        <td>
                            <asp:HyperLink ID="lnkLoginControlTryIt" runat="server" NavigateUrl="~/TryIt/TestLoginControl.aspx"
                                CssClass="btn btn-primary btn-sm">Test Login Control</asp:HyperLink>
                        </td>
                    </tr>

                    <!-- Component 3: Web Service -->
                    <tr>
                        <td rowspan="5"><strong>Doug</strong></td>
                        <td rowspan="5">ASMX Web Service</td>
                        <td rowspan="5">DougWebService</td>
                        <td><code>EncryptString</code></td>
                        <td>string input, string key</td>
                        <td>string</td>
                        <td>Web service endpoint for encryption operations</td>
                        <td rowspan="5">
                            <asp:HyperLink ID="lnkWebServiceTryIt" runat="server" NavigateUrl="~/TryIt/DougWebService.aspx"
                                CssClass="btn btn-primary btn-sm">Test Web Service</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td><code>DecryptString</code></td>
                        <td>string input, string key</td>
                        <td>string</td>
                        <td>Web service endpoint for decryption operations</td>
                    </tr>
                    <tr>
                        <td><code>HashString</code></td>
                        <td>string input</td>
                        <td>string</td>
                        <td>Web service endpoint for hashing operations</td>
                    </tr>
                    <tr>
                        <td><code>VerifyHash</code></td>
                        <td>string input, string hash</td>
                        <td>bool</td>
                        <td>Web service endpoint for hash verification</td>
                    </tr>
                    <tr>
                        <td><code>RandomNumberGenerator</code></td>
                        <td>int min, int max</td>
                        <td>int</td>
                        <td>Generates random number within specified range</td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="alert alert-info mt-3">
            <strong>Note:</strong> The DougWebService is deployed to WebStrar server. All services use the Assignment5_Library DLL 
            for core cryptographic functionality, ensuring consistency across components.
       
        </div>
    </div>

    <!-- Testing Instructions -->
    <div class="section">
        <h2>Testing Instructions</h2>
        <div class="card">
            <div class="card-body">
                <h5>How to Test Doug's Components:</h5>
                <ol>
                    <li><strong>Test DLL Library:</strong> Click "Test DLL" to try encryption, decryption, and hashing functions</li>
                    <li><strong>Test User Control:</strong> Click "Test Login Control" to see the reusable login component in action
                       
                        <ul>
                            <li>First, create a test account using the Member page</li>
                            <li>Then test login functionality with your credentials</li>
                        </ul>
                    </li>
                    <li><strong>Test Web Service:</strong> Click "Test Web Service" to access the ASMX service operations</li>
                    <li><strong>Member Page:</strong> Create accounts and test full authentication flow</li>
                    <li><strong>Staff Page:</strong> Access with credentials - Username: "TA", Password: "Cse445!"</li>
                </ol>

                <h5 class="mt-3">Test Credentials:</h5>
                <ul>
                    <li><strong>Staff Access:</strong> Username: <code>admin</code>, Password: <code>admin</code></li>
                    <li><strong>Member Access:</strong> Create your own account via the Member page</li>
                </ul>
            </div>
        </div>
    </div>

    <!-- Quick Access TryIt Pages -->
    <div class="section">
        <h2>Quick Access - TryIt Pages</h2>
        <div>
            <asp:Button ID="btnDllPage" runat="server" Text="DLL Library Test"
                OnClick="btnDllPage_Click" CssClass="btn btn-info" />
            <asp:Button ID="btnWebServicePage" runat="server" Text="Web Service Test"
                OnClick="btnWebServicePage_Click" CssClass="btn btn-info" />
            <asp:Button ID="btnLoginControlTest" runat="server" Text="Login Control Test"
                OnClick="btnLoginControlTest_Click" CssClass="btn btn-info" />
        </div>
    </div>
</asp:Content>
