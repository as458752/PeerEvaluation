<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormFiller.aspx.cs" Inherits="PeerEvaluation.FormFiller" %>

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
                <td class="auto-style2" style="text-align: center">
                    <asp:Label ID="lblFormName" runat="server" Font-Size="XX-Large" style="text-align: center"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFormFillerMsg" runat="server"></asp:Label>
                </td> 
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="drpPeers" runat="server" Height="25px" Width="318px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><asp:Panel ID="panelFormQuestions" runat="server">
                    </asp:Panel></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
            </table>
    </form>
</body>
</html>
