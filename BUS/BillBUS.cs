using System;
using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS
{
    public class BillBUS
    {
        public static int Insert(HoaDon hoadon)
        {
            return BillDAO.Insert(hoadon);
        }

        public static HoaDon GetLastBill(int maBan)
        {
            return BillDAO.GetLastBill(maBan);
        }

        public static int UpdateInvoicingTime(HoaDon hoaDon)
        {
            return BillDAO.UpdateInvoicingTime(hoaDon);
        }

        public static int UpdateTotalPrice(HoaDon bill)
        {
            return BillDAO.UpdateTotalPrice(bill);
        }

        public static List<HoaDon> LoadAll(int pageNumber, int billsPerPage)
        {
            return BillDAO.LoadAll(pageNumber, billsPerPage);
        }

        public static List<HoaDon> LoadAllByTime(int pageNumer, int billsPerPage, DateTime from, DateTime to)
        {
            return BillDAO.LoadAllByTime(pageNumer, billsPerPage, from, to);
        }

        public static HoaDon GetBill(int maHoaDon)
        {
            return BillDAO.GetBill(maHoaDon);
        }

        public static int GetMaxPageNumber(int billsPerPage)
        {
            int numOfBills = BillDAO.GetNumberOfBills();
            return (int)Math.Ceiling((double)numOfBills / billsPerPage);
        }

        public static int GetMaxPageNumberByTime(int billsPerPage, DateTime from, DateTime to)
        {
            int numOfBills = BillDAO.GetNumberOfBillsByTime(from, to);
            return (int)Math.Ceiling((double)numOfBills / billsPerPage);
        }

        public static int GetMinYear()
        {
            return BillDAO.GetMinYear();
        }

        public static int GetMaxYear()
        {
            return BillDAO.GetMaxYear();
        }

        public static int GetTotalByDay(int day, int month, int year)
        {
            return BillDAO.GetTotalPriceByDay(day, month, year);
        }

        public static int GetTotalByMonth(int month, int year)
        {
            return BillDAO.GetTotalPriceByMonth(month, year);
        }

        public static int GetTotalByYear(int year)
        {
            return BillDAO.GetTotalPriceByYear(year);
        }
    }
}
