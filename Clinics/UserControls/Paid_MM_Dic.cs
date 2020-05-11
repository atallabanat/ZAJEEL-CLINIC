using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinics.UserControls
{
    public partial class Paid_MM_Dic : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public Paid_MM_Dic()
        {
            InitializeComponent();
        }

        private void Paid_MM_Dic_Load(object sender, EventArgs e)
        {
            try
            { 
            textBox2.Text = Paid_MM.pa.textBox2.Text;
            textBox1.Text = Paid_MM.pa.textBox1.Text;
            this.KeyPreview = true;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 paid_MM_Dic", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 paid_MM_Dic", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 paid_MM_Dic", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        double total =Convert.ToDouble( Paid_MM.pa.textBox2.Text);
        double JD = 0;
        double dic = 0;
        public void swa()
        {
            try
            {
                double total = Convert.ToDouble(Paid_MM.pa.textBox2.Text);
                if (textBox4.Text == "")
                {
                    JD = 0;
                }
                else
                {
                    JD = Convert.ToDouble(textBox4.Text);
                }
                if (textBox3.Text == "")
                {
                    dic = 0;
                }
                else
                {
                    dic = (Convert.ToDouble(textBox3.Text) / 100) * total;
                }

                double totalAmount = 0;
                totalAmount = total - JD - dic;
                textBox2.Text = totalAmount.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 paid_MM_Dic", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            { 
            if (textBox4.Text == "")
            {
                textBox2.Text = total.ToString();
            }
            else
            {
                swa();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 paid_MM_Dic", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            { 
            if (textBox3.Text == "")
            {
                textBox2.Text = total.ToString();
            }
            else
            {
                swa();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 paid_MM_Dic", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Paid_MM_Dic_KeyDown(object sender, KeyEventArgs e)
        {
      
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                

            }

        }

        private void btn_file_save_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlCommand cmd = new SqlCommand("update Table_visit_patient set  paidAmount=@paidAmount ,end_Paid=1,SentToDoc=0  where ID_visit='" + textBox1.Text + "'", con);



            cmd.Parameters.Add(new SqlParameter("@paidAmount", textBox2.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("تمت عملية الدفع بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            startHome.start_home.btn_file_save_Click(sender, e);
            Paid_MM.pa.Close();
            this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 paid_MM_Dic", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
