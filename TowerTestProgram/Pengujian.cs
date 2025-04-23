using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Program_Uji_Tower_V1
{
    public partial class Pengujian: Form
    {
        public Pengujian()
        {
            InitializeComponent();
            LoadData();
        }

        private void Pengujian_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
        }

        private void LoadData()
        {
            // Tambahkan data dari db_modul1 langsung ke CheckedListBox
            checkedListBox1.Items.Add(db_modul1.nilai_kode_ch0);
            checkedListBox1.Items.Add(db_modul1.nilai_kode_ch1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            grup_A.Visible = ck_box.md1;
            grup_B.Visible = ck_box.md3;
            grup_C.Visible = ck_box.md4;
            grup_D.Visible = ck_box.md6;
            grup_E.Visible = ck_box.md7;
            grup_F.Visible = ck_box.md8;
            grup_G.Visible = ck_box.md9;
            grup_H.Visible = ck_box.md10;
            grup_I.Visible = ck_box.md11;
            grup_J.Visible = ck_box.md12;
            grup_K.Visible = ck_box.md13;
            grup_L.Visible = ck_box.md14;
            grup_M.Visible = ck_box.md15;
            grup_N.Visible = ck_box.md16;

            //Perhitungan
            double total_transversal = 0;
            foreach (object item in checkedListBox1.CheckedItems)
            {
                if (item.ToString() == db_modul1.nilai_kode_ch0)
                {
                    total_transversal += db_modul1.nilai_kg_ch0; // Ambil nilai berat
                }
                if (item.ToString() == db_modul1.nilai_kode_ch1)
                {
                    total_transversal += db_modul1.nilai_kg_ch1; // Ambil nilai berat
                }
            }

            //kelompok A
            lbl_kg_a1.Text = db_modul1.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_a1.Text = db_modul1.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_a1.Text = db_modul1.nilai_kode_ch0;

            lbl_kg_a2.Text = db_modul1.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_a2.Text = db_modul1.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_a2.Text = db_modul1.nilai_kode_ch1;

            lbl_kg_a3.Text = db_modul2.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_a3.Text = db_modul2.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_a3.Text = db_modul2.nilai_kode_ch0;

            //kelompok B
            lbl_kg_b1.Text = db_modul2.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_b1.Text = db_modul2.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_b1.Text = db_modul2.nilai_kode_ch1;

            lbl_kg_b2.Text = db_modul3.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_b2.Text = db_modul3.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_b2.Text = db_modul3.nilai_kode_ch0;

            lbl_kg_b3.Text = db_modul3.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_b3.Text = db_modul3.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_b3.Text = db_modul3.nilai_kode_ch1;

            //kelompok C
            lbl_kg_c1.Text = db_modul4.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_c1.Text = db_modul4.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_c1.Text = db_modul4.nilai_kode_ch0;

            lbl_kg_c2.Text = db_modul4.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_c2.Text = db_modul4.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_c2.Text = db_modul4.nilai_kode_ch1;

            lbl_kg_c3.Text = db_modul5.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_c3.Text = db_modul5.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_c3.Text = db_modul5.nilai_kode_ch0;

            //kelompok D
            lbl_kg_d1.Text = db_modul5.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_d1.Text = db_modul5.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_d1.Text = db_modul5.nilai_kode_ch1;

            lbl_kg_d2.Text = db_modul6.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_d2.Text = db_modul6.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_d2.Text = db_modul6.nilai_kode_ch0;

            lbl_kg_d3.Text = db_modul6.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_d3.Text = db_modul6.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_d3.Text = db_modul6.nilai_kode_ch1;

            //kelompok E
            lbl_kg_e1.Text = db_modul7.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_e1.Text = db_modul7.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_e1.Text = db_modul7.nilai_kode_ch0;

            lbl_kg_e2.Text = db_modul7.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_e2.Text = db_modul7.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_e2.Text = db_modul7.nilai_kode_ch1;

            //kelompok F
            lbl_kg_f1.Text = db_modul8.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_f1.Text = db_modul8.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_f1.Text = db_modul8.nilai_kode_ch0;

            lbl_kg_f2.Text = db_modul8.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_f2.Text = db_modul8.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_f2.Text = db_modul8.nilai_kode_ch1;

            //kelompok G
            lbl_kg_g1.Text = db_modul9.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_g1.Text = db_modul9.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_g1.Text = db_modul9.nilai_kode_ch0;

            lbl_kg_g2.Text = db_modul9.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_g2.Text = db_modul9.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_g2.Text = db_modul9.nilai_kode_ch1;

            //kelompok H
            lbl_kg_h1.Text = db_modul10.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_h1.Text = db_modul10.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_h1.Text = db_modul10.nilai_kode_ch0;

            lbl_kg_h2.Text = db_modul10.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_h2.Text = db_modul10.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_h2.Text = db_modul10.nilai_kode_ch1;

            //kelompok I
            lbl_kg_i1.Text = db_modul11.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_i1.Text = db_modul11.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_i1.Text = db_modul11.nilai_kode_ch0;

            lbl_kg_i2.Text = db_modul11.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_i2.Text = db_modul11.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_i2.Text = db_modul11.nilai_kode_ch1;

            //kelompok J
            lbl_kg_j1.Text = db_modul12.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_j1.Text = db_modul12.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_j1.Text = db_modul12.nilai_kode_ch0;

            lbl_kg_j2.Text = db_modul12.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_j2.Text = db_modul12.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_j2.Text = db_modul12.nilai_kode_ch1;

            //kelompok K
            lbl_kg_k1.Text = db_modul13.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_k1.Text = db_modul13.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_k1.Text = db_modul13.nilai_kode_ch0;

            lbl_kg_k2.Text = db_modul13.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_k2.Text = db_modul13.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_k2.Text = db_modul13.nilai_kode_ch1;

            //kelompok L
            lbl_kg_l1.Text = db_modul14.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_l1.Text = db_modul14.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_l1.Text = db_modul14.nilai_kode_ch0;

            lbl_kg_l2.Text = db_modul14.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_l2.Text = db_modul14.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_l2.Text = db_modul14.nilai_kode_ch1;

            //kelompok M
            lbl_kg_m1.Text = db_modul15.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_m1.Text = db_modul15.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_m1.Text = db_modul15.nilai_kode_ch0;

            lbl_kg_m2.Text = db_modul15.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_m2.Text = db_modul15.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_m2.Text = db_modul15.nilai_kode_ch1;

            //kelompok N
            lbl_kg_n1.Text = db_modul16.nilai_kg_ch0.ToString("F2");
            lbl_persentarik_n1.Text = db_modul16.nilai_persentarik_ch0.ToString("F2");
            lbl_kode_n1.Text = db_modul16.nilai_kode_ch0;

            lbl_kg_n2.Text = db_modul16.nilai_kg_ch1.ToString("F2");
            lbl_persentarik_n2.Text = db_modul16.nilai_persentarik_ch1.ToString("F2");
            lbl_kode_n2.Text = db_modul16.nilai_kode_ch1;

        }

        private void btn_minimized_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Jangan Di Tutup Jika Masih Dalam Pengujian!! , Yakin Akan Tetap Keluar ?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
