using Clinics.adminControls;
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
    public partial class admin : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        int panelWidth;
        bool isCollapsed;
        public DateTime current;
        public admin()
        {
            InitializeComponent();
            panelWidth = panel1.Width;
            isCollapsed = false;
            timer2.Start();
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 admin", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void admin_Load(object sender, EventArgs e)
        {
            label7.Text = Form1.Recby;
            startHome_admin ssa = new startHome_admin();
            addControlsTopanel(ssa);
        }

        private void btn_Side_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_home);
            startHome_admin ssa = new startHome_admin();
            addControlsTopanel(ssa);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_logout);

            this.Close();
            Form1 ss = new Form1();
            ss.Show();
        }
    }
}
