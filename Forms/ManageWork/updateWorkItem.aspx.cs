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
    public partial class updateWorkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Work_ID))
            {
                WorkItem workItem = new WorkItem();
                _ = new List<string>(13);
                List<string> WorkItemData = workItem.GetWorkItem(Work_ID);
                bool isEmpty = AppUtilities.IsEmpty(WorkItemData);

                this.updatecrsheader.InnerHtml = "<h3>Update Details of Work item for Client: " + WorkItemData[2] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("Error: No Client Details Found");
                }
                else
                {

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
                        staffdrop += "<option value='" + WorkItemData[3] + "'>"+ WorkItemData[4] +"</option>";

                        for (int i = 0; i <= staffCount - 1; i++)
                        {
                            if (AllStaff[i][0] != WorkItemData[3])
                            {
                                staffdrop += "<option value='" + AllStaff[i][0] + "'>" + AllStaff[i][2] + "</option>";
                            }
                            
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
                        taskdrop += "<option value='" + WorkItemData[5] + "'>" + WorkItemData[6] + "</option>";

                        for (int i = 0; i <= taskCount - 1; i++)
                        {
                            if (AllTasks[i][0] != WorkItemData[5])
                            {
                                taskdrop += "<option value='" + AllTasks[i][0] + "'>" + AllTasks[i][1] + "</option>";
                            }
                                
                        }
                        taskdrop += "</select>";
                        TaskListPH.Text = taskdrop;

                    }

                    this.CtrlWorkID.Value = WorkItemData[0].ToString();
                    this.CtrlClientID.Value = WorkItemData[1];
                    this.CtrlClientName.Text = WorkItemData[2];
                    this.CtrlStartDate.Value = WorkItemData[7];
                    this.CtrlStartTime.Text = WorkItemData[9];
                    this.CtrlCompletedDate.Value = WorkItemData[8];
                    this.CtrlEndTime.Text = WorkItemData[10];
                    this.CtrlComment.Text = WorkItemData[12];

                    string status = WorkItemData[11].Replace(" ", String.Empty);

                    string workItemStatus;

                    if (status == "Ongoing")
                    {
                        workItemStatus = "<select class='tbinput' name='DropStatus' id='DropStatus'>";
                        workItemStatus += "<option value='Ongoing' selected='selected'>Ongoing</option>";
                        workItemStatus += "<option value='Paused'>Paused</option>";
                        workItemStatus += "<option value='Completed'>Completed</option>";
                        workItemStatus += "<option value='Discontinued'>Discontinued</option>";
                        workItemStatus += "</select>";
                    }
                    else if (status == "Paused")
                    {
                        workItemStatus = "<select class='tbinput' name='DropStatus' id='DropStatus'>";
                        workItemStatus += "<option value='Ongoing'>Ongoing</option>";
                        workItemStatus += "<option value='Paused' selected='selected'>Paused</option>";
                        workItemStatus += "<option value='Completed'>Completed</option>";
                        workItemStatus += "<option value='Discontinued'>Discontinued</option>";
                        workItemStatus += "</select>";
                    }
                    else if (status == "Completed")
                    {
                        workItemStatus = "<select class='tbinput' name='DropStatus' id='DropStatus'>";
                        workItemStatus += "<option value='Ongoing'>Ongoing</option>";
                        workItemStatus += "<option value='Paused'>Paused</option>";
                        workItemStatus += "<option value='Completed' selected='selected'>Completed</option>";
                        workItemStatus += "<option value='Discontinued'>Discontinued</option>";
                        workItemStatus += "</select>";
                    }
                    else
                    {
                        workItemStatus = "<select class='tbinput' name='DropStatus' id='DropStatus'>";
                        workItemStatus += "<option value='Ongoing'>Ongoing</option>";
                        workItemStatus += "<option value='Paused'>Paused</option>";
                        workItemStatus += "<option value='Completed'>Completed</option>";
                        workItemStatus += "<option value='Discontinued' selected='selected'>Discontinued</option>";
                        workItemStatus += "</select>";
                    }

                    StatusPH.Text = workItemStatus;
                }
            }
        }

        protected void BtnUpdateWorkItem_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateWorkItemData = Request.Form;
                WorkItem UpdateWrk = new WorkItem();
                string Result = UpdateWrk.UpdateWorkItem(UpdateWorkItemData);

                if (Result == "Query Successful!")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Work Item details updated successfully.</span><br />");
                    Response.Write("<a href='ViewWorkItemList.aspx'>Return to Work Item  List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; Work Item details have not been changed.</span><br />");
                    Response.Write("<a href='ViewWorkItemList.aspx'>Return to Work Item List</a>");

                }
            }
        }
    }
}