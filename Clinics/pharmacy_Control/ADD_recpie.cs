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


        public ADD_recpie()
        {
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
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
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
            if (text_Barcode.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل الباركود فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_Barcode.Focus();
                return;
            }
            if (text_ItemName.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم المادة فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_ItemName.Focus();

                    return;

            }
            if (text_cost_parchase.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل سعر الشراء فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_cost_parchase.Focus();
                    return;

            }
            if (text_TAX.Text == "")
            {
                MessageBox.Show("يرجى عد ترك حقل الضريبة فارغ ، في حال لا يوجد ضريبة يرجى ادخال قيمة 0", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_TAX.Focus();
                    return;

            }
            if (text_cost_sales.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل سعر البيع فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_cost_sales.Focus();
                    return;

            }


            else
            {

                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select Code from Drugs where Code=@Code", con);
                    cmd21.Parameters.Add(new SqlParameter("@Code", text_Barcode.Text));
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
                        MessageBox.Show("رقم الباركود موجود مسبقا ، لا يمكن إضافة مادة بنفس الرقم  " + text_Barcode.Text.Trim(), "تكرار البيانات رقم الباركود موجود مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {


                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo_insert_Drugs_reci";

                        cmd.Parameters.Add(new SqlParameter("@Code", text_Barcode.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@ItemName", text_ItemName.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@Tax", text_TAX.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@CostPrice", text_cost_parchase.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@AvgCost", text_cost_AVG.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@SalePrice", text_cost_sales.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@Number_Retail", text_Qu.Text.Trim()));
                        if(textBox_Max.Text=="")
                        {
                            cmd.Parameters.Add(new SqlParameter("@Item_MAX", 0));

                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@Item_MAX", textBox_Max.Text.Trim()));
                        }




                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم تعريف مادة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        text_Barcode.Text = "";
                        text_ItemName.Text = "";
                        text_TAX.Text = "";
                        text_cost_parchase.Text = "";
                        text_cost_AVG.Text = "";
                        text_cost_sales.Text = "";
                        text_Qu.Text = "";

                        text_Barcode.Focus();
                    }


            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 ADD_recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
            try
            {
                if (text_TAX.Text != "" && text_cost_parchase.Text != "")
                {
                    double cost_purchase1 = Convert.ToDouble(text_cost_parchase.Text);
                    double TAX1 = Convert.ToDouble(text_TAX.Text) / 100;

                    double sumALL = (cost_purchase1 * TAX1) + cost_purchase1;
                    text_cost_sales.Text = sumALL.ToString();
                }
            }                        
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 ADD_recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
}

        private void textBox_Max_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

}
