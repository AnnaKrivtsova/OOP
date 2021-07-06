using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1lab
{
    public partial class Form1 : Form
    {
        private readonly ErrorProvider _errorProvider1;
        Calculator calculator = new Calculator();
        public Form1()
        {
            InitializeComponent();
            _errorProvider1 = new ErrorProvider(this);
        }

        private static void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        public int a;
        public int b;
        public char c;
        private void buttonAnd_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBoxMain.Text);
                textBoxMain.Text = "";
                c = '&';
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void buttonOr_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBoxMain.Text);
                textBoxMain.Text = "";
                c = '|';
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

        }

        private void buttonXor_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBoxMain.Text);
                textBoxMain.Text = "";
                c = '^';
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

        }

        private void buttonNot_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBoxMain.Text);
                c = '~';
                textBoxMain.Text = calculator.Not(a);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

        }
        
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBoxMain.Text == "")
                {
                    b = a;
                }
                else
                {
                    b = Convert.ToInt32(textBoxMain.Text);
                }
                textBoxMain.Text = "";             
                switch (c)
                {
                    case '&':
                        calculator.RegisterHandler(new Calculator.MyHandler(DisplayMessage));
                        calculator.MyMessage();
                        textBoxMain.Text = calculator.And(a, b);
                        break;
                    case '|':
                        textBoxMain.Text = calculator.Or(a, b);
                        break;
                    case '^':
                        textBoxMain.Text = calculator.Xor(a, b);
                        break;
                    case '~':
                        textBoxMain.Text = calculator.Not(a);
                        break;                  
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += "1";
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += "2";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxMain.Text = "";
        }

        private void buttonBinary_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBoxMain.Text);
                c = 'b';
                textBoxMain.Text = calculator.Binary(a);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void buttonOctal_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBoxMain.Text);
                textBoxMain.Text = calculator.Octal(a);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBoxMain.Text);
                textBoxMain.Text = calculator.Decimal(a);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void buttonHexadecimal_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBoxMain.Text);
                textBoxMain.Text = calculator.Hexadecimal(a);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += "4";
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += "3";
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += "5";

        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += "6";

        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += "7";

        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += "8";

        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += "9";

        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += "0";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Message_And(object sender, EventArgs e)
        {
            MessageBox.Show("Operation AND");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
