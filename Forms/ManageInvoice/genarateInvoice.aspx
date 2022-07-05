<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="genarateInvoice.aspx.cs" Inherits="invoiceIT.Forms.ManageInvoice.genarateInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Genarate Invoice</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css"/>
    <link rel="stylesheet" href="/resources/demos/style.css"/>
    <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
    <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.js"></script>
     <script>
         $(function () {
             $('.datepick').each(function () {
                 $(this).datepicker({
                     dateFormat: "dd/mm/yy",
                     inline: true,
                     showAnim: "fadeIn",
                     changeMonth: true,
                     changeYear: true,
                 });
             });
         });
     </script>
    <link rel = "stylesheet" href = "/style.css" />
</head>
<body>
    <form id="genarateInvoice" runat="server" autocomplete="off">
        <h2>Provide Invoice details</h2>
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
                <asp:ListItem>--Please make a selection--</asp:ListItem>
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
            <asp:Button ID="BtnGenerateInvoice" runat="server" class="button" Text="Generate Invoice" OnClick="BtnGenerateInvoice_Click"/>
        </div>
    </form>
</body>
</html>
