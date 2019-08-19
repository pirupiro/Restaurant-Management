using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class BillDetailDAO
    {
        private static DataProvider provider;

        public static int Insert(ChiTietHoaDon detail)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_AddBillDetail " + detail.MaHoaDon + ", N'" + detail.TenMon + "', " + detail.SoLuong + ", " + detail.ThanhTien;
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static int Update(ChiTietHoaDon detail)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_UpdateBillDetail " + detail.MaHoaDon + ", N'" + detail.TenMon + "', " + detail.SoLuong + ", " + detail.ThanhTien;

            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static ChiTietHoaDon GetBillDetail(ChiTietHoaDon detail)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetBillDetail " + detail.MaHoaDon + ", N'" + detail.TenMon + "'";
            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            ChiTietHoaDon cthd = null;

            if (reader.Read())
            {
                cthd = new ChiTietHoaDon
                {
                    MaHoaDon = reader.GetInt32(0),
                    TenMon = reader.GetString(1),
                    SoLuong = reader.GetInt32(2),
                    ThanhTien = reader.GetInt32(3)
                };
            }

            provider.Disconnect();
            return cthd;
        }

        public static List<ChiTietHoaDon> LoadAll(int maHoaDon)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_LoadAllBillDetails " + maHoaDon;
            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            List<ChiTietHoaDon> billDetailList = new List<ChiTietHoaDon>();

            while (reader.Read())
            {
                billDetailList.Add(new ChiTietHoaDon(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
            }

            provider.Disconnect();
            return billDetailList;
        }

        public static DataTable LoadAllExtendedBillDetails(int maHoaDon)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_LoadAllExtendedBillDetails " + maHoaDon;
            DataTable table = provider.ExcuteQuery(cmdStr);

            provider.Disconnect();
            return table;
        }
    }
}
