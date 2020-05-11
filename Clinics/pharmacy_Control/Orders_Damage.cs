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
    public partial class Orders_Damage : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        MaskedTextBox maskedTextBox;

        public Orders_Damage()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SubTotal()
        {
            try
            {
                double sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);

                    lbl_cc.Text = Convert.ToDouble(sum).ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Orders_Damage", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Total()

        {

            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[4].Value != "" && dataGridView1.Rows[i].Cells[5].Value != "")
                    {
                        double QQ = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                        double SS = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        double TT = (QQ * SS);

                        dataGridView1.Rows[i].Cells[8].Value = TT;

                    }
                    else
                    {

                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Orders_Damage", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
            private void text_Barcode_KeyDown(object sender, KeyEventArgs e)
            {
            try
            {


                if (e.KeyCode == Keys.Enter)
                {
                    if (text_Barcode.Text == "")
                    {
                        MessageBox.Show("لا يوجد منتج بهذا الباركود");
                        return;
                    }
                    if (text_Barcode.Text == "'")
                    {
                        MessageBox.Show("لا يوجد منتج بهذا الباركود");
                        return;
                    }
                    else
                    {


                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ID_order,ItemName,cost_Sales,TAX,cost_Parchase,EndDate,Quantity from Drugs_NOW where Barcode   = '" + text_Barcode.Text.Trim().ToString() + "'", con);
                        //na.Parameters.Add(new SqlParameter("@Code", "%" + textBox3.Text + "%"));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();
                        while (dr.Read())
                        {



                            dataGridView1.Rows.Add(dr["Barcode"].ToString(),dr["ID_order"].ToString(), dr["ItemName"].ToString(),dr["EndDate"].ToString(), dr["Quantity"].ToString(), dr["cost_Parchase"].ToString(), dr["cost_Sales"].ToString(), dr["TAX"].ToString(), "");
                            text_Barcode.Text = "";

                            Total();
                            SubTotal();
                        }
                        dr.Close();
                        con.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Orders_Damage", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select ID_order from Orders_Damage where ID_order=@ID_order", con);
            cmd21.Parameters.Add(new SqlParameter("@ID_order", text_NO_order.Text.Trim()));
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
                    MessageBox.Show("الفاتورة موجودة مسبقا ، لا يمكن إضافة فاتورة متلفة بنفس الرقم  " + text_NO_order.Text.Trim(), "تكرار البيانات الفاتورة موجودة مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                else
                {
                    if (text_NO_order.Text == "")
                    {
                        MessageBox.Show("يرجى عدم تركك حقل رقم السند فارغ", "لا يمكن إنشاء الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "dbo_insert_Orders_Damage";

                            cmd.Parameters.Add(new SqlParameter("@ID_order", text_NO_order.Text.Trim()));
                            cmd.Parameters.Add("@Date_order", SqlDbType.NVarChar).Value = text_Date_order.Text.Trim();
                            cmd.Parameters.Add("@Number_order", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
                            cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                            cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value;
                            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[3].Value;
                            cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[4].Value;
                            cmd.Parameters.Add("@cost_Parchase", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[5].Value;
                            cmd.Parameters.Add("@cost_Sales", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[6].Value;
                            cmd.Parameters.Add("@TAX", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[7].Value;
                            cmd.Parameters.Add("@Total", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[8].Value;
                            cmd.Parameters.Add("@Sub_Total", SqlDbType.NVarChar).Value = lbl_cc.Text;

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            text_NO_order.Text = "";




                            con.Open();
                            SqlCommand cmd2 = new SqlCommand("select Quantity from Drugs_NOW where Barcode=@Barcode and ID_order=@ID_order ", con);
                        cmd2.Parameters.Add(new SqlParameter("@Barcode", dataGridView1.Rows[i].Cells[0].Value));
                        cmd2.Parameters.Add(new SqlParameter("@ID_order", dataGridView1.Rows[i].Cells[1].Value));
                            SqlDataReader dr2;
                            dr2 = cmd2.ExecuteReader();
                            dr2.Read();

                            double Quntity =Convert.ToDouble( dr2["Quantity"].ToString());
                            double QuntityNow =Convert.ToDouble( dataGridView1.Rows[i].Cells[4].Value);
                            double Qun = Quntity - QuntityNow;
                            dr2.Close();
                            con.Close();



                            SqlCommand cmd4 = new SqlCommand("update Drugs_NOW set Quantity=@Quantity where Barcode=@Barcode and ID_order=@ID_order", con);
                        cmd4.Parameters.Add(new SqlParameter("@Barcode", dataGridView1.Rows[i].Cells[0].Value));
                        cmd4.Parameters.Add(new SqlParameter("@ID_order", dataGridView1.Rows[i].Cells[1].Value));


                        cmd4.Parameters.Add(new SqlParameter("@Quantity", Qun.ToString()));


                            con.Open();
                            cmd4.ExecuteNonQuery();
                            con.Close();








                        }
                        MessageBox.Show("تم إتلاف الفاتورة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridView1.Rows.Clear();
                    }
                }
        }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 Orders_Damage", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

}

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
            Total();
            SubTotal();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 Orders_Damage", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Orders_Damage_Load(object sender, EventArgs e)
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
            maskedTextBox.Mask = "0000/00/00";
            Rectangle rect = dataGridView1.GetCellDisplayRectangle(3, e.RowIndex, true);
            maskedTextBox.Location = rect.Location;
            maskedTextBox.Size = rect.Size;
            maskedTextBox.Text = "";

            if (dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
            {
                maskedTextBox.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            }
            if (dataGridView1.CurrentRow.Cells[3].Selected)
            {
                maskedTextBox.Focus();
                maskedTextBox.Visible = true;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (maskedTextBox.Visible)
            {
                dataGridView1.CurrentRow.Cells[3].Value = maskedTextBox.Text;
                maskedTextBox.Visible = false;
            }
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (maskedTextBox.Visible)
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true);


                maskedTextBox.Location = rect.Location;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
