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
    public partial class frmLichDangKy : Form
    {
        public frmLichDangKy()
        {
            InitializeComponent();
        }
        //1
        KetNoi kn = new KetNoi();
        //2
        private void frmLichDangKy_Load(object sender, EventArgs e)
        {
            getData();
        }
        //3
        public void getData()
        {
            string truy_van = "select * from LichDangKy";
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvLichDangKy.DataSource = tb;
        }
        //4
        public void clearText()
        {
            txtMaPM.Text = "";
            txtMaGV.Text = "";
            txtBatDau.Text = "";
            txtKetThuc.Text = "";
            txtNamHoc.Text = "";
            txtMaPM.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        //5
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearText();
            getData();
        }
        //6
        private void btnTim_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("select * from LichDangKy inner join PhongMay on LichDangKy.MaPM = PhongMay.MaPM where TenPM like N'%{0}%'", txtTim.Text);
            DataTable tb = kn.LayDuLieu(truy_van);
            dgvLichDangKy.DataSource = tb;
        }
        //7
        private void dgvLichDangKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaPM.Text = dgvLichDangKy.Rows[r].Cells["MaPM"].Value.ToString();
                txtMaGV.Text = dgvLichDangKy.Rows[r].Cells["MaGV"].Value.ToString();
                txtBatDau.Text = dgvLichDangKy.Rows[r].Cells["BatDau"].Value.ToString();
                txtKetThuc.Text = dgvLichDangKy.Rows[r].Cells["KetThuc"].Value.ToString();
                txtNamHoc.Text = dgvLichDangKy.Rows[r].Cells["NamHoc"].Value.ToString();
                txtMaPM.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
        //8
        private void btnThem_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("insert into LichDangKy(MaPM,MaGV,BatDau,KetThuc,NamHoc) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')",
                   txtMaPM.Text,
                   txtMaGV.Text,
                   txtBatDau.Text,
                   txtKetThuc.Text,
                   txtNamHoc.Text
                );
            bool kt = kn.ThucThi(truy_van);
            if (kt == true)
            {
                MessageBox.Show("Thêm mới thành công");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại");
            }
        }
        //9
        private void btnSua_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("update LichDangKy set MaGV = '{1}', BatDau = '{2}', KetThuc ='{3}', NamHoc ='{4}' where MaPM ='{0}'",
                   txtMaPM.Text,
                   txtMaGV.Text,
                   txtBatDau.Text,
                   txtKetThuc.Text,
                   txtNamHoc.Text
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
        //10
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string truy_van = string.Format("delete MaPM where MaPM='{0}'",
                   txtMaPM.Text
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

   
