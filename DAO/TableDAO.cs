using DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAO
{
    public class TableDAO
    {
        private static DataProvider provider = new DataProvider();

        public static List<Ban> LoadAll()
        {
            provider.Connect();

            string cmdStr = "Execute proc_LoadAllTables";
            List<Ban> list = new List<Ban>();
            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            
            while (reader.Read())
            {
                list.Add(new Ban(reader.GetInt32(0), reader.GetString(1)));
            }

            provider.Disconnect();
            return list;
        }

        public static int UpdateStatus(Ban ban)
        {
            provider.Connect();

            string cmdStr = "Execute proc_UpdateStatus " + ban.MaBan + ", N'" + ban.TinhTrang + "'";
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static int GetNumberOfTables()
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetNumberOfTables";
            int numOfTables = (int)provider.ExecuteScalar(cmdStr);

            provider.Disconnect();
            return numOfTables;
        }

        public static void Insert(int start, int count)
        {
            provider = new DataProvider();
            provider.Connect();
            
            for (int tableID = start + 1; tableID <= start + count; tableID++)
            {
                string cmdStr = "Execute proc_AddTable " + tableID;
                provider.ExecuteNonQuery(cmdStr);
            }

            provider.Disconnect();
        }

        public static int Delete(int numOfTables)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_RemoveTable " + numOfTables;
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }
    }
}
