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

namespace Program_Uji_Tower_V1
{
    public partial class data_perhitungan: Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index = 0;

        public data_perhitungan()
        {
            InitializeComponent();
        }

        private void data_perhitungan_Load(object sender, EventArgs e)
        {
            listPanel.Add(lbl_page1);
            listPanel.Add(lbl_page2);
            // Inisialisasi: sembunyikan semua panel kecuali yang pertama
            for (int i = 0; i < listPanel.Count; i++)
            {
                listPanel[i].Visible = (i == index);
            }

            // Pastikan panel pertama di depan
            listPanel[index].BringToFront();

            timer1.Start();
            timer1.Interval = 1000;

            var props = typeof(mv).GetProperties();

            for (int i = 1; i <= 16; i++)
            {
                // Channel 0
                ComboBox cmb0 = this.Controls.Find($"cmb_ch0_tagid{i}", true).FirstOrDefault() as ComboBox;
                if (cmb0 != null)
                {
                    foreach (var prop in props)
                        cmb0.Items.Add(prop.Name);

                    cmb0.SelectedIndex = -1;
                }

                // Channel 1
                ComboBox cmb1 = this.Controls.Find($"cmb_ch1_tagid{i}", true).FirstOrDefault() as ComboBox;
                if (cmb1 != null)
                {
                    foreach (var prop in props)
                        cmb1.Items.Add(prop.Name);

                    cmb1.SelectedIndex = -1;
                }
            }
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
            for (int i = 0; i <= 16; i++)
            {
                // Channel 0
                ComboBox cmb0 = this.Controls.Find($"cmb_ch0_tagid{i}", true).FirstOrDefault() as ComboBox;
                Label lbl0 = this.Controls.Find($"lbl_ch0_mv{i}", true).FirstOrDefault() as Label;

                if (cmb0 != null && lbl0 != null && cmb0.SelectedItem != null)
                {
                    string selectedProp = cmb0.SelectedItem.ToString();
                    var propInfo = typeof(mv).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double value = (double)propInfo.GetValue(null);
                        lbl0.Text = value.ToString("F3");
                    }
                }

                // Channel 1
                ComboBox cmb1 = this.Controls.Find($"cmb_ch1_tagid{i}", true).FirstOrDefault() as ComboBox;
                Label lbl1 = this.Controls.Find($"lbl_ch1_mv{i}", true).FirstOrDefault() as Label;

                if (cmb1 != null && lbl1 != null && cmb1.SelectedItem != null)
                {
                    string selectedProp = cmb1.SelectedItem.ToString();
                    var propInfo = typeof(mv).GetProperty(selectedProp);
                    if (propInfo != null)
                    {
                        double value = (double)propInfo.GetValue(null);
                        lbl1.Text = value.ToString("F3");
                    }
                }
            }
            //CH0
            HitungDanTampilkan_ch0_kg1();
            HitungDanTampilkan_ch0_kg2();
            HitungDanTampilkan_ch0_kg3();
            HitungDanTampilkan_ch0_kg4();
            HitungDanTampilkan_ch0_kg5();
            HitungDanTampilkan_ch0_kg6();
            HitungDanTampilkan_ch0_kg7();
            HitungDanTampilkan_ch0_kg8();
            HitungDanTampilkan_ch0_kg9();
            HitungDanTampilkan_ch0_kg10();
            HitungDanTampilkan_ch0_kg11();
            HitungDanTampilkan_ch0_kg12();
            HitungDanTampilkan_ch0_kg13();
            HitungDanTampilkan_ch0_kg14();
            HitungDanTampilkan_ch0_kg15();
            HitungDanTampilkan_ch0_kg16();
            //CH1
            HitungDanTampilkan_ch1_kg1();
            HitungDanTampilkan_ch1_kg2();
            HitungDanTampilkan_ch1_kg3();
            HitungDanTampilkan_ch1_kg4();
            HitungDanTampilkan_ch1_kg5();
            HitungDanTampilkan_ch1_kg6();
            HitungDanTampilkan_ch1_kg7();
            HitungDanTampilkan_ch1_kg8();
            HitungDanTampilkan_ch1_kg9();
            HitungDanTampilkan_ch1_kg10();
            HitungDanTampilkan_ch1_kg11();
            HitungDanTampilkan_ch1_kg12();
            HitungDanTampilkan_ch1_kg13();
            HitungDanTampilkan_ch1_kg14();
            HitungDanTampilkan_ch1_kg15();
            HitungDanTampilkan_ch1_kg16();
        }

        void HitungDanTampilkan_ch0_kg1()
        {
            try
            {
                double nilai_mv = mv.modul1_ch00;
                lbl_ch0_mv1.Text = mv.modul1_ch00.ToString("F3");
                double.TryParse(txt_ch0_op1.Text, out double op);
                double.TryParse(txt_ch0_eks1.Text, out double eks);
                double.TryParse(txt_ch0_xload1.Text, out double xload);
                double.TryParse(txt_ch0_zo1.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg1.Text = hasil.ToString("F3");

                master_kg.modul1_ch00 = hasil;
                txt_ch0_idbox1.Text = nameof(mv.modul1_ch00);
            }
            catch { lbl_ch0_kg1.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg2()
        {
            try
            {
                double nilai_mv = mv.modul2_ch00;
                lbl_ch0_mv2.Text = mv.modul2_ch00.ToString("F3");
                double.TryParse(txt_ch0_op2.Text, out double op);
                double.TryParse(txt_ch0_eks2.Text, out double eks);
                double.TryParse(txt_ch0_xload2.Text, out double xload);
                double.TryParse(txt_ch0_zo2.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg2.Text = hasil.ToString("F3");

                master_kg.modul2_ch00 = hasil;
                txt_ch0_idbox2.Text = nameof(mv.modul2_ch00);
            }
            catch { lbl_ch0_kg2.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg3()
        {
            try
            {
                double nilai_mv = mv.modul3_ch00;
                lbl_ch0_mv3.Text = mv.modul3_ch00.ToString("F3");
                double.TryParse(txt_ch0_op3.Text, out double op);
                double.TryParse(txt_ch0_eks3.Text, out double eks);
                double.TryParse(txt_ch0_xload3.Text, out double xload);
                double.TryParse(txt_ch0_zo3.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg3.Text = hasil.ToString("F3");

                master_kg.modul3_ch00 = hasil;
                txt_ch0_idbox3.Text = nameof(mv.modul3_ch00);
            }
            catch { lbl_ch0_kg3.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg4()
        {
            try
            {
                double nilai_mv = mv.modul4_ch00;
                lbl_ch0_mv4.Text = mv.modul4_ch00.ToString("F3");
                double.TryParse(txt_ch0_op4.Text, out double op);
                double.TryParse(txt_ch0_eks4.Text, out double eks);
                double.TryParse(txt_ch0_xload4.Text, out double xload);
                double.TryParse(txt_ch0_zo4.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg4.Text = hasil.ToString("F3");

                master_kg.modul4_ch00 = hasil;
                txt_ch0_idbox4.Text = nameof(mv.modul4_ch00);
            }
            catch { lbl_ch0_kg4.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg5()
        {
            try
            {
                double nilai_mv = mv.modul5_ch00;
                lbl_ch0_mv5.Text = mv.modul5_ch00.ToString("F3");
                double.TryParse(txt_ch0_op5.Text, out double op);
                double.TryParse(txt_ch0_eks5.Text, out double eks);
                double.TryParse(txt_ch0_xload5.Text, out double xload);
                double.TryParse(txt_ch0_zo5.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg5.Text = hasil.ToString("F3");

                master_kg.modul5_ch00 = hasil;
                txt_ch0_idbox5.Text = nameof(mv.modul5_ch00);
            }
            catch { lbl_ch0_kg5.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg6()
        {
            try
            {
                double nilai_mv = mv.modul6_ch00;
                lbl_ch0_mv6.Text = mv.modul6_ch00.ToString("F3");
                double.TryParse(txt_ch0_op6.Text, out double op);
                double.TryParse(txt_ch0_eks6.Text, out double eks);
                double.TryParse(txt_ch0_xload6.Text, out double xload);
                double.TryParse(txt_ch0_zo6.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg6.Text = hasil.ToString("F3");

                master_kg.modul6_ch00 = hasil;
                txt_ch0_idbox6.Text = nameof(mv.modul6_ch00);
            }
            catch { lbl_ch0_kg6.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg7()
        {
            try
            {
                double nilai_mv = mv.modul7_ch00;
                lbl_ch0_mv7.Text = mv.modul7_ch00.ToString("F3");
                double.TryParse(txt_ch0_op7.Text, out double op);
                double.TryParse(txt_ch0_eks7.Text, out double eks);
                double.TryParse(txt_ch0_xload7.Text, out double xload);
                double.TryParse(txt_ch0_zo7.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg7.Text = hasil.ToString("F3");

                master_kg.modul7_ch00 = hasil;
                txt_ch0_idbox7.Text = nameof(mv.modul7_ch00);
            }
            catch { lbl_ch0_kg7.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg8()
        {
            try
            {
                double nilai_mv = mv.modul8_ch00;
                lbl_ch0_mv8.Text = mv.modul8_ch00.ToString("F3");
                double.TryParse(txt_ch0_op8.Text, out double op);
                double.TryParse(txt_ch0_eks8.Text, out double eks);
                double.TryParse(txt_ch0_xload8.Text, out double xload);
                double.TryParse(txt_ch0_zo8.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg8.Text = hasil.ToString("F3");

                master_kg.modul8_ch00 = hasil;
                txt_ch0_idbox8.Text = nameof(mv.modul8_ch00);
            }
            catch { lbl_ch0_kg8.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg9()
        {
            try
            {
                double nilai_mv = mv.modul9_ch00;
                lbl_ch0_mv9.Text = mv.modul9_ch00.ToString("F3");
                double.TryParse(txt_ch0_op9.Text, out double op);
                double.TryParse(txt_ch0_eks9.Text, out double eks);
                double.TryParse(txt_ch0_xload9.Text, out double xload);
                double.TryParse(txt_ch0_zo9.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg9.Text = hasil.ToString("F3");

                master_kg.modul9_ch00 = hasil;
                txt_ch0_idbox9.Text = nameof(mv.modul9_ch00);
            }
            catch { lbl_ch0_kg9.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg10()
        {
            try
            {
                double nilai_mv = mv.modul10_ch00;
                lbl_ch0_mv10.Text = mv.modul10_ch00.ToString("F3");
                double.TryParse(txt_ch0_op10.Text, out double op);
                double.TryParse(txt_ch0_eks10.Text, out double eks);
                double.TryParse(txt_ch0_xload10.Text, out double xload);
                double.TryParse(txt_ch0_zo10.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg10.Text = hasil.ToString("F3");

                master_kg.modul10_ch00 = hasil;
                txt_ch0_idbox10.Text = nameof(mv.modul10_ch00);
            }
            catch { lbl_ch0_kg10.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg11()
        {
            try
            {
                double nilai_mv = mv.modul11_ch00;
                lbl_ch0_mv11.Text = mv.modul11_ch00.ToString("F3");
                double.TryParse(txt_ch0_op11.Text, out double op);
                double.TryParse(txt_ch0_eks11.Text, out double eks);
                double.TryParse(txt_ch0_xload11.Text, out double xload);
                double.TryParse(txt_ch0_zo11.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg11.Text = hasil.ToString("F3");

                master_kg.modul11_ch00 = hasil;
                txt_ch0_idbox11.Text = nameof(mv.modul11_ch00);
            }
            catch { lbl_ch0_kg11.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg12()
        {
            try
            {
                double nilai_mv = mv.modul12_ch00;
                lbl_ch0_mv12.Text = mv.modul12_ch00.ToString("F3");
                double.TryParse(txt_ch0_op12.Text, out double op);
                double.TryParse(txt_ch0_eks12.Text, out double eks);
                double.TryParse(txt_ch0_xload12.Text, out double xload);
                double.TryParse(txt_ch0_zo12.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg12.Text = hasil.ToString("F3");

                master_kg.modul12_ch00 = hasil;
                txt_ch0_idbox12.Text = nameof(mv.modul12_ch00);
            }
            catch { lbl_ch0_kg12.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg13()
        {
            try
            {
                double nilai_mv = mv.modul13_ch00;
                lbl_ch0_mv13.Text = mv.modul13_ch00.ToString("F3");
                double.TryParse(txt_ch0_op13.Text, out double op);
                double.TryParse(txt_ch0_eks13.Text, out double eks);
                double.TryParse(txt_ch0_xload13.Text, out double xload);
                double.TryParse(txt_ch0_zo13.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg13.Text = hasil.ToString("F3");

                master_kg.modul13_ch00 = hasil;
                txt_ch0_idbox13.Text = nameof(mv.modul13_ch00);
            }
            catch { lbl_ch0_kg13.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg14()
        {
            try
            {
                double nilai_mv = mv.modul14_ch00;
                lbl_ch0_mv14.Text = mv.modul14_ch00.ToString("F3");
                double.TryParse(txt_ch0_op14.Text, out double op);
                double.TryParse(txt_ch0_eks14.Text, out double eks);
                double.TryParse(txt_ch0_xload14.Text, out double xload);
                double.TryParse(txt_ch0_zo14.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg14.Text = hasil.ToString("F3");

                master_kg.modul14_ch00 = hasil;
                txt_ch0_idbox14.Text = nameof(mv.modul14_ch00);
            }
            catch { lbl_ch0_kg14.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg15()
        {
            try
            {
                double nilai_mv = mv.modul15_ch00;
                lbl_ch0_mv15.Text = mv.modul15_ch00.ToString("F3");
                double.TryParse(txt_ch0_op15.Text, out double op);
                double.TryParse(txt_ch0_eks15.Text, out double eks);
                double.TryParse(txt_ch0_xload15.Text, out double xload);
                double.TryParse(txt_ch0_zo15.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg15.Text = hasil.ToString("F3");

                master_kg.modul15_ch00 = hasil;
                txt_ch0_idbox15.Text = nameof(mv.modul15_ch00);
            }
            catch { lbl_ch0_kg15.Text = "Err"; }
        }

        void HitungDanTampilkan_ch0_kg16()
        {
            try
            {
                double nilai_mv = mv.modul16_ch00;
                lbl_ch0_mv16.Text = mv.modul16_ch00.ToString("F3");
                double.TryParse(txt_ch0_op16.Text, out double op);
                double.TryParse(txt_ch0_eks16.Text, out double eks);
                double.TryParse(txt_ch0_xload16.Text, out double xload);
                double.TryParse(txt_ch0_zo16.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch0_kg16.Text = hasil.ToString("F3");

                master_kg.modul16_ch00 = hasil;
                txt_ch0_idbox16.Text = nameof(mv.modul16_ch00);
            }
            catch { lbl_ch0_kg16.Text = "Err"; }
        }

        /// <summary>
        /// CHANEl 01
        /// </summary>

        void HitungDanTampilkan_ch1_kg1()
        {
            try
            {
                double nilai_mv = mv.modul1_ch01; // ← Langsung ambil dari mv
                lbl_ch1_mv1.Text = mv.modul1_ch01.ToString("F3");
                double.TryParse(txt_ch1_op1.Text, out double op);
                double.TryParse(txt_ch1_eks1.Text, out double eks);
                double.TryParse(txt_ch1_xload1.Text, out double xload);
                double.TryParse(txt_ch1_zo1.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg1.Text = hasil.ToString("F3");

                master_kg.modul1_ch01 = hasil;
                txt_ch1_idbox1.Text = nameof(mv.modul1_ch01);
            }
            catch
            {
                lbl_ch1_kg1.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg2()
        {
            try
            {
                double nilai_mv = mv.modul2_ch01;
                lbl_ch1_mv2.Text = mv.modul2_ch01.ToString("F3");
                double.TryParse(txt_ch1_op2.Text, out double op);
                double.TryParse(txt_ch1_eks2.Text, out double eks);
                double.TryParse(txt_ch1_xload2.Text, out double xload);
                double.TryParse(txt_ch1_zo2.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg2.Text = hasil.ToString("F3");

                master_kg.modul2_ch01 = hasil;
                txt_ch1_idbox2.Text = nameof(mv.modul2_ch01);
            }
            catch
            {
                lbl_ch1_kg2.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg3()
        {
            try
            {
                double nilai_mv = mv.modul3_ch01;
                lbl_ch1_mv3.Text = mv.modul3_ch01.ToString("F3");
                double.TryParse(txt_ch1_op3.Text, out double op);
                double.TryParse(txt_ch1_eks3.Text, out double eks);
                double.TryParse(txt_ch1_xload3.Text, out double xload);
                double.TryParse(txt_ch1_zo3.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg3.Text = hasil.ToString("F3");

                master_kg.modul3_ch01 = hasil;
                txt_ch1_idbox3.Text = nameof(mv.modul3_ch01);
            }
            catch
            {
                lbl_ch1_kg3.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg4()
        {
            try
            {
                double nilai_mv = mv.modul4_ch01;
                lbl_ch1_mv4.Text = mv.modul4_ch01.ToString("F3");
                double.TryParse(txt_ch1_op4.Text, out double op);
                double.TryParse(txt_ch1_eks4.Text, out double eks);
                double.TryParse(txt_ch1_xload4.Text, out double xload);
                double.TryParse(txt_ch1_zo4.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg4.Text = hasil.ToString("F3");

                master_kg.modul4_ch01 = hasil;
                txt_ch1_idbox4.Text = nameof(mv.modul4_ch01);
            }
            catch
            {
                lbl_ch1_kg4.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg5()
        {
            try
            {
                double nilai_mv = mv.modul5_ch01;
                lbl_ch1_mv5.Text = mv.modul5_ch01.ToString("F3");
                double.TryParse(txt_ch1_op5.Text, out double op);
                double.TryParse(txt_ch1_eks5.Text, out double eks);
                double.TryParse(txt_ch1_xload5.Text, out double xload);
                double.TryParse(txt_ch1_zo5.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg5.Text = hasil.ToString("F3");

                master_kg.modul5_ch01 = hasil;
                txt_ch1_idbox5.Text = nameof(mv.modul5_ch01);
            }
            catch
            {
                lbl_ch1_kg5.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg6()
        {
            try
            {
                double nilai_mv = mv.modul6_ch01;
                lbl_ch1_mv6.Text = mv.modul6_ch01.ToString("F3");
                double.TryParse(txt_ch1_op6.Text, out double op);
                double.TryParse(txt_ch1_eks6.Text, out double eks);
                double.TryParse(txt_ch1_xload6.Text, out double xload);
                double.TryParse(txt_ch1_zo6.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg6.Text = hasil.ToString("F3");

                master_kg.modul6_ch01 = hasil;
                txt_ch1_idbox6.Text = nameof(mv.modul6_ch01);
            }
            catch
            {
                lbl_ch1_kg6.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg7()
        {
            try
            {
                double nilai_mv = mv.modul7_ch01;
                lbl_ch1_mv7.Text = mv.modul7_ch01.ToString("F3");
                double.TryParse(txt_ch1_op7.Text, out double op);
                double.TryParse(txt_ch1_eks7.Text, out double eks);
                double.TryParse(txt_ch1_xload7.Text, out double xload);
                double.TryParse(txt_ch1_zo7.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg7.Text = hasil.ToString("F3");

                master_kg.modul7_ch01 = hasil;
                txt_ch1_idbox7.Text = nameof(mv.modul7_ch01);
            }
            catch
            {
                lbl_ch1_kg7.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg8()
        {
            try
            {
                double nilai_mv = mv.modul8_ch01;
                lbl_ch1_mv8.Text = mv.modul8_ch01.ToString("F3");
                double.TryParse(txt_ch1_op8.Text, out double op);
                double.TryParse(txt_ch1_eks8.Text, out double eks);
                double.TryParse(txt_ch1_xload8.Text, out double xload);
                double.TryParse(txt_ch1_zo8.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg8.Text = hasil.ToString("F3");

                master_kg.modul8_ch01 = hasil;
                txt_ch1_idbox8.Text = nameof(mv.modul8_ch01);
            }
            catch
            {
                lbl_ch1_kg8.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg9()
        {
            try
            {
                double nilai_mv = mv.modul9_ch01;
                lbl_ch1_mv9.Text = mv.modul9_ch01.ToString("F3");
                double.TryParse(txt_ch1_op9.Text, out double op);
                double.TryParse(txt_ch1_eks9.Text, out double eks);
                double.TryParse(txt_ch1_xload9.Text, out double xload);
                double.TryParse(txt_ch1_zo9.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg9.Text = hasil.ToString("F3");

                master_kg.modul9_ch01 = hasil;
                txt_ch1_idbox9.Text = nameof(mv.modul9_ch01);
            }
            catch
            {
                lbl_ch1_kg9.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg10()
        {
            try
            {
                double nilai_mv = mv.modul10_ch01;
                lbl_ch1_mv10.Text = mv.modul10_ch01.ToString("F3");
                double.TryParse(txt_ch1_op10.Text, out double op);
                double.TryParse(txt_ch1_eks10.Text, out double eks);
                double.TryParse(txt_ch1_xload10.Text, out double xload);
                double.TryParse(txt_ch1_zo10.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg10.Text = hasil.ToString("F3");

                master_kg.modul10_ch01 = hasil;
                txt_ch1_idbox10.Text = nameof(mv.modul10_ch01);
            }
            catch
            {
                lbl_ch1_kg10.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg11()
        {
            try
            {
                double nilai_mv = mv.modul11_ch01;
                lbl_ch1_mv11.Text = mv.modul11_ch01.ToString("F3");
                double.TryParse(txt_ch1_op11.Text, out double op);
                double.TryParse(txt_ch1_eks11.Text, out double eks);
                double.TryParse(txt_ch1_xload11.Text, out double xload);
                double.TryParse(txt_ch1_zo11.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg11.Text = hasil.ToString("F3");

                master_kg.modul11_ch01 = hasil;
                txt_ch1_idbox11.Text = nameof(mv.modul11_ch01);
            }
            catch
            {
                lbl_ch1_kg11.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg12()
        {
            try
            {
                double nilai_mv = mv.modul12_ch01;
                lbl_ch1_mv12.Text = mv.modul12_ch01.ToString("F3");
                double.TryParse(txt_ch1_op12.Text, out double op);
                double.TryParse(txt_ch1_eks12.Text, out double eks);
                double.TryParse(txt_ch1_xload12.Text, out double xload);
                double.TryParse(txt_ch1_zo12.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg12.Text = hasil.ToString("F3");

                master_kg.modul12_ch01 = hasil;
                txt_ch1_idbox12.Text = nameof(mv.modul12_ch01);
            }
            catch
            {
                lbl_ch1_kg12.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg13()
        {
            try
            {
                double nilai_mv = mv.modul13_ch01;
                lbl_ch1_mv13.Text = mv.modul13_ch01.ToString("F3");
                double.TryParse(txt_ch1_op13.Text, out double op);
                double.TryParse(txt_ch1_eks13.Text, out double eks);
                double.TryParse(txt_ch1_xload13.Text, out double xload);
                double.TryParse(txt_ch1_zo13.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg13.Text = hasil.ToString("F3");

                master_kg.modul13_ch01 = hasil;
                txt_ch1_idbox13.Text = nameof(mv.modul13_ch01);
            }
            catch
            {
                lbl_ch1_kg13.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg14()
        {
            try
            {
                double nilai_mv = mv.modul14_ch01;
                lbl_ch1_mv14.Text = mv.modul14_ch01.ToString("F3");
                double.TryParse(txt_ch1_op14.Text, out double op);
                double.TryParse(txt_ch1_eks14.Text, out double eks);
                double.TryParse(txt_ch1_xload14.Text, out double xload);
                double.TryParse(txt_ch1_zo14.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg14.Text = hasil.ToString("F3");

                master_kg.modul14_ch01 = hasil;
                txt_ch1_idbox14.Text = nameof(mv.modul14_ch01);
            }
            catch
            {
                lbl_ch1_kg14.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg15()
        {
            try
            {
                double nilai_mv = mv.modul15_ch01;
                lbl_ch1_mv15.Text = mv.modul15_ch01.ToString("F3");
                double.TryParse(txt_ch1_op15.Text, out double op);
                double.TryParse(txt_ch1_eks15.Text, out double eks);
                double.TryParse(txt_ch1_xload15.Text, out double xload);
                double.TryParse(txt_ch1_zo15.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg15.Text = hasil.ToString("F3");

                master_kg.modul15_ch01 = hasil;
                txt_ch1_idbox15.Text = nameof(mv.modul15_ch01);
            }
            catch
            {
                lbl_ch1_kg15.Text = "Err";
            }
        }

        void HitungDanTampilkan_ch1_kg16()
        {
            try
            {
                double nilai_mv = mv.modul16_ch01;
                lbl_ch1_mv16.Text = mv.modul16_ch01.ToString("F3");
                double.TryParse(txt_ch1_op16.Text, out double op);
                double.TryParse(txt_ch1_eks16.Text, out double eks);
                double.TryParse(txt_ch1_xload16.Text, out double xload);
                double.TryParse(txt_ch1_zo16.Text, out double zero);

                double hasil = ((nilai_mv / (op * eks)) * xload) - zero;
                lbl_ch1_kg16.Text = hasil.ToString("F3");

                master_kg.modul16_ch01 = hasil;
                txt_ch1_idbox16.Text = nameof(mv.modul16_ch01);
            }
            catch
            {
                lbl_ch1_kg16.Text = "Err";
            }
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
