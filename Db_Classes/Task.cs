using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace invoiceIT.Db_Classes
{
    public class Task
    {
        public int Task_ID { get; set; }
        public string Task_Title { get; set; }
        public string Task_Description { get; set; }
        public string Task_Rate { get; set; }
        public string Message { get; set; }

        public string AddTask(NameValueCollection NewTaskData)
        {
            this.Task_Title = NewTaskData["CtrlTaskTitle"];
            this.Task_Description = NewTaskData["CtrlTaskDesc"];
            this.Task_Rate = NewTaskData["CtrlTaskRate"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand AddTask = new SqlCommand
            {
                CommandText = "INSERT TASK (Task_Title, Task_Description, Task_Rate)" +
                "VALUES ('" + Task_Title + "','" + Task_Description + "','" + Task_Rate + "')",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = AddTask.ExecuteNonQuery();
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


        public List<List<string>> GetTask()
        {
            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetAllTasks = new SqlCommand
            {
                CommandText = "SELECT * FROM TASK",
                CommandType = CommandType.Text,
                Connection = con
            };

            List<List<string>> TaskList = new List<List<string>>();

            SqlDataReader reader = GetAllTasks.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TaskList.Add(new List<string> { reader["Task_ID"].ToString()
                    , reader["Task_Title"].ToString(), reader["Task_Description"].ToString()
                    , reader["Task_Rate"].ToString()});
                }
                reader.Close();
            }
            else
            {
                TaskList = null;
            }

            DBConnect.DropConn(con);
            return TaskList;

        }


        public List<string> GetTask(int TaskID)
        {
            this.Task_ID = TaskID;
            List<String> TaskDetails = new List<string>(4);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetTaskDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM TASK WHERE Task_ID = " + Task_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader reader = GetTaskDetails.ExecuteReader();

            if (!reader.HasRows)
            {
                TaskDetails = null;
            }
            else
            {
                while (reader.Read())
                {
                    TaskDetails.Add(reader["Task_ID"].ToString());
                    TaskDetails.Add(reader["Task_Title"].ToString());
                    TaskDetails.Add(reader["Task_Description"].ToString());
                    TaskDetails.Add(reader["Task_Rate"].ToString());
                }
            }

            DBConnect.DropConn(con);

            return TaskDetails;
        }


        public string UpdateTask(NameValueCollection UpdateTaskData)
        {
            this.Task_ID = Convert.ToInt32(UpdateTaskData["CtrlTaskID"]);
            this.Task_Title = UpdateTaskData["CtrlTaskTitle"];
            this.Task_Description = UpdateTaskData["CtrlTaskDesc"];
            this.Task_Rate = UpdateTaskData["CtrlTaskRate"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand UpdateTask = new SqlCommand
            {
                CommandText = "UPDATE TASK SET Task_Title = '" + Task_Title + "', Task_Description = '" + Task_Description +
                "', Task_Rate = '" + Task_Rate + "' WHERE Task_ID = " + Task_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = UpdateTask.ExecuteNonQuery();
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

        public string DeleteTask(int TaskID)
        {
            this.Task_ID = TaskID;

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand DeleteTaskDetails = new SqlCommand
            {
                CommandText = "DELETE FROM TASK WHERE Task_ID = " + Task_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int result = DeleteTaskDetails.ExecuteNonQuery();
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