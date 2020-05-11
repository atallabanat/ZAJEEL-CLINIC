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
    public partial class Grid_Item : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        msgShow msg = new msgShow();
        //public Virable
        public static Boolean SCR_Invoice_Parchase;
        public static Boolean SCR_Entry_Bond;

        string Item_No;
        string Item_Name;
        string Tax;
        string CostPrice;
        string AvgCost;
        string SalePrice;
        string Number_Retail;
        public Grid_Item()
        {
            InitializeComponent();
        }

        private void Grid_Item_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select * from " + D.DataPharmacy + "Drugs";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Item", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Item_No = dataGridView1.CurrentRow.Cells[clm_Code.Name].Value.ToString();
                    Item_Name = dataGridView1.CurrentRow.Cells[clm_ItemName.Name].Value.ToString();
                    Tax= dataGridView1.CurrentRow.Cells[clm_Tax.Name].Value.ToString();
                    CostPrice = dataGridView1.CurrentRow.Cells[clm_CostPrice.Name].Value.ToString();
                    AvgCost = dataGridView1.CurrentRow.Cells[clm_AvgCost.Name].Value.ToString();
                    SalePrice= dataGridView1.CurrentRow.Cells[clm_SalePrice.Name].Value.ToString();
                    Number_Retail= dataGridView1.CurrentRow.Cells[clm_Number_Retail.Name].Value.ToString();
                    if (SCR_Invoice_Parchase == true)
                    {
                        Invoice_Parchase.Inv_Parchase.textBox_Item_No.Text = Item_No;
                        Invoice_Parchase.Inv_Parchase.textBox_Item_Name.Text = Item_Name;
                        Invoice_Parchase.Inv_Parchase.textBox_Price_Parchase.Text = CostPrice;
                        Invoice_Parchase.Inv_Parchase.textBox3.Text = SalePrice;
                        Invoice_Parchase.Inv_Parchase.textBox4.Text = Tax;
                        Invoice_Parchase.Inv_Parchase.textBox_Qantity.Focus();
                        SCR_Invoice_Parchase = false;
                    }
                    if (SCR_Entry_Bond == true)
                    {
                        Entry_Bond.entry_Bond.textBox_Item_No.Text = Item_No;
                        Entry_Bond.entry_Bond.textBox_Item_Name.Text = Item_Name;
                        Entry_Bond.entry_Bond.textBox_Price_Parchase.Text = CostPrice;
                        Entry_Bond.entry_Bond.textBox3.Text = SalePrice;
                        Entry_Bond.entry_Bond.textBox4.Text = Tax;
                        Entry_Bond.entry_Bond.textBox_Qantity.Focus();
                        SCR_Entry_Bond = false;
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                msg.Alert(ex.Message,Form_Alert.enumType.Error);
            }
        }

        private void textBox_search_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                var dataTable2 = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select * from "+D.DataPharmacy+ "Drugs where Code LIKE @Code OR ItemName LIKE @ItemName";
                    Cmd.Parameters.AddWithValue("@Code", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@ItemName", "%" + textBox_search.Text + "%");
                    SqlDataAdapter da2 = new SqlDataAdapter(Cmd);
                    da2.Fill(dataTable2);
                }
                dataGridView1.DataSource = dataTable2;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Grid_Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
