namespace DTO
{
    public class ThucDon
    {
        public string TenMon { get; set; }
        public int DonGia { get; set; }
        public string DonVi { get; set; }

        public ThucDon() { }

        public ThucDon(string tenMon, int donGia, string donVi)
        {
            TenMon = tenMon;
            DonGia = donGia;
            DonVi = donVi;
        }
    }
}
