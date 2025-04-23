using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICPDAS.OPC;
using ICPDAS.OPCDA;
using ICPDAS.OPC.NET;
using System.Web;

namespace Program_Uji_Tower_V1
{
    public partial class master_data : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index;

        private ICPDAS_OPCServer Svr;
        private GroupIO_Synchronous ReadWriteGroup;
        private RefreshGroup AsyncRefrGroup;
        string ServerName;

        private bool hasShownReadError = false;

        private TextBox[] txt_tagids;
        private TextBox[] txt_vals;
        private TextBox[] txt_quas;
        private ComboBox[] cmb_tags;

        public master_data()
        {
            InitializeComponent();
        }

        private void master_data_Load(object sender, EventArgs e)
        {

            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel[index].BringToFront();

            IsiComboMVProperties(cmb_tag1, cmb_tag2, cmb_tag3, cmb_tag4, cmb_tag5, cmb_tag6, cmb_tag7, cmb_tag8,
                cmb_tag9, cmb_tag10, cmb_tag11, cmb_tag12, cmb_tag13, cmb_tag14, cmb_tag15, cmb_tag16,
                cmb_tag17, cmb_tag18, cmb_tag19, cmb_tag20, cmb_tag21, cmb_tag22, cmb_tag23, cmb_tag24,
                cmb_tag25, cmb_tag26, cmb_tag27, cmb_tag28, cmb_tag29, cmb_tag30, cmb_tag31, cmb_tag32);

            txt_tagids = new TextBox[] {  txt_tagid1, txt_tagid2, txt_tagid3, txt_tagid4, txt_tagid5, txt_tagid6, txt_tagid7, txt_tagid8,
                txt_tagid9, txt_tagid10, txt_tagid11, txt_tagid12, txt_tagid13, txt_tagid14, txt_tagid15, txt_tagid16,
                txt_tagid17, txt_tagid18, txt_tagid19, txt_tagid20, txt_tagid21, txt_tagid22, txt_tagid23, txt_tagid24,
                txt_tagid25, txt_tagid26, txt_tagid27, txt_tagid28, txt_tagid29, txt_tagid30, txt_tagid31, txt_tagid32 };

            txt_vals = new TextBox[] { txt_val1, txt_val2, txt_val3, txt_val4, txt_val5, txt_val6, txt_val7, txt_val8,
                txt_val9, txt_val10, txt_val11, txt_val12, txt_val13, txt_val14, txt_val15, txt_val16,
                txt_val17, txt_val18, txt_val19, txt_val20, txt_val21, txt_val22, txt_val23, txt_val24,
                txt_val25, txt_val26, txt_val27, txt_val28, txt_val29, txt_val30, txt_val31, txt_val32 };

            txt_quas = new TextBox[] { txt_qua1, txt_qua2, txt_qua3, txt_qua4, txt_qua5, txt_qua6, txt_qua7, txt_qua8,
                txt_qua9, txt_qua10, txt_qua11, txt_qua12, txt_qua13, txt_qua14, txt_qua15, txt_qua16,
                txt_qua17, txt_qua18, txt_qua19, txt_qua20, txt_qua21, txt_qua22, txt_qua23, txt_qua24,
                txt_qua25, txt_qua26, txt_qua27, txt_qua28, txt_qua29, txt_qua30, txt_qua31, txt_qua32 };

            cmb_tags = new ComboBox[] { cmb_tag1, cmb_tag2, cmb_tag3, cmb_tag4, cmb_tag5, cmb_tag6, cmb_tag7, cmb_tag8,
                cmb_tag9, cmb_tag10, cmb_tag11, cmb_tag12, cmb_tag13, cmb_tag14, cmb_tag15, cmb_tag16,
                cmb_tag17, cmb_tag18, cmb_tag19, cmb_tag20, cmb_tag21, cmb_tag22, cmb_tag23, cmb_tag24,
                cmb_tag25, cmb_tag26, cmb_tag27, cmb_tag28, cmb_tag29, cmb_tag30, cmb_tag31, cmb_tag32 };  
        }
        private void IsiComboMVProperties(params ComboBox[] comboBoxes)
        {
            var mvProps = typeof(mv).GetProperties().Select(p => p.Name).ToArray();
            foreach (var cmb in comboBoxes)
            {
                cmb.Items.Clear();
                cmb.Items.AddRange(mvProps);
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void DataChangeHandler(object sender, DataChangeEventArgs e)
        {
            for(int i=0;i <e.sts.Length; ++i)
            {
                int hnd = e.sts[i].HandleClient;
                object val = e.sts[i].DataValue;
                string qt = AsyncRefrGroup.GetQualityString(e.sts[i].Quality);
                DateTime dt = DateTime.FromFileTime(e.sts[i].TimeStamp);
                ICPDAS.OPC.NET.TagDef tag = AsyncRefrGroup.SearchClientHandle(hnd);
                if  (tag != null)
                {
                    string name = tag.OpcIDef.TagID;
                }
            }
        }        
        
        private void btn_con_Click(object sender, EventArgs e)
        {
            ServerName = "NAPOPC.Svr.1";
            Svr = new ICPDAS_OPCServer();
            Svr.Connect(ServerName);

            ReadWriteGroup = new GroupIO_Synchronous(Svr, 1000);
            AsyncRefrGroup = new RefreshGroup(Svr, new DataChangeEventHandler(DataChangeHandler), 1000);
            timer1.Start();
            timer1.Interval = 1500;

            SetTagIdInputsState(false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 32; i++)
            {
                string tagId = txt_tagids[i].Text;
                if (string.IsNullOrEmpty(tagId)) continue;

                int result = ReadWriteGroup.Read(OPCDATASOURCE.OPC_DS_DEVICE, tagId, out ICPDAS_OPCTagState state);
                if (state != null && HRESULTS.Succeeded(state.Error))
                {
                    txt_vals[i].Text = state.DataValue?.ToString() ?? "";
                    txt_quas[i].Text = ReadWriteGroup.GetQualityString(state.Quality);
                    hasShownReadError = false;
                    System.Diagnostics.Debug.WriteLine("Ini untuk debug output");
                }
                else if (!hasShownReadError)
                {
                    hasShownReadError = true;
                    timer1.Stop();
                    MessageBox.Show($"Gagal membaca tag {i + 1}: " + result);
                }

                string saveToTarget = cmb_tags[i].SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(saveToTarget))
                {
                    double.TryParse(txt_vals[i].Text, out double val);
                    SaveToStaticMV(saveToTarget, val);
                }
            }
        }

        private void SaveToStaticMV(string propertyName, double value)
        {
            var prop = typeof(mv).GetProperty(propertyName);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(null, value);
            }
        }

        private void btn_dis_Click(object sender, EventArgs e)
        {
            if (Svr != null)
            {
                AsyncRefrGroup.Dispose();
                ReadWriteGroup.Dispose();
                Svr.Disconnect();
                Svr = null;
                timer1.Stop();
            }

            SetTagIdInputsState(true);
        }

        private void SetTagIdInputsState(bool isEnabled)
        {
            for (int i = 1; i <= 16; i++)
            {
                Control[] txtControls = this.Controls.Find("txt_tagid" + i, true);
                if (txtControls.Length > 0 && txtControls[0] is TextBox txtBox)
                {
                    txtBox.ReadOnly = !isEnabled;
                }
            }
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

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (index < listPanel.Count - 1)
                listPanel[++index].BringToFront();
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (index > 0)
                listPanel[--index].BringToFront();
        }
    }
}
