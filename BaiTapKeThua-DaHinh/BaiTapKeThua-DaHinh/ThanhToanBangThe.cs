namespace BaiTapKeThua_DaHinh;

class ThanhToanBangThe : IThanhToan
{
    private const int PinMacDinh = 9999;

    public void ThanhToan(double soTien)
    {
        Console.Write("Nhập mã PIN: ");
        int pin = int.Parse(Console.ReadLine() ?? "0");
        if (pin == PinMacDinh)
        {
            Console.WriteLine($"Thanh toan bang the thanh cong: {soTien} VND.");
            Program.LichSuGiaoDich("Thanh toan bang the", soTien, "Thanh cong", DateTime.Now);
        }
        else
        {
            Console.WriteLine("Mã PIN khong đung! Thanh toan that bai.");
            Program.LichSuGiaoDich("Thanh toan bang the", soTien, "That bai", DateTime.Now);
        }
    }
}