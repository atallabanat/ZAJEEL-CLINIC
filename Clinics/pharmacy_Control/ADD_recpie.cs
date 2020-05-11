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

namespace Clinics.pharmacy_Control
{
    public partial class ADD_recpie : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        msgShow msg = new msgShow();
        OthersDataBase D = new OthersDataBase();
        public static ADD_recpie aDD_Recpie;
        ClsHistory history = new ClsHistory();
        DocType docType = new DocType();
        public ADD_recpie()
        {
            aDD_Recpie = this;
            this.KeyPreview = true;

            InitializeComponent();
        }

        private void text_cost_parchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 ADD_recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void text_cost_AVG_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 ADD_recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_cost_sales_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 ADD_recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void text_Qu_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 ADD_recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void text_TAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 ADD_recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void text_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 ADD_recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_Barcode.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك حقل الباركود فارغ", Form_Alert.enumType.Warning);
                    text_Barcode.Focus();
                    return;
                }
                if (text_ItemName.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك حقل اسم المادة فارغ", Form_Alert.enumType.Warning);
                    text_ItemName.Focus();
                    return;

                }
                if (text_cost_parchase.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك حقل سعر الشراء فارغ", Form_Alert.enumType.Warning);
                    text_cost_parchase.Focus();
                    return;

                }
                if (text_TAX.Text == string.Empty)
                {
                    msg.Alert("يرجى عد ترك حقل الضريبة فارغ ، في حال لا يوجد ضريبة يرجى ادخال قيمة 0", Form_Alert.enumType.Warning);
                    text_TAX.Focus();
                    return;

                }
                if (text_cost_sales.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك حقل سعر البيع فارغ", Form_Alert.enumType.Warning);
                    text_cost_sales.Focus();
                    return;
                }
                if (text_cost_AVG.Text == string.Empty)
                {
                    msg.Alert("يرجى عدم ترك حقل سعر التكلفة فارغ", Form_Alert.enumType.Warning);
                    text_cost_AVG.Focus();
                    return;
                }
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select Code from Drugs where Code=@Code", con);
                cmd21.Parameters.AddWithValue("@Code", text_Barcode.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                int count = 0;
                if (dr.Read())
                {
                    count += 1;

                }

                con.Close();
                if (count == 1)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE       " + D.DataPharmacy + "Drugs SET ItemName =@ItemName, Tax =@Tax, CostPrice =@CostPrice, AvgCost =@AvgCost, SalePrice =@SalePrice, Number_Retail =@Number_Retail, Item_MAX =@Item_MAX where Code=@Code";

                        cmd.Parameters.AddWithValue("@Code", text_Barcode.Text.Trim());
                        cmd.Parameters.AddWithValue("@ItemName", text_ItemName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tax", text_TAX.Text.Trim());
                        cmd.Parameters.AddWithValue("@CostPrice", text_cost_parchase.Text.Trim());
                        cmd.Parameters.AddWithValue("@AvgCost", text_cost_AVG.Text.Trim());
                        cmd.Parameters.AddWithValue("@SalePrice", text_cost_sales.Text.Trim());
                        cmd.Parameters.AddWithValue("@Number_Retail", text_Qu.Text.Trim());
                        if (textBox_Max.Text == string.Empty)
                        {
                            cmd.Parameters.AddWithValue("@Item_MAX", 0);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Item_MAX", textBox_Max.Text.Trim());
                        }
                        cmd.ExecuteNonQuery();
                        history.EventHistory(text_Barcode.Text, history.Edit, history.NameEdit, docType.ADD_recpie, this.Text);
                        msg.Alert("تم تعديل بيانات المادة بنجاح", Form_Alert.enumType.Success);
                        ClearScreen();
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
                else
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO " + D.DataPharmacy + "Drugs (Code, ItemName, Tax, CostPrice, AvgCost, SalePrice, Number_Retail, Item_MAX) VALUES        (@Code, @ItemName, @Tax, @CostPrice, @AvgCost, @SalePrice, @Number_Retail, @Item_MAX) ";
                        cmd.Parameters.AddWithValue("@Code", text_Barcode.Text.Trim());
                        cmd.Parameters.AddWithValue("@ItemName", text_ItemName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tax", text_TAX.Text.Trim());
                        cmd.Parameters.AddWithValue("@CostPrice", text_cost_parchase.Text.Trim());
                        cmd.Parameters.AddWithValue("@AvgCost", text_cost_AVG.Text.Trim());
                        cmd.Parameters.AddWithValue("@SalePrice", text_cost_sales.Text.Trim());
                        cmd.Parameters.AddWithValue("@Number_Retail", text_Qu.Text.Trim());
                        if (textBox_Max.Text == string.Empty)
                        {
                            cmd.Parameters.AddWithValue("@Item_MAX", 0);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Item_MAX", textBox_Max.Text.Trim());
                        }
                        cmd.ExecuteNonQuery();
                        history.EventHistory(text_Barcode.Text, history.ADD, history.NameADD, docType.ADD_recpie, this.Text);
                        msg.Alert("تم إضافة بيانات المادة بنجاح", Form_Alert.enumType.Success);
                        ClearScreen();
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
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 ADD_recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ClearScreen()
        {
            text_Barcode.Text = string.Empty;
            text_ItemName.Text = string.Empty;
            text_TAX.Text = string.Empty;
            text_cost_parchase.Text = string.Empty;
            text_cost_AVG.Text = string.Empty;
            text_cost_sales.Text = string.Empty;
            text_Qu.Text = string.Empty;
            textBox_Max.Text = string.Empty;
            text_Barcode.Focus();

        }
        private void ADD_recpie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void text_cost_parchase_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (text_TAX.Text != "" && text_cost_parchase.Text != "")
            //    {
            //        double cost_purchase1 = Convert.ToDouble(text_cost_parchase.Text);
            //        double TAX1 = Convert.ToDouble(text_TAX.Text) / 100;

            //        double sumALL = (cost_purchase1 * TAX1) + cost_purchase1;
            //        text_cost_sales.Text = sumALL.ToString();
            //    }
            //}                        
            //catch (Exception ee)
            //{
            //    con.Close();
            //    MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 ADD_recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }

        private void textBox_Max_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text_TAX_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            Grid_Item.SCR_ADD_recpie = true;
            Grid_Item ss = new Grid_Item();
            ss.ShowDialog();
            Grid_Item.SCR_ADD_recpie = false;

        }

        private void text_Barcode_KeyDown(object sender, KeyEventArgs e)
        {

                if (e.KeyCode == Keys.Enter)
                {
                    if (text_Barcode.Text != string.Empty)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("select * from " + D.DataPharmacy + "Drugs where Code=@Code", con);
                            cmd.Parameters.Add(new SqlParameter("@Code", text_Barcode.Text));
                            con.Open();
                            SqlDataReader Ra = cmd.ExecuteReader();

                            if (Ra.Read())
                            {
                                text_ItemName.Text = Ra["ItemName"].ToString();
                                text_cost_parchase.Text = Ra["CostPrice"].ToString();
                                //--- سعر البيع
                                text_cost_sales.Text = Ra["SalePrice"].ToString();
                                //------------الضريبة-------------------------------
                                text_TAX.Text = Ra["Tax"].ToString();
                                text_Qu.Text = Ra["Number_Retail"].ToString();
                                textBox_Max.Text = Ra["Item_MAX"].ToString();
                                text_cost_AVG.Text = Ra["AvgCost"].ToString();

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
    }
}
