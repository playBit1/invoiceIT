<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addWorkItem.aspx.cs" Inherits="invoiceIT.Forms.ManageWork.addWorkItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>ADD Work Item</title> 
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
    <form id="addWorkItem" runat="server" autocomplete="off">
        <h2>Add Work Item Details</h2>
        <div class="frm_row_cont">
            <asp:Literal ID="ClientListPH" runat="server"></asp:Literal>
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
            <asp:Label ID="LblCompletedDate" runat="server" class="frmlabel" Text="End Date"></asp:Label><br />
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
            <asp:DropDownList ID="DropStatus" runat="server" class='dllist'>
                <asp:ListItem>--Please make a selection--</asp:ListItem>
                <asp:ListItem>Ongoing</asp:ListItem>
                <asp:ListItem>Paused</asp:ListItem>
                <asp:ListItem>Completed</asp:ListItem>
                <asp:ListItem>Discontinued</asp:ListItem>
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
            <asp:Label ID="LblComment" runat="server" class="frmlabel" Text="Comment"></asp:Label><br />
            <asp:TextBox ID="CtrlComment" runat="server" class="tbinput"></asp:TextBox>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnAddNewWorkItem" runat="server" class="button" Text="Add New Work Item" OnClick="BtnAddNewWorkItem_Click" />
        </div>
    </form>
</body>
</html>
