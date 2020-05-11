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
    public partial class End_orders : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);


        public End_orders()
        {
            InitializeComponent();
        }

        private void End_orders_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            con.Open();
            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select ID_order,Date_order,Barcode,ItemName,EndDate,Quantity,PONAS,cost_Parchase,cost_Sales,RetailPrice,TAX,Total from Drugs_NOW where Date_order between @Date_order1 and @Date_order2";
                Cmd.Parameters.Add("@Date_order1", dateTimePicker1.Text);
                Cmd.Parameters.Add("@Date_order2", dateTimePicker2.Text);

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 End_orders", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
