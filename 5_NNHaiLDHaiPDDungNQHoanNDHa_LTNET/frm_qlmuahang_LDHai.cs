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
    public partial class frm_qlmuahang_LDHai : Form
    {
        public frm_qlmuahang_LDHai()
        {
            InitializeComponent();
        }

        int i;

        private void load()
        {
            qlbh_dungDataContext qlbh = new qlbh_dungDataContext();
            var dssp = qlbh.Hanghoas.Select(p => new { p.Mahang, p.Tenhang, p.DVT, p.Dongia});
            dgv_muahang_LDHai.DataSource = dssp;

            qlbh_dungDataContext khachhang = new qlbh_dungDataContext();
            var kh = khachhang.Khachhangs.Select(x => x);
            cbx_tkh_LDHai.DataSource = kh;
            cbx_tkh_LDHai.DisplayMember = "TenKH";
            cbx_tkh_LDHai.ValueMember = "MaKH";
        }
        
        private void frm_qlmuahang_LDHai_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btn_quaylai_LDHai_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_giaodienchinh_ha frm = new frm_giaodienchinh_ha();
            frm.Show();
        }

        private void dgv_muahang_LDHai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_muahang_LDHai.CurrentRow.Index;
            txt_msp_LDHai.Text = dgv_muahang_LDHai.Rows[i].Cells[0].Value.ToString();
            txt_tsp_LDHai.Text = dgv_muahang_LDHai.Rows[i].Cells[1].Value.ToString();
        }

        private void txt_tk_LDHai_TextChanged(object sender, EventArgs e)
        {
            if (txt_tk_LDHai.Text == "")
            {
                load();
            } else
            {
                qlbh_dungDataContext qlbh = new qlbh_dungDataContext();
                var dssp = qlbh.Hanghoas.Where(p => p.Tenhang.Contains(txt_tk_LDHai.Text)).Select(p => 
                new { p.Mahang, p.Tenhang, p.DVT, p.Dongia });
                dgv_muahang_LDHai.DataSource = dssp;
            }
        }

        private void btn_them_LDHai_Click(object sender, EventArgs e)
        {
            if(txt_sl_LDHai.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập số lượng");
                return;
            }
            try
            {
                int soluong = int.Parse(txt_sl_LDHai.Text);
                if (soluong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Số lượng phải là số");
                return;
            }
            DataGridViewRow row = (DataGridViewRow)dgv_giohang_LDHai.Rows[0].Clone();
            int i = dgv_muahang_LDHai.CurrentRow.Index;
            row.Cells[0].Value = txt_msp_LDHai.Text;
            row.Cells[1].Value = txt_tsp_LDHai.Text;
            row.Cells[2].Value = txt_sl_LDHai.Text;
            row.Cells[3].Value = dgv_muahang_LDHai.Rows[i].Cells[3].Value.ToString();
            int sl = int.Parse(row.Cells[2].Value.ToString());
            int dg = int.Parse(row.Cells[3].Value.ToString());
            int tt = sl * dg;
            row.Cells[4].Value = tt.ToString();
            if (dgv_giohang_LDHai.Rows.Count == 1)
            {
                dgv_giohang_LDHai.Rows.Add(row);

            } else
            {
                int check = 0;
                for (int j = 0; j < dgv_giohang_LDHai.Rows.Count - 1; j++)
                {
                    if (dgv_giohang_LDHai.Rows[j].Cells[0].Value.ToString().Equals(txt_msp_LDHai.Text))
                    {
                        check = 1;
                        int slsp = int.Parse(txt_sl_LDHai.Text);
                        dgv_giohang_LDHai.Rows[j].Cells[2].Value = 
                            int.Parse(dgv_giohang_LDHai.Rows[j].Cells[2].Value.ToString()) + slsp;
                        dgv_giohang_LDHai.Rows[j].Cells[4].Value =
                            int.Parse(dgv_giohang_LDHai.Rows[j].Cells[2].Value.ToString())
                            * int.Parse(dgv_giohang_LDHai.Rows[j].Cells[3].Value.ToString());
                        break;
                    }
                }
                if (check == 0)
                {
                    dgv_giohang_LDHai.Rows.Add(row);

                }
            }
            txt_sl_LDHai.Clear();
        }

        private void dgv_giohang_LDHai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = dgv_giohang_LDHai.CurrentRow.Index;
        }

        private void btn_xoa_LDHai_Click(object sender, EventArgs e)
        {
            dgv_giohang_LDHai.Rows.RemoveAt(i);
            dgv_giohang_LDHai.Refresh();

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            int tongtien = 0;
            for (int j = 0; j < dgv_giohang_LDHai.Rows.Count - 1; j++)
            {
                tongtien += int.Parse(dgv_giohang_LDHai.Rows[j].Cells[4].Value.ToString());
            }

            txt_tt_LDHai.Text = tongtien.ToString();
        }

        private void txt_tkd_LDHai_TextChanged(object sender, EventArgs e)
        {
            if (txt_tkd_LDHai.Text.Length == 0)
            {
                return;
                
            } else
            {
                txt_ttl_LDHai.Text = (int.Parse(txt_tkd_LDHai.Text) - int.Parse(txt_tt_LDHai.Text)).ToString();
            }
        }

        private void btn_lhd_LDHai_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_mhd_LDHai.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập mã hóa đơn","thông báo");
                    return;
                }
                string mahoadon = txt_mhd_LDHai.Text;
                string makhachhang = cbx_tkh_LDHai.SelectedValue.ToString();
                DateTime ngaylap = DateTime.Now;
                qlbh_dungDataContext qlbh = new qlbh_dungDataContext();
                Hoadon hoadon = new Hoadon();
                hoadon.Ngayban = ngaylap;
                hoadon.SoHD = mahoadon;
                hoadon.MaNV = Program.mnv;
                hoadon.MaKH = makhachhang;
                qlbh.Hoadons.InsertOnSubmit(hoadon);
                qlbh.SubmitChanges();
                for (int i = 0; i < dgv_giohang_LDHai.Rows.Count - 1; i++)
                {
                    CT_Hoadon cthoadon = new CT_Hoadon();
                    cthoadon.SoHD = mahoadon;
                    cthoadon.Mahang = dgv_giohang_LDHai.Rows[i].Cells[0].Value.ToString();
                    cthoadon.Soluong = int.Parse(dgv_giohang_LDHai.Rows[i].Cells[2].Value.ToString());
                    cthoadon.Dongiaban = int.Parse(dgv_giohang_LDHai.Rows[i].Cells[3].Value.ToString());
                    qlbh.CT_Hoadons.InsertOnSubmit(cthoadon);
                    qlbh.SubmitChanges();
                }
                MessageBox.Show("Lập hoá đơn thành công");
                frm_hoadon_hai rp_hoadon = new frm_hoadon_hai(mahoadon);
                rp_hoadon.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
  
}
