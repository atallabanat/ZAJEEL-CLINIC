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

namespace Clinics.pharmacy_Control
{
    public partial class END_Shift : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public END_Shift()
        {
            InitializeComponent();
        }
        double sum = 0;
        double count = 0;

        double sum2 = 0;
        double count2 = 0;

        double sum3 = 0;
        double count3 = 0;

        double sum4 = 0;
        double count4 = 0;

        double Subtotal = 0;

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void END_Shift_Load(object sender, EventArgs e)
        {
            try
            { 
           textBox1.Text= End_user.ee.textBox1.Text;
            textBox8.Text = End_user.ee.textBox2.Text;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 End_Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        void OnAccount()
        {
            try
            { 
            count3 = 0;
            sum3 = 0;
            
            SqlCommand cmd = new SqlCommand("select Total_Cash from Invoice where Date between @Date1 and @Date2 and NameStaff=@NameStaff and Account='ONAccount' ", con);
            cmd.Parameters.Add("@Date1", dateTimePicker1.Text);
            cmd.Parameters.Add("@Date2", dateTimePicker2.Text);
            cmd.Parameters.Add("@NameStaff", textBox1.Text);

            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Total_Cash"].ToString() != "")
                {
                    count3 = Convert.ToDouble(dr["Total_Cash"].ToString());
                    sum3 += count3;
                }
            }
            dr.Close();
            con.Close();
            textBox2.Text = sum3.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 End_Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        void Credit()
        {
            try
            { 
            count4 = 0;
            sum4 = 0;

            SqlCommand cmd = new SqlCommand("select Total_Cash from Invoice where Date between @Date1 and @Date2 and NameStaff=@NameStaff and Account='Credit' ", con);
            cmd.Parameters.Add("@Date1", dateTimePicker1.Text);
            cmd.Parameters.Add("@Date2", dateTimePicker2.Text);
            cmd.Parameters.Add("@NameStaff", textBox1.Text);

            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Total_Cash"].ToString() != "")
                {
                    count4 = Convert.ToDouble(dr["Total_Cash"].ToString());
                    sum4 += count4;
                }
            }
            dr.Close();
            con.Close();
            textBox4.Text = sum4.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 End_Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        void Cash()
        {
            try
            { 
            count = 0;
            sum = 0;

            SqlCommand cmd = new SqlCommand("select Total_Cash from Invoice where Date between @Date1 and @Date2 and NameStaff=@NameStaff and Account='' ", con);
            cmd.Parameters.Add("@Date1", dateTimePicker1.Text);
            cmd.Parameters.Add("@Date2", dateTimePicker2.Text);
            cmd.Parameters.Add("@NameStaff", textBox1.Text);

            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Total_Cash"].ToString() != "")
                {
                    count = Convert.ToDouble(dr["Total_Cash"].ToString());
                    sum += count;
                }
            }
            dr.Close();
            con.Close();
            textBox3.Text = sum.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 End_Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        void SubTotal()
        {
            try
            {
                Subtotal = 0;
                Subtotal = sum + sum2 + sum3 + sum4;
                textBox6.Text = Subtotal.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 End_Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            count = 0;
            sum = 0;
            count2 = 0;
            sum2 = 0;
            SqlCommand cmd = new SqlCommand("select Total_OnAccount from Invoice where Date between @Date1 and @Date2 and NameStaff=@NameStaff ", con);
            cmd.Parameters.Add("@Date1", dateTimePicker1.Text);
            cmd.Parameters.Add("@Date2", dateTimePicker2.Text);
            cmd.Parameters.Add("@NameStaff", textBox1.Text);

            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Total_OnAccount"].ToString() != "")
                {
                    count2 = Convert.ToDouble(dr["Total_OnAccount"].ToString());
                    sum2 += count2;
                }
            }
            dr.Close();
            con.Close();
            textBox5.Text = sum2.ToString();
            Cash();
            OnAccount();
            Credit();
            SubTotal();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 End_Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
