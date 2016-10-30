<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="PeerEvaluation.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 431px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Manager Page"></asp:Label>
        <br />
    </div>
    <asp:SqlDataSource ID="SqlDataSourceProfessor" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" SelectCommand="SELECT [ASU ID] AS ASU_ID, [FullName] FROM [Account] WHERE ([UserType] = @UserType)" DeleteCommand="DELETE FROM [Account] WHERE [ASU ID] = @ASU_ID" InsertCommand="INSERT INTO [Account] ([ASU ID], [FullName]) VALUES (@ASU_ID, @FullName)" UpdateCommand="UPDATE [Account] SET [FullName] = @FullName WHERE [ASU ID] = @ASU_ID">
        <DeleteParameters>
            <asp:Parameter Name="ASU_ID" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ASU_ID" Type="String" />
            <asp:Parameter Name="FullName" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="UserType" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="FullName" Type="String" />
            <asp:Parameter Name="ASU_ID" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ASU_ID" DataSourceID="SqlDataSourceProfessor" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ASU_ID" HeaderText="ASU_ID" ReadOnly="True" SortExpression="ASU_ID" />
                        <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Height="139px" HorizontalAlign="Center" Style="margin-left: 300px" Width="585px">
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
    <asp:Panel ID="Panel3" runat="server" Height="182px" HorizontalAlign="Center" Style="margin-left: 300px" Width="585px">
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

</asp:Content>
