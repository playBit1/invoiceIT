<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateInvoice.aspx.cs" Inherits="invoiceIT.Forms.ManageInvoice.updateInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Invoice</title>
</head>
<body>
    <div id="frmcont" runat="server">
    <div id="updatecrsheader" runat="server"></div>
    <form id="updateInvoice" runat="server">
        <asp:HiddenField ID="CtrlInvoiceID" runat="server" Value=""></asp:HiddenField>
        <asp:HiddenField ID="CtrlGenDate" runat="server" Value=""></asp:HiddenField>
        <asp:HiddenField ID="CtrlSentDate" runat="server" Value=""></asp:HiddenField>
        <div class="frm_row_cont">
            <asp:Literal ID="WorkListPH" runat="server"></asp:Literal>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblDueDate" runat="server" class="frmlabel" Text="Payment Due Date"></asp:Label><br />
            <input type="text" class = "datepick" id="CtrlDueDate" name="CtrlDueDate" runat="server"/>
            <asp:RequiredFieldValidator 
                ID="RevDueDate"
                EnableClientScript="false"
                ControlToValidate="CtrlDueDate"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Please Enter Payment Due Date">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblStatus" runat="server" class="frmlabel" Text="Status"></asp:Label><br />
            <asp:DropDownList ID="DropStatus" runat="server" class='dllist'>
                <asp:ListItem>Generated</asp:ListItem>
                <asp:ListItem>Sent</asp:ListItem>
                <asp:ListItem>Overdue</asp:ListItem>
                <asp:ListItem>Paid</asp:ListItem>
                <asp:ListItem>Withdrawn</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator 
                ID="RevStatus"
                EnableClientScript="false"
                ControlToValidate="DropStatus"
                InitialValue="--Please make a selection--"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Please Select A Status">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateInvoice" runat="server" class="button" Text="Update Invoice" OnClick="BtnUpdateInvoice_Click"/>
        </div>
    </form>
    </div>
</body>
</html>
