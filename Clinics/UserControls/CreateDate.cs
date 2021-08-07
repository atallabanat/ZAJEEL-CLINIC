using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Clinics.UserControls
{
    public partial class CreateDate : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public CreateDate()
        {
            InitializeComponent();
        }
        void RefreshForm()
        {
            try
            {
                txtDebrt.Text = string.Empty;
                txtDoc.Text = string.Empty;
                textBox_ID_visit.Text = GEtMaxID();
                textBox_ID_pat.Text = string.Empty;
                textBox_Name_pat.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_file_save_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO CreateDate
                         (fileId, Date, IDPat, NamePat, NameDr, NameDebrt)
                            VALUES(@fileId, @Date, @IDPat, @NamePat, @NameDr, @NameDebrt)";

                cmd.Parameters.AddWithValue("@fileId", textBox_ID_pat.Text);
                cmd.Parameters.AddWithValue("@Date", dtp_Date.Value);
                cmd.Parameters.AddWithValue("@IDPat", textBox_ID_pat.Text);
                cmd.Parameters.AddWithValue("@NamePat", textBox_Name_pat.Text);
                cmd.Parameters.AddWithValue("@NameDr", txtDoc.Text);
                cmd.Parameters.AddWithValue("@NameDebrt", txtDebrt.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("تم إنشاء موعد بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshForm();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void CreateDate_Load(object sender, EventArgs e)
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


                textBox_ID_visit.Text = GEtMaxID();


            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        string GEtMaxID()
        {
            try
            {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select isnull(max(ID+1),1) as ID from CreateDate ", con);
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();
                if (dr.Read())
                {

                    string ID = (string)dr["ID"].ToString();
                    dr.Close();
                    con.Close();
                    return ID;


                }
                return string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return string.Empty;
            }
        }
        private void textBox_Name_pat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {



                    SqlCommand na = new SqlCommand();
                    na = new SqlCommand("select ID_pat from Table_visit_patient where Name_pat =@Name_pat ", con);
                    na.Parameters.Add(new SqlParameter("@Name_pat", "" + textBox_Name_pat.Text.Trim() + ""));
                    con.Open();
                    na.ExecuteNonQuery();
                    SqlDataReader dr;

                    dr = na.ExecuteReader();
                    while (dr.Read())
                    {

                        string ID_pat = (string)dr["ID_pat"].ToString();
                        textBox_ID_pat.Text = ID_pat;

                    }
                    dr.Close();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show(ee.Message);

            }
        }
    }
}
