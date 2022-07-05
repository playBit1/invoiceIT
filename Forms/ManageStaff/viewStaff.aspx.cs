using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageStaff
{
    public partial class viewStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_ID))
            {
                Staff staff = new Staff();
                _ = new List<string>(8);
                List<string> StaffData = staff.GetStaff(Staff_ID);
                bool isEmpty = AppUtilities.IsEmpty(StaffData);
                Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                Response.Write("<div><a href='viewStaffList.aspx'>Back To Staff List</a></div>");
                if (isEmpty)
                {
                    Response.Write("Error: No Staff Details Found");
                }
                else
                {
                    Response.Write("<div class = 'staffdetails'> Staff ID: <b>" + StaffData[0] + "</b></div> <br />");
                    Response.Write("<div class = 'staffdetails'> Password: <b>" + StaffData[1] + "</b></div> <br />");
                    Response.Write("<div class = 'staffdetails'> First Name: <b>" + StaffData[2] + "</b></div> <br />");
                    Response.Write("<div class = 'staffdetails'> Surname: <b>" + StaffData[3] + "</b></div> <br />");
                    Response.Write("<div class = 'staffdetails'> Email: <b>" + StaffData[4] + "</b></div> <br />");
                    Response.Write("<div class = 'staffdetails'> Mobile: <b>" + StaffData[5] + "</b></div> <br />");
                    Response.Write("<div class = 'staffdetails'> Access Level: <b>" + StaffData[6] + "</b></div> <br />");
                    Response.Write("<div class = 'staffdetails'> Status: <b>" + StaffData[7] + "</b></div> <br />");
                    Response.Write("<div class = 'staffdetails'> <a href = 'updateStaff.aspx?ID= " + StaffData[0] +
                    "'>Update Staff Details </a> </div>");
                    Response.Write("<br />");
                    Response.Write("<div class = 'staffdetails'> <a href = 'deleteStaff.aspx?ID= " + StaffData[0] +
                    "'>Delete Staff Record </a> </div>");
                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }
    }
}