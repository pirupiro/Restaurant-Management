using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class LoginBUS
    {
        public static bool Has(string taiKhoan, string matKhau)
        {
            return LoginDAO.Has(taiKhoan, matKhau);
        }

        public static int UpdatePassword(string taiKhoan, string matKhau)
        {
            return LoginDAO.UpdatePassword(taiKhoan, matKhau);
        }

        public static DangNhap GetAccount(string taiKhoan)
        {
            return LoginDAO.GetAccount(taiKhoan);
        }

        public static int DeleteAccount(string taiKhoan)
        {
            return LoginDAO.DeleteAccount(taiKhoan);
        }

        public static int CreateAccount(DangNhap dangNhap)
        {
            return LoginDAO.CreateAccount(dangNhap);
        }

        public static DataTable LoadAll()
        {
            return LoginDAO.LoadAll();
        }
    }
}
