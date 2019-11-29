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
    public partial class Menu : Form
    {
        public Menu()
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
            this.Hide();
            DatCho datCho = new DatCho();
            datCho.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanPhong nhanPhong = new NhanPhong();
            nhanPhong.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            TraPhongvaThanhToan traPhongvaThanhToan = new TraPhongvaThanhToan();
            traPhongvaThanhToan.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HuyDangKy huyDangKy = new HuyDangKy();
            huyDangKy.ShowDialog();
        }
    }
}
