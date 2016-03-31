<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="PeerEvaluation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Manager Page"></asp:Label>
        <br />
        </div>
        <p>
            &nbsp;</p>
        <asp:Panel ID="Panel2" runat="server" Height="232px" HorizontalAlign="Center" style="margin-left: 300px" Width="585px">
            <asp:Label ID="Label3" runat="server" Text="Professor Name"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="ASU ID"></asp:Label>
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="135px"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
        </asp:Panel>
        <p>
        </p>
        <asp:Panel ID="Panel1" runat="server" Height="139px" HorizontalAlign="Center" style="margin-left: 300px" Width="585px">
            <br />
            <asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <br />
            ASU ID:
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" Width="56px" />
        </asp:Panel>
        <br />
        <hr />
        <br />
        <asp:Panel ID="Panel3" runat="server" Height="182px" HorizontalAlign="Center" style="margin-left: 300px" Width="585px">
            <br />
            <asp:Label ID="Label6" runat="server" Text="Old Password:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPasswordOld" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            New Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPasswordNew" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            Confirm Password:
            <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change Password" />
            <br />
            <br />
            <asp:Label ID="lblResult" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
