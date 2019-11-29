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
    public partial class NhanPhong : Form
    {
        public NhanPhong()
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

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
            string strMaDoan = txtMaDoan.Text.Trim();
            string strCMND = txtCMND.Text.Trim();
           
            string strTenPhong = txtTenPhong.Text.Trim();
            
            DateTime strBatDau = dateBatDau.Value.Date;
            
            string strErr = string.Empty;

            if (strMaDoan == string.Empty || strCMND == string.Empty || strTenPhong == string.Empty)
            {
                strErr = "Bạn vui lòng nhập Điền Đầy Đủ Thông Tin Đặt chỗ";
                MessageBox.Show(strErr);
            }
            else
            {
                MessageBox.Show("HELLO: ");
                try
                {
                    string con = @"server=DESKTOP-UU88J58\SQLEXPRESS;database=HOLYBIRD_DOAN2;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(con))
                    {

                        connection.Open();
                        SqlParameter[] arrParam = new SqlParameter[4];
                        arrParam[0] = new SqlParameter("@MaDoan", strMaDoan);
                        arrParam[1] = new SqlParameter("@CMND", strCMND);
                        arrParam[2] = new SqlParameter("@TenPhong", strTenPhong);
                        arrParam[3] = new SqlParameter("@BatDau", strBatDau);
                        SqlDataReader reader = SqlHelper.ExecuteReader(con, "NHANPHONG", arrParam);
                       // DataSet data = SqlHelper.ExecuteDataset(con, "NHANPHONG", arrParam);
                        //"SHOWLISTROOM @MaGD, @MaDoan, @Hang,@Tang, @HinhThuc, @SoPhong,@BatDau,@KetThuc "
                       // SqlDataAdapter adapter = new SqlDataAdapter("NHANPHONG", con);
                       // adapter.Fill(data);
                        if (reader.Read() == true)
                        {
                            MessageBox.Show("NHAN PHONG THAT BAI");
                    
                        }
                        else
                        {
                            MessageBox.Show("NHAN PHONG THANH CONG");
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
