using BT13.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BT13.ModelDonHang
{
    public class MenuDonHang
    {
        public int Opption {  get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Product> Products { get; set; } = new List<Product>();

        public MenuDonHang() { 
            this.LoadFile();
        }

        public void HienThiChucNang()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(@"
            1/ Thêm sản phẩm mới.
            2/ Tìm kiếm sản phẩm theo tên.
            3/ Cập nhật giá bán hoặc số lượng tồn kho.
            4/ Xóa sản phẩm. 
            5/ Hiển thị danh sách sản phẩm kèm giá trị kho hàng.
            6/ Hiển thị sản phẩm theo giá tăng dần hoặc giảm dần.
            7/ Hiển thị danh sách sản phẩm theo tên sản phẩm.
            8/ Sắp xếp sản phẩm theo tên.
            9/ Thoát.
        ");
        }


        #region Đơn hàng
        public void UpdateDonHang()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhập vào mã đơn hàng cần chỉnh sửa:");
            int maSanPham = int.Parse(Console.ReadLine());
            Order? orders = this.Orders?.FirstOrDefault(p => p.MaSanPham == maSanPham);

            if (orders != null)
            {
                Console.WriteLine("Số lượng bán hiện tại: " + orders.SoLuongBan);
                Console.WriteLine("Nhập số lượng bán mới:");
                orders.SoLuongBan = int.Parse(Console.ReadLine());

                Console.WriteLine("Tên người đặt hàng hiện tại: " + orders.TenNguoiDatHang);
                Console.WriteLine("Nhập tên người đặt hàng mới:");
                orders.TenNguoiDatHang = Console.ReadLine();

                Console.WriteLine("Trạng thái giao hàng hiện tại: " + orders.DaGiao);
                Console.WriteLine("Nhập trạng thái giao hàng mới (true/false):");
                orders.DaGiao = bool.Parse(Console.ReadLine());
                SaveFile();
                Console.WriteLine("Đơn hàng đã được cập nhật thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy đơn hàng với mã đã nhập.");
            }
        }

        public void CreateDonHang()
        {
            Order order = new Order();
            order.Create();

            if (this.Orders == null)
            {
                this.Orders = new List<Order>();
            }
            SaveFile();
        }

        public void DeleteDonHang()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhập vào mã đơn hàng cần xóa:");
            int maSanPham = int.Parse(Console.ReadLine());
            Order? orders = this.Orders?.FirstOrDefault(p => p.MaSanPham == maSanPham);

            if (orders != null) {
                Orders.Remove(orders);
                Console.WriteLine("Xóa thành công");
                SaveFile();
            }
        }

        public void DetailsDanhSachDonHang()
        {
            string result = "";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhập vào mã đơn hàng cần xem");
            int code = int.Parse(Console.ReadLine());
            Order? orders = this.Orders?.FirstOrDefault(p => p.MaDonHang == code);
            Product? product = this.Products?.FirstOrDefault(p => p.MaSP ==  code);
            if (orders.DaGiao == true)
            {
                result = "Đã giao";
            }else
            {
                result = "Chưa giao";
            }

            Console.WriteLine($@"
            ---------- Thông tin đơn hàng có mã {orders.MaSanPham} ----------
            Mã đơn hàng: {orders.MaDonHang},
            Mã sản phẩm: {orders.MaSanPham},
            Tên sản phẩm: {product.TenSanPham},
            Số lượng đặt mua: {orders.SoLuongBan},
            Tên người đặt hàng: {orders.TenNguoiDatHang},
            Trạng thái đơn hàng: {result};
            ");
        }

        public double TinhTongGiaTriDonHang()
        {
            double tongGiaTri = 0;

            foreach (var product in Products)
            {
                tongGiaTri += product.GiaBan * product.SoLuongTonKho;
            }

            return tongGiaTri;
        }
        #endregion


        #region Product

        public void CreateSanPham()
        {
            Product products = new Product();
            products.MaSP = products.SetID();
            Console.WriteLine("Nhập tên sản phẩm:");
            products.TenSanPham = Console.ReadLine();
            Console.WriteLine("Nhập giá bán");
            products.GiaBan = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhập số lượng sản phẩm");
            products.SoLuong = int.Parse(Console.ReadLine());

            if (this.Products == null)
            {
                this.Products = new List<Product>();
            }
            this.Products.Add(products);
            SaveFile();
        }

        public void UpdateGiaHoacSoLuong()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhập vào mã đơn hàng cần chỉnh sửa:");
            int maSanPham = int.Parse(Console.ReadLine());
            Product? products = this.Products?.Find(p => p.MaSP == maSanPham);

            if (products != null)
            {
                Console.WriteLine("Giá đơn hàng hiện tại: " + products.GiaBan);

                Console.WriteLine("Nhập giá mới:");
                double giaMoi = double.Parse(Console.ReadLine());
                if (products.GiaBan != giaMoi)
                {
                    products.GiaBan = giaMoi;
                }
                else products.GiaBan = products.GiaBan;
                Console.WriteLine("Số lượng đơn hàng hiện tại: " + products.SoLuong);
                Console.WriteLine("Nhập số lượng đơn hàng mới:");
                int soLuong = int.Parse(Console.ReadLine());
                if (products.SoLuong != soLuong)
                {
                    products.SoLuong = soLuong;
                }
                else products.SoLuong = products.SoLuong;

            }
            else
            {
                Console.WriteLine("Không tìm thấy đơn hàng với mã đã nhập.");
            }
            SaveFile();
            Console.WriteLine("Đơn hàng đã được cập nhật thành công.");
        }

        public void SearchSanPham()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhập từ khóa cần tìm: (viết có dấu)");
            string? key = Console.ReadLine().Trim().ToLower();
            List<Product> listSP = this.Products.Where(p => p.TenSanPham.Trim().ToLower().Contains(key)).ToList();
            if (listSP != null)
            {
                Console.WriteLine($"Tìm thấy sản phẩm {listSP.Count} có chứa từ khóa {key}");
                foreach (var sv in listSP)
                {
                   sv.DetailsSanPham();
                }
            }
        }

        public void HienThiDanhSachSanPhamKemGiaTriKhoHang()
        {
            ProductManager productMgr = new ProductManager();
            var product = this.Products;
            
            if (product != null)
            {
                foreach (var sp in product)
                {
                    Console.WriteLine(@$"
                    ---------- Danh sách sản phẩm kho hàng ----------
                    Mã sản phẩm: {sp.MaSP},
                    Tên sản phẩm: {sp.TenSanPham},
                    Giá bán: {sp.GiaBan},
                    Số lượng tồn kho: {sp.SoLuong},
                    ---------- Tổng giá trị kho hàng {productMgr.TinhTongGiaTriKhoHang(sp.GiaBan, sp.SoLuong)} ---------
                ");
                }
            }
        }

        public void HienThiSanPhamTheoGiaTangVaGiamDan()
        {
            IEnumerable<Product> products = null;

            while (true)
            {
                Console.WriteLine("Mời bạn chọn chức năng:");
                Console.WriteLine(@"
                    1. Hiển thị danh sách sản phẩm theo giá tăng dần.
                    2. Hiển thị danh sách sản phẩm theo giá giảm dần.
                    3. Thoát.
                ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        products = this.Products.OrderBy(p => p.GiaBan);
                        break;

                    case 2:
                        products = this.Products.OrderByDescending(p => p.GiaBan);
                        break;

                    case 3:
                        Console.WriteLine("Thoát chương trình.");
                        return;

                    default:
                        Console.WriteLine("Không có chức năng này, mời bạn chọn lại.");
                        continue;
                }

                Console.WriteLine("---------- Danh sách sản phẩm kho hàng ----------");
                foreach (var sp in products)
                {
                    Console.WriteLine(@$"
                        Mã sản phẩm: {sp.MaSP},
                        Tên sản phẩm: {sp.TenSanPham},
                        Giá bán: {sp.GiaBan},
                        Số lượng tồn kho: {sp.SoLuong}
                    ");
                }
            }
        }

        public void HienThiSanPhamTheoTen()
        {
           var products = this.Products.OrderBy(p => p.TenSanPham);
            if(products != null)
            {
                foreach (Product sp in products)
                {
                    Console.WriteLine(@$"
                        Mã sản phẩm: {sp.MaSP},
                        Tên sản phẩm: {sp.TenSanPham},
                        Giá bán: {sp.GiaBan},
                        Số lượng tồn kho: {sp.SoLuong}
                    ");
                }
            }

        }

        public void DeletedSanPham()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Nhập vào mã sản phẩm cần xóa");
            int maSP = int.Parse(Console.ReadLine());
            Product? sanPham = this.Products?.Find(p => p.MaSP == maSP);
            if (sanPham != null)
            {
                this.Products.Remove(sanPham);
                Console.WriteLine("Xóa thành công");
                this.SaveFile();
            }
            else
            {
                Console.WriteLine("Mã sản phẩm không tồn tại");
            }
        }

        #endregion

        public void SaveFile()
        {
            string directoryPath = "./Json";
            string filePathDH = $"{directoryPath}/DonHang.json";
            string filePathSP = $"{directoryPath}/SanPham.json";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string danhSachProduct = JsonSerializer.Serialize(this.Products);
            string danhSachOrder = JsonSerializer.Serialize(this.Orders);

            File.WriteAllText(filePathSP, danhSachProduct);
            File.WriteAllText(filePathDH, danhSachOrder);
        }
        public void LoadFile()
        {
            string strDH = File.ReadAllText("./Json/DonHang.json");
            string strSP = File.ReadAllText("./Json/SanPham.json");

            this.Orders = JsonSerializer.Deserialize<List<Order>>(strDH);
            this.Products = JsonSerializer.Deserialize<List<Product>>(strSP);
        }
    }
}
