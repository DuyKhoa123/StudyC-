namespace BaiTapKeThua_DaHinh;

class LichSuGiaoDich
{
    //Them Id cua tung loai giao dich
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    private string loaiThanhToan;

    public string LoaiThanhToan
    {
        get { return loaiThanhToan; }
        set { loaiThanhToan = value; }
    }
    private double soTien;

    public double SoTien
    {
        get { return soTien; }
        set
        {
            if (soTien <= 5000)
            {
                throw new ArgumentException("SoTien phai lon hon 5000");
            }
            soTien = value;
        }
    }
    private string ketqua;

    public string Ketqua
    {
        get { return ketqua; }
        set { ketqua = value; }
    }
    private DateTime thoiGian;

    public DateTime ThoiGian
    {
        get { return thoiGian; }
        set { thoiGian = value; }
    }

    public LichSuGiaoDich()
    {
        id = GenerateRandomID(); // Tạo ID ngẫu nhiên
        ThoiGian = DateTime.Now;
    }
    // Hàm tạo ID ngẫu nhiên 6 chữ số
    private int GenerateRandomID()
    {
        return Random.Next(100000, 999999); // ID ngẫu nhiên từ 100000 đến 999999
    }
    
    public LichSuGiaoDich(string id, string loaiThanhToan, double soTien, string ketqua, DateTime thoiGian)
    {
        id = GenerateRandomID();
        loaiThanhToan = loaiThanhToan;
        soTien = soTien;
        ketqua = ketqua;
        thoiGian = thoiGian;
    }
}
