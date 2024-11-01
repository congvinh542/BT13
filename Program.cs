using BT13.Model;
using BT13.ModelDonHang;

Console.OutputEncoding = System.Text.Encoding.UTF8;
bool menuWhile = true;

while (menuWhile)
{
    Console.WriteLine(@"Mời bạn chọn hệ thống:
                    1/ Quản lý sinh viên.
                    2/ Quản lý kho hàng
                    3/ Thoát");

    int opption = int.Parse(Console.ReadLine());

    switch (opption)
    {
        case 1:
            {
                MenuSinhVien menu = new MenuSinhVien();
                bool menuWhileSinhVien = true;
                menu.LoadDanhSachSV();

                while (menuWhileSinhVien)
                {
                    Console.WriteLine("Mời bạn chọn chức năng:");
                    menu.HienThiChucNang();
                    menu.Opption = int.Parse(Console.ReadLine());

                    if (menu.Opption >= 0 && menu.Opption <= 9)
                    {
                        switch (menu.Opption)
                        {
                            case 1: menu.CreateSinhVien(); break;
                            case 2: menu.MenuUpdateDiem(); break;
                            case 3: menu.DeletedSinhVien(); break;
                            case 4: menu.InforSinhVienHocLuc(); break;
                            case 5: menu.SearchSinhVien(); break;
                            case 6:
                                {
                                    var sv = menu.sinhViens;
                                    foreach (var sV in sv)
                                    {
                                        sV.InforSinhVien();
                                    }
                                }
                                break;
                            case 7: menu.HienThiDanhSachSinhVienVoiDiemTangDan(); break;
                            case 8: menu.SearchSinhVien(); break;
                            case 9:
                                menuWhileSinhVien = false;  
                                break;
                            default: Console.WriteLine("Chức năng bạn chọn không hợp lệ."); break;
                        }
                    }
                    else Console.WriteLine("Chức năng bạn chọn không hợp lệ.");
                }
            }
            break;

        case 2:
            {
                MenuDonHang menuDH = new MenuDonHang();
                bool menuWhileDonHang = true;
                menuDH.LoadFile();

                while (menuWhileDonHang)
                {
                    Console.WriteLine("Mời bạn chọn chức năng:");
                    menuDH.HienThiChucNang();
                    menuDH.Opption = int.Parse(Console.ReadLine());

                    if (menuDH.Opption >= 0 && menuDH.Opption <= 8)
                    {
                        switch (menuDH.Opption)
                        {
                            case 1: menuDH.CreateSanPham(); break;
                            case 2: menuDH.SearchSanPham(); break;
                            case 3: menuDH.UpdateGiaHoacSoLuong(); break;
                            case 4: menuDH.DeletedSanPham(); break;
                            case 5: menuDH.HienThiDanhSachSanPhamKemGiaTriKhoHang(); break;
                            case 6: menuDH.HienThiSanPhamTheoGiaTangVaGiamDan(); break;
                            case 7: menuDH.HienThiSanPhamTheoTen(); break;
                            case 8: menuDH.SearchSanPham(); break;
                            case 9:
                                menuWhileDonHang = false;  
                                break;
                            default: Console.WriteLine("Chức năng bạn chọn không hợp lệ."); break;
                        }
                    }
                    else Console.WriteLine("Chức năng bạn chọn không hợp lệ.");
                }
            }
            break;

        case 3:
            menuWhile = false;  
            break;

        default:
            Console.WriteLine("Không có chức năng này.");
            break;
    }
}
