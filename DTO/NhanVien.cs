using System;

namespace DTO
{
    public class NhanVien
    {
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string ChucVu { get; set; }
        public int Luong { get; set; }

        public NhanVien() { }

        public NhanVien(int maNhanVien, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string soDienThoai, DateTime ngayVaoLam, string chucVu, int luong)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            NgayVaoLam = ngayVaoLam;
            ChucVu = chucVu;
            Luong = luong;
        }
    }
}
