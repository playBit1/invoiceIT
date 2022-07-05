<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addStaff.aspx.cs" Inherits="invoiceIT.Forms.ManageStaff.addStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Staff</title>
    <link rel = "stylesheet" href = "/style.css" />
</head>
<body>
    <form id="addStaff" runat="server">
        <h2>Add Staff Details</h2>
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
            <asp:DropDownList ID="DropAccessLevel" runat="server">
                <asp:ListItem>Staff</asp:ListItem>
                <asp:ListItem>Administrator</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblStatus" runat="server" class="frmlabel" Text="Status"></asp:Label><br />
            <asp:DropDownList ID="DropStatus" runat="server">
                <asp:ListItem>Active</asp:ListItem>
                <asp:ListItem>Inactive</asp:ListItem>
                <asp:ListItem>Terminated</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnAddNewStaff" runat="server" class="button" Text="Add New Staff" OnClick="BtnAddNewStaff_Click" />
        </div>
    </form>
</body>
</html>
