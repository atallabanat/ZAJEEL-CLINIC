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

namespace Clinics.pharmacy_Control
{
    public partial class Orders_Parchases : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        msgShow msg = new msgShow();
        OthersDataBase D = new OthersDataBase();

        //-------------------------------------
        int countRow = 0;
        string CON;
        MaskedTextBox maskedTextBox;
        int col;
        int row;
        double NrOfDays;
        //--------------------------------------
        /// <summary>
        /// --------------------
        /// </summary>
        public Orders_Parchases()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select ID_order from Drugs_NOW where ID_order='" + text_NO_order.Text.Trim() + "'", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count += 1;

                }

                con.Close();
                if (count == 1)
                {
                    MessageBox.Show("الفاتورة موجودة مسبقا ، لا يمكن إضافة فاتورة بنفس الرقم  " + text_NO_order.Text.Trim(), "تكرار البيانات الفاتورة موجودة مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                else
                {
                    if (text_NO_order.Text == "")
                    {
                        MessageBox.Show("يرجى عدم تركك حقل رقم الفاتورة فارغ", "لا يمكن إنشاء الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (text_Number_Supp.Text == "")
                    {
                        MessageBox.Show("يرجى عدم تركك حقل رقم المورد فارغ", "لا يمكن إنشاء الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (text_Name_Supp.Text == "")
                    {
                        MessageBox.Show("يرجى عدم تركك حقل اسم المورد فارغ", "لا يمكن إنشاء الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if(dataGridView1.Rows.Count==0)
                    {
                        MessageBox.Show("يرجى تعبئة الفاتورة قبل إنشاء الفاتورة", "لا يمكن إنشاء الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {



                        


                        SP_NOW();
                        SP_NOW2();



                        

                            text_NO_order.Text = "";
                            text_Name_Supp.Text = "";
                            text_Number_Supp.Text = "";


                        

                        

                        MessageBox.Show("تم إنشاء الفاتورة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridView1.Rows.Clear();
                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void SP_NOW_Delete()
        {



                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo_Delete_Drugs_NOW";

                cmd.Parameters.Add(new SqlParameter("@ID_order", text_NO_order.Text.Trim()));

                cmd.ExecuteNonQuery();
                con.Close();
            



        }
        private void SP_NOW2_Delete()
        {


                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_Delete_Drugs_NOW2";

                cmd2.Parameters.Add(new SqlParameter("@ID_order", text_NO_order.Text.Trim()));

                cmd2.ExecuteNonQuery();
                con.Close();

            

        }
        private void SP_NOW()
        {


            for (int i = 0; i < dataGridView1.Rows.Count ; ++i)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo_add_Drugs_NOW";

                cmd.Parameters.Add(new SqlParameter("@ID_order", text_NO_order.Text.Trim()));
                cmd.Parameters.Add("@Date_order", SqlDbType.NVarChar).Value = text_Date_order.Text.Trim();
                cmd.Parameters.Add("@ID_Supp", SqlDbType.NVarChar).Value = text_Number_Supp.Text.Trim();
                cmd.Parameters.Add("@Name_Supp", SqlDbType.NVarChar).Value = text_Name_Supp.Text.Trim();
                cmd.Parameters.Add("@CA_ON", SqlDbType.NVarChar).Value = CON;
                cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value;
                cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[3].Value;
                cmd.Parameters.Add("@PONAS", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[4].Value;
                cmd.Parameters.Add("@RetailPrice", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[5].Value;
                cmd.Parameters.Add("@cost_Parchase", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[6].Value;
                cmd.Parameters.Add("@cost_Sales", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[7].Value;
                cmd.Parameters.Add("@TAX", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[8].Value;
                cmd.Parameters.Add("@Total", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[9].Value;
                cmd.Parameters.Add("@Sub_Total", SqlDbType.NVarChar).Value = lbl_cc.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }

            

        }
        private void SP_NOW2()
        {


            for (int i = 0; i < dataGridView1.Rows.Count ; ++i)
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_add_Drugs_NOW2";

                cmd2.Parameters.Add(new SqlParameter("@ID_order", text_NO_order.Text.Trim()));
                cmd2.Parameters.Add("@Date_order", SqlDbType.NVarChar).Value = text_Date_order.Text.Trim();
                cmd2.Parameters.Add("@ID_Supp", SqlDbType.NVarChar).Value = text_Number_Supp.Text.Trim();
                cmd2.Parameters.Add("@Name_Supp", SqlDbType.NVarChar).Value = text_Name_Supp.Text.Trim();
                cmd2.Parameters.Add("@CA_ON", SqlDbType.NVarChar).Value = CON;
                cmd2.Parameters.Add("@Barcode", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                cmd2.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
                cmd2.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value;
                cmd2.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[3].Value;
                cmd2.Parameters.Add("@PONAS", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[4].Value;
                cmd2.Parameters.Add("@RetailPrice", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[5].Value;
                cmd2.Parameters.Add("@cost_Parchase", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[6].Value;
                cmd2.Parameters.Add("@cost_Sales", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[7].Value;
                cmd2.Parameters.Add("@TAX", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[8].Value;
                cmd2.Parameters.Add("@Total", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[9].Value;
                cmd2.Parameters.Add("@Sub_Total", SqlDbType.NVarChar).Value = lbl_cc.Text;
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            
        }
        private void SubTotal()
        {
            try
            {
                double sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    if (dataGridView1.Rows[i].Cells[9].Value != null || dataGridView1.Rows[i].Cells[9].Value !="")
                    {
                        sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);

                        lbl_cc.Text = Convert.ToDouble(sum).ToString();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Total()

        {

            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value != "" && dataGridView1.Rows[i].Cells[6].Value != "")
                    {
                        double QQ = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        double SS = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                        double TT = (QQ * SS);

                        dataGridView1.Rows[i].Cells[9].Value = TT;

                    }
                    else
                    {

                    }
                    
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void cash_CheckedChanged(object sender, EventArgs e)
        {
            CON = "Cash";
        }

        private void OnAccount_CheckedChanged(object sender, EventArgs e)
        {
            CON = "On Account";
        }

        private void text_Number_Supp_TextChanged(object sender, EventArgs e)
        {
            try
            { 
            if (text_Number_Supp.Text == "")
            {
                text_Name_Supp.Text = "";
            }
            SqlCommand na = new SqlCommand();
            na = new SqlCommand("select ID_Supplier, Name_Supplier from add_Supplier where ID_Supplier = @ID_Supplier", con);
            na.Parameters.Add(new SqlParameter("@ID_Supplier", "" + text_Number_Supp.Text + ""));

            con.Open();
            na.ExecuteNonQuery();
            SqlDataReader dr;

            dr = na.ExecuteReader();
            while (dr.Read())
            {
                string Name_Supplier = (string)dr["Name_Supplier"].ToString();
                text_Name_Supp.Text = Name_Supplier;

            }
            dr.Close();
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void dataGridView1_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
            Total();
            SubTotal();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Orders_Parchases_Load(object sender, EventArgs e)
        {
            maskedTextBox = new MaskedTextBox();
            maskedTextBox.Visible = false;
            dataGridView1.Controls.Add(maskedTextBox);
            dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            dataGridView1.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (ColName.Equals("Column2"))
                {
                    maskedTextBox.Mask = "00\\/00\\/0000";
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(Column2.Index, e.RowIndex, true);
                    maskedTextBox.Location = rect.Location;
                    maskedTextBox.Size = rect.Size;
                    maskedTextBox.Text = "";
                    maskedTextBox.Focus();

                    if (dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
                    {
                        maskedTextBox.Text = dataGridView1[Column2.Index, e.RowIndex].Value.ToString();
                    }
                    if (dataGridView1.CurrentRow.Cells[Column2.Name].Selected)
                    {
                        maskedTextBox.Visible = true;
                        maskedTextBox.Focus();

                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (maskedTextBox.Visible)
            {
                dataGridView1.CurrentRow.Cells[Column2.Name].Value = maskedTextBox.Text;
                maskedTextBox.Visible = false;
            }
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {

            if (maskedTextBox.Visible)
            {
                maskedTextBox.Focus();
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true);


                maskedTextBox.Location = rect.Location;
            }
        }

        private void Orders_Parchases_KeyDown(object sender, KeyEventArgs e)
        {
            if(maskedTextBox.Visible==true)
            {
                maskedTextBox.Focus();
            }

        }

        private void text_NO_order_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (text_NO_order.Text == "")
            //        {
            //            MessageBox.Show("لا يوجد فاتورة بهذا الرقم");
            //            return;
            //        }
            //        if (text_NO_order.Text == "'")
            //        {
            //            MessageBox.Show("لا يوجد فاتورة بهذا الرقم");
            //            return;
            //        }
            //        else
            //        {
            //            dataGridView1.Rows.Clear();
            //            text_Name_Supp.Text = "";
            //            text_Number_Supp.Text = "";



            //            SqlCommand na = new SqlCommand();
            //            na = new SqlCommand("select * from Drugs_NOW2 where id_order   = '" + text_NO_order.Text.Trim().ToString() + "'", con);

            //            con.Open();
            //            na.ExecuteNonQuery();
            //            SqlDataReader dr;

            //            dr = na.ExecuteReader();


            //            while (dr.Read())
            //            {




            //                dataGridView1.Rows.Add(dr["barCode"].ToString(), dr["ItemName"].ToString(), dr["EndDate"].ToString(), dr["Quantity"].ToString(), dr["PONAS"].ToString(), dr["RetailPrice"].ToString(), dr["cost_Parchase"].ToString(), dr["cost_Sales"].ToString(), dr["Tax"].ToString(), "", dr["ID_Supp"].ToString(), dr["Name_Supp"].ToString());


            //                Total();
            //                SubTotal();

            //            }



            //            dr.Close();
            //            con.Close();




            //            if (dataGridView1.Rows.Count > 0)
            //            {
            //                button1.Visible = false;
            //                button4.Visible = true;
            //                if(dataGridView1.Rows[0].Cells[10].Value!="" || dataGridView1.Rows[0].Cells[10].Value !=null)
            //                {
            //                    text_Number_Supp.Text = dataGridView1.Rows[0].Cells[10].Value.ToString();
            //                }
            //                if (dataGridView1.Rows[0].Cells[11].Value != "" || dataGridView1.Rows[0].Cells[11].Value != null)
            //                {
            //                    text_Name_Supp.Text = dataGridView1.Rows[0].Cells[11].Value.ToString();
            //                }
                            
                            
            //            }
            //            else
            //            {

            //                button4.Visible = false;
            //                button1.Visible = true;
            //                text_Number_Supp.Focus();
            //            }



            //        }
            //    }
            //}
            //catch (Exception ee)
            //{
            //    con.Close();
            //    MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1010 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }
        
 
        private void button4_Click(object sender, EventArgs e)
        {

            try
            {

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select ID_order from Drugs_NOW where ID_order='" + text_NO_order.Text.Trim() + "'", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count += 1;

                }

                con.Close();
                if (count >= 1)
                {


                    if (text_NO_order.Text == "")
                    {
                        MessageBox.Show("يرجى عدم تركك حقل رقم الفاتورة فارغ", "لا يمكن إنشاء الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        text_NO_order.Focus();
                        return;
                    }
                    if (text_Number_Supp.Text == "")
                    {
                        MessageBox.Show("يرجى عدم تركك حقل رقم المورد فارغ", "لا يمكن إنشاء الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        text_Number_Supp.Focus();
                        return;
                    }
                    if (text_Name_Supp.Text == "")
                    {
                        MessageBox.Show("يرجى عدم تركك حقل اسم المورد فارغ", "لا يمكن إنشاء الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        text_Name_Supp.Focus();
                        return;
                    }
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("يرجى تعبئة الفاتورة قبل إنشاء الفاتورة", "لا يمكن إنشاء الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    for (int i=0; i < dataGridView1.Rows.Count; i++ )
                    {
                        if (dataGridView1.Rows[i].Cells[2].Value == "" || dataGridView1.Rows[i].Cells[2].Value == null)
                        {
                            MessageBox.Show("يرجى عدم ترك حقل تاريخ الإنتهاء فارغ قبل إنشاء الفاتورة", "لا يمكن إنشاء الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            countRow = 0;
                            return;

                        }
                        else
                        {
                            countRow++;
                        }
                        
                    }

                    if (countRow == dataGridView1.Rows.Count)
                    {

                        countRow = 0;

                        SP_NOW_Delete();
                        SP_NOW2_Delete();

                        SP_NOW();
                        SP_NOW2();



                        text_NO_order.Text = "";
                        text_Name_Supp.Text = "";
                        text_Number_Supp.Text = "";






                        MessageBox.Show("تم حفظ الفاتورة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //بعد الحفظ استرجاع الازرار كما كانت

                        //button4.Visible = false;
                        button1.Visible = true;
                        dataGridView1.Rows.Clear();
                    }
                }


                else
                {
                    MessageBox.Show("الفاتورة غير موجودة مسبقا ، لا يمكن تعديل فاتورة غير موجودة بهذا الرقم  " + text_NO_order.Text.Trim(), "خطأ إدخال البيانات الفاتورة غير موجودة مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1011 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void btn_Exit_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {

            }
        }

        private void text_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (text_Barcode.Text == string.Empty)
                    {
                        msg.Alert("يرجى تحديد الباركود",Form_Alert.enumType.Warning);
                        return;
                    }
                   try
                   {
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("select Code,ItemName,SalePrice,Tax,CostPrice,Number_Retail from " + D.DataPharmacy + "Drugs where Code=@Code", con);
                        cmd.Parameters.Add(new SqlParameter("@Code", text_Barcode.Text));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            dataGridView1.Rows.Add(dr["Code"].ToString(), dr["ItemName"].ToString(), "", 1, 0, dr["Number_Retail"].ToString(), dr["CostPrice"].ToString(), dr["SalePrice"].ToString(), dr["Tax"].ToString(), "");


                            // Total();
                            //SubTotal();
                        }
                        dr.Close();
                        dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[0];
                        dataGridView1.Focus();
                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ex.Message, "ERROR 1115 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 
                   }
                   finally
                   {
                       con.Close();
                   }                  

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_CellValidating_1(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (ColName.Equals("Column2"))
                {
                    if (maskedTextBox.Text == string.Empty)
                    {
                        MessageBox.Show("لا يمكن ترك تاريخ الانتهاء فارغ", "عملية غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        if (maskedTextBox.Text.Length != 10)
                        {
                            MessageBox.Show("يرجى التأكد من الصيغة الصحيحة للتاريخ", "عملية غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[2];
                            dataGridView1.Focus();
                        }
                        else
                        {
                            DateTime d1 = DateTime.Now;
                            string mask = maskedTextBox.Text;


                            string yy = mask.Substring(6, 4);
                            string dd = mask.Substring(0, 2);
                            string mm = mask.Substring(3, 2);

                            DateTime d2 = Convert.ToDateTime(yy + "-" + mm + "-" + dd);


                            TimeSpan t = d1 - d2;
                            NrOfDays = t.TotalDays;


                            if (NrOfDays > 0)
                            {
                                MessageBox.Show("التاريخ المدخل منتهي الصلاحية");
                                col = 2;
                                dataGridView1.Focus();
                            }
                        }
                    }
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1009 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(index);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    col = dataGridView1.CurrentCell.ColumnIndex;
                    row = dataGridView1.CurrentCell.RowIndex;

                    if (col < dataGridView1.Columns.Count - 3)
                    {

                        if (dataGridView1.Rows[row].Cells[2].Selected == true)
                        {
                            if (dataGridView1.Rows[row].Cells[Column2.Name].Value != "")
                            {
                                if (NrOfDays < 0)
                                {
                                    dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[col + 1];
                                }
                                else
                                {
                                    MessageBox.Show("التاريخ المدخل منتهي الصلاحية");

                                }
                            }
                            else
                            {
                                MessageBox.Show("يرجى عدم ترك حقل تاريخ الانتهاء", "عملية غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[col + 1];
                        }
                    }

                    if (col == dataGridView1.Columns.Count - 3)
                    {

                        if (dataGridView1.CurrentRow.Cells[Column2.Name].Value == "" || dataGridView1.CurrentRow.Cells[2].Value == null)

                        {
                            MessageBox.Show("يرجى عدم ترك حقل التاريخ فارغ");

                            dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[2];
                            dataGridView1.Focus();
                            //maskedTextBox.Visible = true;
                            //maskedTextBox.Focus();
                        }
                        else
                        {
                            if (dataGridView1.CurrentRow.Cells[3].Value == string.Empty || dataGridView1.CurrentRow.Cells[3].Value == null)
                            {
                                MessageBox.Show("يرجى عدم ترك حقل الكمية فارغ");
                                dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[3];
                                dataGridView1.Focus();
                            }
                            else
                            {
                                dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[0];
                                MessageBox.Show("تم إضافة الدواء بنجاح");
                                text_Barcode.Focus();
                            }
                        }

                    }




                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 Orders_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}