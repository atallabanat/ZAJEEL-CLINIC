using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Clinics
{
    public partial class massegeSMS : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public massegeSMS()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            for(int i=0; i < dataGridView1.RowCount; i++)
            {
                if(dataGridView1.Rows[i].Cells["Col_Select"].Value=="1")
                {
                    string lan = dataGridView1.Rows[i].Cells["Col_phone_pat"].Value.ToString();
                    if (lan.Length ==10)
                    {
                        if (dataGridView1.Rows[i].Cells["Col_phone_pat"].Value != "077" && dataGridView1.Rows[i].Cells["Col_phone_pat"].Value != "079" && dataGridView1.Rows[i].Cells["Col_phone_pat"].Value != "078")
                        {
                            string Numbers_ROW = dataGridView1.Rows[i].Cells["Col_phone_pat"].Value.ToString();
                            textBox1.Text = textBox1.Text + "962" + Numbers_ROW.Substring(1, 9) + ",";

                        }
                    }

                }
            }





            if(textBox1.Text != "")
            {

                String result;
                string numbers = textBox1.Text;
                string message = textMasge.Text;

                String url = "http://josmsservice.com/smsonline/smppformwwl.cfm?numbers=" + numbers + ",&senderid=ShoruqClinc&AccName=ryadclinc&AccPass=ryadclinc123&msg=" + message + "&requesttimeout=5000000";
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
                    MessageBox.Show("تم إرسال الرسائل بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textMasge.Text = "";
                    textBox1.Text = "";
                }
                catch (Exception)
                {
                    //return e.Message;
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













            //try
            //{
            //    WebClient client = new WebClient();
            //    Stream s = client.OpenRead(string.Format("http://josmsservice.com/smsonline/msgservicejo.cfm?numbers="+textTo.Text+",&senderid=RyadClinic&AccName=ryadclinc&AccPass=ryadclinc123&msg=SMSBody&requesttimeout=5000000"));
            //    StreamReader reader = new StreamReader(s);
            //    string result = reader.ReadToEnd();
            //    MessageBox.Show(result, "Messge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



            //return( result;
        }

        private void massegeSMS_Load(object sender, EventArgs e)
        {
            //------------ قائمة الشركات ---------------------------//
            DataTable Dt5 = new DataTable();
            SqlDataAdapter Da5 = new SqlDataAdapter("select Name_insurance from insurance", con);
            Da5.Fill(Dt5);
            comboBox1.DataSource = Dt5;
            comboBox1.DisplayMember = "Name_insurance";
            comboBox1.ValueMember = "Name_insurance";
            comboBox1.SelectedIndex = -1;

            //------------ قائمة الشركات ---------------------------//
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                checkBox1.Checked = false;
                con.Open();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select Name_pat,Name_Measures,phone_pat from Table_PAT where Name_Measures LIKE @Name_Measures and phone_pat <> '' ";
                    Cmd.Parameters.AddWithValue("@Name_Measures", "%" + comboBox1.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }

                dataGridView1.DataSource = dataTable;
                con.Close();
            }     
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا"+ee.Message, "ERROR 1001 MassegeSMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow.Cells[3].Selected==true)
            {
                if(dataGridView1.CurrentRow.Cells[3].Value=="1")
                {

                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                for(int i =0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Cells["Col_Select"].Value = 1;
                }

            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Cells["Col_Select"].Value = 0;
                }
            }

        }
    }
    }

