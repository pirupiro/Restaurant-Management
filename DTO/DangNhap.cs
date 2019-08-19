namespace DTO
{
    public class DangNhap
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int MaNhanVien { get; set; }

        public DangNhap() { }

        public DangNhap(string taiKhoan, string matKhau, int maNhanVien)
        {
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            MaNhanVien = maNhanVien;
        }
    }
}
