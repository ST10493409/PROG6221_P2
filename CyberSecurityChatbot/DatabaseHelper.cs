using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CyberSecurityChatbot
{
    public class DatabaseHelper
    {
        private string connectionString =
            "server=localhost;database=CyberSecurityDB;uid=root;pwd=Milne@1002;";

        public void AddTask(CyberTask task)
        {
            using (MySqlConnection conn =
                new MySqlConnection(connectionString))
            {
                conn.Open();

                string query =
                    @"INSERT INTO Tasks
                    (Title, Description, Reminder, Completed)
                    VALUES
                    (@Title, @Description, @Reminder, @Completed)";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Title", task.Title);
                cmd.Parameters.AddWithValue("@Description", task.Description);
                cmd.Parameters.AddWithValue("@Reminder", task.Reminder);
                cmd.Parameters.AddWithValue("@Completed", task.Completed);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
