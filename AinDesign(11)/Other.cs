using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AinDesign
{
    public partial class Other : Form
    {
        public Other()
        {
            InitializeComponent();
            ShowMessage.Checked = Properties.Settings.Default.ShowMessage;
            MultiFrame.Value = Properties.Settings.Default.MultiFrame;
            MultiPara.Value = Properties.Settings.Default.MultiPara;
            MultiChara.Value = Properties.Settings.Default.MultiChara;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowMessage = ShowMessage.Checked;
            Properties.Settings.Default.MultiFrame = MultiFrame.Value;
            Properties.Settings.Default.MultiChara = MultiChara.Value;
            Properties.Settings.Default.MultiPara = MultiPara.Value;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void MultiFrame_ValueChanged(object sender, EventArgs e)
        {
            MultiPara.Minimum = MultiFrame.Value;
            label6.Text = "(" + MultiFrame.Value + "～64)";
            MultiChara.Minimum = MultiPara.Value;
            label5.Text = "(" + MultiPara.Value + "～1024)";
        }

        private void MultiPara_ValueChanged(object sender, EventArgs e)
        {
            MultiChara.Minimum = MultiPara.Value;
            label5.Text = "(" + MultiPara.Value + "～1024)";
        }
    }
}
