namespace BaiTapKeThua_DaHinh_SanPham;

public class ThoiTrang: SanPham
{
    private double giamGia;

    public double GiamGia
    {
        get { return giamGia; }
        set
        {
            if (giamGia < 0)
            {
                throw new ArgumentException("Vui long nhap so duong.");
            }
            giamGia = value;
        }
    }
    
    public ThoiTrang(
        string maSanPham, 
        string tenSanPham, 
        double giaGoc, 
        double giamGia) : base(maSanPham, tenSanPham, giaGoc)
    {
        this.giamGia = giamGia;
    }
    public override double TinhGiaBan()
    {
        return GiaGoc - giamGia;
    }
    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Gia Ban: {TinhGiaBan():C}");
    }
}