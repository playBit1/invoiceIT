<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addClient.aspx.cs" Inherits="invoiceIT.Forms.ManageClient.addClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Client</title>
    <link rel = "stylesheet" href = "/style.css" />
</head>
<body>
    <form id="addClient" runat="server">
        <h2>Add Client Details</h2>
        <div class="frm_row_cont">
            <asp:Label ID="LblCompName" runat="server" class="frmlabel" Text="Company Name"></asp:Label><br />
            <asp:TextBox ID="CtrlCompName" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revCompName" 
                ControlToValidate="CtrlCompName"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
         <div class="frm_row_cont">
             <asp:Label ID="LblCompAdd1" runat="server" class="frmlabel" Text="Company Address 1"></asp:Label><br />
             <asp:TextBox ID="CtrlCompAdd1" runat="server" class="tbinput" TextMode="MultiLine" Height="50px"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revCompAdd1"
                ControlToValidate="CtrlCompAdd1"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblCompAdd2" runat="server" class="frmlabel" Text="Company Address 2"></asp:Label><br />
            <asp:TextBox ID="CtrlCompAdd2" runat="server" class="tbinput" TextMode="MultiLine" Height="50px"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revCompAdd2"
                ControlToValidate="CtrlCompAdd2"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblCompLocation" runat="server" class="frmlabel" Text="Company Location"></asp:Label><br />
            <asp:TextBox ID="CtrlCompLocation" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revCompLocation"
                ControlToValidate="CtrlCompLocation"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblCompPcode" runat="server" class="frmlabel" Text="Company Postal Code"></asp:Label><br />
            <asp:TextBox ID="CtrlCompPcode" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revCompPcode" 
                ControlToValidate="CtrlCompPcode"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblContactFname" runat="server" class="frmlabel" Text="Contact First Name"></asp:Label><br />
            <asp:TextBox ID="CtrlContactFname" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revContactFname" 
                ControlToValidate="CtrlContactFname"
                ForeColor="Red"
                Display="static"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblContactLname" runat="server" class="frmlabel" Text="Contact Last Name"></asp:Label><br />
            <asp:TextBox ID="CtrlContactLname" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revContactLname" 
                ControlToValidate="CtrlContactLname"
                ForeColor="Red"
                Display="static"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblContactEmail" runat="server" class="frmlabel" Text="Contact Email"></asp:Label><br />
            <asp:TextBox ID="CtrlContactEmail" runat="server" class="tbinput" type="email"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revContactEmail" 
                ControlToValidate="CtrlContactEmail"
                ForeColor="Red"
                Display="static"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblContactMobile" runat="server" class="frmlabel" Text="Contact Mobile"></asp:Label><br />
            <asp:TextBox ID="CtrlContactMobile" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revContactMobile" 
                ControlToValidate="CtrlContactMobile"
                ForeColor="Red"
                Display="static"
                runat="server" 
                ErrorMessage="Required!">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblBillTo" runat="server" class="frmlabel" Text="Bill To"></asp:Label><br />
            <asp:DropDownList ID="DropBillTo" runat="server">
                <asp:ListItem>Company</asp:ListItem>
                <asp:ListItem>Client</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblStatus" runat="server" class="frmlabel" Text="Status"></asp:Label><br />
            <asp:DropDownList ID="DropStatus" runat="server">
                <asp:ListItem>Good</asp:ListItem>
                <asp:ListItem>In Arrears</asp:ListItem>
                <asp:ListItem>Discontinued</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnAddNewClient" runat="server" class="button" Text="Add New Client" OnClick="BtnAddNewClient_Click" />
        </div>
    </form>
</body>
</html>
