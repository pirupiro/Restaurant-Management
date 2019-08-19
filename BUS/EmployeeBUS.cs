using DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class EmployeeBUS
    {
        public static NhanVien GetEmployee(int maNhanVien)
        {
            return EmployeeDAO.GetEmployee(maNhanVien);
        }

        public static List<NhanVien> LoadAll(string tenNhanVien="", bool viewOldEmployees=false)
        {
            return EmployeeDAO.LoadAll(tenNhanVien, viewOldEmployees);
        }

        public static int Delete(int maNhanVien)
        {
            return EmployeeDAO.Delete(maNhanVien);
        }

        public static int Update(NhanVien employee)
        {
            return EmployeeDAO.Update(employee);
        }

        public static int Insert(NhanVien employee)
        {
            return EmployeeDAO.Insert(employee);
        }
    }
}
