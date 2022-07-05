using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageTask
{
    public partial class viewTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Task_ID))
            {
                Task task = new Task();
                _ = new List<string>(4);
                List<string> TaskData = task.GetTask(Task_ID);
                bool isEmpty = AppUtilities.IsEmpty(TaskData);
                Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                Response.Write("<div><a href='viewTaskList.aspx'>Back to List</a></div>");
                if (isEmpty)
                {
                    Response.Write("Error: No Task Details Found");
                }
                else
                {
                    Response.Write("<div class = 'taskdetails'> Task ID: <b>" + TaskData[0] + "</b></div> <br />");
                    Response.Write("<div class = 'taskdetails'> Task Title: <b>" + TaskData[1] + "</b></div> <br />");
                    Response.Write("<div class = 'taskdetails'> Task Description: <b>" + TaskData[2] + "</b></div> <br />");
                    Response.Write("<div class = 'taskdetails'> Task Rate: <b>" + TaskData[3] + "</b></div> <br />");
                    Response.Write("<br />");
                    Response.Write("<div class = 'taskdetails'> <a href = 'updateTask.aspx?ID= " + TaskData[0] +
                    "'>Update Task Details </a> </div>");
                    Response.Write("<br />");
                    Response.Write("<div class = 'taskdetails'> <a href = 'deleteTask.aspx?ID= " + TaskData[0] +
                    "'>Delete Task Record </a> </div>");
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }
    }
}