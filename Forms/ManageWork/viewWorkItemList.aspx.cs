using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageWork
{
    public partial class viewWorkItemList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkItem WorkItemList = new WorkItem();
            List<List<string>> allWorkItems;

            if (Convert.ToInt32(Session["Access"]) == 0)
            {
                allWorkItems = WorkItemList.GetWorkItem();
            }
            else
            {
                allWorkItems = WorkItemList.GetWorkItemFor(Convert.ToInt32(Session["Id"]));
            }

            Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
            if (allWorkItems == null)
            {
                Response.Write("No Records Available!");
            }
            else
            {
                int workItemCount = allWorkItems.Count;
                Response.Write("<h1 align='center'> Select A Work Item To View Details, Update or Delete</h1>");
                Response.Write("<p> Current Work Items:" + workItemCount + "</p>");
                Response.Write("<div class = 'worklistingcont'>");

                Response.Write("<div class = 'worklistingrow'>");
                Response.Write("<div class = 'workid'>Work Item ID</div>");
                Response.Write("<div class = 'clientid'>Client ID</div>");
                Response.Write("<div class = 'staffid'>Staff ID</div>");
                Response.Write("<div class = 'taskid'>Task ID</div>");
                Response.Write("<div class = 'startdate'>Start Date</div>");
                Response.Write("<div class = 'status'>Status</div>");
                Response.Write("</div>");

                for (int i = 0; i <= workItemCount - 1; i++)
                {
                    Response.Write("<div class = 'worklistingrow'>");
                    Response.Write("<div class = 'workid'>" + allWorkItems[i][0] + "</div>");
                    Response.Write("<div class = 'clientid'>" + allWorkItems[i][1] + "</div>");
                    Response.Write("<div class = 'staffid'>" + allWorkItems[i][3] + "</div>");
                    Response.Write("<div class = 'taskid'>" + allWorkItems[i][5] + "</div>");
                    Response.Write("<div class = 'startdate'>" + allWorkItems[i][7] + "</div>");
                    Response.Write("<div class = 'status'>" + allWorkItems[i][11] + "</div>");
                    Response.Write("<div class = 'workview'><a href = 'viewWorkItem.aspx?ID= " + allWorkItems[i][0] +
                    "'>Select</a></div>");
                    Response.Write("</div>");
                }
                Response.Write("</div>");
            }
        }
    }
}