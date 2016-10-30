<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EvaluationResult.aspx.cs" Inherits="PeerEvaluation.EvaluationResult" %>


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
                    <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" style="text-align: center" Text="Evaluation Results"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td><strong>Class Name:</strong>
                    <asp:Label ID="lblClassName" runat="server"></asp:Label>
                    <br />
                    <strong>Form Name:</strong>
                    <asp:Label ID="lblFormName" runat="server"></asp:Label>
                    <br />
                    <strong>Evaluated Student:</strong>
                    <asp:Label ID="lblEvaluated" runat="server"></asp:Label>
                    <br />
                    <strong>Evaluator:</strong>
                    <asp:Label ID="lblEvaluator" runat="server"></asp:Label>
                    <br />
                    <br />
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