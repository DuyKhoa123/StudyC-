// Program chinh

using BaiTapKeThua_DaHinh_SanPham;

internal class Program
{
    static void Main(string[] args)
    {
        QuanliSanPham danhSachSanPham = new QuanliSanPham();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Hien thi danh sach san pham");
            Console.WriteLine("3. Tinh tong doanh thu");
            Console.WriteLine("4. Xoa san pham");
            Console.WriteLine("5. Thoat");
            Console.Write("Chon mot tuy chon: ");
            int luaChon = int.Parse(Console.ReadLine());
            switch (luaChon)
            {
                case 1:
                    Console.WriteLine("Ban muon them san pham nao?");
                    Console.WriteLine("1. Them san pham dien tu");
                    Console.WriteLine("2. Them san pham thoi trang"); 
                    while (isRunning)
                    {
                        switch (luaChon)
                        {
                            case 1:
                                danhSachSanPham.ThemSanPhamDienTu();
                                    break;
                            case 2: 
                                danhSachSanPham.ThemSanPhamThoiTrang();
                                    break;
                            case 3:
                                return;
                            default:
                                Console.WriteLine("Lua chon khong hop le.");
                                break;
                        }   
                    }
                  break;
                case 2:
                    danhSachSanPham.HienThiDanhSachSanPham();
                    break;

                case 3:
                    danhSachSanPham.TinhTongDoanhThu();
                    break;

                case 4:
                    Console.Write("Nhap ma san pham can xoa: ");
                    string maXoa = Console.ReadLine();
                    danhSachSanPham.XoaSanPham(maXoa);
                    break;

                case 5:
                    Console.WriteLine("Thoat chuong trinh.");
                    return;

                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }
    }
}
