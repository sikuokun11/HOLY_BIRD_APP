using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using Microsoft.ApplicationBlocks.Data;

namespace HOLYBIRDAPP
{
    public partial class HuyDangKy : Form
    {
        public HuyDangKy()
        {
            InitializeComponent();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rc = ClientRectangle;
            if (rc.IsEmpty)
                return;
            if (rc.Width == 0 || rc.Height == 0)
                return;
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.White, Color.FromArgb(196, 232, 250), 90F))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           
           

           

            string strHoTen = txtHoTen.Text.Trim();
            string strCMND = txtCMND.Text.Trim();
            string strMaDoan = txtMaDoan.Text.Trim();
            string strTenPhong = txtTenPhong.Text.Trim();

            string strErr = string.Empty;

            if (strMaDoan == string.Empty || strCMND == string.Empty || strTenPhong == string.Empty || strHoTen == string.Empty)
            {
                strErr = "Bạn vui lòng nhập Điền Đầy Đủ Thông Tin ";
                MessageBox.Show(strErr);
            }
            else
            {
                MessageBox.Show("SEE YOU AGAIN ");
                try
                {
                    string con = @"server=DESKTOP-UU88J58\SQLEXPRESS;database=HOLYBIRD_DOAN2;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(con))
                    {

                        connection.Open();
                        SqlParameter[] arrParam = new SqlParameter[4];
                        arrParam[0] = new SqlParameter("@HoTen", strHoTen);
                        arrParam[1] = new SqlParameter("@CMND", strCMND);
                        arrParam[2] = new SqlParameter("@MaDoan", strMaDoan);
                        arrParam[3] = new SqlParameter("@TenPhong", strTenPhong);
                        SqlDataReader reader = SqlHelper.ExecuteReader(con, "HUYDANGKY", arrParam);
                        // DataSet data = SqlHelper.ExecuteDataset(con, "NHANPHONG", arrParam);
                        //"SHOWLISTROOM @MaGD, @MaDoan, @Hang,@Tang, @HinhThuc, @SoPhong,@BatDau,@KetThuc "
                        // SqlDataAdapter adapter = new SqlDataAdapter("NHANPHONG", con);
                        // adapter.Fill(data);
                        if (reader.Read() == true)
                        {
                            MessageBox.Show("HUY DANG KY THAT BAI");

                        }
                        else
                        {
                            MessageBox.Show("HUY DANG KY THANH CONG");
                            //dataGridView1.ClearSelection();
                        }

                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
                // cbShowListRoom.DataSource = CHITIETPHONGDAO.Instance.SHOWLISTROOM(strMaGD,strMaDoan,strHang,strHinhThuc,strTang,strSoPhong,strBatDau,strKetThuc);


            }
        }
    }
    
}
