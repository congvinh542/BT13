using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT13.Model
{
    public class Order
    {
        public static int Id { get; set; } = 1;
        public int MaDonHang {  get; set; }
        public int MaSanPham {  get; set; }
        public int SoLuongBan { get; set; }
        public string TenNguoiDatHang {  get; set; }
        public bool DaGiao { get; set; } = false;

        public void Create()
        {
            MaSanPham = Id;
            Console.WriteLine("Số lượng bán");
            SoLuongBan = int.Parse(Console.ReadLine());
            Console.WriteLine("Tên người đặt hàng");
            TenNguoiDatHang = Console.ReadLine();
            Console.WriteLine("Trạng thái giao hàng");
            DaGiao = true;
            Id++;
        }
    }
}
