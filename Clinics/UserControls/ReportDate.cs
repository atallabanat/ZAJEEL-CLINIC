using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Clinics.UserControls
{
    public partial class ReportDate : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public ReportDate()
        {
            InitializeComponent();
        }
        void GetData()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from CreateDate where cast([Date] as Date) between '" + dtp_Date.Value.ToString("yyyy-MM-dd") + "' and '" + dtp_Date2.Value.ToString("yyyy-MM-dd") + "'";
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
                MessageBox.Show(ee.Message);

            }
        }
        private void btn_file_save_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void addControlsTopanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    add_file_pat.ss = dataGridView1.Rows[e.RowIndex].Cells[clmfileID.Name].Value.ToString();
                    add_visitpatientView ssa = new add_visitpatientView();
                    addControlsTopanel(ssa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
