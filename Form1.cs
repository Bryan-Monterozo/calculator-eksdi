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
       
        //String result = "";
        String operation = "";
        bool operation_Status;
        //bool par_StatusL = false;
        //bool par_StatusR = false;
        bool par_TokenL;
        bool par_TokenR;

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
            {
                text_Box_Entry.Clear();
            }

            if (par_TokenR == true)
            {
                Button b = (Button)sender;
                text_Box_Entry.Text = text_Box_Entry.Text + "*" + b.Text;
            }
            
            if (par_TokenR == false)
            {
                Button b = (Button)sender;
                text_Box_Entry.Text = text_Box_Entry.Text + b.Text;
            }
            
            //result = result + b.Text;

            operation_Status = false;
            par_TokenL = true;
            //par_StatusL = true;
            //par_StatusR = false;
        }

        public void button_Clear_All_Click(object sender, EventArgs e)
        {
            text_Box_Entry.Text = "0";
            text_Box_Result.Text = "0";
            //result = "0";
            operation_Status = false;
            par_TokenL = false;
            par_TokenR = false;
        }

        public void button_Clear_Click(object sender, EventArgs e)
        {
            if (text_Box_Entry.Text.Length >0)
            {
                text_Box_Entry.Text = text_Box_Entry.Text.Remove(text_Box_Entry.Text.Length - 1, 1);
                operation_Status = false;
            }

            if (text_Box_Entry.Text == "") 
            {
                text_Box_Entry.Text = "0";
                operation_Status = false;
            }
            operation_Status = false;
            par_TokenL = false;
            par_TokenR = false;

            /* 
                        if (result.Length > 0)
                        {
                            result = result.Remove(result.Length - 1, 1);
                            operation_Status = false;
                        }

                        if (result == "")
                        {
                            result = "0";
                            operation_Status = false;

                        }
            */
        }

        public void button_Operator_Click(object sender, EventArgs e)
        {
            if (operation_Status == false)
            {
                Button b = (Button)sender;
                operation = b.Text;
                text_Box_Entry.Text = text_Box_Entry.Text + operation;
                operation_Status = true;
                //par_StatusL = false;
            }
            par_TokenL = false;
            par_TokenR = false;
            
        }

        private void button_L_Par_Click(object sender, EventArgs e)
        {
            if (text_Box_Entry.Text == "0")
            {
                text_Box_Entry.Clear();
            }

            if (par_TokenL == false)
            {
                Button b = (Button)sender;
                operation = b.Text;
                text_Box_Entry.Text = text_Box_Entry.Text + operation;
            }

            if (par_TokenL == true)
            {
                Button b = (Button)sender;
                operation = b.Text;
                text_Box_Entry.Text = text_Box_Entry.Text + "*" + operation;
                par_TokenL = false;
            }
            /*if (par_StatusL == false)
            {
                Button b = (Button)sender;
                operation = b.Text;
                text_Box_Entry.Text = text_Box_Entry.Text + operation;
                par_StatusL = true;
            }*/
            par_TokenR = false;
        }

        private void button_R_Par_Click(object sender, EventArgs e)
        {
            if (text_Box_Entry.Text == "0")
            {
                text_Box_Entry.Clear();
            }

            Button b = (Button)sender;
            operation = b.Text;
            text_Box_Entry.Text = text_Box_Entry.Text + operation;

            par_TokenL = true;
            par_TokenR = true;

            /*if (par_StatusR == false)
            {
                Button b = (Button)sender;
                operation = b.Text;
                text_Box_Entry.Text = text_Box_Entry.Text + operation;
                par_StatusR = true;
            }*/
        }

        private void button_Pi_Click(object sender, EventArgs e)
        {
            if (text_Box_Entry.Text == "0")
            {
                text_Box_Entry.Clear();
            }
            if (par_TokenL == false)
            {
                text_Box_Entry.Text = text_Box_Entry.Text + "(3.14159)";
                operation_Status = false;

            }
            if (par_TokenL == true)
            {
                text_Box_Entry.Text = text_Box_Entry.Text + "*" + "(3.14159)";
                operation_Status = false;
            }
            par_TokenL = true;
            par_TokenR = true;
        }

        //For Evaluating Strings as expression
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
            try
            {
                text_Box_Result.Text = Evaluate(text_Box_Entry.Text).ToString();
            }
            catch (Exception)
            {
                text_Box_Result.Text = "SYNTAX Error";
            }
            
          


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
