using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Uji_Tower_V1
{
    public partial class Home : Form
    {
        private data_perhitungan DataPerhitunganInstance = new data_perhitungan();
        private case_1 Case_1_Instance = new case_1();
        private case_2 Case_2_Instance = new case_2();
        //private case_3 Case_3_Instance = new case_3();
        //private case_4 Case_4_Instance = new case_4();
        //private case_5 Case_5_Instance = new case_5();
        //private case_6 Case_6_Instance = new case_6();
        private master_data MasterDataInstance = new master_data();

        private bool formDataPerhitunganSudahDibuka = false;
        private bool formMasterDataSudahDibuka = false;

        public Home()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_kalibrasi_Click(object sender, EventArgs e)
        {
            var calibrationfrom = new Calibration();
            calibrationfrom.Show();
        }

        private void btn_opc_Click(object sender, EventArgs e)
        {
            if (MasterDataInstance.IsDisposed)
            {
                MasterDataInstance = new master_data();
                MasterDataInstance.FormClosed += MasterData_FormClosed;
            }

            formMasterDataSudahDibuka = true;
            MasterDataInstance.Show();
            MasterDataInstance.BringToFront();
        }

        private void MasterData_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMasterDataSudahDibuka = false;
        }

        private void btn_data_Click(object sender, EventArgs e)
        {
            if (!formMasterDataSudahDibuka)
            {
                MessageBox.Show("Silakan buka form Master Data terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DataPerhitunganInstance.IsDisposed)
            {
                DataPerhitunganInstance = new data_perhitungan();
                DataPerhitunganInstance.FormClosed += DataPerhitungan_FormClosed;
            }

            formDataPerhitunganSudahDibuka = true;
            DataPerhitunganInstance.Show();
            DataPerhitunganInstance.BringToFront();
        }

        private void DataPerhitungan_FormClosed(object sender, FormClosedEventArgs e)
        {
            formDataPerhitunganSudahDibuka = false;
        }

        private void btn_case_1_Click(object sender, EventArgs e)
        {
            if (!formDataPerhitunganSudahDibuka)
            {
                MessageBox.Show("Silakan buka form Data Perhitungan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Case_1_Instance.IsDisposed)
            {
                Case_1_Instance = new case_1();
            }

            Case_1_Instance.Show();
            Case_1_Instance.BringToFront();
        }

        private void btn_case_2_Click(object sender, EventArgs e)
        {
            if (!formDataPerhitunganSudahDibuka)
            {
                MessageBox.Show("Silakan buka form Data Perhitungan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Case_2_Instance.IsDisposed)
            {
                Case_2_Instance = new case_2();
            }

            Case_2_Instance.Show();
            Case_2_Instance.BringToFront();
        }

        private void btn_case_3_Click(object sender, EventArgs e)
        {
            //if (!formDataPerhitunganSudahDibuka)
            //{
            //    MessageBox.Show("Silakan buka form Data Perhitungan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (Case_3_Instance.IsDisposed)
            //{
            //    Case_3_Instance = new case_3();
            //}

            //Case_3_Instance.Show();
            //Case_3_Instance.BringToFront();
        }

        private void btn_case_4_Click(object sender, EventArgs e)
        {
            //if (!formDataPerhitunganSudahDibuka)
            //{
            //    MessageBox.Show("Silakan buka form Data Perhitungan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (Case_4_Instance.IsDisposed)
            //{
            //    Case_4_Instance = new case_4();
            //}

            //Case_4_Instance.Show();
            //Case_4_Instance.BringToFront();
        }

        private void btn_case_5_Click(object sender, EventArgs e)
        {
            //if (!formDataPerhitunganSudahDibuka)
            //{
            //    MessageBox.Show("Silakan buka form Data Perhitungan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (Case_5_Instance.IsDisposed)
            //{
            //    Case_5_Instance = new case_5();
            //}

            //Case_5_Instance.Show();
            //Case_5_Instance.BringToFront();
        }

        private void btn_case_6_Click(object sender, EventArgs e)
        {
            //if (!formDataPerhitunganSudahDibuka)
            //{
            //    MessageBox.Show("Silakan buka form Data Perhitungan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (Case_6_Instance.IsDisposed)
            //{
            //    Case_6_Instance = new case_6();
            //}

            //Case_6_Instance.Show();
            //Case_6_Instance.BringToFront();
        }
    }

}
