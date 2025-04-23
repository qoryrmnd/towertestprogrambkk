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

namespace Program_Uji_Tower_V1
{
    public partial class Calibration: Form
    {
        public Calibration()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_mvmaster.Text = mv.master_data.ToString("F3");
            lbl_mvslave.Text = mv.slave_data.ToString("F3");

            // Parameter sensor dari TextBox
            double.TryParse(txt_opmaster.Text, out double opmaster); // mV/V
            double.TryParse(lbl_eksitasi.Text, out double eksitasimaster); // Volt
            double.TryParse(txt_maxloadmaster.Text, out double maxloadmaster); // Kgf
            double.TryParse(txt_zeromaster.Text, out double zeromaster); // Kgf
            //rumus Kgf belum zero
            double hasilmaster = (mv.master_data / (opmaster * eksitasimaster)) * maxloadmaster;
            //setelah zero
            double hasilfinalmaster = hasilmaster - zeromaster;
            //menampilkan hasil zero
            lbl_nilaimasterkg.Text = hasilfinalmaster.ToString("F2");

            // Parameter sensor dari TextBox untuk slave
            double.TryParse(txt_opslave.Text, out double opslave); // mV/V
            double.TryParse(lbl_eksitasi.Text, out double eksitasislave); // Volt
            double.TryParse(txt_maxloadslave.Text, out double maxloadslave); // Kgf
            double.TryParse(txt_zeroslave.Text, out double zeroslave); // Kgf

            // Hitung Kgf untuk slave
            double hasilslave = (mv.slave_data / (opslave * eksitasislave)) * maxloadslave;
            // setelah zero
            double hasilfinalslave = hasilslave - zeroslave;
            // menampilkan hasil slave
            lbl_nilaislavekg.Text = hasilfinalslave.ToString("F2");

        }

        private void Calibration_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1000;
            timer2.Start();
            lbl_tanggal.Text = DateTime.Now.ToLongDateString();
            txt_idmaster.Text = nameof(mv.master_data);
            txt_idslave.Text = nameof(mv.slave_data);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            lbl_waktu.Text = DateTime.Now.ToLongTimeString();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
