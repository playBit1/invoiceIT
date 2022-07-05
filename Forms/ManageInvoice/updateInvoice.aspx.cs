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
    public partial class updateInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Invoice_ID))
            {


                Invoice invoice = new Invoice();
                _ = new List<string>(12);
                List<string> InvoiceData = invoice.GetInvoice(Invoice_ID);
                bool isEmpty = AppUtilities.IsEmpty(InvoiceData);

                if (InvoiceData[11].ToString() == "Sent")
                {
                    this.updatecrsheader.InnerHtml = "<h3>Replaces Invoice Number " + InvoiceData[0] + "Sent On" + InvoiceData[9] + "</h3>";
                }
                else
                {
                    this.updatecrsheader.InnerHtml = "<h3>Update Details for " + InvoiceData[2] + "</h3>";
                }
                
                if (isEmpty)
                {
                    Response.Write("Error: No Invoice Found");
                }
                else
                {
                    string workdrop;
                    WorkItem work = new WorkItem();

                    List<List<string>> AllWork = work.GetWorkItem();

                    if (AllWork == null)
                    {
                        WorkListPH.Text = "Error: No Staff Available";
                    }
                    else
                    {
                        int workCount = AllWork.Count;

                        workdrop = "<span id='LblStaffList' class='frmlabel'>Select Work Item</span><br />";
                        workdrop += "<select class='dllist' name='CtrlWorkList'>";
                        workdrop += "<option value='" + InvoiceData[1] + "'> Client:" + InvoiceData[2] + "    Task:" + InvoiceData[4] + "</option>";

                        for (int i = 0; i <= workCount - 1; i++)
                        {
                            if (AllWork[i][0] != InvoiceData[1])
                            {
                                workdrop += "<option value='" + AllWork[i][0] + "'> Client:" + AllWork[i][2] + "    Task:" + AllWork[i][6] + "</option>";
                            }
                            
                        }
                        workdrop += "</select>";
                        WorkListPH.Text = workdrop;
                    }

                    this.CtrlInvoiceID.Value = InvoiceData[0].ToString();
                    this.CtrlGenDate.Value = InvoiceData[8].ToString();
                    this.CtrlDueDate.Value = InvoiceData[10].ToString();
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }

        protected void BtnUpdateInvoice_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateInvoiceData = Request.Form;
                Client UpdateInv = new Client();
                string Result = UpdateInv.UpdateClient(UpdateInvoiceData);

                if (Result == "Query Successful!")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Invoice details updated successfully.</span><br />");
                    Response.Write("<a href='ViewInvoiceList.aspx'>Return to Invoice List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; Invoice details have not been changed.</span><br />");
                    Response.Write("<a href='ViewInvoiceList.aspx'>Return to Invoice List</a>");

                }
            }
        }
    }
}