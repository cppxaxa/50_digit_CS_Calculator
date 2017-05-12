using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollabCPPandCS
{
    public partial class Calculator_1 : Form
    {
        public Calculator_1()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInput1.Text = "";
            txtInput2.Text = "";
            txtResult.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtInput2.Text = txtInput1.Text;
            txtInput1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtInput1.Text = txtInput2.Text;
            txtInput2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtInput2.Text = txtResult.Text;
            txtResult.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int[] a, b, c;
            a = _50_digit_Lib_Wrapper.cast_obj(txtInput1.Text);
            b = _50_digit_Lib_Wrapper.cast_obj(txtInput2.Text);
            c = _50_digit_Lib_Wrapper.cast_obj();
            _50_digit_Lib_Wrapper.add_obj(a, b, c);

            txtResult.Text = _50_digit_Lib_Wrapper.ToString_obj(c);
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            int[] a, b, c;
            a = _50_digit_Lib_Wrapper.cast_obj(txtInput1.Text);
            b = _50_digit_Lib_Wrapper.cast_obj(txtInput2.Text);
            c = _50_digit_Lib_Wrapper.cast_obj();

            if (_50_digit_Lib_Wrapper.smaller_obj(a, b) == 1)
                c = _50_digit_Lib_Wrapper.cast_obj("0");
            else
                _50_digit_Lib_Wrapper.div_obj(a, b, c);

            txtResult.Text = _50_digit_Lib_Wrapper.ToString_obj(c);
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            int[] a, b, c;
            a = _50_digit_Lib_Wrapper.cast_obj(txtInput1.Text);
            b = _50_digit_Lib_Wrapper.cast_obj(txtInput2.Text);
            c = _50_digit_Lib_Wrapper.cast_obj();

            if (_50_digit_Lib_Wrapper.greater_obj(a, b) == 1)
            {
                _50_digit_Lib_Wrapper.sub_obj(a, b, c);
                txtResult.Text = _50_digit_Lib_Wrapper.ToString_obj(c);
            }
            else if(_50_digit_Lib_Wrapper.greater_obj(b, a) == 0)
            {
                _50_digit_Lib_Wrapper.sub_obj(b, a, c);
                txtResult.Text = _50_digit_Lib_Wrapper.ToString_obj(c);
            }
            else{
                _50_digit_Lib_Wrapper.sub_obj(b, a, c);
                txtResult.Text = _50_digit_Lib_Wrapper.ToString_obj(c);

                MessageBox.Show("Result is negative");
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            int[] a, b, c;
            a = _50_digit_Lib_Wrapper.cast_obj(txtInput1.Text);
            b = _50_digit_Lib_Wrapper.cast_obj(txtInput2.Text);
            c = _50_digit_Lib_Wrapper.cast_obj();
            _50_digit_Lib_Wrapper.mul_obj(a, b, c);

            txtResult.Text = _50_digit_Lib_Wrapper.ToString_obj(c);
        }
    }
}
