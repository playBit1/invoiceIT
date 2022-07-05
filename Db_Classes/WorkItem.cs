using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace invoiceIT.Db_Classes
{
    public class WorkItem
    {
        public int Work_ID { get; set; }
        public int Client_ID { get; set; }
        public int Staff_ID { get; set; }
        public int Task_ID { get; set; }
        public string Start_Date { get; set; }
        public string Completed_Date { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string Message { get; set; }

        public string AddWorkItem(NameValueCollection NewWorkItemData)
        {
            this.Client_ID = Convert.ToInt32(NewWorkItemData["CtrlClientList"]);
            this.Staff_ID = Convert.ToInt32(NewWorkItemData["CtrlStaffList"]);
            this.Task_ID = Convert.ToInt32(NewWorkItemData["CtrlTaskList"]);
            this.Start_Date = DateTime.ParseExact(
                NewWorkItemData["CtrlStartDate"], 
                "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.Completed_Date = DateTime.ParseExact(
                NewWorkItemData["CtrlCompletedDate"],
                "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.Start_Time = NewWorkItemData["CtrlStartTime"];
            this.End_Time = NewWorkItemData["CtrlEndTime"];
            this.Status = NewWorkItemData["DropStatus"];
            this.Comment = NewWorkItemData["CtrlComment"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand AddWorkItem = new SqlCommand
            {
                CommandText = "INSERT WORKITEM (Client_ID, Staff_ID, Task_ID, Start_Date, Completed_Date, " +
                "Start_Time, End_Time, Status, Comment)" +
                "Values ('" + Client_ID + "','" + Staff_ID + "','" + Task_ID + "','" + Start_Date + 
                "','" + Completed_Date + "','" + Start_Time + "','" + End_Time + 
                "','" + Status + "','" + Comment + "' )",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = AddWorkItem.ExecuteNonQuery();
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


        public List<List<string>> GetWorkItemFor(int StaffID)
        {
            SqlConnection con = DBConnect.MakeConn();

            this.Staff_ID = StaffID;
            SqlCommand GetAllWorkItems = new SqlCommand
            {
                CommandText = "SELECT * FROM WORKITEM WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            Client client = new Client();
            Staff staff = new Staff();
            Task task = new Task();

            List<List<string>> WorkItemList = new List<List<string>>();

            SqlDataReader reader = GetAllWorkItems.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _ = new List<string>(12);
                    List<string> ClientData = client.GetClient(Convert.ToInt32(reader["Client_ID"]));
                    _ = new List<string>(8);
                    List<string> StaffData = staff.GetStaff(Convert.ToInt32(reader["Staff_ID"]));
                    _ = new List<string>(4);
                    List<string> TaskData = task.GetTask(Convert.ToInt32(reader["Task_ID"]));

                    string s = Convert.ToDateTime(reader["Start_Date"].ToString()).ToString("d");

                    this.Start_Date = Convert.ToDateTime(s).ToString("dd/MM/yyyy");

                    string si = Convert.ToDateTime(reader["Completed_Date"].ToString()).ToString("d");

                    this.Completed_Date = Convert.ToDateTime(si).ToString("dd/MM/yyyy");

                    WorkItemList.Add(new List<string> { reader["Work_ID"].ToString()
                    , reader["Client_ID"].ToString(), ClientData[1], reader["Staff_ID"].ToString()
                    , StaffData[2], reader["Task_ID"].ToString(), TaskData[1], Start_Date, Completed_Date
                    , reader["Start_Time"].ToString(), reader["End_Time"].ToString()
                    , reader["Status"].ToString(), reader["Comment"].ToString()});
                }
                reader.Close();
            }
            else
            {
                WorkItemList = null;
            }

            DBConnect.DropConn(con);
            return WorkItemList;

        }



        public List<List<string>> GetWorkItem()
        {
            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetAllWorkItems = new SqlCommand
            {
                CommandText = "SELECT * FROM WORKITEM",
                CommandType = CommandType.Text,
                Connection = con
            };

            Client client = new Client();
            Staff staff = new Staff();
            Task task = new Task();

            List<List<string>> WorkItemList = new List<List<string>>();

            SqlDataReader reader = GetAllWorkItems.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _ = new List<string>(12);
                    List<string> ClientData = client.GetClient(Convert.ToInt32(reader["Client_ID"]));
                    _ = new List<string>(8);
                    List<string> StaffData = staff.GetStaff(Convert.ToInt32(reader["Staff_ID"]));
                    _ = new List<string>(4);
                    List<string> TaskData = task.GetTask(Convert.ToInt32(reader["Task_ID"]));

                    string s = Convert.ToDateTime(reader["Start_Date"].ToString()).ToString("d");

                    this.Start_Date = Convert.ToDateTime(s).ToString("dd/MM/yyyy");

                    string si = Convert.ToDateTime(reader["Completed_Date"].ToString()).ToString("d");

                    this.Completed_Date = Convert.ToDateTime(si).ToString("dd/MM/yyyy");

                    WorkItemList.Add(new List<string> { reader["Work_ID"].ToString()
                    , reader["Client_ID"].ToString(), ClientData[1], reader["Staff_ID"].ToString()
                    , StaffData[2], reader["Task_ID"].ToString(), TaskData[1], Start_Date, Completed_Date
                    , reader["Start_Time"].ToString(), reader["End_Time"].ToString()
                    , reader["Status"].ToString(), reader["Comment"].ToString()});
                }
                reader.Close();
            }
            else
            {
                WorkItemList = null;
            }

            DBConnect.DropConn(con);
            return WorkItemList;

        }

        public List<String> GetWorkItem(int WorkItem)
        {
            this.Work_ID = WorkItem;
            List<String> WorkItemdetails = new List<string>(13);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetWorkItemDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM WORKITEM WHERE Work_ID = " + Work_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            Client client = new Client();
            Staff staff = new Staff();
            Task task = new Task();

            SqlDataReader reader = GetWorkItemDetails.ExecuteReader();

            if (!reader.HasRows)
            {
                WorkItemdetails = null;
            }
            else
            {
                while (reader.Read())
                {
                    _ = new List<string>(12);
                    List<string> ClientData = client.GetClient(Convert.ToInt32(reader["Client_ID"]));
                    _ = new List<string>(8);
                    List<string> StaffData = staff.GetStaff(Convert.ToInt32(reader["Staff_ID"]));
                    _ = new List<string>(4);
                    List<string> TaskData = task.GetTask(Convert.ToInt32(reader["Task_ID"]));

                    string s = Convert.ToDateTime(reader["Start_Date"].ToString()).ToString("d");

                    this.Start_Date = Convert.ToDateTime(s).ToString("dd/MM/yyyy");

                    string si = Convert.ToDateTime(reader["Completed_Date"].ToString()).ToString("d");

                    this.Completed_Date = Convert.ToDateTime(si).ToString("dd/MM/yyyy");

                    /* [0] Work ID
                     * [1] Client ID
                     * [2] Client Name
                     * [3] Staff ID
                     * [4] Staff Name
                     * [5] Task ID
                     * [6] Task Name
                     * [7] Work Start Date
                     * [8] Work Completed Date
                     * [9] Work Start Time
                     * [10] Work Completed Time
                     * [11] Work Status
                     * [12] Work Comment
                    */

                    WorkItemdetails.Add(reader["Work_ID"].ToString());
                    WorkItemdetails.Add(reader["Client_ID"].ToString());
                    WorkItemdetails.Add(ClientData[1].ToString());
                    WorkItemdetails.Add(reader["Staff_ID"].ToString());
                    WorkItemdetails.Add(StaffData[3].ToString());
                    WorkItemdetails.Add(reader["Task_ID"].ToString());
                    WorkItemdetails.Add(TaskData[1].ToString());
                    WorkItemdetails.Add(Start_Date);
                    WorkItemdetails.Add(Completed_Date);
                    WorkItemdetails.Add(reader["Start_Time"].ToString());
                    WorkItemdetails.Add(reader["End_Time"].ToString());
                    WorkItemdetails.Add(reader["Status"].ToString());
                    WorkItemdetails.Add(reader["Comment"].ToString());
                }
            }

            DBConnect.DropConn(con);

            return WorkItemdetails;

        }

        public string UpdateWorkItem(NameValueCollection UpdateWorkItem)
        {
            this.Work_ID = Convert.ToInt32(UpdateWorkItem["CtrlWorkID"]);
            this.Client_ID = Convert.ToInt32(UpdateWorkItem["CtrlClientID"]);
            this.Staff_ID = Convert.ToInt32(UpdateWorkItem["CtrlStaffList"]);
            this.Task_ID = Convert.ToInt32(UpdateWorkItem["CtrlTaskList"]);
            this.Start_Date = DateTime.ParseExact(
                UpdateWorkItem["CtrlStartDate"],
                "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.Completed_Date = DateTime.ParseExact(
                UpdateWorkItem["CtrlCompletedDate"],
                "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.Start_Time = UpdateWorkItem["CtrlStartTime"];
            this.End_Time = UpdateWorkItem["CtrlEndTime"];
            this.Status = UpdateWorkItem["DropStatus"];
            this.Comment = UpdateWorkItem["CtrlComment"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand UpdateClient = new SqlCommand
            {
                CommandText = "UPDATE WORKITEM SET Client_ID = '" + Client_ID + "', Staff_ID = '" + Staff_ID +
                "', Task_ID = '" + Task_ID + "', Start_Date = '" + Start_Date +
                "', Completed_Date = '" + Completed_Date + "', Start_Time = '" + Start_Time +
                "', End_Time = '" + End_Time + "', Status = '" + Status +
                "', Comment = '" + Comment +
                "' WHERE Work_ID = " + Work_ID,
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

        public string DeleteWorkItem(int WorkItemID)
        {
            this.Work_ID = WorkItemID;

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand DeleteWorkItemDetails = new SqlCommand
            {
                CommandText = "DELETE FROM WORKITEM WHERE Work_ID = " + Work_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = DeleteWorkItemDetails.ExecuteNonQuery();
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