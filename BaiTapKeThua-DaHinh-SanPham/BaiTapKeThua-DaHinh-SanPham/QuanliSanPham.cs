using System.Net;
using Newtonsoft.Json;

namespace BaiTapKeThua_DaHinh_SanPham;

class QuanliSanPham
{
    private List<SanPham> danhSachSanPham;
    private string filePath= "SanPhamData.json";
    private void LoadData()
    {
        if (!File.Exists(filePath))
        {
            danhSachSanPham = new List<SanPham>();
        }
        else
        {
            string json = File.ReadAllText(filePath);
            danhSachSanPham = JsonConvert.DeserializeObject<List<SanPham>>(json);
        }
    }

    private void saveData()
    {
        string json = JsonConvert.SerializeObject(danhSachSanPham, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public QuanliSanPham()
    {
        LoadData();
    }
    public void ThemSanPham(SanPham sanPham)
    {
        danhSachSanPham.Add(sanPham);
        Console.WriteLine("Da them san pham thanh cong");
        saveData();
    }
    public void HienThiDanhSachSanPham()
    {
        //sap xep giam dan theo gia
        danhSachSanPham.Sort((p1, p2) => p2.GiaGoc.CompareTo(p1.GiaGoc));
        foreach (SanPham product in danhSachSanPham)
        {
            product.HienThiThongTin();
            Console.WriteLine("================================");
        }
        
        //Sap xep theo gia tang dan 
        List<SanPham> sortedProducts = danhSachSanPham.OrderByDescending(p => p.GiaGoc).ToList();
        foreach (SanPham sanPham in sortedProducts)
        {
            sanPham.HienThiThongTin();
            Console.WriteLine("==============================");
        }
    }

    //Them san pham DienTu
    public void ThemSanPhamDienTu()
    {
        Console.WriteLine("Them ma san pham");
        string maSanPham = Console.ReadLine();
        Console.WriteLine("Them ten san pham");
        string tenSanPham = Console.ReadLine();
        Console.WriteLine("Them gia ban san pham");
        double giaGoc = double.Parse(Console.ReadLine());
        Console.WriteLine("Them thue bao hanh");
        double thueBaoHanh = double.Parse(Console.ReadLine());
        Console.WriteLine($"Debug {maSanPham}, {tenSanPham}, {giaGoc}, {thueBaoHanh}");
        DienTu dienTu = new DienTu(maSanPham, tenSanPham, giaGoc, thueBaoHanh); 
        ThemSanPham(dienTu);
    }
    
    //Them san pham ThoiTrang
    public void ThemSanPhamThoiTrang()
    {
        Console.WriteLine("Them ma san pham");
        string maSanPham = Console.ReadLine();
        Console.WriteLine("Them ten san pham");
        string tenSanPham = Console.ReadLine();
        Console.WriteLine("Them gia ban san pham");
        double giaGoc = double.Parse(Console.ReadLine());
        Console.WriteLine("Them ma giam gia");
        double giamGia = double.Parse(Console.ReadLine());
        Console.WriteLine($"Debug {maSanPham}, {tenSanPham}, {giaGoc}, {giamGia}");
        ThoiTrang thoiTrang = new ThoiTrang(maSanPham, tenSanPham, giaGoc, giamGia); 
        ThemSanPham(thoiTrang);
    }
    
    public void TinhTongDoanhThu()
    {
        double tongDoanhThu = danhSachSanPham.Sum(sp => sp.TinhGiaBan());
        Console.WriteLine($"Tong doanh thu du kien: {tongDoanhThu:C}");
    }

    public void XoaSanPham(string maSanPham)
    {
        var sanPham = danhSachSanPham.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
        if (sanPham != null)
        {
            danhSachSanPham.Remove(sanPham);
            Console.WriteLine("Da xoa san pham thanh cong!");
        }
        else
        {
            Console.WriteLine("Khong tim thay san pham de xoa.");
        }
    }
}