using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

public class StudentController
{
    private List<HocSinh> danhSachHocSinh = new List<HocSinh>();
    
    public void ThemHocSinh()
    {
        Console.WriteLine("Nhập mã học sinh:");
        string maHS = Console.ReadLine();
        Console.WriteLine("Nhập tên học sinh:");
        string tenHS = Console.ReadLine();
        Console.WriteLine("Nhập điểm Toán:");
        double toan = double.Parse(Console.ReadLine());
        Console.WriteLine("Nhập điểm Văn:");
        double van = double.Parse(Console.ReadLine());
        Console.WriteLine("Nhập điểm Anh:");
        double anh = double.Parse(Console.ReadLine());

        HocSinh hocSinh = new HocSinh
        {
            MaHS = maHS,
            TenHS = tenHS,
            DiemSo = new Diem { Toan = toan, Van = van, Anh = anh }
        };

        danhSachHocSinh.Add(hocSinh);
        Console.WriteLine("Thêm học sinh thành công!");
    }
    
    public void TimKiemHocSinh()
    {
        Console.WriteLine("Nhập tên học sinh cần tìm:");
        string ten = Console.ReadLine();
        var ketQua = danhSachHocSinh.Where(hs => hs.TenHS.Contains(ten, StringComparison.OrdinalIgnoreCase));
        foreach (var hs in ketQua)
        {
            Console.WriteLine($"Mã HS: {hs.MaHS}, Tên: {hs.TenHS}, Điểm TB: {hs.DiemSo.TinhDiemTrungBinh():F2}, Xếp loại: {hs.XepLoaiHocLuc()}");
        }
    }
    
    public void CapNhatDiem()
    {
        Console.WriteLine("Nhập mã học sinh cần cập nhật điểm:");
        string maHS = Console.ReadLine();
        var hocSinh = danhSachHocSinh.FirstOrDefault(hs => hs.MaHS == maHS);
        if (hocSinh == null)
        {
            Console.WriteLine("Không tìm thấy học sinh!");
            return;
        }

        Console.WriteLine("Nhập điểm mới cho Toán:");
        hocSinh.DiemSo.Toan = double.Parse(Console.ReadLine());
        Console.WriteLine("Nhập điểm mới cho Văn:");
        hocSinh.DiemSo.Van = double.Parse(Console.ReadLine());
        Console.WriteLine("Nhập điểm mới cho Anh:");
        hocSinh.DiemSo.Anh = double.Parse(Console.ReadLine());

        Console.WriteLine("Cập nhật điểm thành công!");
    }
    public void TinhDiemVaXepLoai()
    {
        foreach (var hs in danhSachHocSinh)
        {
            Console.WriteLine($"Mã HS: {hs.MaHS}, Tên: {hs.TenHS}, Điểm TB: {hs.DiemSo.TinhDiemTrungBinh():F2}, Xếp loại: {hs.XepLoaiHocLuc()}");
        }
    }
    public void XoaHocSinh()
    {
        Console.WriteLine("Nhập mã học sinh cần xóa:");
        string maHS = Console.ReadLine();
        var hocSinh = danhSachHocSinh.FirstOrDefault(hs => hs.MaHS == maHS);
        if (hocSinh != null)
        {
            danhSachHocSinh.Remove(hocSinh);
            Console.WriteLine("Xóa học sinh thành công!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy học sinh!");
        }
    }
    public void HienThiTheoDiemTangDan()
    {
        var danhSachSapXep = danhSachHocSinh.OrderBy(hs => hs.DiemSo.TinhDiemTrungBinh());
        foreach (var hs in danhSachSapXep)
        {
            Console.WriteLine($"Mã HS: {hs.MaHS}, Tên: {hs.TenHS}, Điểm TB: {hs.DiemSo.TinhDiemTrungBinh():F2}");
        }
    }
    public void HienThiTheoTen()
    {
        var danhSachSapXep = danhSachHocSinh.OrderBy(hs => hs.TenHS.Split(' ').Last());
        foreach (var hs in danhSachSapXep)
        {
            Console.WriteLine($"Mã HS: {hs.MaHS}, Tên: {hs.TenHS}, Điểm TB: {hs.DiemSo.TinhDiemTrungBinh():F2}");
        }
    }
    public void DocDuLieuTuJson()
    {
        Console.WriteLine("Nhập đường dẫn file JSON:");
        string path = Console.ReadLine();
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            danhSachHocSinh = JsonConvert.DeserializeObject<List<HocSinh>>(jsonData);
            Console.WriteLine("Đọc dữ liệu thành công!");
        }
        else
        {
            Console.WriteLine("File không tồn tại!");
        }
    }
    public void HienThiDanhSach()
    {
        if (danhSachHocSinh.Count == 0)
        {
            Console.WriteLine("Danh sách học sinh trống!");
            return;
        }

        Console.WriteLine("Danh sách học sinh:");
        foreach (var hs in danhSachHocSinh)
        {
            double diemTrungBinh = hs.DiemSo.TinhDiemTrungBinh();
            Console.WriteLine($"Mã HS: {hs.MaHS}, Tên: {hs.TenHS}, " +
                              $"Điểm Toán: {hs.DiemSo.Toan}, Điểm Văn: {hs.DiemSo.Van}, Điểm Anh: {hs.DiemSo.Anh}, " +
                              $"Điểm TB: {diemTrungBinh:F2}, Xếp loại: {hs.XepLoaiHocLuc()}");
        }
    }
    public void XuatDanhSachRaJSON(string filePath)
    {
            var json = JsonConvert.SerializeObject(danhSachHocSinh.ToList(), Formatting.Indented);
            File.WriteAllText("HocSinh.json", json);
            Console.WriteLine($"Xuất file JSON thành công!");
    }
}