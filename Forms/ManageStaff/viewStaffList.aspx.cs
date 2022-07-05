using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageStaff
{
    public partial class viewStaffList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Staff StaffList = new Staff();

            List<List<string>> AllStaff = StaffList.GetStaff();

            if (AllStaff == null)
            {
                Response.Write("No Records Available!");
            }
            else
            {
                int StaffCount = AllStaff.Count;
                Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                Response.Write("<h1 align='center'> Select A Staff Member To View Details, Update or Delete</h1>");
                Response.Write("<p> Staff Count:" + StaffCount + "</p>");
                Response.Write("<div class = 'stafflistingcont'>");

                Response.Write("<div class = 'stafflistingrow'>");
                Response.Write("<div class = 'staffid'>Staff ID</div>");
                Response.Write("<div class = 'staffname'>First Name</div>");
                Response.Write("<div class = 'staffemail'>Email</div>");
                Response.Write("<div class = 'staffaccess'>Access Level</div>");
                Response.Write("<div class = 'staffstatus'>Status</div>");
                Response.Write("</div>");

                for (int i = 0; i <= StaffCount - 1; i++)
                {
                    Response.Write("<div class = 'stafflistingrow'>");
                    Response.Write("<div class = 'staffid'>" + AllStaff[i][0] + "</div>");
                    Response.Write("<div class = 'staffname'>" + AllStaff[i][2] + "</div>");
                    Response.Write("<div class = 'staffemail'>" + AllStaff[i][4] + "</div>");
                    Response.Write("<div class = 'staffaccess'>" + AllStaff[i][6] + "</div>");
                    Response.Write("<div class = 'staffstatus'>" + AllStaff[i][7] + "</div>");
                    Response.Write("<div class = 'staffview'><a href = 'viewStaff.aspx?ID= " + AllStaff[i][0] +
                    "'>Select</a></div>");
                    Response.Write("</div>");
                }
                Response.Write("</div>");
            }
        }
    }
}