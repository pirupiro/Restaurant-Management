using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class TableBUS
    {
        public static List<Ban> LoadAll()
        {
            return TableDAO.LoadAll();
        }

        public static int UpdateStatus(Ban ban)
        {
            return TableDAO.UpdateStatus(ban);
        }

        public static int GetNumberOfTables()
        {
            return TableDAO.GetNumberOfTables();
        }

        public static void Insert(int start, int count)
        {
            TableDAO.Insert(start, count);
        }

        public static int Delete(int numOfTables)
        {
            return TableDAO.Delete(numOfTables);
        }
    }
}
