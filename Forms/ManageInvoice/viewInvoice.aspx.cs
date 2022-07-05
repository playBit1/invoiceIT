using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageInvoice
{
    public partial class viewInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Invoice_ID))
            {
                Invoice invoice = new Invoice();
                _ = new List<string>(12);
                List<string> InvoiceData = invoice.GetInvoice(Invoice_ID);
                bool isEmpty = AppUtilities.IsEmpty(InvoiceData);
                Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                Response.Write("<div><a href='viewInvoiceList.aspx'>Back to List</a></div>");
                if (isEmpty)
                {
                    Response.Write("Error: No Invoice Details Found");
                }
                else
                {
                    Response.Write("<div class = 'clientdetails'> Invoice ID: <b>" + InvoiceData[0] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Work ID: <b>" + InvoiceData[1] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Client Company Name: <b>" + InvoiceData[2] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Staff Member Name: <b>" + InvoiceData[3] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Task Name: <b>" + InvoiceData[4] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Work Item Status: <b>" + InvoiceData[5] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Work Start Time: <b>" + InvoiceData[6] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Work Completed Time: <b>" + InvoiceData[7] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Invoice Genarated Date: <b>" + InvoiceData[8] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Invoice Sent Date: <b>" + InvoiceData[9] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Invoice Payment Due Date: <b>" + InvoiceData[10] + "</b></div> <br />");
                    Response.Write("<div class = 'clientdetails'> Invoice Status: <b>" + InvoiceData[11] + "</b></div> <br />");
                    Response.Write("<br />");
                    Response.Write("<div class = 'clientdetails'> <a href = 'updateInvoice.aspx?ID= " + InvoiceData[0] +
                    "'>Update Invoice Details </a> </div>");
                    Response.Write("<br />");
                    Response.Write("<div class = 'clientdetails'> <a href = 'deleteInvoice.aspx?ID= " + InvoiceData[0] +
                    "'>Delete Invoice </a> </div>");
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }
    }
}