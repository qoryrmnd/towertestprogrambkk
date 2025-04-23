using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Program_Uji_Tower_V1
{
    public partial class case_2: Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index = 0;
        bool isKg = true;

        public case_2()
        {
            InitializeComponent();
        }

        private void case_2_Load(object sender, EventArgs e)
        {
            timer2.Start();
            timer2.Interval = 1000;
            UpdateDateTime();

            timer1.Start();
            timer1.Interval = 1000;

            // Tambah panel ke list
            listPanel.Add(panel2);
            listPanel.Add(panel1);

            // Inisialisasi: sembunyikan semua panel kecuali yang pertama
            for (int i = 0; i < listPanel.Count; i++)
            {
                listPanel[i].Visible = (i == index);
            }

            // Pastikan panel pertama di depan
            listPanel[index].BringToFront();

            var props = typeof(master_kg).GetProperties();
            for (int i = 1; i <= 32; i++)
            {
                // Channel 0
                ComboBox cmb = this.Controls.Find($"cmb_vl{i}", true).FirstOrDefault() as ComboBox;
                if (cmb != null)
                {
                    foreach (var prop in props)
                    cmb.Items.Add(prop.Name);

                    cmb.SelectedIndex = -1;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            lbl_time.Text = DateTime.Now.ToString("HH:mm:ss");
            lbl_date.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }

        private void ShowPanel(int newIndex)
        {
            listPanel[index].Visible = false;      // Sembunyikan panel lama
            index = newIndex;                      // Update index
            listPanel[index].Visible = true;       // Tampilkan panel baru
            listPanel[index].BringToFront();       // Bawa ke depan
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            A1();
            A2();
            A3();
            B1();
            B2();
            B3();
            C1();
            C2();
            C3();
            D1();
            D2();
            D3();
            E1();
            E2();
            F1();
            F2();
            G1();
            G2();
            H1();
            H2();
            I1();
            I2();
            J1();
            J2();
            K1();
            K2();
            L1();
            L2();
            M1();
            M2();
            N1();
            N2();

            //TOTAL T-V-L
            double totalT = TotalKgDenganT();
            lbl_totalT.Text = totalT.ToString("F2") + " KG";
            lbl_totalT_N.Text = (totalT * 9.80665).ToString("F2") + " N";

            double totalV = TotalKgDenganV();
            lbl_totalV.Text = totalV.ToString("F2") + " KG";
            lbl_totalV_N.Text = (totalV * 9.80665).ToString("F2") + " N";

            double totalL = TotalKgDenganL();
            lbl_totalL.Text = totalL.ToString("F2") + " KG";
            lbl_totalL_N.Text = (totalL * 9.80665).ToString("F2") + " N";

            //AVERAGE T-V-L
            lbl_avgprsT.Text = AveragePersenTarikDenganT().ToString("F2");
            lbl_avgprsV.Text = AveragePersenTarikDenganV().ToString("F2");
            lbl_avgprsL.Text = AveragePersenTarikDenganL().ToString("F2");

            double avgT = double.Parse(lbl_avgprsT.Text);
            double avgV = double.Parse(lbl_avgprsV.Text);
            double avgL = double.Parse(lbl_avgprsL.Text);

            double avgTotal = (avgT + avgV + avgL) / 3.0;

            lbl_avgALL.Text = avgTotal.ToString("F2")+" %";

            chart_avgPersen.Series.Clear();
            chart_avgPersen.Legends.Clear();

            var chartArea = chart_avgPersen.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;

            var series = chart_avgPersen.Series.Add("Average %");
            series.ChartType = SeriesChartType.Column;

            series.Points.AddXY("Trans", avgT);
            series.Points[0].Label = avgT.ToString("F2") + " %";

            series.Points.AddXY("Vert", avgV);
            series.Points[1].Label = avgV.ToString("F2") + " %";

            series.Points.AddXY("Long", avgL);
            series.Points[2].Label = avgL.ToString("F2") + " %";

            series.Points[0].Color = Color.Red;
            series.Points[1].Color = Color.Green;
            series.Points[2].Color = Color.Blue;

            series.IsValueShownAsLabel = true;
            series.IsVisibleInLegend = false;


        }

        void A1()
        {
            try
            {
                string selectedProp = cmb_vl1.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik1.Text, out double xtarik);
                        double persen_tarik = (nilai_kg / xtarik) * 100;

                        lbl_kg1.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton1.Text = nilai_newton.ToString("F2") + " N";

                        lbl_persen1.Text = persen_tarik.ToString("F2");
                        lbl_kode1.Text = txt_kode1.Text;

                        return;
                    }
                }
            }
            catch
            {
                lbl_kg1.Text = "Err";
                lbl_newton1.Text = "Err";
            }
        }


        void A2()
        {
            try
            {
                string selectedProp = cmb_vl2.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik2.Text, out double xtarik);
                        double persen_tarik = (nilai_kg / xtarik) * 100;
                        lbl_kg2.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton2.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen2.Text = persen_tarik.ToString("F2");
                        lbl_kode2.Text = txt_kode2.Text;
                        return;
                    }
                }
            }
            catch
            {
                lbl_kg2.Text = "Err";
            }
        }

        void A3()
        {
            try
            {
                string selectedProp = cmb_vl3.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik3.Text, out double xtarik);
                        double persen_tarik = (nilai_kg / xtarik) * 100;
                        lbl_kg3.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton3.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen3.Text = persen_tarik.ToString("F2");
                        lbl_kode3.Text = txt_kode3.Text;
                        return;
                    }
                }
            }
            catch
            {
                lbl_kg3.Text = "Err";
            }
        }

        void B1()
        {
            try
            {
                string selectedProp = cmb_vl4.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik4.Text, out double xtarik);
                        double persen_tarik = (nilai_kg / xtarik) * 100;
                        lbl_kg4.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton4.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen4.Text = persen_tarik.ToString("F2");
                        lbl_kode4.Text = txt_kode4.Text;
                        return;
                    }
                }
            }
            catch
            {
                lbl_kg4.Text = "Err";
            }
        }

        void B2()
        {
            try
            {
                string selectedProp = cmb_vl5.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik5.Text, out double xtarik);
                        double persen_tarik = (nilai_kg / xtarik) * 100;
                        lbl_kg5.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton5.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen5.Text = persen_tarik.ToString("F2");
                        lbl_kode5.Text = txt_kode5.Text;
                        return;
                    }
                }
            }
            catch
            {
                lbl_kg5.Text = "Err";
            }
        }


        void B3()
        {
            try
            {
                string selectedProp = cmb_vl6.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik6.Text, out double xtarik);
                        double persen_tarik6 = (nilai_kg / xtarik) * 100;
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton6.Text = nilai_newton.ToString("F2") + " N";
                        lbl_kg6.Text = nilai_kg.ToString("F2")+" Kg";
                        lbl_persen6.Text = persen_tarik6.ToString("F2");
                        lbl_kode6.Text = txt_kode6.Text;
                    }
                }
            }
            catch
            {
                lbl_kg6.Text = "Err";
            }
        }

        void C1()
        {
            try
            {
                string selectedProp = cmb_vl7.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik7.Text, out double xtarik);
                        double persen_tarik7 = (nilai_kg / xtarik) * 100;
                        lbl_kg7.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton7.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen7.Text = persen_tarik7.ToString(  );
                        lbl_kode7.Text = txt_kode7.Text;
                    }
                }
            }
            catch
            {
                lbl_kg7.Text = "Err";
            }
        }

        void C2()
        {
            try
            {
                string selectedProp = cmb_vl8.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik8.Text, out double xtarik);
                        double persen_tarik8 = (nilai_kg / xtarik) * 100;
                        lbl_kg8.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton8.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen8.Text = persen_tarik8.ToString();
                        lbl_kode8.Text = txt_kode8.Text;
                    }
                }
            }
            catch
            {
                lbl_kg8.Text = "Err";
            }
        }

        void C3()
        {
            try
            {
                string selectedProp = cmb_vl9.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik9.Text, out double xtarik);
                        double persen_tarik9 = (nilai_kg / xtarik) * 100;
                        lbl_kg9.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton9.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen9.Text = persen_tarik9.ToString("F2");
                        lbl_kode9.Text = txt_kode9.Text;
                    }
                }
            }
            catch
            {
                lbl_kg9.Text = "Err";
            }
        }

        void D1()
        {
            try
            {
                string selectedProp = cmb_vl10.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik10.Text, out double xtarik);
                        double persen_tarik10 = (nilai_kg / xtarik) * 100;
                        lbl_kg10.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton10.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen10.Text = persen_tarik10.ToString("F2");
                        lbl_kode10.Text = txt_kode10.Text;
                    }
                }
            }
            catch
            {
                lbl_kg10.Text = "Err";
            }
        }

        void D2()
        {
            try
            {
                string selectedProp = cmb_vl11.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik11.Text, out double xtarik);
                        double persen_tarik11 = (nilai_kg / xtarik) * 100;
                        lbl_kg11.Text = nilai_kg.ToString("F2");
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton11.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen11.Text = persen_tarik11.ToString("F2");
                        lbl_kode11.Text = txt_kode11.Text;
                    }
                }
            }
            catch
            {
                lbl_kg11.Text = "Err";
            }
        }

        void D3()
        {
            try
            {
                string selectedProp = cmb_vl12.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik12.Text, out double xtarik);
                        double persen_tarik12 = (nilai_kg / xtarik) * 100;
                        lbl_kg12.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton12.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen12.Text = persen_tarik12.ToString("F2");
                        lbl_kode12.Text = txt_kode12.Text;
                    }
                }
            }
            catch
            {
                lbl_kg12.Text = "Err";
            }
        }

        void E1()
        {
            try
            {
                string selectedProp = cmb_vl13.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik13.Text, out double xtarik);
                        double persen_tarik13 = (nilai_kg / xtarik) * 100;
                        lbl_kg13.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton13.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen13.Text = persen_tarik13.ToString("F2");
                        lbl_kode13.Text = txt_kode13.Text;
                    }
                }
            }
            catch
            {
                lbl_kg13.Text = "Err";
            }
        }

        void E2()
        {
            try
            {
                string selectedProp = cmb_vl14.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik14.Text, out double xtarik);
                        double persen_tarik14 = (nilai_kg / xtarik) * 100;
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton14.Text = nilai_newton.ToString("F2") + " N";
                        lbl_kg14.Text = nilai_kg.ToString("F2") + " Kg";
                        lbl_persen14.Text = persen_tarik14.ToString("F2");
                        lbl_kode14.Text = txt_kode14.Text;
                    }
                }
            }
            catch
            {
                lbl_kg14.Text = "Err";
            }
        }

        void F1()
        {
            try
            {
                string selectedProp = cmb_vl15.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik15.Text, out double xtarik);
                        double persen_tarik15 = (nilai_kg / xtarik) * 100;
                        lbl_kg15.Text = nilai_kg.ToString("F2")+" Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton15.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen15.Text = persen_tarik15.ToString("F2");
                        lbl_kode15.Text = txt_kode15.Text;
                    }
                }
            }
            catch
            {
                lbl_kg15.Text = "Err";
            }
        }

        void F2()
        {
            try
            {
                string selectedProp = cmb_vl16.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik16.Text, out double xtarik);
                        double persen_tarik16 = (nilai_kg / xtarik) * 100;
                        lbl_kg16.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton16.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen16.Text = persen_tarik16.ToString("F2");
                        lbl_kode16.Text = txt_kode16.Text;
                    }
                }
            }
            catch
            {
                lbl_kg16.Text = "Err";
            }
        }

        void G1()
        {
            try
            {
                string selectedProp = cmb_vl17.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik17.Text, out double xtarik);
                        double persen_tarik17 = (nilai_kg / xtarik) * 100;
                        lbl_kg17.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton17.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen17.Text = persen_tarik17.ToString("F2");
                        lbl_kode17.Text = txt_kode17.Text;
                    }
                }
            }
            catch
            {
                lbl_kg17.Text = "Err";
            }
        }

        void G2()
        {
            try
            {
                string selectedProp = cmb_vl18.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik18.Text, out double xtarik);
                        double persen_tarik18 = (nilai_kg / xtarik) * 100;
                        lbl_kg18.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton18.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen18.Text = persen_tarik18.ToString("F2");
                        lbl_kode18.Text = txt_kode18.Text;
                    }
                }
            }
            catch
            {
                lbl_kg18.Text = "Err";
            }
        }

        void H1()
        {
            try
            {
                string selectedProp = cmb_vl19.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik19.Text, out double xtarik);
                        double persen_tarik19 = (nilai_kg / xtarik) * 100;
                        lbl_kg19.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton19.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen19.Text = persen_tarik19.ToString("F2");
                        lbl_kode19.Text = txt_kode19.Text;
                    }
                }
            }
            catch
            {
                lbl_kg19.Text = "Err";
            }
        }

        void H2()
        {
            try
            {
                string selectedProp = cmb_vl20.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik20.Text, out double xtarik);
                        double persen_tarik20 = (nilai_kg / xtarik) * 100;
                        lbl_kg20.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton20.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen20.Text = persen_tarik20.ToString("F2");
                        lbl_kode20.Text = txt_kode20.Text;
                    }
                }
            }
            catch
            {
                lbl_kg20.Text = "Err";
            }
        }

        void I1()
        {
            try
            {
                string selectedProp = cmb_vl21.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik21.Text, out double xtarik);
                        double persen_tarik21 = (nilai_kg / xtarik) * 100;
                        lbl_kg21.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton21.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen21.Text = persen_tarik21.ToString("F2");
                        lbl_kode21.Text = txt_kode21.Text;
                    }
                }
            }
            catch
            {
                lbl_kg21.Text = "Err";
            }
        }

        void I2()
        {
            try
            {
                string selectedProp = cmb_vl22.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik22.Text, out double xtarik);
                        double persen_tarik22 = (nilai_kg / xtarik) * 100;
                        lbl_kg22.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton22.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen22.Text = persen_tarik22.ToString("F2");
                        lbl_kode22.Text = txt_kode22.Text;
                    }
                }
            }
            catch
            {
                lbl_kg22.Text = "Err";
            }
        }

        void J1()
        {
            try
            {
                string selectedProp = cmb_vl23.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik23.Text, out double xtarik);
                        double persen_tarik23 = (nilai_kg / xtarik) * 100;
                        lbl_kg23.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton23.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen23.Text = persen_tarik23.ToString("F2");
                        lbl_kode23.Text = txt_kode23.Text;
                    }
                }
            }
            catch
            {
                lbl_kg23.Text = "Err";
            }
        }

        void J2()
        {
            try
            {
                string selectedProp = cmb_vl24.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik24.Text, out double xtarik);
                        double persen_tarik24 = (nilai_kg / xtarik) * 100;
                        lbl_kg24.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton24.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen24.Text = persen_tarik24.ToString("F2");
                        lbl_kode24.Text = txt_kode24.Text;
                    }
                }
            }
            catch
            {
                lbl_kg24.Text = "Err";
            }
        }

        void K1()
        {
            try
            {
                string selectedProp = cmb_vl25.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik25.Text, out double xtarik);
                        double persen_tarik25 = (nilai_kg / xtarik) * 100;
                        lbl_kg25.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton25.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen25.Text = persen_tarik25.ToString("F2");
                        lbl_kode25.Text = txt_kode25.Text;
                    }
                }
            }
            catch
            {
                lbl_kg25.Text = "Err";
            }
        }

        void K2()
        {
            try
            {
                string selectedProp = cmb_vl26.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik26.Text, out double xtarik);
                        double persen_tarik26 = (nilai_kg / xtarik) * 100;
                        lbl_kg26.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton26.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen26.Text = persen_tarik26.ToString("F2");
                        lbl_kode26.Text = txt_kode26.Text;
                    }
                }
            }
            catch
            {
                lbl_kg26.Text = "Err";
            }
        }

        void L1()
        {
            try
            {
                string selectedProp = cmb_vl27.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik27.Text, out double xtarik);
                        double persen_tarik27 = (nilai_kg / xtarik) * 100;
                        lbl_kg27.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton27.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen27.Text = persen_tarik27.ToString("F2");
                        lbl_kode27.Text = txt_kode27.Text;
                    }
                }
            }
            catch
            {
                lbl_kg27.Text = "Err";
            }
        }

        void L2()
        {
            try
            {
                string selectedProp = cmb_vl28.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik28.Text, out double xtarik);
                        double persen_tarik28 = (nilai_kg / xtarik) * 100;
                        lbl_kg28.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton28.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen28.Text = persen_tarik28.ToString("F2");
                        lbl_kode28.Text = txt_kode28.Text;
                    }
                }
            }
            catch
            {
                lbl_kg28.Text = "Err";
            }
        }

        void M1()
        {
            try
            {
                string selectedProp = cmb_vl29.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik29.Text, out double xtarik);
                        double persen_tarik29 = (nilai_kg / xtarik) * 100;
                        lbl_kg29.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton29.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen29.Text = persen_tarik29.ToString("F2");
                        lbl_kode29.Text = txt_kode29.Text;
                    }
                }
            }
            catch
            {
                lbl_kg29.Text = "Err";
            }
        }

        void M2()
        {
            try
            {
                string selectedProp = cmb_vl30.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik30.Text, out double xtarik);
                        double persen_tarik30 = (nilai_kg / xtarik) * 100;
                        lbl_kg30.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton30.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen30.Text = persen_tarik30.ToString("F2");
                        lbl_kode30.Text = txt_kode30.Text;
                    }
                }
            }
            catch
            {
                lbl_kg30.Text = "Err";
            }
        }

        void N1()
        {
            try
            {
                string selectedProp = cmb_vl31.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik31.Text, out double xtarik);
                        double persen_tarik31 = (nilai_kg / xtarik) * 100;
                        lbl_kg31.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton31.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen31.Text = persen_tarik31.ToString("F2");
                        lbl_kode31.Text = txt_kode31.Text;
                    }
                }
            }
            catch
            {
                lbl_kg31.Text = "Err";
            }
        }

        void N2()
        {
            try
            {
                string selectedProp = cmb_vl32.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedProp))
                {
                    PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double nilai_kg = (double)propInfo.GetValue(null);
                        double.TryParse(txt_xtarik32.Text, out double xtarik);
                        double persen_tarik32 = (nilai_kg / xtarik) * 100;
                        lbl_kg32.Text = nilai_kg.ToString("F2") + " Kg";
                        double nilai_newton = nilai_kg * 9.80665;
                        lbl_newton32.Text = nilai_newton.ToString("F2") + " N";
                        lbl_persen32.Text = persen_tarik32.ToString("F2");
                        lbl_kode32.Text = txt_kode32.Text;
                    }
                }
            }
            catch
            {
                lbl_kg32.Text = "Err";
            }
        }

        private double TotalKgDenganT()
        {
            double total = 0;

            for (int i = 1; i <= 32; i++)
            {
                ComboBox cmb = (ComboBox)this.Controls.Find("cmb_vl" + i, true).FirstOrDefault();
                Label lblKode = (Label)this.Controls.Find("lbl_kode" + i, true).FirstOrDefault();

                if (cmb != null && lblKode != null && lblKode.Text.Contains("T"))
                {
                    string selectedProp = cmb.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(selectedProp))
                    {
                        PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                        if (propInfo != null)
                        {
                            double nilai_kg = (double)propInfo.GetValue(null);
                            total += nilai_kg;
                        }
                    }
                }
            }

            return total;
        }

        private double TotalKgDenganV()
        {
            double total = 0;

            for (int i = 1; i <= 32; i++)
            {
                ComboBox cmb = (ComboBox)this.Controls.Find("cmb_vl" + i, true).FirstOrDefault();
                Label lblKode = (Label)this.Controls.Find("lbl_kode" + i, true).FirstOrDefault();

                if (cmb != null && lblKode != null && lblKode.Text.Contains("V"))
                {
                    string selectedProp = cmb.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(selectedProp))
                    {
                        PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                        if (propInfo != null)
                        {
                            double nilai_kg = (double)propInfo.GetValue(null);
                            total += nilai_kg;
                        }
                    }
                }
            }

            return total;
        }

        private double TotalKgDenganL()
        {
            double total = 0;

            for (int i = 1; i <= 32; i++)
            {
                ComboBox cmb = (ComboBox)this.Controls.Find("cmb_vl" + i, true).FirstOrDefault();
                Label lblKode = (Label)this.Controls.Find("lbl_kode" + i, true).FirstOrDefault();

                if (cmb != null && lblKode != null && lblKode.Text.Contains("L"))
                {
                    string selectedProp = cmb.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(selectedProp))
                    {
                        PropertyInfo propInfo = typeof(master_kg).GetProperty(selectedProp);
                        if (propInfo != null)
                        {
                            double nilai_kg = (double)propInfo.GetValue(null);
                            total += nilai_kg;
                        }
                    }
                }
            }

            return total;
        }

        private double AveragePersenTarikDenganT()
        {
            double totalPersen = 0;
            int count = 0;

            for (int i = 1; i <= 32; i++)
            {
                Label lblKode = (Label)this.Controls.Find("lbl_kode" + i, true).FirstOrDefault();
                Label lblPersen = (Label)this.Controls.Find("lbl_persen" + i, true).FirstOrDefault();

                if (lblKode != null && lblPersen != null && lblKode.Text.Contains("T"))
                {
                    if (double.TryParse(lblPersen.Text, out double persen))
                    {
                        totalPersen += persen;
                        count++;
                    }
                }
            }

            return count > 0 ? totalPersen / count : 0;
        }

        private double AveragePersenTarikDenganV()
        {
            double totalPersen = 0;
            int count = 0;

            for (int i = 1; i <= 32; i++)
            {
                Label lblKode = (Label)this.Controls.Find("lbl_kode" + i, true).FirstOrDefault();
                Label lblPersen = (Label)this.Controls.Find("lbl_persen" + i, true).FirstOrDefault();

                if (lblKode != null && lblPersen != null && lblKode.Text.Contains("V"))
                {
                    if (double.TryParse(lblPersen.Text, out double persen))
                    {
                        totalPersen += persen;
                        count++;
                    }
                }
            }

            return count > 0 ? totalPersen / count : 0;
        }

        private double AveragePersenTarikDenganL()
        {
            double totalPersen = 0;
            int count = 0;

            for (int i = 1; i <= 32; i++)
            {
                Label lblKode = (Label)this.Controls.Find("lbl_kode" + i, true).FirstOrDefault();
                Label lblPersen = (Label)this.Controls.Find("lbl_persen" + i, true).FirstOrDefault();

                if (lblKode != null && lblPersen != null && lblKode.Text.Contains("L"))
                {
                    if (double.TryParse(lblPersen.Text, out double persen))
                    {
                        totalPersen += persen;
                        count++;
                    }
                }
            }

            return count > 0 ? totalPersen / count : 0;
        }

        private void btn_konversi_Click(object sender, EventArgs e)
        {
            isKg = !isKg;

            for (int i = 1; i <= 32; i++)
            {
                var lblKg = panel1.Controls.Find($"lbl_kg{i}", true).FirstOrDefault();
                var lblNewton = panel1.Controls.Find($"lbl_newton{i}", true).FirstOrDefault();

                if (lblKg != null && lblNewton != null)
                {
                    lblKg.Visible = isKg;
                    lblNewton.Visible = !isKg;
                }
            }

            btn_konversi.Text = isKg ? "Newton" : "Kg";
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

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (index > 0)
                ShowPanel(index - 1);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (index < listPanel.Count - 1)
                ShowPanel(index + 1);
        }
    }
}
