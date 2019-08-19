using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class MenuBUS
    {
        public static List<ThucDon> LoadAll(string tenMon="")
        {
            return MenuDAO.LoadAll(tenMon);
        }

        public static int Delete(string tenMon)
        {
            return MenuDAO.Delete(tenMon);
        }

        public static int UpdatePrice(string tenMon, int donGia)
        {
            return MenuDAO.UpdatePrice(tenMon, donGia);
        }

        public static int Insert(ThucDon dish)
        {
            return MenuDAO.Insert(dish);
        }
    }
}
