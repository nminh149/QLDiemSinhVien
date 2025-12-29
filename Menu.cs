using System;
using System.Text;


namespace QLDMH
{
    class Menu
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            QuanLyDiemMonHoc quanLyDiem = new QuanLyDiemMonHoc();
            FileIO.DocFile(quanLyDiem.dsDMH);
            Console.WriteLine("=====================================================================");
            Console.WriteLine("                  CHƯƠNG TRÌNH QUẢN LÝ ĐIỂM SINH VIÊN                ");
            Console.WriteLine($"                        {quanLyDiem.TenTruong}                      ");
            Console.WriteLine("=====================================================================");
            Console.WriteLine();
            Console.WriteLine("Giảng viên bộ môn : Nguyễn Thành Huy");
            Console.WriteLine("Nhóm thực hiện : Nhóm D");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                 HỆ THỐNG QUẢN LÝ ĐIỂM MÔN HỌC                 ║");
                Console.WriteLine("╠═══════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║                                                               ║");
                Console.WriteLine("║  [1] Nhập môn học           │  [5] Tìm kiếm môn học           ║");
                Console.WriteLine("║  [2] Xóa môn học            │  [6] Sắp xếp danh sách môn học  ║");
                Console.WriteLine("║  [3] Cập nhật môn học       │  [7] Thống kê điểm các môn học  ║");
                Console.WriteLine("║  [4] Xem danh sách môn học  │  [8] Lưu/Đọc dữ liệu từ file    ║");
                Console.WriteLine("║                                                               ║");
                Console.WriteLine("╠═══════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║                [0] Thoát chương trình an toàn                 ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");

                Console.Write("Nhập tùy chọn: ");
        
        
                int key;
                while (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.Write("Vui lòng nhập số hợp lệ: ");
                }
                switch (key)
                {
                    case 1:
                        Console.WriteLine("\n1. Nhập môn học.");
                        quanLyDiem.NhapMonHoc();

                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("\n2. Xóa môn học.");
                        quanLyDiem.XoaMonHoc();

                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("\n3. Cập nhật thông tin điểm môn học.");
                        quanLyDiem.CapNhatDiemMonHoc();

                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("\n4. Hiển thị danh sách môn học.");
                        quanLyDiem.HienThiDanhSachMonHoc();

                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine("\n5. Tìm kiếm môn học theo ID, Điểm, Thời gian học.");
                        quanLyDiem.TimKiemMonHoc();
                        break;
                    case 6:
                        Console.WriteLine("\n6. Sắp xếp danh sách môn học.");
                        quanLyDiem.SapXepMonHoc();
                        break;
                    case 7:
                        Console.WriteLine("\n7. Thống kê danh sách môn học.");
                        quanLyDiem.ThongKeDiem();

                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 8:
                        Console.WriteLine("\n8. Lưu/Đọc báo cáo vào file .txt.");
                        Console.WriteLine("1. Lưu file");
                        Console.WriteLine("2. Đọc file");
                        Console.Write("Chọn: ");
                        string chon = Console.ReadLine();
                        if (chon == "1")
                            FileIO.LuuFile(quanLyDiem.dsDMH);
                        else if (chon == "2")
                            FileIO.DocFile(quanLyDiem.dsDMH);
                        else
                            Console.WriteLine("Lựa chọn không hợp lệ!");
                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 0:
                        Console.WriteLine("\nBạn có muốn lưu trước khi thoát?");
                        Console.WriteLine("1. Có");
                        Console.WriteLine("2. Không");
                        Console.Write("Chọn: ");
                        string luachon = Console.ReadLine();

                        if (luachon == "1")
                        {
                            FileIO.LuuFile(quanLyDiem.dsDMH);
                            Console.WriteLine("Đã lưu dữ liệu thành công!");
                        }
                        else if (luachon == "2")
                        {
                            Console.WriteLine("Không lưu dữ liệu.");
                        }
                        else Console.WriteLine("Lựa chọn không hợp lệ! Thoát mà không lưu.");

                        Console.WriteLine("\nChào tạm biệt! Chúc bạn học tốt ");
                        Console.WriteLine("Phần mềm: QUẢN LÝ ĐIỂM MÔN HỌC - CLST");
                        return;
                    default:
                        Console.WriteLine("\nKhông có chức năng này!");
                        Console.WriteLine("Vui lòng chọn số trong menu.");
                        break;
                }
            }
        }
    }
}