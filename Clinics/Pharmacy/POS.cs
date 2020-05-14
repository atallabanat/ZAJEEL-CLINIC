using Clinics.Class;
using Clinics.Grid;
using Clinics.pharmacy_Control;
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
    public partial class POS : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        msgShow msg = new msgShow();
        ClsHistory history = new ClsHistory();
        DocType docType = new DocType();
        // public Virable 
        int Status;
        double PRS_JD;
        double PRS_Precent;
        public static POS pOS;
        int NewRow = -1;
        public string MYear;
        //--------------selectPet--------------
        public string Name_pat;
        public string Name_Measures;
        public string number_Measures;
        public string presnt_Measures;
        //--------------selectPet--------------
        public POS()
        {
            pOS = this;
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        public void OpenMU()
        {
            if (radioInc.Checked == true)
            {
                lbl_Name_MU.Visible = true;
                textBox_Name_MU.Visible = true;
                lbl_Name_Pat.Visible = true;
                textBox_Name_Pat.Visible = true;

                SelectPet FrmSelectPet = new SelectPet();
                FrmSelectPet.ShowDialog();
            }
            else
            {
                lbl_Name_MU.Visible = false;
                textBox_Name_MU.Visible = false;
                lbl_Name_Pat.Visible = false;
                textBox_Name_Pat.Visible = false;

                Name_pat = string.Empty;
                Name_Measures = string.Empty;
                number_Measures = string.Empty;
                presnt_Measures = string.Empty;
            }
        }
        public void SubTotal()
        {
            try
            {
                double sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[Clm_T_Total.Name].Value);                    
                }
                text_subTotal.Text = Convert.ToDouble(sum).ToString();
            }
            catch
            {

            }
        }
        public void ALLEventSum()
        {
            Total();
            N_Items();
            SubTotal();
            TotalAmount();
        }
        private void btn_View_Bond_No_Click(object sender, EventArgs e)
        {
            Grid_QauntityPOS.SCR_POS = true;
            Grid_QauntityPOS grid = new Grid_QauntityPOS();
            grid.ShowDialog();
            Grid_QauntityPOS.SCR_POS = false;
            textBarcode.Text = string.Empty;
        }
        public void N_Items()
        {
            try
            {
                text_N_ITems.Text = dataGridView1.RowCount.ToString();
            }
            catch
            {

            }
        }
        private void DiscountUser()
        {
            try
            {
                con.Open();
                SqlCommand cmd3 = new SqlCommand("select PRS_JD,PRS_Precent from " + D.DataPharmacy+ "PRS where IDUser=@IDUser", con);
                cmd3.Parameters.Add(new SqlParameter("@IDUser", Program.user_ID));                
                SqlDataReader Ra = cmd3.ExecuteReader();

                if (Ra.Read())
                {                    
                    PRS_JD =Convert.ToDouble(Ra["PRS_JD"].ToString());
                    PRS_Precent=Convert.ToDouble(Ra["PRS_Precent"].ToString());
                }
                else
                {
                    PRS_JD = 0;
                    PRS_Precent = 0;
                }
                Ra.Close();
            }
            catch
            {
                PRS_JD = 0;
                PRS_Precent = 0;
                msg.Alert("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + "ERORR POS 1",Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }
        }
        private void POS_Load(object sender, EventArgs e)
        {
            try
            {
                MaxInvoice();
                DiscountUser();
                text_nameStaff.Text = Program.Name_User;
                textBoxDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            catch
            {

            }
        }
        public void MaxInvoice()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select convert(nvarchar(4),getdate(),111) as MYear", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    MYear = dr["MYear"].ToString();
                }
                textBarcode.Focus();
            }
            catch (Exception ex)
            {
                msg.Alert("حدث خلل بسيط" + "ERROR POS 2 MYear" + ex.Message, Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }

            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull(max(ID)+1,1) as IDMax from " + D.DataPharmacy + "invoice_Sales where MYear=@MYear", con);
                cmd21.Parameters.AddWithValue("@MYear", MYear);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    label5.Text = dr["IDMax"].ToString();
                }
                textBarcode.Focus();
            }
            catch (Exception ex)
            {
                msg.Alert("حدث خلل بسيط"+"ERROR POS 1 Max ID" + ex.Message, Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }

            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select COUNT(distinct ID) as CountInvoice from " + D.DataPharmacy + "invoice_Sales where Bill_Suspension = 1 and ID_User=@ID_User and Myear=@Myear", con);
                cmd21.Parameters.AddWithValue("@MYear", MYear);
                cmd21.Parameters.AddWithValue("@ID_User", Program.user_ID);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                     lblCountInvoice.Text = dr["CountInvoice"].ToString();
                }
                textBarcode.Focus();
            }
            catch (Exception ex)
            {
                msg.Alert("حدث خلل بسيط" + "ERROR POS 77 CountInvoice" + ex.Message, Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            ALLEventSum();
            TotalAmount();
        }

        private void text_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TotalAmount();
                if (text_Discount.Text != string.Empty)
                {
                    if (Convert.ToDouble(text_Discount.Text) > PRS_JD)
                    {
                        text_Discount.Text = string.Empty;
                        msg.Alert("عذرا لا يوجد لديك صلاحية لخصم أكثر من "+PRS_JD+" دينار ",Form_Alert.enumType.Warning);
                        text_Discount.Text = PRS_JD.ToString();
                        text_Discount.Focus();
                        
                    }
                }
            }
            catch
            {

            }
        }

        private void text_DiscountP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TotalAmount();
                if (text_DiscountP.Text != string.Empty)
                {
                    if (Convert.ToDouble(text_DiscountP.Text) > PRS_Precent)
                    {
                        text_DiscountP.Text = string.Empty;
                        msg.Alert("عذرا لا يوجد لديك صلاحية لخصم أكثر من " + PRS_Precent + " % ", Form_Alert.enumType.Warning);
                        text_DiscountP.Text = PRS_Precent.ToString();
                        text_DiscountP.Focus();
                        TotalAmount();
                    }
                }
            }
            catch
            {

            }
        }
        public void TotalAmount()
        {
            double Dis=0;
            double DisP=0;
            double TotalAmount=0;
            double sub = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                {
                    if(text_subTotal.Text==string.Empty)
                    {
                        sub = 0;
                    }
                    else
                    {
                        sub = Convert.ToDouble(text_subTotal.Text);
                    }
                     
                    if(text_Discount.Text==string.Empty)
                    {
                        Dis = 0;
                    }
                    else
                    {
                        Dis = Convert.ToDouble(text_Discount.Text);
                    }
                    if(text_DiscountP.Text==string.Empty)
                    {
                        DisP = 0;
                    }
                    else
                    {
                        DisP = Convert.ToDouble(text_DiscountP.Text.ToString());
                    }                 
                     TotalAmount = (sub - Dis - (sub * (DisP / 100)));
                    text_totalAmount.Text = TotalAmount.ToString();
                }
            }
            catch
            {
                msg.Alert("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + "ERORR POS 3", Form_Alert.enumType.Error);
            }

        }
        private void text_totalAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {

                lbl_cc.Text = text_totalAmount.Text;
            }
            catch
            {
                msg.Alert("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + "ERORR POS 2", Form_Alert.enumType.Error);
            }
        }

        private void text_N_ITems_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        private void textBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            double QuntityNow;
            string EndDateItem;
            double NrOfDays;
            DateTime d1 = DateTime.Now;
            DateTime d2;

                if (e.KeyCode == Keys.Enter)
                {

                    if (textBarcode.Text != string.Empty)
                    {
                        try
                        {
                            try
                            {
                                con.Open();
                                SqlCommand na = new SqlCommand();
                                DataTable dt=new DataTable();
                                na = new SqlCommand("select A.* from (SELECT     R_Barcode,R_ItemName,sum(case when Kind = 1  then R_Qty+R_Bouns else 0 end) - sum(case when Kind = 2 then R_Qty else 0 end) as R_Qty,R_PriceSales,R_PriceParchase ,convert(nvarchar(10), R_DateItem,110) as R_DateItem , R_Tax FROM " + D.DataPharmacy+ "i2_trans where R_Barcode=@R_Barcode  group by R_Barcode,R_ItemName,R_PriceSales,R_PriceParchase, R_DateItem,R_Tax)A where A.R_Qty > 0 ", con);
                                na.Parameters.AddWithValue("@R_Barcode", textBarcode.Text);                                
                                SqlDataAdapter da = new SqlDataAdapter(na);
                                da.Fill(dt);
                                textBarcode.Text = string.Empty;
                                if (dt.Rows.Count > 0)
                                {    
                                    if(dt.Rows.Count == 1)
                                    {
                                        try
                                        {
                                            QuntityNow = Convert.ToDouble(dt.Rows[0][2]);
                                        }
                                        catch
                                        {
                                            QuntityNow = 0;
                                        }

                                        if(QuntityNow > 0 )
                                        {
                                            EndDateItem = dt.Rows[0][4].ToString();
                                            d2 = Convert.ToDateTime(EndDateItem);
                                            TimeSpan t = d1 - d2;
                                            NrOfDays = t.TotalDays;
                                            if (NrOfDays > 0)
                                            {
                                                msg.Alert("عذرا المادة منتهية الصلاحية ، لا يمكنك بيع مادة منتهية الصلاحية",Form_Alert.enumType.Warning);
                                            }
                                            else
                                            {
                                                if(QuntityNow > 0 && QuntityNow < 1)
                                                {
                                                    dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, dt.Rows[0]["R_Barcode"], dt.Rows[0]["R_ItemName"], dt.Rows[0]["R_Qty"], dt.Rows[0]["R_PriceSales"], "", "", dt.Rows[0]["R_Tax"],"", EndDateItem,dt.Rows[0]["R_PriceParchase"]);
                                                }
                                                else
                                                {
                                                    dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, dt.Rows[0]["R_Barcode"], dt.Rows[0]["R_ItemName"], 1, dt.Rows[0]["R_PriceSales"],"","", dt.Rows[0]["R_Tax"],"", EndDateItem, dt.Rows[0]["R_PriceParchase"]);
                                                }
                                                
                                            }
                                        }
                                        else
                                        {
                                            msg.Alert(" لا يوجد كمية ، عذرا لقد نفذت الكمية من هذه المادة", Form_Alert.enumType.Warning);
                                        }
                                    }
                                    else if(dt.Rows.Count > 1)
                                    {
                                        count2 FrmCount2 = new count2();
                                        count2.count22.dataGridView1.DataSource = dt;
                                        FrmCount2.ShowDialog();
                                    }
                                }
                                else
                                {
                                    msg.Alert("عذرا هذه المادة غير متوفرة أو نفذت الكمية أو غير معرفة مسبقا",Form_Alert.enumType.Warning);
                                }
                            }
                            catch
                            {

                            }
                            finally
                            {
                                con.Close();
                                ALLEventSum();
                                TotalAmount();
                                textBarcode.Focus();
                            }
                        }
                        catch
                        {

                        }
                        finally
                        {
                            ALLEventSum();
                            TotalAmount();
                            textBarcode.Focus();
                        }
                    }
                }
        }

        private void textBarcode_Enter(object sender, EventArgs e)
        {
            if (textBarcode.Text == "Barcode                                                                                              F7")
            {
                textBarcode.Text = string.Empty;
                textBarcode.ForeColor = Color.Black;
            }
        }

        private void textBarcode_Leave(object sender, EventArgs e)
        {
            if (textBarcode.Text == string.Empty)
            {
                textBarcode.Text = "Barcode                                                                                              F7";
                textBarcode.ForeColor = Color.Silver;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "C Barcode                                                                                           F1")
            {
                textBox6.Text = string.Empty;
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                textBox6.Text = "C Barcode                                                                                           F1";
                textBox6.ForeColor = Color.Silver;
            }

        }

        public void radioCash_Click(object sender, EventArgs e)
        {
            if (radioCash.Checked == true)
            {
                Status = 0;
                OpenMU();
            }
            else if (radioAP.Checked == true)
            {
                Status = 1;
                OpenMU();
            }
            else if (radioCredit.Checked == true)
            {
                Status = 2;
                OpenMU();
            }
            else if (radioInc.Checked == true)
            {
                Status = 3;
                OpenMU();
            }

        }

        private void radioAP_Click(object sender, EventArgs e)
        {
            if (radioCash.Checked == true)
            {
                Status = 0;
                OpenMU();
            }
            else if (radioAP.Checked == true)
            {
                Status = 1;
                OpenMU();
            }
            else if (radioCredit.Checked == true)
            {
                Status = 2;
                OpenMU();
            }
            else if (radioInc.Checked == true)
            {
                Status = 3;
                OpenMU();
            }

        }

        private void radioCredit_Click(object sender, EventArgs e)
        {
            if (radioCash.Checked == true)
            {
                Status = 0;
                OpenMU();
            }
            else if (radioAP.Checked == true)
            {
                Status = 1;
                OpenMU();
            }
            else if (radioCredit.Checked == true)
            {
                Status = 2;
                OpenMU();
            }
            else if (radioInc.Checked == true)
            {
                Status = 3;
                OpenMU();
            }

        }
        public void Total()
        {
            double Number_Retail;
            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                {
                    if (dataGridView1.Rows[i].Cells[clm_RetailPrice.Name].Value == string.Empty || dataGridView1.Rows[i].Cells[clm_RetailPrice.Name].Value == null )
                    {
                        double QQ;
                        if (dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value==string.Empty || dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value==null)
                        {
                            QQ = 1;
                            dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value = 1;
                        }
                        else
                        {                            
                            QQ = Convert.ToDouble(dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value);
                        }
                        
                        double SS = Convert.ToDouble(dataGridView1.Rows[i].Cells[clm_SellingPrice.Name].Value);
                        double DD;
                        if (dataGridView1.Rows[i].Cells[clm_Discount.Name].Value==string.Empty || dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == null)
                        {
                            DD = 0;
                        }
                        else
                        {
                            DD = Convert.ToDouble(dataGridView1.Rows[i].Cells[clm_Discount.Name].Value);
                        }
                        double TT = (QQ * SS) - DD;

                        dataGridView1.Rows[i].Cells[Clm_T_Total.Name].Value = TT;
                        dataGridView1.Rows[i].Cells[clm_RetailQTY.Name].Value = null;
                    }
                    else
                    {
                        try
                        {
                            con.Open();
                            SqlCommand na = new SqlCommand();
                            na = new SqlCommand("select Number_Retail from "+D.DataPharmacy+"Drugs where Code=@Code", con);
                            na.Parameters.AddWithValue("@Code", dataGridView1.Rows[i].Cells[clm_code.Name].Value);                            
                            SqlDataReader dr;
                            dr = na.ExecuteReader();
                            if (dr.Read())
                            {
                                Number_Retail = Convert.ToDouble(dr["Number_Retail"]);
                                double SalePrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[clm_SellingPrice.Name].Value);
                                double TNumber_Retail = SalePrice / Number_Retail;
                                double RowQQ = Convert.ToDouble(dataGridView1.Rows[i].Cells[clm_RetailPrice.Name].Value);
                                double DD;
                                if (dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == string.Empty || dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == null)
                                {
                                    DD = 0;
                                }
                                else
                                {
                                    DD = Convert.ToDouble(dataGridView1.Rows[i].Cells[clm_Discount.Name].Value);
                                }
                                double RetailQTY = RowQQ / Number_Retail;
                                dataGridView1.Rows[i].Cells[clm_RetailQTY.Name].Value = RetailQTY.ToString();
                                double TotalRow = (TNumber_Retail * RowQQ) - DD;
                                dataGridView1.Rows[i].Cells[Clm_T_Total.Name].Value = TotalRow.ToString();
                                dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value = string.Empty;
                                dr.Close();
                            }
                            
                        }
                        catch
                        {

                        }
                        finally
                        {
                            con.Close();
                        }                        
                    }
                }
            }
            catch
            {
                
            }

        }

        private void radioInc_Click(object sender, EventArgs e)
        {
            if (radioCash.Checked == true)
            {
                Status = 0;
                OpenMU();
            }
            else if (radioAP.Checked == true)
            {
                Status = 1;
                OpenMU();
            }
            else if (radioCredit.Checked == true)
            {
                Status = 2;
                OpenMU();
            }
            else if (radioInc.Checked == true)
            {
                Status = 3;
                OpenMU();
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                Add_Mesures ss = new Add_Mesures();
                ss.Show();
            }
            catch
            {

            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ALLEventSum();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.Rows.Count <= 0)
                {
                    msg.Alert("لا يمكن فتح شاشة الحساب ، لا يوجد بيانات",Form_Alert.enumType.Warning);
                    return;
                }
                if (lbl_Name_MU.Visible == true)
                {
                    Dic_Pet ss = new Dic_Pet();
                    ss.ShowDialog();
                }
                else
                {
                    PaidEND nn = new PaidEND();
                    nn.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                msg.Alert("حدث خلل بسيط" + "ERROR POS 1 Account Load" + ex.Message, Form_Alert.enumType.Error);
            }

        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
            catch
            {

            }
        }

        private void إغلاقالنظامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            {
                Application.Exit();
            }
        }

        private void الذهابالىالاستقبالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                home hh = new home();
                hh.Show();
                this.Close();
            }
            catch
            {

            }
        }
        public void ClearScreen()
        {
            radioCash.Checked = true;
            if (radioCash.Checked == true)
            {
                Status = 0;
                OpenMU();
            }
            else if (radioAP.Checked == true)
            {
                Status = 1;
                OpenMU();
            }
            else if (radioCredit.Checked == true)
            {
                Status = 2;
                OpenMU();
            }
            else if (radioInc.Checked == true)
            {
                Status = 3;
                OpenMU();
            }

            dataGridView1.Rows.Clear();
            text_Discount.Text = string.Empty;
            text_DiscountP.Text = string.Empty;
            text_N_ITems.Text = "0";
            text_subTotal.Text = "0";
            text_totalAmount.Text = "00.000";
            lbl_cc.Text = "00.000";
        }
        public bool ADD_Row_Dic_Pet(string number_Measures,string Name_Measures,string Name_pat,string presnt_Measures,string berfore_Total,string lbl_cc)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "INSERT INTO  " + D.DataPharmacy + "Invoice_Sales (ID,MYear, DateInvoice, Time, NameStaff, Status, Number_Measures, Name_MU, Name_Pat, Presnt_Measures, R_Barcode, R_ItemName, R_Qty, R_QtyRetail, R_SellingPrice, R_Discount, R_Tax, R_Total, R_DateItem, N_ITems_Invoice, SubTotal_Invoice, Discount_Invoice, DiscountP_Invoice, TotalAmount_Invoice, ID_User, Bill_Suspension) VALUES        (@ID,@MYear, @DateInvoice, (select CONVERT(varchar(15),CAST(getdate() AS TIME),100) AS Time), @NameStaff, @Status, @Number_Measures, @Name_MU, @Name_Pat, @Presnt_Measures, @R_Barcode, @R_ItemName, @R_Qty, @R_QtyRetail, @R_SellingPrice, @R_Discount, @R_Tax, @R_Total, @R_DateItem, @N_ITems_Invoice, @SubTotal_Invoice, @Discount_Invoice, @DiscountP_Invoice, @TotalAmount_Invoice, @ID_User, @Bill_Suspension)";

                    cmd.Parameters.AddWithValue("@ID", label5.Text);
                    cmd.Parameters.AddWithValue("@MYear", MYear);
                    cmd.Parameters.AddWithValue("@DateInvoice", textBoxDate.Text);
                    cmd.Parameters.AddWithValue("@NameStaff", text_nameStaff.Text);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Number_Measures", number_Measures);
                    cmd.Parameters.AddWithValue("@Name_MU", Name_Measures);
                    cmd.Parameters.AddWithValue("@Name_Pat", Name_pat);
                    cmd.Parameters.AddWithValue("@Presnt_Measures", presnt_Measures);

                    cmd.Parameters.AddWithValue("@R_Barcode", dataGridView1.Rows[i].Cells[clm_code.Name].Value);
                    cmd.Parameters.AddWithValue("@R_ItemName", dataGridView1.Rows[i].Cells[Column2.Name].Value);
                    if(dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value==string.Empty || dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value==null)
                    {
                        cmd.Parameters.AddWithValue("@R_Qty", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Qty", dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value);
                    }
                    if(dataGridView1.Rows[i].Cells[clm_RetailPrice.Name].Value==string.Empty || dataGridView1.Rows[i].Cells[clm_RetailPrice.Name].Value==null)
                    {
                        cmd.Parameters.AddWithValue("@R_QtyRetail", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_QtyRetail", dataGridView1.Rows[i].Cells[clm_RetailPrice.Name].Value);
                    }                    
                    cmd.Parameters.AddWithValue("@R_SellingPrice", dataGridView1.Rows[i].Cells[clm_SellingPrice.Name].Value);

                    if (dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == "" || dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", dataGridView1.Rows[i].Cells[clm_Discount.Name].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[Column8.Name].Value == "" || dataGridView1.Rows[i].Cells[Column8.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Tax", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Tax", dataGridView1.Rows[i].Cells[Column8.Name].Value);
                    }
                    cmd.Parameters.AddWithValue("@R_Total", dataGridView1.Rows[i].Cells[Clm_T_Total.Name].Value);
                    cmd.Parameters.AddWithValue("@R_DateItem", dataGridView1.Rows[i].Cells[Clm_R_DateItem.Name].Value);
                    cmd.Parameters.AddWithValue("@N_ITems_Invoice", text_N_ITems.Text);
                    cmd.Parameters.AddWithValue("@SubTotal_Invoice", berfore_Total);
                    if (text_Discount.Text == string.Empty || text_Discount.Text == null)
                    {
                        cmd.Parameters.AddWithValue("@Discount_Invoice", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Discount_Invoice", text_Discount.Text);
                    }
                    if (text_DiscountP.Text == string.Empty || text_DiscountP.Text == null)
                    {
                        cmd.Parameters.AddWithValue("@DiscountP_Invoice", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DiscountP_Invoice", text_DiscountP.Text);
                    }
                    cmd.Parameters.AddWithValue("@TotalAmount_Invoice", lbl_cc);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.Parameters.AddWithValue("@Bill_Suspension", 0);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;

            }
            catch (Exception ee)
            {
                msg.Alert("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا ERROR 1026 Invoice_Sales" + ee.Message, Form_Alert.enumType.Error);
                return false;
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

                    cmd.CommandText = "INSERT INTO  " + D.DataPharmacy + "Invoice_Sales (ID,MYear, DateInvoice, Time, NameStaff, Status, Number_Measures, Name_MU, Name_Pat, Presnt_Measures, R_Barcode, R_ItemName, R_Qty, R_QtyRetail, R_SellingPrice, R_Discount, R_Tax, R_Total, R_DateItem, N_ITems_Invoice, SubTotal_Invoice, Discount_Invoice, DiscountP_Invoice, TotalAmount_Invoice, ID_User, Bill_Suspension) VALUES        (@ID,@MYear, @DateInvoice, (select CONVERT(varchar(15),CAST(getdate() AS TIME),100) AS Time), @NameStaff, @Status, @Number_Measures, @Name_MU, @Name_Pat, @Presnt_Measures, @R_Barcode, @R_ItemName, @R_Qty, @R_QtyRetail, @R_SellingPrice, @R_Discount, @R_Tax, @R_Total, @R_DateItem, @N_ITems_Invoice, @SubTotal_Invoice, @Discount_Invoice, @DiscountP_Invoice, @TotalAmount_Invoice, @ID_User, @Bill_Suspension)";

                    cmd.Parameters.AddWithValue("@ID", label5.Text);
                    cmd.Parameters.AddWithValue("@MYear", MYear);
                    cmd.Parameters.AddWithValue("@DateInvoice", textBoxDate.Text);
                    cmd.Parameters.AddWithValue("@NameStaff", text_nameStaff.Text);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Number_Measures", "");
                    cmd.Parameters.AddWithValue("@Name_MU", "");
                    cmd.Parameters.AddWithValue("@Name_Pat", "");
                    cmd.Parameters.AddWithValue("@Presnt_Measures", "");

                    cmd.Parameters.AddWithValue("@R_Barcode", dataGridView1.Rows[i].Cells[clm_code.Name].Value);
                    cmd.Parameters.AddWithValue("@R_ItemName", dataGridView1.Rows[i].Cells[Column2.Name].Value);
                    if (dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value == string.Empty || dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Qty", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Qty", dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[clm_RetailPrice.Name].Value == string.Empty || dataGridView1.Rows[i].Cells[clm_RetailPrice.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_QtyRetail", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_QtyRetail", dataGridView1.Rows[i].Cells[clm_RetailPrice.Name].Value);
                    }

                    cmd.Parameters.AddWithValue("@R_SellingPrice", dataGridView1.Rows[i].Cells[clm_SellingPrice.Name].Value);

                    if (dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == "" || dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", dataGridView1.Rows[i].Cells[clm_Discount.Name].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[Column8.Name].Value == "" || dataGridView1.Rows[i].Cells[Column8.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Tax", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Tax", dataGridView1.Rows[i].Cells[Column8.Name].Value);
                    }
                    cmd.Parameters.AddWithValue("@R_Total", dataGridView1.Rows[i].Cells[Clm_T_Total.Name].Value);
                    cmd.Parameters.AddWithValue("@R_DateItem", dataGridView1.Rows[i].Cells[Clm_R_DateItem.Name].Value);
                    cmd.Parameters.AddWithValue("@N_ITems_Invoice", text_N_ITems.Text);
                    cmd.Parameters.AddWithValue("@SubTotal_Invoice", text_subTotal.Text);                    
                    if (text_Discount.Text==string.Empty || text_Discount.Text==null)
                    {
                        cmd.Parameters.AddWithValue("@Discount_Invoice", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Discount_Invoice", text_Discount.Text);
                    }
                    if (text_DiscountP.Text == string.Empty || text_DiscountP.Text == null)
                    {
                        cmd.Parameters.AddWithValue("@DiscountP_Invoice", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DiscountP_Invoice", text_DiscountP.Text);
                    }
                    cmd.Parameters.AddWithValue("@TotalAmount_Invoice", lbl_cc.Text);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.Parameters.AddWithValue("@Bill_Suspension", 0);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;

            }
            catch (Exception ee)
            {
                msg.Alert("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا ERROR 1026 Invoice_Sales" + ee.Message, Form_Alert.enumType.Error);
                con.Close();
                return false;                
            }
        }
        public bool Delete_Row()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from " + D.DataPharmacy + "Invoice_Sales where ID=@ID and MYear=@MYear";

                cmd.Parameters.AddWithValue("@ID", label5.Text);
                cmd.Parameters.AddWithValue("@MYear", MYear);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ee)
            {
                msg.Alert("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا ERROR 1028 Invoice_Sales" + ee.Message, Form_Alert.enumType.Error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool Delete_Row_Trans()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from " + D.DataPharmacy + "i2_Trans where Order_No=@Order_No and MYear=@MYear and Doc_Type=@Doc_Type and Screen_Code=@Screen_Code";

                cmd.Parameters.AddWithValue("@Order_No", label5.Text);
                cmd.Parameters.AddWithValue("@MYear", MYear);
                cmd.Parameters.AddWithValue("@Doc_Type", docType.Invoice_Sales);
                cmd.Parameters.AddWithValue("@Screen_Code", docType.Invoice_Sales);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ee)
            {
                msg.Alert("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا ERROR 1029 Invoice_Sales" + ee.Message, Form_Alert.enumType.Error);
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

                    cmd.Parameters.AddWithValue("@Order_No", label5.Text);
                    cmd.Parameters.AddWithValue("@Myear", MYear);
                    cmd.Parameters.AddWithValue("@Kind", docType.Output);
                    cmd.Parameters.AddWithValue("@Doc_Type", docType.Invoice_Sales);
                    cmd.Parameters.AddWithValue("@Screen_Code", docType.Invoice_Sales);
                    cmd.Parameters.AddWithValue("@Odate", textBoxDate.Text);
                    cmd.Parameters.AddWithValue("@status_Order", Status);
                    cmd.Parameters.AddWithValue("@S_No", "0");
                    cmd.Parameters.AddWithValue("@S_Name", "");
                    if (text_subTotal.Text == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@TotalOrder", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TotalOrder", text_subTotal.Text);

                    }
                    double TotalDiscount = 0;
                    if (text_subTotal.Text!=string.Empty)
                    {
                        TotalDiscount = Convert.ToDouble(text_subTotal.Text) - Convert.ToDouble(text_totalAmount.Text);
                    }                    
                    cmd.Parameters.AddWithValue("@TotalDiscount", TotalDiscount);
                    cmd.Parameters.AddWithValue("@FlagDiscount", 0);                
                    cmd.Parameters.AddWithValue("@TotalAfterDiscount", text_totalAmount.Text);

                    cmd.Parameters.AddWithValue("@R_Barcode", dataGridView1.Rows[i].Cells[clm_code.Name].Value);
                    cmd.Parameters.AddWithValue("@R_ItemName", dataGridView1.Rows[i].Cells[Column2.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceParchase", dataGridView1.Rows[i].Cells[Clm_R_PriceParchase.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceSales", dataGridView1.Rows[i].Cells[clm_SellingPrice.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Tax", dataGridView1.Rows[i].Cells[Column8.Name].Value);
                    if(dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value==string.Empty || dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value==null)
                    {
                        cmd.Parameters.AddWithValue("@R_Qty", dataGridView1.Rows[i].Cells[clm_RetailQTY.Name].Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Qty", dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value);
                    }

                        cmd.Parameters.AddWithValue("@R_Bouns", "0");

                    cmd.Parameters.AddWithValue("@R_DateItem", dataGridView1.Rows[i].Cells[Clm_R_DateItem.Name].Value);

                    if (dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == "" || dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("R_Discount", dataGridView1.Rows[i].Cells[clm_Discount.Name].Value);
                    }

                    cmd.Parameters.AddWithValue("@R_DiscountPresnt", "0");
                    cmd.Parameters.AddWithValue("@R_TotalRow", dataGridView1.Rows[i].Cells[Clm_T_Total.Name].Value);
                    cmd.Parameters.AddWithValue("@Note", "فاتورة بيع صيدلية رقم"+label5.Text);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ee)
            {
                msg.Alert("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا ERROR 1030 Invoice_Sales" + ee.Message, Form_Alert.enumType.Error);
                con.Close();
                return false;               
            }
        }

        public bool ADD_Row_Trans_Dic_Pet(string subTotal,string TotalDiscount, string TotalAfterDiscount)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "INSERT INTO  " + D.DataPharmacy + " i2_Trans (Order_No, Myear, Kind, Doc_Type, Screen_Code, Odate, status_Order, S_No, S_Name, TotalOrder, TotalDiscount, FlagDiscount, TotalAfterDiscount, R_Barcode, R_ItemName, R_PriceParchase, R_PriceSales, R_Tax, R_Qty, R_Bouns, R_DateItem, R_Discount, R_DiscountPresnt, R_TotalRow, Note, ID_User) VALUES        (@Order_No, @Myear, @Kind, @Doc_Type, @Screen_Code, @Odate, @status_Order, @S_No, @S_Name, @TotalOrder, @TotalDiscount, @FlagDiscount, @TotalAfterDiscount, @R_Barcode, @R_ItemName, @R_PriceParchase, @R_PriceSales, @R_Tax, @R_Qty, @R_Bouns, @R_DateItem, @R_Discount, @R_DiscountPresnt, @R_TotalRow, @Note, @ID_User)";

                    cmd.Parameters.AddWithValue("@Order_No", label5.Text);
                    cmd.Parameters.AddWithValue("@Myear", MYear);
                    cmd.Parameters.AddWithValue("@Kind", docType.Output);
                    cmd.Parameters.AddWithValue("@Doc_Type", docType.Invoice_Sales);
                    cmd.Parameters.AddWithValue("@Screen_Code", docType.Invoice_Sales);
                    cmd.Parameters.AddWithValue("@Odate", textBoxDate.Text);
                    cmd.Parameters.AddWithValue("@status_Order", Status);
                    cmd.Parameters.AddWithValue("@S_No", "0");
                    cmd.Parameters.AddWithValue("@S_Name", "");                
                    cmd.Parameters.AddWithValue("@TotalOrder", subTotal);
                    cmd.Parameters.AddWithValue("@TotalDiscount", TotalDiscount);
                    cmd.Parameters.AddWithValue("@FlagDiscount", 0);
                    cmd.Parameters.AddWithValue("@TotalAfterDiscount", TotalAfterDiscount);

                    cmd.Parameters.AddWithValue("@R_Barcode", dataGridView1.Rows[i].Cells[clm_code.Name].Value);
                    cmd.Parameters.AddWithValue("@R_ItemName", dataGridView1.Rows[i].Cells[Column2.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceParchase", dataGridView1.Rows[i].Cells[Clm_R_PriceParchase.Name].Value);
                    cmd.Parameters.AddWithValue("@R_PriceSales", dataGridView1.Rows[i].Cells[clm_SellingPrice.Name].Value);
                    cmd.Parameters.AddWithValue("@R_Tax", dataGridView1.Rows[i].Cells[Column8.Name].Value);
                    if (dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value == string.Empty || dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Qty", dataGridView1.Rows[i].Cells[clm_RetailQTY.Name].Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Qty", dataGridView1.Rows[i].Cells[clm_Quantity.Name].Value);
                    }

                    cmd.Parameters.AddWithValue("@R_Bouns", "0");

                    cmd.Parameters.AddWithValue("@R_DateItem", dataGridView1.Rows[i].Cells[Clm_R_DateItem.Name].Value);

                    if (dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == "" || dataGridView1.Rows[i].Cells[clm_Discount.Name].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("R_Discount", dataGridView1.Rows[i].Cells[clm_Discount.Name].Value);
                    }

                    cmd.Parameters.AddWithValue("@R_DiscountPresnt", "0");
                    cmd.Parameters.AddWithValue("@R_TotalRow", dataGridView1.Rows[i].Cells[Clm_T_Total.Name].Value);
                    cmd.Parameters.AddWithValue("@Note", "فاتورة بيع صيدلية تأمين رقم" + label5.Text);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ee)
            {
                msg.Alert("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا ERROR 1030 Invoice_Sales" + ee.Message, Form_Alert.enumType.Error);
                con.Close();
                return false;                
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count <= 0)
                {
                    msg.Alert("لا يمكنك التخزين ، لا يوجد بيانات", Form_Alert.enumType.Warning);
                    return;
                }
                if (label5.Text == string.Empty)
                {
                    msg.Alert("لا يمكنك التخزين ، لا يوجد رقم للفاتورة", Form_Alert.enumType.Warning);
                    return;
                }
                if (Convert.ToDouble(lbl_cc.Text) <= 0)
                {
                    msg.Alert("لا يمكنك التخزين ، لا يمكن تخزين فاتورة قيمتها أقل من صفر أو صفرية", Form_Alert.enumType.Warning);
                    return;
                }
                if (lbl_Name_MU.Visible == true)
                {
                    Dic_Pet ss = new Dic_Pet();
                    ss.ShowDialog();
                }
                else
                {
                    //----------------------------------------------تفقيد الفاتورة موجودة في الداتا--------------------------------------------------------------
                    try
                    {
                        con.Open();
                        SqlCommand cmd22 = new SqlCommand("select DISTINCT ID from " + D.DataPharmacy + "Invoice_Sales where ID=@ID and MYear=@MYear", con);
                        cmd22.Parameters.AddWithValue("@ID", label5.Text);
                        cmd22.Parameters.AddWithValue("@MYear", MYear);
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
                                history.EventHistory(label5.Text, history.ADD, history.NameADD, docType.Invoice_Sales, "فاتورة بيع صيدلية ");
                                msg.Alert("تم تخزين الفاتورة  بنجاح بالرقم " + label5.Text + "", Form_Alert.enumType.Success);
                                ClearScreen();
                                MaxInvoice();
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
                                        history.EventHistory(label5.Text, history.Edit, history.NameEdit, docType.Invoice_Sales, "فاتورة بيع صيدلية ");
                                        msg.Alert("تم تخزين الفاتورة  بنجاح بالرقم " + label5.Text + "", Form_Alert.enumType.Success);
                                        ClearScreen();
                                        MaxInvoice();
                                    }
                                }
                            }
                        }

                    }

                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ClearScreen();
                MaxInvoice();
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ClearScreen();
                MaxInvoice();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Delete_Row() == true)
                {
                    if (Delete_Row_Trans() == true)
                    {
                        history.EventHistory(label5.Text, history.Delete, history.NameDelete, docType.Invoice_Sales, "فاتورة بيع صيدلية ");
                        msg.Alert("تم حذف الفاتورة  بنجاح بالرقم " + label5.Text + "", Form_Alert.enumType.Success);
                        ClearScreen();
                        MaxInvoice();         
                    }
                }

            }
            catch
            {

            }
        }
    }
}
