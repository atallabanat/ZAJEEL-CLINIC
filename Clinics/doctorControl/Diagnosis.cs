using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Clinics.report;

namespace Clinics.UserControls
{
    public partial class Diagnosis : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static string ss;
        public static Diagnosis Diagnosis1;
        public Diagnosis()
        {
            Diagnosis1 = this;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Analyzes fm = new Analyzes();
            fm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Measures fm = new Measures();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recipe fm = new recipe();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            x_ray fm = new x_ray();
            fm.Show();
        }

        private void Diagnosis_Load(object sender, EventArgs e)
        {
            try
            { 
            textBox_ID_visit.Text = startHome_Doctor.tt;

            ss = textBox_ID_visit.Text;

            SqlCommand na = new SqlCommand();
            na = new SqlCommand("select ID_visit,date_visit,ID_pat,Name_pat,Reason,Chronic,Diagnosis,heat,Pressure,weight,heart,Notes,Attention,complaint from Table_visit_patient where  ID_visit =  '" + textBox_ID_visit.Text.Trim() + "' ", con);
            con.Open();
            na.ExecuteNonQuery();
            SqlDataReader dr;

            dr = na.ExecuteReader();
            while (dr.Read())
            {

                string date_visit = (string)dr["date_visit"].ToString();
                textBox_date_visit.Text = date_visit;

                string ID_pat = (string)dr["ID_pat"].ToString();
                textBox_ID_pat.Text = ID_pat;


                string Name_pat = (string)dr["Name_pat"].ToString();
                textBox_Name_pat.Text = Name_pat;

                string Reason = (string)dr["Reason"].ToString();
                textBox_Reason.Text = Reason;

                string Chronic = (string)dr["Chronic"].ToString();
                textBox4.Text = Chronic;

                string Diagnosis = (string)dr["Diagnosis"].ToString();
                textBox_Diagnosis.Text = Diagnosis;

                string Pressure = (string)dr["Pressure"].ToString();
                textBox_Pressure.Text = Pressure;

                string weight = (string)dr["weight"].ToString();
                textBox_weight.Text = weight;

                string heat = (string)dr["heat"].ToString();
                textBox_heat.Text = heat;

                string heart = (string)dr["heart"].ToString();
                textBox_heart.Text = heart;

                string Notes = (string)dr["Notes"].ToString();
                textBox_Notes.Text = Notes;

                string Attention = (string)dr["Attention"].ToString();
                textBox_Attention.Text = Attention;

                string complaint = (string)dr["complaint"].ToString();
                textBox_complaint.Text = complaint;


            }
            dr.Close();
            con.Close();

                if (textBox_ID_pat.Text != "")
                {
                    //-----------------------------------------------------------------------------------------------------
                    SqlCommand cmd22 = new SqlCommand("select end_Date from Table_PAT where ID_pat=@ID_pat", con);
                    cmd22.Parameters.Add(new SqlParameter("@ID_pat", textBox_ID_pat.Text));
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Diagnosis", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            { 
            if (textBox_ID_visit.Text == "")
            {
                MessageBox.Show("يرجى تحديد رقم الزيارة للحفظ", "عملية غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {






                SqlCommand cmd = new SqlCommand("update Table_visit_patient set  Reason=@Reason,Chronic=@Chronic,Diagnosis=@Diagnosis,heat=@heat,Pressure=@Pressure,weight=@weight,heart=@heart,Notes=@Notes,Attention=@Attention,complaint=@complaint  where ID_visit='" + textBox_ID_visit.Text + "'", con);



                cmd.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar)).Value = textBox_Reason.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@Chronic", SqlDbType.NVarChar)).Value = textBox4.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.NVarChar)).Value = textBox_Diagnosis.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@heat", SqlDbType.NVarChar)).Value = textBox_heat.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@Pressure", SqlDbType.NVarChar)).Value = textBox_Pressure.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@weight", SqlDbType.NVarChar)).Value = textBox_weight.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@heart", SqlDbType.NVarChar)).Value = textBox_heart.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@Notes", SqlDbType.NVarChar)).Value = textBox_Notes.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@Attention", SqlDbType.NVarChar)).Value = textBox_Attention.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@complaint", SqlDbType.NVarChar)).Value = textBox_complaint.Text.Trim();

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم تشخيص حالة المريض بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                startHome_Doctor.DOCStatr.toolStripMenuItem4_Click(sender, e);
                
                



            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Diagnosis", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_ID_visit_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBox_ID_visit.Text == "")
                {
                    textBox_date_visit.Text = "";
                    textBox_ID_pat.Text = "";
                    textBox_Name_pat.Text = "";
                    textBox_Notes.Text = "";
                    textBox_Pressure.Text = "";
                    textBox_Reason.Text = "";
                    textBox_weight.Text = "";
                    textBox_heat.Text = "";
                    textBox_heart.Text = "";
                    textBox_Diagnosis.Text = "";
                    textBox_Attention.Text = "";
                    textBox4.Text = "";

                }
                else
                {
                    SqlCommand na = new SqlCommand();
                    na = new SqlCommand("select ID_visit,date_visit,ID_pat,Name_pat,Reason,Chronic,Diagnosis,heat,Pressure,weight,heart,Notes,Attention,complaint from Table_visit_patient where  ID_visit =  '" + textBox_ID_visit.Text.Trim() + "' ", con);
                    con.Open();
                    na.ExecuteNonQuery();
                    SqlDataReader dr;

                    dr = na.ExecuteReader();
                    while (dr.Read())
                    {

                        string date_visit = (string)dr["date_visit"].ToString();
                        textBox_date_visit.Text = date_visit;

                        string ID_pat = (string)dr["ID_pat"].ToString();
                        textBox_ID_pat.Text = ID_pat;


                        string Name_pat = (string)dr["Name_pat"].ToString();
                        textBox_Name_pat.Text = Name_pat;

                        string Reason = (string)dr["Reason"].ToString();
                        textBox_Reason.Text = Reason;

                        string Chronic = (string)dr["Chronic"].ToString();
                        textBox4.Text = Chronic;

                        string Diagnosis = (string)dr["Diagnosis"].ToString();
                        textBox_Diagnosis.Text = Diagnosis;

                        string Pressure = (string)dr["Pressure"].ToString();
                        textBox_Pressure.Text = Pressure;

                        string weight = (string)dr["weight"].ToString();
                        textBox_weight.Text = weight;

                        string heat = (string)dr["heat"].ToString();
                        textBox_heat.Text = heat;

                        string heart = (string)dr["heart"].ToString();
                        textBox_heart.Text = heart;

                        string Notes = (string)dr["Notes"].ToString();
                        textBox_Notes.Text = Notes;

                        string Attention = (string)dr["Attention"].ToString();
                        textBox_Attention.Text = Attention;

                        string complaint = (string)dr["complaint"].ToString();
                        textBox_complaint.Text = complaint;


                    }
                    dr.Close();
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Diagnosis", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            report_Diagnosis ss = new report_Diagnosis();
            ss.Show();
        }
    }
}
