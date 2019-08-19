using System;

namespace DTO
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaBan { get; set; }
        public int MaNhanVien { get; set; }
        public DateTime? ThoiGianLap { get; set; }
        public int TongTien { get; set; }

        public HoaDon() { }

        public HoaDon(int maHoaDon, int maBan, int maNhanVien, DateTime? thoiGianLap, int tongTien)
        {
            MaHoaDon = maHoaDon;
            MaBan = maBan;
            MaNhanVien = maNhanVien;
            ThoiGianLap = thoiGianLap;
            TongTien = tongTien;
        }
    }
}
