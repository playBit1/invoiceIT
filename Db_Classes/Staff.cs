using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace invoiceIT.Db_Classes
{
    public class Staff
    {

        public int Staff_ID { get; set; }
        public string Password { get; set; }
        public string F_Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Access_Level { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }


        public string AddStaff(NameValueCollection NewStaffData)
        {
            this.Password = NewStaffData["CtrlPassword"];
            this.F_Name = NewStaffData["CtrlFName"];
            this.Surname = NewStaffData["CtrlSurname"];
            this.Email = NewStaffData["CtrlEmail"];
            this.Mobile = NewStaffData["CtrlMobile"];
            this.Access_Level = NewStaffData["DropAccessLevel"];
            this.Status = NewStaffData["DropStatus"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand AddStaff = new SqlCommand
            {
                CommandText = "INSERT STAFF (Password, F_Name, Surname, Email, " +
                "Mobile, Access_Level, Status)" +
                "Values ('" + Password + "','" + F_Name + "','" + Surname + "','" + Email + "'" +
                ",'" + Mobile + "','" + Access_Level + "','" + Status + "' )",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = AddStaff.ExecuteNonQuery();
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

        public List<List<string>> GetStaff()
        {
            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetAllStaff = new SqlCommand
            {
                CommandText = "SELECT * FROM STAFF",
                CommandType = CommandType.Text,
                Connection = con
            };

            List<List<string>> StaffList = new List<List<string>>();

            SqlDataReader reader = GetAllStaff.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    StaffList.Add(new List<string> { reader["Staff_ID"].ToString()
                    , reader["Password"].ToString()
                    , reader["F_Name"].ToString(), reader["Surname"].ToString()
                    , reader["Email"].ToString(), reader["Mobile"].ToString()
                    , reader["Access_Level"].ToString(), reader["Status"].ToString()});
                }
                reader.Close();
            }
            else
            {
                StaffList = null;
            }

            DBConnect.DropConn(con);
            return StaffList;

        }

        public List<String> GetStaff(int StaffID)
        {
            this.Staff_ID = StaffID;
            List<String> StaffDetails = new List<string>(8);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetStaffDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM STAFF WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader reader = GetStaffDetails.ExecuteReader();

            if (!reader.HasRows)
            {
                StaffDetails = null;
            }
            else
            {
                while (reader.Read())
                {
                    StaffDetails.Add(reader["Staff_ID"].ToString());
                    StaffDetails.Add(reader["Password"].ToString());
                    StaffDetails.Add(reader["F_Name"].ToString());
                    StaffDetails.Add(reader["Surname"].ToString());
                    StaffDetails.Add(reader["Email"].ToString());
                    StaffDetails.Add(reader["Mobile"].ToString());
                    StaffDetails.Add(reader["Access_Level"].ToString());
                    StaffDetails.Add(reader["Status"].ToString());

                }
            }

            DBConnect.DropConn(con);

            return StaffDetails;

        }

        public List<String> GetStaff(string UserEmail, string UserPassword)
        {
            this.Email = UserEmail;
            this.Password = UserPassword;

            List<String> AccountDetails = new List<string>(3);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetStaffDetails = new SqlCommand
            {
                CommandText = "SELECT F_Name, Access_Level, Staff_ID FROM STAFF WHERE Email = '" + Email +
                "' AND Password = '" + Password + "'",
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader reader = GetStaffDetails.ExecuteReader();

            if (!reader.HasRows)
            {
                AccountDetails = null;
            }
            else
            {
                while (reader.Read())
                {
                    AccountDetails.Add(reader["F_Name"].ToString());
                    AccountDetails.Add(reader["Access_Level"].ToString());
                    AccountDetails.Add(reader["Staff_ID"].ToString());
                }
            }

            DBConnect.DropConn(con);

            return AccountDetails;

        }


        public string UpdateStaff(NameValueCollection UpdateStaffData)
        {
            this.Staff_ID = Convert.ToInt32(UpdateStaffData["CtrlStaffID"]);
            this.Password = UpdateStaffData["CtrlPassword"];
            this.F_Name = UpdateStaffData["CtrlFName"];
            this.Surname = UpdateStaffData["CtrlSurname"];
            this.Email = UpdateStaffData["CtrlEmail"];
            this.Mobile = UpdateStaffData["CtrlMobile"];
            this.Access_Level = UpdateStaffData["DropAccessLevel"];
            this.Status = UpdateStaffData["DropStatus"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand UpdateStaff = new SqlCommand
            {
                CommandText = "UPDATE STAFF SET Password = '" + Password +
                "', F_Name = '" + F_Name + "', Surname = '" + Surname +
                "', Email = '" + Email + "', Mobile = '" + Mobile +
                "', Access_Level = '" + Access_Level + "', Status = '" + Status +
                "' WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = UpdateStaff.ExecuteNonQuery();
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

        public string DeleteStaff(int StaffID)
        {
            this.Staff_ID = StaffID;

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand DeleteStaffDetails = new SqlCommand
            {
                CommandText = "DELETE FROM STAFF WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = DeleteStaffDetails.ExecuteNonQuery();
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