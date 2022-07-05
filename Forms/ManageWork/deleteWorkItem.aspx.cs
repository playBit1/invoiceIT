using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageWork
{
    public partial class deleteWorkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Work_ID))
            {
                WorkItem client = new WorkItem();
                string result = client.DeleteWorkItem(Work_ID);

                if (result == "Query Successful!")
                {
                    Response.Write("<span class='success'>Work Item record deleted successfully.</span><br />");
                    Response.Write("<a href='ViewWorkItemList.aspx'>Return to Work Item List</a>");
                }
                else
                {
                    Response.Write("<span class='error'>Delete failed; Work Item details have not been removed.</span><br />");
                    Response.Write("<a href='ViewWorkItemList.aspx'>Return to Work Item List</a>");
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }
    }
}