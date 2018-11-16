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
            CalculateDamage();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Savefile.SaveSavefile();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
