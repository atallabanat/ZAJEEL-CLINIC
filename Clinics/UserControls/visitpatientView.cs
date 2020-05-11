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
    public partial class visitpatientView : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        SqlDataAdapter Da;
        DataTable Dt = new DataTable();
        public visitpatientView()
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 visitpatientView", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void visitpatientView_Load(object sender, EventArgs e)
        {
            try
            { 
            textBox_ID_visit.Text = startHome.tt;

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


                string heat = (string)dr["heat"].ToString();
                textBox_heat.Text = heat;

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
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 visitpatientView", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_file_save_Click(object sender, EventArgs e)
        {
            startHome ssa = new startHome();
            addControlsTopanel(ssa);
        }
        //--------------------------الصفحات المتنقلة ------------------------//
        private void addControlsTopanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);

        }
        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
