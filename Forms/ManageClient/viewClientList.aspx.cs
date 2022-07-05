using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageClient
{
    public partial class viewClientList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Client ClientList = new Client();

            List<List<string>> allClients = ClientList.GetClient();
            Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
            if (allClients == null)
            {
                Response.Write("No Records Available!");
            }
            else
            {
                int clientCount = allClients.Count;
                Response.Write("<h1 align='center'> Select A Client To View Details, Update or Delete</h1>");
                Response.Write("<p> Current Clients:" + clientCount + "</p>");
                Response.Write("<div class = 'clientlistingcont'>");

                Response.Write("<div class = 'clientlistingrow'>");
                Response.Write("<div class = 'clientrowspace'>Client ID</div>");
                Response.Write("<div class = 'clientrowspace'>Company Name</div>");
                Response.Write("<div class = 'clientrowspace'>Contact First Name</div>");
                Response.Write("<div class = 'clientrowspace'>Contact Last Name</div>");
                Response.Write("<div class = 'clientrowspace'>Contact Email</div>");
                Response.Write("<div class = 'clientrowspace'>Contact Mobile</div>");
                Response.Write("</div>");

                for (int i = 0; i <= clientCount - 1; i++)
                {
                    Response.Write("<div class = 'clientlistingrow'>");
                    Response.Write("<div class = 'clientrowspace'>" + allClients[i][0] +"</div>");
                    Response.Write("<div class = 'clientrowspace'>" + allClients[i][1] + "</div>");
                    Response.Write("<div class = 'clientrowspace'>" + allClients[i][6] + "</div>");
                    Response.Write("<div class = 'clientrowspace'>" + allClients[i][7] + "</div>");
                    Response.Write("<div class = 'clientrowspace'>" + allClients[i][8] + "</div>");
                    Response.Write("<div class = 'clientrowspace'>" + allClients[i][9] + "</div>");
                    Response.Write("<div class = 'clientrowspace'><a href = 'viewClient.aspx?ID= " + allClients[i][0] +
                    "'>Select</a></div>");
                    Response.Write("</div>");
                }
                Response.Write("</div>");
            }
        }
    }
}