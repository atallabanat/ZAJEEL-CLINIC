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
using System.Collections.Specialized;
using System.Net;
using System.IO;

namespace Clinics.UserControls
{
    public partial class add_file_pat : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static string ss;
        
        public add_file_pat()
        {
            
            InitializeComponent();

        }
        //public Virable







        public void loadsel()
        {
            try
            { 
            SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_visit)+1,1) from Table_visit_patient", con);
            con.Open();
            SqlDataReader Ra = cmd2.ExecuteReader();

            Ra.Read();
            textBox_ID_visit.Text = Ra[0].ToString();
            Ra.Close();
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            try
            {
                SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_pat)+1,1) from Table_PAT", con);
                con.Open();
                SqlDataReader Ra = cmd2.ExecuteReader();

                Ra.Read();
                textBox_Number.Text = Ra[0].ToString();
                Ra.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1014 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }





        //--------------------------الصفحات المتنقلة ------------------------//
        private void addControlsTopanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);

        }


        private void add_file_pat_Load(object sender, EventArgs e)
        {
            
            loadsel();
        }
        private void Send_SMS()
        {
            String result;
            if(textbox_phone.Text.Length !=10)
            {

            }
            else
            {
                string T_numbers = textbox_phone.Text;
                string numbers = "962" + T_numbers.Substring(1, 9);
                string message = "عيادات الشروق الطبية ترحب بزيارتكم، هاتف العيادة :027401381";
                if(T_numbers.Substring(0,3)!="077" && T_numbers.Substring(0, 3) != "079" && T_numbers.Substring(0, 3) != "078")
                {
                    return;
                }
                String url = "http://josmsservice.com/smsonline/msgservicejo.cfm?numbers=" + numbers + ",&senderid=ShoruqClinc&AccName=ryadclinc&AccPass=ryadclinc123&msg=" + message + "&requesttimeout=5000000";
                //refer to parameters to complete correct url string

                StreamWriter myWriter = null;
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

                objRequest.Method = "POST";
                objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
                objRequest.ContentType = "application/x-www-form-urlencoded";
                try
                {
                    myWriter = new StreamWriter(objRequest.GetRequestStream());
                    myWriter.Write(url);
                }
                catch (Exception)
                {
                    MessageBox.Show("مشاكل في إرسال الرسالة يرجى مراجعة الشركة المختصة");
                    myWriter.Close();
                    return;
                }
                finally
                {
                    myWriter.Close();
                }

                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    // Close and clean up the StreamReader
                    sr.Close();
                }
            }



        }
        private void Send_SMS2()
        {
            String result;
            if (textbox_phone.Text.Length != 10)
            {

            }
            else
            {
                string T_numbers = textbox_phone.Text;
                string numbers = "962" + T_numbers.Substring(1, 9);
                string message = "صيدلية الزاجل ترحب بزيارتكم، هاتف الصيدلية :027401991";
                if (T_numbers.Substring(0, 3) != "077" && T_numbers.Substring(0, 3) != "079" && T_numbers.Substring(0, 3) != "078")
                {
                    return;
                }
                String url = "http://josmsservice.com/smsonline/msgservicejo.cfm?numbers=" + numbers + ",&senderid=ZajelPharma&AccName=ryadclinc&AccPass=ryadclinc123&msg=" + message + "&requesttimeout=5000000";
                //refer to parameters to complete correct url string

                StreamWriter myWriter = null;
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

                objRequest.Method = "POST";
                objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
                objRequest.ContentType = "application/x-www-form-urlencoded";
                try
                {
                    myWriter = new StreamWriter(objRequest.GetRequestStream());
                    myWriter.Write(url);
                }
                catch (Exception)
                {
                    MessageBox.Show("مشاكل في إرسال الرسالة يرجى مراجعة الشركة المختصة");
                    myWriter.Close();
                    return;
                }
                finally
                {
                    myWriter.Close();
                }

                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    // Close and clean up the StreamReader
                    sr.Close();
                }
            }



        }


        private void btn_file_save_Click_1(object sender, EventArgs e)
        {
            if (textBox_Number.Text == "")
            {

                MessageBox.Show("لا يمكن ترك حقل (رقم الملف ) فارغ ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Number.Focus();
                return;
            }

            if (textBox_Name.Text == "")
            {

                MessageBox.Show("لا يمكن ترك حقل (اسم المريض ) فارغ ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Name.Focus();
                return;
            }

            else
            {

                try
                {

                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select ID_pat from Table_PAT where ID_pat=@ID_pat", con);
                    cmd21.Parameters.Add(new SqlParameter("@ID_pat", textBox_Number.Text));
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
                        MessageBox.Show("رقم الملف للمريض موجودة مسبقا ، لا يمكن إضافة مريض بنفس الرقم  " + textBox_Number.Text.Trim(), "تكرار البيانات رقم الملف للمريض موجودة مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {


                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dboadd_file_pat";

                        cmd.Parameters.Add(new SqlParameter("@ID_pat", textBox_Number.Text.Trim()));
                        cmd.Parameters.Add("@Name_pat", SqlDbType.NVarChar).Value = textBox_Name.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@age_pat", textbox_age.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@phone_pat", textbox_phone.Text.Trim()));
                        cmd.Parameters.Add("@end_Date", SqlDbType.SmallDateTime).Value  = textbox_enD_Date.Value;
                        cmd.Parameters.Add(new SqlParameter("@Name_Measures", text_Measures.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@presnt_Measures", text_presnt_Measures.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@presnt_Doc", text_presnt_Doc.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@presnt_MM", text_presnt_MM.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@number_Measures", text_number_Measures.Text.Trim()));
                        cmd.Parameters.Add("@address_pat", SqlDbType.NVarChar).Value = comboBox_address.SelectedValue;
                        cmd.Parameters.Add("@city_pat", SqlDbType.NVarChar).Value = comboBox_city.SelectedValue;
                        cmd.Parameters.Add("@cuntry_pat", SqlDbType.NVarChar).Value = textBox_cuntrey.Text.Trim();
                        cmd.Parameters.Add("@str_pat", SqlDbType.NVarChar).Value = textBox_str.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@Nfamile", comboBoxNfamile.SelectedValue));
                        cmd.Parameters.Add(new SqlParameter("@Nwife", comboBox_Nwife.SelectedValue));
                        cmd.Parameters.Add("@wife1", SqlDbType.NVarChar).Value = textBox_wife1.Text.Trim();
                        cmd.Parameters.Add("@wife2", SqlDbType.NVarChar).Value = textBox_wife2.Text.Trim();
                        cmd.Parameters.Add("@wife3", SqlDbType.NVarChar).Value = textBox_wife3.Text.Trim();
                        cmd.Parameters.Add("@wife4", SqlDbType.NVarChar).Value = textBox_wife4.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@Nch", comboBoxNch.SelectedValue));
                        cmd.Parameters.Add("@ch1", SqlDbType.NVarChar).Value = textBox_ch1.Text.Trim();
                        cmd.Parameters.Add("@ch2", SqlDbType.NVarChar).Value = textBox_ch2.Text.Trim();
                        cmd.Parameters.Add("@ch3", SqlDbType.NVarChar).Value = textBox_ch3.Text.Trim();
                        cmd.Parameters.Add("@ch4", SqlDbType.NVarChar).Value = textBox_ch4.Text.Trim();
                        cmd.Parameters.Add("@ch5", SqlDbType.NVarChar).Value = textBox_ch5.Text.Trim();
                        cmd.Parameters.Add("@ch6", SqlDbType.NVarChar).Value = textBox_ch6.Text.Trim();
                        cmd.Parameters.Add("@ch7", SqlDbType.NVarChar).Value = textBox_ch7.Text.Trim();
                        cmd.Parameters.Add("@ch8", SqlDbType.NVarChar).Value = textBox_ch8.Text.Trim();
                        cmd.Parameters.Add("@ch9", SqlDbType.NVarChar).Value = textBox_ch9.Text.Trim();
                        cmd.Parameters.Add("@ch10", SqlDbType.NVarChar).Value = textBox_ch10.Text.Trim();
                        cmd.Parameters.Add("@ch11", SqlDbType.NVarChar).Value = textBox_ch11.Text.Trim();
                        cmd.Parameters.Add("@ch12", SqlDbType.NVarChar).Value = textBox_ch12.Text.Trim();
                        cmd.Parameters.Add("@ch13", SqlDbType.NVarChar).Value = textBox_ch13.Text.Trim();
                        cmd.Parameters.Add("@ch14", SqlDbType.NVarChar).Value = textBox_ch14.Text.Trim();
                        var home = new home();
                        cmd.Parameters.Add("@date", SqlDbType.NVarChar).Value = home.current;
                        cmd.Parameters.Add("@add_name", SqlDbType.NVarChar).Value = Form1.Recby;



                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con.Open();


                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.CommandText = "dboadd_TT";

                        cmd2.Parameters.Add(new SqlParameter("@ID_visit", textBox_ID_visit.Text.Trim()));
                        cmd2.Parameters.Add(new SqlParameter("@ID_pat", textBox_Number.Text.Trim()));
                        cmd2.Parameters.Add("@Name_pat", SqlDbType.NVarChar).Value = textBox_Name.Text.Trim();




                        cmd2.ExecuteNonQuery();
                        con.Close();

                        //---------------------------- رسائل الخاصة ب موظفين الاستقبال-------------------------------------------------
                        SqlDataReader ddr;
                        DataTable Dt = new DataTable();
                        SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=13", con);
                        con.Open();
                        ddr = ccmd.ExecuteReader();
                        if (ddr.Read())
                        {
                            if (ddr["Priv_Display"].ToString() == "True")
                            {
                                Send_SMS();
                            }
                        }
                        ddr.Close();
                        con.Close();








                        //---------------------------------------------------------------------------------------


                        //---------------------------- رسائل الخاصة ب موظفين الصيدلية-------------------------------------------------
                        SqlDataReader ddr2;

                        SqlCommand ccmd2 = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=14", con);
                        con.Open();
                        ddr2 = ccmd2.ExecuteReader();
                        if (ddr2.Read())
                        {
                            if (ddr2["Priv_Display"].ToString() == "True")
                            {
                                Send_SMS2();
                            }
                        }
                        ddr2.Close();
                        con.Close();








                        //---------------------------------------------------------------------------------------
                        MessageBox.Show("تم إنشاء ملف مريض", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        add_visitpatientView ssa = new add_visitpatientView();
                        addControlsTopanel(ssa);

                    }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        }

        private void textBox_Number_TextChanged_1(object sender, EventArgs e)
        {
            ss = textBox_Number.Text;
        }

        private void groupBox4_Enter_1(object sender, EventArgs e)
        {
            try
            { 
            //------------ قائمة عدد الاطفال ---------------------------//
            DataTable Dt5 = new DataTable();
            SqlDataAdapter Da5 = new SqlDataAdapter("select * from Nch", con);
            Da5.Fill(Dt5);
            comboBoxNch.DataSource = Dt5;
            comboBoxNch.DisplayMember = "ch";
            comboBoxNch.ValueMember = "ch";
            comboBoxNch.SelectedIndex = -1;

                //------------ قائمة عدد الاطفال ---------------------------//
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void comboBoxNch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNch.SelectedIndex == 0)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = false;
                lbl_ch3.Visible = false;
                lbl_ch4.Visible = false;
                lbl_ch5.Visible = false;
                lbl_ch6.Visible = false;
                lbl_ch7.Visible = false;
                lbl_ch8.Visible = false;
                lbl_ch9.Visible = false;
                lbl_ch10.Visible = false;
                lbl_ch11.Visible = false;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = false;
                textBox_ch3.Visible = false;
                textBox_ch4.Visible = false;
                textBox_ch5.Visible = false;
                textBox_ch6.Visible = false;
                textBox_ch7.Visible = false;
                textBox_ch8.Visible = false;
                textBox_ch9.Visible = false;
                textBox_ch10.Visible = false;
                textBox_ch11.Visible = false;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }



            if (comboBoxNch.SelectedIndex == 1)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = false;
                lbl_ch4.Visible = false;
                lbl_ch5.Visible = false;
                lbl_ch6.Visible = false;
                lbl_ch7.Visible = false;
                lbl_ch8.Visible = false;
                lbl_ch9.Visible = false;
                lbl_ch10.Visible = false;
                lbl_ch11.Visible = false;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = false;
                textBox_ch4.Visible = false;
                textBox_ch5.Visible = false;
                textBox_ch6.Visible = false;
                textBox_ch7.Visible = false;
                textBox_ch8.Visible = false;
                textBox_ch9.Visible = false;
                textBox_ch10.Visible = false;
                textBox_ch11.Visible = false;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }



            if (comboBoxNch.SelectedIndex == 2)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = false;
                lbl_ch5.Visible = false;
                lbl_ch6.Visible = false;
                lbl_ch7.Visible = false;
                lbl_ch8.Visible = false;
                lbl_ch9.Visible = false;
                lbl_ch10.Visible = false;
                lbl_ch11.Visible = false;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = false;
                textBox_ch5.Visible = false;
                textBox_ch6.Visible = false;
                textBox_ch7.Visible = false;
                textBox_ch8.Visible = false;
                textBox_ch9.Visible = false;
                textBox_ch10.Visible = false;
                textBox_ch11.Visible = false;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }



            if (comboBoxNch.SelectedIndex == 3)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = false;
                lbl_ch6.Visible = false;
                lbl_ch7.Visible = false;
                lbl_ch8.Visible = false;
                lbl_ch9.Visible = false;
                lbl_ch10.Visible = false;
                lbl_ch11.Visible = false;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = false;
                textBox_ch6.Visible = false;
                textBox_ch7.Visible = false;
                textBox_ch8.Visible = false;
                textBox_ch9.Visible = false;
                textBox_ch10.Visible = false;
                textBox_ch11.Visible = false;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }


            if (comboBoxNch.SelectedIndex == 4)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = true;
                lbl_ch6.Visible = false;
                lbl_ch7.Visible = false;
                lbl_ch8.Visible = false;
                lbl_ch9.Visible = false;
                lbl_ch10.Visible = false;
                lbl_ch11.Visible = false;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = true;
                textBox_ch6.Visible = false;
                textBox_ch7.Visible = false;
                textBox_ch8.Visible = false;
                textBox_ch9.Visible = false;
                textBox_ch10.Visible = false;
                textBox_ch11.Visible = false;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }


            if (comboBoxNch.SelectedIndex == 5)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = true;
                lbl_ch6.Visible = true;
                lbl_ch7.Visible = false;
                lbl_ch8.Visible = false;
                lbl_ch9.Visible = false;
                lbl_ch10.Visible = false;
                lbl_ch11.Visible = false;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = true;
                textBox_ch6.Visible = true;
                textBox_ch7.Visible = false;
                textBox_ch8.Visible = false;
                textBox_ch9.Visible = false;
                textBox_ch10.Visible = false;
                textBox_ch11.Visible = false;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }


            if (comboBoxNch.SelectedIndex == 6)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = true;
                lbl_ch6.Visible = true;
                lbl_ch7.Visible = true;
                lbl_ch8.Visible = false;
                lbl_ch9.Visible = false;
                lbl_ch10.Visible = false;
                lbl_ch11.Visible = false;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = true;
                textBox_ch6.Visible = true;
                textBox_ch7.Visible = true;
                textBox_ch8.Visible = false;
                textBox_ch9.Visible = false;
                textBox_ch10.Visible = false;
                textBox_ch11.Visible = false;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }


            if (comboBoxNch.SelectedIndex == 7)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = true;
                lbl_ch6.Visible = true;
                lbl_ch7.Visible = true;
                lbl_ch8.Visible = true;
                lbl_ch9.Visible = false;
                lbl_ch10.Visible = false;
                lbl_ch11.Visible = false;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = true;
                textBox_ch6.Visible = true;
                textBox_ch7.Visible = true;
                textBox_ch8.Visible = true;
                textBox_ch9.Visible = false;
                textBox_ch10.Visible = false;
                textBox_ch11.Visible = false;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }

            if (comboBoxNch.SelectedIndex == 8)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = true;
                lbl_ch6.Visible = true;
                lbl_ch7.Visible = true;
                lbl_ch8.Visible = true;
                lbl_ch9.Visible = true;
                lbl_ch10.Visible = false;
                lbl_ch11.Visible = false;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = true;
                textBox_ch6.Visible = true;
                textBox_ch7.Visible = true;
                textBox_ch8.Visible = true;
                textBox_ch9.Visible = true;
                textBox_ch10.Visible = false;
                textBox_ch11.Visible = false;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }

            if (comboBoxNch.SelectedIndex == 9)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = true;
                lbl_ch6.Visible = true;
                lbl_ch7.Visible = true;
                lbl_ch8.Visible = true;
                lbl_ch9.Visible = true;
                lbl_ch10.Visible = true;
                lbl_ch11.Visible = false;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = true;
                textBox_ch6.Visible = true;
                textBox_ch7.Visible = true;
                textBox_ch8.Visible = true;
                textBox_ch9.Visible = true;
                textBox_ch10.Visible = true;
                textBox_ch11.Visible = false;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }


            if (comboBoxNch.SelectedIndex == 10)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = true;
                lbl_ch6.Visible = true;
                lbl_ch7.Visible = true;
                lbl_ch8.Visible = true;
                lbl_ch9.Visible = true;
                lbl_ch10.Visible = true;
                lbl_ch11.Visible = true;
                lbl_ch12.Visible = false;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = true;
                textBox_ch6.Visible = true;
                textBox_ch7.Visible = true;
                textBox_ch8.Visible = true;
                textBox_ch9.Visible = true;
                textBox_ch10.Visible = true;
                textBox_ch11.Visible = true;
                textBox_ch12.Visible = false;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }


            if (comboBoxNch.SelectedIndex == 11)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = true;
                lbl_ch6.Visible = true;
                lbl_ch7.Visible = true;
                lbl_ch8.Visible = true;
                lbl_ch9.Visible = true;
                lbl_ch10.Visible = true;
                lbl_ch11.Visible = true;
                lbl_ch12.Visible = true;
                lbl_ch13.Visible = false;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = true;
                textBox_ch6.Visible = true;
                textBox_ch7.Visible = true;
                textBox_ch8.Visible = true;
                textBox_ch9.Visible = true;
                textBox_ch10.Visible = true;
                textBox_ch11.Visible = true;
                textBox_ch12.Visible = true;
                textBox_ch13.Visible = false;
                textBox_ch14.Visible = false;



            }

            if (comboBoxNch.SelectedIndex == 12)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = true;
                lbl_ch6.Visible = true;
                lbl_ch7.Visible = true;
                lbl_ch8.Visible = true;
                lbl_ch9.Visible = true;
                lbl_ch10.Visible = true;
                lbl_ch11.Visible = true;
                lbl_ch12.Visible = true;
                lbl_ch13.Visible = true;
                lbl_ch14.Visible = false;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = true;
                textBox_ch6.Visible = true;
                textBox_ch7.Visible = true;
                textBox_ch8.Visible = true;
                textBox_ch9.Visible = true;
                textBox_ch10.Visible = true;
                textBox_ch11.Visible = true;
                textBox_ch12.Visible = true;
                textBox_ch13.Visible = true;
                textBox_ch14.Visible = false;



            }




            if (comboBoxNch.SelectedIndex == 13)
            {
                lbl_ch1.Visible = true;
                lbl_ch2.Visible = true;
                lbl_ch3.Visible = true;
                lbl_ch4.Visible = true;
                lbl_ch5.Visible = true;
                lbl_ch6.Visible = true;
                lbl_ch7.Visible = true;
                lbl_ch8.Visible = true;
                lbl_ch9.Visible = true;
                lbl_ch10.Visible = true;
                lbl_ch11.Visible = true;
                lbl_ch12.Visible = true;
                lbl_ch13.Visible = true;
                lbl_ch14.Visible = true;


                textBox_ch1.Visible = true;
                textBox_ch2.Visible = true;
                textBox_ch3.Visible = true;
                textBox_ch4.Visible = true;
                textBox_ch5.Visible = true;
                textBox_ch6.Visible = true;
                textBox_ch7.Visible = true;
                textBox_ch8.Visible = true;
                textBox_ch9.Visible = true;
                textBox_ch10.Visible = true;
                textBox_ch11.Visible = true;
                textBox_ch12.Visible = true;
                textBox_ch13.Visible = true;
                textBox_ch14.Visible = true;



            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            try
            { 
            //------------ قائمة عدد الزوجات ---------------------------//
            DataTable Dt3 = new DataTable();
            SqlDataAdapter Da3 = new SqlDataAdapter("select * from Nwife", con);
            Da3.Fill(Dt3);
            comboBox_Nwife.DataSource = Dt3;
            comboBox_Nwife.DisplayMember = "Nwife";
            comboBox_Nwife.ValueMember = "Nwife";
            comboBox_Nwife.SelectedIndex = -1;

            //------------ قائمة عدد الزوجات ---------------------------//

            //------------ قائمة عدد الاسرة ---------------------------//
            DataTable Dt4 = new DataTable();
            SqlDataAdapter Da4 = new SqlDataAdapter("select * from Nfamile", con);
            Da4.Fill(Dt4);
            comboBoxNfamile.DataSource = Dt4;
            comboBoxNfamile.DisplayMember = "Nfamile";
            comboBoxNfamile.ValueMember = "Nfamile";
            comboBoxNfamile.SelectedIndex = -1;

                //------------ قائمة عدد الاسرة ---------------------------//
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void comboBox_Nwife_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Nwife.SelectedIndex == 0)
            {
                lbl_wife1.Visible = true;
                lbl_wife2.Visible = false;
                lbl_wife3.Visible = false;
                lbl_wife4.Visible = false;
                textBox_wife1.Visible = true;
                textBox_wife2.Visible = false;
                textBox_wife3.Visible = false;
                textBox_wife4.Visible = false;
            }
            if (comboBox_Nwife.SelectedIndex == 1)
            {
                lbl_wife1.Visible = true;
                lbl_wife2.Visible = true;
                lbl_wife3.Visible = false;
                lbl_wife4.Visible = false;
                textBox_wife1.Visible = true;
                textBox_wife2.Visible = true;
                textBox_wife3.Visible = false;
                textBox_wife4.Visible = false;
            }
            if (comboBox_Nwife.SelectedIndex == 2)
            {
                lbl_wife1.Visible = true;
                lbl_wife2.Visible = true;
                lbl_wife3.Visible = true;
                lbl_wife4.Visible = false;
                textBox_wife1.Visible = true;
                textBox_wife2.Visible = true;
                textBox_wife3.Visible = true;
                textBox_wife4.Visible = false;
            }
            if (comboBox_Nwife.SelectedIndex == 3)
            {
                lbl_wife1.Visible = true;
                lbl_wife2.Visible = true;
                lbl_wife3.Visible = true;
                lbl_wife4.Visible = true;
                textBox_wife1.Visible = true;
                textBox_wife2.Visible = true;
                textBox_wife3.Visible = true;
                textBox_wife4.Visible = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            try
            { 
            //------------ قائمة العنوان ---------------------------//
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter("select * from Cuntry", con);
            Da.Fill(Dt);
            comboBox_address.DataSource = Dt;
            comboBox_address.DisplayMember = "nameCuntry";
            comboBox_address.ValueMember = "nameCuntry";
            comboBox_address.SelectedIndex = -1;

            //------------ قائمة العنوان ---------------------------//


            //------------ قائمة المدينة ---------------------------//
            DataTable Dt2 = new DataTable();
            SqlDataAdapter Da2 = new SqlDataAdapter("select * from city", con);
            Da2.Fill(Dt2);
            comboBox_city.DataSource = Dt2;
            comboBox_city.DisplayMember = "namecity";
            comboBox_city.ValueMember = "namecity";
            comboBox_city.SelectedIndex = -1;

                //------------ قائمة المدينة ---------------------------//

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void comboBox_address_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_address.SelectedIndex == -1)
            {
                lbl_cuntry.Visible = false;
                textBox_cuntrey.Visible = false;
                lbl_city.Visible = false;
                comboBox_city.Visible = false;
                lbl_str.Visible = false;
                textBox_str.Visible = false;
            }
            if (comboBox_address.SelectedIndex == 1)
            {
                lbl_cuntry.Visible = true;
                textBox_cuntrey.Visible = true;
                lbl_city.Visible = false;
                comboBox_city.Visible = false;
                lbl_str.Visible = false;
                textBox_str.Visible = false;
            }
            else
            {
                lbl_city.Visible = true;
                comboBox_city.Visible = true;
                lbl_str.Visible = true;
                textBox_str.Visible = true;
                lbl_cuntry.Visible = false;
                textBox_cuntrey.Visible = false;
            }

        }

        private void textbox_age_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textbox_phone_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textbox_phone2_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1009 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_presnt_Doc_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1010 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_presnt_MM_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1011 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Number_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1012 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void add_file_pat_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void add_file_pat_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void panelControls_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            try
            {
                //------------ قائمة اسماء الشركات ---------------------------//
                DataTable Dt5 = new DataTable();
                SqlDataAdapter Da5 = new SqlDataAdapter("select * from insurance", con);
                Da5.Fill(Dt5);
                text_Measures.DataSource = Dt5;
                text_Measures.DisplayMember = "Name_insurance";
                text_Measures.ValueMember = "Name_insurance";
                text_Measures.SelectedIndex = -1;

                //------------ قائمة اسماء الشركات ---------------------------//
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1013 add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
