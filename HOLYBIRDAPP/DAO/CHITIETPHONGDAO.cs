using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOLYBIRDAPP.DAO
{
    class CHITIETPHONGDAO
    {
        private static CHITIETPHONGDAO instance;

        internal static CHITIETPHONGDAO Instance { get => instance; set => instance = value; }

        internal DataTable SHOWLISTROOM(string MaGD, string MaDoan, string Hang, string HinhThuc,int Tang ,int SoPhong,DateTime BatDau, DateTime KetThuc)

        {
            string query = "SHOWLISTROOM  @MaGD ,@MaDoan,@Hang, @Tang ,@HinhThuc ,@SoPhong ,@BatDau, @KetThuc ";
            return DataProvider.Instance.ExecuteQuery(query,new object[] {MaGD,MaDoan,Hang,Tang,HinhThuc,SoPhong,BatDau,KetThuc});
        }
        public DataSet InsertROOM()
        {
            string query = "SELECT * FROM PHONG";
            return DataProvider.Instance.ExecuteQueryy(query);
        }
    }
}
