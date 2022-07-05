<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="invoiceIT.Forms.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
    <link rel = "stylesheet" href = "/style.css" />
</head>
<body>
    <h1>Login</h1>
    <form id="login" runat="server">
        <div class="frm_row_cont">
            <asp:Label ID="LblUserEmail" runat="server" Text="Email Address" class="frmlabel"></asp:Label><br />
            <asp:TextBox ID="CtrlUserEmail" runat="server" type="email" class="tbinput"></asp:TextBox><br />
            <asp:RequiredFieldValidator 
                ID="revEmail" 
                ControlToValidate="CtrlUserEmail"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Please Enter Email Address">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblUserPassword" runat="server" Text="Password" class="frmlabel"></asp:Label><br />
            <asp:TextBox ID="CtrlUserPassword" runat="server" TextMode = "Password" class="tbinput"></asp:TextBox><br />
            <asp:RequiredFieldValidator 
                ID="revUserPassword" 
                ControlToValidate="CtrlUserPassword"
                ForeColor="Red"
                runat="server" 
                ErrorMessage="Password Required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnLogin" class="button" runat="server" Text="Login" OnClick ="BtnLogin_Click" />
        </div>
    </form>
</body>
</html>
