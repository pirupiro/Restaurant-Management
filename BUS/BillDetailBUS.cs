using System.Collections.Generic;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class BillDetailBUS
    {
        public static int Insert(ChiTietHoaDon cthd)
        {
            return BillDetailDAO.Insert(cthd);
        }

        public static int Update(ChiTietHoaDon detail)
        {
            return BillDetailDAO.Update(detail);
        }

        public static ChiTietHoaDon GetBillDetail(ChiTietHoaDon detail)
        {
            return BillDetailDAO.GetBillDetail(detail);
        }

        public static List<ChiTietHoaDon> LoadAll(int maHoaDon)
        {
            return BillDetailDAO.LoadAll(maHoaDon);
        }

        public static DataTable LoadAllExtendedBillDetails(int maHoaDon)
        {
            return BillDetailDAO.LoadAllExtendedBillDetails(maHoaDon);
        }
    }
}
