using Clinics.Class;
using Clinics.Pharmacy;
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
        OthersDataBase D = new OthersDataBase();
        int NewRow = -1;
        msgShow msg = new msgShow();
        ClsHistory history = new ClsHistory();
        DocType docType = new DocType();
        public Dic_Pet()
        {
            dd = this;
            InitializeComponent();
        }

        private void Dic_Pet_Load(object sender, EventArgs e)
        {
            double presnt_Measures;
            double Total_Pat;
            double After_Total;
            try
            {
                textBox_ID_Orders.Text = POS.pOS.number_Measures;
                textBox_Name_MU.Text = POS.pOS.Name_Measures;
                textBox_Name_Pat.Text = POS.pOS.Name_pat;
                textBox_berfore_Total.Text = POS.pOS.lbl_cc.Text;
                textBox_Total_Pat.Text = POS.pOS.presnt_Measures;

                try
                {
                    if (textBox_Total_Pat.Text == string.Empty)
                    {
                        presnt_Measures = 0;
                    }
                    else
                    {
                        presnt_Measures = Convert.ToDouble(textBox_Total_Pat.Text);                        
                    }
                    Total_Pat = (100 - presnt_Measures);
                    textBox_Total_MU.Text = Total_Pat.ToString();

                    After_Total = Convert.ToDouble(textBox_berfore_Total.Text) * (presnt_Measures / 100);

                    textBox_After_Total.Text = After_Total.ToString();
                    lbl_cc.Text = textBox_After_Total.Text;
                }
                catch
                {
                    presnt_Measures = 0;
                    textBox_Total_Pat.Text = "";
                    lbl_cc.Text = textBox_berfore_Total.Text;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Dic_Pet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox_ID_Orders.Text==string.Empty)
                {
                    MessageBox.Show("لا يمكن تخزين الفاتورة ، لا يوجد رقم تأمين للمستفيد","عملية خاطئة",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                if (textBox_Name_MU.Text == string.Empty)
                {
                    MessageBox.Show("لا يمكن تخزين الفاتورة ، اسم شركة التأمين للمستفيد فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (textBox_Name_Pat.Text == string.Empty)
                {
                    MessageBox.Show("لا يمكن تخزين الفاتورة ، اسم المستفيد فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //----------------------------------------------تفقيد الفاتورة موجودة في الداتا--------------------------------------------------------------
                try
                {
                    con.Open();
                    SqlCommand cmd22 = new SqlCommand("select DISTINCT ID from " + D.DataPharmacy + "Invoice_Sales where ID=@ID and MYear=@MYear", con);
                    cmd22.Parameters.AddWithValue("@ID", POS.pOS.label5.Text);
                    cmd22.Parameters.AddWithValue("@MYear", POS.pOS.MYear);
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

                    if (POS.pOS.ADD_Row_Dic_Pet(textBox_ID_Orders.Text, textBox_Name_MU.Text,textBox_Name_Pat.Text, textBox_Total_Pat.Text, textBox_berfore_Total.Text, lbl_cc.Text) == true)
                    {
                        if (POS.pOS.ADD_Row_Trans_Dic_Pet(textBox_berfore_Total.Text,(Convert.ToDouble(textBox_berfore_Total.Text) - Convert.ToDouble(textBox_After_Total.Text)).ToString(), textBox_After_Total.Text) == true)
                        {
                            history.EventHistory(POS.pOS.label5.Text, history.ADD, history.NameADD, docType.Invoice_Sales, "فاتورة بيع صيدلية تأمين");
                            msg.Alert("تم تخزين الفاتورة  بنجاح بالرقم " + POS.pOS.label5.Text + "", Form_Alert.enumType.Success);
                            POS.pOS.ClearScreen();
                            POS.pOS.MaxInvoice();
                        }
                    }
                }
                else if (NewRow == 1)
                {
                    if (POS.pOS.Delete_Row() == true)
                    {
                        if (POS.pOS.Delete_Row_Trans() == true)
                        {
                            if (POS.pOS.ADD_Row_Dic_Pet(textBox_ID_Orders.Text, textBox_Name_MU.Text, textBox_Name_Pat.Text, textBox_Total_Pat.Text, textBox_berfore_Total.Text, lbl_cc.Text) == true)
                            {
                                if (POS.pOS.ADD_Row_Trans_Dic_Pet(textBox_berfore_Total.Text, (Convert.ToDouble(textBox_berfore_Total.Text) - Convert.ToDouble(textBox_After_Total.Text)).ToString(), textBox_After_Total.Text) == true)
                                {
                                    history.EventHistory(POS.pOS.label5.Text, history.Edit, history.NameEdit, docType.Invoice_Sales, "فاتورة بيع صيدلية تأمين");
                                    msg.Alert("تم تخزين الفاتورة  بنجاح بالرقم " + POS.pOS.label5.Text + "", Form_Alert.enumType.Success);
                                    POS.pOS.ClearScreen();
                                    POS.pOS.MaxInvoice();
                                }
                            }
                        }
                    }
                }
                this.Close();
            }
            catch (Exception ee)
            {
                
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Dic_Pet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
