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

namespace Clinics.UserControls
{
    public partial class visitpatient : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        SqlDataAdapter Da;
        DataTable Dt = new DataTable();
        public visitpatient()
        {
            InitializeComponent();
            try
            { 

            Da = new SqlDataAdapter("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + "", con);
            Da.Fill(Dt);


            if (Dt.Rows[4][0].ToString() == "False" || Dt.Rows[4][0].ToString() == string.Empty)
                groupBox4.Enabled = false;


            if (Dt.Rows[5][0].ToString() == "False" || Dt.Rows[5][0].ToString() == string.Empty)
                textBox_ID_visit.Enabled = false;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void visitpatient_Load(object sender, EventArgs e)
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

            textBox_date_visit.Format = DateTimePickerFormat.Custom;
            textBox_date_visit.CustomFormat = "yyyy/MM/dd";

            SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_visit)+1,1) from Table_visit_patient", con);
            con.Open();
            SqlDataReader Ra = cmd2.ExecuteReader();

            Ra.Read();
            textBox_ID_visit.Text = Ra[0].ToString();
            Ra.Close();
            con.Close();
        }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
}

        private void btn_file_save_Click(object sender, EventArgs e)
        {
            if (textBox_ID_visit.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل (رقم الزيارة) فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox_date_visit.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل (تاريخ الزيارة) فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox_ID_pat.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل (الرقم الوطني) فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox_Name_pat.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل (اسم المريض) فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                try
                {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dboadd_vist";

                    cmd.Parameters.Add(new SqlParameter("@ID_visit", textBox_ID_visit.Text.Trim()));
                    cmd.Parameters.Add("@date_visit", SqlDbType.NVarChar).Value = textBox_date_visit.Text.Trim();
                    cmd.Parameters.Add("@ID_pat", SqlDbType.NVarChar).Value = textBox_ID_pat.Text.Trim();
                    cmd.Parameters.Add("@Name_pat", SqlDbType.NVarChar).Value = textBox_Name_pat.Text.Trim();
                    cmd.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = textBox_Reason.Text.Trim();
                    cmd.Parameters.Add("@Chronic", SqlDbType.NVarChar).Value = textBox4.Text.Trim();
                    cmd.Parameters.Add("@Diagnosis", SqlDbType.NVarChar).Value = textBox_Diagnosis.Text.Trim();
                    cmd.Parameters.Add("@heat", SqlDbType.NVarChar).Value = textBox_heat.Text.Trim();
                    cmd.Parameters.Add("@Pressure", SqlDbType.NVarChar).Value = textBox_Pressure.Text.Trim();
                    cmd.Parameters.Add("@weight", SqlDbType.NVarChar).Value = textBox_weight.Text.Trim();
                    cmd.Parameters.Add("@heart", SqlDbType.NVarChar).Value = textBox_heart.Text.Trim();
                    cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = textBox_Notes.Text.Trim();
                    cmd.Parameters.Add("@Attention", SqlDbType.NVarChar).Value = textBox_Attention.Text.Trim();
                    cmd.Parameters.Add("@add_name", SqlDbType.NVarChar).Value = Form1.Recby;

                    var home = new home();
                    //cmd.Parameters.Add("@date", SqlDbType.NChar).Value = home.current;




                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("تم إنشاء ملف زيارة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    textBox_ID_visit.Text = "";
                    textBox_date_visit.Text = "";
                    textBox_ID_pat.Text = "";
                    textBox_Name_pat.Text = "";
                    textBox_Reason.Text = "";
                    textBox4.Text = "";
                    textBox_Diagnosis.Text = "";
                    textBox_heat.Text = "";
                    textBox_Pressure.Text = "";
                    textBox_weight.Text = "";
                    textBox_heart.Text = "";
                    textBox_Notes.Text = "";
                    textBox_Attention.Text = "";



                    SqlCommand cmd3 = new SqlCommand("select ISNULL (MAX (ID_visit)+1,1) from Table_visit_patient", con);
                    con.Open();
                    SqlDataReader Ra3 = cmd3.ExecuteReader();

                    Ra3.Read();
                    textBox_ID_visit.Text = Ra3[0].ToString();
                    Ra3.Close();
                    con.Close();
                }
                catch (Exception ee)
                {
                    con.Close();
                    MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

        private void textBox_ID_pat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBox_Name_pat.Text == "")
                {
                    if (textBox_ID_pat.Text == "")
                    {
                        textBox_Name_pat.Text = "";
                        textBox4.Text = "";
                        textBox_Attention.Text = "";

                    }
                    else
                    {
                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Name_pat,Chronic,Attention from Table_visit_patient where  ID_pat =  '" + textBox_ID_pat.Text.Trim() + "' ", con);
                        con.Open();

                        SqlDataReader dr;

                        dr = na.ExecuteReader();
                        while (dr.Read())
                        {



                            string Chronic = (string)dr["Chronic"].ToString();
                            textBox4.Text = Chronic;


                            string Attention = (string)dr["Attention"].ToString();
                            textBox_Attention.Text = Attention;

                            string Name_pat = (string)dr["Name_pat"].ToString();
                            textBox_Name_pat.Text = Name_pat;


                        }
                        dr.Close();
                        con.Close();


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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Name_pat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
            {



                    SqlCommand na = new SqlCommand();
                na = new SqlCommand("select ID_pat,Chronic,Attention from Table_visit_patient where Name_pat =@Name_pat ", con);
                na.Parameters.Add(new SqlParameter("@Name_pat", "" + textBox_Name_pat.Text.Trim() + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();
                while (dr.Read())
                {

                    string ID_pat = (string)dr["ID_pat"].ToString();
                    textBox_ID_pat.Text = ID_pat;

                    string Chronic = (string)dr["Chronic"].ToString();
                    textBox4.Text = Chronic;


                    string Attention = (string)dr["Attention"].ToString();
                    textBox_Attention.Text = Attention;




                }
                dr.Close();
                con.Close();

                    //-----------------------------------------------------------------------------------------------------
                    SqlCommand cmd22 = new SqlCommand("select end_Date from Table_PAT where ID_pat=@ID_pat", con);
                    cmd22.Parameters.Add(new SqlParameter("@ID_pat", textBox_ID_pat.Text));
                    con.Open();
                    SqlDataReader Ra2 = cmd22.ExecuteReader();

                    Ra2.Read();
                    DateTime d1 = DateTime.Now;
                    DateTime d2 =Convert.ToDateTime( Ra2["end_Date"].ToString().Trim());
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
}

        private void textBox_ID_pat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
