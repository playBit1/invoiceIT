using invoiceIT.Db_Classes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace invoiceIT.Forms.ManageStaff
{
    public partial class addStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddNewStaff_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                NameValueCollection NewStaffData = Request.Form;
                Staff NewStaff = new Staff();
                String Result = NewStaff.AddStaff(NewStaffData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);
            }
        }
    }
}