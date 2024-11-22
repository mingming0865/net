using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmTK : Form
    {
        public frmTK()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void frmLoaiTaiKhoan_Load(object sender, EventArgs e)
        {
            string truy_van = "select * from LoaiTK order by CapDo DESC";
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvLoaiTK.DataSource = tb;
        }
    }
}
