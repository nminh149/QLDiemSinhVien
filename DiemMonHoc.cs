
using System;

namespace QLDMH
{
    public class DiemMonHoc
    {
        public int KyHoc { get; set; }
        public string IDMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTinChi { get; set; }
        public double Diem { get; set; }
        public double DiemQuaTrinh { get; set; }
        public double DiemThi { get; set; }
        public DateTime NgayHoc { get; set; }
        public bool TrangThai { get; set; }

        public void TinhDiemCuoi()
        {
            Diem = Math.Round((DiemQuaTrinh * 0.5) + (DiemThi * 0.5), 2);
            TrangThai = Diem >= QuanLyDiemMonHoc.DIEM_DAT;
        }
    }
    public enum XepLoai
    {
        APlus, A, BPlus, B, CPlus, C, DPlus, D, FPlus, F
    }
    public class ThongKeKetQua
    {
        public int SoMonAPlus { get; set; }
        public int SoMonA { get; set; }
        public int SoMonBPlus { get; set; }
        public int SoMonB { get; set; }
        public int SoMonCPlus { get; set; }
        public int SoMonC { get; set; }
        public int SoMonDPlus { get; set; }
        public int SoMonD { get; set; }
        public int SoMonFPlus { get; set; }
        public int SoMonF { get; set; }
        public double DiemTBThang10 { get; set; }
        public double DiemTBHe4 { get; set; }
        public int TongTinChi { get; set; }
    }
}