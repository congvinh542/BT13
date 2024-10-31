class SinhVien{
    public static int Id {get; set;} = 1;
    public int? MaSinhVien {set;get;}
    public string? TenSinhVien { set; get; }
    public double DiemToan {set; get;} 
    public double DiemAnh {set;get;}
    public double DiemVan {set; get;}

    public void NhapThongTinSinh(){
        MaSinhVien = Id;
        Console.WriteLine("Nhập tên sinh viên");
        TenSinhVien = Console.ReadLine();
        Console.WriteLine("Nhập vào điểm toán");
        DiemToan = double.Parse(Console.ReadLine());
        Console.WriteLine("Nhập vào điểm anh");
        DiemAnh = double.Parse(Console.ReadLine());
        Console.WriteLine("Nhập vào điểm văn");
        DiemVan = double.Parse(Console.ReadLine());
        SinhVien.Id++;
    }

    public void InforSinhVien()
    {
        Console.WriteLine(@$"
        ---------- Thông tin sinh viên : {TenSinhVien}----------
        Mã số: {MaSinhVien},
        Điểm toán: {DiemToan},
        Điểm anh: {DiemAnh},
        Điểm văn: {DiemVan}.
        Điểm trung bình: {TinhDiemTrungBinh()}.
        ");
    }

    public void InforSinhVien(string hocLuc){
        Console.WriteLine(@$"
        ---------- Thông tin sinh viên : {TenSinhVien}----------
        Mã số: {MaSinhVien},
        Điểm toán: {DiemToan},
        Điểm anh: {DiemAnh},
        Điểm văn: {DiemVan}.
        Điểm trung bình: {TinhDiemTrungBinh()}.
        Xếp loại học lực: {hocLuc},
        ");
    }

    public double TinhDiemTrungBinh(){
        return (DiemToan + DiemAnh + DiemVan) / 3;
    }
}