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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("select * from NguoiDung where TaiKhoan = '{0}' and MatKhau = '{1}'", txtTaiKhoan.Text, txtMatKhau.Text);
            DataTable tb = kn.LayDuLieu(truy_van);
            if(tb.Rows.Count == 1)
            {
                MessageBox.Show("Đăng nhập thành công");
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");

            }
        }
    }
}
