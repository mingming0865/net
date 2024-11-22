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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void lịchĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLichDangKy frm = new frmLichDangKy();
            frm.MdiParent = this;
            frm.Show();
        }

        private void loạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiPhong frm = new frmLoaiPhong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.MdiParent = this;
            frm.Show();
        }

        
    }
}
