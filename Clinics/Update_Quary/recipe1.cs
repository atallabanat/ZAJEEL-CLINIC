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

namespace Clinics.Update_Quary
{
    public partial class recipe1 : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public recipe1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void recipe1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'clinicDataSet.Drugs' table. You can move, or remove it, as needed.
                textBox1.Text = quary_visitpatient.qak.textBox_ID_visit.Text;
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    cmd2.Parameters.Add("@Code", Code1);
                    cmd2.Parameters.Add("@ItemName", ItemName1);
                    cmd2.Parameters.Add("@Tax", Tax1);
                    cmd2.Parameters.Add("@CostPrice", CostPrice1);
                    cmd2.Parameters.Add("@SalePrice", SalePrice1);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    cmd2.Parameters.Add("@Code", Code2);
                    cmd2.Parameters.Add("@ItemName", ItemName2);
                    cmd2.Parameters.Add("@Tax", Tax2);
                    cmd2.Parameters.Add("@CostPrice", CostPrice2);
                    cmd2.Parameters.Add("@SalePrice", SalePrice2);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    cmd2.Parameters.Add("@Code", Code3);
                    cmd2.Parameters.Add("@ItemName", ItemName3);
                    cmd2.Parameters.Add("@Tax", Tax3);
                    cmd2.Parameters.Add("@CostPrice", CostPrice3);
                    cmd2.Parameters.Add("@SalePrice", SalePrice3);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    cmd2.Parameters.Add("@Code", Code5);
                    cmd2.Parameters.Add("@ItemName", ItemName5);
                    cmd2.Parameters.Add("@Tax", Tax5);
                    cmd2.Parameters.Add("@CostPrice", CostPrice5);
                    cmd2.Parameters.Add("@SalePrice", SalePrice5);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    cmd2.Parameters.Add("@Code", Code6);
                    cmd2.Parameters.Add("@ItemName", ItemName6);
                    cmd2.Parameters.Add("@Tax", Tax6);
                    cmd2.Parameters.Add("@CostPrice", CostPrice6);
                    cmd2.Parameters.Add("@SalePrice", SalePrice6);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    cmd2.Parameters.Add("@Code", Code7);
                    cmd2.Parameters.Add("@ItemName", ItemName7);
                    cmd2.Parameters.Add("@Tax", Tax7);
                    cmd2.Parameters.Add("@CostPrice", CostPrice7);
                    cmd2.Parameters.Add("@SalePrice", SalePrice7);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    cmd2.Parameters.Add("@Code", Code8);
                    cmd2.Parameters.Add("@ItemName", ItemName8);
                    cmd2.Parameters.Add("@Tax", Tax8);
                    cmd2.Parameters.Add("@CostPrice", CostPrice8);
                    cmd2.Parameters.Add("@SalePrice", SalePrice8);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    cmd2.Parameters.Add("@Code", Code9);
                    cmd2.Parameters.Add("@ItemName", ItemName9);
                    cmd2.Parameters.Add("@Tax", Tax9);
                    cmd2.Parameters.Add("@CostPrice", CostPrice9);
                    cmd2.Parameters.Add("@SalePrice", SalePrice9);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1009 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    cmd2.Parameters.Add("@Code", Code10);
                    cmd2.Parameters.Add("@ItemName", ItemName10);
                    cmd2.Parameters.Add("@Tax", Tax10);
                    cmd2.Parameters.Add("@CostPrice", CostPrice10);
                    cmd2.Parameters.Add("@SalePrice", SalePrice10);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1010 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    cmd2.Parameters.Add("@Code", Code4);
                    cmd2.Parameters.Add("@ItemName", ItemName4);
                    cmd2.Parameters.Add("@Tax", Tax4);
                    cmd2.Parameters.Add("@CostPrice", CostPrice4);
                    cmd2.Parameters.Add("@SalePrice", SalePrice4);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1011 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1012 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1013 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1014 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1015 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("update Table_visit_patient set Medication1=@Medication1,Medication2=@Medication2,Medication3=@Medication3,Medication4=@Medication4,Medication5=@Medication5,Medication6=@Medication6,Medication7=@Medication7,Medication8=@Medication8,Medication9=@Medication9,Medication10=@Medication10 where ID_visit=" + textBox1.Text.Trim() + "", con);

                cmd.Parameters.Add(new SqlParameter("@Medication1", textBox4.Text));
                cmd.Parameters.Add(new SqlParameter("@Medication2", textBox2.Text));
                cmd.Parameters.Add(new SqlParameter("@Medication3", textBox3.Text));
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


            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1016 recipe1", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void textBox4_Leave(object sender, EventArgs e)
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
        //------------------------------------------------------------//

    }




}
