using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageTask
{
    public partial class viewTaskList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Task TaskList = new Task();

            List<List<string>> AllTasks = TaskList.GetTask();

            Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
            if (AllTasks == null)
            {
                Response.Write("No Records Available!");
            }
            else
            {
                int taskCount = AllTasks.Count;
                Response.Write("<h1 align='center'> Select A Task To View Details, Update or Delete</h1>");
                Response.Write("<p> Current Tasks:" + taskCount + "</p>");
                Response.Write("<div class = 'tasklistingcont'>");

                Response.Write("<div class = 'tasklistingrow'>");
                Response.Write("<div class = 'taskid'>Task ID</div>");
                Response.Write("<div class = 'tasktitle'>Task Title</div>");
                Response.Write("<div class = 'taskrate'>Task Rate</div>");
                Response.Write("</div>");

                for (int i = 0; i <= taskCount - 1; i++)
                {
                    Response.Write("<div class = 'tasklistingrow'>");
                    Response.Write("<div class = 'taskid'>" + AllTasks[i][0] + "</div>");
                    Response.Write("<div class = 'tasktitle'>" + AllTasks[i][1] + "</div>");
                    Response.Write("<div class = 'taskrate'>" + AllTasks[i][3] + "</div>");
                    Response.Write("<div class = 'taskview'><a href = 'viewTask.aspx?ID= " + AllTasks[i][0] +
                    "'>Select</a></div>");
                    Response.Write("</div>");
                }
                Response.Write("</div>");
            }
        }
    }
}