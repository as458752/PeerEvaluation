<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PeerEvaluation.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            left:50%;
            margin-left:-200px;
            position:absolute;
            top: 128px;
        }
        .auto-style2 {
            left:50%;
            margin-left:-200px;
            position:absolute;
            top: 328px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Login Page"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1" HorizontalAlign="Center" Width="400px" BackColor="#CCFFFF" DefaultButton="btnLogin">
        <br />
        <asp:Label ID="Label4" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="Please enter Username" ForeColor="Red" ValidationGroup="LoginGroup"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Please enter Password" ForeColor="Red" ValidationGroup="LoginGroup"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" Font-Size="Large" Text="Login" ValidationGroup="LoginGroup" OnClick="btnLogin_Click" />
        <br />
        <br />
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text="Error Message" Visible="False"></asp:Label>
        <br />
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server" CssClass="auto-style2" HorizontalAlign="Center" Width="400px" BackColor="#CCFFFF">
    <br />
        <asp:Label ID="Label6" runat="server" Text="Do not have an account?"></asp:Label>
        <br />
        <asp:Button ID="ButtonRegister" runat="server" OnClick="ButtonRegister_Click" Text="Register" />
    <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Forgot your password?"></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Enter your Email address"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSendEmail" runat="server" OnClick="btnSendEmail_Click" Text="Send Password Reset Link" ValidationGroup="resetGroup" />
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email address is required!" ForeColor="Red" ValidationGroup="resetGroup"></asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email address is invalid!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="resetGroup"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="msgLabel" runat="server" ForeColor="Red" Text="Error Message" Visible="False"></asp:Label>
    <br />
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
<br />
<br />
<br />
<br />
    <br />
    <br />
    <br />
</asp:Content>
