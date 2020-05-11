using Clinics.report;
using Clinics.UserControls;
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

namespace Clinics
{
    public partial class recipe : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static recipe recipe1;

        public recipe()
        {
            recipe1 = this;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void recipe_Load(object sender, EventArgs e)
        {
            try
            { 
            // TODO: This line of code loads data into the 'clinicDataSet.Drugs' table. You can move, or remove it, as needed.
            textBox1.Text = Diagnosis.ss;
            string barcode = textBox1.Text;

            try
            {
                Zen.Barcode.Code128BarcodeDraw brcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = brcode.Draw(barcode, 60);
            }
            catch (Exception ee)
            {

            }


                //-------- select ------------------------------------------------------//

                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select ID_visit,Medication1,Medication2,Medication3,Medication4,Medication5,Medication6,Medication7,Medication8,Medication9,Medication10,dose1,dose2,dose3,dose4,dose5,dose6,dose7,dose8,dose9,dose10,ML1,ML2,ML3,ML4,ML5,ML6,ML7,ML8,ML9,ML10,count1,count2,count3,count4,count5,count6,count7,count8,count9,count10,Deay1,Deay2,Deay3,Deay4,Deay5,Deay6,Deay7,Deay8,Deay9,Deay10 from Table_visit_patient where ID_visit=@ID_visit", con);
                na.Parameters.Add(new SqlParameter("@ID_visit", textBox1.Text));
                con.Open();
                SqlDataReader dr;

                dr = na.ExecuteReader();
                while (dr.Read())
                {

                    string Medication1 = dr["Medication1"].ToString();
                    textBox4.Text = Medication1;

                    string Medication2 = dr["Medication2"].ToString();
                    textBox2.Text = Medication2;

                    string Medication3 = dr["Medication3"].ToString();
                    textBox3.Text = Medication3;

                    string Medication4 = dr["Medication4"].ToString();
                    textBox5.Text = Medication4;

                    string Medication5 = dr["Medication5"].ToString();
                    textBox6.Text = Medication5;

                    string Medication6 = dr["Medication6"].ToString();
                    textBox7.Text = Medication6;

                    string Medication7 = dr["Medication7"].ToString();
                    textBox8.Text = Medication7;

                    string Medication8 = dr["Medication8"].ToString();
                    textBox9.Text = Medication8;

                    string Medication9 = dr["Medication9"].ToString();
                    textBox10.Text = Medication9;

                    string Medication10 = dr["Medication10"].ToString();
                    textBox11.Text = Medication10;

                    string dose1 = dr["dose1"].ToString();
                    text_dose1.Text = dose1;

                    string dose2 = dr["dose2"].ToString();
                    text_dose2.Text = dose2;

                    string dose3 = dr["dose3"].ToString();
                    text_dose3.Text = dose3;

                    string dose4 = dr["dose4"].ToString();
                    text_dose4.Text = dose4;


                    string dose5 = dr["dose5"].ToString();
                    text_dose5.Text = dose5;


                    string dose6 = dr["dose6"].ToString();
                    text_dose6.Text = dose6;


                    string dose7 = dr["dose7"].ToString();
                    text_dose7.Text = dose7;


                    string dose8 = dr["dose8"].ToString();
                    text_dose8.Text = dose8;


                    string dose9 = dr["dose9"].ToString();
                    text_dose9.Text = dose9;


                    string dose10 = dr["dose10"].ToString();
                    text_dose10.Text = dose10;

                    string ML1 = dr["ML1"].ToString();
                    combo_A_1.Text = ML1;

                    string ML2 = dr["ML2"].ToString();
                    combo_A_2.Text = ML2;

                    string ML3 = dr["ML3"].ToString();
                    combo_A_3.Text = ML3;

                    string ML4 = dr["ML4"].ToString();
                    combo_A_4.Text = ML4;

                    string ML5 = dr["ML5"].ToString();
                    combo_A_5.Text = ML5;

                    string ML6 = dr["ML6"].ToString();
                    combo_A_6.Text = ML6;

                    string ML7 = dr["ML7"].ToString();
                    combo_A_7.Text = ML7;

                    string ML8 = dr["ML8"].ToString();
                    combo_A_8.Text = ML8;

                    string ML9 = dr["ML9"].ToString();
                    combo_A_9.Text = ML9;

                    string ML10 = dr["ML10"].ToString();
                    combo_A_10.Text = ML10;

                    string count1 = dr["count1"].ToString();
                    combo_N_1.Text = count1;

                    string count2 = dr["count2"].ToString();
                    combo_N_2.Text = count2;

                    string count3 = dr["count3"].ToString();
                    combo_N_3.Text = count3;

                    string count4 = dr["count4"].ToString();
                    combo_N_4.Text = count4;

                    string count5 = dr["count5"].ToString();
                    combo_N_5.Text = count5;

                    string count6 = dr["count6"].ToString();
                    combo_N_6.Text = count6;

                    string count7 = dr["count7"].ToString();
                    combo_N_7.Text = count7;

                    string count8 = dr["count8"].ToString();
                    combo_N_8.Text = count8;

                    string count9 = dr["count9"].ToString();
                    combo_N_9.Text = count9;

                    string count10 = dr["count10"].ToString();
                    combo_N_10.Text = count10;

                    string Deay1 = dr["Deay1"].ToString();
                    combo_D_1.Text = Deay1;

                    string Deay2 = dr["Deay2"].ToString();
                    combo_D_2.Text = Deay2;

                    string Deay3 = dr["Deay3"].ToString();
                    combo_D_3.Text = Deay3;

                    string Deay4 = dr["Deay4"].ToString();
                    combo_D_4.Text = Deay4;

                    string Deay5 = dr["Deay5"].ToString();
                    combo_D_5.Text = Deay5;

                    string Deay6 = dr["Deay6"].ToString();
                    combo_D_6.Text = Deay6;

                    string Deay7 = dr["Deay7"].ToString();
                    combo_D_7.Text = Deay7;

                    string Deay8 = dr["Deay8"].ToString();
                    combo_D_8.Text = Deay8;

                    string Deay9 = dr["Deay9"].ToString();
                    combo_D_9.Text = Deay9;

                    string Deay10 = dr["Deay10"].ToString();
                    combo_D_10.Text = Deay10;


                }
                dr.Close();
                con.Close();



                //-----------------------------------------------------------------------//




                if (textBox4.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox5.Text == "" && textBox6.Text == "" && textBox7.Text == "" && textBox8.Text == "" && textBox9.Text == "" && textBox10.Text == "" && textBox11.Text == "")
                {
                    button2.Enabled = true;
                }
                else
                {

                    button2.Enabled = false;

                }







                //----------------------------------------


                con.Open();
            SqlCommand cmd2;
            SqlDataReader dr2;
            cmd2 = new SqlCommand("select ItemName from Drugs_NOW", con);
            cmd2.ExecuteNonQuery();
            dr2 = cmd2.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while (dr2.Read())
            {
                col.Add(dr2.GetString(0));

            }
            textBox4.AutoCompleteCustomSource = col;
            textBox2.AutoCompleteCustomSource = col;
            textBox3.AutoCompleteCustomSource = col;
            textBox5.AutoCompleteCustomSource = col;
            textBox6.AutoCompleteCustomSource = col;
            textBox7.AutoCompleteCustomSource = col;
            textBox8.AutoCompleteCustomSource = col;
            textBox9.AutoCompleteCustomSource = col;
            textBox10.AutoCompleteCustomSource = col;
            textBox11.AutoCompleteCustomSource = col;


            dr2.Close();
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox4.Text == "")
                {

                }
                else
                {
                    try
                    {

                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                        na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox4.Text + ""));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();

                        dr.Read();

                        Code1 = dr["Barcode"].ToString();
                        CostPrice1 = dr["cost_Parchase"].ToString();
                        SalePrice1 = dr["cost_Sales"].ToString();
                        Tax1 = dr["TAX"].ToString();
                        ItemName1 = dr["ItemName"].ToString();

                        //uCode1 = dr["Barcode"].ToString();
                        //uCostPrice1 = dr["cost_Parchase"].ToString();
                        //uSalePrice1 = dr["cost_Sales"].ToString();
                        //uTax1 = dr["TAX"].ToString();
                        //uItemName1 = dr["ItemName"].ToString();

                        dr.Close();
                        con.Close();

                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                        textBox4.Text = "";
                        MessageBox.Show(ee.Message);
                    }
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox2.Text == "")
                {

                }
                else
                {
                    try
                    {
                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                        na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox2.Text + ""));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();

                        dr.Read();

                        Code2 = dr["Barcode"].ToString();
                        CostPrice2 = dr["cost_Parchase"].ToString();
                        SalePrice2 = dr["cost_Sales"].ToString();
                        Tax2 = dr["TAX"].ToString();
                        ItemName2 = dr["ItemName"].ToString();


                        //uCode2 = dr["Barcode"].ToString();
                        //uCostPrice2 = dr["cost_Parchase"].ToString();
                        //uSalePrice2 = dr["cost_Sales"].ToString();
                        //uTax2 = dr["TAX"].ToString();
                        //uItemName2 = dr["ItemName"].ToString();

                        dr.Close();
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                        textBox2.Text = "";
                        MessageBox.Show(ee.Message);
                    }
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox3.Text == "")
                {

                }
                else
                {
                    try
                    {
                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                        na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox3.Text + ""));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();

                        dr.Read();

                        Code3 = dr["Barcode"].ToString();
                        CostPrice3 = dr["cost_Parchase"].ToString();
                        SalePrice3 = dr["cost_Sales"].ToString();
                        Tax3 = dr["TAX"].ToString();
                        ItemName3 = dr["ItemName"].ToString();


                        //uCode3 = dr["Barcode"].ToString();
                        //uCostPrice3 = dr["cost_Parchase"].ToString();
                        //uSalePrice3 = dr["cost_Sales"].ToString();
                        //uTax3 = dr["TAX"].ToString();
                        //uItemName3 = dr["ItemName"].ToString();
                        dr.Close();
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                        textBox3.Text = "";
                        MessageBox.Show(ee.Message);
                    }
                    }
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox5.Text == "")
                {

                }
                else
                {
                    try
                    {
                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                        na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox5.Text + ""));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();

                        dr.Read();

                        Code5 = dr["Barcode"].ToString();
                        CostPrice5 = dr["cost_Parchase"].ToString();
                        SalePrice5 = dr["cost_Sales"].ToString();
                        Tax5 = dr["TAX"].ToString();
                        ItemName5 = dr["ItemName"].ToString();


                        //uCode5 = dr["Barcode"].ToString();
                        //uCostPrice5 = dr["cost_Parchase"].ToString();
                        //uSalePrice5 = dr["cost_Sales"].ToString();
                        //uTax5 = dr["TAX"].ToString();
                        //uItemName5 = dr["ItemName"].ToString();
                        dr.Close();
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                        textBox5.Text = "";
                        MessageBox.Show(ee.Message);
                    }
                }

            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox6.Text == "")
                {

                }
                else
                {
                    try
                    {
                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                        na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox6.Text + ""));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();

                        dr.Read();

                        Code6 = dr["Barcode"].ToString();
                        CostPrice6 = dr["cost_Parchase"].ToString();
                        SalePrice6 = dr["cost_Sales"].ToString();
                        Tax6 = dr["TAX"].ToString();
                        ItemName6 = dr["ItemName"].ToString();


                        //uCode6 = dr["Barcode"].ToString();
                        //uCostPrice6 = dr["cost_Parchase"].ToString();
                        //uSalePrice6 = dr["cost_Sales"].ToString();
                        //uTax6 = dr["TAX"].ToString();
                        //uItemName6 = dr["ItemName"].ToString();
                        dr.Close();
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                        textBox6.Text = "";
                        MessageBox.Show(ee.Message);
                    }
                }
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox7.Text == "")
                {

                }
                else
                {
                    try
                    {
                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                        na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox7.Text + ""));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();

                        dr.Read();

                        Code7 = dr["Barcode"].ToString();
                        CostPrice7 = dr["cost_Parchase"].ToString();
                        SalePrice7 = dr["cost_Sales"].ToString();
                        Tax7 = dr["TAX"].ToString();
                        ItemName7 = dr["ItemName"].ToString();


                        //uCode7 = dr["Barcode"].ToString();
                        //uCostPrice7 = dr["cost_Parchase"].ToString();
                        //uSalePrice7 = dr["cost_Sales"].ToString();
                        //uTax7 = dr["TAX"].ToString();
                        //uItemName7 = dr["ItemName"].ToString();
                        dr.Close();
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                        textBox7.Text = "";
                        MessageBox.Show(ee.Message);
                    }
                }
                
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox8.Text == "")
                {

                }
                else
                {
                    try
                    {


                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                        na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox8.Text + ""));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();

                        dr.Read();

                        Code8 = dr["Barcode"].ToString();
                        CostPrice8 = dr["cost_Parchase"].ToString();
                        SalePrice8 = dr["cost_Sales"].ToString();
                        Tax8 = dr["TAX"].ToString();
                        ItemName8 = dr["ItemName"].ToString();


                        //uCode8 = dr["Barcode"].ToString();
                        //uCostPrice8 = dr["cost_Parchase"].ToString();
                        //uSalePrice8 = dr["cost_Sales"].ToString();
                        //uTax8 = dr["TAX"].ToString();
                        //uItemName8 = dr["ItemName"].ToString();
                        dr.Close();
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                        textBox8.Text = "";
                        MessageBox.Show(ee.Message);
                    }
                }
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox9.Text == "")
                {

                }
                else
                {
                    try
                    {
                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                        na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox9.Text + ""));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();

                        dr.Read();

                        Code9 = dr["Barcode"].ToString();
                        CostPrice9 = dr["cost_Parchase"].ToString();
                        SalePrice9 = dr["cost_Sales"].ToString();
                        Tax9 = dr["TAX"].ToString();
                        ItemName9 = dr["ItemName"].ToString();


                        //uCode9 = dr["Barcode"].ToString();
                        //uCostPrice9 = dr["cost_Parchase"].ToString();
                        //uSalePrice9 = dr["cost_Sales"].ToString();
                        //uTax9 = dr["TAX"].ToString();
                        //uItemName9 = dr["ItemName"].ToString();
                        dr.Close();
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                        textBox9.Text = "";
                        MessageBox.Show(ee.Message);
                    }
                    }
                
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox10.Text == "")
                {

                }
                else
                {
                    try
                    {
                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                        na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox10.Text + ""));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();

                        dr.Read();

                        Code10 = dr["Barcode"].ToString();
                        CostPrice10 = dr["cost_Parchase"].ToString();
                        SalePrice10 = dr["cost_Sales"].ToString();
                        Tax10 = dr["TAX"].ToString();
                        ItemName10 = dr["ItemName"].ToString();


                        //uCode10 = dr["Barcode"].ToString();
                        //uCostPrice10 = dr["cost_Parchase"].ToString();
                        //uSalePrice10 = dr["cost_Sales"].ToString();
                        //uTax10 = dr["TAX"].ToString();
                        //uItemName10 = dr["ItemName"].ToString();
                        dr.Close();
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                        textBox10.Text = "";
                        MessageBox.Show(ee.Message);
                    }
                }

            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox11.Text == "")
                {
                }
                else
                {

                    try
                    {
                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                        na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox11.Text + ""));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();

                        dr.Read();

                        Code4 = dr["Barcode"].ToString();
                        CostPrice4 = dr["cost_Parchase"].ToString();
                        SalePrice4 = dr["cost_Sales"].ToString();
                        Tax4 = dr["TAX"].ToString();
                        ItemName4 = dr["ItemName"].ToString();


                        //uCode4 = dr["Barcode"].ToString();
                        //uCostPrice4 = dr["cost_Parchase"].ToString();
                        //uSalePrice4 = dr["cost_Sales"].ToString();
                        //uTax4 = dr["TAX"].ToString();
                        //uItemName4 = dr["ItemName"].ToString();
                        dr.Close();
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                        textBox11.Text = "";
                        MessageBox.Show(ee.Message);
                    }
                    }
                
            }
        }

        public void sa1()
        {
            try
            { 
            if (textBox4.Text != "")
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_recip_add";

                cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
                cmd2.Parameters.Add(new SqlParameter("@Code", Code1));
                cmd2.Parameters.Add(new SqlParameter("@ItemName", ItemName1));
                cmd2.Parameters.Add(new SqlParameter("@Tax", Tax1));
                cmd2.Parameters.Add(new SqlParameter("@CostPrice", CostPrice1));
                cmd2.Parameters.Add(new SqlParameter("@SalePrice", SalePrice1));
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void sa2()
        {
            try
            { 
            if (textBox2.Text != "")
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_recip_add";

                cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
                cmd2.Parameters.Add(new SqlParameter("@Code", Code2));
                cmd2.Parameters.Add(new SqlParameter("@ItemName", ItemName2));
                cmd2.Parameters.Add(new SqlParameter("@Tax", Tax2));
                cmd2.Parameters.Add(new SqlParameter("@CostPrice", CostPrice2));
                cmd2.Parameters.Add(new SqlParameter("@SalePrice", SalePrice2));

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        

        public void sa3()
        {
            try
            { 
            if (textBox3.Text != "")
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_recip_add";

                cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
                cmd2.Parameters.Add(new SqlParameter("@Code", Code3));
                cmd2.Parameters.Add(new SqlParameter("@ItemName", ItemName3));
                cmd2.Parameters.Add(new SqlParameter("@Tax", Tax3));
                cmd2.Parameters.Add(new SqlParameter("@CostPrice", CostPrice3));
                cmd2.Parameters.Add(new SqlParameter("@SalePrice", SalePrice3));

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void sa4()
        {
            try
            { 
            if (textBox5.Text != "")
            {

                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_recip_add";

                cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
                cmd2.Parameters.Add(new SqlParameter("@Code", Code5));
                cmd2.Parameters.Add(new SqlParameter("@ItemName", ItemName5));
                cmd2.Parameters.Add(new SqlParameter("@Tax", Tax5));
                cmd2.Parameters.Add(new SqlParameter("@CostPrice", CostPrice5));
                cmd2.Parameters.Add(new SqlParameter("@SalePrice", SalePrice5));

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void sa5()
        {
            try
            { 
            if (textBox6.Text != "")
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_recip_add";

                cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
                cmd2.Parameters.Add(new SqlParameter("@Code", Code6));
                cmd2.Parameters.Add(new SqlParameter("@ItemName", ItemName6));
                cmd2.Parameters.Add(new SqlParameter("@Tax", Tax6));
                cmd2.Parameters.Add(new SqlParameter("@CostPrice", CostPrice6));
                cmd2.Parameters.Add(new SqlParameter("@SalePrice", SalePrice6));

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void sa6()
        {
            try
            { 
            if (textBox7.Text != "")
            {

                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_recip_add";

                cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
                cmd2.Parameters.Add(new SqlParameter("@Code", Code7));
                cmd2.Parameters.Add(new SqlParameter("@ItemName", ItemName7));
                cmd2.Parameters.Add(new SqlParameter("@Tax", Tax7));
                cmd2.Parameters.Add(new SqlParameter("@CostPrice", CostPrice7));
                cmd2.Parameters.Add(new SqlParameter("@SalePrice", SalePrice7));

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void sa7()
        {
            try
            { 
            if (textBox8.Text != "")
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_recip_add";

                cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
                cmd2.Parameters.Add(new SqlParameter("@Code", Code8));
                cmd2.Parameters.Add(new SqlParameter("@ItemName", ItemName8));
                cmd2.Parameters.Add(new SqlParameter("@Tax", Tax8));
                cmd2.Parameters.Add(new SqlParameter("@CostPrice", CostPrice8));
                cmd2.Parameters.Add(new SqlParameter("@SalePrice", SalePrice8));

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void sa8()
        {
            try
            { 
            if (textBox9.Text != "")
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_recip_add";

                cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
                cmd2.Parameters.Add(new SqlParameter("@Code", Code9));
                cmd2.Parameters.Add(new SqlParameter("@ItemName", ItemName9));
                cmd2.Parameters.Add(new SqlParameter("@Tax", Tax9));
                cmd2.Parameters.Add(new SqlParameter("@CostPrice", CostPrice9));
                cmd2.Parameters.Add(new SqlParameter("@SalePrice", SalePrice9));

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

            }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1009 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void sa9()
        {
            try
            { 
            if (textBox10.Text != "")
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_recip_add";

                cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
                cmd2.Parameters.Add(new SqlParameter("@Code", Code10));
                cmd2.Parameters.Add(new SqlParameter("@ItemName", ItemName10));
                cmd2.Parameters.Add(new SqlParameter("@Tax", Tax10));
                cmd2.Parameters.Add(new SqlParameter("@CostPrice", CostPrice10));
                cmd2.Parameters.Add(new SqlParameter("@SalePrice", SalePrice10));

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1010 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void sa10()
        {
            try
            {
            if (textBox11.Text != "")
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "dbo_recip_add";

                cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
                cmd2.Parameters.Add(new SqlParameter("@Code", Code4));
                cmd2.Parameters.Add(new SqlParameter("@ItemName", ItemName4));
                cmd2.Parameters.Add(new SqlParameter("@Tax", Tax4));
                cmd2.Parameters.Add(new SqlParameter("@CostPrice", CostPrice4));
                cmd2.Parameters.Add(new SqlParameter("@SalePrice", SalePrice4));

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1011 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void dose()
        {
            try
            { 
            SqlCommand cmd = new SqlCommand("update Table_visit_patient set dose1=@dose1,dose2=@dose2,dose3=@dose3,dose4=@dose4,dose5=@dose5,dose6=@dose6,dose7=@dose7,dose8=@dose8,dose9=@dose9,dose10=@dose10 where ID_visit=" + textBox1.Text.Trim() + "", con);
            cmd.Parameters.Add(new SqlParameter("@dose1", text_dose1.Text));
            cmd.Parameters.Add(new SqlParameter("@dose2", text_dose2.Text));
            cmd.Parameters.Add(new SqlParameter("@dose3", text_dose3.Text));
            cmd.Parameters.Add(new SqlParameter("@dose4", text_dose4.Text));
            cmd.Parameters.Add(new SqlParameter("@dose5", text_dose5.Text));
            cmd.Parameters.Add(new SqlParameter("@dose6", text_dose6.Text));
            cmd.Parameters.Add(new SqlParameter("@dose7", text_dose7.Text));
            cmd.Parameters.Add(new SqlParameter("@dose8", text_dose8.Text));
            cmd.Parameters.Add(new SqlParameter("@dose9", text_dose9.Text));
            cmd.Parameters.Add(new SqlParameter("@dose10", text_dose10.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1012 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void ML()
        {
            try
            { 
            SqlCommand cmd = new SqlCommand("update Table_visit_patient set ML1=@ML1,ML2=@ML2,ML3=@ML3,ML4=@ML4,ML5=@ML5,ML6=@ML6,ML7=@ML7,ML8=@ML8,ML9=@ML9,ML10=@ML10 where ID_visit=" + textBox1.Text.Trim() + "", con);
            cmd.Parameters.Add(new SqlParameter("@ML1", combo_A_1.Text));
            cmd.Parameters.Add(new SqlParameter("@ML2", combo_A_2.Text));
            cmd.Parameters.Add(new SqlParameter("@ML3", combo_A_3.Text));
            cmd.Parameters.Add(new SqlParameter("@ML4", combo_A_4.Text));
            cmd.Parameters.Add(new SqlParameter("@ML5", combo_A_5.Text));
            cmd.Parameters.Add(new SqlParameter("@ML6", combo_A_6.Text));
            cmd.Parameters.Add(new SqlParameter("@ML7", combo_A_7.Text));
            cmd.Parameters.Add(new SqlParameter("@ML8", combo_A_8.Text));
            cmd.Parameters.Add(new SqlParameter("@ML9", combo_A_9.Text));
            cmd.Parameters.Add(new SqlParameter("@ML10", combo_A_10.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1013 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void count()
        {
            try
            { 
            SqlCommand cmd = new SqlCommand("update Table_visit_patient set count1=@count1,count2=@count2,count3=@count3,count4=@count4,count5=@count5,count6=@count6,count7=@count7,count8=@count8,count9=@count9,count10=@count10 where ID_visit=" + textBox1.Text.Trim() + "", con);
            cmd.Parameters.Add(new SqlParameter("@count1", combo_N_1.Text));
            cmd.Parameters.Add(new SqlParameter("@count2", combo_N_2.Text));
            cmd.Parameters.Add(new SqlParameter("@count3", combo_N_3.Text));
            cmd.Parameters.Add(new SqlParameter("@count4", combo_N_4.Text));
            cmd.Parameters.Add(new SqlParameter("@count5", combo_N_5.Text));
            cmd.Parameters.Add(new SqlParameter("@count6", combo_N_6.Text));
            cmd.Parameters.Add(new SqlParameter("@count7", combo_N_7.Text));
            cmd.Parameters.Add(new SqlParameter("@count8", combo_N_8.Text));
            cmd.Parameters.Add(new SqlParameter("@count9", combo_N_9.Text));
            cmd.Parameters.Add(new SqlParameter("@count10", combo_N_10.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1014 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Daey()
        {
            try
            { 
            SqlCommand cmd = new SqlCommand("update Table_visit_patient set Deay1=@Deay1,Deay2=@Deay2,Deay3=@Deay3,Deay4=@Deay4,Deay5=@Deay5,Deay6=@Deay6,Deay7=@Deay7,Deay8=@Deay8,Deay9=@Deay9,Deay10=@Deay10 where ID_visit=" + textBox1.Text.Trim() + "", con);

            cmd.Parameters.Add(new SqlParameter("@Deay1", combo_D_1.Text));
            cmd.Parameters.Add(new SqlParameter("@Deay2", combo_D_2.Text));
            cmd.Parameters.Add(new SqlParameter("@Deay3", combo_D_3.Text));
            cmd.Parameters.Add(new SqlParameter("@Deay4", combo_D_4.Text));
            cmd.Parameters.Add(new SqlParameter("@Deay5", combo_D_5.Text));
            cmd.Parameters.Add(new SqlParameter("@Deay6", combo_D_6.Text));
            cmd.Parameters.Add(new SqlParameter("@Deay7", combo_D_7.Text));
            cmd.Parameters.Add(new SqlParameter("@Deay8", combo_D_8.Text));
            cmd.Parameters.Add(new SqlParameter("@Deay9", combo_D_9.Text));
            cmd.Parameters.Add(new SqlParameter("@Deay10", combo_D_10.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1015 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("update Table_visit_patient set Medication1=@Medication1,Medication2=@Medication2,Medication3=@Medication3,Medication4=@Medication4,Medication5=@Medication5,Medication6=@Medication6,Medication7=@Medication7,Medication8=@Medication8,Medication9=@Medication9,Medication10=@Medication10 where ID_visit=@ID_visit", con);
                cmd.Parameters.Add(new SqlParameter("@ID_visit", textBox1.Text));

                cmd.Parameters.Add(new SqlParameter("@Medication1", textBox4.Text)) ;
                cmd.Parameters.Add(new SqlParameter("@Medication2", textBox2.Text)) ;
                cmd.Parameters.Add(new SqlParameter("@Medication3", textBox3.Text)) ;
                cmd.Parameters.Add(new SqlParameter("@Medication4", textBox5.Text));
                cmd.Parameters.Add(new SqlParameter("@Medication5", textBox6.Text));
                cmd.Parameters.Add(new SqlParameter("@Medication6", textBox7.Text));
                cmd.Parameters.Add(new SqlParameter("@Medication7", textBox8.Text));
                cmd.Parameters.Add(new SqlParameter("@Medication8", textBox9.Text));
                cmd.Parameters.Add(new SqlParameter("@Medication9", textBox10.Text));
                cmd.Parameters.Add(new SqlParameter("@Medication10", textBox11.Text));




            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            dose();
            ML();
            count();
            Daey();

            sa1();
            sa2();
            sa3();
            sa4();
            sa5();
            sa6();
            sa7();
            sa8();
            sa9();
            sa10();










            MessageBox.Show("تم إضافة الوصفة الطبية بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = false;

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1016 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        //---------- متغيرات جلب اسماء الادوية وضريبتها ---------------//
        string Code1;
        string Code2;
        string Code3;
        string Code4;
        string Code5;
        string Code6;
        string Code7;
        string Code8;
        string Code9;
        string Code10;

        

        string ItemName1;
        string ItemName2;
        string ItemName3;
        string ItemName4;
        string ItemName5;
        string ItemName6;
        string ItemName7;
        string ItemName8;
        string ItemName9;
        string ItemName10;

        string Tax1;
        string Tax2;
        string Tax3;
        string Tax4;
        string Tax5;
        string Tax6;
        string Tax7;
        string Tax8;
        string Tax9;
        string Tax10;

        string CostPrice1;
        string CostPrice2;
        string CostPrice3;
        string CostPrice4;
        string CostPrice5;
        string CostPrice6;
        string CostPrice7;
        string CostPrice8;
        string CostPrice9;
        string CostPrice10;

        string SalePrice1;
        string SalePrice2;
        string SalePrice3;
        string SalePrice4;
        string SalePrice5;
        string SalePrice6;
        string SalePrice7;
        string SalePrice8;
        string SalePrice9;
        string SalePrice10;




        //string uCode1;
        //string uCode2;
        //string uCode3;
        //string uCode4;
        //string uCode5;
        //string uCode6;
        //string uCode7;
        //string uCode8;
        //string uCode9;
        //string uCode10;



        //string uItemName1;
        //string uItemName2;
        //string uItemName3;
        //string uItemName4;
        //string uItemName5;
        //string uItemName6;
        //string uItemName7;
        //string uItemName8;
        //string uItemName9;
        //string uItemName10;

        //string uTax1;
        //string uTax2;
        //string uTax3;
        //string uTax4;
        //string uTax5;
        //string uTax6;
        //string uTax7;
        //string uTax8;
        //string uTax9;
        //string uTax10;

        //string uCostPrice1;
        //string uCostPrice2;
        //string uCostPrice3;
        //string uCostPrice4;
        //string uCostPrice5;
        //string uCostPrice6;
        //string uCostPrice7;
        //string uCostPrice8;
        //string uCostPrice9;
        //string uCostPrice10;

        //string uSalePrice1;
        //string uSalePrice2;
        //string uSalePrice3;
        //string uSalePrice4;
        //string uSalePrice5;
        //string uSalePrice6;
        //string uSalePrice7;
        //string uSalePrice8;
        //string uSalePrice9;
        //string uSalePrice10;

        //------------------------------------------------------------//
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {




            try {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox4.Text + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();

                dr.Read();

                Code1 = dr["Barcode"].ToString();
                CostPrice1 = dr["cost_Parchase"].ToString();
                SalePrice1 = dr["cost_Sales"].ToString();
                Tax1 = dr["TAX"].ToString();
                ItemName1 = dr["ItemName"].ToString();

                //uCode1 = dr["Barcode"].ToString();
                //uCostPrice1 = dr["cost_Parchase"].ToString();
                //uSalePrice1 = dr["cost_Sales"].ToString();
                //uTax1 = dr["TAX"].ToString();
                //uItemName1 = dr["ItemName"].ToString();

                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                textBox4.Text = "";
                MessageBox.Show(ee.Message);
            }
            }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox2.Text + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();

                dr.Read();

                Code2 = dr["Barcode"].ToString();
                CostPrice2 = dr["cost_Parchase"].ToString();
                SalePrice2 = dr["cost_Sales"].ToString();
                Tax2 = dr["TAX"].ToString();
                ItemName2 = dr["ItemName"].ToString();

                //uCode2 = dr["Barcode"].ToString();
                //uCostPrice2 = dr["cost_Parchase"].ToString();
                //uSalePrice2 = dr["cost_Sales"].ToString();
                //uTax2 = dr["TAX"].ToString();
                //uItemName2 = dr["ItemName"].ToString();

                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                textBox2.Text = "";
                MessageBox.Show(ee.Message);
            }
        }


        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox3.Text + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();

                dr.Read();

                Code3 = dr["Barcode"].ToString();
                CostPrice3 = dr["cost_Parchase"].ToString();
                SalePrice3 = dr["cost_Sales"].ToString();
                Tax3 = dr["TAX"].ToString();
                ItemName3 = dr["ItemName"].ToString();

                //uCode3 = dr["Barcode"].ToString();
                //uCostPrice3 = dr["cost_Parchase"].ToString();
                //uSalePrice3 = dr["cost_Sales"].ToString();
                //uTax3 = dr["TAX"].ToString();
                //uItemName3 = dr["ItemName"].ToString();

                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                textBox3.Text = "";
                MessageBox.Show(ee.Message);
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox5.Text + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();

                dr.Read();

                Code5 = dr["Barcode"].ToString();
                CostPrice5 = dr["cost_Parchase"].ToString();
                SalePrice5 = dr["cost_Sales"].ToString();
                Tax5 = dr["TAX"].ToString();
                ItemName5 = dr["ItemName"].ToString();


                //uCode5 = dr["Barcode"].ToString();
                //uCostPrice5 = dr["cost_Parchase"].ToString();
                //uSalePrice5 = dr["cost_Sales"].ToString();
                //uTax5 = dr["TAX"].ToString();
                //uItemName5 = dr["ItemName"].ToString();
                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                textBox5.Text = "";
                MessageBox.Show(ee.Message);
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox6.Text + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();

                dr.Read();

                Code6 = dr["Barcode"].ToString();
                CostPrice6 = dr["cost_Parchase"].ToString();
                SalePrice6 = dr["cost_Sales"].ToString();
                Tax6 = dr["TAX"].ToString();
                ItemName6 = dr["ItemName"].ToString();

                //uCode6 = dr["Barcode"].ToString();
                //uCostPrice6 = dr["cost_Parchase"].ToString();
                //uSalePrice6 = dr["cost_Sales"].ToString();
                //uTax6 = dr["TAX"].ToString();
                //uItemName6 = dr["ItemName"].ToString();
                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                textBox6.Text = "";
                MessageBox.Show(ee.Message);
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox7.Text + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();

                dr.Read();

                Code7 = dr["Barcode"].ToString();
                CostPrice7 = dr["cost_Parchase"].ToString();
                SalePrice7 = dr["cost_Sales"].ToString();
                Tax7 = dr["TAX"].ToString();
                ItemName7 = dr["ItemName"].ToString();

                //uCode7 = dr["Barcode"].ToString();
                //uCostPrice7 = dr["cost_Parchase"].ToString();
                //uSalePrice7 = dr["cost_Sales"].ToString();
                //uTax7 = dr["TAX"].ToString();
                //uItemName7 = dr["ItemName"].ToString();
                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                textBox7.Text = "";
                MessageBox.Show(ee.Message);
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox8.Text + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();

                dr.Read();

                Code8 = dr["Barcode"].ToString();
                CostPrice8 = dr["cost_Parchase"].ToString();
                SalePrice8 = dr["cost_Sales"].ToString();
                Tax8 = dr["TAX"].ToString();
                ItemName8 = dr["ItemName"].ToString();

                //uCode8 = dr["Barcode"].ToString();
                //uCostPrice8 = dr["cost_Parchase"].ToString();
                //uSalePrice8 = dr["cost_Sales"].ToString();
                //uTax8 = dr["TAX"].ToString();
                //uItemName8 = dr["ItemName"].ToString();

                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                textBox8.Text = "";
                MessageBox.Show(ee.Message);
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox9.Text + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();

                dr.Read();

                Code9 = dr["Barcode"].ToString();
                CostPrice9 = dr["cost_Parchase"].ToString();
                SalePrice9 = dr["cost_Sales"].ToString();
                Tax9 = dr["TAX"].ToString();
                ItemName9 = dr["ItemName"].ToString();

                //uCode9 = dr["Barcode"].ToString();
                //uCostPrice9 = dr["cost_Parchase"].ToString();
                //uSalePrice9 = dr["cost_Sales"].ToString();
                //uTax9 = dr["TAX"].ToString();
                //uItemName9 = dr["ItemName"].ToString();

                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                textBox9.Text = "";
                MessageBox.Show(ee.Message);
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox10.Text + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();

                dr.Read();

                Code10 = dr["Barcode"].ToString();
                CostPrice10 = dr["cost_Parchase"].ToString();
                SalePrice10 = dr["cost_Sales"].ToString();
                Tax10 = dr["TAX"].ToString();
                ItemName10 = dr["ItemName"].ToString();

                //uCode10 = dr["Barcode"].ToString();
                //uCostPrice10 = dr["cost_Parchase"].ToString();
                //uSalePrice10 = dr["cost_Sales"].ToString();
                //uTax10 = dr["TAX"].ToString();
                //uItemName10 = dr["ItemName"].ToString();
                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                textBox10.Text = "";
                MessageBox.Show(ee.Message);
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select Barcode,ItemName,cost_Sales,cost_Parchase,TAX from Drugs_NOW where ItemName =@ItemName", con);
                na.Parameters.Add(new SqlParameter("@ItemName", "" + textBox11.Text + ""));
                con.Open();
                na.ExecuteNonQuery();
                SqlDataReader dr;

                dr = na.ExecuteReader();

                dr.Read();

                Code4 = dr["Barcode"].ToString();
                CostPrice4 = dr["cost_Parchase"].ToString();
                SalePrice4 = dr["cost_Sales"].ToString();
                Tax4 = dr["TAX"].ToString();
                ItemName4 = dr["ItemName"].ToString();

                //uCode4 = dr["Barcode"].ToString();
                //uCostPrice4 = dr["cost_Parchase"].ToString();
                //uSalePrice4 = dr["cost_Sales"].ToString();
                //uTax4 = dr["TAX"].ToString();
                //uItemName4 = dr["ItemName"].ToString();
                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("لا يوجد دواء بهذا الأسم ", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                textBox11.Text = "";
                MessageBox.Show(ee.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // الباركود الصورة //////////////
            try
            { 
            Bitmap bm =new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, this.pictureBox1.Width, this.pictureBox1.Height));
            e.Graphics.DrawImage(bm, 0, 950);
            //---------------------------------------------------------------------//
            Bitmap bmp = Properties.Resources.s2;
            Image newimage = bmp;
            e.Graphics.DrawImage(newimage, 120, 0, newimage.Width, newimage.Height);
            e.Graphics.DrawImage(newimage, 690, 0, newimage.Width, newimage.Height);
            e.Graphics.DrawString("عيادات الشروق", new Font("Arial", 35, FontStyle.Bold), Brushes.Black, new Point(320, 30));

            e.Graphics.DrawString("اسم العلاج", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(670, 170));
            e.Graphics.DrawString(label9.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(0, 130));

            e.Graphics.DrawString(label9.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(0, 190));
            e.Graphics.DrawString(label1.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(580, 155));

            e.Graphics.DrawString(textBox4.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(600, 250));
            e.Graphics.DrawString(textBox2.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(600, 280));
            e.Graphics.DrawString(textBox3.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(600, 310));
            e.Graphics.DrawString(textBox5.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(600, 340));
            e.Graphics.DrawString(textBox6.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(600, 370));
            e.Graphics.DrawString(textBox7.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(600, 400));
            e.Graphics.DrawString(textBox8.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(600, 430));
            e.Graphics.DrawString(textBox9.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(600, 460));
            e.Graphics.DrawString(textBox10.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(600, 490));
            e.Graphics.DrawString(textBox11.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(600, 520));


            e.Graphics.DrawString("الجرعة", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(470, 170));
            e.Graphics.DrawString(label1.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(420, 155));
            e.Graphics.DrawString(combo_A_1.Text +"  "+ text_dose1.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(460, 250));
            e.Graphics.DrawString(combo_A_2.Text + "  " + text_dose2.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(460, 280));
            e.Graphics.DrawString(combo_A_3.Text + "  " + text_dose3.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(460, 310));
            e.Graphics.DrawString(combo_A_4.Text + "  " + text_dose4.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(460, 340));
            e.Graphics.DrawString(combo_A_5.Text + "  " + text_dose5.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(460, 370));
            e.Graphics.DrawString(combo_A_6.Text + "  " + text_dose6.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(460, 400));
            e.Graphics.DrawString(combo_A_7.Text + "  " + text_dose7.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(460, 430));
            e.Graphics.DrawString(combo_A_8.Text + "  " + text_dose8.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(460, 460));
            e.Graphics.DrawString(combo_A_9.Text + "  " + text_dose9.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(460, 490));
            e.Graphics.DrawString(combo_A_10.Text + "  " + text_dose10.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(460, 520));

            e.Graphics.DrawString("عدد المرات", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(280, 170));
            e.Graphics.DrawString(label1.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(250, 155));
            e.Graphics.DrawString(combo_N_1.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(330, 250));
            e.Graphics.DrawString(combo_N_2.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(330, 280));
            e.Graphics.DrawString(combo_N_3.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(330, 310));
            e.Graphics.DrawString(combo_N_4.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(330, 340));
            e.Graphics.DrawString(combo_N_5.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(330, 370));
            e.Graphics.DrawString(combo_N_6.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(330, 400));
            e.Graphics.DrawString(combo_N_7.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(330, 430));
            e.Graphics.DrawString(combo_N_8.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(330, 460));
            e.Graphics.DrawString(combo_N_9.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(330, 490));
            e.Graphics.DrawString(combo_N_10.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(330, 520));

            e.Graphics.DrawString("أيام العلاج", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(80, 170));

            e.Graphics.DrawString(combo_D_1.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 250));
            e.Graphics.DrawString(combo_D_2.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 280));
            e.Graphics.DrawString(combo_D_3.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 310));
            e.Graphics.DrawString(combo_D_4.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 340));
            e.Graphics.DrawString(combo_D_5.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 370));
            e.Graphics.DrawString(combo_D_6.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 400));
            e.Graphics.DrawString(combo_D_7.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 430));
            e.Graphics.DrawString(combo_D_8.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 460));
            e.Graphics.DrawString(combo_D_9.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 490));
            e.Graphics.DrawString(combo_D_10.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(80, 520));

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1020 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //public void up1()
        //{
        //    try
        //    {
        //        if (textBox4.Text != "" && uCode1!=null)
        //        {

        //            SqlCommand cmd = new SqlCommand("update Medication set Medication_ID=@Medication_ID,Code=@Code,ItemName=@ItemName,Tax=@Tax,CostPrice=@CostPrice,SalePrice=@SalePrice where Medication_ID=@Medication_ID and IID=@IID", con);

        //            cmd.Parameters.Add(new SqlParameter("@IID", IID1.Text));
        //            cmd.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
        //            cmd.Parameters.Add(new SqlParameter("@Code", uCode1));
        //            cmd.Parameters.Add(new SqlParameter("@ItemName", uItemName1));
        //            cmd.Parameters.Add(new SqlParameter("@Tax", uTax1));
        //            cmd.Parameters.Add(new SqlParameter("@CostPrice", uCostPrice1));
        //            cmd.Parameters.Add(new SqlParameter("@SalePrice", uSalePrice1));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        con.Close();
        //        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1021 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        //public void up2()
        //{
        //    try
        //    {
        //        if (textBox2.Text != "" && uCode2 != null)
        //        {
        //            SqlCommand cmd = new SqlCommand("update Medication set Medication_ID=@Medication_ID,Code=@Code,ItemName=@ItemName,Tax=@Tax,CostPrice=@CostPrice,SalePrice=@SalePrice where Medication_ID=@Medication_ID", con);

        //            cmd.Parameters.Add(new SqlParameter("@IID", IID2.Text));
        //            cmd.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
        //            cmd.Parameters.Add(new SqlParameter("@Code", uCode2));
        //            cmd.Parameters.Add(new SqlParameter("@ItemName", uItemName2));
        //            cmd.Parameters.Add(new SqlParameter("@Tax", uTax2));
        //            cmd.Parameters.Add(new SqlParameter("@CostPrice", uCostPrice2));
        //            cmd.Parameters.Add(new SqlParameter("@SalePrice", uSalePrice2));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        con.Close();
        //        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1022 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}


        //public void up3()
        //{
        //    try
        //    {
        //        if (textBox3.Text != "" && uCode3 != null)
        //        {
        //            SqlCommand cmd = new SqlCommand("update Medication set Medication_ID=@Medication_ID,Code=@Code,ItemName=@ItemName,Tax=@Tax,CostPrice=@CostPrice,SalePrice=@SalePrice where Medication_ID=@Medication_ID", con);

        //            cmd.Parameters.Add(new SqlParameter("@IID", IID3.Text));
        //            cmd.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
        //            cmd.Parameters.Add(new SqlParameter("@Code", uCode3));
        //            cmd.Parameters.Add(new SqlParameter("@ItemName", uItemName3));
        //            cmd.Parameters.Add(new SqlParameter("@Tax", uTax3));
        //            cmd.Parameters.Add(new SqlParameter("@CostPrice", uCostPrice3));
        //            cmd.Parameters.Add(new SqlParameter("@SalePrice", uSalePrice3));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();


        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        con.Close();
        //        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1023 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        //public void up4()
        //{
        //    try
        //    {
        //        if (textBox5.Text != "" && uCode4 != null)
        //        {

        //            SqlCommand cmd = new SqlCommand("update Medication set Medication_ID=@Medication_ID,Code=@Code,ItemName=@ItemName,Tax=@Tax,CostPrice=@CostPrice,SalePrice=@SalePrice where Medication_ID=@Medication_ID", con);

        //            cmd.Parameters.Add(new SqlParameter("@IID", IID4.Text));
        //            cmd.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
        //            cmd.Parameters.Add(new SqlParameter("@Code", uCode4));
        //            cmd.Parameters.Add(new SqlParameter("@ItemName", uItemName4));
        //            cmd.Parameters.Add(new SqlParameter("@Tax", uTax4));
        //            cmd.Parameters.Add(new SqlParameter("@CostPrice", uCostPrice4));
        //            cmd.Parameters.Add(new SqlParameter("@SalePrice", uSalePrice4));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        con.Close();
        //        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1024 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        //public void up5()
        //{
        //    try
        //    {
        //        if (textBox6.Text != "" && uCode5 != null)
        //        {
        //            SqlCommand cmd = new SqlCommand("update Medication set Medication_ID=@Medication_ID,Code=@Code,ItemName=@ItemName,Tax=@Tax,CostPrice=@CostPrice,SalePrice=@SalePrice where Medication_ID=@Medication_ID", con);

        //            cmd.Parameters.Add(new SqlParameter("@IID", IID5.Text));
        //            cmd.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
        //            cmd.Parameters.Add(new SqlParameter("@Code", uCode5));
        //            cmd.Parameters.Add(new SqlParameter("@ItemName", uItemName5));
        //            cmd.Parameters.Add(new SqlParameter("@Tax", uTax5));
        //            cmd.Parameters.Add(new SqlParameter("@CostPrice", uCostPrice5));
        //            cmd.Parameters.Add(new SqlParameter("@SalePrice", uSalePrice5));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        con.Close();
        //        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1025 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        //public void up6()
        //{
        //    try
        //    {
        //        if (textBox7.Text != "" && uCode6 != null)
        //        {
        //            SqlCommand cmd = new SqlCommand("update Medication set Medication_ID=@Medication_ID,Code=@Code,ItemName=@ItemName,Tax=@Tax,CostPrice=@CostPrice,SalePrice=@SalePrice where Medication_ID=@Medication_ID", con);

        //            cmd.Parameters.Add(new SqlParameter("@IID", IID6.Text));
        //            cmd.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
        //            cmd.Parameters.Add(new SqlParameter("@Code", uCode6));
        //            cmd.Parameters.Add(new SqlParameter("@ItemName", uItemName6));
        //            cmd.Parameters.Add(new SqlParameter("@Tax", uTax6));
        //            cmd.Parameters.Add(new SqlParameter("@CostPrice", uCostPrice6));
        //            cmd.Parameters.Add(new SqlParameter("@SalePrice", uSalePrice6));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        con.Close();
        //        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1026 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        //public void up7()
        //{
        //    try
        //    {
        //        if (textBox8.Text != "" && uCode7 != null)
        //        {
        //            SqlCommand cmd = new SqlCommand("update Medication set Medication_ID=@Medication_ID,Code=@Code,ItemName=@ItemName,Tax=@Tax,CostPrice=@CostPrice,SalePrice=@SalePrice where Medication_ID=@Medication_ID", con);

        //            cmd.Parameters.Add(new SqlParameter("@IID", IID7.Text));
        //            cmd.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
        //            cmd.Parameters.Add(new SqlParameter("@Code", uCode7));
        //            cmd.Parameters.Add(new SqlParameter("@ItemName", uItemName7));
        //            cmd.Parameters.Add(new SqlParameter("@Tax", uTax7));
        //            cmd.Parameters.Add(new SqlParameter("@CostPrice", uCostPrice7));
        //            cmd.Parameters.Add(new SqlParameter("@SalePrice", uSalePrice7));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        con.Close();
        //        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1027 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        //public void up8()
        //{
        //    try
        //    {
        //        if (textBox9.Text != "" && uCode8 != null)
        //        {
        //            SqlCommand cmd = new SqlCommand("update Medication set Medication_ID=@Medication_ID,Code=@Code,ItemName=@ItemName,Tax=@Tax,CostPrice=@CostPrice,SalePrice=@SalePrice where Medication_ID=@Medication_ID", con);

        //            cmd.Parameters.Add(new SqlParameter("@IID", IID8.Text));
        //            cmd.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
        //            cmd.Parameters.Add(new SqlParameter("@Code", uCode8));
        //            cmd.Parameters.Add(new SqlParameter("@ItemName", uItemName8));
        //            cmd.Parameters.Add(new SqlParameter("@Tax", uTax8));
        //            cmd.Parameters.Add(new SqlParameter("@CostPrice", uCostPrice8));
        //            cmd.Parameters.Add(new SqlParameter("@SalePrice", uSalePrice8));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //        }

        //    }
        //    catch (Exception ee)
        //    {
        //        con.Close();
        //        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1028 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        //public void up9()
        //{
        //    try
        //    {
        //        if (textBox10.Text != "" && uCode9 != null)
        //        {
        //            SqlCommand cmd = new SqlCommand("update Medication set Medication_ID=@Medication_ID,Code=@Code,ItemName=@ItemName,Tax=@Tax,CostPrice=@CostPrice,SalePrice=@SalePrice where Medication_ID=@Medication_ID", con);

        //            cmd.Parameters.Add(new SqlParameter("@IID", IID9.Text));
        //            cmd.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
        //            cmd.Parameters.Add(new SqlParameter("@Code", uCode9));
        //            cmd.Parameters.Add(new SqlParameter("@ItemName", uItemName9));
        //            cmd.Parameters.Add(new SqlParameter("@Tax", uTax9));
        //            cmd.Parameters.Add(new SqlParameter("@CostPrice", uCostPrice9));
        //            cmd.Parameters.Add(new SqlParameter("@SalePrice", uSalePrice9));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        con.Close();
        //        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1029 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        //public void up10()
        //{
        //    try
        //    {
        //        if (textBox11.Text != "" && uCode10 != null)
        //        {
        //            SqlCommand cmd = new SqlCommand("update Medication set Medication_ID=@Medication_ID,Code=@Code,ItemName=@ItemName,Tax=@Tax,CostPrice=@CostPrice,SalePrice=@SalePrice where Medication_ID=@Medication_ID", con);

        //            cmd.Parameters.Add(new SqlParameter("@IID", IID10.Text));
        //            cmd.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text.Trim()));
        //            cmd.Parameters.Add(new SqlParameter("@Code", uCode10));
        //            cmd.Parameters.Add(new SqlParameter("@ItemName", uItemName10));
        //            cmd.Parameters.Add(new SqlParameter("@Tax", uTax10));
        //            cmd.Parameters.Add(new SqlParameter("@CostPrice", uCostPrice10));
        //            cmd.Parameters.Add(new SqlParameter("@SalePrice", uSalePrice10));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        con.Close();
        //        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1030 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("update Table_visit_patient set Medication1=@Medication1,Medication2=@Medication2,Medication3=@Medication3,Medication4=@Medication4,Medication5=@Medication5,Medication6=@Medication6,Medication7=@Medication7,Medication8=@Medication8,Medication9=@Medication9,Medication10=@Medication10 where ID_visit=@ID_visit", con);
            //cmd.Parameters.Add(new SqlParameter("@ID_visit", textBox1.Text));

            //cmd.Parameters.Add(new SqlParameter("@Medication1", textBox4.Text));
            //cmd.Parameters.Add(new SqlParameter("@Medication2", textBox2.Text));
            //cmd.Parameters.Add(new SqlParameter("@Medication3", textBox3.Text));
            //cmd.Parameters.Add(new SqlParameter("@Medication4", textBox5.Text));
            //cmd.Parameters.Add(new SqlParameter("@Medication5", textBox6.Text));
            //cmd.Parameters.Add(new SqlParameter("@Medication6", textBox7.Text));
            //cmd.Parameters.Add(new SqlParameter("@Medication7", textBox8.Text));
            //cmd.Parameters.Add(new SqlParameter("@Medication8", textBox9.Text));
            //cmd.Parameters.Add(new SqlParameter("@Medication9", textBox10.Text));
            //cmd.Parameters.Add(new SqlParameter("@Medication10", textBox11.Text));

            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();



            //dose();
            //ML();
            //count();
            //Daey();
            ////---------------- Delete --- recipe-------------------------------------------------------------------------------//
            //SqlCommand cmd2 = new SqlCommand("delete from Medication where Medication_ID=@Medication_ID", con);
            //cmd2.Parameters.Add(new SqlParameter("@Medication_ID", textBox1.Text));
            ////-----------------------------------------------------------------------------------------------------------------//





            //button2.Enabled = false;
            //button4.Enabled = true;

            //MessageBox.Show("تم تعديل بيانات الوصفة الطبية بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
