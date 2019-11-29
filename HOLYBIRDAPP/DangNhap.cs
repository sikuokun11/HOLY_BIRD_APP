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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;

        protected override void OnPaintBackground(PaintEventArgs e) {
            Rectangle rc = ClientRectangle;
            if (rc.IsEmpty)
                return;
            if (rc.Width == 0 || rc.Height == 0)
                return;
            using (LinearGradientBrush brush = new LinearGradientBrush(rc,Color.White,Color.FromArgb(196,232,250),90F)) {
                e.Graphics.FillRectangle(brush, rc);
            }
        }

        public void Hienthi() {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strUserName = txtUserName.Text.Trim();
            string strPassword = txtPassword.Text.Trim();
            string strErr = string.Empty;
            if (strUserName == string.Empty)
            {
                strErr = "Bạn vui lòng nhập tên đăng nhập";
            }
            if (strPassword == string.Empty)
            {
                strErr += "\nBạn vui lòng nhập mật khẩu";
            }
            if (strErr != string.Empty)
            {
                MessageBox.Show("ERR:" + strErr);
                return;
            }
            try {
                string con = @"server=DESKTOP-UU88J58\SQLEXPRESS;database=HOLYBIRD_DOAN2;Integrated Security=True";
                SqlParameter[] arrParam = new SqlParameter[2];
                arrParam[0] = new SqlParameter("@TenDangNhap", strUserName);
                arrParam[1] = new SqlParameter("@MatKhau", strPassword);
                SqlDataReader reader = SqlHelper.ExecuteReader(con, "KIEMTRATAIKHOAN", arrParam);
                if (reader.Read() == true)
                {
                    MessageBox.Show("DANG NHAP THANH CONG");
                    this.Hide();
                    // Chuyen man hanh sang Dat Cho
                    Menu menu = new Menu();
                    menu.ShowDialog();
                }
                else
                    MessageBox.Show("DANG NHAP THAT BAI");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
                
            




        }
    }
}
