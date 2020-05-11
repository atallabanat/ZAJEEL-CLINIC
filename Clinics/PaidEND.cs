using Clinics.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinics
{
    public partial class PaidEND : Form
    {
        public PaidEND()
        {
            InitializeComponent();
        }

        private void PaidEND_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            textBox1.Focus();
            textBox3.Text = POS.pOS.lbl_cc.Text;
            
        }
        private void ten()
        {

            try
            {
                double a = 0;
                double b = 0;
                double t = 0;
                if (textBox1.Text != "" && textBox1.Text != "\r\n")
                {


                    a = Convert.ToDouble(textBox3.Text);
                    b = Convert.ToDouble(textBox1.Text);

                    t = b - a;
                    textBox2.Text = t.ToString();

                }
                else
                {
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 PaidEND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PaidEND_KeyDown(object sender, KeyEventArgs e)
        {
            try
            { 
                if (e.KeyData == Keys.F8)
                {
                    btn_Save_Click(sender, e);
                }
            }
            catch (Exception ee)
            {
                
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 PaidEND", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            { 
                ten();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 PaidEND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {                 
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                {               
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 PaidEND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }

   
}
