using BT13.ModelDonHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT13.Model
{
    public class ProductManager
    {
        public List<Product> Products { get; set; } = new List<Product>();
        MenuDonHang menuDonHang = new MenuDonHang();

        public ProductManager()
        {
            menuDonHang.LoadFile();
        }

        public void SearchSanPham()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MenuDonHang menuDonHang = new MenuDonHang();
            Console.WriteLine("Nhập từ khóa cần tìm");
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

        public double TinhTongGiaTriKhoHang(double gia, double soLuong)
        {
            return gia * soLuong;
        }
    }
}
