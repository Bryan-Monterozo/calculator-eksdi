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

        //Declared values
       
        String result = "";
        Double value = 0;
        String operation = "";


        public calc_Main()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //buttons

        public void button_Click(object sender, EventArgs e)
        {
            if (text_Box_Entry.Text == "0")
                text_Box_Entry.Clear();


            Button b = (Button)sender;
            text_Box_Entry.Text = text_Box_Entry.Text + b.Text;
            result = result + b.Text;


        }

        public void button_Clear_All_Click(object sender, EventArgs e)
        {
            text_Box_Entry.Text = "0";
            result = "0";
        }

        public void button_Clear_Click(object sender, EventArgs e)
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

        public void button_Operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            text_Box_Entry.Text = text_Box_Entry.Text + operation;

            value = Double.Parse(result);
            result = "";
        }

        public static Double Evaluate(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return Double.Parse((string)row["expression"]);
        }

        public void button_Equal_Click(object sender, EventArgs e)
        {
            text_Box_Result.Text = Evaluate(text_Box_Entry.Text).ToString();
/* TESTING

            switch(operation)
            {
                case "+":
                    text_Box_Result.Text = (value + Double.Parse(result)).ToString();
                    break;

                case "-":
                    text_Box_Result.Text = (value - Double.Parse(result)).ToString();
                    break;
                case "*":
                    text_Box_Result.Text = (value * Double.Parse(result)).ToString();
                    break;
                case "/":
                    text_Box_Result.Text = (value / Double.Parse(result)).ToString();
                    break;
                default:
                    break;

            }// END SWITCH
*/

               
        }

    }
}
