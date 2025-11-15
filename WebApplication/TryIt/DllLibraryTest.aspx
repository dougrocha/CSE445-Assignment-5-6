<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DllLibraryTest.aspx.cs" Inherits="WebApplication.TryIt.DllLibraryTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Assignment5_Library DLL Test Page</h1>
        <p>Test Encryption, Decryption, and Hashing Service</p>
    </div>

    <div>
        <h2>Test Instructions</h2>
        <p>Creator: Douglas Rocha</p>
        <p>Test Steps:</p>
        <ol>
            <li>Test Encryption with sample text</li>
            <li>Copy Encrypted output and test decryption</li>
            <li>Test hashing with a password</li>
            <li>Test hash verification with correct and wrong outputs</li>
        </ol>
    </div>

    <div>
        <h2>Encryption Test</h2>
        <asp:TextBox ID="txtEncryptInput" runat="server" Width="400px" TextMode="MultiLine" Rows="4" Placeholder="Enter text to encrypt"></asp:TextBox><br />
        <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" OnClick="btnEncrypt_Click" /><br />
        <asp:TextBox ID="txtEncryptOutput" runat="server" Width="400px" TextMode="MultiLine" Rows="4" ReadOnly="true" Placeholder="Encrypted output will appear here"></asp:TextBox>
    </div>

    <div>
        <h2>Decryption Test</h2>
        <asp:TextBox ID="txtDecryptInput" runat="server" Width="400px" TextMode="MultiLine" Rows="4" Placeholder="Enter text to decrypt"></asp:TextBox><br />
        <asp:Button ID="btnDecrypt" runat="server" Text="Decrypt" OnClick="btnDecrypt_Click" /><br />
        <asp:TextBox ID="txtDecryptOutput" runat="server" Width="400px" TextMode="MultiLine" Rows="4" ReadOnly="true" Placeholder="Decrypted output will appear here"></asp:TextBox>
    </div>

    <div>
        <h2>Hashing Test</h2>
        <asp:TextBox ID="txtHashInput" runat="server" Width="400px" TextMode="SingleLine" Placeholder="Enter password to hash"></asp:TextBox><br />
        <asp:Button ID="btnHash" runat="server" Text="Hash Password" OnClick="btnHash_Click" /><br />
        <asp:TextBox ID="txtHashOutput" runat="server" Width="400px" TextMode="MultiLine" Rows="4" ReadOnly="true" Placeholder="Hashed output will appear here"></asp:TextBox>
    </div>
</asp:Content>
