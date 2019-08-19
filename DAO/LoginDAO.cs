using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class LoginDAO
    {
        private static DataProvider provider;

        public static bool Has(string taiKhoan, string matKhau)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_CheckAccount '" + taiKhoan + "', '" + matKhau + "'";
            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            bool result = reader.HasRows;
            
            provider.Disconnect();
            return result;
        }

        public static int UpdatePassword(string taiKhoan, string matKhau)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_UpdatePassword '" + taiKhoan + "', '" + matKhau + "'";
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static DangNhap GetAccount(string taiKhoan)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_GetAccount '" + taiKhoan + "'";
            SqlDataReader reader = provider.ExecuteReader(cmdStr);
            DangNhap login = new DangNhap();

            if (reader.Read())
            {
                login.TaiKhoan = reader.GetString(0);
                login.MatKhau = reader.GetString(1);
                login.MaNhanVien = reader.GetInt32(2);
            }

            provider.Disconnect();
            return login;
        }

        public static int DeleteAccount(string taiKhoan)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_DeleteAccont '" + taiKhoan + "'";
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static int CreateAccount(DangNhap dangNhap)
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_CreateAccount '" + dangNhap.TaiKhoan + "', '" + dangNhap.MatKhau + "', " + dangNhap.MaNhanVien;
            int result = provider.ExecuteNonQuery(cmdStr);

            provider.Disconnect();
            return result;
        }

        public static DataTable LoadAll()
        {
            provider = new DataProvider();
            provider.Connect();

            string cmdStr = "Execute proc_LoadAllAccounts";
            DataTable table = provider.ExcuteQuery(cmdStr);

            provider.Disconnect();
            return table;
        }
    }
}
