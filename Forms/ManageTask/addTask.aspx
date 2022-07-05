<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addTask.aspx.cs" Inherits="invoiceIT.Forms.ManageTask.addTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Task</title>
    <link rel = "stylesheet" href = "/style.css" />
</head>
<body>
    <form id="addTask" runat="server">
        <h2>Add Task Details</h2>
        <div class="frm_row_cont">
            <asp:Label ID="LblTaskTitle" runat="server" class="frmlabel" Text="Task Title"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskTitle" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revTaskTitle" 
                ControlToValidate="CtrlTaskTitle"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
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
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnAddNewTask" runat="server" class="button" Text="Add New Task" OnClick="BtnAddNewTask_Click"/>
        </div>
    </form>
</body>
</html>
