using System;
using System.Collections.Generic;
using System.IO;
using BaiTapKeThua_DaHinh;
using Newtonsoft.Json;

public class Program
{
    private static List<LichSuGiaoDich> lichSuGiaoDich = new List<LichSuGiaoDich>();

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n=== He Thong Thanh Toan ===");
            Console.WriteLine("1. Thanh toan bang tien mat");
            Console.WriteLine("2. Thanh toan bang the");
            Console.WriteLine("3. Thanh toan online");
            Console.WriteLine("4. Xem lich su giao dich");
            Console.WriteLine("5. Thoat");
            Console.Write("Chọn chuc nang: ");

            int luaChon = int.Parse(Console.ReadLine() ?? "0");
            if (luaChon == 5) break;
            if (luaChon == 4)
            {
                Console.WriteLine("An phim bat ki de xem");
            }
            Console.Write("Nhap so tien can thanh toan: ");
            double soTien = double.Parse(Console.ReadLine() ?? "0");

            IThanhToan phuongThucThanhToan;
            switch (luaChon)
            {
                case 1:
                    phuongThucThanhToan = new ThanhToanTienMat();
                    phuongThucThanhToan.ThanhToan(soTien);
                    break;

                case 2:
                    phuongThucThanhToan = new ThanhToanBangThe();
                    phuongThucThanhToan.ThanhToan(soTien);
                    break;

                case 3:
                    phuongThucThanhToan = new ThanhToanOnline();
                    phuongThucThanhToan.ThanhToan(soTien);
                    break;

                case 4:
                    XemLichSuGiaoDich();
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }
        }
    }

    public static void LichSuGiaoDich(string loaiThanhToan, double soTien, string ketQua, DateTime ThoiGian)
    {
        var giaoDich = new LichSuGiaoDich
        {
            LoaiThanhToan = loaiThanhToan,
            SoTien = soTien,
            Ketqua = ketQua,
            ThoiGian = DateTime.Now
        };
        lichSuGiaoDich.Add(giaoDich);

        // Lưu vào file JSON
        string filePath = "LichSuGiaoDich.json";
        string json = JsonConvert.SerializeObject(lichSuGiaoDich, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public static void XemLichSuGiaoDich()
    {
        Console.WriteLine("\n=== Lich su giao dich ===");
        if (lichSuGiaoDich.Count == 0)
        {
            Console.WriteLine("Chua co giao dich nao.");
        }
        else
        {
            foreach (var giaoDich in lichSuGiaoDich)
            {
                Console.WriteLine($"[{giaoDich.ThoiGian}] {giaoDich.LoaiThanhToan} - {giaoDich.SoTien} VND - {giaoDich.Ketqua}");
            }
        }
    }
}
