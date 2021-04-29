using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class calc_Main : Form
    {
        Double value = 0;
        String operation = "";
        bool operation_Pressed = false;

        public calc_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((text_Box_Result.Text == "0")||(operation_Pressed))
                text_Box_Result.Clear();

            Button b = (Button)sender;
            text_Box_Result.Text = text_Box_Result.Text + b.Text;

            operation_Pressed = false;

        }

        private void button_Clear_All_Click(object sender, EventArgs e)
        {
            text_Box_Result.Text = "0";
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            text_Box_Result.Clear();
            value = 0;
        }

        private void button_Operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = Double.Parse(text_Box_Result.Text);
            operation_Pressed = true;

        }

        private void button_Equal_Click(object sender, EventArgs e)
        {

            switch(operation)
            {
                case "+":
                    text_Box_Result.Text = (value + Double.Parse(text_Box_Result.Text)).ToString();
                    break;

                case "-":
                    text_Box_Result.Text = (value - Double.Parse(text_Box_Result.Text)).ToString();
                    break;
                case "x":
                    text_Box_Result.Text = (value * Double.Parse(text_Box_Result.Text)).ToString();
                    break;
                case "/":
                    text_Box_Result.Text = (value / Double.Parse(text_Box_Result.Text)).ToString();
                    break;
                default:
                    break;

            }// END SWITCH
            operation_Pressed = false;
        }

    }
}
