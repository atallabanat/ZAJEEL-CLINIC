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
    public partial class End_ALL : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public End_ALL()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
        void Cash()
        {
            try
            { 
            count2 = 0;
            sum2 = 0;

            SqlCommand cmd = new SqlCommand("select Total_Cash from Invoice where Date between @Date1 and @Date2 and Account='' ", con);
            cmd.Parameters.Add("@Date1", dateTimePicker1.Text);
            cmd.Parameters.Add("@Date2", dateTimePicker2.Text);

            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Total_Cash"].ToString() != "")
                {
                    count2 = Convert.ToDouble(dr["Total_Cash"].ToString());
                    sum2 += count2;
                }
            }
            dr.Close();
            con.Close();
            textBox3.Text = sum2.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 End_ALL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        void Credit()
        {
            try
            { 
            count3 = 0;
            sum3 = 0;

            SqlCommand cmd = new SqlCommand("select Total_Cash from Invoice where Date between @Date1 and @Date2 and Account='Credit' ", con);
            cmd.Parameters.Add("@Date1", dateTimePicker1.Text);
            cmd.Parameters.Add("@Date2", dateTimePicker2.Text);

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
            textBox4.Text = sum3.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 End_ALL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        void OnAccount()
        {
            try
            { 
            count4 = 0;
            sum4 = 0;

            SqlCommand cmd = new SqlCommand("select Total_Cash from Invoice where Date between @Date1 and @Date2 and Account='ONAccount' ", con);
            cmd.Parameters.Add("@Date1", dateTimePicker1.Text);
            cmd.Parameters.Add("@Date2", dateTimePicker2.Text);

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
            textBox2.Text = sum4.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 End_ALL", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 End_ALL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            sum = 0;
            count = 0;

            SqlCommand cmd = new SqlCommand("select Total_OnAccount from Invoice where Date between @Date1 and @Date2 ", con);
            cmd.Parameters.Add("@Date1", dateTimePicker1.Text);
            cmd.Parameters.Add("@Date2", dateTimePicker2.Text);

            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Total_OnAccount"].ToString() != "")
                {
                    count = Convert.ToDouble(dr["Total_OnAccount"].ToString());
                    sum += count;
                }
            }
            dr.Close();
            con.Close();

            textBox5.Text = sum.ToString();
            Cash();
            Credit();
            OnAccount();
            SubTotal();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 End_ALL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
