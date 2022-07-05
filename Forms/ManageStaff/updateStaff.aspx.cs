using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageStaff
{
    public partial class updateStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_ID))
            {
                Staff staff = new Staff();
                _ = new List<string>(8);
                List<string> StaffData = staff.GetStaff(Staff_ID);
                bool isEmpty = AppUtilities.IsEmpty(StaffData);

                Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                this.updatecrsheader.InnerHtml = "<h3>Update Details for " + StaffData[2] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("Error: No Staff Record Found");
                }
                else
                {
                    this.CtrlStaffID.Value = StaffData[0].ToString();
                    this.CtrlPassword.Text = StaffData[1];
                    this.CtrlFName.Text = StaffData[2];
                    this.CtrlSurname.Text = StaffData[3];
                    this.CtrlEmail.Text = StaffData[4];
                    this.CtrlMobile.Text = StaffData[5];

                    string accessLevel = StaffData[6].Replace(" ", String.Empty);
                    string status = StaffData[7].Replace(" ", String.Empty);
                    string staffaccessLevel;
                    string staffStatus;

                    if (StaffData[0].ToString() == "1")
                    {
                        staffaccessLevel = "<select class='tbinput' name='DropAccessLevel' id='DropAccessLevel'>";
                        staffaccessLevel += "<option value='Administrator' selected='selected'>Administrator</option>";
                        staffaccessLevel += "</select>";
                    }
                    else if (accessLevel == "Administrator")
                    {
                        staffaccessLevel = "<select class='tbinput' name='DropAccessLevel' id='DropAccessLevel'>";
                        staffaccessLevel += "<option value='Administrator' selected='selected'>Administrator</option>";
                        staffaccessLevel += "<option value='Staff'>Staff</option>";
                        staffaccessLevel += "</select>";

                    }
                    else
                    {
                        staffaccessLevel = "<select class='tbinput' name='DropAccessLevel' id='DropAccessLevel'>";
                        staffaccessLevel += "<option value='Administrator'>Administrator</option>";
                        staffaccessLevel += "<option value='Staff' selected='selected'>Staff</option>";
                        staffaccessLevel += "</select>";
                    }


                    if (status == "Active")
                    {
                        staffStatus = "<select class='tbinput' name='DropStatus' id='DropStatus'>";
                        staffStatus += "<option value='Active' selected='selected'>Active</option>";
                        staffStatus += "<option value='Inactive'>Inactive</option>";
                        staffStatus += "<option value='Terminated'>Terminated</option>";
                        staffStatus += "</select>";
                    }
                    else if (status == "Inactive")
                    {
                        staffStatus = "<select class='tbinput' name='DropStatus' id='DropStatus'>";
                        staffStatus += "<option value='Active'>Active</option>";
                        staffStatus += "<option value='Inactive' selected='selected'>Inactive</option>";
                        staffStatus += "<option value='Terminated'>Terminated</option>";
                        staffStatus += "</select>";
                    }
                    else
                    {
                        staffStatus = "<select class='tbinput' name='DropStatus' id='DropStatus'>";
                        staffStatus += "<option value='Active'>Active</option>";
                        staffStatus += "<option value='Inactive'>Inactive</option>";
                        staffStatus += "<option value='Terminated' selected='selected'>Terminated</option>";
                        staffStatus += "</select>";
                    }

                    AccessLevelPH.Text = staffaccessLevel;
                    StatusPH.Text = staffStatus;

                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }

        protected void BtnUpdateStaff_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateStaffData = Request.Form;
                Staff UpdateStf = new Staff();
                string Result = UpdateStf.UpdateStaff(UpdateStaffData);

                if (Result == "Query Successful!")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Staff details updated successfully.</span><br />");
                    Response.Write("<a href='ViewStaffList.aspx'>Return to Staff List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; Staff details have not been changed.</span><br />");
                    Response.Write("<a href='ViewStaffList.aspx'>Return to Staff List</a>");

                }
            }
        }
    }
}