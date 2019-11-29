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
using HOLYBIRDAPP.DAO;

namespace HOLYBIRDAPP
{
    public partial class DatCho : Form
    {
       
        public DatCho()
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public void SHOWLISTROOM()
        {
           
        }

        public void LoadDate()
        {
            dateBatDau.Value = DateTime.Now;
            dateKetThuc.Value = DateTime.Now.AddDays(30);
        }

        private void AddParameter(string query, object[] parameter, SqlCommand command)
        {
            if (parameter != null)
            {
                string[] listParameter = query.Split(' ');
                int i = 0;
                foreach (string item in listParameter)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        ++i;
                    }
                }
            }
        }

        static void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            StringBuilder sb = new StringBuilder("");
            sb.AppendLine(e.Message);
        }
        private void buttonDatCho_Click(object sender, EventArgs e)
        {
            string strMaGD = txtMaGD.Text.Trim();
            string strMaDoan = txtMaDoan.Text.Trim();
            string strHang = txtHang.Text.Trim();
            int strTang = (int)txtTang.Value;
            string strHinhThuc = txtHinhThuc.Text.Trim();
            DateTime strBatDau = dateBatDau.Value.Date ;
            DateTime strKetThuc = dateKetThuc.Value.Date ;
            int strSoPhong = (int)txtSoPhong.Value;
            string strErr = string.Empty;

            if (strMaGD == string.Empty || strMaDoan == string.Empty || strHang == string.Empty || strHinhThuc == string.Empty ||strSoPhong == 0 || strTang == 0)
            {
                strErr = "Bạn vui lòng nhập Điền Đầy Đủ Thông Tin Đặt chỗ";
                MessageBox.Show(strErr);
            }
            else
            {
                 MessageBox.Show("  " + strMaGD + " " + strMaGD + " " + strHang + " /" + strSoPhong + " " + strBatDau +"/" +strTang);
                try
                {
                    string con = @"server=DESKTOP-UU88J58\SQLEXPRESS;database=HOLYBIRD_DOAN2;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(con))
                    {

                        connection.Open();
                        connection.InfoMessage += conn_InfoMessage;
                        SqlParameter[] arrParam = new SqlParameter[8];
                        arrParam[0] = new SqlParameter("@MaGD", strMaGD);
                        arrParam[1] = new SqlParameter("@MaDoan", strMaDoan);
                        arrParam[2] = new SqlParameter("@Hang", strHang);
                        arrParam[3] = new SqlParameter("@Tang", strTang);
                        arrParam[4] = new SqlParameter("@HinhThuc", strHinhThuc);
                        arrParam[5] = new SqlParameter("@SoPhong", strSoPhong);
                        arrParam[6] = new SqlParameter("@BatDau", strBatDau);
                        arrParam[7] = new SqlParameter("@KetThuc", strKetThuc);
                        SqlDataReader reader = SqlHelper.ExecuteReader(con, "SHOWLISTROOM", arrParam);
                        DataSet data = SqlHelper.ExecuteDataset(con, "SHOWLISTROOM", arrParam);
                        //"SHOWLISTROOM @MaGD, @MaDoan, @Hang,@Tang, @HinhThuc, @SoPhong,@BatDau,@KetThuc "
                        SqlDataAdapter adapter = new SqlDataAdapter("SHOWLISTROOM2", con);
                        adapter.Fill(data);
                        if (reader.Read() == true)
                        {
                            MessageBox.Show("DAT CHO THANH CONG");
                            dataGridView1.DataSource = data.Tables[0];
                            SqlParameter[] arrParam2 = new SqlParameter[5];
                            arrParam2[0] = new SqlParameter("@MaGD", strMaGD);
                            arrParam2[1] = new SqlParameter("@MaDoan", strMaDoan);
                            arrParam2[2] = new SqlParameter("@SoPhong", strSoPhong);
                            arrParam2[3] = new SqlParameter("@BatDau", strBatDau);
                            arrParam2[4] = new SqlParameter("@KetThuc", strKetThuc);
                            SqlDataReader reader2 = SqlHelper.ExecuteReader(con, "THEMGIAODICH", arrParam2);
                        }
                        else
                        {
                            MessageBox.Show("DAT CHO THAT BAI");
                            dataGridView1.ClearSelection();
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

        private void metroLabel12_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string strMaGD = txtMaGD.Text.Trim();
            string strMaDoan = txtMaDoan.Text.Trim();
            string strHang = txtHang.Text.Trim();
            int strTang = (int)txtTang.Value;
            string strHinhThuc = txtHinhThuc.Text.Trim();
            DateTime strBatDau = dateBatDau.Value.Date;
            DateTime strKetThuc = dateKetThuc.Value.Date;
            int strSoPhong = (int)txtSoPhong.Value;
            string strErr = string.Empty;
            string strTen = txtTen.Text.Trim();
            string strCMND = txtCMND1.Text.Trim();
            string strChonPhong = txtChonPhong1.Text.Trim();
            string strMaPhong = txtMaPhong1.Text.Trim();

            if (strMaGD == string.Empty || strMaDoan == string.Empty || strHang == string.Empty || strHinhThuc == string.Empty || strSoPhong == 0 || strTang == 0)
            {
                strErr = "Bạn vui lòng nhập Điền Đầy Đủ Thông Tin Đặt chỗ";
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
                        SqlParameter[] arrParam = new SqlParameter[6];
                        arrParam[0] = new SqlParameter("@MaDoan", strMaDoan);
                        arrParam[1] = new SqlParameter("@HoTen", strTen);
                        arrParam[2] = new SqlParameter("@CMND", strCMND);
                        arrParam[3] = new SqlParameter("@TenPhong", strChonPhong);
                        arrParam[4] = new SqlParameter("@MaPhong", strMaPhong);
                        arrParam[5] = new SqlParameter("@BatDau", strBatDau);
                        SqlDataReader reader = SqlHelper.ExecuteReader(con, "NHAPGDTHANHVIENDOAN", arrParam);
                  
                        if (reader.Read() == true)
                        {
                            SqlParameter[] arrParam2 = new SqlParameter[4];
                            arrParam2[0] = new SqlParameter("@MaDoan", strMaDoan);
                            arrParam2[1] = new SqlParameter("@MaPhong", strMaPhong);
                            arrParam2[2] = new SqlParameter("@CMND", strCMND);
                            arrParam2[3] = new SqlParameter("@BatDau", strBatDau);
                            arrParam2[4] = new SqlParameter("@KetThuc", strKetThuc);
                            SqlDataReader reader2 = SqlHelper.ExecuteReader(con, "THEMCHITIETGIAODICH", arrParam2);
                            if (reader2.Read() == true)
                            {
                                MessageBox.Show("BAN DA DANG KY PHONG CHO RIENG MINH THANH CONG");
                            }
                            else
                            {
                                MessageBox.Show("BAN DA DANG KY PHONG CHO RIENG MINH THAT BAI");
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("BAN DA DANG KY PHONG CHO RIENG MINH THAT BAI");
                      
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string strMaGD = txtMaGD.Text.Trim();
            string strMaDoan = txtMaDoan.Text.Trim();
            string strHang = txtHang.Text.Trim();
            int strTang = (int)txtTang.Value;
            string strHinhThuc = txtHinhThuc.Text.Trim();
            DateTime strBatDau = dateBatDau.Value.Date;
            DateTime strKetThuc = dateKetThuc.Value.Date;
            int strSoPhong = (int)txtSoPhong.Value;
            string strErr = string.Empty;
            string strTen = txtTen2.Text.Trim();
            string strCMND = txtCMND2.Text.Trim();
            string strChonPhong = txtChonPhong2.Text.Trim();
            string strMaPhong = txtMaPhong2.Text.Trim();

            if (strMaGD == string.Empty || strMaDoan == string.Empty || strHang == string.Empty || strHinhThuc == string.Empty || strSoPhong == 0 || strTang == 0)
            {
                strErr = "Bạn vui lòng nhập Điền Đầy Đủ Thông Tin Đặt chỗ";
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
                        SqlParameter[] arrParam = new SqlParameter[6];
                        arrParam[0] = new SqlParameter("@MaDoan", strMaDoan);
                        arrParam[1] = new SqlParameter("@HoTen", strTen);
                        arrParam[2] = new SqlParameter("@CMND", strCMND);
                        arrParam[3] = new SqlParameter("@TenPhong", strChonPhong);
                        arrParam[4] = new SqlParameter("@MaPhong", strMaPhong);
                        arrParam[5] = new SqlParameter("@BatDau", strBatDau);
                        SqlDataReader reader = SqlHelper.ExecuteReader(con, "NHAPGDTHANHVIENDOAN", arrParam);

                        if (reader.Read() == true)
                        {
                            SqlParameter[] arrParam2 = new SqlParameter[5];
                            arrParam2[0] = new SqlParameter("@MaGD", strMaGD);
                            arrParam2[1] = new SqlParameter("@MaDoan", strMaDoan);
                            arrParam2[2] = new SqlParameter("@MaPhong", strMaPhong);
                            arrParam2[3] = new SqlParameter("@CMND", strCMND);
                            arrParam2[4] = new SqlParameter("@BatDau", strBatDau);
                            arrParam2[5] = new SqlParameter("@KetThuc", strKetThuc);
                            SqlDataReader reader2 = SqlHelper.ExecuteReader(con, "THEMCHITIETGIAODICH", arrParam2);
                            MessageBox.Show("BAN DA DANG KY PHONG CHO RIENG MINH THANH CONG");
                        }
                        else
                        {
                            MessageBox.Show("BAN DA DANG KY PHONG CHO RIENG MINH THAT BAI");

                        }

                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
           
                }
                // cbShowListRoom.DataSource = CHITIETPHONGDAO.Instance.SHOWLISTROOM(strMaGD,strMaDoan,strHang,strHinhThuc,strTang,strSoPhong,strBatDau,strKetThuc);


            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string strMaGD = txtMaGD.Text.Trim();
            string strMaDoan = txtMaDoan.Text.Trim();
            string strHang = txtHang.Text.Trim();
            int strTang = (int)txtTang.Value;
            string strHinhThuc = txtHinhThuc.Text.Trim();
            DateTime strBatDau = dateBatDau.Value.Date;
            DateTime strKetThuc = dateKetThuc.Value.Date;
            int strSoPhong = (int)txtSoPhong.Value;
            string strErr = string.Empty;
            string strTen = txtTen3.Text.Trim();
            string strCMND = txtCMND3.Text.Trim();
            string strChonPhong = txtChonPhong3.Text.Trim();
            string strMaPhong = txtMaPhong3.Text.Trim();

            if (strMaGD == string.Empty || strMaDoan == string.Empty || strHang == string.Empty || strHinhThuc == string.Empty || strSoPhong == 0 || strTang == 0)
            {
                strErr = "Bạn vui lòng nhập Điền Đầy Đủ Thông Tin Đặt chỗ";
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
                        SqlParameter[] arrParam = new SqlParameter[6];
                        arrParam[0] = new SqlParameter("@MaDoan", strMaDoan);
                        arrParam[1] = new SqlParameter("@HoTen", strTen);
                        arrParam[2] = new SqlParameter("@CMND", strCMND);
                        arrParam[3] = new SqlParameter("@TenPhong", strChonPhong);
                        arrParam[4] = new SqlParameter("@MaPhong", strMaPhong);
                        arrParam[5] = new SqlParameter("@BatDau", strBatDau);
                        SqlDataReader reader = SqlHelper.ExecuteReader(con, "NHAPGDTHANHVIENDOAN", arrParam);

                        if (reader.Read() == true)
                        {
                            SqlParameter[] arrParam2 = new SqlParameter[5];
                            arrParam2[0] = new SqlParameter("@MaGD", strMaGD);
                            arrParam2[1] = new SqlParameter("@MaDoan", strMaDoan);
                            arrParam2[2] = new SqlParameter("@MaPhong", strMaPhong);
                            arrParam2[3] = new SqlParameter("@CMND", strCMND);
                            arrParam2[4] = new SqlParameter("@BatDau", strBatDau);
                            arrParam2[5] = new SqlParameter("@KetThuc", strKetThuc);
                            SqlDataReader reader2 = SqlHelper.ExecuteReader(con, "THEMCHITIETGIAODICH", arrParam2);
                            MessageBox.Show("BAN DA DANG KY PHONG CHO RIENG MINH THANH CONG");
                        }
                        else
                        {
                            MessageBox.Show("BAN DA DANG KY PHONG CHO RIENG MINH THAT BAI");

                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    
                }
                // cbShowListRoom.DataSource = CHITIETPHONGDAO.Instance.SHOWLISTROOM(strMaGD,strMaDoan,strHang,strHinhThuc,strTang,strSoPhong,strBatDau,strKetThuc);


            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            string strMaGD = txtMaGD.Text.Trim();
            string strMaDoan = txtMaDoan.Text.Trim();
            string strHang = txtHang.Text.Trim();
            int strTang = (int)txtTang.Value;
            string strHinhThuc = txtHinhThuc.Text.Trim();
            DateTime strBatDau = dateBatDau.Value.Date;
            DateTime strKetThuc = dateKetThuc.Value.Date;
            int strSoPhong = (int)txtSoPhong.Value;
            string strErr = string.Empty;
            string strTen = txtTen4.Text.Trim();
            string strCMND = txtCMND4.Text.Trim();
            string strChonPhong = txtChonPhong4.Text.Trim();
            string strMaPhong = txtMaPhong4.Text.Trim();

            if (strMaGD == string.Empty || strMaDoan == string.Empty || strHang == string.Empty || strHinhThuc == string.Empty || strSoPhong == 0 || strTang == 0)
            {
                strErr = "Bạn vui lòng nhập Điền Đầy Đủ Thông Tin Đặt chỗ";
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
                        SqlParameter[] arrParam = new SqlParameter[6];
                        arrParam[0] = new SqlParameter("@MaDoan", strMaDoan);
                        arrParam[1] = new SqlParameter("@HoTen", strTen);
                        arrParam[2] = new SqlParameter("@CMND", strCMND);
                        arrParam[3] = new SqlParameter("@TenPhong", strChonPhong);
                        arrParam[4] = new SqlParameter("@MaPhong", strMaPhong);
                        arrParam[5] = new SqlParameter("@BatDau", strBatDau);
                        SqlDataReader reader = SqlHelper.ExecuteReader(con, "NHAPGDTHANHVIENDOAN", arrParam);

                        if (reader.Read() == true)
                        {
                            SqlParameter[] arrParam2 = new SqlParameter[5];
                            arrParam2[0] = new SqlParameter("@MaGD", strMaGD);
                            arrParam2[1] = new SqlParameter("@MaDoan", strMaDoan);
                            arrParam2[2] = new SqlParameter("@MaPhong", strMaPhong);
                            arrParam2[3] = new SqlParameter("@CMND", strCMND);
                            arrParam2[4] = new SqlParameter("@BatDau", strBatDau);
                            arrParam2[5] = new SqlParameter("@KetThuc", strKetThuc);
                            SqlDataReader reader2 = SqlHelper.ExecuteReader(con, "THEMCHITIETGIAODICH", arrParam2);
                            MessageBox.Show("BAN DA DANG KY PHONG CHO RIENG MINH THANH CONG");
                        }
                        else
                        {
                            MessageBox.Show("BAN DA DANG KY PHONG CHO RIENG MINH THAT BAI");

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

        private void metroButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
   
            HuyDangKy huyDangKy = new HuyDangKy();
            huyDangKy.ShowDialog();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanPhong nhanPhong = new NhanPhong();
            nhanPhong.ShowDialog();
        }
    }
    
}
