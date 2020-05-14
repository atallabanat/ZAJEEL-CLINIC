using Clinics.Class;
using Clinics.Pharmacy;
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
    public partial class Grid_Out_Bond : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        //public Virable
        public static Boolean SCR_Out_Bond;
        string Bond_No;
        string Bond_Date;
        public Grid_Out_Bond()
        {
            InitializeComponent();
        }

        private void Grid_Out_Bond_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                if (SCR_Out_Bond == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = "select DISTINCT  IDOrder, FORMAT (Date, 'dd-MM-yyyy') as Date from " + D.DataPharmacy + " Out_Bond where MYear=@MYear";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", Out_Bond.out_Bond.textBox_Year.Text));
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);
                    }
                    dataGridView1.DataSource = dataTable;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Out_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Bond_No = dataGridView1.CurrentRow.Cells[clm_IDOrder.Name].Value.ToString();
                    Bond_Date = dataGridView1.CurrentRow.Cells[clm_Date.Name].Value.ToString();

                    if (SCR_Out_Bond == true)
                    {
                        Out_Bond.out_Bond.textBox_Bond_No.Text = Bond_No;
                        Out_Bond.out_Bond.addScren();
                        SCR_Out_Bond = false;
                    }

                }
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Out_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
