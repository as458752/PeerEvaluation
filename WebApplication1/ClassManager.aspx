<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassManager.aspx.cs" Inherits="PeerEvaluation.ClassManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" style="text-align: center" Text="Class Manager"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label ID="Label2" runat="server" Text="Create new class"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label3" runat="server" Text="Name:"></asp:Label>
                    <asp:TextBox ID="txtClassName" Width="400px" runat="server"></asp:TextBox>
                    <asp:Button ID="btnCreateClass" runat="server" Text="Create" OnClick="btnCreateClass_Click" />
                </td>
            </tr>
            <tr>
                <td>Class list</td>
                <td>Class forms</td>
            </tr>
            <tr>             
                <td><asp:ListBox ID="lstClasses" Rows="20" width="100%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstClasses_SelectedIndexChanged"></asp:ListBox></td>
                <td><asp:ListBox ID="lstClassForms" Rows="20" width="100%" runat="server"></asp:ListBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload information" />
                    <asp:Button ID="btnDeleteClass" runat="server" Text="Delete Class" Enabled="False" OnClick="btnDeleteClass_Click" />
                    
                </td>
                <td>
                    <asp:DropDownList ID="drpFormsList" runat="server" Width="200px">
                    </asp:DropDownList>
                    <asp:Button ID="btnAddFormToClass" runat="server" Text="Add Form" OnClick="btnAddFormToClass_Click" style="height: 26px" />
                    <asp:Button ID="btnViewResults" runat="server" Text="View Results" />
                    <asp:Button ID="btnDeleteForm" runat="server" Text="Delete Form" />
                </td>
            </tr>
        </table>

        To create a new form, click <a href="FormCreation.aspx">here</a>.
    </form>
</body>
</html>
