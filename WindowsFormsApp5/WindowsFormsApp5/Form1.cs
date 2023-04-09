using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int cekinput;
        private void button1_Click(object sender, EventArgs e)
        {
            cekinput = Convert.ToInt32(textBox_input.Text);
            if (cekinput < 4)
            {
                MessageBox.Show("input harus lebih besar dari 3");
                textBox_input.Clear();
            }
            else
            {
                Form2 baru = new Form2();
                baru.Show();
            }
        }


        private void textBox_input_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

