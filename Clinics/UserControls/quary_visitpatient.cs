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
using Clinics.Update_Quary;

namespace Clinics.UserControls
{
    public partial class quary_visitpatient : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        SqlDataAdapter Da;
        DataTable Dt = new DataTable();
        public static quary_visitpatient qak;
        public quary_visitpatient()
        {
            qak = this;
            InitializeComponent();
            try
            { 
            Da = new SqlDataAdapter("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + "", con);
            Da.Fill(Dt);



            if (Dt.Rows[4][0].ToString() == "False" || Dt.Rows[4][0].ToString() == string.Empty)
                groupBox4.Enabled = false;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 quary_visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dt.Rows[8][0].ToString() == "False" || Dt.Rows[8][0].ToString() == string.Empty)
                {
                    MessageBox.Show("عذرا لايوجد لديك صلاحية التعديل", "تعديل ملف", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (textBox_ID_visit.Text == "")
                {
                    MessageBox.Show("يرجى تحديد رقم الزيارة للتعديل", "عملية غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                   





                    SqlCommand cmd = new SqlCommand("update Table_visit_patient set  Reason=@Reason,Chronic=@Chronic,Diagnosis=@Diagnosis,heat=@heat,Pressure=@Pressure,weight=@weight,heart=@heart,Notes=@Notes,Attention=@Attention  where ID_visit='" + textBox_ID_visit.Text + "'", con);



                    cmd.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar)).Value = textBox_Reason.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Chronic", SqlDbType.NVarChar)).Value = textBox4.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.NVarChar)).Value = textBox_Diagnosis.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@heat", SqlDbType.NVarChar)).Value = textBox_heat.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Pressure", SqlDbType.NVarChar)).Value = textBox_Pressure.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@weight", SqlDbType.NVarChar)).Value = textBox_weight.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@heart", SqlDbType.NVarChar)).Value = textBox_heart.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Notes", SqlDbType.NVarChar)).Value = textBox_Notes.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Attention", SqlDbType.NVarChar)).Value = textBox_Attention.Text.Trim();

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم تعديل بيانات المريض بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);






                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 quary_visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dt.Rows[9][0].ToString() == "False" || Dt.Rows[9][0].ToString() == string.Empty)
                {
                    MessageBox.Show("عذرا لايوجد لديك صلاحية الحذف", "حذف ملف", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (textBox_ID_visit.Text=="")
                {
                    MessageBox.Show("يرجى تحديد رقم الزيارة قبل الحذف", "عملية غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {


                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from Table_visit_patient where ID_visit='" + textBox_ID_visit.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox_ID_visit.Text = "";
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

                    MessageBox.Show("تم حذف ملف الزيارة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 quary_visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_ID_visit_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 quary_visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_ID_pat_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 quary_visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            report_visitpatient ss = new report_visitpatient();
            ss.Show();
        }

        private void textBox_Name_pat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    select_Visit ss = new select_Visit();
                    ss.Show();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 quary_visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void quary_visitpatient_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd33;
                SqlDataReader dr33;
                cmd33 = new SqlCommand("select Name_pat from Table_visit_patient", con);
                cmd33.ExecuteNonQuery();
                dr33 = cmd33.ExecuteReader();
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                while (dr33.Read())
                {
                    col.Add(dr33.GetString(0));

                }
                textBox_Name_pat.AutoCompleteCustomSource = col;
                dr33.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1009 quary_visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_ID_visit_TextChanged(object sender, EventArgs e)
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
                    na = new SqlCommand("select ID_visit,date_visit,ID_pat,Name_pat,Reason,Chronic,Diagnosis,heat,Pressure,weight,heart,Notes,Attention from Table_visit_patient where  ID_visit =  '" + textBox_ID_visit.Text.Trim() + "' ", con);
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
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 quary_visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox_ID_visit.Text=="")
            {
                MessageBox.Show("يرجى تحديد رقم الزيارة او اسم المريض لدخول الى الاجراءات الطبية", "عذرا", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                Measures1 ss = new Measures1();
                ss.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox_ID_visit.Text == "")
            {
                MessageBox.Show("يرجى تحديد رقم الزيارة او اسم المريض لدخول الى الأشعة", "عذرا", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                x_Ray1 ss = new x_Ray1();
                ss.Show();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox_ID_visit.Text == "")
            {
                MessageBox.Show("يرجى تحديد رقم الزيارة او اسم المريض لدخول الى التحاليل الطبية", "عذرا", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                Analyzes1 ss = new Analyzes1();
                ss.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox_ID_visit.Text == "")
            {
                MessageBox.Show("يرجى تحديد رقم الزيارة او اسم المريض لدخول الى الوصفة الطبية", "عذرا", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                recipe1 ss = new recipe1();
                ss.Show();
            }
        }
    }
}
