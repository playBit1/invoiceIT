using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageInvoice
{
    public partial class viewInvoiceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Invoice InvoiceList = new Invoice();



            List<List<string>> allInvoices = InvoiceList.GetInvoice();
            Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");

            if (allInvoices == null)
            {
                Response.Write("No Records Available!");
            }
            else
            {
                int InvoiceCount = allInvoices.Count;
                Response.Write("<h1 align='center'> Select A Invoice To View Details, Update or Delete</h1>");
                Response.Write("<p> Current Clients:" + InvoiceCount + "</p>");
                Response.Write("<div class = 'invoicelistingcont'>");

                Response.Write("<div class = 'invoicelistingrow'>");
                Response.Write("<div class = 'invoicerowspace'>Invoice ID</div>");
                Response.Write("<div class = 'invoicerowspace'>Work ID</div>");
                Response.Write("<div class = 'invoicerowspace'>Performed Task</div>");
                Response.Write("<div class = 'invoicerowspace'>Total Hours For Task</div>");
                Response.Write("<div class = 'invoicerowspace'>Work Item Status</div>");
                Response.Write("<div class = 'invoicerowspace'>Invoice Status</div>");
                Response.Write("</div>");

                /* [0] Invoice ID
                  * [1] Work ID
                  * [2] Client Company Name
                  * [3] Staff Member Name
                  * [4] Task Name
                  * [5] Work Item Status
                  * [6] Work Start Time
                  * [7] Work Completed Time
                  * [8] Invoice Genarated Date
                  * [9] Invoice Sent Date
                  * [10] Invoice Payment Due Date
                  * [11] Invoice Status
                 */

                for (int i = 0; i <= InvoiceCount - 1; i++)
                {
                    if (int.TryParse(allInvoices[i][6].Substring(0, 2), out int startHour))
                    {
                        
                    }

                    if (int.TryParse(allInvoices[i][7].Substring(0, 2), out int endHour))
                    {

                    }

                    int diff = endHour - startHour;

                    Response.Write("<div class = 'invoicelistingrow'>");
                    Response.Write("<div class = 'invoicerowspace'>" + allInvoices[i][0] + "</div>");
                    Response.Write("<div class = 'invoicerowspace'>" + allInvoices[i][1] + "</div>");
                    Response.Write("<div class = 'invoicerowspace'>" + allInvoices[i][4] + "</div>");
                    Response.Write("<div class = 'invoicerowspace'>" + diff +" Hours" + "</div>");
                    Response.Write("<div class = 'invoicerowspace'>" + allInvoices[i][5] + "</div>");
                    Response.Write("<div class = 'invoicerowspace'>" + allInvoices[i][11] + "</div>");
                    Response.Write("<div class = 'invoicerowspace'><a href = 'viewInvoice.aspx?ID= " + allInvoices[i][0] +
                    "'>Select</a></div>");
                    Response.Write("</div>");
                }
                Response.Write("</div>");
            }
        }
    }
}