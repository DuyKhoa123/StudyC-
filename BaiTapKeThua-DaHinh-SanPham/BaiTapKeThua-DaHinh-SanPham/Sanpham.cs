namespace BaiTapKeThua_DaHinh_SanPham;

// Lop truu tuong SanPham
public abstract class SanPham
{
    private string maSanPham { get; set; }

    public string MaSanPham
    {
        get { return maSanPham; }
        set { maSanPham = value; }
    }
    private string tenSanPham { get; set; }

    public string TenSanPham
    {
        get { return tenSanPham; }
        set { tenSanPham = value; }
    }
    private double giaGoc { get; set; }

    public double GiaGoc
    {
        get { return giaGoc; }
        set { giaGoc = value; }
    }

    public SanPham(string maSanPham, string tenSanPham, double giaGoc)
    {
        MaSanPham = maSanPham;
        TenSanPham = tenSanPham;
        GiaGoc = giaGoc;
    }

    // Phuong thuc truu tuong de tinh gia ban
    public abstract double TinhGiaBan();

    // Phuong thuc hien thi thong tin san pham
    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Ma: {MaSanPham}, Ten: {TenSanPham}, Gia goc: {GiaGoc:C}");
    }
}