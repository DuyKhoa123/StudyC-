
class Program
{
    
    static void Main(string[] args)
    {
        StudentController controller = new StudentController();
        while (true)
        {
            Console.WriteLine("\nQuản lý thông tin học sinh:");
            Console.WriteLine("1. Thêm thông tin học sinh");
            Console.WriteLine("2. Tìm kiếm thông tin học sinh theo tên");
            Console.WriteLine("3. Cập nhật điểm số học sinh");
            Console.WriteLine("4. Tính điểm trung bình và xếp loại");
            Console.WriteLine("5. Xóa học sinh khỏi danh sách");
            Console.WriteLine("6. Hiển thị danh sách học sinh");
            Console.WriteLine("7. Hiển thị học sinh theo điểm trung bình tăng dần");
            Console.WriteLine("8. Hiển thị học sinh theo tên (sắp xếp theo chữ cái cuối)");
            Console.WriteLine("9. Đọc dữ liệu từ file JSON");
            Console.WriteLine("10. Xuất dữ liệu từ file JSON");
            Console.WriteLine("0. Thoát chương trình");
            Console.Write("Lựa chọn của bạn: ");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    controller.ThemHocSinh();
                    break;
                case 2:
                    controller.TimKiemHocSinh();
                    break;
                case 3:
                    controller.CapNhatDiem();
                    break;
                case 4:
                    controller.TinhDiemVaXepLoai();
                    break;
                case 5:
                    controller.XoaHocSinh();
                    break;
                case 6:
                    controller.HienThiDanhSach();
                    break;
                case 7:
                    controller.HienThiTheoDiemTangDan();
                    break;
                case 8:
                    controller.HienThiTheoTen();
                    break;
                case 9:
                    controller.DocDuLieuTuJson();
                    break;
                case 10:
                    Console.Write("Nhập đường dẫn file: ");
                    string filePath = Console.ReadLine();
                    controller.XuatDanhSachRaJSON(filePath);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }
    }
}
