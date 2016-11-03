<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClassManager.aspx.cs" Inherits="PeerEvaluation.ClassManager" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 99%;
            height: 572px;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style3 {
            width: 628px;
        }
        .auto-style4 {
            width: 628px;
            height: 316px;
        }
        .auto-style5 {
            height: 316px;
        }
        </style>
</head>
<body>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="2" style="text-align: center">
                    &nbsp;
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" style="text-align: center" Text="Class Manager"></asp:Label>
                    <br />
                </td>
            </tr>
            <%--            <tr>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>--%>
            <tr>
                <td class="auto-style3"><strong>Class List</strong></td>
                <td><strong>Class Forms</strong></td>
            </tr>
            <tr>             
                <td class="auto-style4"><asp:ListBox ID="lstClasses" Rows="20" width="495px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstClasses_SelectedIndexChanged" Height="312px"></asp:ListBox></td>
                <td class="auto-style5"><asp:ListBox ID="lstClassForms" Rows="20" width="495px" runat="server" Height="312px"></asp:ListBox></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <strong>Create a new class<br />
                    </strong><br />
                    <asp:Label ID="Label5" runat="server" Text="Name:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtClassName" Width="400px" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnCreateClass" runat="server" Text="Create" OnClick="btnCreateClass_Click" />
                    <br />
                    <br />
                    <asp:FileUpload ID="fupStudentInfo" runat="server" Height="26px" Width="252px" />
                    &nbsp;
                    <asp:Button ID="btnUpload" runat="server" Text="Upload information" OnClick="btnUpload_Click" Enabled="False" Width="120px" />
                    &nbsp;
                    <asp:Button ID="btnDeleteClass" runat="server" Text="Delete Class" Enabled="False" OnClick="btnDeleteClass_Click" Width="120px" />
                    
                    <asp:Label ID="lblCreateClassMessage" runat="server" ForeColor="Red"></asp:Label>
                    &nbsp;
                    
                </td>
                <td>
                    <strong>Create a new Evaluation Form:&nbsp;
                    </strong>
                    <asp:Button ID="clickHere" runat="server" OnClick="clickHere_Click" Text="Click Here" />
                    <br />
                    <br />
                    <asp:DropDownList ID="drpFormsList" runat="server" Width="200px">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="btnAddFormToClass" runat="server" Text="Add Form" OnClick="btnAddFormToClass_Click" Width="100px" />
                    &nbsp;
                    <asp:Button ID="btnDeleteForm" runat="server" Text="Remove Form" OnClick="btnRemoveForm_Click" Width="100px" />
                    <br />
                    <br />
                    <asp:Button ID="btnViewResults" runat="server" OnClick="btnViewResults_Click1" Text="View Evaluation Results" />
                    <br />
                    <asp:Label ID="lblFormsMessage" runat="server" ForeColor="Red" Text="[lblFormsMessage]" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>

</body>
</html>
                    </asp:Content>