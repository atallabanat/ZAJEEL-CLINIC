using Clinics.Class;
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

namespace Clinics.Pharmacy
{
    public partial class OrderMaterials : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        msgShow msg = new msgShow();
        OthersDataBase D = new OthersDataBase();
        DocType docType = new DocType();
        ClsHistory history = new ClsHistory();
        ConvertDate convertDate = new ConvertDate();
        public OrderMaterials()
        {
            InitializeComponent();
        }
        private void LoadGrid()
        {
            try
            {

                con.Open();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select * from (SELECT        A.R_Barcode, A.R_ItemName,  A.R_PriceParchase,A.R_PriceSales,A.R_Tax,A.R_Qty, " + D.DataPharmacy + "Drugs.Item_MAX,(A.R_Qty * A.R_PriceParchase) As TotalRow FROM            (SELECT        R_Barcode, R_ItemName, SUM(CASE WHEN Kind = 1 THEN R_Qty + R_Bouns ELSE 0 END) - SUM(CASE WHEN Kind = 2 THEN R_Qty ELSE 0 END) AS R_Qty, R_PriceSales, R_PriceParchase, R_Tax  FROM " + D.DataPharmacy + "i2_Trans  GROUP BY R_Barcode, R_ItemName, R_PriceSales, R_PriceParchase, R_Tax) AS A Left JOIN  " + D.DataPharmacy + "Drugs ON A.R_Barcode = " + D.DataPharmacy + "Drugs.Code)B where B.R_Qty <= B.Item_MAX", con);                
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add( dr2["R_Barcode"].ToString(), dr2["R_ItemName"].ToString(), dr2["R_PriceParchase"].ToString(), dr2["R_PriceSales"].ToString(), dr2["R_Tax"].ToString(), dr2["R_Qty"].ToString(), dr2["Item_MAX"].ToString(), dr2["TotalRow"].ToString());
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 OrderMaterials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }
        private void OrderMaterials_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Cells[ClmADD.Name].Selected==true)
            {
                dataGridView2.Rows.Add(dataGridView1.CurrentRow.Cells[Clm_R_Barcode.Name].Value, dataGridView1.CurrentRow.Cells[Clm_R_ItemName.Name].Value, dataGridView1.CurrentRow.Cells[Clm_R_PriceParchase.Name].Value, dataGridView1.CurrentRow.Cells[Clm_R_PriceSales.Name].Value, dataGridView1.CurrentRow.Cells[Clm_R_Tax.Name].Value, dataGridView1.CurrentRow.Cells[Clm_Item_MAX.Name].Value, dataGridView1.CurrentRow.Cells[Clm_Item_MAX.Name].Value); ;
                int index = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(index);
                sumTotalRow();
                sumGrid1();
                sumGrid2();
            }
        }
        private void sumTotalRow()
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    double PriceParchsae = 0;
                    double Qty =0;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        Qty = Convert.ToDouble(dataGridView2.Rows[i].Cells[clm_R_Qty2.Name].Value);
                        PriceParchsae = Convert.ToDouble(dataGridView2.Rows[i].Cells[clm_R_PriceParchase2.Name].Value);
                        dataGridView2.Rows[i].Cells[Clm_R_TotalRow2.Name].Value = (Qty * PriceParchsae).ToString();
                    }
                    
                }
            }
            catch
            {
                
            }
        }

        private void sumGrid1()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    double TotalRow = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        TotalRow += Convert.ToDouble(dataGridView1.Rows[i].Cells[Clm_R_TotalRow.Name].Value);
                    }
                    textBox1.Text = TotalRow.ToString();
                }
                else
                {
                    textBox1.Text = "00.000";
                }
            }
            catch
            {
                textBox1.Text = "00.000";
            }
        }
        private void sumGrid2()
        {
            try
            {
                if (dataGridView2.Rows.Count  > 0)
                {

                    double TotalRow = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count ; i++)
                    {
                        TotalRow += Convert.ToDouble(dataGridView2.Rows[i].Cells[Clm_R_TotalRow2.Name].Value);
                    }
                    textBox_Total.Text = TotalRow.ToString();
                }
                else
                {
                    textBox_Total.Text = "00.000";
                }
            }
            catch
            {
                textBox_Total.Text = "00.000";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
                sumGrid1();
                sumGrid2();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
                sumGrid1();
                sumGrid2();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.Rows.Count > 0)
                {
                    for(int i =0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView2.Rows.Add(dataGridView1.Rows[i].Cells[Clm_R_Barcode.Name].Value, dataGridView1.Rows[i].Cells[Clm_R_ItemName.Name].Value, dataGridView1.Rows[i].Cells[Clm_R_PriceParchase.Name].Value, dataGridView1.Rows[i].Cells[Clm_R_PriceSales.Name].Value, dataGridView1.Rows[i].Cells[Clm_R_Tax.Name].Value, dataGridView1.Rows[i].Cells[Clm_Item_MAX.Name].Value, dataGridView1.Rows[i].Cells[Clm_Item_MAX.Name].Value);
                        
                    }
                    dataGridView1.Rows.Clear();
                    sumTotalRow();
                    sumGrid1();
                    sumGrid2();
                }
                
            }
            catch
            {

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Cells[Clm_Delete.Name].Selected == true)
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                dataGridView2.Rows.RemoveAt(index);
                sumGrid1();
                sumGrid2();
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            sumTotalRow();
            sumGrid1();
            sumGrid2();
        }
    }
}
