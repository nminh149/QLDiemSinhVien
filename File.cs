// FileIO.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace QLDMH
{
    public static class FileIO
    {
        private static readonly string RootDirectory =
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

        private const string FileName = "BaoCaoDiemMonHoc.txt";
        private const string BackupName = "BaoCaoDiemMonHoc_Backup.bak";
        public static string FilePath => Path.Combine(RootDirectory, FileName);
        public static string BackupPath => Path.Combine(RootDirectory, BackupName);

        public static void LuuFile(List<DiemMonHoc> dsDMH)
        {
            try
            {
                // Tạo backup nếu file gốc đã tồn tại
                if (File.Exists(FilePath))
                {
                    if (File.Exists(BackupPath))
                        File.Delete(BackupPath);
                    File.Copy(FilePath, BackupPath);
                    Console.WriteLine($"Đã tạo backup: {BackupPath}");
                }

                using (StreamWriter sw = new StreamWriter(FilePath, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("════════════════════════════════════════════════════════");
                    sw.WriteLine("           BÁO CÁO KẾT QUẢ HỌC TẬP");
                    sw.WriteLine($"           Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}");
                    sw.WriteLine("════════════════════════════════════════════════════════");
                    sw.WriteLine();

                    if (dsDMH.Count == 0)
                    {
                        sw.WriteLine("          Chưa có môn học nào được nhập.");
                        sw.WriteLine();
                    }
                    else
                    {
                        // Thêm cột "KỲ" vào bảng báo cáo
                        sw.WriteLine($"{"STT",-4} {"KỲ",-4} {"ID MH",-8} {"TÊN MÔN HỌC",-30} {"TC",-4} {"ĐQT",-6} {"ĐTHI",-6} {"ĐIỂM",-6} {"XẾP LOẠI",-10} {"TRẠNG THÁI",-10}");
                        sw.WriteLine(new string('─', 110));

                        int stt = 1;
                        foreach (var mh in dsDMH)
                        {
                            string xl = ThongKeDiemHelper.HienThiXepLoai(ThongKeDiemHelper.QuyDoiChu(mh.Diem));
                            string tt = mh.TrangThai ? "QUA" : "RỚT";
                            sw.WriteLine($"{stt,-4} {mh.KyHoc,-4} {mh.IDMonHoc,-8} {mh.TenMonHoc,-30} {mh.SoTinChi,-4} " +
                                         $"{mh.DiemQuaTrinh,-6:F1} {mh.DiemThi,-6:F1} {mh.Diem,-6:F1} {xl,-10} {tt,-10}");
                            stt++;
                        }

                        sw.WriteLine(new string('═', 110));
                        var kq = ThongKeDiemHelper.ThongKe(dsDMH);
                        sw.WriteLine($"{"TỔNG TÍN CHÍ:",-20} {kq.TongTinChi,3} tín chỉ");
                        sw.WriteLine($"{"GPA (10):",-20} {kq.DiemTBThang10,6:F2}");
                        sw.WriteLine($"{"GPA (4.0):",-20} {kq.DiemTBHe4,6:F2}");
                        sw.WriteLine($"{"XẾP LOẠI TỔNG:",-20} {LayXepLoaiTong(kq.DiemTBHe4)}");
                    }

                    sw.WriteLine();
                    sw.WriteLine("════════════════════════════════════════════════════════");
                    sw.WriteLine("           Phần mềm: QUẢN LÝ ĐIỂM MÔN HỌC - CLST");
                    sw.WriteLine("════════════════════════════════════════════════════════");
                }

                Console.WriteLine("\n" + new string('=', 70));
                Console.WriteLine("                ĐÃ LƯU BÁO CÁO THÀNH CÔNG!");
                Console.WriteLine($"                File nằm tại: {FilePath}");
                if (File.Exists(BackupPath))
                    Console.WriteLine($"                Backup nằm tại: {BackupPath}");
                Console.WriteLine(new string('=', 70));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lưu file: {ex.Message}");
            }
        }


        public static void DocFile(List<DiemMonHoc> dsDMH)
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine($"Không tìm thấy file: {FilePath}");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(FilePath, System.Text.Encoding.UTF8);

                Console.WriteLine("\n" + new string('=', 70));
                Console.WriteLine("             NỘI DUNG BÁO CÁO ĐỌC TỪ FILE");
                Console.WriteLine(new string('=', 70));
                foreach (string line in lines)
                    Console.WriteLine(line);
                Console.WriteLine(new string('=', 70));

                dsDMH.Clear();
                bool batDauDoc = false;
                foreach (string line in lines)
                {
                    // có cột "KỲ" + ĐQT + ĐTHI
                    if (line.Contains("STT") && line.Contains("KỲ") && line.Contains("ID MH") && line.Contains("ĐQT") && line.Contains("ĐTHI"))
                    {
                        batDauDoc = true;
                        continue;
                    }
                    if (!batDauDoc || string.IsNullOrWhiteSpace(line) || line.Contains("═") || line.Contains("─") || line.Contains("TỔNG"))
                        continue;

                    string trim = line.Trim();
                    if (trim.Length < 50) continue;

                    try
                    {
                        string[] parts = Regex.Split(trim, @"\s{2,}");
                        if (parts.Length >= 10 && int.TryParse(parts[1], out _))
                        {
                            DiemMonHoc mh = new DiemMonHoc
                            {
                                KyHoc = int.Parse(parts[1].Trim()),
                                IDMonHoc = parts[2].Trim(),
                                TenMonHoc = parts[3].Trim(),
                                SoTinChi = int.Parse(parts[4].Trim()),
                                DiemQuaTrinh = double.Parse(parts[5].Trim()),
                                DiemThi = double.Parse(parts[6].Trim()),
                                Diem = double.Parse(parts[7].Trim()),
                                TrangThai = parts[9].Trim() == "QUA",
                                NgayHoc = DateTime.Now.AddDays(-30)
                            };
                            dsDMH.Add(mh);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi parse dòng: {trim} - {ex.Message}");
                    }
                }
                Console.WriteLine($"ĐÃ TẢI THÀNH CÔNG {dsDMH.Count} MÔN HỌC!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
            }
        }

        private static string LayXepLoaiTong(double gpa4)
        {
            if (gpa4 >= 3.6) return "XUẤT SẮC";
            if (gpa4 >= 3.2) return "GIỎI";
            if (gpa4 >= 2.5) return "KHÁ";
            if (gpa4 >= 2.0) return "TRUNG BÌNH";
            return "YẾU";
        }

        public static bool KiemTraFileTonTai() => File.Exists(FilePath);
    }
}