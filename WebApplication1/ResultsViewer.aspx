<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResultsViewer.aspx.cs" Inherits="PeerEvaluation.ResultsViewer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 20px;
        }
        </style>
</head>
<body>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="2" style="text-align: center">
                    <asp:Label ID="lblWelcome" runat="server" Text="Welcome"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" style="text-align: center" Text="Form Results"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblResultsMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="panelFormResults" runat="server">
                    </asp:Panel>

                </td>
            </tr>
            </table>
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return" />
    </body>
</html>
     </asp:Content>