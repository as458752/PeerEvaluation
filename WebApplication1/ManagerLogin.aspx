<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagerLogin.aspx.cs" Inherits="PeerEvaluation.ManagerLogin1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            left: 50%;
            margin-left: -200px;
            position: absolute;
            top: 128px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Manager Login Page"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1" HorizontalAlign="Center" Width="400px" BackColor="#CCFFFF">
        <br />
        <asp:Label ID="Label2" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter Username!" ForeColor="Red" ValidationGroup="ManagerLoginGroup"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter Password!" ForeColor="Red" ValidationGroup="ManagerLoginGroup"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" Font-Size="Large" OnClick="btnLogin_Click" Text="Login" ValidationGroup="ManagerLoginGroup" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error Message" Visible="False"></asp:Label>
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
</asp:Content>
