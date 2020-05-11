using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinics.pharmacy_Control
{
    public partial class Add_Retail : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public Add_Retail()
        {
            InitializeComponent();
        }

        private void Add_Retail_Load(object sender, EventArgs e)
        {




            try
            {





                con.Open();
                SqlCommand cmd2;
                SqlDataReader dr2;
                cmd2 = new SqlCommand("select Barcode,ItemName,cost_Sales,TAX from Drugs_NOW where ItemName like @ItemName ", con);
                cmd2.Parameters.Add(new SqlParameter("@ItemName", "%" + textBox4.Text + "%"));
                cmd2.ExecuteNonQuery();
                dr2 = cmd2.ExecuteReader();
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                while (dr2.Read())
                {
                    col.Add(dr2.GetString(1));

                }
                textBox4.AutoCompleteCustomSource = col;
                dr2.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Add_Retail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



    



      

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل الباركود فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBox4.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل اسم الدواء فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {

                    SqlCommand cmd = new SqlCommand("update Drugs_NOW set RetailPrice=@RetailPrice where Barcode=@Barcode", con);

                cmd.Parameters.Add(new SqlParameter("@Barcode", textBox1.Text.Trim()));

                cmd.Parameters.Add(new SqlParameter("@RetailPrice", text_Number.Text.Trim()));



                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                    MessageBox.Show("تم إضافة التجزئة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);




                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Add_Retail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void text_Number_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Add_Retail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    con.Open();
                    SqlCommand cmd2;
                    SqlDataReader dr2;
                    cmd2 = new SqlCommand("select Barcode,ItemName,cost_Sales,TAX from Drugs_NOW where ItemName like @ItemName", con);
                    cmd2.Parameters.Add(new SqlParameter("@ItemName", "%" + textBox4.Text + "%"));
                    cmd2.ExecuteNonQuery();
                    dr2 = cmd2.ExecuteReader();
                    dr2.Read();



                    textBox1.Text = dr2[0].ToString();


                    con.Close();


                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 Add_Retail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
