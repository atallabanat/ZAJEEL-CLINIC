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
    public partial class Paid_MM : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static Paid_MM pa;
        public Paid_MM()
        {
            pa = this;

            InitializeComponent();
        }
        double total = 0;

        public void sq()
        {
            try
            { 
            if (dataGridView1.Rows.Count <= 1)
            {
                double a = 0;
                double b = 0;
                double c = 0;
                double e = 0;
                double f = 0;
                
                double dicP = 0;
                if (dataGridView1.Rows[0].Cells["s1"].Value == "" || dataGridView1.Rows[0].Cells["s1"].Value == DBNull.Value)
                {
                    a = 0;

                    
                }
            
                else
                {
                    a = Convert.ToDouble(dataGridView1.Rows[0].Cells["s1"].Value);
                }

                if (dataGridView1.Rows[0].Cells["s2"].Value == "" || dataGridView1.Rows[0].Cells["s2"].Value == DBNull.Value)
                {
                    b = 0;
                }
                else
                {
                    b = Convert.ToDouble(dataGridView1.Rows[0].Cells["s2"].Value);
                }
                if (dataGridView1.Rows[0].Cells["s3"].Value == "" || dataGridView1.Rows[0].Cells["s3"].Value == DBNull.Value)
                {
                    c = 0;
                }
                else
                {
                    c = Convert.ToDouble(dataGridView1.Rows[0].Cells["s3"].Value);
                }
                if (dataGridView1.Rows[0].Cells["s4"].Value == "" || dataGridView1.Rows[0].Cells["s4"].Value == DBNull.Value)
                {
                    e = 0;
                }
                else
                {
                    e = Convert.ToDouble(dataGridView1.Rows[0].Cells["s4"].Value);
                }
                if (dataGridView1.Rows[0].Cells["s5"].Value == "" || dataGridView1.Rows[0].Cells["s5"].Value == DBNull.Value)
                {
                    f = 0;
                }
                else
                {
                    f = Convert.ToDouble(dataGridView1.Rows[0].Cells["s5"].Value);
                }



                total = (a + b + c + e + f);
                textBox2.Text = total.ToString();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 paid_MM", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Paid_MM_Load(object sender, EventArgs e)
        {
            try
            {
            textBox1.Text = startHome.tt;
            textBox3.Text=startHome.start_home.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Name_Measures1,Name_Measures2,Name_Measures3,Name_Measures4,Name_MeasuresOther,Price_MeasuresOther,Price_Measures1,Price_Measures2,Price_Measures3,Price_Measures4 from Table_visit_patient where ID_visit=@ID_visit";
            cmd.Parameters.Add(new SqlParameter("@ID_visit", textBox1.Text));
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

            sq();

            con.Open();
            SqlCommand cmd21 = new SqlCommand("select Name_pat,presnt_MM from Table_PAT where ID_pat=@ID_pat", con);
            cmd21.Parameters.Add(new SqlParameter("@ID_pat", textBox3.Text));
            SqlDataReader dr13;
            dr13 = cmd21.ExecuteReader();
            int count = 0;
            while (dr13.Read())
            {
                count += 1;

            }

            con.Close();
            if (count == 1)
            {
                SqlCommand cmd33 = con.CreateCommand();

                cmd33 = new SqlCommand("select Name_pat,presnt_MM from Table_PAT where ID_pat=@ID_pat", con);
                cmd33.Parameters.Add(new SqlParameter("@ID_pat", textBox3.Text));
                con.Open();
                SqlDataReader dr221;

                dr221 = cmd33.ExecuteReader();
                dr221.Read();
                if (dr221["presnt_MM"].ToString() != "")
                {
                    t1.Visible = true;
                    t2.Visible = true;
                    text1.Visible = true;
                    text2.Visible = true;
                    bunifuCustomLabel5.Visible = true;
                    text1.Text = dr221["Name_pat"].ToString();
                    double texet2 =Convert.ToDouble(dr221["presnt_MM"].ToString());
                    text2.Text = texet2.ToString();
                    dr221.Close();
                    con.Close();
                }

                

            }

            else
            {


                t1.Visible = false;
                t2.Visible = false;
                text1.Visible = false;
                text2.Visible = false;
                bunifuCustomLabel5.Visible = true;



            }
            con.Close();
                if (textBox3.Text != "")
                {
                    //-----------------------------------------------------------------------------------------------------
                    SqlCommand cmd22 = new SqlCommand("select end_Date from Table_PAT where ID_pat=@ID_pat", con);
                    cmd22.Parameters.Add(new SqlParameter("@ID_pat", textBox3.Text));
                    con.Open();
                    SqlDataReader Ra2 = cmd22.ExecuteReader();

                    Ra2.Read();
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = Convert.ToDateTime(Ra2["end_Date"].ToString().Trim());
                    TimeSpan t = d1 - d2;
                    double NrOfDays = t.TotalDays;
                    if (NrOfDays > 356)
                    {
                        lbl_EndDate.Visible = true;
                    }
                    else
                    {
                        lbl_EndDate.Visible = false;
                    }

                    Ra2.Close();
                    con.Close();
                    //-------------------------------------------------------------------------------------------------------------
                }


            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 paid_MM", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

}


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //double dicp = 0;
            //if (textBox3.Text == "")
            //{
            //    dicp = 0;
            //}
            //else
            //{
            //    dicp = Convert.ToDouble(textBox3.Text);
            //}
            //total =total-  ((dicp / 100)*total);
            
        }

        private void btn_file_save_Click(object sender, EventArgs e)
        {
            
            Paid_MM_Dic ss = new Paid_MM_Dic();
            ss.Show();
           
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlCommand cmd = new SqlCommand("update Table_visit_patient set  paidAmount=@paidAmount ,end_Paid=1,SentToDoc=0  where ID_visit=@ID_visit", con);
            cmd.Parameters.Add(new SqlParameter("@paidAmount", textBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@ID_visit", textBox1.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("تمت عملية الدفع بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            startHome.start_home.btn_file_save_Click(sender,e);
            this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 paid_MM", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
