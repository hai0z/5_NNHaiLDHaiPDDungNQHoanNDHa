﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBHTH_PhanDinhDung
{
    public partial class frm_giaodienchinh_ha : Form
    {
        public frm_giaodienchinh_ha()
        {
            InitializeComponent();
        }

        private void btn_gttv_ha_Click(object sender, EventArgs e)
        {
            frm_gttv_ha gttv = new frm_gttv_ha();
            this.Hide();
            gttv.ShowDialog();
        }

        private void frm_giaodienchinh_ha_Load(object sender, EventArgs e)
        {
            if(Program.role == false)
            {
                btn_qldoanhthu_ha.Enabled = false;
                btn_qlnhanvien_ha.Enabled=false;
            }
            qlbh_dungDataContext qlbh = new qlbh_dungDataContext();
            var nhanvien = qlbh.Nhanviens.Select(nv => new { nv.TenNV, nv.MaNV }).Where(nv => nv.MaNV == Program.mnv).SingleOrDefault();
            if(nhanvien != null)
            {
                lb_tennv_ha.Text = $"Xin chào! {nhanvien.TenNV}";
            }

        }

        private void frm_giaodienchinh_ha_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_dangxuat_ha_Click(object sender, EventArgs e)
        {
            //confirm logout
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Program.mnv = "";
                Program.role = false;
                this.Hide();
                frm_dangnhap_dung dangnhap = new frm_dangnhap_dung();
                dangnhap.ShowDialog();
            }
        }

        private void btn_qlkhachhang_ha_Click(object sender, EventArgs e)
        {
            try
            {
                frm_qlkh_LDHai qlkh = new frm_qlkh_LDHai();
                this.Hide();
                qlkh.ShowDialog();
            }
            catch (Exception){ }
        }

        private void btn_qlloaihang_ha_Click(object sender, EventArgs e)
        {
            frm_qlloaihang_hoan qllh = new frm_qlloaihang_hoan();
            this.Hide();
            qllh.ShowDialog();
        }

        private void btn_qlmathang_ha_Click(object sender, EventArgs e)
        {
            frm_qlhh_LDHai qlhh = new frm_qlhh_LDHai();
            this.Hide();
            qlhh.ShowDialog();
        }

        private void btn_qlnhanvien_ha_Click(object sender, EventArgs e)
        {
            frm_qlnv_hai qlnv = new frm_qlnv_hai();
            Hide();
            qlnv.ShowDialog();
        }

        private void btn_muahang_ha_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_qlmuahang_LDHai muahang = new frm_qlmuahang_LDHai();
            muahang.ShowDialog();
        }

        private void btn_qldoanhthu_ha_Click(object sender, EventArgs e)
        {
            Hide();
            frm_qldoanhthu_hai qldt = new frm_qldoanhthu_hai();
            qldt.ShowDialog();
        }

        private void btn_baocao_hai_Click(object sender, EventArgs e)
        {

            Hide();
            frm_baocao_hai baocao = new frm_baocao_hai();
            baocao.ShowDialog();
        }

        private void btn_qlhd_hai_Click(object sender, EventArgs e)
        {
            Hide();
            frm_qlhoadon_hai qlhd = new frm_qlhoadon_hai();
            qlhd.ShowDialog();
        }
    }
}
