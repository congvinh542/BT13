using System.Text.Json;

class MenuSinhVien
{
    public int? Opption { set; get; }
    public List<SinhVien> sinhViens { set; get; } = new List<SinhVien>();

    public void HienThiChucNang()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(@"
            1/ Thêm sinh viên.
            2/ Cập nhật điểm số sinh viên.
            3/ Xoá sinh viên.
            4/ Tính điểm trung bình và xếp loại. 
            5/ Tìm kiếm sinh viên theo tên (tên sinh viên không dấu). (gõ có dấu mới tìm đc ạ :))
            6/ Hiển thị danh sách thông tin sinh viên.
            7/ Hiển thị danh sách sinh viên theo điểm tăng dần.
            8/ Hiển thị danh sách sinh viên theo tên tìm kiếm.
            9/ Thoát.
        ");
    }

    public void CreateSinhVien()
    {
        SinhVien sinhVienNew = new SinhVien();
        sinhVienNew.NhapThongTinSinh();
        if (this.sinhViens == null)
        {
            this.sinhViens = new List<SinhVien>();
        }
        this.sinhViens.Add(sinhVienNew);
        this.SaveDanhSachSV();
    }
    public void MenuUpdateDiem()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Nhập vào mã sinh viên cần sửa điểm");
        int maSinhVien = int.Parse(Console.ReadLine());
        var sinhVien = sinhViens.FirstOrDefault(p => p.MaSinhVien == maSinhVien);
        var nameSinhVien = sinhVien.TenSinhVien;
        
        while (true)
        {
            Console.WriteLine(@$"
            ---------- Chọn các môn cần sửa điểm của sinh viên {nameSinhVien} ----------
            1. Môn toán.
            2. Môn văn.
            3. Môn anh.
            4. Thoát.
        ");
            int chon = int.Parse(Console.ReadLine());
            if (chon == 4) break;

            Console.WriteLine("Nhập vào điểm số mới cần sửa đổi");
            double diemMoi = double.Parse(Console.ReadLine()); // Nhận điểm mới từ người dùng
            int maMon = chon;

            UpdateDiemSinhVien(maMon, diemMoi, maSinhVien);
        }
    }

    public void UpdateDiemSinhVien(int maMon, double diemMoi, int maSinhVien)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        SinhVien? sv = this.sinhViens?.Find(sv => sv.MaSinhVien == maSinhVien);

        if (sv != null)
        {
            if (maMon == 1)
            {
                sv.DiemToan = diemMoi;
                Console.WriteLine($"Cập nhập điểm môn toán của sinh viên {sv.TenSinhVien} thành công");
            }
            else if (maMon == 2)
            {
                sv.DiemVan = diemMoi;
                Console.WriteLine($"Cập nhập điểm môn văn của sinh viên {sv.TenSinhVien} thành công");
            }
            else if (maMon == 3)
            {
                sv.DiemAnh = diemMoi;
                Console.WriteLine($"Cập nhập điểm môn anh của sinh viên {sv.TenSinhVien} thành công");
            }
            sv.InforSinhVien();
        }
        else
        {
            Console.Write("Không tìm thấy sinh viên có mã tương ứng !");
        }
    }

    public void DeletedSinhVien()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Nhập vào mã sinh viên cần xóa");
        int maSV = int.Parse(Console.ReadLine());
        SinhVien? maSinhVien = this.sinhViens?.Find(p => p.MaSinhVien == maSV);
        if (maSinhVien != null)
        {
            this.sinhViens.Remove(maSinhVien);
            Console.WriteLine("Xóa thành công");
            this.SaveDanhSachSV();
        }
        else
        {
            Console.WriteLine("Mã nhân viên không tồn tại");
        }

    }
    public void SearchSinhVien()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Nhập từ khóa cần tìm");
        string? key = Console.ReadLine().Trim().ToLower();
        List<SinhVien> listSV = this.sinhViens.Where(p => p.TenSinhVien.Trim().ToLower().Contains(key)).ToList();
        if (listSV != null)
        {
            Console.WriteLine($"Tìm thấy {listSV.Count} có chứa từ khóa {key}");
            foreach (var sv in listSV)
            {
                sv.InforSinhVien();
            }
        }
    }

    public void InforSinhVienHocLuc()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<SinhVien> listSv = this.sinhViens;
        var result = "";
        if (listSv != null)
        {
            Console.WriteLine($"Danh sách sinh viên");
            foreach (var sv in listSv)
            {
                if (sv.TinhDiemTrungBinh() < 5)
                {
                    result = "Học lực yếu";
                }
                else if (sv.TinhDiemTrungBinh() >= 5 && sv.TinhDiemTrungBinh() <= 6.5)
                {
                    result = "Học lực trung bình";
                }
                else if (sv.TinhDiemTrungBinh() >= 6.5 && sv.TinhDiemTrungBinh() < 8)
                {
                    result = "Học lực khá";
                }
                else
                {
                    result = "Học lực giỏi";
                }
                sv.InforSinhVien(result);
            }
        }
    }
    public void HienThiDanhSachSinhVienVoiDiemTangDan()
    {
    Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<SinhVien> listSV = this.sinhViens.OrderBy(p => p.TinhDiemTrungBinh()).ToList();
        if(listSV != null){
            Console.WriteLine("Danh sách sinh viên với điểm trung bình tăng dần là");
            foreach(var sv in listSV){
                sv.InforSinhVien();
            }
        }
    }
    public void HienThiDanhSachSinhVienTheoTen(){
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<SinhVien> listSv = this.sinhViens.OrderBy(p => p.TenSinhVien).ToList();
        if(listSv != null){
            Console.WriteLine("Danh sách tên sinh viên sắp xếp theo bảng chữ cái");
            foreach (var sv in listSv)
            {
                sv.InforSinhVien();
            }
        }
    }
    public void SaveDanhSachSV(){
        string directoryPath = "./Json"; 
        string filePath = $"{directoryPath}/DSSV.json"; 
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        string danhSachSV = JsonSerializer.Serialize(this.sinhViens);
        File.WriteAllText(filePath, danhSachSV);
    }
    public void LoadDanhSachSV(){
        string strSV = File.ReadAllText("./Json/DSSV.json");
        this.sinhViens = JsonSerializer.Deserialize<List<SinhVien>>(strSV);
    }
}