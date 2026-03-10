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
    public partial class color : Form
    {
        public color()
        {
            InitializeComponent();
            colorConvert.Checked = Properties.Settings.Default.ColorConvert;
            CMY0.Checked = Properties.Settings.Default.CMY0;
            CMYK0.Checked = Properties.Settings.Default.CMYK0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ColorConvert = colorConvert.Checked;
            Properties.Settings.Default.CMY0 = CMY0.Checked;
            Properties.Settings.Default.CMYK0 = CMYK0.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
