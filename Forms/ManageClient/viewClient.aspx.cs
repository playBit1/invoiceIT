using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageClient
{
    public partial class viewClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_ID))
            {
                Client client = new Client();
                _ = new List<string>(12);
                List<string> ClientData = client.GetClient(Client_ID);
                bool isEmpty = AppUtilities.IsEmpty(ClientData);
                Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                Response.Write("<div><a href='viewClientList.aspx'>Back to List</a></div>");
                if (isEmpty)
                {
                    Response.Write("Error: No Client Details Found");
                }
                else
                {
                    Response.Write("<div class = 'clientdetails'> Client ID: <b>" + ClientData[0] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Company Name: <b>" + ClientData[1] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Company Address 1: <b>" + ClientData[2] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Company Address 2: <b>" + ClientData[3] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Company Location: <b>" + ClientData[4] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Company Postal Code: <b>" + ClientData[5] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Contact First Name: <b>" + ClientData[6] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Contact Last Name: <b>" + ClientData[7] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Contact Email: <b>" + ClientData[8] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Contact Mobile: <b>" + ClientData[9] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Bill To: <b>" + ClientData[10] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Status: <b>" + ClientData[11] + "</b></div> <br />");
                    Response.Write("<br />");
                    Response.Write("<div class = 'clientdetails'> <a href = 'updateClient.aspx?ID= " + ClientData[0] +
                    "'>Update Client Details </a> </div>");
                    Response.Write("<br />");
                    Response.Write("<div class = 'clientdetails'> <a href = 'deleteClient.aspx?ID= " + ClientData[0] +
                    "'>Delete Client Record </a> </div>");
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }
    }
}