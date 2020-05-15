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
    public partial class Grid_Invoice_Sales : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        string Invoice_No;
        string DateInvoice;
        public Grid_Invoice_Sales()
        {
            InitializeComponent();
        }

        private void Grid_Invoice_Sales_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select DISTINCT ID,FORMAT (DateInvoice, 'dd-MM-yyyy') as DateInvoice,Time,CASE WHEN Status=0 THEN N'نقدي' WHEN Status=1 THEN N'ذمم مدينة' WHEN Status=2 THEN N'بطاقة' ELSE N'تأمين' END as Status,TotalAmount_Invoice from " + D.DataPharmacy+ "Invoice_Sales where Bill_Suspension <> 1 order by ID desc";                    
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);
                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Invoice_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Invoice_No = dataGridView1.CurrentRow.Cells[clm_ID.Name].Value.ToString();
                    DateInvoice = dataGridView1.CurrentRow.Cells[clm_DateInvoice.Name].Value.ToString();
                        POS.pOS.label5.Text = Invoice_No;
                        POS.pOS.addScreen(Invoice_No, DateInvoice);
                }
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Invoice_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
