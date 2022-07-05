using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace invoiceIT.Forms
{
    public partial class logOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Write("<h2>Log Out Successfull!</h2>");
            Response.Write("<a href='/Forms/login.aspx'>Return To Login</a>");
        }
    }
}