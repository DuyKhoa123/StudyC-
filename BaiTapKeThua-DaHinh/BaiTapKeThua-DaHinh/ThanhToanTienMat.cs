namespace BaiTapKeThua_DaHinh;

class ThanhToanTienMat : IThanhToan
{
    public void ThanhToan(double soTien)
    {
        Console.WriteLine($"Thanh toan tien mat thanh cong: {soTien} VND.");
        Program.LichSuGiaoDich("Thanh Toan Tien Mat" ,soTien, "Thanh cong", DateTime.Now);
    }
}
