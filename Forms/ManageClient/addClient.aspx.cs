using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;
using System.Collections.Specialized;

namespace invoiceIT.Forms.ManageClient
{
    public partial class addClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddNewClient_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                NameValueCollection NewClientData = Request.Form;
                Client NewClient = new Client();
                String Result = NewClient.AddClient(NewClientData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);
            }
        }
    }
}