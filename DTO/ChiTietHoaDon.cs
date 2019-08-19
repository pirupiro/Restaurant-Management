namespace DTO
{
    public class ChiTietHoaDon
    {
        public int MaHoaDon { get; set; }
        public string TenMon { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }

        public ChiTietHoaDon() { }

        public ChiTietHoaDon(int maHoaDon, string tenMon, int soLuong, int thanhTien)
        {
            MaHoaDon = maHoaDon;
            TenMon = tenMon;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
        }
    }
}
