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
    public partial class frmNhanSu : Form
    {
        public frmNhanSu()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void frmNhanSu_Load(object sender, EventArgs e)
        {
            getData();
        }

        public void getData()
        {
            string truy_van = "select * from NhanVien";
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvNhanSu.DataSource = tb;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("select * from NhanVien where TenNhanVien like N'%{0}%'", txtTim.Text);
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvNhanSu.DataSource = tb;

        }

        private void dgvNhanSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if(r >= 0)
            {
                txtMaNV.Text = dgvNhanSu.Rows[r].Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = dgvNhanSu.Rows[r].Cells["TenNhanVien"].Value.ToString();
                txtPhongBan.Text = dgvNhanSu.Rows[r].Cells["MaPhong"].Value.ToString();
                txtChucVu.Text = dgvNhanSu.Rows[r].Cells["MaChucVu"].Value.ToString();
                txtMaNV.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        public void clearText()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtPhongBan.Text = "";
            txtChucVu.Text = "";
            txtMaNV.Enabled = true; 
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
              clearText();
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("insert into NhanVien VALUES('{0}', N'{1}', '{2}', '{3}')",
                   txtMaNV.Text,
                   txtTenNV.Text,
                   txtPhongBan.Text,
                   txtChucVu.Text
                );
            bool kt = kn.ThucThi(truy_van);
            if(kt == true)
            {
                MessageBox.Show("Thêm mới thành công");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("update NhanVien set TenNhanVien = N'{1}', MaPhong='{2}', MaChucVu='{3}' where MaNhanVien ='{0}'",
                   txtMaNV.Text,
                   txtTenNV.Text,
                   txtPhongBan.Text,
                   txtChucVu.Text
                );
            bool kt = kn.ThucThi(truy_van);
            if (kt == true)
            {
                MessageBox.Show("Sửa thành công");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("delete NhanVien where MaNhanVien='{0}'",
                   txtMaNV.Text,
                   txtTenNV.Text,
                   txtPhongBan.Text,
                   txtChucVu.Text
                );
            bool kt = kn.ThucThi(truy_van);
            if (kt == true)
            {
                MessageBox.Show("Xóa thành công");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
    }
}
