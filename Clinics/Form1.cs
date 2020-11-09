using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using SQL2008R2Express1;
using static SQL2008R2Express1.SQL2008R2Express;

namespace Clinics
{
    public partial class Form1 : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices cd = new Choices();

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string username;
        public static string Recby
        {
            get { return username; }
            set { username = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Status = 0;
                SQL2008R2Express1.SQL2008R2Express atallaBanat = new SQL2008R2Express1.SQL2008R2Express();
                if (atallaBanat.CheckRegister(constring, ProgramName.Clinic) && atallaBanat.CheckRegister(constring, ProgramName.POS))
                {
                    Status = 3;
                }
                else if (atallaBanat.CheckRegister(constring, ProgramName.Clinic))
                {
                    Status = 2;
                }
                else if (atallaBanat.CheckRegister(constring, ProgramName.POS))
                {
                    Status = 1;
                }
                else
                {
                    Status = 0;
                }

                if (Status > 0)
                {
                    SqlCommand cmd = new SqlCommand("select * from tbl_User where username=@username and password=@password", con);
                    cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NChar)).Value = textBox_name.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NChar)).Value = textBox_password.Text.Trim();

                    SqlDataReader dr;
                    con.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        Program.user_ID = dr[0].ToString();
                        Program.Name_User = dr["username"].ToString();
                        Recby = textBox_name.Text;
                        if (Status == 3)
                        {
                            this.Hide();
                            home2 ff = new home2();
                            ff.Show();
                        }
                        else if (Status == 2)
                        {

                        }
                        else if (Status == 1)
                        {

                        }

                       
                        sre.RecognizeAsyncStop();
                        btnstart.Visible = true;
                        btnstop.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("اسم المستخدم وكلمة المرور خطأ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textbox_number.Clear();
                    textBox_name.Clear();
                    textBox_password.Clear();
                    textbox_number.Focus();
                    con.Close();
                }
                else
                {
                    frmRigister frm = new frmRigister();
                    frm.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    
        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            try
            { 
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void textbox_number_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            btnstart.Visible = false;
            btnstop.Visible = true;
            cd.Add(new string[] { "User","pass","close", "login", "stop" });
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
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "close":
                    Application.Exit();
                    break;

                case "login": 
                    button1_Click(sender, e);
                     break;

                case "stop":
                    btnstop_Click(sender, e);
                    break;

                case "User":
                    textbox_number.Focus();
                    break;

                case "pass":
                    textBox_password.Focus();
                    break;

            }

        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            sre.RecognizeAsyncStop();
            btnstart.Visible = true;
            btnstop.Visible = false;
        }

 

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                SqlCommand na = new SqlCommand();
                na = new SqlCommand("select username from tbl_User where ID=@ID", con);
                na.Parameters.Add(new SqlParameter("@ID", textbox_number.Text));
                con.Close();
                con.Open();
                SqlDataReader dr;

                dr = na.ExecuteReader();
                if (dr.Read())
                {

                    string username = (string)dr["username"].ToString();
                    textBox_name.Text = username.ToString();


                }


                con.Close();

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
