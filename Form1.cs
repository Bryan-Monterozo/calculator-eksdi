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
        String result = "";
        Double value = 0;
        String operation = "";


        public calc_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //buttons

        private void button_Click(object sender, EventArgs e)
        {
            if (text_Box_Entry.Text == "0")
                text_Box_Entry.Clear();


            Button b = (Button)sender;
            text_Box_Entry.Text = text_Box_Entry.Text + b.Text;
            result = result + b.Text;


        }

        private void button_Clear_All_Click(object sender, EventArgs e)
        {
            text_Box_Entry.Text = "0";
            result = "0";
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            if (text_Box_Entry.Text.Length >0)
            {
                text_Box_Entry.Text = text_Box_Entry.Text.Remove(text_Box_Entry.Text.Length - 1, 1);
            }

            if (text_Box_Entry.Text == "") 
            {
                text_Box_Entry.Text = "0";
            }

            if (result.Length > 0)
            {
                result = result.Remove(result.Length - 1, 1);
            }

            if (result == "")
            {
                result = "0";
            }
        }

        private void button_Operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            text_Box_Entry.Text = text_Box_Entry.Text + operation;

            value = Double.Parse(result);
            result = "";
        }

        private void button_Equal_Click(object sender, EventArgs e)
        {

            switch(operation)
            {
                case "+":
                    text_Box_Result.Text = (value + Double.Parse(result)).ToString();
                    break;

                case "-":
                    text_Box_Result.Text = (value - Double.Parse(result)).ToString();
                    break;
                case "x":
                    text_Box_Result.Text = (value * Double.Parse(result)).ToString();
                    break;
                case "/":
                    text_Box_Result.Text = (value / Double.Parse(result)).ToString();
                    break;
                default:
                    break;

            }// END SWITCH

        }

    }
}
