Console.OutputEncoding = System.Text.Encoding.UTF8;

MenuSinhVien menu = new MenuSinhVien();
SinhVien sinhVien = new SinhVien();
menu.LoadDanhSachSV();

while(true){
    Console.WriteLine("Mời bạn chọn chức năng: ");
    menu.HienThiChucNang();
    menu.Opption = int.Parse(Console.ReadLine());
    //if (menu.Opption.GetType == int)
    {

        switch (menu.Opption)
        {
            case 1:
                {
                    menu.CreateSinhVien();
                }
                break;
            case 2:
                {
                    menu.MenuUpdateDiem();
                }
                break;
            case 3:
                {
                    menu.DeletedSinhVien();
                }
                break;
            case 4:
                {
                    menu.InforSinhVienHocLuc();
                }
                break;
                 case 5:
                     {
                         menu.SearchSinhVien();
                     }
                     break;
                 case 6:
                     {
                         menu.HienThiDanhSachSinhVienVoiDiemTangDan();
                     }
                     break;
                 case 7:
                     {
                         menu.SearchSinhVien();
                     }
                     break;
               
        }
        if (menu.Opption == 8)
        {
            break;
        }

    }
}