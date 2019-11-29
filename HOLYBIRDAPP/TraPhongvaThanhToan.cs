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
    public partial class TraPhongvaThanhToan : Form
    {
        public TraPhongvaThanhToan()
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
         
            string strMaDoan = txtMaDoan.Text.Trim();
            string strTenPhong = txtTenPhong.Text.Trim();

            string strErr = string.Empty;

            if (strMaDoan == string.Empty || strTenPhong == string.Empty)
            {
                strErr = "Bạn vui lòng nhập Điền Đầy Đủ Thông Tin ";
                MessageBox.Show(strErr);
            }
            else
            {
                MessageBox.Show("SEE YOU AGAIN !!");
                try
                {
                    string con = @"server=DESKTOP-UU88J58\SQLEXPRESS;database=HOLYBIRD_DOAN2;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(con))
                    {

                        connection.Open();
                        SqlParameter[] arrParam = new SqlParameter[2];
                        arrParam[0] = new SqlParameter("@MaDoan", strMaDoan);
                        arrParam[1] = new SqlParameter("@TenPhong", strTenPhong);
                        SqlDataReader reader = SqlHelper.ExecuteReader(con, "TRAPHONG", arrParam);
                        DataSet data = SqlHelper.ExecuteDataset(con, "XEMTIENPHONGCANHAN", arrParam);
                        SqlParameter[] arrParam1 = new SqlParameter[1];
                        arrParam1[0] = new SqlParameter("@MaDoan", strMaDoan);
                        DataSet data2 = SqlHelper.ExecuteDataset(con, "TONGTIENDOANTRA", arrParam1);
                        if (reader.Read() == true)
                        {
                            MessageBox.Show("TRA PHONG THAT BAI");

                        }
                        else
                        {
                            MessageBox.Show("TRA PHONG THANH CONG");
                            TienPhongGrid.DataSource = data.Tables[0];
                            TongTienGrid.DataSource = data2.Tables[0];
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

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string strMaDoan = txtMaDoan.Text.Trim();
        
            string strErr = string.Empty;

            if (strMaDoan == string.Empty)
            {
                strErr = "Bạn vui lòng nhập Điền Đầy Đủ Thông Tin ";
                MessageBox.Show(strErr);
            }
            else
            {
                
                try
                {
                    string con = @"server=DESKTOP-UU88J58\SQLEXPRESS;database=HOLYBIRD_DOAN2;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(con))
                    {

                        connection.Open();
                        SqlParameter[] arrParam = new SqlParameter[1];
                        arrParam[0] = new SqlParameter("@MaDoan", strMaDoan);
                        SqlDataReader reader = SqlHelper.ExecuteReader(con, "TONGTIENDOANTRA", arrParam);
                        DataSet data2 = SqlHelper.ExecuteDataset(con, "TONGTIENDOANTRA", arrParam);
                        if (reader.Read() == false)
                        {
                            MessageBox.Show("Err!!! Khong co gi de xem");

                        }
                        else
                        {
                            MessageBox.Show("Moi ban xem Thong tin");
              
                            TongTienGrid.DataSource = data2.Tables[0];
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

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string strMaDoan = txtMaDoan.Text.Trim();
            string strTenPhong = txtTenPhong.Text.Trim();

            string strErr = string.Empty;

            if (strMaDoan == string.Empty)
            {
                strErr = "Bạn vui lòng nhập Điền Đầy Đủ Thông Tin ";
                MessageBox.Show(strErr);
            }
            else
            {

                try
                {
                    string con = @"server=DESKTOP-UU88J58\SQLEXPRESS;database=HOLYBIRD_DOAN2;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(con))
                    {

                        connection.Open();
                        SqlParameter[] arrParam = new SqlParameter[2];
                        arrParam[0] = new SqlParameter("@MaDoan", strMaDoan);
                        arrParam[1] = new SqlParameter("@TenPhong", strTenPhong);
                        SqlDataReader reader = SqlHelper.ExecuteReader(con, "THANHTOANDOAN", arrParam);
                        if (reader.Read() == false)
                        {
                            MessageBox.Show("THANH TOAN KHONG THANH CONG");

                        }
                        else
                        {
                            MessageBox.Show("THANHTOAN THANH CONG, CAM ON BAN DA DEN VOI HOLYBIRD");

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
