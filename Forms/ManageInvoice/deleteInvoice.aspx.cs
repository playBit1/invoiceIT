using invoiceIT.Db_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace invoiceIT.Forms.ManageInvoice
{
    public partial class deleteInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Invoice_ID))
            {
                Invoice invoice = new Invoice();
                string result = invoice.DeleteInvoice(Invoice_ID);

                if (result == "Query Successful!")
                {
                    Response.Write("<span class='success'>Invoice record deleted successfully.</span><br />");
                    Response.Write("<a href='ViewInvoiceList.aspx'>Return to Invoice List</a>");
                }
                else
                {
                    Response.Write("<span class='error'>Delete failed; Invoice details have not been removed.</span><br />");
                    Response.Write("<a href='ViewInvoiceList.aspx'>Return to Invoice List</a>");
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }
    }
}