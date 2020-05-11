using Clinics.Class;
using Clinics.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinics.Pharmacy
{
    public partial class Invoice_Parchase : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        msgShow msg = new msgShow();
        OthersDataBase D = new OthersDataBase();
        DocType docType = new DocType();
        int On_Percentage= 0 ;
        int Print = 0;
        int printNo;
        int NewRow = -1;
        int status_Invoice=0;
        public static Invoice_Parchase Inv_Parchase;
        public Invoice_Parchase()
        {
            Inv_Parchase = this;
            InitializeComponent();
        }
        public void addScren()
        {
            try
            {
                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select top 1 * from " + D.DataPharmacy + "Invoice_Parchase where IDOrder=@IDOrder and MYear=@MYear", con);
                    cmd21.Parameters.Add(new SqlParameter("@IDOrder", textBox_Invoice__Number.Text));
                    cmd21.Parameters.Add(new SqlParameter("@MYear", textBox_Year.Text));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();

                    if (dr.Read())
                    {
                        textBox_Supplier_No.Text = dr["IDSupplier"].ToString();
                        textBox_Supplier_Name.Text = dr["NameSupplier"].ToString();
                        textBox_Year.Text = dr["MYear"].ToString();
                        textBox_Total.Text = dr["TotalOrder"].ToString();
                        textBox_Discount.Text = dr["TotalDiscount"].ToString();
                        textBox_Note.Text = dr["Note"].ToString();
                        dateTime_Invoice_Date.Text = dr["Date"].ToString();
                        status_Invoice = Convert.ToInt32(dr["Status"].ToString());
                        if (status_Invoice == 0)
                        {
                            radioButton1.Checked = true;
                        }
                        else if (status_Invoice == 1)
                        {
                            radioButton2.Checked = true;
                        }
                        On_Percentage = Convert.ToInt32(dr["FlagDiscount"]);
                        if (On_Percentage == 1)
                        {
                            checkBox2.Checked = true;
                        }
                        else
                        {
                            checkBox2.Checked = false;
                        }
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
                SqlCommand cmd = new SqlCommand("select R_Barcode, R_ItemName, R_PriceParchase, R_PriceSales, R_Tax, R_Qty, R_Bouns,CONVERT(nvarchar(10), R_DateItem,110) as R_DateItem, R_Discount, R_DiscountPresnt, R_TotalRow from " + D.DataPharmacy+ "Invoice_Parchase where IDOrder=@IDOrder and myear=@myear", con);
                cmd.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                cmd.Parameters.Add(new SqlParameter("@IDOrder", textBox_Invoice__Number.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add(dr2["R_Barcode"].ToString(), dr2["R_ItemName"].ToString(), dr2["R_PriceParchase"].ToString(), dr2["R_PriceSales"].ToString(), dr2["R_Tax"].ToString(), dr2["R_Qty"].ToString(), dr2["R_Bouns"].ToString(), dr2["R_DateItem"].ToString(), dr2["R_Discount"].ToString(), dr2["R_DiscountPresnt"].ToString(), dr2["R_TotalRow"].ToString());
                    Sum_TotalGrid();
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1025 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Invoice_Parchase_Load(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.Year.ToString();
                textBox_Year.Text = date;
                MaxOrder();

            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }
        private void MaxOrder()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(IDOrder)+1),1) as max from "+D.DataPharmacy+"Invoice_Parchase where myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Invoice__Number.Text = dr["max"].ToString();
                }
                
                textBox_Invoice__Number.Focus();
            }
            catch(Exception ex)
            {
                msg.Alert("حدث خلل بسيط"+ex.Message,Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void textBox_Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Invoice_Parchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox_Invoice__Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Supplier_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void textBox_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Price_Parchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Qantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBouns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Discount1_GroupBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Discount_Percentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Item_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Item_No.Text != string.Empty)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("select Code,ItemName,Tax,CostPrice,AvgCost,SalePrice,Number_Retail from " + D.DataPharmacy + "Drugs where Code=@Code", con);
                            cmd.Parameters.Add(new SqlParameter("@Code", textBox_Item_No.Text));
                            con.Open();
                            SqlDataReader Ra = cmd.ExecuteReader();

                            if (Ra.Read())
                            {
                                textBox_Item_Name.Text = Ra["ItemName"].ToString();
                                textBox_Price_Parchase.Text = Ra["CostPrice"].ToString();
                                //--- سعر البيع
                                textBox3.Text = Ra["SalePrice"].ToString();
                                //------------الضريبة-------------------------------
                                textBox4.Text = Ra["Tax"].ToString();
                                textBox_Qantity.Focus();
                            }
                            else
                            {
                                msg.Alert("لا يوجد مادة بهذا الرمز", Form_Alert.enumType.Warning);                                
                                textBox_Item_No.Text = string.Empty;
                                textBox_Item_Name.Text = string.Empty;
                                textBox_Item_No.Focus();
                            }
                            Ra.Close();
                            

                        }
                        catch (Exception ex)
                        {
                            msg.Alert("حدث خلل بسيط"+ex.Message,Form_Alert.enumType.Error);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }

                }

            }
            catch (Exception ee)
            {
                msg.Alert("حدث خلل بسيط" + ee.Message, Form_Alert.enumType.Error);
            }

        }
        private void clear_screen()
        {
            textBox_Supplier_No.Text = string.Empty;
            textBox_Supplier_Name.Text = string.Empty;
            textBox_Note.Text = string.Empty;
            radioButton1.Checked = true;
            checkBox2.Checked = false;
            textBox_Total.Text = "0";
            textBox_Net_Total.Text = string.Empty;
            textBox_Discount.Text = string.Empty;
            dataGridView1.Rows.Clear();
            ClearGroupBoxGrid();
        }
        private void ClearGroupBoxGrid()
        {
            textBox_Item_No.Text = string.Empty;
            textBox_Item_Name.Text = string.Empty;
            textBox_Price_Parchase.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox_Qantity.Text = string.Empty;
            textBouns.Text = string.Empty;
            textBox_End_Date.Text = string.Empty;
            textBox_Discount1_GroupBox1.Text = string.Empty;
            textBox_Discount_Percentage.Text = string.Empty;
            textBox_total1_groupbox1.Text = string.Empty;
            textBox_Item_No.Focus();
        }
        private void Data_ADD_Rows()
        {
            try
            {
                dataGridView1.Rows.Add(textBox_Item_No.Text, textBox_Item_Name.Text, textBox_Price_Parchase.Text, textBox3.Text, textBox4.Text, textBox_Qantity.Text, textBouns.Text, textBox_End_Date.Text, textBox_Discount1_GroupBox1.Text, textBox_Discount_Percentage.Text, textBox_total1_groupbox1.Text);
                ClearGroupBoxGrid();
                msg.Alert("تم إضافة المادة بنجاح", Form_Alert.enumType.Success);
                Sum_TotalGrid();
            }
            catch (Exception ee)
            {
                msg.Alert("حدث خلل بسيط" + ee.Message, Form_Alert.enumType.Error);
            }
        }

        private void Sum_TotalGrid()
        {
            try
            {
                if (dataGridView1.Rows.Count  > 0)
                {
                    double TotalALLRows = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        double TotalRows = Convert.ToDouble(dataGridView1.Rows[i].Cells[Clm_R_TotalRow.Name].Value);

                        TotalALLRows += TotalRows;
                        textBox_Total.Text = TotalALLRows.ToString();
                    }
                }
            }
            catch (Exception ee)
            {
                msg.Alert("حدث خلل بسيط" + ee.Message, Form_Alert.enumType.Error);
            }

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Item_No.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك رمز المادة فارغ",Form_Alert.enumType.Warning);
                    textBox_Item_No.Focus();
                    return;

                }
                if (textBox_Item_Name.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك اسم المادة فارغ",Form_Alert.enumType.Warning);
                    textBox_Item_No.Focus();
                    return;
                }
                if (textBox_Price_Parchase.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك سعر الشراء فارغ",Form_Alert.enumType.Warning);
                    textBox_Price_Parchase.Focus();
                    return;
                }
                if (textBox3.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك سعر البيع فارغ", Form_Alert.enumType.Warning);
                    textBox3.Focus();
                    return;
                }
                if (textBox4.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك الضريبة فارغة", Form_Alert.enumType.Warning);
                    textBox4.Focus();
                    return;
                }
                if (textBox_Qantity.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك حقل الكمية فارغ", Form_Alert.enumType.Warning);
                    textBox_Qantity.Focus();
                    return;
                }
                if (textBox_End_Date.Text == "  /  /")
                {
                    msg.Alert("هذه المادة مرتبطة بتاريخ صلاحية لا يمكنك ترك تاريخ الصلاحية فارغ",Form_Alert.enumType.Warning);
                    textBox_End_Date.Focus();
                    return;
                }
                try
                {
                    DateTime d1 = DateTime.Now;
                    string mask = textBox_End_Date.Text;


                    string yyyy = mask.Substring(6, 4);
                    string dd = mask.Substring(0, 2);
                    string MM = mask.Substring(3, 2);

                    DateTime d2 = Convert.ToDateTime(yyyy + "-" + MM + "-" + dd);

                    double NrOfDays;
                    TimeSpan t = d1 - d2;
                    NrOfDays = t.TotalDays;


                    if (NrOfDays > 0)
                    {
                        msg.Alert("التاريخ المدخل منتهي الصلاحية", Form_Alert.enumType.Warning);
                        textBox_End_Date.Focus();
                        return;
                    }                    
                }
                catch
                {
                    msg.Alert("يرجى التأكد من إدخال التاريخ بشكل صحيح", Form_Alert.enumType.Warning);
                    textBox_End_Date.Focus();
                    return;
                }
                if(textBouns.Text==string.Empty)
                {
                    textBouns.Text="0";
                }
                if(textBox_Discount1_GroupBox1.Text==string.Empty)
                {
                    textBox_Discount1_GroupBox1.Text = "0";
                }
                if(textBox_Discount_Percentage.Text==string.Empty)
                {
                    textBox_Discount_Percentage.Text = "0";
                }
                Data_ADD_Rows();
                textBox_Item_No.Focus();
            }
            catch (Exception ee)
            {
                con.Close();
                msg.Alert("حدث خلل بسيط" + ee.Message, Form_Alert.enumType.Error);

            }

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            Sum_TotalGrid();
        }
        private void Sum_Total_Item()
        {
            double Quntity;
            double Price_parchase;
            double Total_Before_Discount;
            double discount;
            double discount_Percent;
            double Total_After_Discount;
            double Total;
            try
            {

                if (textBox_Qantity.Text == string.Empty)
                {
                    Quntity = 0;
                }
                else
                {
                    Quntity = Convert.ToDouble(textBox_Qantity.Text);
                }
                if (textBox_Price_Parchase.Text == string.Empty)
                {
                    Price_parchase = 0;

                }
                else
                {
                    Price_parchase = Convert.ToDouble(textBox_Price_Parchase.Text);
                }

                Total_Before_Discount = (Quntity * Price_parchase);

                if (textBox_Discount1_GroupBox1.Text == string.Empty)
                {
                    discount = 0;

                }
                else
                {
                    discount = Convert.ToDouble(textBox_Discount1_GroupBox1.Text);

                }
                if (textBox_Discount_Percentage.Text == string.Empty)
                {
                    discount_Percent = 0;
                }
                else
                {
                    discount_Percent = Convert.ToDouble(textBox_Discount_Percentage.Text) / 100;

                }

                Total_After_Discount = Total_Before_Discount - discount;
                Total = Total_After_Discount - (Total_Before_Discount * discount_Percent);

                textBox_total1_groupbox1.Text = Total.ToString();


            }
            catch
            {
                Quntity = 0;
                Price_parchase = 0;
                discount = 0;
                discount_Percent = 0;
                Total_Before_Discount = 0;
                Total_After_Discount = 0;
                Total = 0;
                textBox_total1_groupbox1.Text = Total.ToString();
            }
        }

        private void textBox_Qantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch
            {

            }
        }

        private void textBox_Discount1_GroupBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch
            {

            }
        }

        private void textBox_Price_Parchase_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch
            {

            }
        }

        private void textBox_Discount_Percentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch
            {

            }
        }
        private void Sum_Total_Parchase()
        {
            try
            {
                double discount2;
                if (textBox_Discount.Text != string.Empty)
                {
                    discount2 = Convert.ToDouble(textBox_Discount.Text);
                    if (checkBox2.Checked == true)
                    {
                        discount2 = (discount2 / 100) * Convert.ToDouble(textBox_Total.Text);

                    }
                }
                else
                {
                    discount2 = 0;
                }
                double totall = Convert.ToDouble(textBox_Total.Text) - discount2;
                textBox_Net_Total.Text = totall.ToString();
            }
            catch
            {

            }
        }

        private void textBox_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Parchase();
            }
            catch
            {
                
            }
        }

        private void textBox_Total_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Parchase();
            }
            catch
            {

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked == true)
                {
                    On_Percentage = 1;
                }
                else
                {
                    On_Percentage = 0;
                }
                Sum_Total_Parchase();
            }
            catch 
            {

            }
        }

        private void btn_Delete_Row_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(index);
                    Sum_TotalGrid();
                    msg.Alert("تم حذف السطر",Form_Alert.enumType.Info);
                }
                textBox_Item_No.Focus();
            }
            catch
            {

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    textBox_Item_No.Text = dataGridView1.CurrentRow.Cells[Clm_R_Barcode.Name].Value.ToString();
                    textBox_Item_Name.Text = dataGridView1.CurrentRow.Cells[Clm_R_ItemName.Name].Value.ToString();
                    textBox_Price_Parchase.Text = dataGridView1.CurrentRow.Cells[Clm_R_PriceParchase.Name].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[Clm_R_PriceSales.Name].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[Clm_R_Tax.Name].Value.ToString();
                    textBox_Qantity.Text = dataGridView1.CurrentRow.Cells[Clm_R_Qty.Name].Value.ToString();
                    textBouns.Text = dataGridView1.CurrentRow.Cells[Clm_R_Bouns.Name].Value.ToString();
                    textBox_End_Date.Text = dataGridView1.CurrentRow.Cells[Clm_R_DateItem.Name].Value.ToString();
                    textBox_Discount1_GroupBox1.Text = dataGridView1.CurrentRow.Cells[Clm_R_Discount.Name].Value.ToString();
                    textBox_Discount_Percentage.Text = dataGridView1.CurrentRow.Cells[Clm_R_DiscountPresnt.Name].Value.ToString();
                    textBox_total1_groupbox1.Text = dataGridView1.CurrentRow.Cells[Clm_R_TotalRow.Name].Value.ToString();

                    int index = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(index);
                    Sum_TotalGrid();
                    msg.Alert("وضع تعديل البيانات", Form_Alert.enumType.Edit);
                }
            }
            catch
            {

            }
        }

        private void btn_View_Supplier_No_Click(object sender, EventArgs e)
        {
            Grid_Supplier.SCR_Invoice_Parchase = true;
            Grid_Supplier ss = new Grid_Supplier();
            ss.ShowDialog();
            Grid_Supplier.SCR_Invoice_Parchase = false;
        }

        private void textBox_Supplier_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Supplier_No.Text != string.Empty)
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("select ID_Supplier,Name_Supplier  from add_Supplier where ID_Supplier=@ID_Supplier", con);
                            cmd.Parameters.Add(new SqlParameter("@ID_Supplier", textBox_Supplier_No.Text));                            
                            SqlDataReader Ra = cmd.ExecuteReader();
                            if (Ra.Read())
                            {
                                textBox_Supplier_Name.Text = Ra["Name_Supplier"].ToString();
                            }
                            else
                            {
                                msg.Alert("لا يوجد مورد بهذا الرقم", Form_Alert.enumType.Warning);
                                textBox_Supplier_No.Text = string.Empty;
                                textBox_Supplier_Name.Text = string.Empty;
                            }
                            Ra.Close();
                            
                        }
                        catch(Exception ex)
                        {
                            msg.Alert(ex.Message,Form_Alert.enumType.Error);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }


                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            Grid_Item.SCR_Invoice_Parchase = true;
            Grid_Item ss = new Grid_Item();
            ss.ShowDialog();
            Grid_Item.SCR_Invoice_Parchase = false;
            textBox_Qantity.Focus();
        }
        private bool Delete_Row_Trans()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from " + D.DataPharmacy + "i2_Trans where Order_No=@Order_No and MYear=@MYear and Doc_Type=@Doc_Type and Screen_Code=@Screen_Code";

                cmd.Parameters.AddWithValue("@Order_No", textBox_Invoice__Number.Text);
                cmd.Parameters.AddWithValue("@MYear", textBox_Year.Text);
                cmd.Parameters.AddWithValue("@Doc_Type", docType.Invoice_Parchase);
                cmd.Parameters.AddWithValue("@Screen_Code", docType.Invoice_Parchase);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1028 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        private bool Delete_Row()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from "+D.DataPharmacy+"Invoice_Parchase where IDOrder=@IDOrder and MYear=@MYear";

                cmd.Parameters.AddWithValue("@IDOrder", textBox_Invoice__Number.Text);
                cmd.Parameters.AddWithValue("@MYear", textBox_Year.Text);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1028 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        private bool ADD_Row()
        {
            
            try
            {
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "INSERT INTO  "+D.DataPharmacy +" Invoice_Parchase (IDOrder, MYear, Date, IDSupplier, NameSupplier, Status, Note, TotalOrder, TotalDiscount, FlagDiscount, TotalAfterDiscount, R_Barcode, R_ItemName, R_PriceParchase, R_PriceSales, R_Tax, R_Qty, R_Bouns, R_DateItem, R_Discount, R_DiscountPresnt, R_TotalRow,ID_User) VALUES        (@IDOrder, @MYear, @Date, @IDSupplier, @NameSupplier, @Status, @Note, @TotalOrder, @TotalDiscount, @FlagDiscount, @TotalAfterDiscount, @R_Barcode, @R_ItemName, @R_PriceParchase, @R_PriceSales, @R_Tax, @R_Qty, @R_Bouns, @R_DateItem,  @R_Discount, @R_DiscountPresnt, @R_TotalRow,@ID_User)";

                    cmd.Parameters.AddWithValue("@IDOrder", textBox_Invoice__Number.Text);
                    cmd.Parameters.AddWithValue("@MYear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTime_Invoice_Date.Value);

                    if (textBox_Supplier_No.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@IDSupplier", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IDSupplier", textBox_Supplier_No.Text);

                    }
                    cmd.Parameters.AddWithValue("@NameSupplier", textBox_Supplier_Name.Text);
                    cmd.Parameters.AddWithValue("@Status", status_Invoice);
                    cmd.Parameters.AddWithValue("@Note", textBox_Note.Text);
                    if (textBox_Net_Total.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@TotalAfterDiscount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TotalAfterDiscount", textBox_Net_Total.Text);

                    }
                    if (textBox_Discount.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@TotalDiscount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TotalDiscount", textBox_Discount.Text);

                    }
                    cmd.Parameters.AddWithValue("@FlagDiscount", On_Percentage);
                    if (textBox_Total.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@TotalOrder", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TotalOrder", textBox_Total.Text);

                    }


                    cmd.Parameters.AddWithValue("@R_Barcode", dataGridView1.Rows[i].Cells[Clm_R_Barcode.Name].Value);
                    cmd.Parameters.AddWithValue("@R_ItemName", dataGridView1.Rows[i].Cells[Clm_R_ItemName.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceParchase", dataGridView1.Rows[i].Cells[Clm_R_PriceParchase.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceSales", dataGridView1.Rows[i].Cells[Clm_R_PriceSales.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Tax", dataGridView1.Rows[i].Cells[Clm_R_Tax.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Qty", dataGridView1.Rows[i].Cells[Clm_R_Qty.Name].Value);
                    if(dataGridView1.Rows[i].Cells[Clm_R_Bouns.Name].Value=="" || dataGridView1.Rows[i].Cells[Clm_R_Bouns.Name].Value==null)
                    {
                        cmd.Parameters.AddWithValue("@R_Bouns", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Bouns", dataGridView1.Rows[i].Cells[Clm_R_Bouns.Name].Value);
                    }
                    

                    cmd.Parameters.AddWithValue("@R_DateItem", dataGridView1.Rows[i].Cells[Clm_R_DateItem.Name].Value);
                    if (dataGridView1.Rows[i].Cells[Clm_R_Discount.Name].Value == "" || dataGridView1.Rows[i].Cells[Clm_R_Discount.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("R_Discount", dataGridView1.Rows[i].Cells[Clm_R_Discount.Name].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[Clm_R_DiscountPresnt.Name].Value == "" || dataGridView1.Rows[i].Cells[Clm_R_DiscountPresnt.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_DiscountPresnt", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_DiscountPresnt", dataGridView1.Rows[i].Cells[Clm_R_DiscountPresnt.Name].Value);

                    }
                    cmd.Parameters.AddWithValue("@R_TotalRow", dataGridView1.Rows[i].Cells[Clm_R_TotalRow.Name].Value);                    
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);


                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1026 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Print = 0;
                if (textBox_Year.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك السنة فارغة",Form_Alert.enumType.Warning);
                    return;

                }
                if (textBox_Invoice__Number.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك رقم الفاتورة فارغ", Form_Alert.enumType.Warning);
                    return;
                }

                printNo = Convert.ToInt32(textBox_Invoice__Number.Text);
                if (dataGridView1.Rows.Count <= 0)
                {
                    msg.Alert("الفاتورة فارغه",Form_Alert.enumType.Warning);
                    return;
                }
                if (textBox_Net_Total.Text == string.Empty || textBox_Net_Total.Text == "0")
                {
                    msg.Alert("لا يمكنك حفظ فاتورة قيمتها 0",Form_Alert.enumType.Warning);
                    return;
                }


                //----------------------------------------------تفقيد الفاتورة موجودة في الداتا--------------------------------------------------------------
                try
                {
                    con.Open();
                    SqlCommand cmd22 = new SqlCommand("select DISTINCT IDOrder from "+D.DataPharmacy+"Invoice_Parchase where IDOrder=@IDOrder and myear=@myear", con);
                    cmd22.Parameters.Add(new SqlParameter("@IDOrder", textBox_Invoice__Number.Text));
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
                catch(Exception ex)
                {
                    msg.Alert("حدث خلل بسيط"+ex.Message,Form_Alert.enumType.Error);
                }
                finally
                {
                    con.Close();
                }
                //----------------------------------------------------------------------------------------------------------------

                if (NewRow == 0)
                {

                    if(ADD_Row()==true)
                    {
                        if(ADD_Row_Trans()==true)
                        {
                            msg.Alert("تم اضافة الطلب  بنجاح بالرقم " + textBox_Invoice__Number.Text + "", Form_Alert.enumType.Success);
                            clear_screen();
                            Invoice_Parchase_Load(sender, e);
                        }                        
                    }
                    
                    
                }
                else if (NewRow == 1)
                {
                    if(Delete_Row()==true)
                    {
                        if(Delete_Row_Trans()==true)
                        {
                            if (ADD_Row() == true)
                            {
                                if (ADD_Row_Trans() == true)
                                {
                                    msg.Alert("تم اضافة الطلب  بنجاح بالرقم " + textBox_Invoice__Number.Text + "", Form_Alert.enumType.Success);
                                    clear_screen();
                                    Invoice_Parchase_Load(sender, e);
                                }
                            }
                        }
                    }                   
                }
                Print = 1;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1023 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool ADD_Row_Trans()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "INSERT INTO  " + D.DataPharmacy + " i2_Trans (Order_No, Myear, Kind, Doc_Type, Screen_Code, Odate, status_Order, S_No, S_Name, TotalOrder, TotalDiscount, FlagDiscount, TotalAfterDiscount, R_Barcode, R_ItemName, R_PriceParchase, R_PriceSales, R_Tax, R_Qty, R_Bouns, R_DateItem, R_Discount, R_DiscountPresnt, R_TotalRow, Note, ID_User) VALUES        (@Order_No, @Myear, @Kind, @Doc_Type, @Screen_Code, @Odate, @status_Order, @S_No, @S_Name, @TotalOrder, @TotalDiscount, @FlagDiscount, @TotalAfterDiscount, @R_Barcode, @R_ItemName, @R_PriceParchase, @R_PriceSales, @R_Tax, @R_Qty, @R_Bouns, @R_DateItem, @R_Discount, @R_DiscountPresnt, @R_TotalRow, @Note, @ID_User)";

                    cmd.Parameters.AddWithValue("@Order_No", textBox_Invoice__Number.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Kind", docType.Input);
                    cmd.Parameters.AddWithValue("@Doc_Type", docType.Invoice_Parchase);
                    cmd.Parameters.AddWithValue("@Screen_Code", docType.Invoice_Parchase);
                    cmd.Parameters.AddWithValue("@Odate", dateTime_Invoice_Date.Value);
                    cmd.Parameters.AddWithValue("@status_Order", status_Invoice);
                    if (textBox_Supplier_No.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@S_No", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@S_No", textBox_Supplier_No.Text);

                    }
                    cmd.Parameters.AddWithValue("@S_Name", textBox_Supplier_Name.Text);
                    if (textBox_Total.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@TotalOrder", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TotalOrder", textBox_Total.Text);

                    }
                    if (textBox_Discount.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@TotalDiscount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TotalDiscount", textBox_Discount.Text);

                    }
                    cmd.Parameters.AddWithValue("@FlagDiscount", On_Percentage);
                    if (textBox_Net_Total.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@TotalAfterDiscount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TotalAfterDiscount", textBox_Net_Total.Text);

                    }
                    cmd.Parameters.AddWithValue("@R_Barcode", dataGridView1.Rows[i].Cells[Clm_R_Barcode.Name].Value);
                    cmd.Parameters.AddWithValue("@R_ItemName", dataGridView1.Rows[i].Cells[Clm_R_ItemName.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceParchase", dataGridView1.Rows[i].Cells[Clm_R_PriceParchase.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceSales", dataGridView1.Rows[i].Cells[Clm_R_PriceSales.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Tax", dataGridView1.Rows[i].Cells[Clm_R_Tax.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Qty", dataGridView1.Rows[i].Cells[Clm_R_Qty.Name].Value);
                    if (dataGridView1.Rows[i].Cells[Clm_R_Bouns.Name].Value == "" || dataGridView1.Rows[i].Cells[Clm_R_Bouns.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Bouns", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Bouns", dataGridView1.Rows[i].Cells[Clm_R_Bouns.Name].Value);
                    }
                    cmd.Parameters.AddWithValue("@R_DateItem", dataGridView1.Rows[i].Cells[Clm_R_DateItem.Name].Value);
                    if (dataGridView1.Rows[i].Cells[Clm_R_Discount.Name].Value == "" || dataGridView1.Rows[i].Cells[Clm_R_Discount.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("R_Discount", dataGridView1.Rows[i].Cells[Clm_R_Discount.Name].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[Clm_R_DiscountPresnt.Name].Value == "" || dataGridView1.Rows[i].Cells[Clm_R_DiscountPresnt.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_DiscountPresnt", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_DiscountPresnt", dataGridView1.Rows[i].Cells[Clm_R_DiscountPresnt.Name].Value);

                    }
                    cmd.Parameters.AddWithValue("@R_TotalRow", dataGridView1.Rows[i].Cells[Clm_R_TotalRow.Name].Value);
                    cmd.Parameters.AddWithValue("@Note", textBox_Note.Text);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1026 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //نقدي
                status_Invoice = 0;
            }
            if (radioButton2.Checked == true)
            {
                //مم مدينة
                status_Invoice = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //نقدي
                status_Invoice = 0;
            }
            if (radioButton2.Checked == true)
            {
                //مم مدينة
                status_Invoice = 1;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Delete_Row() == true)
            {
                if (Delete_Row_Trans() == true)
                {                    
                    msg.Alert("تم حذف الطلب  بنجاح بالرقم " + textBox_Invoice__Number.Text + "",Form_Alert.enumType.Success);
                    clear_screen();
                    Invoice_Parchase_Load(sender, e);                                            
                }
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

        private void btn_View_Invoice_No_Click(object sender, EventArgs e)
        {
            if (textBox_Year.Text != string.Empty)
            {
                Grid_Invoice_Parchase.SCR_Invoice_Parchase = true;
                Grid_Invoice_Parchase ss = new Grid_Invoice_Parchase();
                ss.ShowDialog();
                Grid_Invoice_Parchase.SCR_Invoice_Parchase = false;
            }
        }
    }
}
