namespace BaiTapKeThua_DaHinh_SanPham;

public class DienTu: SanPham
{
    private double thueBaoHanh;

    public double ThueBaoHanh
    {
        get { return thueBaoHanh; }
        set { thueBaoHanh = value; }
    }

    public DienTu(
        string maSanPham, 
        string tenSanPham, 
        double giaGoc, 
        double thueBaoHanh) : base(maSanPham, tenSanPham,
        giaGoc)
    {
        this.thueBaoHanh = thueBaoHanh;
    }

    public override double TinhGiaBan()
    {
        return GiaGoc + thueBaoHanh;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Gia Ban: {TinhGiaBan():C}");
    }
}