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
    public partial class Destruction_Bond : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        msgShow msg = new msgShow();
        OthersDataBase D = new OthersDataBase();
        DocType docType = new DocType();
        ClsHistory history = new ClsHistory();
        ConvertDate convertDate = new ConvertDate();
        public double RQty = 0;
        int Print = 0;
        int printNo;
        int NewRow = -1;
        public static Destruction_Bond destruction_Bond;
        public Destruction_Bond()
        {
            destruction_Bond = this;
            InitializeComponent();
        }
        private void MaxOrder()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(IDOrder)+1),1) as max from " + D.DataPharmacy + "Destruction_Bond where myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Bond_No.Text = dr["max"].ToString();
                }

                textBox_Bond_No.Focus();
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

        private void Destruction_Bond_Load(object sender, EventArgs e)
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

        private void btn_View_Supplier_No_Click(object sender, EventArgs e)
        {
            Grid_Supplier.SCR_Destruction_Bond = true;
            Grid_Supplier ss = new Grid_Supplier();
            ss.ShowDialog();
            Grid_Supplier.SCR_Destruction_Bond = false;
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
                        catch (Exception ex)
                        {
                            msg.Alert(ex.Message, Form_Alert.enumType.Error);
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Destruction_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox_Supplier_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
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
                            msg.Alert("حدث خلل بسيط" + ex.Message, Form_Alert.enumType.Error);
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

        private void btn_Item_Click(object sender, EventArgs e)
        {
            Grid_Item.SCR_Destruction_Bond = true;
            Grid_Item ss = new Grid_Item();
            ss.ShowDialog();
            Grid_Item.SCR_Destruction_Bond = false;
            textBox_Qantity.Focus();
        }

        private void btn_Qauntity_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Item_No.Text != string.Empty)
                {
                    Grid_Qauntity.SCR_Destruction_Bond = true;
                    Grid_Qauntity grid_Qauntity = new Grid_Qauntity();
                    grid_Qauntity.ShowDialog();
                    Grid_Qauntity.SCR_Destruction_Bond = false;
                }
                else
                {
                    MessageBox.Show("يرجى تحديد المادة لإظهار الكمية");
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1024 Destruction_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_Quantity2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Item_No.Text != string.Empty)
                {
                    Grid_Qauntity.SCR_Destruction_Bond = true;
                    Grid_Qauntity grid_Qauntity = new Grid_Qauntity();
                    grid_Qauntity.ShowDialog();
                    Grid_Qauntity.SCR_Destruction_Bond = false;
                }
                else
                {
                    MessageBox.Show("يرجى تحديد المادة لإظهار الكمية");
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1025 Destruction_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Sum_TotalGrid()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    double TotalALLRows = 0;
                    double TotalALLQtyRows = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        double TotalRows = Convert.ToDouble(dataGridView1.Rows[i].Cells[Clm_R_TotalRow.Name].Value);
                        double TotalQtyRows = Convert.ToDouble(dataGridView1.Rows[i].Cells[Clm_R_Qty.Name].Value);

                        TotalALLRows += TotalRows;
                        TotalALLQtyRows += TotalQtyRows;
                        textBox_Total2_groupBox2.Text = TotalALLRows.ToString();
                        textBox1.Text = TotalALLQtyRows.ToString();
                    }
                }
            }
            catch (Exception ee)
            {
                msg.Alert("حدث خلل بسيط" + ee.Message, Form_Alert.enumType.Error);
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
                    msg.Alert("تم حذف السطر", Form_Alert.enumType.Info);
                }
                textBox_Item_No.Focus();
            }
            catch
            {

            }

        }
        private void Data_ADD_Rows()
        {
            try
            {
                dataGridView1.Rows.Add(textBox_Item_No.Text, textBox_Item_Name.Text, textBox_Price_Parchase.Text, textBox3.Text, textBox4.Text, textBox_Qantity.Text, textBox_End_Date.Text, textBox_total1_groupbox1.Text);
                ClearGroupBoxGrid();
                msg.Alert("تم إضافة المادة بنجاح", Form_Alert.enumType.Success);
                Sum_TotalGrid();
            }
            catch (Exception ee)
            {
                msg.Alert("حدث خلل بسيط" + ee.Message, Form_Alert.enumType.Error);
            }
        }
        private void ClearGroupBoxGrid()
        {
            textBox_Item_No.Text = string.Empty;
            textBox_Item_Name.Text = string.Empty;
            textBox_Price_Parchase.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox_Qantity.Text = string.Empty;
            textBox_End_Date.Text = string.Empty;
            textBox_total1_groupbox1.Text = string.Empty;
            textBox_Item_No.Focus();
        }
        private void clear_screen()
        {
            textBox_Supplier_No.Text = string.Empty;
            textBox_Supplier_Name.Text = string.Empty;
            textBox_Note.Text = string.Empty;
            textBox_Total2_groupBox2.Text = "0";
            textBox1.Text = "0";
            dataGridView1.Rows.Clear();
            ClearGroupBoxGrid();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Item_No.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك رمز المادة فارغ", Form_Alert.enumType.Warning);
                    textBox_Item_No.Focus();
                    return;

                }
                if (textBox_Item_Name.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك اسم المادة فارغ", Form_Alert.enumType.Warning);
                    textBox_Item_No.Focus();
                    return;
                }
                if (textBox_Price_Parchase.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك سعر الشراء فارغ", Form_Alert.enumType.Warning);
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
                    msg.Alert("هذه المادة مرتبطة بتاريخ صلاحية لا يمكنك ترك تاريخ الصلاحية فارغ", Form_Alert.enumType.Warning);
                    textBox_End_Date.Focus();
                    return;
                }
                double QantityNow = 0;
                try
                {
                    QantityNow = Convert.ToDouble(textBox_Qantity.Text);
                }
                catch
                {
                    QantityNow = 0;
                }
                double RQty2 = RQty;
                loopGridQty();
                if (QantityNow > RQty)
                {
                    msg.Alert("  عذرا الكمية المتواجدة للمادة    " + RQty + "    لا يمكنك إخراج أكبر من الكمية المتواجدة  ", Form_Alert.enumType.Warning);
                    textBox_Qantity.Focus();
                    RQty = RQty2;
                    return;
                }
                Data_ADD_Rows();
                textBox_Item_No.Focus();
            }
            catch (Exception ee)
            {
                msg.Alert("حدث خلل بسيط" + ee.Message, Form_Alert.enumType.Error);
            }

        }
        private void loopGridQty()
        {
            if(dataGridView1.Rows.Count>0)
            {
                for(int i =0; i< dataGridView1.Rows.Count; i++)
                {
                    if(textBox_Item_No.Text == dataGridView1.Rows[i].Cells[Clm_R_Barcode.Name].Value.ToString())
                    {
                        double QtyGridItem = 0;
                        try
                        {
                            QtyGridItem = Convert.ToDouble(dataGridView1.Rows[i].Cells[Clm_R_Qty.Name].Value.ToString());
                            RQty -= QtyGridItem;
                        }
                        catch
                        {
                            QtyGridItem = 0;
                        }
                    }
                }
            }
        }
        private bool Delete_Row()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from " + D.DataPharmacy + "Destruction_Bond where IDOrder=@IDOrder and MYear=@MYear";

                cmd.Parameters.AddWithValue("@IDOrder", textBox_Bond_No.Text);
                cmd.Parameters.AddWithValue("@MYear", textBox_Year.Text);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1028 Destruction_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        private bool Delete_Row_Trans()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from " + D.DataPharmacy + "i2_Trans where Order_No=@Order_No and MYear=@MYear and Doc_Type=@Doc_Type and Screen_Code=@Screen_Code";

                cmd.Parameters.AddWithValue("@Order_No", textBox_Bond_No.Text);
                cmd.Parameters.AddWithValue("@MYear", textBox_Year.Text);
                cmd.Parameters.AddWithValue("@Doc_Type", docType.Destruction_Bond);
                cmd.Parameters.AddWithValue("@Screen_Code", docType.Destruction_Bond);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1028 Destruction_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                con.Close();
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

                    cmd.Parameters.AddWithValue("@Order_No", textBox_Bond_No.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Kind", docType.Output);
                    cmd.Parameters.AddWithValue("@Doc_Type", docType.Destruction_Bond);
                    cmd.Parameters.AddWithValue("@Screen_Code", docType.Destruction_Bond);
                    cmd.Parameters.AddWithValue("@Odate", dateTime_Bond_Date.Value);
                    cmd.Parameters.AddWithValue("@status_Order", "0");
                    if (textBox_Supplier_No.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@S_No", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@S_No", textBox_Supplier_No.Text);

                    }
                    cmd.Parameters.AddWithValue("@S_Name", textBox_Supplier_Name.Text);
                    if (textBox_Total2_groupBox2.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@TotalOrder", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TotalOrder", textBox_Total2_groupBox2.Text);

                    }
                    cmd.Parameters.AddWithValue("@TotalDiscount", "0");
                    cmd.Parameters.AddWithValue("@FlagDiscount", "0");
                    if (textBox_Total2_groupBox2.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@TotalAfterDiscount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TotalAfterDiscount", textBox_Total2_groupBox2.Text);

                    }
                    cmd.Parameters.AddWithValue("@R_Barcode", dataGridView1.Rows[i].Cells[Clm_R_Barcode.Name].Value);
                    cmd.Parameters.AddWithValue("@R_ItemName", dataGridView1.Rows[i].Cells[Clm_R_ItemName.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceParchase", dataGridView1.Rows[i].Cells[Clm_R_PriceParchase.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceSales", dataGridView1.Rows[i].Cells[Clm_R_PriceSales.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Tax", dataGridView1.Rows[i].Cells[Clm_R_Tax.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Qty", dataGridView1.Rows[i].Cells[Clm_R_Qty.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Bouns", "0");
                    cmd.Parameters.AddWithValue("@R_DateItem",convertDate.TODate(dataGridView1.Rows[i].Cells[Clm_R_DateItem.Name].Value.ToString()));
                    cmd.Parameters.AddWithValue("@R_Discount", "0");
                    cmd.Parameters.AddWithValue("@R_DiscountPresnt", "0");
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1026 Destruction_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    msg.Alert("يرجى عدم ترك السنة فارغة", Form_Alert.enumType.Warning);
                    return;

                }
                if (textBox_Bond_No.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك رقم السند فارغ", Form_Alert.enumType.Warning);
                    return;
                }

                printNo = Convert.ToInt32(textBox_Bond_No.Text);
                if (dataGridView1.Rows.Count <= 0)
                {
                    msg.Alert("الفاتورة فارغه", Form_Alert.enumType.Warning);
                    return;
                }
                if (textBox_Total2_groupBox2.Text == string.Empty || textBox_Total2_groupBox2.Text == "0")
                {
                    msg.Alert("لا يمكنك حفظ فاتورة قيمتها 0", Form_Alert.enumType.Warning);
                    return;
                }


                //----------------------------------------------تفقيد الفاتورة موجودة في الداتا--------------------------------------------------------------
                try
                {
                    con.Open();
                    SqlCommand cmd22 = new SqlCommand("select DISTINCT IDOrder from " + D.DataPharmacy + "Destruction_Bond where IDOrder=@IDOrder and myear=@myear", con);
                    cmd22.Parameters.Add(new SqlParameter("@IDOrder", textBox_Bond_No.Text));
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
                        if (ADD_Row_Trans() == true)
                        {
                            history.EventHistory(textBox_Bond_No.Text, history.ADD, history.NameADD, docType.Destruction_Bond, this.Text);
                            msg.Alert("تم اضافة الطلب  بنجاح بالرقم " + textBox_Bond_No.Text + "", Form_Alert.enumType.Success);
                            clear_screen();
                            Destruction_Bond_Load(sender, e);
                        }
                    }


                }
                else if (NewRow == 1)
                {
                    if (Delete_Row() == true)
                    {
                        if (Delete_Row_Trans() == true)
                        {
                            if (ADD_Row() == true)
                            {
                                if (ADD_Row_Trans() == true)
                                {
                                    history.EventHistory(textBox_Bond_No.Text, history.Edit, history.NameEdit, docType.Destruction_Bond, this.Text);
                                    msg.Alert("تم اضافة الطلب  بنجاح بالرقم " + textBox_Bond_No.Text + "", Form_Alert.enumType.Success);
                                    clear_screen();
                                    Destruction_Bond_Load(sender, e);
                                }
                            }
                        }
                    }
                }
                Print = 1;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1023 Destruction_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    cmd.CommandText = "INSERT INTO  " + D.DataPharmacy + " Destruction_Bond (IDOrder, MYear, Date, IDSupplier, NameSupplier, Note, TotalOrder, R_Barcode, R_ItemName, R_PriceParchase, R_PriceSales, R_Tax, R_Qty, R_DateItem, R_TotalRow, ID_User) VALUES (@IDOrder, @MYear, @Date, @IDSupplier, @NameSupplier, @Note, @TotalOrder, @R_Barcode, @R_ItemName, @R_PriceParchase, @R_PriceSales, @R_Tax, @R_Qty, @R_DateItem, @R_TotalRow, @ID_User)";

                    cmd.Parameters.AddWithValue("@IDOrder", textBox_Bond_No.Text);
                    cmd.Parameters.AddWithValue("@MYear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTime_Bond_Date.Value);

                    if (textBox_Supplier_No.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@IDSupplier", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IDSupplier", textBox_Supplier_No.Text);

                    }
                    cmd.Parameters.AddWithValue("@NameSupplier", textBox_Supplier_Name.Text);
                    cmd.Parameters.AddWithValue("@Note", textBox_Note.Text);
                    cmd.Parameters.AddWithValue("@TotalOrder", textBox_Total2_groupBox2.Text);


                    cmd.Parameters.AddWithValue("@R_Barcode", dataGridView1.Rows[i].Cells[Clm_R_Barcode.Name].Value);
                    cmd.Parameters.AddWithValue("@R_ItemName", dataGridView1.Rows[i].Cells[Clm_R_ItemName.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceParchase", dataGridView1.Rows[i].Cells[Clm_R_PriceParchase.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceSales", dataGridView1.Rows[i].Cells[Clm_R_PriceSales.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Tax", dataGridView1.Rows[i].Cells[Clm_R_Tax.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Qty", dataGridView1.Rows[i].Cells[Clm_R_Qty.Name].Value);
                    cmd.Parameters.AddWithValue("@R_DateItem",convertDate.TODate(dataGridView1.Rows[i].Cells[Clm_R_DateItem.Name].Value.ToString()));
                    cmd.Parameters.AddWithValue("@R_TotalRow", dataGridView1.Rows[i].Cells[Clm_R_TotalRow.Name].Value);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);


                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1026 Destruction_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Delete_Row() == true)
            {
                if (Delete_Row_Trans() == true)
                {
                    history.EventHistory(textBox_Bond_No.Text, history.Delete, history.NameDelete, docType.Destruction_Bond, this.Text);
                    msg.Alert("تم حذف الطلب  بنجاح بالرقم " + textBox_Bond_No.Text + "", Form_Alert.enumType.Success);
                    clear_screen();
                    Destruction_Bond_Load(sender, e);
                }
            }

        }
        public void addScren()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from " + D.DataPharmacy + "Destruction_Bond where IDOrder=@IDOrder and MYear=@MYear", con);
                cmd21.Parameters.Add(new SqlParameter("@IDOrder", textBox_Bond_No.Text));
                cmd21.Parameters.Add(new SqlParameter("@MYear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    textBox_Supplier_No.Text = dr["IDSupplier"].ToString();
                    textBox_Supplier_Name.Text = dr["NameSupplier"].ToString();
                    textBox_Year.Text = dr["MYear"].ToString();
                    textBox_Total2_groupBox2.Text = dr["TotalOrder"].ToString();
                    textBox_Note.Text = dr["Note"].ToString();
                    dateTime_Bond_Date.Text = dr["Date"].ToString();
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
                SqlCommand cmd = new SqlCommand("select R_Barcode, R_ItemName, R_PriceParchase, R_PriceSales, R_Tax, R_Qty, FORMAT (R_DateItem, 'dd-MM-yyyy') as R_DateItem,  R_TotalRow from " + D.DataPharmacy + "Destruction_Bond where IDOrder=@IDOrder and myear=@myear", con);
                cmd.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                cmd.Parameters.Add(new SqlParameter("@IDOrder", textBox_Bond_No.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add(dr2["R_Barcode"].ToString(), dr2["R_ItemName"].ToString(), dr2["R_PriceParchase"].ToString(), dr2["R_PriceSales"].ToString(), dr2["R_Tax"].ToString(), dr2["R_Qty"].ToString(), dr2["R_DateItem"].ToString(), dr2["R_TotalRow"].ToString());
                    Sum_TotalGrid();
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1025 Destruction_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_View_Bond_No_Click(object sender, EventArgs e)
        {
            if (textBox_Year.Text != string.Empty)
            {
                Grid_Destruction_Bond.SCR_Destruction_Bond = true;
                Grid_Destruction_Bond ss = new Grid_Destruction_Bond();
                ss.ShowDialog();
                Grid_Destruction_Bond.SCR_Destruction_Bond = false;
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch
            {

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch
            {

            }
        }
        private void Sum_Total_Item()
        {
            double Quntity;
            double Price_parchase;
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

                Total = Quntity * Price_parchase;

                textBox_total1_groupbox1.Text = Total.ToString();


            }
            catch
            {
                Quntity = 0;
                Price_parchase = 0;
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
    }
}
