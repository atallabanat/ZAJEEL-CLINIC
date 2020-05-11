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
    public partial class count2 : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public count2()
        {
            InitializeComponent();
        }

        private void count2_Load(object sender, EventArgs e)
        {
            try
            { 

            if (Point_sale.point_Sale.textBox3.Text != "")
            {
                textBox1.Text = Point_sale.point_Sale.textBox3.Text;
                con.Open();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select ID_order,EndDate,Barcode,ItemName,Quantity,cost_Sales,TAX from Drugs_NOW where Barcode=@Barcode";
                    Cmd.Parameters.Add(new SqlParameter("@Barcode", textBox1.Text));
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
                con.Close();
            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 count2", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            { 
            Point_sale.point_Sale.dataGridView1.Rows.Add(Point_sale.point_Sale.i, dataGridView1.CurrentRow.Cells[2].Value, dataGridView1.CurrentRow.Cells[3].Value,"1", dataGridView1.CurrentRow.Cells[5].Value,"","0", dataGridView1.CurrentRow.Cells[6].Value);
            Point_sale.point_Sale.i += 1;
            Point_sale.point_Sale.Total();
            Point_sale.point_Sale.N_Items();
            Point_sale.point_Sale.SubTotal();
            Point_sale.point_Sale.TotalAmount();
            Point_sale.totalAmount = Point_sale.point_Sale.text_totalAmount.Text;
            Point_sale.point_Sale.textBox3.Text = "";
            Point_sale.point_Sale.textBox7.Text =dataGridView1.CurrentRow.Cells["Column7"].Value.ToString();
            Point_sale.point_Sale.textBox3.Focus();
            this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 count2", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
