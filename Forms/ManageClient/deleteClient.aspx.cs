using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageClient
{
    public partial class deleteClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_ID))
            {
                Client client = new Client();
                string result = client.DeleteClient(Client_ID);

                if (result == "Query Successful!")
                {
                    Response.Write("<span class='success'>Client record deleted successfully.</span><br />");
                    Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                }
                else
                {
                    Response.Write("<span class='error'>Delete failed; Client details have not been removed.</span><br />");
                    Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }
    }
}