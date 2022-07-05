using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageTask
{
    public partial class updateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Task_ID))
            {
                Task task = new Task();
                _ = new List<string>(4);
                List<string> TaskData = task.GetTask(Task_ID);
                bool isEmpty = AppUtilities.IsEmpty(TaskData);

                this.updatecrsheader.InnerHtml = "<h3>Update Details for " + TaskData[1] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("Error: No Task Details Found");
                }
                else
                {
                    this.CtrlTaskID.Value = TaskData[0].ToString();
                    this.CtrlTaskTitle.Text = TaskData[1];
                    this.CtrlTaskDesc.Text = TaskData[2];
                    this.CtrlTaskRate.Text = TaskData[3];
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }

        }

        protected void BtnUpdateTask_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateTaskData = Request.Form;
                Task UpdateTsk = new Task();
                string Result = UpdateTsk.UpdateTask(UpdateTaskData);

                if (Result == "Query Successful!")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Task details updated successfully.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; Task details have not been changed.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>");

                }
            }

        }
    }
}