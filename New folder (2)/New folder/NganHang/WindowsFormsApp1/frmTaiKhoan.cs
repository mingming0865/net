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
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            string truy_van = "select * from TaiKhoan";
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvTaikhoan.DataSource = tb;
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        //    private void btnTim_Click(object sender, EventArgs e)
        //    {
        //        //string truy_van = String.Format("select * from TaiKhoan where MaKH like '%{0}%'", txtSearch.Text);
        //        string truy_van = String.Format("select TaiKhoan.* from TaiKhoan inner join KhachHang on TaiKhoan.MaKH = ");
        //    }   DataTable tb = 
        //}
    }
}
