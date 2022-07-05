using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using invoiceIT.Db_Classes;

namespace invoiceIT.Forms.ManageClient
{
    public partial class updateClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_ID))
            {
                Client client = new Client();
                _ = new List<string>(12);
                List<string> ClientData = client.GetClient(Client_ID);
                bool isEmpty = AppUtilities.IsEmpty(ClientData);

                this.updatecrsheader.InnerHtml = "<h3>Update Details for " + ClientData[1] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("Error: No Client Details Found");
                }
                else
                {
                    this.CtrlClientID.Value = ClientData[0].ToString();
                    this.CtrlCompName.Text = ClientData[1];
                    this.CtrlCompAdd1.Text = ClientData[2];
                    this.CtrlCompAdd2.Text = ClientData[3];
                    this.CtrlCompLocation.Text = ClientData[4];
                    this.CtrlCompPcode.Text = ClientData[5];
                    this.CtrlContactFname.Text = ClientData[6];
                    this.CtrlContactLname.Text = ClientData[7];
                    this.CtrlContactEmail.Text = ClientData[8];
                    this.CtrlContactMobile.Text = ClientData[9];

                    string billTo = ClientData[10].Replace(" ", String.Empty);
                    string status = ClientData[11].Replace(" ", String.Empty);
                    string clientBillTo;
                    string clientStatus;

                    if (billTo == "Company")
                    {
                        clientBillTo = "<select class='tbinput' name='DropBillTo' id='DropBillTo'>";
                        clientBillTo += "<option value='Company' selected='selected'>Company</option>";
                        clientBillTo += "<option value='Client'>Client</option>";
                        clientBillTo += "</select>";

                    }
                    else
                    {
                        clientBillTo = "<select class='tbinput' name='DropBillTo' id='DropBillTo'>";
                        clientBillTo += "<option value='Client' selected='selected'>Client</option>";
                        clientBillTo += "<option value='Company'>Company</option>";
                        clientBillTo += "</select>";
                    }


                    if (status == "Good")
                    {
                        clientStatus = "<select class='tbinput' name='DropStatus' id='DropStatus'>";
                        clientStatus += "<option value='Good' selected='selected'>Good</option>";
                        clientStatus += "<option value='In Arrears'>In Arrears</option>";
                        clientStatus += "<option value='Discontinued'>Discontinued</option>";
                        clientStatus += "</select>";
                    }
                    else if (status == "InArrears")
                    {
                        clientStatus = "<select class='tbinput' name='DropStatus' id='DropStatus'>";
                        clientStatus += "<option value='Good'>Good</option>";
                        clientStatus += "<option value='In Arrears' selected='selected'>In Arrears</option>";
                        clientStatus += "<option value='Discontinued'>Discontinued</option>";
                        clientStatus += "</select>";
                    }
                    else
                    {
                        clientStatus = "<select class='tbinput' name='DropStatus' id='DropStatus'>";
                        clientStatus += "<option value='Good'>Good</option>";
                        clientStatus += "<option value='In Arrears'>In Arrears</option>";
                        clientStatus += "<option value='Discontinued' selected='selected'>Discontinued</option>";
                        clientStatus += "</select>";
                    }

                    BillToPH.Text = clientBillTo;
                    StatusPH.Text = clientStatus;

                }
            }
            else
            {
                Response.Write("ID Not Found or Invalid ");
            }
        }

        protected void BtnUpdateClient_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateClientData = Request.Form;
                Client UpdateCli = new Client();
                string Result = UpdateCli.UpdateClient(UpdateClientData);

                if (Result == "Query Successful!")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Client details updated successfully.</span><br />");
                    Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; Client details have not been changed.</span><br />");
                    Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");

                }
            }
        }
    }
}