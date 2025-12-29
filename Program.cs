using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace QLDMH
{
    class QuanLyDiemMonHoc
    {
        private readonly string truongHoc = "Đại học Kinh tế (UEH)";
        public string TenTruong => truongHoc;
        public List<DiemMonHoc> dsDMH = new List<DiemMonHoc>();
        public const double DIEM_DAT = 5.0;

        // Nhập môn
        public void NhapMonHoc()
        {
            string id;
            while (true)
            {
                Console.Write("Nhập ID môn học: ");
                id = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(id))
                {
                    Console.WriteLine("ID môn học không được để trống!");
                    continue;
                }
                if (dsDMH.Any(m => m.IDMonHoc.Equals(id, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Môn học này đã tồn tại, vui lòng nhập ID khác!");
                    continue;
                }
                break;
            }
            string ten;
            while (true)
            {
                Console.Write("Nhập tên môn học: ");
                ten = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ten))
                {
                    Console.WriteLine("Tên môn học không được để trống!");
                    continue;
                }
                if (dsDMH.Any(m => m.TenMonHoc.Equals(ten, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Môn học này đã tồn tại, vui lòng nhập tên khác!");
                    continue;
                }
                break;
            }

            int kyHoc;
            while (true)
            {
                Console.Write("Nhập kỳ học: ");
                if (int.TryParse(Console.ReadLine(), out kyHoc) && kyHoc > 0) break;
                Console.WriteLine("Kỳ học không hợp lệ, vui lòng nhập lại!");
            }
            int tinChi;
            while (true)
            {
                Console.Write("Nhập số tín chỉ: ");
                if (int.TryParse(Console.ReadLine(), out tinChi) && tinChi > 0) break;
                Console.WriteLine("Số tín chỉ không hợp lệ, vui lòng nhập lại!");
            }
            double diemQT;
            while (true)
            {
                Console.Write("Nhập điểm quá trình (0 - 10): ");
                if (double.TryParse(Console.ReadLine(), out diemQT) && diemQT >= 0 && diemQT <= 10) break;
                Console.WriteLine("Điểm quá trình không hợp lệ, vui lòng nhập lại!");
            }
            double diemThi;
            while (true)
            {
                Console.Write("Nhập điểm thi KTHP (0 - 10): ");
                if (double.TryParse(Console.ReadLine(), out diemThi) && diemThi >= 0 && diemThi <= 10) break;
                Console.WriteLine("Điểm thi không hợp lệ, vui lòng nhập lại!");
            }
            DateTime ngay;
            while (true)
            {
                Console.Write("Nhập ngày học (dd-MM-yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngay)) break;
                Console.WriteLine("Ngày học không hợp lệ, vui lòng nhập lại!");
            }

            var mh = new DiemMonHoc
            {
                IDMonHoc = id,
                TenMonHoc = ten,
                SoTinChi = tinChi,
                DiemQuaTrinh = diemQT,
                DiemThi = diemThi,
                KyHoc = kyHoc,
                NgayHoc = ngay,
            };
            mh.TinhDiemCuoi();
            dsDMH.Add(mh);

            //Dùng hàm out để nhận 2 giá trị cùng lúc
            ThongKeDiemHelper.QuyDoiHe4(mh.Diem, out double diemHe4, out XepLoai xepLoai);
            Console.WriteLine("\nNhập môn học thành công!");

            string ngayStr = ngay.ToString("dd-MM-yyyy");
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║            THÔNG TIN MÔN HỌC VỪA NHẬP        ║");
            Console.WriteLine("╠══════════════════════════════════════════════╣");
            Console.WriteLine($"║ ID môn học     : {id,-28}║");
            Console.WriteLine($"║ Tên môn học    : {ten,-28}║");
            Console.WriteLine($"║ Số tín chỉ     : {tinChi,-28}║");
            Console.WriteLine($"║ Kỳ học         : {kyHoc,-28}║");
            Console.WriteLine($"║ Ngày học       : {ngayStr,-28}║");
            Console.WriteLine($"║ Điểm quá trình : {diemQT,-28:F2}║");
            Console.WriteLine($"║ Điểm thi KTHP  : {diemThi,-28:F2}║");
            Console.WriteLine($"║ Điểm tổng (10) : {mh.Diem,-28:F2}║");
            Console.WriteLine($"║ Điểm (4.0)     : {diemHe4,-28:F1}║");
            Console.WriteLine($"║ Xếp loại       : {ThongKeDiemHelper.HienThiXepLoai(xepLoai),-28}║");
            Console.WriteLine($"║ Trạng thái     : {(mh.TrangThai ? "QUA MÔN" : "RỚT MÔN"),-28}║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");
        }


        // Xóa môn học
        public void XoaMonHoc()
        {
            Console.WriteLine("\n=== XÓA MÔN HỌC ===");
            Console.WriteLine("1. Xóa theo tên môn");
            Console.WriteLine("2. Xóa tất cả môn học");
            Console.Write("Chọn chức năng: ");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Write("Nhập tên môn cần xóa: ");
                string ten = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ten))
                {
                    Console.WriteLine("Tên môn không hợp lệ!");
                    return;
                }
                var mh = dsDMH.Find(m => m.TenMonHoc.Equals(ten, StringComparison.OrdinalIgnoreCase));
                if (mh != null)
                {
                    dsDMH.Remove(mh);
                    Console.WriteLine($"Đã xóa môn học: {ten}");
                }
                else Console.WriteLine("Không tìm thấy môn học cần xóa.");
            }

            else if (choice == "2")
            {
                Console.Write("Bạn có chắc chắn muốn xóa tất cả môn học? (Y/N): ");
                string xacNhan = Console.ReadLine();
                if (xacNhan == "Y")
                {
                    dsDMH.Clear();
                    Console.WriteLine("Đã xóa tất cả môn học.");
                }
                else Console.WriteLine("Hủy xóa tất cả môn học.");
            }
            else Console.WriteLine("Lựa chọn không hợp lệ!");
        }


        // Cập nhật điểm môn học
        public void CapNhatDiemMonHoc()
        {
            if (dsDMH.Count == 0)
            {
                Console.WriteLine("Chưa có môn học nào để cập nhật!");
                return;
            }
            Console.Write("Nhập tên môn học cần cập nhật: ");
            string tenMon = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < dsDMH.Count; i++)
            {
                if (dsDMH[i].TenMonHoc.Equals(tenMon, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    ThongKeDiemHelper.QuyDoiHe4(dsDMH[i].Diem, out double diemHe4Cu, out XepLoai loaiCu);

                    string trangThaiCu = dsDMH[i].TrangThai ? "QUA MÔN" : "RỚT MÔN";
                    Console.WriteLine("╔══════════════════════════════════════════════╗");
                    Console.WriteLine("║                   THÔNG TIN CŨ               ║");
                    Console.WriteLine("╠══════════════════════════════════════════════╣");
                    Console.WriteLine($"║ Tên môn học       : {dsDMH[i].TenMonHoc,-25}║");
                    Console.WriteLine($"║ Điểm quá trình    : {dsDMH[i].DiemQuaTrinh,-25:F2}║");
                    Console.WriteLine($"║ Điểm thi KTHP     : {dsDMH[i].DiemThi,-25:F2}║");
                    Console.WriteLine($"║ Điểm cuối (10)    : {dsDMH[i].Diem,-25:F2}║");
                    Console.WriteLine($"║ Điểm (4.0)        : {diemHe4Cu,-25:F1}║");
                    Console.WriteLine($"║ Xếp loại          : {ThongKeDiemHelper.HienThiXepLoai(loaiCu),-25}║");
                    Console.WriteLine($"║ Trạng thái        : {trangThaiCu,-25}║");
                    Console.WriteLine("╚══════════════════════════════════════════════╝");

                    // Nhập điểm mới
                    Console.Write("Nhập điểm quá trình mới (hoặc Enter để giữ nguyên): ");
                    string inputQT = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputQT) && double.TryParse(inputQT, out double diemQT))
                    {
                        dsDMH[i].DiemQuaTrinh = diemQT;
                    }

                    // Cập nhật điểm thi
                    Console.Write("Nhập điểm thi KTHP mới (hoặc Enter để giữ nguyên): ");
                    string inputThi = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputThi) && double.TryParse(inputThi, out double diemThi))
                    {
                        dsDMH[i].DiemThi = diemThi;
                    }

                    dsDMH[i].TinhDiemCuoi();
                    // Tính lại xếp loại và điểm hệ 4
                    ThongKeDiemHelper.QuyDoiHe4(dsDMH[i].Diem, out double diemHe4Moi, out XepLoai loaiMoi);
                    string trangThaiMoi = dsDMH[i].TrangThai ? "QUA MÔN" : "RỚT MÔN";
                    Console.WriteLine("╔══════════════════════════════════════════════╗");
                    Console.WriteLine("║                  THÔNG TIN MỚI               ║");
                    Console.WriteLine("╠══════════════════════════════════════════════╣");
                    Console.WriteLine($"║ Tên môn học       : {dsDMH[i].TenMonHoc,-25}║");
                    Console.WriteLine($"║ Điểm quá trình    : {dsDMH[i].DiemQuaTrinh,-25:F2}║");
                    Console.WriteLine($"║ Điểm thi KTHP     : {dsDMH[i].DiemThi,-25:F2}║");
                    Console.WriteLine($"║ Điểm cuối (10)    : {dsDMH[i].Diem,-25:F2}║");
                    Console.WriteLine($"║ Điểm (4.0)        : {diemHe4Moi,-25:F1}║");
                    Console.WriteLine($"║ Xếp loại          : {ThongKeDiemHelper.HienThiXepLoai(loaiMoi),-25}║");
                    Console.WriteLine($"║ Trạng thái        : {trangThaiMoi,-25}║");
                    Console.WriteLine("╚══════════════════════════════════════════════╝");
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Không tìm thấy môn học cần cập nhật!");
            }
        }


        // Hiển thị danh sách môn học
        public void HienThiDanhSachMonHoc()
        {
            Console.WriteLine("\nDanh sách môn học");
            if (dsDMH.Count == 0)
            {
                Console.WriteLine("Chưa có môn học nào!");
                return;
            }
            Console.WriteLine("\n================================ DANH SÁCH MÔN HỌC ================================");
            Console.WriteLine($"{"STT",3} | {"ID MH",-8} | {"Tên môn",-28} | {"TC",2} | {"Hệ 10",8} | {"Hệ 4",5} | {"Loại",-4} | {"Trạng thái",-10}");
            Console.WriteLine(new string('-', 88));


            for (int i = 0; i < dsDMH.Count; i++)
            {
                var mh = dsDMH[i];
                ThongKeDiemHelper.QuyDoiHe4(mh.Diem, out double diemHe4, out XepLoai loaiChu);
                string loaiChuStr = ThongKeDiemHelper.HienThiXepLoai(loaiChu);
                string trangThai = ThongKeDiemHelper.KiemTraTrangThai(mh.Diem) ? "QUA MÔN" : "RỚT MÔN";
                Console.WriteLine($"{i + 1,3} | {mh.IDMonHoc,-8} | {mh.TenMonHoc,-28} | {mh.SoTinChi,2} | {mh.Diem,8:F2} | {diemHe4,5:F1} | {loaiChuStr,-4} | {trangThai,-10}");
            }
            Console.WriteLine(new string('-', 88));
            Console.WriteLine($"\nTổng số môn học: {dsDMH.Count}");
        }



        // Tìm kiếm môn học
        public void TimKiem(string idCanTim)
        {
            bool found = false;
            for (int i = 0; i < dsDMH.Count; i++) // Linear search theo ID
            {
                if (dsDMH[i].IDMonHoc.Equals(idCanTim, StringComparison.OrdinalIgnoreCase))
                {
                    HienThi(dsDMH[i]);
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Không tìm thấy môn học có ID này!");
        }
        public void TimKiem(double diemCanTim)
        {
            bool found = false;
            for (int i = 0; i < dsDMH.Count; i++) // Linear search theo điểm
            {
                if (Math.Abs(dsDMH[i].Diem - diemCanTim) < 0.001)
                {
                    HienThi(dsDMH[i]);
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Không tìm thấy môn học có điểm này!");
        }
        public void TimKiem(DateTime ngayCanTim)
        {
            bool found = false;
            for (int i = 0; i < dsDMH.Count; i++) // Linear search theo ngày học
            {
                if (dsDMH[i].NgayHoc.Date == ngayCanTim.Date)
                {
                    HienThi(dsDMH[i]);
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Không tìm thấy môn học có ngày học này!");
        }

        public void TimKiemMonHoc()
        {
            int chon;
            do
            {
                Console.WriteLine("\n=== MENU TÌM KIẾM ===");
                Console.WriteLine("1. Tìm theo ID");
                Console.WriteLine("2. Tìm theo điểm (điểm tổng)");
                Console.WriteLine("3. Tìm theo ngày học");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                chon = int.Parse(Console.ReadLine());

                if (chon == 1)
                {
                    Console.Write("Nhập ID cần tìm: ");
                    string id = Console.ReadLine();
                    TimKiem(id);
                }
                else if (chon == 2)
                {
                    Console.Write("Nhập điểm cần tìm (điểm tổng): ");
                    if (double.TryParse(Console.ReadLine(), out double diem))
                        TimKiem(diem);
                    else Console.WriteLine("Điểm không hợp lệ!");
                }
                else if (chon == 3)
                {
                    Console.Write("Nhập ngày học cần tìm (dd-MM-yyyy): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngay))
                        TimKiem(ngay);
                    else Console.WriteLine("Định dạng ngày không hợp lệ!");
                }

            } while (chon != 0);
        }
        static void HienThi(DiemMonHoc mh)
        {
            ThongKeDiemHelper.QuyDoiHe4(mh.Diem, out double diemHe4, out XepLoai loaiChu);
            string loaiChuStr = ThongKeDiemHelper.HienThiXepLoai(loaiChu);
            string trangThaiStr = mh.TrangThai ? "QUA MÔN" : "RỚT MÔN";
            string ngayStr = mh.NgayHoc.ToString("dd-MM-yyyy");

            Console.WriteLine("\n╔══════════════════════════════════════════════╗");
            Console.WriteLine($"║ ID môn học : {mh.IDMonHoc,-32}║");
            Console.WriteLine($"║ Tên môn học: {mh.TenMonHoc,-32}║");
            Console.WriteLine($"║ Số tín chỉ : {mh.SoTinChi,-32}║");
            Console.WriteLine($"║ Kỳ học     : {mh.KyHoc,-32}║");
            Console.WriteLine($"║ Ngày học   : {ngayStr,-32}║");
            Console.WriteLine($"║ Điểm (10)  : {mh.Diem,-32:F2}║");
            Console.WriteLine($"║ Điểm (4.0) : {diemHe4,-32:F1}║");
            Console.WriteLine($"║ Xếp loại   : {loaiChuStr,-32}║");
            Console.WriteLine($"║ Trạng thái : {trangThaiStr,-32}║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");
        }


        // Sắp xếp môn học
        // Bubble Sort theo điểm môn học (tăng dần)
        public void SapXepTheoDiem_BubbleSort()
        {
            for (int i = 0; i < dsDMH.Count - 1; i++)
            {
                for (int j = 0; j < dsDMH.Count - i - 1; j++)
                {
                    if (dsDMH[j].Diem > dsDMH[j + 1].Diem)
                    {
                        var temp = dsDMH[j];
                        dsDMH[j] = dsDMH[j + 1];
                        dsDMH[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("\nDanh sách môn học đã được sắp xếp theo điểm (tăng dần):");
            HienThiDanhSachMonHoc();
        }

        // Bubble Sort theo tên môn học (A → Z)
        public void SapXepTheoTen_BubbleSort()
        {
            for (int i = 0; i < dsDMH.Count - 1; i++)
            {
                for (int j = 0; j < dsDMH.Count - i - 1; j++)
                {
                    if (string.Compare(dsDMH[j].TenMonHoc, dsDMH[j + 1].TenMonHoc, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        var temp = dsDMH[j];
                        dsDMH[j] = dsDMH[j + 1];
                        dsDMH[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("\nDanh sách môn học đã được sắp xếp theo tên (A-Z):");
            HienThiDanhSachMonHoc();
        }
        public void SapXepMonHoc()
        {
            int chon;
            do
            {
                Console.WriteLine("\n=== MENU SẮP XẾP MÔN HỌC ===");
                Console.WriteLine("1. Sắp xếp theo điểm");
                Console.WriteLine("2. Sắp xếp theo tên môn học");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                chon = int.Parse(Console.ReadLine());
                if (chon == 1)
                {
                    SapXepTheoDiem_BubbleSort();
                }
                else if (chon == 2)
                {
                    SapXepTheoTen_BubbleSort();
                }
                else if (chon == 0)
                {
                    Console.WriteLine("Thoát sắp xếp...");
                }
                else Console.WriteLine("Lựa chọn không hợp lệ!");
            } while (chon != 0);
        }


        // Thống kê điểm
        public void ThongKeDiem()
        {
            if (dsDMH == null || dsDMH.Count == 0)
            {
                Console.WriteLine("Chưa có dữ liệu để thống kê!");
                return;
            }
            Console.WriteLine("Nhập 0 để xem tất cả, hoặc chọn số tương ứng với kỳ muốn xem");
            var cacKy = dsDMH.Select(m => m.KyHoc).Distinct().OrderBy(k => k).ToList();
            for (int i = 0; i < cacKy.Count; i++)
            {
                Console.WriteLine($"{i + 1} - Kỳ {cacKy[i]}");
            }
            Console.WriteLine("0 - Tất cả các kỳ");

            Console.Write("Chọn kỳ muốn thống kê: ");
            if (!int.TryParse(Console.ReadLine(), out int luaChon))
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                return;
            }

            int kyChon = 0; // 0 = tất cả các kỳ
            if (luaChon > 0 && luaChon <= cacKy.Count)
                kyChon = cacKy[luaChon - 1];

            // --- Lọc danh sách môn học theo kỳ đã chọn ---
            IEnumerable<DiemMonHoc> dsLoc = kyChon == 0 ? dsDMH : dsDMH.Where(m => m.KyHoc == kyChon);
            // --- Hiển thị bảng ma trận theo kỳ ---
            Console.WriteLine("\n============ BẢNG MA TRẬN ĐIỂM ============");
            BangMaTranDiem(kyChon);
            // --- Thống kê chi tiết điểm A,B,C... ---
            ThongKeKetQua ketQua = ThongKeDiemHelper.ThongKe(dsLoc);

            string kyStr = kyChon == 0 ? "TẤT CẢ CÁC KỲ" : $"KỲ {kyChon}";
            Console.WriteLine($"\n=== THỐNG KÊ ĐIỂM THEO {kyStr} ===");
            Console.WriteLine($"A+ : {ketQua.SoMonAPlus}");
            Console.WriteLine($"A  : {ketQua.SoMonA}");
            Console.WriteLine($"B+ : {ketQua.SoMonBPlus}");
            Console.WriteLine($"B  : {ketQua.SoMonB}");
            Console.WriteLine($"C+ : {ketQua.SoMonCPlus}");
            Console.WriteLine($"C  : {ketQua.SoMonC}");
            Console.WriteLine($"D+ : {ketQua.SoMonDPlus}");
            Console.WriteLine($"D  : {ketQua.SoMonD}");
            Console.WriteLine($"F+ : {ketQua.SoMonFPlus}");
            Console.WriteLine($"F  : {ketQua.SoMonF}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"GPA hệ 10: {ketQua.DiemTBThang10:F2}");
            Console.WriteLine($"GPA hệ 4.0: {ketQua.DiemTBHe4:F2}");
        }

        // Hàm hiển thị bảng ma trận (cập nhật thêm tham số tùy chọn kỳ)
        public void BangMaTranDiem(int kyHoc = 0)
        {
            if (dsDMH.Count == 0)
            {
                Console.WriteLine("Chưa có dữ liệu để hiển thị ma trận điểm!");
                return;
            }

            // --- Lấy danh sách kỳ cần hiển thị ---
            List<int> cacKy = kyHoc == 0
                ? dsDMH.Select(m => m.KyHoc).Distinct().OrderBy(k => k).ToList()
                : new List<int> { kyHoc };

            int maxMon = cacKy.Max(ky => dsDMH.Count(m => m.KyHoc == ky));


            double[,] maTran = new double[cacKy.Count, maxMon];
            for (int i = 0; i < cacKy.Count; i++)
                for (int j = 0; j < maxMon; j++)
                    maTran[i, j] = -1;


            Dictionary<int, int> demMon = cacKy.ToDictionary(k => k, v => 0);
            foreach (var mh in dsDMH)
            {
                if (kyHoc != 0 && mh.KyHoc != kyHoc) continue; // lọc theo kỳ nếu có chọn
                int viTriKy = cacKy.IndexOf(mh.KyHoc);
                int viTriMon = demMon[mh.KyHoc];
                maTran[viTriKy, viTriMon] = mh.Diem;
                demMon[mh.KyHoc]++;
            }

            // --- In bảng ma trận ---
            Console.Write("Học kỳ\t");
            for (int j = 0; j < maxMon; j++)
                Console.Write($"Môn {j + 1}\t");
            Console.WriteLine();

            for (int i = 0; i < cacKy.Count; i++)
            {
                Console.Write($"Kỳ {cacKy[i]}\t");
                for (int j = 0; j < maxMon; j++)
                {
                    if (maTran[i, j] >= 0)
                    {
                        Console.Write($"{maTran[i, j]:F2}\t");
                    }
                    else
                    {
                        Console.Write("-\t");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n============================================");
        }
    }


    public static class ThongKeDiemHelper
    {
        // Quy đổi điểm mảng 2 chiều
        private static readonly object[,] bangQuyDoi = new object[,]
        {
            {9.0, 10.0, 4.0, "A+"},
            {8.5, 8.9, 4.0, "A"},
            {8.0, 8.4, 3.5, "B+"},
            {7.0, 7.9, 3.0, "B"},
            {6.5, 6.9, 2.5, "C+"},
            {5.5, 6.4, 2.0, "C"},
            {5.0, 5.4, 1.5, "D+"},
            {4.0, 4.9, 1.0, "D"},
            {3.0, 3.9, 0.5, "F+"},
            {0.0, 2.9, 0.0, "F" }
        };

        public static void QuyDoiHe4(double diem, out double diemHe4, out XepLoai loaiChu)
        {
            diemHe4 = 0.0;
            loaiChu = XepLoai.F;

            for (int i = 0; i < bangQuyDoi.GetLength(0); i++)
            {
                double min = (double)bangQuyDoi[i, 0];
                double max = (double)bangQuyDoi[i, 1];
                double he4 = (double)bangQuyDoi[i, 2];
                string diemChu = (string)bangQuyDoi[i, 3];
                if (diem >= min && diem <= max)
                {
                    diemHe4 = he4;
                    loaiChu = (XepLoai)Enum.Parse(typeof(XepLoai), diemChu.Replace("+", "Plus"));
                    return;
                }
            }
        }

        // Quy đổi chỉ trả về điểm hệ 4
        public static double QuyDoiHe4(double diem)
        {
            for (int i = 0; i < bangQuyDoi.GetLength(0); i++)
            {
                double min = (double)bangQuyDoi[i, 0];
                double max = (double)bangQuyDoi[i, 1];
                double he4 = (double)bangQuyDoi[i, 2];
                if (diem >= min && diem <= max)
                    return he4;
            }
            return 0.0;
        }
        // Quy đổi sang loại chữ
        public static XepLoai QuyDoiChu(double diem)
        {
            for (int i = 0; i < bangQuyDoi.GetLength(0); i++)
            {
                double min = (double)bangQuyDoi[i, 0];
                double max = (double)bangQuyDoi[i, 1];
                string diemChu = (string)bangQuyDoi[i, 3];
                if (diem >= min && diem <= max)
                    return (XepLoai)Enum.Parse(typeof(XepLoai), diemChu.Replace("+", "Plus"));
            }
            return XepLoai.F;
        }

        public static string HienThiXepLoai(XepLoai loai)
        {
            switch (loai)
            {
                case XepLoai.APlus: return "A+";
                case XepLoai.BPlus: return "B+";
                case XepLoai.CPlus: return "C+";
                case XepLoai.DPlus: return "D+";
                case XepLoai.FPlus: return "F+";
                default: return loai.ToString();
            }
        }

        public static bool KiemTraTrangThai(double diem)
        {
            return diem >= QuanLyDiemMonHoc.DIEM_DAT;
        }

        // Hàm tính toán thống kê dựa trên danh sách điểm
        public static ThongKeKetQua ThongKe(IEnumerable<DiemMonHoc> dsDMH)
        {
            int soAPlus = 0, soA = 0;
            int soBPlus = 0, soB = 0;
            int soCPlus = 0, soC = 0;
            int soDPlus = 0, soD = 0;
            int soFPlus = 0, soF = 0;
            double tongDiem10 = 0.0, tongDiem4 = 0.0;
            int tongTinChi = 0;

            foreach (var mh in dsDMH)
            {
                double diem = mh.Diem;
                int tinChi = mh.SoTinChi;
                QuyDoiHe4(diem, out double diemHe4, out XepLoai loaiChu);

                // Đếm số môn theo loại
                switch (loaiChu)
                {
                    case XepLoai.APlus: soAPlus++; break;
                    case XepLoai.A: soA++; break;
                    case XepLoai.BPlus: soBPlus++; break;
                    case XepLoai.B: soB++; break;
                    case XepLoai.CPlus: soCPlus++; break;
                    case XepLoai.C: soC++; break;
                    case XepLoai.DPlus: soDPlus++; break;
                    case XepLoai.D: soD++; break;
                    case XepLoai.FPlus: soFPlus++; break;
                    case XepLoai.F: soF++; break;
                }

                // Tính tổng điểm có trọng số
                tongDiem10 += diem * tinChi;
                tongDiem4 += QuyDoiHe4(diem) * tinChi;
                tongTinChi += tinChi;
            }

            double gpa10 = tongTinChi > 0 ? tongDiem10 / tongTinChi : 0.0;
            double gpa4 = tongTinChi > 0 ? tongDiem4 / tongTinChi : 0.0;

            return new ThongKeKetQua
            {
                SoMonAPlus = soAPlus,
                SoMonA = soA,
                SoMonBPlus = soBPlus,
                SoMonB = soB,
                SoMonCPlus = soCPlus,
                SoMonC = soC,
                SoMonDPlus = soDPlus,
                SoMonD = soD,
                SoMonFPlus = soFPlus,
                SoMonF = soF,
                DiemTBThang10 = gpa10,
                DiemTBHe4 = gpa4,
                TongTinChi = tongTinChi
            };
        }
    }
}