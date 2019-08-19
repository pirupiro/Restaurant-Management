using DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAO
{
    public class MenuDAO
    {
        private static DataProvider provider;

        public static List<ThucDon> LoadAll(string tenMon="")
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr;

            if (tenMon == string.Empty)
            {
                cmdStr = "Execute proc_LoadAllDishes";
            }
            else
            {
                cmdStr = "Execute proc_LoadAllDishesWithName N'" + tenMon + "'";
            }

            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            List<ThucDon> list = new List<ThucDon>();

            while (reader.Read())
            {
                list.Add(new ThucDon(reader.GetString(0), reader.GetInt32(1), reader.GetString(2)));
            }

            provider.Disconnect();
            return list;
        }

        public static int Delete(string tenMon)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_RemoveDish N'" + tenMon + "'";
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static int UpdatePrice(string tenMon, int donGia)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_UpdateDishPrice N'" + tenMon + "', " + donGia;
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static int Insert(ThucDon dish)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_AddDish N'" + dish.TenMon + "', " + dish.DonGia + ", N'" + dish.DonVi + "'";
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }
    }
}
