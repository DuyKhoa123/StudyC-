namespace BaiTapKeThua_DaHinh;

class ThanhToanOnline : IThanhToan
{
    private const int OtpMacDinh = 1234;

    public void ThanhToan(double soTien)
    {
        Console.Write("Nhap ma OTP: ");
        int otp = int.Parse(Console.ReadLine() ?? "0");
        if (otp == OtpMacDinh)
        {
            Console.WriteLine($"Thanh toan online thanh cang: {soTien} VND.");
            Program.LichSuGiaoDich("Thanh toan online", soTien, "Thanh cong", DateTime.Now);
        }
        else
        {
            Console.WriteLine("Mã OTP không đúng! Thanh toán thất bại.");
            Program.LichSuGiaoDich("Thanh toán online", soTien, "Thất bại", DateTime.Now);
        }
    }
}