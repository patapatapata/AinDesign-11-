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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            OneCharaMode.Checked = Properties.Settings.Default.OneChara;
            Tracking.Checked = Properties.Settings.Default.OneTracking;
            Rotation.Checked = Properties.Settings.Default.OneRotation;
            Position.Checked = Properties.Settings.Default.OnePosition;
            Tsume.Checked = Properties.Settings.Default.OneTsume;
            Italics.Checked = Properties.Settings.Default.OneItalics;
            NoBreak.Checked = Properties.Settings.Default.OneNoBreak;
            Aki.Checked = Properties.Settings.Default.OneAki;
            Underline.Checked = Properties.Settings.Default.OneUnderline;
            Stroke.Checked = Properties.Settings.Default.OneStroke;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OneRotation = Rotation.Checked;
            Properties.Settings.Default.OnePosition = Position.Checked;
            Properties.Settings.Default.OneTracking = Tracking.Checked;
            Properties.Settings.Default.OneTsume = Tsume.Checked;
            Properties.Settings.Default.OneItalics = Italics.Checked;
            Properties.Settings.Default.OneAki = Aki.Checked;
            Properties.Settings.Default.OneNoBreak = NoBreak.Checked;
            Properties.Settings.Default.OneUnderline = Underline.Checked;
            Properties.Settings.Default.OneStroke = Stroke.Checked;
            Properties.Settings.Default.OneChara = OneCharaMode.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

    }
}
