using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageTask
{
    public partial class addTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddNewTask_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Write("<div><a href='/Forms/index.aspx'>Back to Menu</a></div>");
                NameValueCollection NewTaskData = Request.Form;
                Task NewTask = new Task();
                String Result = NewTask.AddTask(NewTaskData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);
            }
        }
    }
}