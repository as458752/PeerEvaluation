<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormCreation.aspx.cs" Inherits="PeerEvaluation.FormCreation" %>

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
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="2" style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" style="text-align: center" Text="Team Peer Evaluation Form Creation"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="2">&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Evaluation Form Name:"></asp:Label>
&nbsp;<asp:TextBox ID="txtName" runat="server" Width="416px" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;&nbsp;
                    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="350px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="663px"></asp:ListBox>
                </td>
                <td style="text-align: center">
                    <asp:Label ID="Label3" runat="server" Text="Question Type: "></asp:Label>
                    <asp:RadioButtonList ID="rblType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblType_SelectedIndexChanged" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Multiple Choice</asp:ListItem>
                        <asp:ListItem>Short Answers</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Question Description:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtDescription" runat="server" Width="508px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblChoices" runat="server" Text="Choices:"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblChoice1" runat="server" Text="Grade Point: 1"></asp:Label>
&nbsp;<asp:TextBox ID="txtChoice1" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblChoice2" runat="server" Text="Grade Point: 2"></asp:Label>
&nbsp;<asp:TextBox ID="txtChoice2" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblChoice3" runat="server" Text="Grade Point: 3"></asp:Label>
&nbsp;<asp:TextBox ID="txtChoice3" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblChoice4" runat="server" Text="Grade Point: 4"></asp:Label>
&nbsp;<asp:TextBox ID="txtChoice4" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblChoice5" runat="server" Text="Grade Point: 5"></asp:Label>
&nbsp;<asp:TextBox ID="txtChoice5" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td style="text-align: center">
                    <asp:Button ID="btnAdd" runat="server" Height="29px" OnClick="btnAdd_Click" Text="Add Question" Width="122px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnModify" runat="server" Height="30px" OnClick="btnModify_Click" Text="Modify Question" Width="143px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="2">
                    <asp:Button ID="btnPublish" runat="server" Height="42px" OnClick="btnPublish_Click" Text="Publish" Width="82px" />
                </td>
            </tr>
        </table>
</body>
</html>
         </asp:Content>