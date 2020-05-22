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

namespace Clinics.pharmacy_Control
{
    public partial class End_user : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static End_user ee;
        string ID;
        string UserName;
        public End_user()
        {
            ee = this;
            InitializeComponent();
        }

        private void End_user_Load(object sender, EventArgs e)
        {
            try
            { 
                con.Open();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select ID,username from tbl_User order by ID";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;            
            }
            catch (Exception ee)
            {                
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 End_user", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            END_Shift ss = new END_Shift();
            ss.Show();
            this.Hide();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            { 
                ID = dataGridView1.CurrentRow.Cells[Clm_ID.Name].Value.ToString();
                UserName = dataGridView1.CurrentRow.Cells[clm_UserName.Name].Value.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 End_user", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
