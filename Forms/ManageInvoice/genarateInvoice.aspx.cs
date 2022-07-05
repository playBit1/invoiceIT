using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageInvoice
{
    public partial class genarateInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string WorkItemdrop;
            WorkItem workItem = new WorkItem();

            List<List<string>> AllWorkItem = workItem.GetWorkItem();

            if (AllWorkItem == null)
            {
                WorkListPH.Text = "Error: No Staff Available";
            }
            else
            {
                int staffCount = AllWorkItem.Count;

                WorkItemdrop = "<span id='LblStaffList' class='frmlabel'>Select Work Item</span><br />";
                WorkItemdrop += "<select class='dllist' name='CtrlWorkList'>";
                WorkItemdrop += "<option value='0'>--Please make a selection--</option>";

                for (int i = 0; i <= staffCount - 1; i++)
                {
                    WorkItemdrop += "<option value='" + AllWorkItem[i][0] + "'> Client:" + AllWorkItem[i][2] +"    Task:" + AllWorkItem[i][6] + "</option>";
                }
                WorkItemdrop += "</select>";
                WorkListPH.Text = WorkItemdrop;

            }

            string date = DateTime.Now.ToString("M/d/yyyy");
            string globDate = Convert.ToDateTime(date).ToString("MM/dd/yyyy");
            this.CtrlGenDate.Value = globDate; 

        }

        protected void BtnGenerateInvoice_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request.Form["CtrlWorkList"] == "0")
                {
                    Response.Write("Please Select Values For Work Item");
                }
                else
                {
                    Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                    NameValueCollection NewInvoiceData = Request.Form;
                    Invoice NewInvoice = new Invoice();
                    String Result = NewInvoice.AddInvoice(NewInvoiceData);
                    Response.Write(Result);
                    AppUtilities.ClearForm(Form.Controls);
                }
            }

        }
    }
}