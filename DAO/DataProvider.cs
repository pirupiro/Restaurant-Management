using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DataProvider
    {
        private string conStr = @"Data Source=.;Initial Catalog=QUANLYQUANAN;Integrated Security=True";
        SqlConnection connection;

        public DataProvider()
        {
            connection = new SqlConnection(conStr);
        }

        public void Connect()
        {
            connection.Open();
        }

        public void Disconnect()
        {
            connection.Close();
        }

        public DataTable ExcuteQuery(string cmdStr)
        {
            SqlCommand cmd = new SqlCommand(cmdStr, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public int ExecuteNonQuery(string cmdStr)
        {
            SqlCommand cmd = new SqlCommand(cmdStr, connection);
            return cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string cmdStr)
        {
            SqlCommand cmd = new SqlCommand(cmdStr, connection);
            return cmd.ExecuteReader();
        }

        public object ExecuteScalar(string cmdStr)
        {
            SqlCommand cmd = new SqlCommand(cmdStr, connection);
            return cmd.ExecuteScalar();
        }
    }
}
