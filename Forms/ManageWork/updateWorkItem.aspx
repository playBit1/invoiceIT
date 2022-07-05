<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateWorkItem.aspx.cs" Inherits="invoiceIT.Forms.ManageWork.updateWorkItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Work Item</title> 
    <link rel = "stylesheet" href = "/style.css" />
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
</head>
<body>
    <div id="frmcont" runat="server">
    <div id="updatecrsheader" runat="server"></div>
    <form id="updateWorkItem" runat="server" autocomplete="off">
        <h2>Add Work Item Details</h2>
        <asp:HiddenField ID="CtrlWorkID" runat="server" Value=""></asp:HiddenField>
        <div class="frm_row_cont">
            <asp:Label ID="LblClientName" runat="server" class="frmlabel" Text="Client Company Name"></asp:Label><br />
            <asp:HiddenField ID="CtrlClientID" runat="server" Value=""></asp:HiddenField>
            <asp:TextBox ID="CtrlClientName" class="tbinput" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="frm_row_cont">
            <asp:Literal ID="StaffListPH" runat="server"></asp:Literal>
        </div>
        <div class="frm_row_cont">
            <asp:Literal ID="TaskListPH" runat="server"></asp:Literal>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblStartDate" runat="server" class="frmlabel" Text="Start Date"></asp:Label><br />
            <input type="text" class = "datepick" id="CtrlStartDate" name="CtrlStartDate" runat="server"/>
            <asp:RequiredFieldValidator 
                ID="revStartDate"
                EnableClientScript="false"
                ControlToValidate="CtrlStartDate"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Please Enter Start Date">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblStartTime" runat="server" class="frmlabel" Text="Start Time"></asp:Label><br />
            <asp:TextBox ID="CtrlStartTime" type="time" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RevStartTime"
                EnableClientScript="false"
                ControlToValidate="CtrlStartTime"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Please Enter Start Time">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblCompletedDate" runat="server" class="frmlabel" Text="Completion Date"></asp:Label><br />
            <input type="text" class = "datepick" id="CtrlCompletedDate" name="CtrlCompletedDate" runat="server"/>
            <asp:RequiredFieldValidator 
                ID="RevCompletedDate"
                EnableClientScript="false"
                ControlToValidate="CtrlCompletedDate"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Please Enter Completion Date">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblEndTime" runat="server" class="frmlabel" Text="End Time"></asp:Label><br />
            <asp:TextBox ID="CtrlEndTime" type="time" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RevEndTime"
                EnableClientScript="false"
                ControlToValidate="CtrlEndTime"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Please Enter Completion Time">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblStatus" runat="server" class="frmlabel" Text="Status"></asp:Label><br />
            <asp:Literal ID="StatusPH" runat="server"></asp:Literal>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblComment" runat="server" class="frmlabel" Text="Comment"></asp:Label><br />
            <asp:TextBox ID="CtrlComment" runat="server" class="tbinput"></asp:TextBox>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateWorkItem" runat="server" class="button" Text="Update Work Item" OnClick="BtnUpdateWorkItem_Click"/>
        </div>
    </form>
    </div>
</body>
</html>
