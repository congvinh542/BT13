using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT13.Model
{
    public class Product
    {
        public static int Id { get; set; } = 1;
        public int MaSP { get; set; }
        public string TenSanPham { set; get; }
        public double GiaBan { set; get; }
        public int SoLuong { set; get; }
        public int SoLuongTonKho { set; get; }

        public int SetID()
        {
            Id++;
            MaSP = Id;
            return MaSP;
        }

        public void DetailsSanPham()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(@$"
             Mã sản phẩm: {MaSP},
             Tên sản phẩm: {TenSanPham},
             Giá bán: {GiaBan},
             Số lượng tồn kho: {SoLuong},
         ");

        }
    }
}
