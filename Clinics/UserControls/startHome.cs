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
    public partial class startHome : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static string tt;
        public static startHome start_home;

        public startHome()
        {
            start_home = this;
            InitializeComponent();
        }

        private void startHome_Load(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd4 = con.CreateCommand();

                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "select count(Name_pat) from Table_PAT where age_pat is not null";
                con.Open();
                try
                {
                    Int32 rows_count2 = Convert.ToInt32(cmd4.ExecuteScalar());
                    label2.Text = rows_count2.ToString() + "";

                }
                catch (Exception ex)
                {
                }
                con.Close();
                

                    SqlCommand cmd5 = con.CreateCommand();

                    cmd5.CommandType = CommandType.Text;
                    cmd5.CommandText = "select count(ID_visit) from Table_visit_patient where isnull(end_Paid,0) <> 1    and isnull(end_ee,0) <> 1 and date_visit is not null";
                    con.Open();
            try
            {
                Int32 rows_count22 = Convert.ToInt32(cmd5.ExecuteScalar());
                        label32.Text = rows_count22.ToString() + "";

        }
                    catch (Exception ex)
                    {
                    }
    con.Close();


                    var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "dboselectsts";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 startHome", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            //---------------------------------------------------------------//
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(dataGridView1.Rows.Count==0)
                {
                }
                else
                {
                    list_pat.Show(dataGridView1, new Point(e.X, e.Y));
                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    tt = textBox1.Text;
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 startHome", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Table_visit_patient set SentToDoc=1,end_ee=0 where ID_visit=" + textBox1.Text + " ";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();




                MessageBox.Show("تم الارسال بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 startHome", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Table_visit_patient set end_Paid=1 where ID_visit=" + textBox1.Text + " ";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "dboselectsts";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;


                MessageBox.Show("تم الغاء العملية بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                SqlCommand cmd5 = con.CreateCommand();

                cmd5.CommandType = CommandType.Text;
                cmd5.CommandText = "select count(ID_visit) from Table_visit_patient where isnull(end_Paid,0) <> 1    and isnull(end_ee,0) <> 1 and date_visit is not null";
                con.Open();
                try
                {
                    Int32 rows_count22 = Convert.ToInt32(cmd5.ExecuteScalar());
                    label32.Text = rows_count22.ToString() + "";

                }
                catch (Exception ex)
                {
                }
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 startHome", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //--------------------------الصفحات المتنقلة ------------------------//
        private void addControlsTopanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            visitpatientView ssa = new visitpatientView();
            addControlsTopanel(ssa);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Paid_MM ss = new Paid_MM();
            ss.Show();
        }

        public void btn_file_save_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlCommand cmd4 = con.CreateCommand();

            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "select count(Name_pat) from Table_PAT where age_pat is not null";
            con.Open();
            try
            {
                Int32 rows_count2 = Convert.ToInt32(cmd4.ExecuteScalar());
                label2.Text = rows_count2.ToString() + "";

            }
            catch (Exception ex)
            {
            }
            con.Close();


            SqlCommand cmd5 = con.CreateCommand();

            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "select count(ID_visit) from Table_visit_patient where isnull(end_Paid,0) <> 1    and isnull(end_ee,0) <> 1 and date_visit is not null";
            con.Open();
            try
            {
                Int32 rows_count22 = Convert.ToInt32(cmd5.ExecuteScalar());
                label32.Text = rows_count22.ToString() + "";

            }
            catch (Exception ex)
            {
            }
            con.Close();

            con.Open();
            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "dboselectsts";
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 startHome", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
