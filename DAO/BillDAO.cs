using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAO
{
    public class BillDAO
    {
        private static DataProvider provider;

        public static int Insert(HoaDon hoadon)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_AddBill " + hoadon.MaBan + ", " + hoadon.MaNhanVien + ", " + hoadon.TongTien;
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static HoaDon GetLastBill(int maBan)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetLastBill " + maBan;
            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            HoaDon bill = new HoaDon();

            if (reader.Read())
            {
                bill.MaHoaDon = reader.GetInt32(0);
                bill.MaBan = reader.GetInt32(1);
                bill.MaNhanVien = reader.GetInt32(2);

                if (!reader.IsDBNull(3))
                    bill.ThoiGianLap = reader.GetDateTime(3);

                bill.TongTien = reader.GetInt32(4);
            }

            provider.Disconnect();
            return bill;
        }

        public static int UpdateInvoicingTime(HoaDon hoaDon)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_UpdateInvoicingTime " + hoaDon.MaHoaDon;
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static int UpdateTotalPrice(HoaDon bill)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_UpdateTotalPrice " + bill.MaHoaDon + ", " + bill.TongTien;
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static List<HoaDon> LoadAll(int pageNumber, int billsPerPage)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_LoadAllBills " + pageNumber + ", " + billsPerPage;
            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            List<HoaDon> billList = new List<HoaDon>();

            while (reader.Read())
            {
                int maHoaDon = reader.GetInt32(0);
                int maBan = reader.GetInt32(1);
                int maNhanVen = reader.GetInt32(2);
                DateTime? thoiGianLap;

                if (!reader.IsDBNull(3))
                {
                    thoiGianLap = reader.GetDateTime(3);
                }
                else
                {
                    thoiGianLap = null;
                }

                int tongTien = reader.GetInt32(4);

                billList.Add(new HoaDon(maHoaDon, maBan, maNhanVen, thoiGianLap, tongTien));
            }

            provider.Disconnect();
            return billList;
        }

        public static List<HoaDon> LoadAllByTime(int pageNumber, int billsPerPage, DateTime from, DateTime to)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_LoadAllBillsByTime " + pageNumber + ", " + billsPerPage + ", '" + from.ToString("yyyy-MM-dd") + "', '" + to.ToString("yyyy-MM-dd") + "'";
            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            List<HoaDon> billList = new List<HoaDon>();

            while (reader.Read())
            {
                int maHoaDon = reader.GetInt32(0);
                int maBan = reader.GetInt32(1);
                int maNhanVen = reader.GetInt32(2);
                DateTime? thoiGianLap;

                if (!reader.IsDBNull(3))
                {
                    thoiGianLap = reader.GetDateTime(3);
                }
                else
                {
                    thoiGianLap = null;
                }

                int tongTien = reader.GetInt32(4);

                billList.Add(new HoaDon(maHoaDon, maBan, maNhanVen, thoiGianLap, tongTien));
            }

            provider.Disconnect();
            return billList;
        }

        public static HoaDon GetBill(int maHoaDon)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetBill " + maHoaDon;
            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            HoaDon bill = null;

            if (reader.Read())
            {
                DateTime? thoiGianLap;

                if (!reader.IsDBNull(3))
                {
                    thoiGianLap = reader.GetDateTime(3);
                }
                else
                {
                    thoiGianLap = null;
                }

                bill = new HoaDon
                {
                    MaHoaDon = reader.GetInt32(0),
                    MaBan = reader.GetInt32(1),
                    MaNhanVien = reader.GetInt32(2),
                    ThoiGianLap = thoiGianLap,
                    TongTien = reader.GetInt32(4)
                };
            }

            provider.Disconnect();
            return bill;
        }

        public static int GetNumberOfBills()
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetNumberOfBills";
            int numOfBills = (int)provider.ExecuteScalar(cmdStr);

            provider.Disconnect();
            return numOfBills;
        }

        public static int GetNumberOfBillsByTime(DateTime from, DateTime to)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetNumberOfBillsByTime '" + from.ToString("yyyy-MM-dd") + "', '" + to.ToString("yyyy-MM-dd") + "'";
            int numOfBills = (int)provider.ExecuteScalar(cmdStr);

            provider.Disconnect();
            return numOfBills;
        }

        public static int GetMinYear()
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetMinYear";
            object result = provider.ExecuteScalar(cmdStr);
            int minYear = result == DBNull.Value ? DateTime.Today.Year : (int)result;
            
            provider.Disconnect();
            return minYear;
        }

        public static int GetMaxYear()
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetMaxYear";
            object result = provider.ExecuteScalar(cmdStr);
            int maxYear = result == DBNull.Value ? DateTime.Today.Year : (int)result;

            provider.Disconnect();
            return maxYear;
        }

        public static int GetTotalPriceByDay(int day, int month, int year)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetTotalPriceByDay " + day + ", " + month + ", " + year;
            int total;
            object totalObject = provider.ExecuteScalar(cmdStr);
            total = totalObject == DBNull.Value ? 0 : (int)totalObject;
            provider.Disconnect();
            return total;
        }

        public static int GetTotalPriceByMonth(int month, int year)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetTotalPriceByMonth " + month + ", " + year;
            int total;
            object totalObject = provider.ExecuteScalar(cmdStr);
            total = totalObject == DBNull.Value ? 0 : (int)totalObject;
            provider.Disconnect();
            return total;
        }

        public static int GetTotalPriceByYear(int year)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetTotalPriceByYear " + year;
            int total;
            object totalObject = provider.ExecuteScalar(cmdStr);
            total = totalObject == DBNull.Value ? 0 : (int)totalObject;
            provider.Disconnect();
            return total;
        }
    }
}
