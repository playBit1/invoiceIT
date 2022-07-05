<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateTask.aspx.cs" Inherits="invoiceIT.Forms.ManageTask.updateTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Task Details</title>
    <link rel = "stylesheet" href = "/style.css" />
</head>
<body>
    <div id="frmcont" runat="server">
    <div id="updatecrsheader" runat="server"></div>
    <form id="updateTask" runat="server">
        <asp:HiddenField ID="CtrlTaskID" runat="server" Value=""></asp:HiddenField>
        <div class="frm_row_cont">
            <asp:Label ID="LblTaskTitle" runat="server" class="frmlabel" Text="Task Title"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskTitle" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revTaskTitle" 
                ControlToValidate="CtrlTaskTitle"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Task Title Required">
            </asp:RequiredFieldValidator>
        </div>
         <div class="frm_row_cont">
             <asp:Label ID="LblTaskDesc" runat="server" class="frmlabel" Text="Task Description"></asp:Label><br />
             <asp:TextBox ID="CtrlTaskDesc" runat="server" class="tbinput" TextMode="MultiLine" Height="50px"></asp:TextBox>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblTaskRate" runat="server" class="frmlabel" Text="Task Rate"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskRate" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revTaskRate"
                ControlToValidate="CtrlTaskRate"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Task Rate Required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateTask" runat="server" class="button" Text="Update Task" OnClick="BtnUpdateTask_Click"/>
        </div>
    </form>
    </div>
</body>
</html>
