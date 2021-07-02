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
        String operation = "";
        byte point_Token = 0;
        bool pointEnable = true;
        bool operation_Status;
        //bool par_StatusL = false;
        //bool par_StatusR = false;
        bool par_TokenL;
        bool par_TokenR;
        //double memory = 0;
        
        public calc_Main()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }
        //buttons
        public void button_Num_Click(object sender, EventArgs e)
        {
            if (text_Box_Entry.Text == "0")
            {
                text_Box_Entry.Clear();
            }

            if (par_TokenR == true)
            {
                Button b = (Button)sender;
                text_Box_Entry.Text = text_Box_Entry.Text + "*" + b.Text;
                if (pointEnable == false)
                {
                    point_Token++;
                }
            }
            
            if (par_TokenR == false)
            {
                Button b = (Button)sender;
                text_Box_Entry.Text = text_Box_Entry.Text + b.Text;
                if (pointEnable == false)
                {
                    point_Token++;
                }
            }
            
            //result = result + b.Text;

            operation_Status = false;
            par_TokenL = true;
            par_TokenR = false;
            //par_StatusL = true;
            //par_StatusR = false;
        }

        public void button_Dot_Click(object sender, EventArgs e)
        {
            if (pointEnable == true)
            {
                if (text_Box_Entry.Text == "0")
                {
                    text_Box_Entry.Clear();
                }

                if (par_TokenR == true)
                {
                    Button b = (Button)sender;
                    if (point_Token == 0)
                    {
                        text_Box_Entry.Text = text_Box_Entry.Text + "*" + b.Text;
                        pointEnable = false;
                        point_Token++;
                    }
                }

                if (par_TokenR == false)
                {
                    Button b = (Button)sender;
                    if (point_Token == 0)
                    {
                        text_Box_Entry.Text = text_Box_Entry.Text + b.Text;
                        pointEnable = false;
                        point_Token++;
                    }
                }
            }
        }

        public void button_Clear_All_Click(object sender, EventArgs e)
        {
            text_Box_Entry.Text = "0";
            text_Box_Result.Text = "0";
            //result = "0";
            operation_Status = false;
            par_TokenL = false;
            par_TokenR = false;
            point_Token = 0;
            pointEnable = true;
        }

        public void button_Clear_Click(object sender, EventArgs e)
        {
            if (text_Box_Entry.Text.Length > 0)
            {
                text_Box_Entry.Text = text_Box_Entry.Text.Remove(text_Box_Entry.Text.Length - 1, 1);
            }

            if (text_Box_Entry.Text == "") 
            {
                text_Box_Entry.Text = "0";
            }

            if (point_Token == 1)
            {
                pointEnable = true;
            }
            
            if (point_Token != 0)
            {
                point_Token--;
            }
            operation_Status = false;
            par_TokenL = false;
            par_TokenR = false;
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
            pointEnable = true;
            point_Token = 0;
        }

        public void button_L_Par_Click(object sender, EventArgs e)
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

        public void button_R_Par_Click(object sender, EventArgs e)
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

        public void button_Pi_Click(object sender, EventArgs e)
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
        }

        //MEMORY MANIPULATION
        private void button_MC_Click(object sender, EventArgs e)
        {
            listBox_Mem.Items.Clear();
            button_M.Enabled = false;
            button_MR.Enabled = false;
            button_MSub.Enabled = false;
            button_MAdd.Enabled = false;
            button_MC.Enabled = false;
        }

        public void button_MR_Click(object sender, EventArgs e)
        {
            if (text_Box_Entry.Text == "0")
            {
                text_Box_Entry.Clear();
            }

            if (par_TokenR == true)
            {
                text_Box_Entry.Text = text_Box_Entry.Text + "*" + listBox_Mem.Items[0].ToString();
                if (pointEnable == false)
                {
                    string s = (string)listBox_Mem.Items[0];
                    byte n = (byte)s.Length;
                    point_Token = (byte)(point_Token + n);
                }
            }

            if (par_TokenR == false)
            {
                text_Box_Entry.Text = text_Box_Entry.Text + listBox_Mem.Items[0].ToString();
                if (pointEnable == false)
                {
                    string s = (string)listBox_Mem.Items[0];
                    byte n = (byte)s.Length;
                    point_Token = (byte)(point_Token + n);
                }
            }

            operation_Status = false;
            par_TokenL = true;
            listBox_Mem.Visible = false;
        }
        public void button_MS_Click(object sender, EventArgs e)
        {
            listBox_Mem.Items.Insert(0, text_Box_Result.Text);
            button_MR.Enabled = true;
            button_MSub.Enabled = true;
            button_MAdd.Enabled = true;
            button_M.Enabled = true;
            button_MC.Enabled = true;
        }

        public void button_MAdd_Click(object sender, EventArgs e)
        {
            string recent_Val = listBox_Mem.Items[0].ToString();
            listBox_Mem.Items[0] = (double.Parse(recent_Val) + double.Parse(text_Box_Entry.Text)).ToString();
        }

        public void button_MSub_Click(object sender, EventArgs e)
        {
            string recent_Val = listBox_Mem.Items[0].ToString();
            listBox_Mem.Items[0] = (double.Parse(recent_Val) - double.Parse(text_Box_Entry.Text)).ToString();
        }

        public void button_M_Click(object sender, EventArgs e)
        {
            listBox_Mem.Visible = true;
        }

        public void listBox_Mem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox_Mem.SelectedItem != null)
            {
                if (text_Box_Entry.Text == "0")
                {
                    text_Box_Entry.Clear();
                }

                if (par_TokenR == true)
                {
                    text_Box_Entry.Text = text_Box_Entry.Text + "*" + listBox_Mem.Text;
                    if (pointEnable == false)
                    {
                        string s = (string)listBox_Mem.SelectedItem;
                        byte n = (byte)s.Length;
                        point_Token = (byte)(point_Token + n);
                    }
                }

                if (par_TokenR == false)
                {
                    text_Box_Entry.Text = text_Box_Entry.Text + listBox_Mem.Text;
                    if (pointEnable == false)
                    {
                        string s = (string)listBox_Mem.SelectedItem;
                        byte n = (byte)s.Length;
                        point_Token = (byte)(point_Token + n);
                    }
                }

                operation_Status = false;
                par_TokenL = true;
                listBox_Mem.Visible = false;
            }
        }

        public void calc_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void calc_Main_MouseClick(object sender, MouseEventArgs e)
        {
            listBox_Mem.Visible = false;
        }

        public void text_Box_Result_MouseClick(object sender, MouseEventArgs e)
        {
            listBox_Mem.Visible = false;
        }

        public void text_Box_Entry_MouseClick(object sender, MouseEventArgs e)
        {
            listBox_Mem.Visible = false;
        }

        //KeyBinds
        private void calc_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                button1.PerformClick();
            }
            if (e.KeyCode == Keys.D2)
            {
                button2.PerformClick();
            }
            if (e.KeyCode == Keys.D3)
            {
                button3.PerformClick();
            }
            if (e.KeyCode == Keys.D4)
            {
                button4.PerformClick();
            }
            if (e.KeyCode == Keys.D5 && e.Modifiers != Keys.Shift)
            {
                button5.PerformClick();
            }
            if (e.KeyCode == Keys.D6 && e.Modifiers != Keys.Shift)
            {
                button6.PerformClick();
            }
            if (e.KeyCode == Keys.D7)
            {
                button7.PerformClick();
            }
            if (e.KeyCode == Keys.D8)
            {
                button8.PerformClick();
            }
            if (e.KeyCode == Keys.D9 && e.Modifiers != Keys.Shift)
            {
                button9.PerformClick();
            }
            if (e.KeyCode == Keys.D0 && e.Modifiers != Keys.Shift)
            {
                button0.PerformClick();
            }
            if (e.KeyCode == Keys.OemPeriod)
            {
                button_Dot.PerformClick();
            }
            if (e.KeyCode == Keys.Oemplus && e.Modifiers == Keys.Shift)
            {
                button_Add.PerformClick();
            }
            if (e.KeyCode == Keys.OemMinus)
            {
                button_Subtract.PerformClick();
            }
            if (e.KeyCode == Keys.D6 && e.Modifiers == Keys.Shift)
            {
                button_Multiply.PerformClick();
            }
            if (e.KeyCode == Keys.OemQuestion)
            {
                button_Divide.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button_Equal.PerformClick();
            }
            if (e.KeyCode == Keys.Back)
            {
                button_Clear.PerformClick();
            }
            if (e.KeyCode == Keys.Delete)
            {
                button_Clear_All.PerformClick();
            }
            if (e.KeyCode == Keys.D5 && e.Modifiers == Keys.Shift)
            {
                button_Mod.PerformClick();
            }
            if (e.KeyCode == Keys.D9 && e.Modifiers == Keys.Shift)
            {
                button_L_Par.PerformClick();
            }
            if (e.KeyCode == Keys.D0 && e.Modifiers == Keys.Shift)
            {
                button_R_Par.PerformClick();
            }
            if (e.KeyCode == Keys.E)
            {
                button_Base10.PerformClick();
            }
        }
    }
}
