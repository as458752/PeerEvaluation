<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatabaseManager.aspx.cs" Inherits="PeerEvaluation.DatabaseManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" SelectCommand="SELECT * FROM [Account]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ASU ID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ASU ID" HeaderText="ASU ID" ReadOnly="True" SortExpression="ASU ID" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="UserType" HeaderText="UserType" SortExpression="UserType" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
    </body>
</html>
