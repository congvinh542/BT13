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
            products.Create();

            if (this.Products == null)
            {
                this.Products = new List<Product>();
            }
            SaveFile();
        }

        public void UpdateGiaHoacSoLuong()
        {

        }

        public void SearchSanPham()
        {

        }

        public void Details()
        {

        }

        public void TinhTongGiaTriKhoHang()
        {

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
