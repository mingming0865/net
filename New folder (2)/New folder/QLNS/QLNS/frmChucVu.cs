using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class frmChucVu : Form
    {
        public frmChucVu()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            string truy_van = "select * from ChucVu order by CapDo";
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvChucvu.DataSource = tb;
        }
    }
}
