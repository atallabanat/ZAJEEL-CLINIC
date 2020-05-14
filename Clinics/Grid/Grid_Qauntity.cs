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
    public partial class Grid_Qauntity : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        //public virable
        public static Boolean SCR_Out_Bond;
        public static Boolean SCR_Destruction_Bond;
        string R_Barcode;
        string R_ItemName;
        string R_Qty;
        string R_PriceParchase;
        string R_PriceSales;
        string R_DateItem;
        public Grid_Qauntity()
        {
            InitializeComponent();
        }

        private void Grid_Qauntity_Load(object sender, EventArgs e)
        {
            try
            {

                if (SCR_Out_Bond == true)
                {
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = "SELECT     R_Barcode,R_ItemName,sum(case when Kind = 1  then R_Qty else 0 end) - sum(case when Kind = 2 then R_Qty else 0 end) as R_Qty,R_PriceParchase,R_PriceSales ,FORMAT (R_DateItem, 'dd-MM-yyyy') as R_DateItem FROM           " + D.DataPharmacy+ "i2_trans where R_Barcode=@R_Barcode group by R_Barcode,R_ItemName,R_PriceParchase,R_PriceSales, R_DateItem";
                        Cmd.Parameters.AddWithValue("@R_Barcode", Out_Bond.out_Bond.textBox_Item_No.Text);
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                }
                if (SCR_Destruction_Bond == true)
                {
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = "SELECT     R_Barcode,R_ItemName,sum(case when Kind = 1  then R_Qty else 0 end) - sum(case when Kind = 2 then R_Qty else 0 end) as R_Qty,R_PriceParchase,R_PriceSales ,FORMAT (R_DateItem, 'dd-MM-yyyy') as R_DateItem FROM           " + D.DataPharmacy + "i2_trans where R_Barcode=@R_Barcode group by R_Barcode,R_ItemName,R_PriceParchase,R_PriceSales, R_DateItem";
                        Cmd.Parameters.AddWithValue("@R_Barcode", Destruction_Bond.destruction_Bond.textBox_Item_No.Text);
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Grid_Qauntity", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    R_Barcode = dataGridView1.CurrentRow.Cells[clmR_Barcode.Name].Value.ToString();
                    R_ItemName = dataGridView1.CurrentRow.Cells[clmR_ItemName.Name].Value.ToString();
                    R_Qty = dataGridView1.CurrentRow.Cells[clm_R_Qty.Name].Value.ToString();
                    R_PriceParchase = dataGridView1.CurrentRow.Cells[clmR_PriceParchase.Name].Value.ToString();
                    R_PriceSales = dataGridView1.CurrentRow.Cells[clmR_PriceSales.Name].Value.ToString();
                    R_DateItem = dataGridView1.CurrentRow.Cells[clmR_DateItem.Name].Value.ToString();

                    if (SCR_Out_Bond == true)
                    {
                        Out_Bond.out_Bond.textBox_Price_Parchase.Text = R_PriceParchase;
                        Out_Bond.out_Bond.textBox3.Text = R_PriceSales;
                        Out_Bond.out_Bond.textBox_Qantity.Text = R_Qty;
                        Out_Bond.out_Bond.textBox_End_Date.Text = R_DateItem;
                        Out_Bond.out_Bond.RQty =Convert.ToDouble(R_Qty);
                        SCR_Out_Bond = false;
                    }
                    if (SCR_Destruction_Bond == true)
                    {
                        Destruction_Bond.destruction_Bond.textBox_Price_Parchase.Text = R_PriceParchase;
                        Destruction_Bond.destruction_Bond.textBox3.Text = R_PriceSales;
                        Destruction_Bond.destruction_Bond.textBox_Qantity.Text = R_Qty;
                        Destruction_Bond.destruction_Bond.textBox_End_Date.Text = R_DateItem;
                        Destruction_Bond.destruction_Bond.RQty = Convert.ToDouble(R_Qty);
                        SCR_Destruction_Bond = false;
                    }
                }

                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Grid_Qauntity", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
