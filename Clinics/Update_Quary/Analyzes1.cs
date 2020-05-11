using Clinics.UserControls;
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

namespace Clinics.Update_Quary
{
    public partial class Analyzes1 : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public Analyzes1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("update Table_visit_patient set analyze=@analyze where ID_visit=" + textBox1.Text.Trim() + "", con);

                cmd.Parameters.Add(new SqlParameter("@analyze", SqlDbType.NVarChar)).Value = textBox_analyze.Text;








                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



                MessageBox.Show("تم إضافة بيانات التحاليل بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Analyzes1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Analyzes1_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = quary_visitpatient.qak.textBox_ID_visit.Text;
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select analyze from Table_visit_patient where  ID_visit =  '" + textBox1.Text + "' ", con);
                con.Open();
                SqlDataReader dr;

                dr = na.ExecuteReader();
                while (dr.Read())
                {

                    string analyze = dr["analyze"].ToString();
                    textBox_analyze.Text = analyze;


                }
                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Analyzes1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
