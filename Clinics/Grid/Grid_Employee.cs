using Clinics.Class;
using Clinics.Pharmacy.ToolsPos;
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

namespace Clinics.Grid
{
    public partial class Grid_Employee : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        //public Virable
        string ID;
        string UserName;
        public Grid_Employee()
        {
            InitializeComponent();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    ID = dataGridView1.CurrentRow.Cells[clm_ID.Name].Value.ToString();
                    UserName = dataGridView1.CurrentRow.Cells[clm_username.Name].Value.ToString();

                    EndShiftUser.shiftUser.textBox_Emp_No.Text = ID;
                    EndShiftUser.shiftUser.textBox_Emp_Name.Text = UserName;
                }
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Grid_Employee_Load(object sender, EventArgs e)
        {
            try
            {
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
