using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace invoiceIT.Db_Classes
{
    public class Invoice
    {
        public int Invoice_ID { get; set; }
        public int Work_ID { get; set; }
        public string Generated_Date { get; set; }
        public string Sent_Date { get; set; }
        public string Payment_Due_Date { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public string AddInvoice(NameValueCollection NewInvoiceData)
        {
            this.Work_ID = Convert.ToInt32(NewInvoiceData["CtrlWorkList"]);
            this.Generated_Date = NewInvoiceData["CtrlGenDate"];

            if (NewInvoiceData["DropStatus"] == "Sent")
            {
                this.Sent_Date = this.Generated_Date;
            }

            this.Payment_Due_Date = DateTime.ParseExact(
                NewInvoiceData["CtrlDueDate"],
                "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.Status = NewInvoiceData["DropStatus"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand AddInvoice = new SqlCommand
            {
                CommandText = "INSERT INVOICE (Work_ID, Generated_Date, Sent_Date, Payment_Due_Date, Status)" +
                "Values ('" + Work_ID + "','" + Generated_Date + "','" + Sent_Date + 
                "','" + Payment_Due_Date + "','" + Status + "' )",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = AddInvoice.ExecuteNonQuery();
                if (result == 0)
                {
                    this.Message = "Query Unsuccessful!";
                }
                else
                {
                    this.Message = "Query Successful!";
                }
            }
            else
            {
                this.Message = "Database Connection Failed!";
            }

            DBConnect.DropConn(con);

            return Message;
        }

        public List<List<string>> GetInvoice()
        {
            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetAllInvoice = new SqlCommand
            {
                CommandText = "SELECT * FROM INVOICE",
                CommandType = CommandType.Text,
                Connection = con
            };

            List<List<string>> InvoiceList = new List<List<string>>();

            SqlDataReader reader = GetAllInvoice.ExecuteReader();

            WorkItem workItem = new WorkItem();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _ = new List<string>(13);
                    List<string> WorkData = workItem.GetWorkItem(Convert.ToInt32(reader["Work_ID"]));

                    /* [0] Invoice ID
                     * [1] Work ID
                     * [2] Client Company Name
                     * [3] Staff Member Name
                     * [4] Task Name
                     * [5] Work Item Status
                     * [6] Work Start Time
                     * [7] Work Completed Time
                     * [8] Invoice Genarated Date
                     * [9] Invoice Sent Date
                     * [10] Invoice Payment Due Date
                     * [11] Invoice Status
                    */

                    InvoiceList.Add(new List<string> {
                      reader["Invoice_ID"].ToString()
                    , reader["Work_ID"].ToString()
                    , WorkData[2].ToString()
                    , WorkData[4].ToString()
                    , WorkData[6].ToString()
                    , WorkData[11].ToString()
                    , WorkData[9].ToString()
                    , WorkData[10].ToString()
                    , reader["Generated_Date"].ToString()
                    , reader["Sent_Date"].ToString()
                    , reader["Payment_Due_Date"].ToString()
                    , reader["Status"].ToString()});
                }
                reader.Close();
            }
            else
            {
                InvoiceList = null;
            }

            DBConnect.DropConn(con);
            return InvoiceList;

        }

        public List<String> GetInvoice(int InvoiceID)
        {
            this.Invoice_ID = InvoiceID;
            List<String> InvoiceDetails = new List<string>(13);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetInvoiceDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM INVOICE WHERE Invoice_ID = " + Invoice_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader reader = GetInvoiceDetails.ExecuteReader();

            WorkItem workItem = new WorkItem();

            if (!reader.HasRows)
            {
                InvoiceDetails = null;
            }
            else
            {
                while (reader.Read())
                {

                    _ = new List<string>(12);
                    List<string> WorkData = workItem.GetWorkItem(Convert.ToInt32(reader["Work_ID"]));

                    this.Generated_Date = DateTime.ParseExact(reader["Generated_Date"].ToString()
                        , "M/dd/yyyy hh:mm:ss tt", null).ToString("dd/MM/yyyy");

                    this.Payment_Due_Date = DateTime.ParseExact(reader["Payment_Due_Date"].ToString()
                        , "M/dd/yyyy hh:mm:ss tt", null).ToString("dd/MM/yyyy");

                    InvoiceDetails.Add(reader["Invoice_ID"].ToString());
                    InvoiceDetails.Add(reader["Work_ID"].ToString());
                    InvoiceDetails.Add(WorkData[2].ToString());
                    InvoiceDetails.Add(WorkData[4].ToString());
                    InvoiceDetails.Add(WorkData[6].ToString());
                    InvoiceDetails.Add(WorkData[11].ToString());
                    InvoiceDetails.Add(WorkData[9].ToString());
                    InvoiceDetails.Add(WorkData[10].ToString());
                    InvoiceDetails.Add(Generated_Date);
                    InvoiceDetails.Add(reader["Sent_Date"].ToString());
                    InvoiceDetails.Add(Payment_Due_Date);
                    InvoiceDetails.Add(reader["Status"].ToString());

                }
            }

            DBConnect.DropConn(con);

            return InvoiceDetails;

        }

        public string UpdateInvoice(NameValueCollection UpdateInvoiceData)
        {
            this.Invoice_ID = Convert.ToInt32(UpdateInvoiceData["CtrlInvoiceID"]);
            this.Work_ID = Convert.ToInt32(UpdateInvoiceData["CtrlWorkList"]);
            this.Generated_Date = UpdateInvoiceData["CtrlGenDate"];

            if (UpdateInvoiceData["DropStatus"] == "Sent")
            {
                this.Sent_Date = this.Generated_Date;
            }

            this.Payment_Due_Date = DateTime.ParseExact(
                UpdateInvoiceData["CtrlDueDate"],
                "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.Status = UpdateInvoiceData["DropStatus"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand UpdateInvoice = new SqlCommand
            {
                CommandText = "UPDATE INVOICE SET Work_ID = '" + Work_ID + "', Generated_Date = '" + Generated_Date +
                "', Sent_Date = '" + Sent_Date + "', Payment_Due_Date = '" + Payment_Due_Date +
                "', Status = '" + Status +
                "' WHERE Invoice_ID = " + Invoice_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = UpdateInvoice.ExecuteNonQuery();
                if (result == 0)
                {
                    this.Message = "Query Unsuccessful!";
                }
                else
                {
                    this.Message = "Query Successful!";
                }
            }
            else
            {
                this.Message = "Database Connection Failed!";
            }

            DBConnect.DropConn(con);
            return Message;
        }

        public string DeleteInvoice(int InvoiceID)
        {
            this.Invoice_ID = InvoiceID;

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand DeleteInvoiceDetails = new SqlCommand
            {
                CommandText = "DELETE FROM INVOICE WHERE Invoice_ID = " + Invoice_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = DeleteInvoiceDetails.ExecuteNonQuery();
                if (result == 0)
                {
                    this.Message = "Query Unsuccessful!";
                }
                else
                {
                    this.Message = "Query Successful!";
                }
            }
            else
            {
                this.Message = "Database Connection Failed!";
            }

            DBConnect.DropConn(con);
            return Message;
        }


    }
}