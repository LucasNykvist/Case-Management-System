using Microsoft.Data.SqlClient;

namespace CMS.Services
{
    internal class CombinerService
    {
        static SqlConnection GetSqlConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lukep\Documents\Case Database.mdf"";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public void CombineClientTask(int ClientID, int TaskID)
        {
            using (SqlConnection connection = GetSqlConnection())
            {
                connection.Open();
                string Query = "INSERT INTO Cases (ClientID, TaskID) VALUES (@ClientID, @TaskID)";
                using (SqlCommand command = new SqlCommand(Query, connection)) 
                {
                    command.Parameters.AddWithValue("@ClientID", ClientID);
                    command.Parameters.AddWithValue("@TaskID", TaskID);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Case Has Been Added...");
                }
            }
        }
    }
}
