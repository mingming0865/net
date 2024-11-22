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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            getDaTa();
        }

        public void getDaTa()
        {
            string truy_van = "select * from SanPham";
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvSanPham.DataSource = tb;
        }

        public void clearText()
        {
            txtMaSP.Text = "";
            txtTen.Text = "";
            txtDonGia.Text = "";
            txtHinhAnh.Text = "";
            txtMoTaNgan.Text = "";
            txtMoTaChiTiet.Text = "";
            txtMaLoaiSP.Text = "";
            txtMaSP.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            getDaTa();
            clearText();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("select * from SanPham inner join LoaiSanPham on SanPham.MaLoaiSp  = LoaiSanPham.MaLoaiSP where Ten = N'%{0}%'", txtTim.Text);
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvSanPham.DataSource = tb;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("insert into SanPham(MaSP, Ten, DonGia, HinhAnh, MoTaNgan, MoTaChiTiet, MaLoaiSP) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'",
                txtMaSP.Text,
                 txtTen.Text,
                txtDonGia.Text,
                txtHinhAnh.Text,
                txtMoTaNgan.Text,
                txtMoTaChiTiet.Text,
                txtMaLoaiSP.Text
                );
            bool kt = kn.ThucThi(truy_van);
            if(kt == true)
            {
                MessageBox.Show("Thêm thành công");
                btnMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaSP.Text = dgvSanPham.Rows[r].Cells["MaSP"].Value.ToString();
                txtTen.Text = dgvSanPham.Rows[r].Cells["Ten"].Value.ToString();
                txtDonGia.Text = dgvSanPham.Rows[r].Cells["DonGia"].Value.ToString();
                txtHinhAnh.Text = dgvSanPham.Rows[r].Cells["HinhAnh"].Value.ToString();
                txtMoTaNgan.Text = dgvSanPham.Rows[r].Cells["MoTaNgan"].Value.ToString();
                txtMoTaChiTiet.Text = dgvSanPham.Rows[r].Cells["MoTaChiTiet"].Value.ToString();
                txtMaLoaiSP.Text = dgvSanPham.Rows[r].Cells["MaLoaiSP"].Value.ToString();
                txtMaSP.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("update SanPham set Ten = '{1}', DonGia = '{2}', HinhAnh = '{3}', MoTaNgan = '{4}', MoTaChiTiet = '{5}', MaLoaiSP = '{6}' where MaSP = {0}",
                txtMaSP.Text,
                 txtTen.Text,
                txtDonGia.Text,
                txtHinhAnh.Text,
                txtMoTaNgan.Text,
                txtMoTaChiTiet.Text,
                txtMaLoaiSP.Text
                );
            bool kt = kn.ThucThi(truy_van);
            if (kt == true)
            {
                MessageBox.Show("Sửa thành công");
                btnMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("delete from SanPham where MaSP = {0}",
                txtMaSP.Text,
                 txtTen.Text,
                txtDonGia.Text,
                txtHinhAnh.Text,
                txtMoTaNgan.Text,
                txtMoTaChiTiet.Text,
                txtMaLoaiSP.Text
                );
            bool kt = kn.ThucThi(truy_van);
            if (kt == true)
            {
                MessageBox.Show("Xóa thành công");
                btnMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
    }
}
