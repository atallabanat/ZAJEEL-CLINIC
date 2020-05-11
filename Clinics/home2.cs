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
using Clinics.Pharmacy;

namespace Clinics
{
    public partial class home2 : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        SqlDataAdapter Da;
        DataTable Dt = new DataTable();
        public home2()
        {
            try
            { 
            InitializeComponent();
            Da = new SqlDataAdapter("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID)+"",con);
            Da.Fill(Dt);


            if (Dt.Rows[0][0].ToString() == "False" || Dt.Rows[0][0].ToString() == string.Empty)
                btn_admin.Visible = false;

            if (Dt.Rows[1][0].ToString() == "False" || Dt.Rows[1][0].ToString() == string.Empty)
                btn_dr.Visible = false;

            if (Dt.Rows[2][0].ToString() == "False" || Dt.Rows[2][0].ToString() == string.Empty)
                btn_pha.Visible = false;

            if (Dt.Rows[3][0].ToString() == "False" || Dt.Rows[3][0].ToString() == string.Empty)
                btn_resp.Visible = false;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Home2", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void home2_Load(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_resp_Click(object sender, EventArgs e)
        {
            this.Close();
            home ff = new home();
            ff.Show();
        }

        private void btn_dr_Click(object sender, EventArgs e)
        {
            this.Close();
            doctar ff = new doctar();
            ff.Show();
        }

        private void btn_pha_Click(object sender, EventArgs e)
        {
            this.Close();
            POS nn = new POS();
            nn.Show();
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            this.Close();
            admin nn = new admin();
            nn.Show();
        }
    }
}
