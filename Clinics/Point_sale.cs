using Clinics.pharmacy_Control;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using DGVPrinterHelper;
using Clinics.Pharmacy;

namespace Clinics
{
    public partial class Point_sale : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static string totalAmount;
        public static Point_sale point_Sale;

        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices cd = new Choices();

        public Point_sale()
        {
            point_Sale = this;

            InitializeComponent();


        }
        string CON;
        SqlCommand cmd2;
        SqlDataReader dr2;
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "close":
                    Application.Exit();
                    break;

                case "Stop":
                    sre.RecognizeAsyncStop();
                    MessageBox.Show("تم تعطيل الأوامر الصوتية", "الأوامر الصوتية", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;

                case "Save":
                    btn_Save_Click(sender, e);
                    break;

                case "New":
                    button1_Click(sender, e);
                    break;

                case "Barcode":
                    textBox3.Focus();
                    break;

                case "Cancel":
                    button5_Click(sender, e);
                    break;
            }
        }
        int flagcombo;
        private void Point_sale_Load(object sender, EventArgs e)
        {

            try
            {

                //------------ قائمة اسماء الشركات ---------------------------//
                flagcombo = 1;
                DataTable Dt5 = new DataTable();
                SqlDataAdapter Da5 = new SqlDataAdapter("select * from insurance", con);
                Da5.Fill(Dt5);
                textBox1.DataSource = Dt5;
                textBox1.DisplayMember = "Name_insurance";
                textBox1.ValueMember = "Name_insurance";
                textBox1.SelectedIndex = -1;

                //------------ قائمة اسماء الشركات ---------------------------//

                textBox3.Focus();
                flagcombo = 0;
                radioButton1.Checked = true;


                SqlCommand cmd3 = new SqlCommand("select ISNULL (MAX (InvoiceNo)+1,1) from Invoice", con);
                con.Open();
                SqlDataReader Ra = cmd3.ExecuteReader();

                Ra.Read();
                label5.Text = Ra[0].ToString();
                EW = Convert.ToInt32(Ra[0].ToString());
                ED = Ra[0].ToString();
                EE = Convert.ToInt32(Ra[0].ToString());

                Ra.Close();
                con.Close();


            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001-1 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            try
            {

                textBox5.Text = DateTime.Now.ToString("yyyy/MM/dd");
                //con.Open();
                //cmd2 = new SqlCommand("select ItemName from Drugs_NOW ", con);
                //cmd2.ExecuteNonQuery();
                //dr2 = cmd2.ExecuteReader();
                //AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                //while (dr2.Read())
                //{
                //    col.Add(dr2.GetString(0));

                //}
                //textBox4.AutoCompleteCustomSource = col;
                //dr2.Close();
                //con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001-2 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            try
            {

                text_nameStaff.Text = Form1.Recby.ToString();
                this.KeyPreview = true;
                text_Discount.Text = "0";
                text_DiscountP.Text = "0";
                totalAmount = text_totalAmount.Text;


                SqlDataAdapter Da;
                DataTable Dt = new DataTable();

                Da = new SqlDataAdapter("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + "", con);
                Da.Fill(Dt);

                if (Dt.Rows[10][0].ToString() == "False" || Dt.Rows[10][0].ToString() == string.Empty)
                {
                    الذهابالىالاستقبالToolStripMenuItem.Visible = false;
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001-3 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        public void Total()

        {

            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[5].Value == "")
                    {
                        double QQ = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        double SS = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                        double DD = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                        double TT = (QQ * SS) - DD;

                        dataGridView1.Rows[i].Cells[8].Value = TT;
                    }
                    else
                    {



                        ////عدد الاشرطة
                        //double SDR = Convert.ToDouble(dr2[6].ToString());
                        //double SP = Convert.ToDouble(dr2[5].ToString());
                        //double APR = SP / SDR;

                        //double AADDP = APR * Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].Value);

                        //dataGridView1.Rows[e.RowIndex].Cells[8].Value = AADDP;
                    }
                    //    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void SubTotal()
        {
            try
            {
                double sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);

                    text_subTotal.Text = Convert.ToDouble(sum).ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void TotalAmount()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    double sub = Convert.ToDouble(text_subTotal.Text.ToString());
                    double Dis = Convert.ToDouble(text_Discount.Text.ToString());
                    double DisP = Convert.ToDouble(text_DiscountP.Text.ToString());
                    string TotalAmount = Convert.ToDouble((sub - Dis - (sub * (DisP / 100)))).ToString();

                    text_totalAmount.Text = Convert.ToDouble(TotalAmount).ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void N_Items()
        {
            try
            {
                int count = dataGridView1.RowCount - 1;
                text_N_ITems.Text = count.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        double qaa;
        DateTime d2;
        DateTime d1 = DateTime.Now;
        double NrOfDays;
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {


                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("لا يوجد منتج بهذا الباركود");
                        return;
                    }
                    else
                    {


                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Quantity,Convert(smalldatetime,EndDate,103) as EndDate from Drugs_NOW where Barcode=@Barcode", con);
                        na.Parameters.Add(new SqlParameter("@Barcode", "" + textBox3.Text + ""));
                        con.Open();
                        SqlDataReader dr;
                        dr = na.ExecuteReader();
                        if (dr.Read())
                        {
                            qaa = Convert.ToDouble(dr["Quantity"]);
                            string enddate = dr["EndDate"].ToString();
                            d2 = Convert.ToDateTime(enddate);
                            TimeSpan t = d1 - d2;
                            NrOfDays = t.TotalDays;
                            dr.Close();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("عذرا هذه المادة غير موجودة أو لا توجد كمية", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dr.Close();
                            con.Close();
                        }

                        if (qaa <= 0)
                        {

                            MessageBox.Show("عذرا نفذت الكمية ، يرجى إدخاله من جديد في فاتورة الشراء", "لا يوجد كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox3.Text = "";
                            textBox3.Focus();

                        }
                        else if (NrOfDays > 0)
                        {
                            MessageBox.Show("عذرا المادة منتهية الصلاحية ، لا يمكنك بيع مادة منتهية الصلاحية", "مادة منتهية الصلاحية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox3.Text = "";
                            textBox3.Focus();
                        }
                        else
                        {

                            SqlCommand na4 = new SqlCommand();
                            na4 = new SqlCommand("select count(Barcode) from Drugs_NOW where Barcode=@Barcode", con);
                            na4.Parameters.Add(new SqlParameter("@Barcode", "" + textBox3.Text + ""));
                            SqlDataReader dr4;
                            con.Open();
                            dr4 = na4.ExecuteReader();
                            dr4.Read();
                            if (Convert.ToDouble(dr4.GetValue(0)) > 1)
                            {

                                count2 ss = new count2();
                                ss.Show();
                                con.Close();
                            }

                            else
                            {
                                dr4.Close();
                                con.Close();
                                SqlCommand na5 = new SqlCommand();
                                na5 = new SqlCommand("select Barcode,ItemName,cost_Sales,Quantity,Tax from Drugs_NOW where Barcode=@Barcode", con);
                                na5.Parameters.Add(new SqlParameter("@Barcode", "" + textBox3.Text + ""));
                                con.Open();
                                SqlDataReader dr5;
                                dr5 = na5.ExecuteReader();


                                while (dr5.Read())
                                {


                                    dataGridView1.Rows.Add(i, textBox3.Text, dr5["ItemName"].ToString(), 1, dr5["cost_Sales"].ToString(), "", 0, dr5["Tax"].ToString());
                                    textBox3.Text = "";
                                    textBox3.Focus();


                                    Total();
                                    N_Items();
                                    SubTotal();
                                    TotalAmount();
                                    totalAmount = text_totalAmount.Text;
                                    i += 1;


                                }
                                dr5.Close();
                                con.Close();
                            }

                        }

                    }

                }


            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        string ED;
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                Total();
                N_Items();
                SubTotal();
                TotalAmount();
                totalAmount = text_totalAmount.Text;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_Discount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                TotalAmount();
                totalAmount = text_totalAmount.Text;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public int po = 0;
        int dd = 1;
        public void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && po == 0)
                {
                    Dic_Pet ss = new Dic_Pet();
                    ss.Show();
                    po += 1;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select InvoiceNo from Invoice where InvoiceNo=@InvoiceNo", con);
                    cmd21.Parameters.Add(new SqlParameter("InvoiceNo", label5.Text));
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
                        MessageBox.Show("الفاتورة موجودة مسبقا ، لا يمكن إضافة فاتورة بنفس الرقم  " + label5.Text.Trim(), "تكرار البيانات الفاتورة موجودة مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    else
                    {



                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            SqlCommand na = new SqlCommand();
                            na = new SqlCommand("select COUNT(Barcode) from Drugs_NOW where Barcode= @Barcode", con);
                            na.Parameters.Add(new SqlParameter("@Barcode", "" + dataGridView1.Rows[i].Cells[1].Value + ""));
                            con.Open();
                            na.ExecuteNonQuery();
                            SqlDataReader dr2;

                            dr2 = na.ExecuteReader();
                            double qun = 0;
                            double qqz = 0;
                            double totalz = 0;
                            dr2.Read();

                            if (Convert.ToDouble(dr2.GetValue(0)) > 1)
                            {
                                dr2.Close();
                                con.Close();
                                SqlCommand na3 = new SqlCommand();
                                na3 = new SqlCommand("select ID_order,Quantity from Drugs_NOW where ID_order= @ID_order and Barcode= @Barcode ", con);
                                na3.Parameters.Add(new SqlParameter("@ID_order", "" + textBox7.Text + ""));
                                na3.Parameters.Add(new SqlParameter("@Barcode", "" + dataGridView1.Rows[i].Cells[1].Value + ""));

                                con.Open();
                                na3.ExecuteNonQuery();
                                SqlDataReader dr3;

                                dr3 = na3.ExecuteReader();
                                dr3.Read();

                                qun = Convert.ToDouble(dr3["Quantity"].ToString());
                                qqz = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                totalz = qun - qqz;
                                dr3.Close();
                                con.Close();


                                SqlCommand cmd2 = new SqlCommand("update Drugs_NOW set  Quantity=@Quantity  where ID_order=" + textBox7.Text + " and Barcode= @Barcode", con);
                                cmd2.Parameters.Add(new SqlParameter("@Barcode", "" + dataGridView1.Rows[i].Cells[1].Value + ""));



                                cmd2.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.NVarChar)).Value = totalz.ToString();

                                con.Open();
                                cmd2.ExecuteNonQuery();
                                con.Close();



                            }
                            else
                            {
                                dr2.Close();
                                con.Close();
                                SqlCommand na44 = new SqlCommand();
                                na44 = new SqlCommand("select Quantity from Drugs_NOW where Barcode= @Barcode", con);
                                na44.Parameters.Add(new SqlParameter("@Barcode", "" + dataGridView1.Rows[i].Cells[1].Value + ""));
                                con.Open();
                                na44.ExecuteNonQuery();
                                SqlDataReader dr44;

                                dr44 = na44.ExecuteReader();
                                dr44.Read();


                                qun = Convert.ToDouble(dr44["Quantity"].ToString());
                                qqz = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                totalz = qun - qqz;
                                dr44.Close();
                                con.Close();



                                SqlCommand cmd2 = new SqlCommand("update Drugs_NOW set  Quantity=@Quantity  where Barcode='" + dataGridView1.Rows[i].Cells[1].Value + "'", con);



                                cmd2.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.NVarChar)).Value = totalz.ToString();

                                con.Open();
                                cmd2.ExecuteNonQuery();
                                con.Close();

                            }

                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "dbo_insertt_Invoice";

                            cmd.Parameters.Add(new SqlParameter("@InvoiceNo", label5.Text.Trim()));
                            cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = CON;
                            cmd.Parameters.Add("@NameStaff", SqlDbType.NVarChar).Value = text_nameStaff.Text.Trim();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = textBox5.Text.Trim();
                            cmd.Parameters.Add("@N", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                            cmd.Parameters.Add("@code", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
                            cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value;
                            cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[3].Value;
                            cmd.Parameters.Add("@SellingPrice", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[4].Value;
                            cmd.Parameters.Add("@RetailPrice", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[5].Value;
                            cmd.Parameters.Add("@Tax", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[7].Value;
                            cmd.Parameters.Add("@Total", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[8].Value;
                            cmd.Parameters.Add("@Discount", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[6].Value;


                            if (dd == 1)
                            {

                                if (textBox2.Text == "")
                                {
                                    cmd.Parameters.Add("@Total_CashBerfore", SqlDbType.NVarChar).Value = text_subTotal.Text.Trim();
                                    cmd.Parameters.Add("@DisJD", SqlDbType.NVarChar).Value = text_Discount.Text.Trim();
                                    cmd.Parameters.Add("@DisPresent", SqlDbType.NVarChar).Value = text_DiscountP.Text.Trim();
                                    cmd.Parameters.Add("@Total_Cash", SqlDbType.NVarChar).Value = lbl_cc.Text.Trim();
                                    dd += 1;
                                }
                                else
                                {

                                    cmd.Parameters.Add("@Total_Cash", SqlDbType.NVarChar).Value = Dic_Pet.dd.lbl_cc.Text.Trim();
                                    cmd.Parameters.Add("@Total_Pat", SqlDbType.NVarChar).Value = Dic_Pet.dd.textBox_Total_Pat.Text.Trim();
                                    cmd.Parameters.Add("@Total_OnAccount", SqlDbType.NVarChar).Value = Dic_Pet.dd.textBox_Total_MU.Text.Trim();
                                    cmd.Parameters.Add("@Name_Measures", SqlDbType.NVarChar).Value = Dic_Pet.dd.textBox_Name_MU.Text.Trim();
                                    cmd.Parameters.Add("@IDCustomer", SqlDbType.NVarChar).Value = Dic_Pet.dd.textBox_ID_Orders.Text.Trim();
                                    cmd.Parameters.Add("@NameCustomer", SqlDbType.NVarChar).Value = textBox2.Text.Trim();
                                    dd += 1;
                                }




                            }
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }


                        dd = 1;


                        SqlCommand cmd3 = new SqlCommand("select ISNULL (MAX (InvoiceNo)+1,1) from Invoice", con);
                        con.Open();
                        SqlDataReader Ra = cmd3.ExecuteReader();

                        Ra.Read();
                        label5.Text = Ra[0].ToString();

                        dataGridView1.Rows.Clear();
                        textBox1.SelectedIndex = -1;
                        textBox2.Text = "";
                        textBox3.Focus();
                        text_totalAmount.Text = "0";
                        EW = Convert.ToInt32(Ra[0].ToString());
                        ED = Ra[0].ToString();
                        EE = Convert.ToInt32(Ra[0].ToString());
                        Ra.Close();
                        con.Close();
                        textBox2.SelectedIndex = -1;
                        i = 1;
                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1009 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.SelectedIndex = -1;


                SqlCommand cmd3 = new SqlCommand("select ISNULL (MAX (InvoiceNo)+1,1) from Invoice", con);
                con.Open();
                SqlDataReader Ra = cmd3.ExecuteReader();

                Ra.Read();
                label5.Text = Ra[0].ToString();
                dataGridView1.Rows.Clear();
                textBox1.SelectedIndex=-1;
                textBox2.Text = "";
                textBox3.Focus();
                text_totalAmount.Text = "0";

                EW = Convert.ToInt32(Ra[0].ToString());
                ED = Ra[0].ToString();
                EE = Convert.ToInt32(Ra[0].ToString());
                Ra.Close();
                con.Close();
                i = 1;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1010 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label5.Text == "")
            {
                MessageBox.Show("يرجى تحديد رقم الفاتورة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {


                    //حذف الفاتورة واسترجاعها

                    SqlCommand cmd2 = new SqlCommand("delete from Invoice where InvoiceNo=" + label5.Text.Trim() + "", con);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();


                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {





                        //اضافة الفاتورة من جديد
                        btn_Save_Click(sender, e);

                        //SqlCommand cmd = con.CreateCommand();
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.CommandText = "dbo_insertt_Invoice";

                        //cmd.Parameters.Add(new SqlParameter("@InvoiceNo", label5.Text.Trim()));
                        //cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = CON;
                        //cmd.Parameters.Add("@IDCustomer", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
                        //cmd.Parameters.Add("@NameCustomer", SqlDbType.NVarChar).Value = textBox2.Text.Trim();
                        //cmd.Parameters.Add("@NameStaff", SqlDbType.NVarChar).Value = text_nameStaff.Text.Trim();
                        //cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = textBox5.Text.Trim();
                        //cmd.Parameters.Add("@N", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                        //cmd.Parameters.Add("@code", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
                        //cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value;
                        //cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[3].Value;
                        //cmd.Parameters.Add("@SellingPrice", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[4].Value;
                        //cmd.Parameters.Add("@RetailPrice", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[5].Value;
                        //cmd.Parameters.Add("@Tax", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[7].Value;
                        //cmd.Parameters.Add("@Total", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[8].Value;
                        //cmd.Parameters.Add("@Discount", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[6].Value;
                        //con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                    }
                    i = 1;
                    Total();
                    N_Items();
                    SubTotal();
                    TotalAmount();
                    totalAmount = text_totalAmount.Text;
                }
                catch (Exception ee)
                {
                    con.Close();
                    MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1011 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (label5.Text == "")
            {
                MessageBox.Show("لا يوجد فاتورة بهذا الرقم", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف فاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {


                        SqlCommand cmd = new SqlCommand("delete from Invoice where InvoiceNo=" + label5.Text.Trim() + "", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        MessageBox.Show("تم الفاتورة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1012 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    try
                    {
                        SqlCommand cmd3 = new SqlCommand("select ISNULL (MAX (InvoiceNo)+1,1) from Invoice", con);
                        con.Open();
                        SqlDataReader Ra = cmd3.ExecuteReader();

                        Ra.Read();
                        label5.Text = Ra[0].ToString();
                        dataGridView1.Rows.Clear();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Focus();
                        text_totalAmount.Text = "0";

                        EW = Convert.ToInt32(Ra[0].ToString());
                        ED = Ra[0].ToString();
                        EE = Convert.ToInt32(Ra[0].ToString());
                        Ra.Close();
                        con.Close();
                        i = 1;
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1013 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.SelectedIndex = -1;

                SqlCommand cmd3 = new SqlCommand("select ISNULL (MAX (InvoiceNo)+1,1) from Invoice", con);
                con.Open();
                SqlDataReader Ra = cmd3.ExecuteReader();

                Ra.Read();
                label5.Text = Ra[0].ToString();
                dataGridView1.Rows.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Focus();
                text_totalAmount.Text = "0";

                EW = Convert.ToInt32(Ra[0].ToString());
                ED = Ra[0].ToString();
                EE = Convert.ToInt32(Ra[0].ToString());
                Ra.Close();
                con.Close();
                i = 1;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1014 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void Point_sale_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {


                if (e.KeyData == Keys.F8)
                {
                    btn_Save_Click(sender, e);
                }
                if (e.KeyData == Keys.F2)
                {
                    button1_Click(sender, e);
                }
                if (e.KeyData == Keys.F3)
                {
                    button2_Click(sender, e);
                }
                if (e.KeyData == Keys.F4)
                {
                    button3_Click(sender, e);
                }
                if (e.KeyData == Keys.F5)
                {
                    //طباعة //
                }
                if (e.KeyData == Keys.F6)
                {
                    button5_Click(sender, e);
                }
                if (e.KeyData == Keys.F7)
                {
                    textBox3.Focus();
                }
                if (e.KeyData == Keys.F9)
                {
                    textBox1.Focus();
                }
                if (e.KeyData == Keys.F10)
                {
                    label_F1.Visible = true;
                    label_F2.Visible = true;
                    label_F3.Visible = true;
                    label_F4.Visible = true;
                    label_F5.Visible = true;
                    label_F6.Visible = true;
                    label_F9.Visible = true;
                    label_F12.Visible = true;
                    label_CN.Visible = true;
                }
                if (e.KeyData == Keys.F11)
                {
                    label_F1.Visible = false;
                    label_F2.Visible = false;
                    label_F3.Visible = false;
                    label_F4.Visible = false;
                    label_F5.Visible = false;
                    label_F6.Visible = false;
                    label_F9.Visible = false;
                    label_F12.Visible = false;
                    label_CN.Visible = false;
                }

                if (e.KeyData == Keys.F12)
                {
                    button6_Click(sender, e);
                }

                if (e.KeyData == Keys.Control || e.KeyCode == Keys.N)
                {
                    textBox4.Focus();
                }

                if (e.KeyData == Keys.Left)
                {

                    textBox2.SelectedIndex = -1;
                    flagcombo = 1;
                    textBox1.SelectedIndex = -1;
                    flagcombo = 0;
                    if (dataGridView1.Rows.Count != 1)
                    {
                        text_totalAmount.Text = "0";
                        textBox2.SelectedIndex = -1;
                    }
                    BackdatagridView();
                }
                if (e.KeyData == Keys.Right)
                {
                    textBox2.SelectedIndex = -1;
                    textBox1.SelectedIndex = -1;
                    if (dataGridView1.Rows.Count != 1)
                    {
                        text_totalAmount.Text = "0";
                        textBox2.SelectedIndex = -1;
                    }
                    BackdatagridViewPlus();
                }
                if (e.KeyData == Keys.F1)
                {
                    textBox6.Focus();
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1015 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    Dic_Pet ss = new Dic_Pet();
                    ss.Show();
                }
                else
                {
                    PaidEND nn = new PaidEND();
                    nn.Show();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1016 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_Discount_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1017 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double b = Convert.ToDouble(text_Discount.Text);

                string c = "";

                SqlCommand cmd3 = new SqlCommand("select ID_PRS,Name_PRS,PRS,PRS_JD from PRS where Name_PRS =@Name_PRS", con);
                cmd3.Parameters.Add(new SqlParameter("@Name_PRS", text_nameStaff.Text.Trim()));

                con.Open();
                SqlDataReader Ra = cmd3.ExecuteReader();


                if (Ra.Read())
                {
                    c = Ra[3].ToString();

                }
                else
                {
                    c = "1";
                }
                Ra.Close();
                con.Close();


                if (b >= Convert.ToDouble(c))
                {
                    MessageBox.Show("لا يوجد لديك صلاحية بخصم أكثر من " + c.ToString() + "دينار", "صلاحية ممنوعة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_Discount.Text = "0";
                }

                if (text_Discount.Text == "")
                {
                    text_Discount.Text = "0";
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1018 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_DiscountP_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1019 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void text_DiscountP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(text_DiscountP.Text);
                double b = Convert.ToDouble(text_Discount.Text);

                string d;

                SqlCommand cmd3 = new SqlCommand("select ID_PRS,Name_PRS,PRS,PRS_JD from PRS where Name_PRS =@Name_PRS", con);
                cmd3.Parameters.Add(new SqlParameter("@Name_PRS", text_nameStaff.Text.Trim()));

                con.Open();
                SqlDataReader Ra = cmd3.ExecuteReader();

                if (Ra.Read())
                {
                    d = Ra[2].ToString();

                }
                else
                {
                    d = "1";
                }


                Ra.Close();
                con.Close();


                if (a >= Convert.ToDouble(d))
                {
                    MessageBox.Show("%" + "لا يوجد لديك صلاحية بخصم أكثر من " + d.ToString(), "صلاحية ممنوعة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_DiscountP.Text = "0";
                }

                if (text_DiscountP.Text == "")
                {
                    text_DiscountP.Text = "0";
                }


                TotalAmount();
                totalAmount = text_totalAmount.Text;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1020 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_totalAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {

                lbl_cc.Text = text_totalAmount.Text;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1021 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }




        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {



                SqlCommand cmd = con.CreateCommand();

                cmd2 = new SqlCommand("select Barcode,ItemName,cost_Sales,TAX from Drugs_NOW where ItemName like @ItemName ", con);
                cmd2.Parameters.Add(new SqlParameter("@ItemName", "%" + textBox4.Text + "%"));
                con.Open();

                dr2 = cmd2.ExecuteReader();
                dr2.Read();
                if (e.KeyCode == Keys.Enter)
                {
                    textBox3.Text = dr2["Barcode"].ToString();
                    textBox3.Focus();
                    textBox4.Clear();
                    dr2.Close();
                    con.Close();
                }
                dr2.Close();
                con.Close();
                //while (dr2.Read())
                //{

                //    if (e.KeyCode == Keys.Enter)
                //    {

                //        dataGridView1.Rows.Add(i, dr2["Barcode"].ToString(), textBox4.Text, 1, dr2["cost_Sales"].ToString(), "", 0, dr2["TAX"].ToString());
                //        textBox4.Text = "";
                //        textBox3.Focus();

                //    }
                //    Total();
                //    N_Items();
                //    SubTotal();
                //    TotalAmount();
                //    totalAmount = text_totalAmount.Text;
                //    i += 1;

                //}
                //dr2.Close();
                //con.Close();


            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1022 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CON = "";
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1023 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CON = "ONAccount";
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1024 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CON = "Credit";
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1025 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        string Name_Measures;
        //------------------------------------------------------------------------------------------------------------------------------------------------
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {





                if (e.KeyCode == Keys.Enter)
                {

                    if (textBox1.Text == "")
                    {

                    }
                    else
                    {
                        //------------ قائمة التأمينات ---------------------------//
                        DataTable Dt5 = new DataTable();
                        SqlCommand ca5 = new SqlCommand("select Name_pat,number_Measures from Table_PAT where number_Measures=@number_Measures", con);
                        ca5.Parameters.Add(new SqlParameter("number_Measures", textBox1.Text));
                        SqlDataAdapter Da5 = new SqlDataAdapter(ca5);
                        Da5.Fill(Dt5);
                        textBox2.DataSource = Dt5;
                        textBox2.DisplayMember = "Name_pat";
                        textBox2.ValueMember = "Name_pat";

                        //------------ ----------------- ---------------------------//


                        textBox2.Focus();




                        try
                        {
                            con.Open();
                            SqlCommand cmd21 = new SqlCommand("select Name_Measures,number_Measures from Table_PAT where number_Measures=@number_Measures1", con);
                            cmd21.Parameters.Add(new SqlParameter("@number_Measures1", textBox1.Text));
                            SqlDataReader dr13;
                            dr13 = cmd21.ExecuteReader();
                            int count = 0;
                            if (dr13.Read())
                            {
                                count += 1;

                            }

                            con.Close();
                            if (count == 1)
                            {
                                SqlCommand cmd33 = con.CreateCommand();

                                cmd33 = new SqlCommand("select Name_Measures,number_Measures from Table_PAT where number_Measures =@number_Measures ", con);
                                cmd33.Parameters.Add(new SqlParameter("@number_Measures", textBox1.Text));
                                con.Open();
                                //cmd2.ExecuteNonQuery();
                                SqlDataReader dr221;

                                dr221 = cmd33.ExecuteReader();
                                dr221.Read();

                                Name_Measures = dr221["Name_Measures"].ToString();

                                dr221.Close();
                                con.Close();

                                po = 0;

                            }

                            else
                            {
                                MessageBox.Show("لا يوجد تأمين بهذا الرقم", "لا يوجد", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }
                        catch (Exception ee)
                        {
                            con.Close();
                            MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1026 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1027 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex == -1)
                {
                    return;
                }
                if (e.ColumnIndex != 5)
                {
                    return;
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[5].Value != "")
                {
                    try
                    {
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1028 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    con.Open();
                    SqlCommand cmd2;
                    SqlDataReader dr2;
                    cmd2 = new SqlCommand("select * from Drugs_NOW where Barcode = @Barcode ", con);
                    //for (int i = 0; i < dataGridView1.Rows.Count-1 ; )
                    //{

                    cmd2.Parameters.Add(new SqlParameter("@Barcode", "" + dataGridView1.Rows[e.RowIndex].Cells[1].Value + ""));

                    dr2 = cmd2.ExecuteReader();
                    dr2.Read();
                    //عدد الاشرطة
                    double SDR = Convert.ToDouble(dr2[12].ToString());
                    double SP = Convert.ToDouble(dr2[11].ToString());
                    double APR = SP / SDR;

                    double AADDP = APR * Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].Value);

                    dataGridView1.Rows[e.RowIndex].Cells[8].Value = AADDP;
                    dr2.Close();
                    //}

                    con.Close();

                    Total();
                    N_Items();
                    SubTotal();
                    TotalAmount();
                    totalAmount = text_totalAmount.Text;

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1029 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public int i = 1;
        int EW;
        int EE;
        public void BackdatagridView()
        {
            try
            {
                dataGridView1.Rows.Clear();
                i = 1;
                if (Convert.ToInt32(label5.Text) < 1)
                {
                    EW = Convert.ToInt32(EE);

                    textBox1.Text = "";
                    textBox2.Text = "";

                    label5.Text = Convert.ToString(EE);
                    MessageBox.Show("لايوجد فاتورة بهذا الرقم ، تم استرجاعك الى اخر فاتورة ،، شكرا");



                    SqlCommand na = new SqlCommand();
                    na = new SqlCommand("select IDCustomer,NameCustomer,N,code,ItemName,Quantity,SellingPrice,RetailPrice,Discount,Tax from Invoice where InvoiceNo='" + EE + "'", con);
                    con.Open();
                    na.ExecuteNonQuery();
                    SqlDataReader dr;

                    dr = na.ExecuteReader();
                    while (dr.Read())
                    {


                        textBox1.Text = dr["IDCustomer"].ToString();
                        textBox2.Text = dr["NameCustomer"].ToString();

                        dataGridView1.Rows.Add(i, dr["code"].ToString(), dr["ItemName"].ToString(), dr["Quantity"].ToString(), dr["SellingPrice"].ToString(), dr["RetailPrice"].ToString(), dr["Discount"].ToString(), dr["Tax"].ToString());
                        //textBox3.Text = "";
                        //textBox3.Focus();

                        Total();
                        N_Items();
                        SubTotal();
                        TotalAmount();
                        totalAmount = text_totalAmount.Text;

                    }
                    con.Close();
                }
                else
                {
                    con.Open();


                    EW -= 1;
                    label5.Text = EW.ToString();

                    SqlCommand na = new SqlCommand();
                    na = new SqlCommand("select Account,IDCustomer,NameCustomer,N,code,ItemName,Quantity,SellingPrice,RetailPrice,Discount,Tax,Name_Measures from Invoice where InvoiceNo='" + EW + "'", con);
                    na.ExecuteNonQuery();
                    SqlDataReader dr;

                    dr = na.ExecuteReader();
                    while (dr.Read())
                    {

                        if (dr["Account"].ToString() == "Cash")
                        {
                            radioButton1.Checked = true;
                        }
                        if (dr["Account"].ToString() == "ON Account")
                        {
                            radioButton2.Checked = true;

                        }
                        if (dr["Account"].ToString() == "Credit")
                        {
                            radioButton3.Checked = true;

                        }
                        flagcombo = 1;
                        textBox1.Text = dr["Name_Measures"].ToString();
                        flagcombo = 0;
                        string nn = dr["NameCustomer"].ToString();
                        textBox2.Text = nn;

                        dataGridView1.Rows.Add(i, dr["code"].ToString(), dr["ItemName"].ToString(), dr["Quantity"].ToString(), dr["SellingPrice"].ToString(), dr["RetailPrice"].ToString(), dr["Discount"].ToString(), dr["Tax"].ToString());
                        //textBox3.Text = "";
                        //textBox3.Focus();

                        Total();
                        N_Items();
                        SubTotal();
                        TotalAmount();
                        totalAmount = text_totalAmount.Text;
                        i += 1;
                    }


                    dr.Close();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1030 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        public void BackdatagridViewPlus()
        {
            try
            {

                dataGridView1.Rows.Clear();
                i = 1;
                if (Convert.ToInt32(EW) >= Convert.ToInt32(ED))
                {

                    EW = Convert.ToInt32(ED);
                    radioButton1.Checked = true;

                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    EW += 1;
                    label5.Text = EW.ToString();

                    SqlCommand na = new SqlCommand();
                    na = new SqlCommand("select Account,IDCustomer,NameCustomer,N,code,ItemName,Quantity,SellingPrice,RetailPrice,Discount,Tax,Name_Measures from Invoice where InvoiceNo='" + EW + "'", con);
                    con.Open();
                    na.ExecuteNonQuery();
                    SqlDataReader dr;

                    dr = na.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr["Account"].ToString() == "Cash")
                        {
                            radioButton1.Checked = true;
                        }
                        if (dr["Account"].ToString() == "ON Account")
                        {
                            radioButton2.Checked = true;

                        }
                        if (dr["Account"].ToString() == "Credit")
                        {
                            radioButton3.Checked = true;

                        }
                        flagcombo = 1;
                        textBox1.Text = dr["Name_Measures"].ToString();
                        flagcombo = 0;
                        textBox2.Text= dr["NameCustomer"].ToString();

                        dataGridView1.Rows.Add(i, dr["code"].ToString(), dr["ItemName"].ToString(), dr["Quantity"].ToString(), dr["SellingPrice"].ToString(), dr["RetailPrice"].ToString(), dr["Discount"].ToString(), dr["Tax"].ToString());
                        //textBox3.Text = "";
                        //textBox3.Focus();

                        Total();
                        N_Items();
                        SubTotal();
                        TotalAmount();
                        totalAmount = text_totalAmount.Text;
                        i += 1;
                    }


                    dr.Close();
                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1031 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Barcode                          F7")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;


            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Barcode                          F7";
                textBox3.ForeColor = Color.Silver;


            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "C Barcode                       F1")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;


            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "C Barcode                       F1";
                textBox6.ForeColor = Color.Silver;


            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox6.Text == "")
                    {
                        MessageBox.Show("لا يوجد منتج بهذا الباركود");
                        return;
                    }
                    if (textBox6.Text == "'")
                    {
                        MessageBox.Show("لا يوجد منتج بهذا الباركود");
                        return;
                    }
                    else
                    {

                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select Medication_ID,Code,ItemName,SalePrice,Tax from Medication where Medication_ID=@Medication_ID", con);
                        na.Parameters.Add(new SqlParameter("@Medication_ID", textBox6.Text.Trim().ToString()));
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();
                        while (dr.Read())
                        {



                            dataGridView1.Rows.Add(i, dr["Code"].ToString(), dr["ItemName"].ToString(), 1, dr["SalePrice"].ToString(), "", 0, dr["Tax"].ToString());
                            textBox6.Text = "";
                            textBox6.Focus();


                            Total();
                            N_Items();
                            SubTotal();
                            TotalAmount();
                            totalAmount = text_totalAmount.Text;
                            i += 1;
                        }
                        dr.Close();
                        con.Close();

                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1032 Point_sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void إغلاقالنظامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void تجزئةمادةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Retail ssa = new Add_Retail();
            ssa.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Invoice_Parchase Form = new Invoice_Parchase();
            Form.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Orders_Damage ss = new Orders_Damage();
            ss.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Add_Mesures ss = new Add_Mesures();
            ss.Show();
        }

        private void جردالشفتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void جردالموادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            End_orders ss = new End_orders();
            ss.Show();
        }

        private void تعريفمادةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADD_recpie ss = new ADD_recpie();
            ss.Show();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("تم تشغيل الأوامر الصوتية", "الأوامر الصوتية", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            cd.Add(new string[] { "close", "Stop", "Save", "New", "Barcode", "Cancel" });
            Grammar gr = new Grammar(new GrammarBuilder(cd));



            try
            {

                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

            }

        }

        private void الذهابالىالاستقبالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            home hh = new home();
            hh.Show();
            this.Close();
        }

        private void كشفالموادالمنتهيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materials_EndDate ss = new materials_EndDate();
            ss.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }
        int ii = 0;
        int i2 = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {



                //Bitmap bmp = Properties.Resources.s2;
                //Image newimage = bmp;
                //e.Graphics.DrawImage(newimage, 120, 0, newimage.Width, newimage.Height);
                //e.Graphics.DrawImage(newimage, 690, 0, newimage.Width, newimage.Height);
                e.Graphics.DrawString("صيدلية الزاجل", new Font("Arial", 35, FontStyle.Bold), Brushes.Black, new Point(320, 30));

                e.Graphics.DrawString("اســــم الـــدواء", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(50, 170));
                e.Graphics.DrawString("الكمية", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(600, 170));
                e.Graphics.DrawString("السعر", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(740, 170));

                if (dataGridView1.Rows.Count > 1)
                {
                    int higt = 230;


                    for (i2 = ii; i2 < dataGridView1.Rows.Count - 1; i2++)
                    {


                        e.HasMorePages = false;


                        e.Graphics.DrawString(dataGridView1.Rows[i2].Cells[0].Value.ToString() + " - " + "  " + dataGridView1.Rows[i2].Cells[2].Value.ToString(), new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(50, higt));

                        e.Graphics.DrawString(dataGridView1.Rows[i2].Cells[8].Value.ToString(), new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(760, higt));
                        e.Graphics.DrawString(dataGridView1.Rows[i2].Cells[3].Value.ToString(), new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(630, higt));


                        higt = higt + 40;


                        if (higt >= 1000)
                        {
                            higt = 50;
                            e.HasMorePages = true;
                            ii = i2 + 1;

                            break;

                        }

                    }
                    if (i2 == dataGridView1.Rows.Count - 1)
                    {
                        ii = 0;
                    }

                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1020 recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            }

        private void textBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //------------ قائمة اسماء الشركات ---------------------------//
            if (flagcombo != 1)
            {
                if (textBox1.SelectedIndex != -1)
                {
                    DataTable DDT = new DataTable();
                    SqlCommand na = new SqlCommand();
                    na = new SqlCommand("select Name_pat from Table_PAT where Name_Measures like @Name_Measures", con);
                    na.Parameters.AddWithValue("@Name_Measures", "%" + textBox1.Text + "%");
                    SqlDataAdapter DDA = new SqlDataAdapter(na);
                    DDA.Fill(DDT);
                    textBox2.DataSource = DDT;
                    textBox2.DisplayMember = "Name_pat";
                    textBox2.ValueMember = "Name_pat";
                    textBox2.SelectedIndex = -1;

                    //------------ قائمة اسماء الشركات ---------------------------//
                }
            }
        }

        private void سندإدخالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entry_Bond Form = new Entry_Bond();
            Form.Show();
        }

        private void سندإخراجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Out_Bond Form = new Out_Bond();
            Form.Show();
        }

        private void سندالإتلافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Destruction_Bond Form = new Destruction_Bond();
            Form.Show();
        }

        private void lbl_cc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



