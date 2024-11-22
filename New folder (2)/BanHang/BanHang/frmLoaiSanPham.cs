using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanHang
{
    public partial class frmLoaiSanPham : Form
    {
        public frmLoaiSanPham()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            string truy_van = "select * from LoaiSanPham order by MaSanPham DESC";
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvLoaiSanPham.DataSource = tb;
        }
    }
}
