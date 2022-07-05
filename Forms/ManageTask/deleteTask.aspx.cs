using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageTask
{
    public partial class deleteTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Task_ID))
            {
                Task task = new Task();
                string result = task.DeleteTask(Task_ID);

                if (result == "Query Successful!")
                {
                    Response.Write("<span class='success'>Task record deleted successfully.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>");
                }
                else
                {
                    Response.Write("<span class='error'>Delete failed; Client details have not been removed.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>");
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }
    }
}