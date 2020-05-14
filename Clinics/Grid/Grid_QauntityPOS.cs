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
    public partial class Grid_QauntityPOS : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        //public virable
        public static Boolean SCR_POS;            
        string R_Barcode;
        string R_ItemName;
        string R_Qty;
        string R_Tax;
        string R_PriceSales;
        string R_DateItem;
        string R_PriceParchase;
        public Grid_QauntityPOS()
        {
            InitializeComponent();
        }

        private void Grid_QauntityPOS_Load(object sender, EventArgs e)
        {
            try
            {

                if (SCR_POS == true)
                {
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = "SELECT     R_Barcode,R_ItemName,sum(case when Kind = 1  then R_Qty+R_Bouns else 0 end) - sum(case when Kind = 2 then R_Qty else 0 end) as R_Qty,R_PriceSales ,R_PriceParchase,FORMAT (R_DateItem, 'dd-MM-yyyy') as R_DateItem , R_Tax FROM   " + D.DataPharmacy+ "i2_trans  group by R_Barcode,R_ItemName,R_PriceSales, R_PriceParchase,R_DateItem,R_Tax";                        
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);
                        
                    }
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ee)
            {               
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Grid_QauntityPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    R_Tax = dataGridView1.CurrentRow.Cells[clmR_Tax.Name].Value.ToString();
                    R_PriceSales = dataGridView1.CurrentRow.Cells[clmR_PriceSales.Name].Value.ToString();
                    R_DateItem = dataGridView1.CurrentRow.Cells[clmR_DateItem.Name].Value.ToString();
                    R_PriceParchase= dataGridView1.CurrentRow.Cells[clm_R_PriceParchase.Name].Value.ToString();
                    if (SCR_POS == true)
                    {
                        POS.pOS.dataGridView1.Rows.Add(POS.pOS.dataGridView1.Rows.Count+1, R_Barcode, R_ItemName,1, R_PriceSales,string.Empty,string.Empty,R_Tax,string.Empty, R_DateItem, R_PriceParchase);
                        POS.pOS.ALLEventSum();
                        POS.pOS.TotalAmount();
                        SCR_POS = false;
                    }
                }

                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Grid_QauntityPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
