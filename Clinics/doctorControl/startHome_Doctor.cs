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
    public partial class startHome_Doctor : UserControl
    {

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static string tt;
        public static startHome_Doctor  DOCStatr;
        public startHome_Doctor()
        {
            DOCStatr = this;
            InitializeComponent();
        }

        private void startHome_Doctor_Load(object sender, EventArgs e)
        {
            try
            { 
            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "dboselect_PAT";
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;



            SqlCommand cmd4 = con.CreateCommand();

            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "select count(Name_pat) from Table_PAT where age_pat is not null";
            con.Open();
            
                Int32 rows_count2 = Convert.ToInt32(cmd4.ExecuteScalar());
                label2.Text = rows_count2.ToString() + "";
                
            con.Close();


            SqlCommand cmd5 = con.CreateCommand();

            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "select count(ID_visit) from Table_visit_patient where isnull(end_Paid,0) <> 1    and isnull(end_ee,0) <> 1 and date_visit is not null";
            con.Open();
            
                Int32 rows_count22 = Convert.ToInt32(cmd5.ExecuteScalar());
                label32.Text = rows_count22.ToString() + "";

            
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 start_Dr", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                }
                else
                {

                    list_pat_dactor.Show(dataGridView1, new Point(e.X, e.Y));
                    textBox1.Text = dataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
                    tt = textBox1.Text;
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 start_Dr", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //--------------------------الصفحات المتنقلة ------------------------//
        private void addControlsTopanel(Control c)
        {

            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);

        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Diagnosis ssa = new Diagnosis();
            addControlsTopanel(ssa);
        }

        public void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Table_visit_patient set end_ee=1 where ID_visit=" + textBox1.Text + " ";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "dboselect_PAT";
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;



            SqlCommand cmd4 = con.CreateCommand();

            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "select count(Name_pat) from Table_PAT where age_pat is not null";
            con.Open();
            
                Int32 rows_count2 = Convert.ToInt32(cmd4.ExecuteScalar());
                label2.Text = rows_count2.ToString() + "";

            
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 start_Dr", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_refreash_Click(object sender, EventArgs e)
        {
            try
            { 

            SqlCommand cmd4 = con.CreateCommand();

            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "select count(Name_pat) from Table_PAT where age_pat is not null";
            con.Open();
           
                Int32 rows_count2 = Convert.ToInt32(cmd4.ExecuteScalar());
                label2.Text = rows_count2.ToString() + "";

            
            con.Close();


            SqlCommand cmd5 = con.CreateCommand();

            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "select count(ID_visit) from Table_visit_patient where isnull(end_Paid,0) <> 1    and isnull(end_ee,0) <> 1 and date_visit is not null";
            con.Open();
            
                Int32 rows_count22 = Convert.ToInt32(cmd5.ExecuteScalar());
                label32.Text = rows_count22.ToString() + "";

           
            con.Close();

            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "dboselect_PAT";
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 start_Dr", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
