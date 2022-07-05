using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageStaff
{
    public partial class deleteStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_ID) && Staff_ID != 1)
            {
                Staff staff = new Staff();
                string result = staff.DeleteStaff(Staff_ID);

                if (result == "Query Successful!")
                {
                    Response.Write("<span class='success'>Staff record deleted successfully.</span><br />");
                    Response.Write("<a href='ViewStaffList.aspx'>Return to Staff List</a>");
                }
                else
                {
                    Response.Write("<span class='error'>Delete failed; Staff details have not been removed.</span><br />");
                    Response.Write("<a href='ViewStaffList.aspx'>Return to Staff List</a>");
                }
            }
            else
            {
                Response.Write("Cannot Delete Main Administrator");
            }
        }
    }
}