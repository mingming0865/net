using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhongMay
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void btnTim_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("select * from LichDangKy inner join GiaoVien on LichDangKy.MaGV = GiaoVien.MaGV where TenGV like N'%{0}%'", txtTim.Text);
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvThongKe.DataSource = tb;
        }
    }
}
