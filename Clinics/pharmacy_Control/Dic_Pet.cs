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
    public partial class Dic_Pet : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static Dic_Pet dd;
        public Dic_Pet()
        {
            dd = this;
            InitializeComponent();
        }

        private void Dic_Pet_Load(object sender, EventArgs e)
        {
            try
            { 
            this.KeyPreview = true;
            

            if (Point_sale.point_Sale.textBox2.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى تحديد اسم المستفيد من التأمين في الشاشة السابقة لإتمام العملية", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                textBox_Name_MU.Text = Point_sale.point_Sale.textBox1.Text;
                textBox_Name_Pat.Text = Point_sale.point_Sale.textBox2.Text;
                textBox_berfore_Total.Text = Point_sale.point_Sale.lbl_cc.Text;



                SqlCommand cmd3 = new SqlCommand("select presnt_Measures,Name_Measures,number_Measures from Table_PAT where Name_Measures like @Name_Measures and Name_pat=@Name_pat", con);
                cmd3.Parameters.Add(new SqlParameter("@Name_Measures", textBox_Name_MU.Text));
                cmd3.Parameters.Add(new SqlParameter("@Name_pat", textBox_Name_Pat.Text));
                con.Open();
                SqlDataReader Ra = cmd3.ExecuteReader();
                Ra.Read();
                    textBox_ID_Orders.Text = Ra["number_Measures"].ToString();

                    if (Ra["presnt_Measures"].ToString() == "")
                    {
                        textBox_Tax_Pat.Text = "100";
                        textBox_Tax_MU.Text = "0";
                        textBox_Total_MU.Text = "0";
                        textBox_Total_Pat.Text = textBox_berfore_Total.Text;
                        textBox_After_Total.Text = textBox_berfore_Total.Text;
                        lbl_cc.Text = textBox_berfore_Total.Text;

                    }
                    else
                    {
                        textBox_Tax_Pat.Text = Ra["presnt_Measures"].ToString();


                        double TAXCOMPANY = 100 - Convert.ToDouble(Ra["presnt_Measures"].ToString());
                        textBox_Tax_MU.Text = TAXCOMPANY.ToString();

                        double TAX_Pat = Convert.ToDouble(textBox_berfore_Total.Text) * (Convert.ToDouble(textBox_Tax_Pat.Text) / 100);
                        textBox_Total_Pat.Text = TAX_Pat.ToString();

                        double TAX_MU = Convert.ToDouble(textBox_berfore_Total.Text) * (Convert.ToDouble(textBox_Tax_MU.Text) / 100);
                        textBox_Total_MU.Text = TAX_MU.ToString();

                        textBox_After_Total.Text = textBox_Total_Pat.Text;
                        lbl_cc.Text = textBox_After_Total.Text;
                    }
                Ra.Close();
                con.Close();
            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Dic_Pet", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            { 
            Point_sale.point_Sale.btn_Save_Click(sender, e);
            Point_sale.point_Sale.textBox3.Text = "";
            Point_sale.point_Sale.textBox3.Focus();
            Point_sale.point_Sale.po = 0;
            Point_sale.point_Sale.radioButton1.Checked = true;

            this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Add_Retail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Dic_Pet_Leave(object sender, EventArgs e)
        {
            try
            { 
            Point_sale.point_Sale.po = 0;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Add_Retail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Dic_Pet_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            { 
            Point_sale.point_Sale.po = 0;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 Add_Retail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Dic_Pet_KeyDown(object sender, KeyEventArgs e)
        {
            try
            { 
            if(e.KeyCode==Keys.F8)
            {
                btn_Save_Click(sender, e);
            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 Add_Retail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
