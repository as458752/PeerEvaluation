<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="PeerEvaluation.StudentLogin" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            text-align: left;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style4 {
            width: 505px;
            height: 25px;
            text-align: right;
        }
        .auto-style5 {
            height: 25px;
        }
        .auto-style6 {
        width: 505px;
        text-align: right;
    }
        .auto-style7 {
            height: 25px;
            width: 164px;
        }
        .auto-style8 {
            width: 164px;
            text-align: right;
        height: 26px;
    }
        .auto-style9 {
            width: 164px;
            text-align: left;
        }
    .auto-style10 {
        width: 505px;
        text-align: right;
        height: 32px;
    }
    .auto-style11 {
        width: 164px;
        text-align: left;
        height: 32px;
    }
    .auto-style12 {
        height: 32px;
    }
    .auto-style13 {
        width: 505px;
        text-align: right;
        height: 26px;
    }
    .auto-style14 {
        height: 26px;
    }
        .auto-style15 {
            width: 164px;
            text-align: center;
        }
    </style>
</head>
<body>
        <table class="auto-style2">
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style7">
                    Login Page</td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Username</td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBoxUserName" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserName" ErrorMessage="Please enter Username" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">Password</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
                <td class="auto-style14">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Please enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    &nbsp;<asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" Width="97px" />
                </td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style15">
                    <asp:Button ID="ButtonRegister" runat="server" CausesValidation="False" OnClick="ButtonRegister_Click" Text="Register" Width="97px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">Forgot password? Enter your email address</td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtEmail" runat="server" Width="177px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">
                    <asp:Button ID="Send" runat="server" CausesValidation="False" OnClick="SendEmail_Click" Text="Send Email" Width="97px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">
                    <asp:Label ID="msgLabel" runat="server" style="text-align: left"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
</body>
</html>
    </asp:Content>