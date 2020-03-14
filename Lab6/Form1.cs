using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public int Val1 { get; set; } = 0;
        public int Val2 { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => label1.Text = $"The value is {Val1 + Val2}";

        private void textBox1_TextChanged(object sender, EventArgs e) {
            try {
                Val1 = Convert.ToInt32(textBox1.Text);
            } catch (System.FormatException) { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            try {
                Val2 = Convert.ToInt32(textBox2.Text);
            } catch (System.FormatException) { }
        }
    }
}
