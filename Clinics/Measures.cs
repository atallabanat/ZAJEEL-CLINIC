using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Clinics.UserControls;
using Clinics.report;

namespace Clinics
{
    public partial class Measures : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static Measures mm;

        public Measures()
        {
            mm = this;
            InitializeComponent();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Measures_Load(object sender, EventArgs e)
        {
            try
            { 
            text_Name_Measures1.Focus();
            textBox1.Text = Diagnosis.ss;







            SqlCommand na = new SqlCommand();
            na = new SqlCommand("select Name_Measures1,Price_Measures1,Name_Measures2,Price_Measures2,Name_Measures3,Price_Measures3,Name_Measures4,Price_Measures4,Name_MeasuresOther,Price_MeasuresOther from Table_visit_patient where  ID_visit =  '" + textBox1.Text + "' ", con);
            con.Open();
            SqlDataReader dr;

            dr = na.ExecuteReader();
            while (dr.Read())
            {

                string Name_Measures1 = dr["Name_Measures1"].ToString();
                text_Name_Measures1.Text = Name_Measures1;

                string Name_Measures2 = dr["Name_Measures2"].ToString();
                text_Name_Measures2.Text = Name_Measures2;

                string Name_Measures3 = dr["Name_Measures3"].ToString();
                text_Name_Measures3.Text = Name_Measures3;

                string Name_Measures4 = dr["Name_Measures4"].ToString();
                text_Name_Measures4.Text = Name_Measures4;

                string Name_MeasuresOther = dr["Name_MeasuresOther"].ToString();
                textBox_Name_MeasuresOther.Text = Name_MeasuresOther;


                string Price_Measures1 = dr["Price_Measures1"].ToString();
                t1.Text = Price_Measures1;

                string Price_Measures2 = dr["Price_Measures2"].ToString();
                t2.Text = Price_Measures2;


                string Price_Measures3 = dr["Price_Measures3"].ToString();
                t3.Text = Price_Measures3;

                string Price_Measures4 = dr["Price_Measures4"].ToString();
                t4.Text = Price_Measures4;



                string Price_MeasuresOther = dr["Price_MeasuresOther"].ToString();
                text_price_Other.Text = Price_MeasuresOther;
            }
            dr.Close();
            con.Close();







            //-------------------------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                    SqlCommand cmd = new SqlCommand("update Table_visit_patient set Name_Measures1=@Name_Measures1,Price_Measures1=@Price_Measures1,Name_Measures2=@Name_Measures2,Price_Measures2=@Price_Measures2,Name_Measures3=@Name_Measures3,Price_Measures3=@Price_Measures3,Name_Measures4=@Name_Measures4,Price_Measures4=@Price_Measures4,Name_MeasuresOther=@Name_MeasuresOther,Price_MeasuresOther=@Price_MeasuresOther where ID_visit=" + textBox1.Text.Trim() + "", con);

                    cmd.Parameters.Add(new SqlParameter("@Name_Measures1", text_Name_Measures1.Text));
                cmd.Parameters.Add(new SqlParameter("@Price_Measures1", t1.Text.Trim()));

                cmd.Parameters.Add(new SqlParameter("@Name_Measures2", text_Name_Measures2.Text));
                cmd.Parameters.Add(new SqlParameter("@Price_Measures2", t2.Text.Trim()));

                cmd.Parameters.Add(new SqlParameter("@Name_Measures3", text_Name_Measures3.Text));
                cmd.Parameters.Add(new SqlParameter("@Price_Measures3", t3.Text.Trim()));

                cmd.Parameters.Add(new SqlParameter("@Name_Measures4", text_Name_Measures4.Text));
                cmd.Parameters.Add(new SqlParameter("@Price_Measures4", t4.Text.Trim()));

                cmd.Parameters.Add(new SqlParameter("@Name_MeasuresOther", textBox_Name_MeasuresOther.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@Price_MeasuresOther", text_price_Other.Text.Trim()));





                con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                    MessageBox.Show("تم تعديل بيانات الاجراء بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void text_price_Other_KeyPress(object sender, KeyPressEventArgs e)
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
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void textBox_Name_MeasuresOther_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Enter)
            {
                text_price_Other.Focus();
            }
        }

        private void text_price_Other_KeyDown(object sender, KeyEventArgs e)
        {
            try
            { 
            if (e.KeyData == Keys.Enter)
            {
                button2_Click(sender, e);
            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
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
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void t2_KeyPress(object sender, KeyPressEventArgs e)
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
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void t3_KeyPress(object sender, KeyPressEventArgs e)
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
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void t4_KeyPress(object sender, KeyPressEventArgs e)
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
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            report_measures ss =new  report_measures();
            ss.Show();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            try
            {
                //------------ قائمة الاجراءات ---------------------------//
                DataTable Dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter("select * from add_Measures", con);
                Da.Fill(Dt);
                text_Name_Measures1.DataSource = Dt;
                text_Name_Measures1.DisplayMember = "Name_Measures";
                text_Name_Measures1.ValueMember = "Name_Measures";
                text_Name_Measures1.SelectedIndex = -1;



                //------------ قائمة الاجراءات ---------------------------//
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1009 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            try
            {
                //------------ قائمة الاجراءات ---------------------------//
                DataTable Dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter("select * from add_Measures", con);
                Da.Fill(Dt);
                text_Name_Measures2.DataSource = Dt;
                text_Name_Measures2.DisplayMember = "Name_Measures";
                text_Name_Measures2.ValueMember = "Name_Measures";
                text_Name_Measures2.SelectedIndex = -1;



                //------------ قائمة الاجراءات ---------------------------//
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1014 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            try
            {
                //------------ قائمة الاجراءات ---------------------------//
                DataTable Dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter("select * from add_Measures", con);
                Da.Fill(Dt);
                text_Name_Measures3.DataSource = Dt;
                text_Name_Measures3.DisplayMember = "Name_Measures";
                text_Name_Measures3.ValueMember = "Name_Measures";
                text_Name_Measures3.SelectedIndex = -1;



                //------------ قائمة الاجراءات ---------------------------//
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1015 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            try
            {
                //------------ قائمة الاجراءات ---------------------------//
                DataTable Dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter("select * from add_Measures", con);
                Da.Fill(Dt);
                text_Name_Measures4.DataSource = Dt;
                text_Name_Measures4.DisplayMember = "Name_Measures";
                text_Name_Measures4.ValueMember = "Name_Measures";
                text_Name_Measures4.SelectedIndex = -1;



                //------------ قائمة الاجراءات ---------------------------//
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1016 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void text_Name_Measures1_Leave(object sender, EventArgs e)
        {
            try
            {

                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Name_Measures,Price_Measures from add_Measures where  Name_Measures =@Name_Measures ", con);
                na.Parameters.Add(new SqlParameter("@Name_Measures", text_Name_Measures1.Text));

                con.Open();
                SqlDataReader dr;

                dr = na.ExecuteReader();
                while (dr.Read())
                {

                    string Price_Measures = dr["Price_Measures"].ToString();
                    t1.Text = Price_Measures;




                }
                dr.Close();
                con.Close();

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1010 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_Name_Measures2_Leave(object sender, EventArgs e)
        {
            try
            {

                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Name_Measures,Price_Measures from add_Measures where  Name_Measures =@Name_Measures ", con);
                na.Parameters.Add(new SqlParameter("@Name_Measures", text_Name_Measures2.Text));

                con.Open();
                SqlDataReader dr;

                dr = na.ExecuteReader();
                while (dr.Read())
                {

                    string Price_Measures2 = dr["Price_Measures"].ToString();
                    t2.Text = Price_Measures2;




                }
                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1011 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void text_Name_Measures3_Leave(object sender, EventArgs e)
        {
            try
            {

                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Name_Measures,Price_Measures from add_Measures where  Name_Measures =@Name_Measures ", con);
                na.Parameters.Add(new SqlParameter("@Name_Measures", text_Name_Measures3.Text));

                con.Open();
                SqlDataReader dr;

                dr = na.ExecuteReader();
                while (dr.Read())
                {

                    string Price_Measures3 = dr["Price_Measures"].ToString();
                    t3.Text = Price_Measures3;




                }
                dr.Close();
                con.Close();

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1012 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_Name_Measures4_Leave(object sender, EventArgs e)
        {
            try
            {

                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Name_Measures,Price_Measures from add_Measures where  Name_Measures =@Name_Measures ", con);
                na.Parameters.Add(new SqlParameter("@Name_Measures", text_Name_Measures4.Text));

                con.Open();
                SqlDataReader dr;

                dr = na.ExecuteReader();
                while (dr.Read())
                {

                    string Price_Measures4 = dr["Price_Measures"].ToString();
                    t4.Text = Price_Measures4;




                }
                dr.Close();
                con.Close();

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1013 Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
