<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateStaff.aspx.cs" Inherits="invoiceIT.Forms.ManageStaff.updateStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Staff</title>
    <link rel = "stylesheet" href = "/style.css" />
</head>
<body>
    <div id="frmcont" runat="server">
    <div id="updatecrsheader" runat="server"></div>
    <form id="form1" runat="server">
        <h2>Add Staff Details</h2>
        <asp:HiddenField ID="CtrlStaffID" runat="server" Value=""></asp:HiddenField>
        <div class="frm_row_cont">
            <asp:Label ID="LblFName" runat="server" class="frmlabel" Text="First Name"></asp:Label><br />
            <asp:TextBox ID="CtrlFName" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revFName" 
                ControlToValidate="CtrlFName"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
         <div class="frm_row_cont">
             <asp:Label ID="LblSurname" runat="server" class="frmlabel" Text="Surname"></asp:Label><br />
             <asp:TextBox ID="CtrlSurname" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revSurname"
                ControlToValidate="CtrlSurname"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblEmail" runat="server" class="frmlabel" Text="Email"></asp:Label><br />
            <asp:TextBox ID="CtrlEmail" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revEmail"
                ControlToValidate="CtrlEmail"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblPassword" runat="server" class="frmlabel" Text="Account Password"></asp:Label><br />
            <asp:TextBox ID="CtrlPassword" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revPassword"
                ControlToValidate="CtrlPassword"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblMobile" runat="server" class="frmlabel" Text="Mobile Number"></asp:Label><br />
            <asp:TextBox ID="CtrlMobile" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revMobile" 
                ControlToValidate="CtrlMobile"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblAccessLevel" runat="server" class="frmlabel" Text="Access Level"></asp:Label><br />
            <asp:Literal ID="AccessLevelPH" runat="server"></asp:Literal>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblStatus" runat="server" class="frmlabel" Text="Status"></asp:Label><br />
            <asp:Literal ID="StatusPH" runat="server"></asp:Literal>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateStaff" runat="server" class="button" Text="Update Staff" OnClick="BtnUpdateStaff_Click"/>
        </div>
    </form>
    </div>
</body>
</html>
