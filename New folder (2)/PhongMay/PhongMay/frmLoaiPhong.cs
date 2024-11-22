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
    public partial class frmLoaiPhong : Form
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            string truy_van = "select * from LoaiPhong";
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvLoaiPhong.DataSource = tb;
        }
    }
}
