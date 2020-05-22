using Clinics.Class;
using Clinics.Grid;
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
        int NewRow = -1;
        public static OrderMaterials orderMaterials;
        public OrderMaterials()
        {
            orderMaterials = this;
            InitializeComponent();
        }
        public void addScren()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from " + D.DataPharmacy + "OrderMaterials where ID=@ID and MYear=@MYear", con);
                cmd21.Parameters.Add(new SqlParameter("@ID", textBox_Invoice__Number.Text));
                cmd21.Parameters.Add(new SqlParameter("@MYear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {

                    textBox_Year.Text = dr["MYear"].ToString();
                    textBox_Total.Text = dr["ALLTotal"].ToString();
                    dateTime_Invoice_Date.Text = dr["Date"].ToString();
                    con.Close();
                }
                else
                {
                    con.Close();
                    clear_screen();
                    MaxOrder();
                    return;
                }


                con.Open();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select R_Barcode, R_ItemName, R_PriceParchase, R_PriceSales, R_Tax, R_Qty, Item_MAX,R_TotalRow from " + D.DataPharmacy + "OrderMaterials where ID=@ID and myear=@myear", con);
                cmd.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                cmd.Parameters.Add(new SqlParameter("@ID", textBox_Invoice__Number.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView2.Rows.Add(dr2["R_Barcode"].ToString(), dr2["R_ItemName"].ToString(), dr2["R_PriceParchase"].ToString(), dr2["R_PriceSales"].ToString(), dr2["R_Tax"].ToString(), dr2["R_Qty"].ToString(), dr2["Item_MAX"].ToString(), dr2["R_TotalRow"].ToString());
                    
                }
                sumGrid1();
                sumGrid2();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1025 OrderMaterials", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
        private void MaxOrder()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(ID)+1),1) as max from " + D.DataPharmacy + "OrderMaterials where myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Invoice__Number.Text = dr["max"].ToString();
                }

                textBox_Invoice__Number.Focus();
            }
            catch (Exception ex)
            {
                msg.Alert("حدث خلل بسيط" + ex.Message, Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void OrderMaterials_Load(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.Year.ToString();
                textBox_Year.Text = date;
                MaxOrder();

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
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
        private bool ADD_Row()
        {

            try
            {

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "INSERT INTO "+D.DataPharmacy+"OrderMaterials  (ID, myear, Date, R_Barcode, R_ItemName, R_PriceParchase, R_PriceSales, R_Tax, R_Qty, Item_MAX, R_TotalRow, ALLTotal) VALUES (@ID, @myear, @Date, @R_Barcode, @R_ItemName, @R_PriceParchase, @R_PriceSales, @R_Tax, @R_Qty, @Item_MAX, @R_TotalRow, @ALLTotal)";

                    cmd.Parameters.AddWithValue("@ID", textBox_Invoice__Number.Text);
                    cmd.Parameters.AddWithValue("@MYear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTime_Invoice_Date.Value);

                    cmd.Parameters.AddWithValue("@R_Barcode", dataGridView2.Rows[i].Cells[clm_R_Barcode2.Name].Value);
                    cmd.Parameters.AddWithValue("@R_ItemName", dataGridView2.Rows[i].Cells[clm_R_ItemName2.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceParchase", dataGridView2.Rows[i].Cells[clm_R_PriceParchase2.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceSales", dataGridView2.Rows[i].Cells[clm_R_PriceSales2.Name].Value);
                    if (dataGridView2.Rows[i].Cells[clm_R_Tax2.Name].Value == "" || dataGridView2.Rows[i].Cells[clm_R_Tax2.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Tax", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Tax", dataGridView2.Rows[i].Cells[clm_R_Tax2.Name].Value);

                    }
                    cmd.Parameters.AddWithValue("@R_Qty", dataGridView2.Rows[i].Cells[clm_R_Qty2.Name].Value);
                    cmd.Parameters.AddWithValue("@Item_MAX", dataGridView2.Rows[i].Cells[clm_Item_MAX2.Name].Value);
                    cmd.Parameters.AddWithValue("@R_TotalRow", dataGridView2.Rows[i].Cells[Clm_R_TotalRow2.Name].Value);
                    cmd.Parameters.AddWithValue("@ALLTotal", textBox_Total.Text);
                    


                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1026 OrderMaterials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return false;
            }
        }
        private bool Delete_Row()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from " + D.DataPharmacy + "OrderMaterials where ID=@ID and MYear=@MYear";

                cmd.Parameters.AddWithValue("@ID", textBox_Invoice__Number.Text);
                cmd.Parameters.AddWithValue("@MYear", textBox_Year.Text);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1028 OrderMaterials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        private void clear_screen()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                textBox1.Text = "0";
                textBox_Total.Text = "0";
            }
            catch
            {

            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (textBox_Year.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك السنة فارغة", Form_Alert.enumType.Warning);
                    return;

                }
                if (textBox_Invoice__Number.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك رقم الفاتورة فارغ", Form_Alert.enumType.Warning);
                    return;
                }                
                if (dataGridView2.Rows.Count <= 0)
                {
                    msg.Alert("الفاتورة فارغه", Form_Alert.enumType.Warning);
                    return;
                }
                //----------------------------------------------تفقيد الفاتورة موجودة في الداتا--------------------------------------------------------------
                try
                {
                    con.Open();
                    SqlCommand cmd22 = new SqlCommand("select DISTINCT ID from " + D.DataPharmacy + "OrderMaterials where ID=@ID and myear=@myear", con);
                    cmd22.Parameters.Add(new SqlParameter("@ID", textBox_Invoice__Number.Text));
                    cmd22.Parameters.Add(new SqlParameter("@myear", textBox_Year.Text));
                    SqlDataReader dr2;
                    dr2 = cmd22.ExecuteReader();

                    if (dr2.Read())
                    {
                        NewRow = 1;

                    }
                    else
                    {
                        NewRow = 0;
                    }

                }
                catch (Exception ex)
                {
                    msg.Alert("حدث خلل بسيط" + ex.Message, Form_Alert.enumType.Error);
                }
                finally
                {
                    con.Close();
                }
                //----------------------------------------------------------------------------------------------------------------

                if (NewRow == 0)
                {

                    if (ADD_Row() == true)
                    {
                            history.EventHistory(textBox_Invoice__Number.Text, history.ADD, history.NameADD, docType.OrderMaterials, this.Text);
                            msg.Alert("تم اضافة الطلب  بنجاح بالرقم " + textBox_Invoice__Number.Text + "", Form_Alert.enumType.Success);
                            clear_screen();
                             OrderMaterials_Load(sender, e);                      
                    }


                }
                else if (NewRow == 1)
                {
                    if (Delete_Row() == true)
                    {

                            if (ADD_Row() == true)
                            {
                                history.EventHistory(textBox_Invoice__Number.Text, history.Edit, history.NameEdit, docType.OrderMaterials, this.Text);
                                msg.Alert("تم اضافة الطلب  بنجاح بالرقم " + textBox_Invoice__Number.Text + "", Form_Alert.enumType.Success);
                                clear_screen();
                                 OrderMaterials_Load(sender, e);                                
                            }                        
                    }
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1023 OrderMaterials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_View_Invoice_No_Click(object sender, EventArgs e)
        {
            if (textBox_Year.Text != string.Empty)
            {                
                Grid_OrderMaterials ss = new Grid_OrderMaterials();
                ss.ShowDialog();
            }
        }

        private void textBox_Invoice__Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox_Invoice__Number.Text != string.Empty)
                {
                    addScren();
                }

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Delete_Row() == true)
                {
                    history.EventHistory(textBox_Invoice__Number.Text, history.Delete, history.NameDelete, docType.OrderMaterials, this.Text);
                    msg.Alert("تم حذف الطلب  بنجاح بالرقم " + textBox_Invoice__Number.Text + "", Form_Alert.enumType.Success);
                    clear_screen();
                    OrderMaterials_Load(sender, e);                    
                }

            }
            catch
            {

            }

        }
    }
}
