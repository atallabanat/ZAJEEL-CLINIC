using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Clinics.UserControls
{
    public partial class quary_insurance : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public quary_insurance()
        {
            InitializeComponent();
        }

        private void quary_insurance_Load(object sender, EventArgs e)
        {

        }

        private void textBox_number_KeyUp(object sender, KeyEventArgs e)
        {
            try
            { 
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Name_pat,number_Measures,presnt_Measures,presnt_MM,presnt_Doc,Name_Measures from Table_PAT where number_Measures like'%" + textBox_number.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 quary_insurance", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
