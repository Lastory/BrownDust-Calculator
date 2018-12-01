using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrownDust_Calculator
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void button_DO_Click(object sender, EventArgs e)
        {
            CalculateAll();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Savefile.SaveSavefile();
        }

        private void comboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Language != comboBox_Language.SelectedIndex)
            {
                Language = comboBox_Language.SelectedIndex;
                UILanguageChange();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lastory/BrownDust-Calculator");
        }

        private void linkLabel_Update_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lastory/BrownDust-Calculator/releases");
        }
    }
}
