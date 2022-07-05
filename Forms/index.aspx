<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="invoiceIT.Forms.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="TtlIndex"></title> 
    <link rel = "stylesheet" href = "/style.css" />
</head>
<body>
    <h1>Select a service!</h1>
    <h5>Select a service from drop box and press its corresponsing button</h5>
    <a href="logout.aspx">Logout</a>
    <form id="index" runat="server">

        <div class="frm_row_cont">
            <asp:Label ID="LblManageWork" runat="server" class="frmlabel" Text="Manage Work"></asp:Label><br />
            <asp:DropDownList ID="DropManageWork" runat="server" class="tbinput">
            <asp:ListItem>View Work Item List</asp:ListItem>
            <asp:ListItem>Add Work Item</asp:ListItem>
            <asp:ListItem>Update Work Item</asp:ListItem>
            <asp:ListItem>Delete Work Item</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnManageWork" runat="server" Text="Manage Work Items" OnClick="BtnManageWork_Click" class="button" />

        </div>
        <div id ="adminOnly" runat="server">
        <div class="frm_row_cont">
            <asp:Label ID="LblManageClient" runat="server" class="frmlabel" Text="Manage Client"></asp:Label><br />
            <asp:DropDownList ID="DropManageClient" runat="server" class="tbinput">
            <asp:ListItem>View Client List</asp:ListItem>
            <asp:ListItem>Add Client</asp:ListItem>
            <asp:ListItem>Update Client</asp:ListItem>
            <asp:ListItem>Delete Client</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnManageClient" runat="server" Text="Manage Clients" OnClick="BtnManageClient_Click" class="button" />
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblManageStaff" runat="server" class="frmlabel" Text="Manage Staff"></asp:Label><br />
            <asp:DropDownList ID="DropManageStaff" runat="server" class="tbinput">
            <asp:ListItem>View Staff List</asp:ListItem>
            <asp:ListItem>Add Staff</asp:ListItem>
            <asp:ListItem>Update Staff</asp:ListItem>
            <asp:ListItem>Delete Staff</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnManageStaff" runat="server" Text="Manage Staff" OnClick="BtnManageStaff_Click" class="button" />
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblManageInvoice" runat="server" class="frmlabel" Text="Manage Invoice"></asp:Label><br />
            <asp:DropDownList ID="DropManageInvoice" runat="server" class="tbinput">
            <asp:ListItem>Genarate Invoice</asp:ListItem>
            <asp:ListItem>View Invoice List</asp:ListItem>
            <asp:ListItem>Update Invoice</asp:ListItem>
            <asp:ListItem>Delete Invoice</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnManageInvoice" runat="server" Text="Manage Invoice" OnClick="BtnManageInvoice_Click" class="button" />
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblManageTask" runat="server" class="frmlabel" Text="Manage Task"></asp:Label><br />
            <asp:DropDownList ID="DropManageTask" runat="server" class="tbinput">
            <asp:ListItem>View Task List</asp:ListItem>
            <asp:ListItem>Add Task</asp:ListItem>
            <asp:ListItem>Update Task</asp:ListItem>
            <asp:ListItem>Delete Task</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="BtnManageTask" runat="server" Text="Manage Task" OnClick="BtnManageTask_Click" class="button" />
        </div>
        </div>
    </form>
</body>
</html>
