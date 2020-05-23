using Clinics.Class;
using Clinics.Pharmacy;
using Clinics.Pharmacy.ToolsPos.FRM_Report;
using Clinics.pharmacy_Control;
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
        public static Boolean SCR_Out_Bond;
        public static Boolean SCR_Destruction_Bond;
        public static Boolean SCR_ADD_recpie;
        public static Boolean SCR_FRM_Report_Material_inventory;
        string Item_No;
        string Item_Name;
        string Tax;
        string CostPrice;
        string AvgCost;
        string SalePrice;
        string Number_Retail;
        string Item_MAX;
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
                    Item_MAX= dataGridView1.CurrentRow.Cells[clmItem_MAX.Name].Value.ToString();
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
                    if (SCR_Out_Bond == true)
                    {
                        Out_Bond.out_Bond.textBox_Item_No.Text = Item_No;
                        Out_Bond.out_Bond.textBox_Item_Name.Text = Item_Name;
                        Out_Bond.out_Bond.textBox_Price_Parchase.Text = CostPrice;
                        Out_Bond.out_Bond.textBox3.Text = SalePrice;
                        Out_Bond.out_Bond.textBox4.Text = Tax;
                        Out_Bond.out_Bond.textBox_Qantity.Focus();
                        SCR_Out_Bond = false;
                    }
                    if (SCR_Destruction_Bond == true)
                    {
                        Destruction_Bond.destruction_Bond.textBox_Item_No.Text = Item_No;
                        Destruction_Bond.destruction_Bond.textBox_Item_Name.Text = Item_Name;
                        Destruction_Bond.destruction_Bond.textBox_Price_Parchase.Text = CostPrice;
                        Destruction_Bond.destruction_Bond.textBox3.Text = SalePrice;
                        Destruction_Bond.destruction_Bond.textBox4.Text = Tax;
                        Destruction_Bond.destruction_Bond.textBox_Qantity.Focus();
                        SCR_Destruction_Bond = false;
                    }
                    if (SCR_ADD_recpie == true)
                    {
                        ADD_recpie.aDD_Recpie.text_Barcode.Text = Item_No;
                        ADD_recpie.aDD_Recpie.text_ItemName.Text = Item_Name;
                        ADD_recpie.aDD_Recpie.text_cost_parchase.Text = CostPrice;
                        ADD_recpie.aDD_Recpie.text_cost_sales.Text = SalePrice;
                        ADD_recpie.aDD_Recpie.text_TAX.Text = Tax;
                        ADD_recpie.aDD_Recpie.text_cost_AVG.Text= AvgCost;
                        ADD_recpie.aDD_Recpie.text_Qu.Text = Number_Retail;
                        ADD_recpie.aDD_Recpie.textBox_Max.Text = Item_MAX;
                        SCR_ADD_recpie = false;
                    }
                    if(SCR_FRM_Report_Material_inventory==true)
                    {
                        FRM_Report_Material_inventory.fRM_Report_Material_.textBox_Item_No.Text = Item_No;
                        FRM_Report_Material_inventory.fRM_Report_Material_.textBox_Item_Name.Text = Item_Name;
                        SCR_FRM_Report_Material_inventory = false;
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
