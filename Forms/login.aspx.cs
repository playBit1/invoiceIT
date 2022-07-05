using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using invoiceIT.Db_Classes;
using System.Collections;

namespace invoiceIT.Forms
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                Staff user = new Staff();
                _ = new List<string>(3);
                List<string> UserDetails = user.GetStaff(Request.Form["CtrlUserEmail"], Request.Form["CtrlUserPassword"]);
                bool isEmpty = AppUtilities.IsEmpty(UserDetails);
                if (isEmpty)
                {
                    Response.Write("<p>User not found Please Enter Correct Email OR Password <br>");
                    //Account Credentials provided Since This is a protoType
                    Response.Write("Prototype Admin Account Email:<b>psmailes@itserv.com.au</b> And PassWord:<b>Peter123</b> <br>");        
                    Response.Write("Prototype Staff Account Email:<b>mpilson@itserv.com.au</b> And PassWord:<b>MaPi10</b></p>");
                }
                else
                {
                    if (UserDetails[1] == "Administrator                           ")
                    {
                        Session["Access"] = 0;
                        Session["Name"] = UserDetails[0];
                        Session["Id"] = UserDetails[2];
                        Response.Redirect("/Forms/index.aspx?");
                    }
                    else if (UserDetails[1] == "Staff                                   ")
                    {
                        Session["Access"] = 1;
                        Session["Name"] = UserDetails[0];
                        Session["Id"] = UserDetails[2];
                        Response.Redirect("/Forms/index.aspx?");
                    }
                    else
                    {
                        Response.Write("Invalid Role: Please Contact Support");
                    }
                }
            }
        }
    }
}