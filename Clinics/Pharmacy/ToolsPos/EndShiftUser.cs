using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinics.Pharmacy.ToolsPos
{
    public partial class EndShiftUser : Form
    {
        public EndShiftUser()
        {
            InitializeComponent();
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    btn_View_Emp_No.Enabled = false;
                    textBox_Emp_No.Enabled = false;
                    textBox_Emp_Name.Enabled = false;
                }
                else
                {
                    btn_View_Emp_No.Enabled = true;
                    textBox_Emp_No.Enabled = true;
                    textBox_Emp_Name.Enabled = true;
                }
            }
            catch
            {

            }            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked == true)
                {
                    dateTime_From_Date.Enabled = false;
                    dateTime_To_Date.Enabled = false;                   
                }
                else
                {
                    dateTime_From_Date.Enabled = true;
                    dateTime_To_Date.Enabled = true;
                }
            }
            catch
            {

            }

        }
    }
}
