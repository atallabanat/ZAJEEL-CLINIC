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
    public partial class select_Visit : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public select_Visit()
        {
            InitializeComponent();
        }

        private void select_Visit_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = quary_visitpatient.qak.textBox_Name_pat.Text;
                con.Open();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select ID_visit,date_visit,ID_pat,Name_pat,Reason from Table_visit_patient where Name_pat=@Name_pat and date_visit is not NULL";
                    Cmd.Parameters.Add(new SqlParameter("@Name_pat", textBox1.Text.Trim()));
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 select_Visit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                quary_visitpatient.qak.textBox_ID_visit.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 select_Visit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
