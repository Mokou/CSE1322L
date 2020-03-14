using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        bool op, second = false;

        private void Button0_Click(object sender, EventArgs e) {
            if (op)
                second = true;
            AnswerBox.Text += '0';
        }

        private void Button1_Click(object sender, EventArgs e) {
            if (op)
                second = true;
            AnswerBox.Text += '1';
        }

        private void Button2_Click(object sender, EventArgs e) {
            if (op)
                second = true;
            AnswerBox.Text += '2';
        }

        private void Button3_Click(object sender, EventArgs e) {
            if (op)
                second = true;
            AnswerBox.Text += '3';
        }

        private void Button4_Click(object sender, EventArgs e) {
            if (op)
                second = true;
            AnswerBox.Text += '4';
        }

        private void Button5_Click(object sender, EventArgs e) {
            if (op)
                second = true;
            AnswerBox.Text += '5';
        }

        private void Button6_Click(object sender, EventArgs e) {
            if (op)
                second = true;
            AnswerBox.Text += '6';
        }

        private void Button7_Click(object sender, EventArgs e) {
            if (op)
                second = true;
            AnswerBox.Text += '7';
        }

        private void Button8_Click(object sender, EventArgs e) {
            if (op)
                second = true;
            AnswerBox.Text += '8';
        }

        private void Button9_Click(object sender, EventArgs e) {
            if (op)
                second = true;
            AnswerBox.Text += '9';
        }

        private void DivideButton_Click(object sender, EventArgs e) {
            if (!op && AnswerBox.Text != "") {
                AnswerBox.Text += " / ";
                op = true;
            }
        }

        private void MultiplyButton_Click(object sender, EventArgs e) {
            if (!op && AnswerBox.Text != "") {
                AnswerBox.Text += " * ";
                op = true;
            }
        }

        private void SubtractButton_Click(object sender, EventArgs e) {
            if (!op && AnswerBox.Text != "") {
                AnswerBox.Text += " - ";
                op = true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e) {
            if (!op && AnswerBox.Text != "") {
                AnswerBox.Text += " + ";
                op = true;
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e) {
            if (op && second) {
                var arr = AnswerBox.Text.Split();
                switch (arr[1]) {
                    case "/":
                        if (Convert.ToDouble(arr[2]) != 0) {
                            AnswerBox.Text = Convert.ToString(Convert.ToDouble(arr[0]) / Convert.ToDouble(arr[2]));
                            op = false;
                            second = false;
                        }
                        break;
                    case "*":
                        AnswerBox.Text = Convert.ToString(Convert.ToDouble(arr[0]) * Convert.ToDouble(arr[2]));
                        op = false;
                        second = false;
                        break;
                    case "-":
                        AnswerBox.Text = Convert.ToString(Convert.ToDouble(arr[0]) - Convert.ToDouble(arr[2]));
                        op = false;
                        second = false;
                        break;
                    case "+":
                        AnswerBox.Text = Convert.ToString(Convert.ToDouble(arr[0]) + Convert.ToDouble(arr[2]));
                        op = false;
                        second = false;
                        break;
                }
            }
        }
    }
}
