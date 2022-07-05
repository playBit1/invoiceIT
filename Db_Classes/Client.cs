using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace invoiceIT.Db_Classes
{
    public class Client
    {
        public int Client_ID { get; set; }
        public string Comp_Name { get; set; }
        public string Comp_Add1 { get; set; }
        public string Comp_Add2 { get; set; }
        public string Comp_Location { get; set; }
        public string Comp_Pcode { get; set; }
        public string Contact_Fname { get; set; }
        public string Contact_Lname { get; set; }
        public string Contact_Email { get; set; }
        public string Contact_Mobile { get; set; }
        public string Bill_To { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }


        public string AddClient(NameValueCollection NewClientData)
        {
            this.Comp_Name = NewClientData["CtrlCompName"];
            this.Comp_Add1 = NewClientData["CtrlCompAdd1"];
            this.Comp_Add2 = NewClientData["CtrlCompAdd2"];
            this.Comp_Location = NewClientData["CtrlCompLocation"];
            this.Comp_Pcode = NewClientData["CtrlCompPcode"];
            this.Contact_Fname = NewClientData["CtrlContactFname"];
            this.Contact_Lname = NewClientData["CtrlContactLname"];
            this.Contact_Email = NewClientData["CtrlContactEmail"];
            this.Contact_Mobile = NewClientData["CtrlContactMobile"];
            this.Bill_To = NewClientData["DropBillTo"];
            this.Status = NewClientData["DropStatus"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand AddClient = new SqlCommand
            {
                CommandText = "INSERT CLIENT (Comp_Name, Comp_Add1, Comp_Add2, Comp_Location, Comp_Pcode, " +
                "Contact_Fname, Contact_Lname, Contact_Email, Contact_Mobile, Bill_To, Status)" +
                "Values ('"+ Comp_Name + "','"+ Comp_Add1 + "','" + Comp_Add2 + "','" + Comp_Location + "','" + Comp_Pcode + "'" +
                ",'" + Contact_Fname + "','" + Contact_Lname + "','" + Contact_Email + "','" + Contact_Mobile + "','" + Bill_To + "'" +
                ",'" + Status + "' )",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = AddClient.ExecuteNonQuery();
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


        public List<List<string>> GetClient()
        {
            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetAllClients = new SqlCommand
            {
                CommandText = "SELECT * FROM CLIENT",
                CommandType = CommandType.Text,
                Connection = con
            };

            List<List<string>> ClientList = new List<List<string>>();

            SqlDataReader reader = GetAllClients.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClientList.Add(new List<string> { reader["Client_ID"].ToString()
                    , reader["Comp_Name"].ToString(), reader["Comp_Add1"].ToString()
                    , reader["Comp_Add2"].ToString(), reader["Comp_Location"].ToString() 
                    , reader["Comp_Pcode"].ToString(), reader["Contact_Fname"].ToString()
                    , reader["Contact_Lname"].ToString(), reader["Contact_Email"].ToString()
                    , reader["Contact_Mobile"].ToString(), reader["Bill_To"].ToString(), reader["Status"].ToString()});
                }
                reader.Close();
            }
            else
            {
                ClientList = null;
            }

            DBConnect.DropConn(con);
            return ClientList;

        }

        public List<String> GetClient(int ClientID)
        {
            this.Client_ID = ClientID;
            List<String> clientdetails = new List<string>(12);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetClientDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM CLIENT WHERE Client_ID = " + Client_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader reader = GetClientDetails.ExecuteReader();

            if (!reader.HasRows)
            {
                clientdetails = null;
            }
            else
            {
                while (reader.Read())
                {
                    clientdetails.Add(reader["Client_ID"].ToString());
                    clientdetails.Add(reader["Comp_Name"].ToString());
                    clientdetails.Add(reader["Comp_Add1"].ToString());
                    clientdetails.Add(reader["Comp_Add2"].ToString());
                    clientdetails.Add(reader["Comp_Location"].ToString());
                    clientdetails.Add(reader["Comp_Pcode"].ToString());
                    clientdetails.Add(reader["Contact_Fname"].ToString());
                    clientdetails.Add(reader["Contact_Lname"].ToString());
                    clientdetails.Add(reader["Contact_Email"].ToString());
                    clientdetails.Add(reader["Contact_Mobile"].ToString());
                    clientdetails.Add(reader["Bill_To"].ToString());
                    clientdetails.Add(reader["Status"].ToString());
                }
            }

            DBConnect.DropConn(con);

            return clientdetails;

        }

        public string UpdateClient(NameValueCollection UpdateClientData)
        {
            this.Client_ID = Convert.ToInt32(UpdateClientData["CtrlClientID"]);
            this.Comp_Name = UpdateClientData["CtrlCompName"];
            this.Comp_Add1 = UpdateClientData["CtrlCompAdd1"];
            this.Comp_Add2 = UpdateClientData["CtrlCompAdd2"];
            this.Comp_Location = UpdateClientData["CtrlCompLocation"];
            this.Comp_Pcode = UpdateClientData["CtrlCompPcode"];
            this.Contact_Fname = UpdateClientData["CtrlContactFname"];
            this.Contact_Lname = UpdateClientData["CtrlContactLname"];
            this.Contact_Email = UpdateClientData["CtrlContactEmail"];
            this.Contact_Mobile = UpdateClientData["CtrlContactMobile"];
            this.Bill_To = UpdateClientData["DropBillTo"];
            this.Status = UpdateClientData["DropStatus"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand UpdateClient = new SqlCommand
            {
                CommandText = "UPDATE CLIENT SET Comp_Name = '" + Comp_Name + "', Comp_Add1 = '" + Comp_Add1 + 
                "', Comp_Add2 = '" + Comp_Add2 + "', Comp_Location = '" + Comp_Location +
                "', Comp_Pcode = '" + Comp_Pcode + "', Contact_Fname = '" + Contact_Fname + 
                "', Contact_Lname = '" + Contact_Lname + "', Contact_Email = '" + Contact_Email +
                "', Contact_Mobile = '" + Contact_Mobile + "', Bill_To = '" + Bill_To + "', Status = '" + Status + 
                "' WHERE Client_ID = " + Client_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = UpdateClient.ExecuteNonQuery();
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


        public string DeleteClient(int ClientID)
        {
            this.Client_ID = ClientID;

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand DeleteClientDetails = new SqlCommand
            {
                CommandText = "DELETE FROM CLIENT WHERE Client_ID = " + Client_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = DeleteClientDetails.ExecuteNonQuery();
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