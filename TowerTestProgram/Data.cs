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

namespace Program_Uji_Tower_V1
{
    public partial class Data: Form
    {
        IntPtr hPort;

        //NILAI AI
        float ai_ch0_md1 = 0, ai_ch1_md1 = 0;
        float ai_ch0_md2 = 0, ai_ch1_md2 = 0;
        float ai_ch0_md3 = 0, ai_ch1_md3 = 0;
        float ai_ch0_md4 = 0, ai_ch1_md4 = 0;
        float ai_ch0_md5 = 0, ai_ch1_md5 = 0;
        float ai_ch0_md6 = 0, ai_ch1_md6 = 0;
        float ai_ch0_md7 = 0, ai_ch1_md7 = 0;
        float ai_ch0_md8 = 0, ai_ch1_md8 = 0;
        float ai_ch0_md9 = 0, ai_ch1_md9 = 0;
        float ai_ch0_md10 = 0, ai_ch1_md10 = 0;
        float ai_ch0_md11 = 0, ai_ch1_md11 = 0;
        float ai_ch0_md12 = 0, ai_ch1_md12 = 0;
        float ai_ch0_md13 = 0, ai_ch1_md13 = 0;
        float ai_ch0_md14 = 0, ai_ch1_md14 = 0;
        float ai_ch0_md15 = 0, ai_ch1_md15 = 0;
        float ai_ch0_md16 = 0, ai_ch1_md16 = 0;

        public Data()
        {
            InitializeComponent();
            InitializeBaudRateSelector();
            LoadComPort();
        }

        private void LoadComPort()
        {
            string[] portList = SerialPort.GetPortNames();
            foreach (string s in portList)
            {
                com_port.Items.Add(s);
            }
            com_port.SelectedIndex = 0;
        }

        private void InitializeBaudRateSelector()
        {
            com_baud.Items.AddRange(new object[] { 9600, 14400, 19200, 38400, 57600, 115200 });
            com_baud.SelectedIndex = 0;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            hPort = PACNET.UART.Open(com_port.Text + "," + com_baud.Text);

            if (hPort == (IntPtr)(-1))
            {
                MessageBox.Show("error code" + PACNET.ErrHandling.GetLastError());
            }
            else
            {
                btn_connect.Visible = false;
                btn_discon.Visible = true;
                timer1.Start(); // Mulai timer saat port terbuka
                timer1.Interval = 200;
            }
        }

        private void btn_discon_Click(object sender, EventArgs e)
        {
            PACNET.UART.Close(hPort);
            btn_connect.Visible = true;
            btn_discon.Visible = false;
            timer1.Stop(); // Hentikan timer saat port ditutup
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ////COBAA
            int jumlahModul = 5; // Ubah sesuai jumlah modul yang diperlukan

            // Array untuk menyimpan ID dan channel
            int[] id_md = new int[jumlahModul];
            int[] ch0_md = new int[jumlahModul];
            int[] ch1_md = new int[jumlahModul];
            float[] ai_ch0_md = new float[jumlahModul];
            float[] ai_ch1_md = new float[jumlahModul];

            // Loop untuk membaca data dari semua modul
            for (int i = 0; i < jumlahModul; i++)
            {
                TextBox txtId = this.Controls.Find($"txt_id_md{i + 1}", true).FirstOrDefault() as TextBox;
                TextBox txtCh0 = this.Controls.Find($"txt_ch0_md{i + 1}", true).FirstOrDefault() as TextBox;
                TextBox txtCh1 = this.Controls.Find($"txt_ch1_md{i + 1}", true).FirstOrDefault() as TextBox;

                if (txtId != null) Int32.TryParse(txtId.Text, out id_md[i]);
                if (txtCh0 != null) Int32.TryParse(txtCh0.Text, out ch0_md[i]);
                if (txtCh1 != null) Int32.TryParse(txtCh1.Text, out ch1_md[i]);

                PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md[i]), ch0_md[i], 2, ref ai_ch0_md[i]);
                PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md[i]), ch1_md[i], 2, ref ai_ch1_md[i]);
            }
       

            ////MD1
            //int id_md1 = 0, ch0_md1 = 0, ch1_md1 = 0;
            //Int32.TryParse(txt_id_md1.Text, out id_md1);
            //Int32.TryParse(txt_ch0_md1.Text, out ch0_md1);
            //Int32.TryParse(txt_ch1_md1.Text, out ch1_md1);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md1), ch0_md1, 2, ref ai_ch0_md1);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md1), ch1_md1, 2, ref ai_ch1_md1);
            ////MD2
            //int id_md2 = 0, ch0_md2 = 0, ch1_md2 = 0;
            //Int32.TryParse(txt_id_md2.Text, out id_md2);
            //Int32.TryParse(txt_ch0_md2.Text, out ch0_md2);
            //Int32.TryParse(txt_ch1_md2.Text, out ch1_md2);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md2), ch0_md2, 2, ref ai_ch0_md2);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md2), ch1_md2, 2, ref ai_ch1_md2);
            ////MD3
            //int id_md3 = 0, ch0_md3 = 0, ch1_md3 = 0;
            //Int32.TryParse(txt_id_md3.Text, out id_md3);
            //Int32.TryParse(txt_ch0_md3.Text, out ch0_md3);
            //Int32.TryParse(txt_ch1_md3.Text, out ch1_md3);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md3), ch0_md3, 2, ref ai_ch0_md3);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md3), ch1_md3, 2, ref ai_ch1_md3);
            ////MD4
            //int id_md4 = 0, ch0_md4 = 0, ch1_md4 = 0;
            //Int32.TryParse(txt_id_md4.Text, out id_md4);
            //Int32.TryParse(txt_ch0_md4.Text, out ch0_md4);
            //Int32.TryParse(txt_ch1_md4.Text, out ch1_md4);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md4), ch0_md4, 2, ref ai_ch0_md4);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md4), ch1_md4, 2, ref ai_ch1_md4);
            ////MD5
            //int id_md5 = 0, ch0_md5 = 0, ch1_md5 = 0;
            //Int32.TryParse(txt_id_md5.Text, out id_md5);
            //Int32.TryParse(txt_ch0_md5.Text, out ch0_md5);
            //Int32.TryParse(txt_ch1_md5.Text, out ch1_md5);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md5), ch0_md5, 2, ref ai_ch0_md5);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md5), ch1_md5, 2, ref ai_ch1_md5);
            ////MD6
            //int id_md6 = 0, ch0_md6 = 0, ch1_md6 = 0;
            //Int32.TryParse(txt_id_md6.Text, out id_md6);
            //Int32.TryParse(txt_ch0_md6.Text, out ch0_md6);
            //Int32.TryParse(txt_ch1_md6.Text, out ch1_md6);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md6), ch0_md6, 2, ref ai_ch0_md6);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md6), ch1_md6, 2, ref ai_ch1_md6);
            ////MD7
            //int id_md7 = 0, ch0_md7 = 0, ch1_md7 = 0;
            //Int32.TryParse(txt_id_md7.Text, out id_md7);
            //Int32.TryParse(txt_ch0_md7.Text, out ch0_md7);
            //Int32.TryParse(txt_ch1_md7.Text, out ch1_md7);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md7), ch0_md7, 2, ref ai_ch0_md7);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md7), ch1_md7, 2, ref ai_ch1_md7);
            ////MD8
            //int id_md8 = 0, ch0_md8 = 0, ch1_md8 = 0;
            //Int32.TryParse(txt_id_md8.Text, out id_md8);
            //Int32.TryParse(txt_ch0_md8.Text, out ch0_md8);
            //Int32.TryParse(txt_ch1_md8.Text, out ch1_md8);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md8), ch0_md8, 2, ref ai_ch0_md8);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md8), ch1_md8, 2, ref ai_ch1_md8);
            ////MD9
            //int id_md9 = 0, ch0_md9 = 0, ch1_md9 = 0;
            //Int32.TryParse(txt_id_md9.Text, out id_md9);
            //Int32.TryParse(txt_ch0_md9.Text, out ch0_md9);
            //Int32.TryParse(txt_ch1_md9.Text, out ch1_md9);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md9), ch0_md9, 2, ref ai_ch0_md9);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md9), ch1_md9, 2, ref ai_ch1_md9);
            ////MD10
            //int id_md10 = 0, ch0_md10 = 0, ch1_md10 = 0;
            //Int32.TryParse(txt_id_md10.Text, out id_md10);
            //Int32.TryParse(txt_ch0_md10.Text, out ch0_md10);
            //Int32.TryParse(txt_ch1_md10.Text, out ch1_md10);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md10), ch0_md10, 2, ref ai_ch0_md10);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md10), ch1_md10, 2, ref ai_ch1_md10);
            ////MD11
            //int id_md11 = 0, ch0_md11 = 0, ch1_md11 = 0;
            //Int32.TryParse(txt_id_md11.Text, out id_md11);
            //Int32.TryParse(txt_ch0_md11.Text, out ch0_md11);
            //Int32.TryParse(txt_ch1_md11.Text, out ch1_md11);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md11), ch0_md11, 2, ref ai_ch0_md11);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md11), ch1_md11, 2, ref ai_ch1_md11);
            ////MD12
            //int id_md12 = 0, ch0_md12 = 0, ch1_md12 = 0;
            //Int32.TryParse(txt_id_md12.Text, out id_md12);
            //Int32.TryParse(txt_ch0_md12.Text, out ch0_md12);
            //Int32.TryParse(txt_ch1_md12.Text, out ch1_md12);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md12), ch0_md12, 2, ref ai_ch0_md12);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md12), ch1_md12, 2, ref ai_ch1_md12);
            ////MD13
            //int id_md13 = 0, ch0_md13 = 0, ch1_md13 = 0;
            //Int32.TryParse(txt_id_md13.Text, out id_md13);
            //Int32.TryParse(txt_ch0_md13.Text, out ch0_md13);
            //Int32.TryParse(txt_ch1_md13.Text, out ch1_md13);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md13), ch0_md13, 2, ref ai_ch0_md13);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md13), ch1_md13, 2, ref ai_ch1_md13);
            ////MD14
            //int id_md14 = 0, ch0_md14 = 0, ch1_md14 = 0;
            //Int32.TryParse(txt_id_md14.Text, out id_md14);
            //Int32.TryParse(txt_ch0_md14.Text, out ch0_md14);
            //Int32.TryParse(txt_ch1_md14.Text, out ch1_md14);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md14), ch0_md14, 2, ref ai_ch0_md14);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md14), ch1_md14, 2, ref ai_ch1_md14);
            ////MD15
            //int id_md15 = 0, ch0_md15 = 0, ch1_md15 = 0;
            //Int32.TryParse(txt_id_md15.Text, out id_md15);
            //Int32.TryParse(txt_ch0_md15.Text, out ch0_md15);
            //Int32.TryParse(txt_ch1_md15.Text, out ch1_md15);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md15), ch0_md15, 2, ref ai_ch0_md15);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md15), ch1_md15, 2, ref ai_ch1_md15);
            ////MD16
            //int id_md16 = 0, ch0_md16 = 0, ch1_md16 = 0;
            //Int32.TryParse(txt_id_md16.Text, out id_md16);
            //Int32.TryParse(txt_ch0_md16.Text, out ch0_md16);
            //Int32.TryParse(txt_ch1_md16.Text, out ch1_md16);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md16), ch0_md16, 2, ref ai_ch0_md16);
            //PACNET.PAC_IO.ReadAI(hPort, PACNET.PAC_IO.PAC_REMOTE_IO(id_md16), ch1_md16, 2, ref ai_ch1_md16);
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

        private void Data_Load(object sender, EventArgs e)
        {
            //timer2.Start();
            //lbl_tanggal.Text = DateTime.Now.ToLongDateString();

            //COBA
            timer2.Start(); // Mulai timer saat port terbuka
            timer2.Interval = 200;
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            ////MD1
            //double.TryParse(txt_op_ch0_md1.Text, out double op_ch0_md1);
            //double.TryParse(txt_eks_ch0_md1.Text, out double eks_ch0_md1);
            //double.TryParse(txt_mxload_ch0_md1.Text, out double mxload_ch0_md1);
            //double.TryParse(txt_zero_ch0_md1.Text, out double zero_ch0_md1);
            //double.TryParse(txt_mxtarik_ch0_md1.Text, out double mxtarik_ch0_md1);
            //double hasil_kg_ch0_md1 = (ai_ch0_md1 / (op_ch0_md1 * eks_ch0_md1)) * mxload_ch0_md1;
            //double final_kg_ch0_md1 = hasil_kg_ch0_md1 - zero_ch0_md1;
            //double nilai_persentarik_ch0_md1 = (final_kg_ch0_md1 / mxtarik_ch0_md1) * 100;
            //lbl_mv_ch0_md1.Text = ai_ch0_md1.ToString("F2");
            //lbl_kgf_ch0_md1.Text = final_kg_ch0_md1.ToString("F2");
            //db_modul1.nilai_kg_ch0 = final_kg_ch0_md1;
            //db_modul1.nilai_kode_ch0 = txt_kode_ch0_md1.Text;
            //db_modul1.nilai_persentarik_ch0 = nilai_persentarik_ch0_md1;
            //double.TryParse(txt_op_ch1_md1.Text, out double op_ch1_md1);
            //double.TryParse(txt_eks_ch1_md1.Text, out double eks_ch1_md1);
            //double.TryParse(txt_mxload_ch1_md1.Text, out double mxload_ch1_md1);
            //double.TryParse(txt_zero_ch1_md1.Text, out double zero_ch1_md1);
            //double.TryParse(txt_mxtarik_ch1_md1.Text, out double mxtarik_ch1_md1);
            //double hasil_kg_ch1_md1 = (ai_ch1_md1 / (op_ch1_md1 * eks_ch1_md1)) * mxload_ch1_md1;
            //double final_kg_ch1_md1 = hasil_kg_ch1_md1 - zero_ch1_md1;
            //double nilai_persentarik_ch1_md1 = (final_kg_ch1_md1 / mxtarik_ch1_md1) * 100;
            //lbl_mv_ch1_md1.Text = ai_ch1_md1.ToString("F2");
            //lbl_kgf_ch1_md1.Text = final_kg_ch1_md1.ToString("F2");
            //db_modul1.nilai_kg_ch1 = final_kg_ch1_md1;
            //db_modul1.nilai_kode_ch1 = txt_kode_ch1_md1.Text;
            //db_modul1.nilai_persentarik_ch1 = nilai_persentarik_ch1_md1;

            ////MD2
            //double.TryParse(txt_op_ch0_md2.Text, out double op_ch0_md2);
            //double.TryParse(txt_eks_ch0_md2.Text, out double eks_ch0_md2);
            //double.TryParse(txt_mxload_ch0_md2.Text, out double mxload_ch0_md2);
            //double.TryParse(txt_zero_ch0_md2.Text, out double zero_ch0_md2);
            //double.TryParse(txt_mxtarik_ch0_md2.Text, out double mxtarik_ch0_md2);
            //double hasil_kg_ch0_md2 = (ai_ch0_md2 / (op_ch0_md2 * eks_ch0_md2)) * mxload_ch0_md2;
            //double final_kg_ch0_md2 = hasil_kg_ch0_md2 - zero_ch0_md2;
            //double nilai_persentarik_ch0_md2 = (final_kg_ch0_md2 / mxtarik_ch0_md2) * 100;
            //lbl_mv_ch0_md2.Text = ai_ch0_md2.ToString("F2");
            //lbl_kgf_ch0_md2.Text = final_kg_ch0_md2.ToString("F2");
            //db_modul2.nilai_kg_ch0 = final_kg_ch0_md2;
            //db_modul2.nilai_kode_ch0 = txt_kode_ch0_md2.Text;
            //db_modul2.nilai_persentarik_ch0 = nilai_persentarik_ch0_md2;
            //double.TryParse(txt_op_ch1_md2.Text, out double op_ch1_md2);
            //double.TryParse(txt_eks_ch1_md2.Text, out double eks_ch1_md2);
            //double.TryParse(txt_mxload_ch1_md2.Text, out double mxload_ch1_md2);
            //double.TryParse(txt_zero_ch1_md2.Text, out double zero_ch1_md2);
            //double.TryParse(txt_mxtarik_ch1_md2.Text, out double mxtarik_ch1_md2);
            //double hasil_kg_ch1_md2 = (ai_ch1_md2 / (op_ch1_md2 * eks_ch1_md2)) * mxload_ch1_md2;
            //double final_kg_ch1_md2 = hasil_kg_ch1_md2 - zero_ch1_md2;
            //double nilai_persentarik_ch1_md2 = (final_kg_ch1_md2 / mxtarik_ch1_md2) * 100;
            //lbl_mv_ch1_md2.Text = ai_ch1_md2.ToString("F2");
            //lbl_kgf_ch1_md2.Text = final_kg_ch1_md2.ToString("F2");
            //db_modul2.nilai_kg_ch1 = final_kg_ch1_md2;
            //db_modul2.nilai_kode_ch1 = txt_kode_ch1_md2.Text;
            //db_modul2.nilai_persentarik_ch1 = nilai_persentarik_ch1_md2;

            ////MD3
            //double.TryParse(txt_op_ch0_md3.Text, out double op_ch0_md3);
            //double.TryParse(txt_eks_ch0_md3.Text, out double eks_ch0_md3);
            //double.TryParse(txt_mxload_ch0_md3.Text, out double mxload_ch0_md3);
            //double.TryParse(txt_zero_ch0_md3.Text, out double zero_ch0_md3);
            //double.TryParse(txt_mxtarik_ch0_md3.Text, out double mxtarik_ch0_md3);
            //double hasil_kg_ch0_md3 = (ai_ch0_md3 / (op_ch0_md3 * eks_ch0_md3)) * mxload_ch0_md3;
            //double final_kg_ch0_md3 = hasil_kg_ch0_md3 - zero_ch0_md3;
            //double nilai_persentarik_ch0_md3 = (final_kg_ch0_md3 / mxtarik_ch0_md3) * 100;
            //lbl_mv_ch0_md3.Text = ai_ch0_md3.ToString("F2");
            //lbl_kgf_ch0_md3.Text = final_kg_ch0_md3.ToString("F2");
            //db_modul2.nilai_kg_ch0 = final_kg_ch0_md3;
            //db_modul2.nilai_kode_ch0 = txt_kode_ch0_md3.Text;
            //db_modul2.nilai_persentarik_ch0 = nilai_persentarik_ch0_md3;
            //double.TryParse(txt_op_ch1_md3.Text, out double op_ch1_md3);
            //double.TryParse(txt_eks_ch1_md3.Text, out double eks_ch1_md3);
            //double.TryParse(txt_mxload_ch1_md3.Text, out double mxload_ch1_md3);
            //double.TryParse(txt_zero_ch1_md3.Text, out double zero_ch1_md3);
            //double.TryParse(txt_mxtarik_ch1_md3.Text, out double mxtarik_ch1_md3);
            //double hasil_kg_ch1_md3 = (ai_ch1_md3 / (op_ch1_md3 * eks_ch1_md3)) * mxload_ch1_md3;
            //double final_kg_ch1_md3 = hasil_kg_ch1_md3 - zero_ch1_md3;
            //double nilai_persentarik_ch1_md3 = (final_kg_ch1_md3 / mxtarik_ch1_md3) * 100;
            //lbl_mv_ch1_md3.Text = ai_ch1_md3.ToString("F2");
            //lbl_kgf_ch1_md3.Text = final_kg_ch1_md3.ToString("F2");
            //db_modul2.nilai_kg_ch1 = final_kg_ch1_md3;
            //db_modul2.nilai_kode_ch1 = txt_kode_ch1_md3.Text;
            //db_modul2.nilai_persentarik_ch1 = nilai_persentarik_ch1_md3;

            ////MD4
            //double.TryParse(txt_op_ch0_md4.Text, out double op_ch0_md4);
            //double.TryParse(txt_eks_ch0_md4.Text, out double eks_ch0_md4);
            //double.TryParse(txt_mxload_ch0_md4.Text, out double mxload_ch0_md4);
            //double.TryParse(txt_zero_ch0_md4.Text, out double zero_ch0_md4);
            //double.TryParse(txt_mxtarik_ch0_md4.Text, out double mxtarik_ch0_md4);
            //double hasil_kg_ch0_md4 = (ai_ch0_md4 / (op_ch0_md4 * eks_ch0_md4)) * mxload_ch0_md4;
            //double final_kg_ch0_md4 = hasil_kg_ch0_md4 - zero_ch0_md4;
            //double nilai_persentarik_ch0_md4 = (final_kg_ch0_md4 / mxtarik_ch0_md4) * 100;
            //lbl_mv_ch0_md4.Text = ai_ch0_md4.ToString("F2");
            //lbl_kgf_ch0_md4.Text = final_kg_ch0_md4.ToString("F2");
            //db_modul2.nilai_kg_ch0 = final_kg_ch0_md4;
            //db_modul2.nilai_kode_ch0 = txt_kode_ch0_md4.Text;
            //db_modul2.nilai_persentarik_ch0 = nilai_persentarik_ch0_md4;
            //double.TryParse(txt_op_ch1_md4.Text, out double op_ch1_md4);
            //double.TryParse(txt_eks_ch1_md4.Text, out double eks_ch1_md4);
            //double.TryParse(txt_mxload_ch1_md4.Text, out double mxload_ch1_md4);
            //double.TryParse(txt_zero_ch1_md4.Text, out double zero_ch1_md4);
            //double.TryParse(txt_mxtarik_ch1_md4.Text, out double mxtarik_ch1_md4);
            //double hasil_kg_ch1_md4 = (ai_ch1_md4 / (op_ch1_md4 * eks_ch1_md4)) * mxload_ch1_md4;
            //double final_kg_ch1_md4 = hasil_kg_ch1_md4 - zero_ch1_md4;
            //double nilai_persentarik_ch1_md4 = (final_kg_ch1_md4 / mxtarik_ch1_md4) * 100;
            //lbl_mv_ch1_md4.Text = ai_ch1_md4.ToString("F2");
            //lbl_kgf_ch1_md4.Text = final_kg_ch1_md4.ToString("F2");
            //db_modul2.nilai_kg_ch1 = final_kg_ch1_md4;
            //db_modul2.nilai_kode_ch1 = txt_kode_ch1_md4.Text;
            //db_modul2.nilai_persentarik_ch1 = nilai_persentarik_ch1_md4;

            ////md5
            //double.TryParse(txt_op_ch0_md5.Text, out double op_ch0_md5);
            //double.TryParse(txt_eks_ch0_md5.Text, out double eks_ch0_md5);
            //double.TryParse(txt_mxload_ch0_md5.Text, out double mxload_ch0_md5);
            //double.TryParse(txt_zero_ch0_md5.Text, out double zero_ch0_md5);
            //double.TryParse(txt_mxtarik_ch0_md5.Text, out double mxtarik_ch0_md5);
            //double hasil_kg_ch0_md5 = (ai_ch0_md5 / (op_ch0_md5 * eks_ch0_md5)) * mxload_ch0_md5;
            //double final_kg_ch0_md5 = hasil_kg_ch0_md5 - zero_ch0_md5;
            //double nilai_persentarik_ch0_md5 = (final_kg_ch0_md5 / mxtarik_ch0_md5) * 100;
            //lbl_mv_ch0_md5.Text = ai_ch0_md5.ToString("F2");
            //lbl_kgf_ch0_md5.Text = final_kg_ch0_md5.ToString("F2");
            //db_modul2.nilai_kg_ch0 = final_kg_ch0_md5;
            //db_modul2.nilai_kode_ch0 = txt_kode_ch0_md5.Text;
            //db_modul2.nilai_persentarik_ch0 = nilai_persentarik_ch0_md5;
            //double.TryParse(txt_op_ch1_md5.Text, out double op_ch1_md5);
            //double.TryParse(txt_eks_ch1_md5.Text, out double eks_ch1_md5);
            //double.TryParse(txt_mxload_ch1_md5.Text, out double mxload_ch1_md5);
            //double.TryParse(txt_zero_ch1_md5.Text, out double zero_ch1_md5);
            //double.TryParse(txt_mxtarik_ch1_md5.Text, out double mxtarik_ch1_md5);
            //double hasil_kg_ch1_md5 = (ai_ch1_md5 / (op_ch1_md5 * eks_ch1_md5)) * mxload_ch1_md5;
            //double final_kg_ch1_md5 = hasil_kg_ch1_md5 - zero_ch1_md5;
            //double nilai_persentarik_ch1_md5 = (final_kg_ch1_md5 / mxtarik_ch1_md5) * 100;
            //lbl_mv_ch1_md5.Text = ai_ch1_md5.ToString("F2");
            //lbl_kgf_ch1_md5.Text = final_kg_ch1_md5.ToString("F2");
            //db_modul2.nilai_kg_ch1 = final_kg_ch1_md5;
            //db_modul2.nilai_kode_ch1 = txt_kode_ch1_md5.Text;
            //db_modul2.nilai_persentarik_ch1 = nilai_persentarik_ch1_md5;
        }

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
    }
}
