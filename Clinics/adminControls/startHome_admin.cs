using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Clinics.UserControls;
using Clinics.userControls;
using Clinics.pharmacy_Control;

namespace Clinics.adminControls
{
    public partial class startHome_admin : UserControl
    {
        
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public startHome_admin()
        {
            InitializeComponent();
        }
        
        //--------------------------الصفحات المتنقلة ------------------------//
        private void addControlsTopanel(Control c)
        {
            try
            { 
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 start_admin", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void startHome_admin_Load(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd4 = con.CreateCommand();

            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "select count(Name_pat) from Table_PAT where age_pat is not null";
            con.Open();
            
                Int32 rows_count2 = Convert.ToInt32(cmd4.ExecuteScalar());
                label2.Text = rows_count2.ToString() + "";

            
            con.Close();


            SqlCommand cmd5 = con.CreateCommand();

            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "select count(ID_visit) from Table_visit_patient where isnull(end_Paid,0) <> 1    and isnull(end_ee,0) <> 1 and date_visit is not null";
            con.Open();
                Int32 rows_count22 = Convert.ToInt32(cmd5.ExecuteScalar());
                label32.Text = rows_count22.ToString() + "";
                
            con.Close();

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 start_admin", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            add_employee ssa = new add_employee();
            addControlsTopanel(ssa);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            controls_user ssa = new controls_user();
            addControlsTopanel(ssa);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add_Measures ssa = new add_Measures();
            addControlsTopanel(ssa);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Mesures ss = new Add_Mesures();
            ss.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Retail ssa = new Add_Retail();
            addControlsTopanel(ssa);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PRS ssa = new PRS();
            addControlsTopanel(ssa);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Add_Supplier ssa = new Add_Supplier();
            addControlsTopanel(ssa);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Orders_Parchases ss = new Orders_Parchases();
            ss.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Orders_Damage ss = new Orders_Damage();
            ss.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ADD_recpie ss = new ADD_recpie();
            ss.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            End_orders ss = new End_orders();
            ss.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            End_user ss = new End_user();
            ss.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Insurance_companies ssa = new Insurance_companies();
            addControlsTopanel(ssa);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Patient_files ssa = new Patient_files();
            addControlsTopanel(ssa);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            massegeSMS sMS = new massegeSMS();
            sMS.ShowDialog();
        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}