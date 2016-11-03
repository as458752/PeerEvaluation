<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="PeerEvaluation.StudentPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1124px;
            table-layout: fixed
        }
        .auto-style2 {
            height: 20px;
        }
        </style>
</head>
<body>
        <table class="auto-style1" style="height: 457px">
            <tr>
                <td class="auto-style2" colspan="2" style="text-align: center">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" style="text-align: center" Text="Evaluation Form Selection Page"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td><strong>Enrolled classes for Evaluation (choose one):</strong></td>
                <td><strong>Evaluation forms for selected class (choose one):</strong></td>
            </tr>
            <tr>             
                <td><asp:ListBox ID="lstClasses" Rows="20" width="65%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstClasses_SelectedIndexChanged" Height="258px" style="text-align: center"></asp:ListBox></td>
                <td><asp:ListBox ID="lstClassForms" Rows="20" width="63%" runat="server" OnSelectedIndexChanged="lstClassForms_SelectedIndexChanged" Height="248px"></asp:ListBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Button ID="btnFillForm" runat="server" Text="Fill Form" OnClick="btnFillForm_Click" />
                </td>
            </tr>
            
        </table>        
   
</body>
</html>
      </asp:Content>