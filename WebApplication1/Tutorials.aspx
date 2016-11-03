<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutorials.aspx.cs" Inherits="PeerEvaluation.Tutorials1" %>

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
        .auto-style4 {
        height: 55px;
    }
    .auto-style5 {
        text-align: left;
    }
    .auto-style6 {
        font-size: xx-large;
    }
    .auto-style7 {
        text-align: justify;
    }
        .auto-style8 {
            height: 43px;
            text-align: left;
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
                <td class="auto-style4" colspan="2" style="text-align: center">
                    <span class="auto-style6">Tutorials Page</span><br />
                </td>
            </tr>
            <tr>
                <td class="auto-style8"><strong>Students:</strong></td>
                <td class="auto-style8"><strong>Professors:</strong></td>
            </tr>
            <tr>             
                <td class="auto-style5">Step 1: Login
                    <br />
                    <br />
                    Step 2: Once logged in, the classes you are enrolled in will be availale on the left 
                    <br />
                    hand side of the Evaluation Forms Selection Page. Select any class.<br />
                    <br />
                    <asp:Image ID="Image1" runat="server" Height="281px" ImageUrl="~/images/enrolled.PNG" Width="416px" />
                    <br />
                    <br />
                    Step 3: After selecting the class, the available evaluation forms will be visible in the<br />
&nbsp;right box on the same page. Select any of the forms that you would like to 
                    <br />
                    evaluation and then click Fill Form to go to evaluation form.<br />
                    <br />
                    <asp:Image ID="Image2" runat="server" Height="281px" ImageUrl="~/images/evaluate.PNG" Width="416px" />
                    <br />
                    <br />
                    Step 4: Once you are at the evaluation form, the first student in the evaluation list<br />
&nbsp;for your group will be selected. Either you can evaluation this person or click on<br />
&nbsp;the drop down list to select another student.<br />
                    <br />
                    <asp:Image ID="Image3" runat="server" Height="88px" ImageUrl="~/images/peer1.PNG" Width="399px" />
                    <br />
                    <br />
                    Step 5: Repeat Steps 1-4 until all the group memers from each evaluation form 
                    <br />
                    has been evaluated.<br />
                </td>
                <td class="auto-style7" dir="ltr"><strong>Create a new Class:<br />
                    <br />
                    </strong>Professors can create new classes that they are teaching. To create a new class, enter the name of the class at bottom of the class list box. Then click on choose file button to add the information about student&#39;s group and then click on upload informatin button. Finally, click on create button to create the class. To delete any of the previous classes, just select the class and click delete class button.<br />
                    <br />
                    <asp:Image ID="Image4" runat="server" Height="294px" ImageUrl="~/images/createclass.PNG" Width="539px" />
                    <br />
                    <br />
                    <strong>Add a new form to the existing classes:<br />
                    <br />
                    </strong>To add a new form to the classes created, first select the class from the class list and then click on the &quot;select a form to add&quot; arrow below class forms box and then select the form. Click on Add Form button to add evaluation form to the class. To create a new form click on Click Here button, and then follow the same steps from the first line to add it to any of the classes. To remove the form, just select the class and then form and then click remove.<strong><br />
                    <br />
                    <asp:Image ID="Image5" runat="server" Height="315px" ImageUrl="~/images/createform.PNG" Width="539px" />
                    <br />
                    </strong>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <br />
                </td>
            </tr>
            
        </table>        
   
</body>
</html>
      </asp:Content>
