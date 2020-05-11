using Clinics.userControls;
using Clinics.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinics
{
    public partial class home : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        int panelWidth;
        bool isCollapsed;
        public DateTime current;
        DataTable Dt = new DataTable();

        public home()
        {
            InitializeComponent();
            panelWidth = panel1.Width;
            isCollapsed = false;
            timer2.Start();



        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panel1.Width = panel1.Width + 10;

                if (panel1.Width >= panelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();

                }
            }
            else
            {
                panel1.Width = panel1.Width - 10;
                if (panel1.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();

                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                lbl_date.Text = DateTime.Now.ToLongDateString();
                current = DateTime.Now;
                lbl_time.Text = dt.ToString("HH:MM:ss");
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Home", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_home);
            startHome ssa = new startHome();
            addControlsTopanel(ssa);
        }

        //------------ الشريط المتحرك بجانب الزر ---------------------//
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;



        }
        //--------------------------الصفحات المتنقلة ------------------------//
        private void addControlsTopanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);

        }
        private void btn_Side_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void btn_Exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            visitpatient ssa = new visitpatient();
            addControlsTopanel(ssa);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            controls_user ssa = new controls_user();
            addControlsTopanel(ssa);

        }

        private void btn_create_pat_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_create_pat);

            add_file_pat ssa = new add_file_pat();
            addControlsTopanel(ssa);
        }

        private void home_Load(object sender, EventArgs e)
        {
            try
            {


                label7.Text = Form1.Recby;

                startHome ssa = new startHome();
                addControlsTopanel(ssa);
                SqlDataAdapter Da;
                DataTable Dt = new DataTable();

                Da = new SqlDataAdapter("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + "", con);
                Da.Fill(Dt);
                if (Dt.Rows[11][0].ToString() == "False" || Dt.Rows[11][0].ToString() == string.Empty)
                {
                    button4.Visible = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void sendtodoc_Click(object sender, EventArgs e)
        {
            try
            {



                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Table_visit_patient set SentToDoc=1 ";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();




                MessageBox.Show("تم الارسال بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Home", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_new_pat_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_new_pat);

            visitpatient ssa = new visitpatient();
            addControlsTopanel(ssa);
        }

        private void btn_quary_pat_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_quary_pat);
            quary_add_file_pat ssa = new quary_add_file_pat();
            addControlsTopanel(ssa);

        }

        private void btn_qury_new_pat_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_qury_new_pat);
            quary_visitpatient ssa = new quary_visitpatient();
            addControlsTopanel(ssa);

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_logout);

            this.Close();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            moveSidePanel(button2);

            add_file_pat ssa = new add_file_pat();
            addControlsTopanel(ssa);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveSidePanel(button3);

            quary_insurance ssa = new quary_insurance();
            addControlsTopanel(ssa);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            doctar dd = new doctar();
            dd.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("هذه الشاشة محمية  ، فقط في حالة الضرورة ، يرجى وضع كلمة المرور للدخول اليها", "كلمة المرور", "*****", 0, 0);

            if (input == "keyzone")
            {
                massegeSMS sMS = new massegeSMS();
                sMS.ShowDialog();
            }
        }
    }
}