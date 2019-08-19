using DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAO
{
    public class EmployeeDAO
    {
        private static DataProvider provider;

        public static NhanVien GetEmployee(int maNhanVien)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetEmployee " + maNhanVien;
            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            NhanVien employee = new NhanVien();

            if (reader.Read())
            {
                employee.MaNhanVien = reader.GetInt32(0);
                employee.HoTen = reader.GetString(1);
                employee.NgaySinh = reader.GetDateTime(2);
                employee.GioiTinh = reader.GetString(3);
                employee.DiaChi = reader.GetString(4);
                employee.SoDienThoai = reader.GetString(5);
                employee.NgayVaoLam = reader.GetDateTime(6);
                employee.ChucVu = reader.GetString(7);
                employee.Luong = reader.GetInt32(8);
            }

            provider.Disconnect();
            return employee;
        }

        public static List<NhanVien> LoadAll(string tenNhanVien="", bool viewOldEmployees=false)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr;

            if (viewOldEmployees)
            {
                if (tenNhanVien == string.Empty)
                {
                    cmdStr = "Execute proc_LoadAllOldEmployees";
                }
                else
                {
                    cmdStr = "Execute proc_LoadAllOldEmployeesWithName N'" + tenNhanVien + "'";
                }
            }
            else
            {
                if (tenNhanVien == string.Empty)
                {
                    cmdStr = "Execute proc_LoadAllEmployees";
                }
                else
                {
                    cmdStr = "Execute proc_LoadAllEmployeesWithName N'" + tenNhanVien + "'";
                }
            }
                
            List<NhanVien> employeeList = new List<NhanVien>();
            SqlDataReader reader = provider.ExecuteReader(cmdStr);

            while (reader.Read())
            {
                NhanVien employee = new NhanVien();
                employee.MaNhanVien = reader.GetInt32(0); 
                employee.HoTen = reader.GetString(1);
                employee.NgaySinh = reader.GetDateTime(2);
                employee.GioiTinh = reader.GetString(3);
                employee.DiaChi = reader.GetString(4);
                employee.SoDienThoai = reader.GetString(5);
                employee.NgayVaoLam = reader.GetDateTime(6);
                employee.ChucVu = reader.GetString(7);
                employee.Luong = reader.GetInt32(8);
                employeeList.Add(employee);
            }

            provider.Disconnect();
            return employeeList;
        }

        public static int Delete(int maNhanVien)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_RemoveEmployee " + maNhanVien;
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static int Update(NhanVien employee)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_UpdateEmployee " + employee.MaNhanVien + ", "
                                                           + "N'" + employee.HoTen + "', "
                                                           + "'" + employee.NgaySinh.ToString("yyyy-MM-dd") + "', "
                                                           + "N'" + employee.GioiTinh + "', "
                                                           + "N'" + employee.DiaChi + "', "
                                                           + "'" + employee.SoDienThoai + "', "
                                                           + "'" + employee.NgayVaoLam.ToString("yyyy-MM-dd") + "', "
                                                           + "N'" + employee.ChucVu + "', "
                                                           + employee.Luong;

            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static int Insert(NhanVien employee)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_AddEmployee N'" + employee.HoTen + "', "
                                                          + "'" + employee.NgaySinh.ToString("yyyy-MM-dd") + "', "
                                                          + "N'" + employee.GioiTinh + "', "
                                                          + "N'" + employee.DiaChi + "', "
                                                          + "'" + employee.SoDienThoai + "', "
                                                          + "'" + employee.NgayVaoLam.ToString("yyyy-MM-dd") + "', "
                                                          + "N'" + employee.ChucVu + "', "
                                                          + employee.Luong;

            int result = provider.ExecuteNonQuery(cmdStr);
            
            provider.Disconnect();
            return result;
        }
    }
}
