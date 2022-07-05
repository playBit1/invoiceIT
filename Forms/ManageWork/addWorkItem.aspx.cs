using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageWork
{
    public partial class addWorkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string clientDrop;
            Client client = new Client();

            List<List<string>> AllClients = client.GetClient();

            if (AllClients == null)
            {
                ClientListPH.Text = "Error: No Clients Available";
            }
            else
            {
                int clientCount = AllClients.Count;

                clientDrop = "<span id='LblClientList' class='frmlabel'>Select a Client</span><br />";
                clientDrop += "<select class='dllist' ID ='CtrlClientList' name='CtrlClientList'>";
                clientDrop += "<option value='0'>--Please make a selection--</option>";

                for (int i = 0; i <= clientCount - 1; i++)
                {
                    clientDrop += "<option value='" + AllClients[i][0] + "'>" + AllClients[i][1] + "</option>";
                }
                clientDrop += "</select>";

                ClientListPH.Text = clientDrop;

            }


            string staffdrop;
            Staff staff = new Staff();

            List<List<string>> AllStaff = staff.GetStaff();

            if (AllStaff == null)
            {
                StaffListPH.Text = "Error: No Staff Available";
            }
            else
            {
                int staffCount = AllStaff.Count;

                staffdrop = "<span id='LblStaffList' class='frmlabel'>Select Staff Member</span><br />";
                staffdrop += "<select class='dllist' name='CtrlStaffList'>";
                staffdrop += "<option value='0'>--Please make a selection--</option>";

                for (int i = 0; i <= staffCount - 1; i++)
                {
                    staffdrop += "<option value='" + AllStaff[i][0] + "'>" + AllStaff[i][2] + "</option>";
                }
                staffdrop += "</select>";
                StaffListPH.Text = staffdrop;

            }

            string taskdrop;
            Task task = new Task();

            List<List<string>> AllTasks = task.GetTask();

            if (AllTasks == null)
            {
                TaskListPH.Text = "Error: No Tasks Available";
            }
            else
            {
                int taskCount = AllTasks.Count;

                taskdrop = "<span id='LblTaskList' class='frmlabel'>Select Task</span><br />";
                taskdrop += "<select class='dllist' name='CtrlTaskList'>";
                taskdrop += "<option value='0'>--Please make a selection--</option>";

                for (int i = 0; i <= taskCount - 1; i++)
                {
                    taskdrop += "<option value='" + AllTasks[i][0] + "'>" + AllTasks[i][1] + "</option>";
                }
                taskdrop += "</select>";
                TaskListPH.Text = taskdrop;

            }

        }

        protected void BtnAddNewWorkItem_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request.Form["CtrlClientList"] == "0" && Request.Form["CtrlStaffList"] == "0" && Request.Form["CtrlTaskList"] == "0")
                {
                    Response.Write("Please Select Values For Client, Staff And Task Fields");
                }
                else
                {
                    Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                    NameValueCollection NewWorkData = Request.Form;
                    WorkItem NewWork = new WorkItem();
                    String Result = NewWork.AddWorkItem(NewWorkData);
                    Response.Write(Result);
                    AppUtilities.ClearForm(Form.Controls);
                }
            }
        }
    }
}