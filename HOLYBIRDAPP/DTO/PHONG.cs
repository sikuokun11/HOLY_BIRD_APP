using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HOLYBIRDAPP.DTO
{
    class PHONG
    {
        private string MaPhong;
        private string TenPhong;
        public PHONG() { }
        public PHONG(string MaPhong, string TenPhong)
        {
            this.MaPhong1 = MaPhong;
            this.TenPhong1 = TenPhong;
        }
        public PHONG(DataRow row)
        {
            this.MaPhong1 = row["MaPhong"].ToString();
            this.TenPhong1 = row["TenPhong"].ToString();
        }
        public bool Equals(PHONG phong)
        {
            if (phong == null) return false;
            if (phong.TenPhong != this.TenPhong) return false;
            if (phong.MaPhong != this.MaPhong) return false;
            return true;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as PHONG);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string MaPhong1 { get => MaPhong; set => MaPhong = value; }
        public string TenPhong1 { get => TenPhong; set => TenPhong = value; }
    }
}
