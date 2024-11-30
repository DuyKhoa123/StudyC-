using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
//using Newtonsoft.Json;

public class Diem
{
    public double Toan { get; set; }
    public double Van { get; set; }
    public double Anh { get; set; }
    public double TinhDiemTrungBinh()
    {
        return (Toan + Van + Anh) / 3;
    }
}

public class HocSinh
{
    public string MaHS { get; set; }
    public string TenHS { get; set; }
    public Diem DiemSo { get; set; }

    public string XepLoaiHocLuc()
    {
        double dtb = DiemSo.TinhDiemTrungBinh();
        if (dtb < 5) return "Yếu";
        if (dtb <= 6.5) return "Trung bình";
        if (dtb <= 8) return "Khá";
        return "Giỏi";
    }
}