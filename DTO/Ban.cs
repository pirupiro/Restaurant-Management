namespace DTO
{
    public class Ban
    {
        public int MaBan { get; set; }
        public string TinhTrang { get; set; }

        public Ban() { }

        public Ban(int maBan, string tinhTrang)
        {
            MaBan = maBan;
            TinhTrang = tinhTrang;
        }
    }
}
