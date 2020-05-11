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
    public partial class Grid_Invoice_Parchase : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        //public Virable
        public static Boolean SCR_Invoice_Parchase;
        string Invoice_No;
        string Invoice_Date;
        public Grid_Invoice_Parchase()
        {
            InitializeComponent();
        }

        private void Grid_Invoice_Parchase_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                    if (SCR_Invoice_Parchase == true)
                    {
                        using (SqlCommand Cmd = con.CreateCommand())
                        {
                            Cmd.CommandType = CommandType.Text;
                            Cmd.CommandText = "select DISTINCT  IDOrder,Date from " + D.DataPharmacy+" Invoice_Parchase where MYear=@MYear";
                            Cmd.Parameters.Add(new SqlParameter("@Myear", Invoice_Parchase.Inv_Parchase.textBox_Year.Text));
                            SqlDataAdapter da = new SqlDataAdapter(Cmd);
                            da.Fill(dataTable);
                        }
                        dataGridView1.DataSource = dataTable;
                    }
                
            }
            catch (Exception ee)
            {               
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Invoice_No = dataGridView1.CurrentRow.Cells[clm_IDOrder.Name].Value.ToString();
                    Invoice_Date = dataGridView1.CurrentRow.Cells[clm_Date.Name].Value.ToString();

                    if (SCR_Invoice_Parchase == true)
                    {
                        Invoice_Parchase.Inv_Parchase.textBox_Invoice__Number.Text = Invoice_No;
                        Invoice_Parchase.Inv_Parchase.addScren();
                        SCR_Invoice_Parchase = false;
                    }

                }
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
