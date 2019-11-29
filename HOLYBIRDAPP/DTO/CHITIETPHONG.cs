using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HOLYBIRDAPP.DTO
{
    class CHITIETPHONG
    {
        private string MaPhong;
        private int TinhTrang;
        private int Tang;
        private int GiaPhong;
        private string HinhThuc;
        private string Hang;
        public CHITIETPHONG() {
        }
        public CHITIETPHONG(string MaPhong, string Hang, string HinhThuc, int Tang, int TinhTrang, int GiaPhong)
        {
            this.MaPhong1 = MaPhong;
            this.Hang1 = Hang;
            this.HinhThuc1 = HinhThuc;
            this.Tang1 = Tang;
            this.TinhTrang1 = TinhTrang;
            this.GiaPhong1 = GiaPhong;
        }
        public CHITIETPHONG(DataRow row)
        {
            this.MaPhong1 = row["MaPhong"].ToString();
            this.Hang1 = row["Hang"].ToString();
            this.HinhThuc1 = row["HinhThuc"].ToString();
            this.TinhTrang1 = (int)row["TinhTrang"];
            this.Tang1 = (int)row["Tang"];
            this.GiaPhong1 = (int)row["GiaPhong"];
        }
        public bool Equals(CHITIETPHONG chitietphong)
        {
            if (chitietphong == null) return false;
            if (this.MaPhong != chitietphong.MaPhong) return false;
            if (this.Hang != chitietphong.Hang) return false;
            if (this.Tang != chitietphong.Tang) return false;
            if (this.HinhThuc != chitietphong.HinhThuc) return false;
            if (this.Tang != chitietphong.Tang) return false;
            if (this.GiaPhong != chitietphong.GiaPhong) return false;
            return true;
        }

        public string MaPhong1 { get => MaPhong; set => MaPhong = value; }
        public int TinhTrang1 { get => TinhTrang; set => TinhTrang = value; }
        public int Tang1 { get => Tang; set => Tang = value; }
        public int GiaPhong1 { get => GiaPhong; set => GiaPhong = value; }
        public string HinhThuc1 { get => HinhThuc; set => HinhThuc = value; }
        public string Hang1 { get => Hang; set => Hang = value; }
    }
}
