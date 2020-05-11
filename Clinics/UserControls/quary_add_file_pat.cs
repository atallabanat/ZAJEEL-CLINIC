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

namespace Clinics.UserControls
{
    public partial class quary_add_file_pat : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        SqlDataAdapter Da;
        DataTable Dt = new DataTable();
        public static quary_add_file_pat qq;
        public quary_add_file_pat()
        {
            qq = this;
            InitializeComponent();
            try
            { 
            Da = new SqlDataAdapter("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + "", con);
            Da.Fill(Dt);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 quary_add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

        private void textBox_Number_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBox_Number.Text == "")
                {
                    textBox_Name.Text = "";
                    textbox_age.Text = "";
                    textbox_phone.Text = "";
                    textbox_enD_Date.Text = "";
                    text_Measures.Text = "";
                    text_presnt_Measures.Text = "";
                    text_presnt_MM.Text = "";
                    text_presnt_Doc.Text = "";
                    text_number_Measures.Text = "";
                    textBox_cuntrey.Text = "";
                    textBox_str.Text = "";
                    textBox_wife1.Text = "";
                    textBox_wife2.Text = "";
                    textBox_wife3.Text = "";
                    textBox_wife4.Text = "";
                    textBox_ch1.Text = "";
                    textBox_ch2.Text = "";
                    textBox_ch3.Text = "";
                    textBox_ch4.Text = "";
                    textBox_ch5.Text = "";
                    textBox_ch6.Text = "";
                    textBox_ch7.Text = "";
                    textBox_ch8.Text = "";
                    textBox_ch9.Text = "";
                    textBox_ch10.Text = "";
                    textBox_ch11.Text = "";
                    textBox_ch12.Text = "";
                    textBox_ch13.Text = "";
                    textBox_ch14.Text = "";
                    text_Nch.Text = "";
                    text_address.Text = "";
                    text_city.Text = "";
                    text_Nfamile.Text = "";
                    text_Nwife.Text = "";

                }
                else
                {
                    SqlCommand na = new SqlCommand();
                    na = new SqlCommand("select ID_pat,Name_pat,age_pat,phone_pat,end_Date,Name_Measures,presnt_Measures,presnt_Doc,presnt_MM,number_Measures,address_pat,city_pat,cuntry_pat,str_pat,Nfamile,Nwife,wife1,wife2,wife3,wife4,Nch,ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch8,ch9,ch10,ch11,ch12,ch13,ch14 from Table_PAT where  ID_pat =  '" + textBox_Number.Text + "' ", con);
                    con.Open();
                    na.ExecuteNonQuery();
                    SqlDataReader dr;

                    dr = na.ExecuteReader();
                    if (dr.Read())
                    {

                        string Name_pat = (string)dr["Name_pat"].ToString();
                        textBox_Name.Text = Name_pat;

                        string age_pat = (string)dr["age_pat"].ToString();
                        textbox_age.Text = age_pat;


                        string phone_pat = (string)dr["phone_pat"].ToString();
                        textbox_phone.Text = phone_pat;

                        string end_Date = (string)dr["end_Date"].ToString();
                        textbox_enD_Date.Value =Convert.ToDateTime( end_Date);

                        string Name_Measures = (string)dr["Name_Measures"].ToString();
                        text_Measures.Text = Name_Measures;

                        string presnt_Measures = (string)dr["presnt_Measures"].ToString();
                        text_presnt_Measures.Text = presnt_Measures;

                        string presnt_MM = (string)dr["presnt_MM"].ToString();
                        text_presnt_MM.Text = presnt_MM;

                        string presnt_Doc = (string)dr["presnt_Doc"].ToString();
                        text_presnt_Doc.Text = presnt_Doc;

                        string number_Measures = (string)dr["number_Measures"].ToString();
                        text_number_Measures.Text = number_Measures;

                        string address_pat = (string)dr["address_pat"].ToString();
                        text_address.Text = address_pat;

                        string city_pat = (string)dr["city_pat"].ToString();
                        text_city.Text = city_pat;

                        string cuntry_pat = (string)dr["cuntry_pat"].ToString();
                        textBox_cuntrey.Text = cuntry_pat;

                        string str_pat = (string)dr["str_pat"].ToString();
                        textBox_str.Text = str_pat;

                        string Nfamile = (string)dr["Nfamile"].ToString();
                        text_Nfamile.Text = Nfamile;

                        string Nwife = (string)dr["Nwife"].ToString();
                        text_Nwife.Text = Nwife;

                        string wife1 = (string)dr["wife1"].ToString();
                        textBox_wife1.Text = wife1;

                        string wife2 = (string)dr["wife2"].ToString();
                        textBox_wife2.Text = wife2;


                        string wife3 = (string)dr["wife3"].ToString();
                        textBox_wife3.Text = wife3;


                        string wife4 = (string)dr["wife4"].ToString();
                        textBox_wife4.Text = wife4;


                        string Nch = (string)dr["Nch"].ToString();
                        text_Nch.Text = Nch;


                        string ch1 = (string)dr["ch1"].ToString();
                        textBox_ch1.Text = ch1;


                        string ch2 = (string)dr["ch2"].ToString();
                        textBox_ch2.Text = ch2;


                        string ch3 = (string)dr["ch3"].ToString();
                        textBox_ch3.Text = ch3;


                        string ch4 = (string)dr["ch4"].ToString();
                        textBox_ch4.Text = ch4;


                        string ch5 = (string)dr["ch5"].ToString();
                        textBox_ch5.Text = ch5;


                        string ch6 = (string)dr["ch6"].ToString();
                        textBox_ch6.Text = ch6;


                        string ch7 = (string)dr["ch7"].ToString();
                        textBox_ch7.Text = ch7;


                        string ch8 = (string)dr["ch8"].ToString();
                        textBox_ch8.Text = ch8;


                        string ch9 = (string)dr["ch9"].ToString();
                        textBox_ch9.Text = ch9;


                        string ch10 = (string)dr["ch10"].ToString();
                        textBox_ch10.Text = ch10;


                        string ch11 = (string)dr["ch11"].ToString();
                        textBox_ch11.Text = ch11;


                        string ch12 = (string)dr["ch12"].ToString();
                        textBox_ch12.Text = ch12;


                        string ch13 = (string)dr["ch13"].ToString();
                        textBox_ch13.Text = ch13;


                        string ch14 = (string)dr["ch14"].ToString();
                        textBox_ch14.Text = ch14;



                    }
                    else
                    {
                        textBox_Name.Text = "";
                        textbox_age.Text = "";
                        textbox_phone.Text = "";
                        textbox_enD_Date.Text = "";
                        text_Measures.Text = "";
                        text_presnt_Measures.Text = "";
                        text_presnt_MM.Text = "";
                        text_presnt_Doc.Text = "";
                        text_number_Measures.Text = "";
                        textBox_cuntrey.Text = "";
                        textBox_str.Text = "";
                        textBox_wife1.Text = "";
                        textBox_wife2.Text = "";
                        textBox_wife3.Text = "";
                        textBox_wife4.Text = "";
                        textBox_ch1.Text = "";
                        textBox_ch2.Text = "";
                        textBox_ch3.Text = "";
                        textBox_ch4.Text = "";
                        textBox_ch5.Text = "";
                        textBox_ch6.Text = "";
                        textBox_ch7.Text = "";
                        textBox_ch8.Text = "";
                        textBox_ch9.Text = "";
                        textBox_ch10.Text = "";
                        textBox_ch11.Text = "";
                        textBox_ch12.Text = "";
                        textBox_ch13.Text = "";
                        textBox_ch14.Text = "";
                        text_Nch.Text = "";
                        text_address.Text = "";
                        text_city.Text = "";
                        text_Nfamile.Text = "";
                        text_Nwife.Text = "";
                    }
                    dr.Close();
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 quary_add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (Dt.Rows[7][0].ToString() == "False" || Dt.Rows[7][0].ToString() == string.Empty)
                {
                    MessageBox.Show("عذرا لايوجد لديك صلاحية الحذف", "حذف ملف", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (textBox_Number.Text == "")
                {
                    MessageBox.Show("يرجى تحديد الرقم الوطني قبل الحذف", "عملية غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {


                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from Table_PAT where ID_pat=@ID_pat";
                    cmd.Parameters.Add(new SqlParameter("@ID_pat", textBox_Number.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox_Number.Text = "";
                    textBox_Name.Text = "";
                    textbox_age.Text = "";
                    textbox_phone.Text = "";
                    textbox_enD_Date.Text = "";
                    text_Measures.Text = "";
                    text_presnt_Measures.Text = "";
                    text_presnt_Doc.Text = "";
                    text_presnt_MM.Text = "";
                    text_number_Measures.Text = "";
                    textBox_cuntrey.Text = "";
                    textBox_str.Text = "";
                    textBox_wife1.Text = "";
                    textBox_wife2.Text = "";
                    textBox_wife3.Text = "";
                    textBox_wife4.Text = "";
                    textBox_ch1.Text = "";
                    textBox_ch2.Text = "";
                    textBox_ch3.Text = "";
                    textBox_ch4.Text = "";
                    textBox_ch5.Text = "";
                    textBox_ch6.Text = "";
                    textBox_ch7.Text = "";
                    textBox_ch8.Text = "";
                    textBox_ch9.Text = "";
                    textBox_ch10.Text = "";
                    textBox_ch11.Text = "";
                    textBox_ch12.Text = "";
                    textBox_ch13.Text = "";
                    textBox_ch14.Text = "";
                    text_Nch.Text = "";
                    text_address.Text = "";
                    text_city.Text = "";
                    text_Nfamile.Text = "";
                    text_Nwife.Text = "";
                    MessageBox.Show("تم حذف ملف المريض بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 quary_add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dt.Rows[6][0].ToString() == "False" || Dt.Rows[6][0].ToString() == string.Empty)
                {
                    MessageBox.Show("عذرا لايوجد لديك صلاحية التعديل", "تعديل ملف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBox_Number.Text == "")
                {
                    MessageBox.Show("يرجى تحديد الرقم الوطني للتعديل", "عملية غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
    


                    SqlCommand cmd = new SqlCommand("update Table_PAT set  Name_pat=@Name_pat,age_pat=@age_pat,phone_pat=@phone_pat,end_Date=@end_Date,Name_Measures=@Name_Measures,presnt_Measures=@presnt_Measures,presnt_Doc=@presnt_Doc,presnt_MM=@presnt_MM,number_Measures=@number_Measures,address_pat=@address_pat,city_pat=@city_pat,cuntry_pat=@cuntry_pat,str_pat=@str_pat,Nfamile=@Nfamile,Nwife=@Nwife,wife1=@wife1,wife2=@wife2,wife3=@wife3,wife4=@wife4,Nch=@Nch,ch1=@ch1,ch2=@ch2,ch3=@ch3,ch4=@ch4,ch5=@ch5,ch6=@ch6,ch7=@ch7,ch8=@ch8,ch9=@ch9,ch10=@ch10,ch11=@ch11,ch12=@ch12,ch13=@ch13,ch14=@ch14  where ID_pat='" + textBox_Number.Text + "'", con);



                    cmd.Parameters.Add(new SqlParameter("@Name_pat", SqlDbType.NVarChar)).Value = textBox_Name.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@age_pat", textbox_age.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@phone_pat", textbox_phone.Text.Trim()));
                    cmd.Parameters.Add("@end_Date", SqlDbType.SmallDateTime).Value = textbox_enD_Date.Value;
                    cmd.Parameters.Add(new SqlParameter("@Name_Measures", text_Measures.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@presnt_Measures", text_presnt_Measures.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@presnt_MM", text_presnt_MM.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@presnt_Doc", text_presnt_Doc.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@number_Measures", text_number_Measures.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@address_pat", SqlDbType.NVarChar)).Value = text_address.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@city_pat", SqlDbType.NVarChar)).Value = text_city.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@cuntry_pat", SqlDbType.NVarChar)).Value = textBox_cuntrey.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@str_pat", SqlDbType.NVarChar)).Value = textBox_str.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Nfamile", text_Nfamile.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@Nwife", text_Nwife.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@wife1", SqlDbType.NVarChar)).Value = textBox_wife1.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@wife2", SqlDbType.NVarChar)).Value = textBox_wife2.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@wife3", SqlDbType.NVarChar)).Value = textBox_wife3.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@wife4", SqlDbType.NVarChar)).Value = textBox_wife4.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Nch", text_Nch.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@ch1", SqlDbType.NVarChar)).Value = textBox_ch1.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch2", SqlDbType.NVarChar)).Value = textBox_ch2.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch3", SqlDbType.NVarChar)).Value = textBox_ch3.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch4", SqlDbType.NVarChar)).Value = textBox_ch4.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch5", SqlDbType.NVarChar)).Value = textBox_ch5.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch6", SqlDbType.NVarChar)).Value = textBox_ch6.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch7", SqlDbType.NVarChar)).Value = textBox_ch7.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch8", SqlDbType.NVarChar)).Value = textBox_ch8.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch9", SqlDbType.NVarChar)).Value = textBox_ch9.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch10", SqlDbType.NVarChar)).Value = textBox_ch10.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch11", SqlDbType.NVarChar)).Value = textBox_ch11.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch12", SqlDbType.NVarChar)).Value = textBox_ch12.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch13", SqlDbType.NVarChar)).Value = textBox_ch13.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@ch14", SqlDbType.NVarChar)).Value = textBox_ch14.Text.Trim();

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("تم تعديل بيانات المريض بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 quary_add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void textbox_phone_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBox_Name.Text == "")
                {
                    if (textbox_phone.Text == "")
                    {
                    textBox_Name.Text = "";
                    textbox_age.Text = "";
                    textBox_Number.Text = "";
                    textbox_enD_Date.Text = "";
                    text_Measures.Text = "";
                    text_presnt_Measures.Text = "";
                    text_number_Measures.Text = "";
                    textBox_cuntrey.Text = "";
                    textBox_str.Text = "";
                    textBox_wife1.Text = "";
                    textBox_wife2.Text = "";
                    textBox_wife3.Text = "";
                    textBox_wife4.Text = "";
                    textBox_ch1.Text = "";
                    textBox_ch2.Text = "";
                    textBox_ch3.Text = "";
                    textBox_ch4.Text = "";
                    textBox_ch5.Text = "";
                    textBox_ch6.Text = "";
                    textBox_ch7.Text = "";
                    textBox_ch8.Text = "";
                    textBox_ch9.Text = "";
                    textBox_ch10.Text = "";
                    textBox_ch11.Text = "";
                    textBox_ch12.Text = "";
                    textBox_ch13.Text = "";
                    textBox_ch14.Text = "";
                    text_Nch.Text = "";
                    text_address.Text = "";
                    text_city.Text = "";
                    text_Nfamile.Text = "";
                    text_Nwife.Text = "";

                }
                else
                {

                        SqlCommand na = new SqlCommand();
                        na = new SqlCommand("select ID_pat,Name_pat,age_pat,phone_pat,end_Date,Name_Measures,presnt_Measures,number_Measures,address_pat,city_pat,cuntry_pat,str_pat,Nfamile,Nwife,wife1,wife2,wife3,wife4,Nch,ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch8,ch9,ch10,ch11,ch12,ch13,ch14 from Table_PAT where  phone_pat =  '" + textbox_phone.Text + "' ", con);
                        con.Open();
                        na.ExecuteNonQuery();
                        SqlDataReader dr;

                        dr = na.ExecuteReader();
                        while (dr.Read())
                        {

                            string Name_pat = (string)dr["Name_pat"].ToString();
                            textBox_Name.Text = Name_pat;

                            string age_pat = (string)dr["age_pat"].ToString();
                            textbox_age.Text = age_pat;


                            string ID_pat = (string)dr["ID_pat"].ToString();
                            textBox_Number.Text = ID_pat;

                            string end_Date = (string)dr["end_Date"].ToString();
                            textbox_enD_Date.Value = Convert.ToDateTime(end_Date);

                            string Name_Measures = (string)dr["Name_Measures"].ToString();
                            text_Measures.Text = Name_Measures;

                            string presnt_Measures = (string)dr["presnt_Measures"].ToString();
                            text_presnt_Measures.Text = presnt_Measures;

                            string number_Measures = (string)dr["number_Measures"].ToString();
                            text_number_Measures.Text = number_Measures;

                            string address_pat = (string)dr["address_pat"].ToString();
                            text_address.Text = address_pat;

                            string city_pat = (string)dr["city_pat"].ToString();
                            text_city.Text = city_pat;

                            string cuntry_pat = (string)dr["cuntry_pat"].ToString();
                            textBox_cuntrey.Text = cuntry_pat;

                            string str_pat = (string)dr["str_pat"].ToString();
                            textBox_str.Text = str_pat;

                            string Nfamile = (string)dr["Nfamile"].ToString();
                            text_Nfamile.Text = Nfamile;

                            string Nwife = (string)dr["Nwife"].ToString();
                            text_Nwife.Text = Nwife;

                            string wife1 = (string)dr["wife1"].ToString();
                            textBox_wife1.Text = wife1;

                            string wife2 = (string)dr["wife2"].ToString();
                            textBox_wife2.Text = wife2;


                            string wife3 = (string)dr["wife3"].ToString();
                            textBox_wife3.Text = wife3;


                            string wife4 = (string)dr["wife4"].ToString();
                            textBox_wife4.Text = wife4;


                            string Nch = (string)dr["Nch"].ToString();
                            text_Nch.Text = Nch;


                            string ch1 = (string)dr["ch1"].ToString();
                            textBox_ch1.Text = ch1;


                            string ch2 = (string)dr["ch2"].ToString();
                            textBox_ch2.Text = ch2;


                            string ch3 = (string)dr["ch3"].ToString();
                            textBox_ch3.Text = ch3;


                            string ch4 = (string)dr["ch4"].ToString();
                            textBox_ch4.Text = ch4;


                            string ch5 = (string)dr["ch5"].ToString();
                            textBox_ch5.Text = ch5;


                            string ch6 = (string)dr["ch6"].ToString();
                            textBox_ch6.Text = ch6;


                            string ch7 = (string)dr["ch7"].ToString();
                            textBox_ch7.Text = ch7;


                            string ch8 = (string)dr["ch8"].ToString();
                            textBox_ch8.Text = ch8;


                            string ch9 = (string)dr["ch9"].ToString();
                            textBox_ch9.Text = ch9;


                            string ch10 = (string)dr["ch10"].ToString();
                            textBox_ch10.Text = ch10;


                            string ch11 = (string)dr["ch11"].ToString();
                            textBox_ch11.Text = ch11;


                            string ch12 = (string)dr["ch12"].ToString();
                            textBox_ch12.Text = ch12;


                            string ch13 = (string)dr["ch13"].ToString();
                            textBox_ch13.Text = ch13;


                            string ch14 = (string)dr["ch14"].ToString();
                            textBox_ch14.Text = ch14;



                        }
                        dr.Close();
                        con.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 quary_add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            saqwe ss = new saqwe();
            ss.Show();
        }

        private void quary_add_file_pat_Load(object sender, EventArgs e)
        {
            try
            { 
            con.Open();
            SqlCommand cmd2;
            SqlDataReader dr2;
            cmd2 = new SqlCommand("select Name_pat from Table_PAT", con);
            cmd2.ExecuteNonQuery();
            dr2 = cmd2.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while (dr2.Read())
            {
                col.Add(dr2.GetString(0));

            }
            textBox_Name.AutoCompleteCustomSource = col;
            dr2.Close();
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 quary_add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Name_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBox_Name.Text == "")
                {
                    textBox_Number.Text = "";
                    textbox_age.Text = "";
                    textbox_phone.Text = "";
                    textbox_enD_Date.Text = "";
                    text_Measures.Text = "";
                    text_presnt_Measures.Text = "";
                    text_presnt_Doc.Text = "";
                    text_presnt_MM.Text = "";
                    text_number_Measures.Text = "";
                    textBox_cuntrey.Text = "";
                    textBox_str.Text = "";
                    textBox_wife1.Text = "";
                    textBox_wife2.Text = "";
                    textBox_wife3.Text = "";
                    textBox_wife4.Text = "";
                    textBox_ch1.Text = "";
                    textBox_ch2.Text = "";
                    textBox_ch3.Text = "";
                    textBox_ch4.Text = "";
                    textBox_ch5.Text = "";
                    textBox_ch6.Text = "";
                    textBox_ch7.Text = "";
                    textBox_ch8.Text = "";
                    textBox_ch9.Text = "";
                    textBox_ch10.Text = "";
                    textBox_ch11.Text = "";
                    textBox_ch12.Text = "";
                    textBox_ch13.Text = "";
                    textBox_ch14.Text = "";
                    text_Nch.Text = "";
                    text_address.Text = "";
                    text_city.Text = "";
                    text_Nfamile.Text = "";
                    text_Nwife.Text = "";

                }
                else
                {
                    SqlCommand na = new SqlCommand();
                    na = new SqlCommand("select ID_pat,age_pat,phone_pat,end_Date,Name_Measures,presnt_Measures,presnt_MM,presnt_Doc,number_Measures,address_pat,city_pat,cuntry_pat,str_pat,Nfamile,Nwife,wife1,wife2,wife3,wife4,Nch,ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch8,ch9,ch10,ch11,ch12,ch13,ch14 from Table_PAT where  Name_pat = @Name_pat", con);
                    na.Parameters.Add(new SqlParameter("@Name_pat", textBox_Name.Text)) ;
                    con.Open();
                    na.ExecuteNonQuery();
                    SqlDataReader dr;

                    dr = na.ExecuteReader();
                    while (dr.Read())
                    {

                        string number_pat = (string)dr["ID_pat"].ToString();
                        textBox_Number.Text = number_pat;

                        string age_pat = (string)dr["age_pat"].ToString();
                        textbox_age.Text = age_pat;


                        string phone_pat = (string)dr["phone_pat"].ToString();
                        textbox_phone.Text = phone_pat;

                        string end_Date = (string)dr["end_Date"].ToString();
                        textbox_enD_Date.Text = end_Date;

                        string Name_Measures = (string)dr["Name_Measures"].ToString();
                        text_Measures.Text = Name_Measures;

                        string presnt_Measures = (string)dr["presnt_Measures"].ToString();
                        text_presnt_Measures.Text = presnt_Measures;

                        string presnt_MM = (string)dr["presnt_MM"].ToString();
                        text_presnt_MM.Text = presnt_MM;

                        string presnt_Doc = (string)dr["presnt_Doc"].ToString();
                        text_presnt_Doc.Text = presnt_Doc;


                        string number_Measures = (string)dr["number_Measures"].ToString();
                        text_number_Measures.Text = number_Measures;

                        string address_pat = (string)dr["address_pat"].ToString();
                        text_address.Text = address_pat;

                        string city_pat = (string)dr["city_pat"].ToString();
                        text_city.Text = city_pat;

                        string cuntry_pat = (string)dr["cuntry_pat"].ToString();
                        textBox_cuntrey.Text = cuntry_pat;

                        string str_pat = (string)dr["str_pat"].ToString();
                        textBox_str.Text = str_pat;

                        string Nfamile = (string)dr["Nfamile"].ToString();
                        text_Nfamile.Text = Nfamile;

                        string Nwife = (string)dr["Nwife"].ToString();
                        text_Nwife.Text = Nwife;

                        string wife1 = (string)dr["wife1"].ToString();
                        textBox_wife1.Text = wife1;

                        string wife2 = (string)dr["wife2"].ToString();
                        textBox_wife2.Text = wife2;


                        string wife3 = (string)dr["wife3"].ToString();
                        textBox_wife3.Text = wife3;


                        string wife4 = (string)dr["wife4"].ToString();
                        textBox_wife4.Text = wife4;


                        string Nch = (string)dr["Nch"].ToString();
                        text_Nch.Text = Nch;


                        string ch1 = (string)dr["ch1"].ToString();
                        textBox_ch1.Text = ch1;


                        string ch2 = (string)dr["ch2"].ToString();
                        textBox_ch2.Text = ch2;


                        string ch3 = (string)dr["ch3"].ToString();
                        textBox_ch3.Text = ch3;


                        string ch4 = (string)dr["ch4"].ToString();
                        textBox_ch4.Text = ch4;


                        string ch5 = (string)dr["ch5"].ToString();
                        textBox_ch5.Text = ch5;


                        string ch6 = (string)dr["ch6"].ToString();
                        textBox_ch6.Text = ch6;


                        string ch7 = (string)dr["ch7"].ToString();
                        textBox_ch7.Text = ch7;


                        string ch8 = (string)dr["ch8"].ToString();
                        textBox_ch8.Text = ch8;


                        string ch9 = (string)dr["ch9"].ToString();
                        textBox_ch9.Text = ch9;


                        string ch10 = (string)dr["ch10"].ToString();
                        textBox_ch10.Text = ch10;


                        string ch11 = (string)dr["ch11"].ToString();
                        textBox_ch11.Text = ch11;


                        string ch12 = (string)dr["ch12"].ToString();
                        textBox_ch12.Text = ch12;


                        string ch13 = (string)dr["ch13"].ToString();
                        textBox_ch13.Text = ch13;


                        string ch14 = (string)dr["ch14"].ToString();
                        textBox_ch14.Text = ch14;



                    }
                    dr.Close();
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 quary_add_file_pat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void quary_add_file_pat_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
