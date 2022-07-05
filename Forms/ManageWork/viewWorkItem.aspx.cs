using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageWork
{
    public partial class viewWorkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Work_ID))
            {
                WorkItem workItem = new WorkItem();
                _ = new List<string>(13);
                List<string> WorkItemData = workItem.GetWorkItem(Work_ID);
                bool isEmpty = AppUtilities.IsEmpty(WorkItemData);
                Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                Response.Write("<div><a href='viewWorkItemList.aspx'>Back to List</a></div>");
                if (isEmpty)
                {
                    Response.Write("Error: No Work Item Details Found");
                }
                else
                {
                    Response.Write("<div class = 'workdetails'> Work ID: <b>" + WorkItemData[0] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Client ID: <b>" + WorkItemData[1] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Client Company Name: <b>" + WorkItemData[2] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Staff ID: <b>" + WorkItemData[3] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Staff First Name: <b>" + WorkItemData[4] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Task ID: <b>" + WorkItemData[5] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Task Title: <b>" + WorkItemData[6] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Start Date: <b>" + WorkItemData[7] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Start Time: <b>" + WorkItemData[9] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Completed Date: <b>" + WorkItemData[8] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Completed Time: <b>" + WorkItemData[10] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Status: <b>" + WorkItemData[11] + "</b></div> <br />");
                    Response.Write("<div class = 'workdetails'> Comment: <b>" + WorkItemData[12] + "</b></div> <br />");
                    Response.Write("<br />");
                    Response.Write("<div class = 'workdetails'> <a href = 'updateWorkItem.aspx?ID= " + WorkItemData[0] +
                    "'>Update Work Item Details </a> </div>");
                    Response.Write("<br />");
                    Response.Write("<div class = 'workdetails'> <a href = 'deleteWorkItem.aspx?ID= " + WorkItemData[0] +
                    "'>Delete Work Item Record </a> </div>");
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }
    }
}