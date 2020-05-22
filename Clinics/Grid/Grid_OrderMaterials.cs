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
    public partial class Grid_OrderMaterials : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        //public Virable        
        string Invoice_No;
        string Invoice_Date;
        public Grid_OrderMaterials()
        {
            InitializeComponent();
        }

        private void Grid_OrderMaterials_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select DISTINCT  ID,FORMAT (Date, 'dd-MM-yyyy') as Date from " + D.DataPharmacy + " OrderMaterials where MYear=@MYear";
                    Cmd.Parameters.Add(new SqlParameter("@Myear", OrderMaterials.orderMaterials.textBox_Year.Text));
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);
                }
                dataGridView1.DataSource = dataTable;                
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_OrderMaterials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Invoice_No = dataGridView1.CurrentRow.Cells[clm_ID.Name].Value.ToString();
                    Invoice_Date = dataGridView1.CurrentRow.Cells[clm_Date.Name].Value.ToString();

                    OrderMaterials.orderMaterials.textBox_Invoice__Number.Text = Invoice_No;
                    OrderMaterials.orderMaterials.addScren();
                }
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_OrderMaterials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
