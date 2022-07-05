using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace invoiceIT.Forms
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.Session["Access"] == null && System.Web.HttpContext.Current.Session["Name"] == null)
            {
                Response.Redirect("/Forms/login.aspx");
            }
            else
            {
                if (Convert.ToInt32(Session["Access"]) == 0)
                {
                    this.TtlIndex.Text = "Hello " + Session["Name"].ToString();
                }
                else if (Convert.ToInt32(Session["Access"]) == 1)
                {
                    this.adminOnly.Visible = false;
                    this.TtlIndex.Text = "Hello " + Session["Name"].ToString();
                }

            }
        }

        protected void BtnManageWork_Click(object sender, EventArgs e)
        {
            string formName = Request.Form["DropManageWork"];
            formName = formName.Replace(" ", String.Empty);
            if (formName == "UpdateWorkItem" || formName == "DeleteWorkItem")
            {
                Response.Redirect("ManageWork/viewWorkItemList.aspx");
            }
            else
            {
                Response.Redirect("ManageWork/" + formName + ".aspx");
            }
        }

        protected void BtnManageClient_Click(object sender, EventArgs e)
        {
            string formName = Request.Form["DropManageClient"];
            formName = formName.Replace(" ", String.Empty);
            if (formName == "UpdateClient" || formName == "DeleteClient")
            {
                Response.Redirect("ManageClient/viewClientList.aspx");
            }
            else
            {
                Response.Redirect("ManageClient/" + formName + ".aspx");
            }
        }

        protected void BtnManageStaff_Click(object sender, EventArgs e)
        {
            string formName = Request.Form["DropManageStaff"];
            formName = formName.Replace(" ", String.Empty);
            if (formName == "UpdateStaff" || formName == "DeleteStaff")
            {
                Response.Redirect("ManageStaff/viewStaffList.aspx");
            }
            else
            {
                Response.Redirect("ManageStaff/" + formName + ".aspx");
            }
        }

        protected void BtnManageInvoice_Click(object sender, EventArgs e)
        {
            string formName = Request.Form["DropManageInvoice"];
            formName = formName.Replace(" ", String.Empty);
            if (formName == "UpdateInvoice" || formName == "DeleteInvoice")
            {
                Response.Redirect("ManageInvoice/viewInvoiceList.aspx");
            }
            else
            {
                Response.Redirect("ManageInvoice/" + formName + ".aspx");
            }
        }

        protected void BtnManageTask_Click(object sender, EventArgs e)
        {
            string formName = Request.Form["DropManageTask"];
            formName = formName.Replace(" ", String.Empty);
            if (formName == "UpdateTask" || formName == "DeleteTask")
            {
                Response.Redirect("ManageTask/viewTaskList.aspx");
            }
            else
            {
                Response.Redirect("ManageTask/" + formName + ".aspx");
            }
        }
    }
}