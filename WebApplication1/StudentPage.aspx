<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="PeerEvaluation.StudentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1200px;
            table-layout: fixed
        }
        .auto-style2 {
            height: 20px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="2" style="text-align: center">
                    <asp:Label ID="lblWelcome" runat="server" Text="Welcome"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" style="text-align: center" Text="Evaluation Forms"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td>These are the classes you are currently enrrolled in.</td>
                <td>Select a class to list here its associated evaluation forms.</td>
            </tr>
            <tr>             
                <td><asp:ListBox ID="lstClasses" Rows="20" width="100%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstClasses_SelectedIndexChanged"></asp:ListBox></td>
                <td><asp:ListBox ID="lstClassForms" Rows="20" width="100%" runat="server" OnSelectedIndexChanged="lstClassForms_SelectedIndexChanged"></asp:ListBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnFillForm" runat="server" Text="Fill Form" OnClick="btnFillForm_Click" />
                </td>
            </tr>
            
        </table>        
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
    </form>
</body>
</html>
