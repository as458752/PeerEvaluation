<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordPage.aspx.cs" Inherits="PeerEvaluation.ResetPasswordPage" %>

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
            width: 359px;
            height: 25px;
            text-align: right;
        }
        .auto-style7 {
            height: 25px;
            width: 135px;
        }
        .auto-style5 {
            height: 25px;
        }
        .auto-style6 {
            width: 359px;
            text-align: right;
        }
        .auto-style8 {
            width: 135px;
        }
        .auto-style3 {
            width: 359px;
        }
        .auto-style9 {
            width: 359px;
            text-align: right;
            height: 20px;
        }
        .auto-style10 {
            width: 135px;
            height: 20px;
        }
        .auto-style11 {
            height: 20px;
        }
        </style>
</head>
<body>
        <div>
        </div>
        <div class="auto-style1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password Reset</div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style4">New Password</td>
                <td class="auto-style7">
                    <asp:TextBox ID="newPass" runat="server" Width="148px"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">Confirm Password</td>
                <td class="auto-style8">
                    <asp:TextBox ID="confirmPass" runat="server" Width="148px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="confirmButton" runat="server" OnClick="confirmButton_Click" Text="Reset" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11"></td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
</body>
</html>
      </asp:Content>