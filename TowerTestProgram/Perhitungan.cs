using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;
using ICPDAS.OPC.NET;
using ICPDAS.OPC;
using ICPDAS.OPCDA;


namespace Program_Uji_Tower_V1
{
    public partial class Perhitungan: Form
    {
        //private ComboBox[] cmb_tags;
        public Perhitungan()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //for (int i = 0; i < 32; i++)
            //{
            //    string saveToTarget = cmb_tags[i].SelectedItem?.ToString();
            //    if (!string.IsNullOrEmpty(saveToTarget))
            //    {
            //        double.TryParse(txt_vals[i].Text, out double val);
            //        SaveToStaticMV(saveToTarget, val);
            //    }
            //}

            //Modul1
            double.TryParse(txt_op_ch0_md1.Text, out double op_ch0_md1);
            double.TryParse(txt_eks_ch0_md1.Text, out double eks_ch0_md1);
            double.TryParse(txt_mxload_ch0_md1.Text, out double mxload_ch0_md1);
            double.TryParse(txt_zero_ch0_md1.Text, out double zero_ch0_md1);
            double.TryParse(txt_mxtarik_ch0_md1.Text, out double mxtarik_ch0_md1);
            double hasil_kg_ch0_md1 = (mv.modul10_ch00 / (op_ch0_md1 * eks_ch0_md1)) * mxload_ch0_md1;
            double final_kg_ch0_md1 = hasil_kg_ch0_md1 - zero_ch0_md1;
            double nilai_persentarik_ch0_md1 = (final_kg_ch0_md1 / mxtarik_ch0_md1) * 100;

            lbl_mv_ch0_md1.Text = mv.modul1_ch00.ToString("F2");
            lbl_kgf_ch0_md1.Text = final_kg_ch0_md1.ToString("F2");
            db_modul1.nilai_kg_ch0 = final_kg_ch0_md1;
            db_modul1.nilai_kode_ch0 = txt_kode_ch0_md1.Text;
            db_modul1.nilai_persentarik_ch0 = nilai_persentarik_ch0_md1;

            double.TryParse(txt_op_ch1_md1.Text, out double op_ch1_md1);
            double.TryParse(txt_eks_ch1_md1.Text, out double eks_ch1_md1);
            double.TryParse(txt_mxload_ch1_md1.Text, out double mxload_ch1_md1);
            double.TryParse(txt_zero_ch1_md1.Text, out double zero_ch1_md1);
            double.TryParse(txt_mxtarik_ch1_md1.Text, out double mxtarik_ch1_md1);
            double hasil_kg_ch1_md1 = (mv.modul1_ch01 / (op_ch1_md1 * eks_ch1_md1)) * mxload_ch1_md1;
            double final_kg_ch1_md1 = hasil_kg_ch1_md1 - zero_ch1_md1;
            double nilai_persentarik_ch1_md1 = (final_kg_ch1_md1 / mxtarik_ch1_md1) * 100;

            lbl_mv_ch1_md1.Text = mv.modul1_ch01.ToString("F2");
            lbl_kgf_ch1_md1.Text = final_kg_ch1_md1.ToString("F2");
            db_modul1.nilai_kg_ch1 = final_kg_ch1_md1;
            db_modul1.nilai_kode_ch1 = txt_kode_ch1_md1.Text;
            db_modul1.nilai_persentarik_ch1 = nilai_persentarik_ch1_md1;
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            
        }

        private void Perhitungan_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1000;

            //IsiComboMVProperties(cmb_tag1, cmb_tag2, cmb_tag3, cmb_tag4);
        }

        //private void IsiComboMVProperties(params ComboBox[] comboBoxes)
        //{
        //    var mvProps = typeof(mv).GetProperties().Select(p => p.Name).ToArray();
        //    foreach (var cmb in comboBoxes)
        //    {
        //        cmb.Items.Clear();
        //        cmb.Items.AddRange(mvProps);
        //        cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        //    }
        //}

        private void ckc_md1_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md1 = ckc_md1.Checked;
        }

        private void ckc_md3_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md3 = ckc_md3.Checked;
        }

        private void ckc_md4_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md4 = ckc_md4.Checked;
        }

        private void ckc_md6_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md6 = ckc_md6.Checked;
        }

        private void ckc_md7_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md7 = ckc_md7.Checked;
        }

        private void ckc_md8_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md8 = ckc_md8.Checked;
        }

        private void ckc_md9_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md9 = ckc_md9.Checked;
        }

        private void ckc_md10_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md10 = ckc_md10.Checked;
        }

        private void ckc_md11_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md11 = ckc_md11.Checked;
        }

        private void ckc_md12_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md12 = ckc_md12.Checked;
        }

        private void ckc_md13_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md13 = ckc_md13.Checked;
        }

        private void ckc_md14_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md14 = ckc_md14.Checked;

        }

        private void ckc_md15_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md15 = ckc_md15.Checked;
        }

        private void ckc_md16_CheckedChanged(object sender, EventArgs e)
        {
            ck_box.md16 = ckc_md16.Checked;
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Jangan Di Tutup Jika Masih Dalam Pengujian!! , Yakin Akan Tetap Keluar ?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btn_minimized_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
