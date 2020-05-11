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
    public partial class controls_user : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public controls_user()
        {
            InitializeComponent();

        }

        private void controls_user_Load(object sender, EventArgs e)
        {
            try
            { 



            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter("select * from tbl_User", con);
            Da.Fill(Dt);
            list_user.DataSource = Dt;
            list_user.DisplayMember = "username";
            list_user.ValueMember = "ID";

            DataTable Dt2 = new DataTable();
            SqlDataAdapter Da2 = new SqlDataAdapter("select * from TB_Lists", con);
            Da2.Fill(Dt2);
            list_mune.DataSource = Dt2;
            list_mune.DisplayMember = "List_name";
            list_mune.ValueMember = "List_ID";

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 controls_user", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void list_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                DataTable Dts = new DataTable();
                Dts.Clear();
                SqlDataAdapter Da = new SqlDataAdapter();
                Da = new SqlDataAdapter("select TB_Priv.Priv_Screen_ID,Screen_name,Priv_User_ID,Priv_Display,Priv_Add,Priv_Edit,Priv_Delete from TB_Priv,TB_Screen where TB_Priv.Priv_Screen_ID=TB_Screen.Screen_ID and TB_Screen.List_ID=(select List_ID from TB_Lists where List_ID="+list_mune.SelectedValue+ ") and Priv_User_ID="+list_user.SelectedValue+"",con);
                Da.Fill(Dts);
                dataGridView1.DataSource =Dts;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[1].Width = 170;
                dataGridView1.Columns[1].HeaderText = "اسم الشاشة";
                dataGridView1.Columns[3].HeaderText = "تفعيل";
                dataGridView1.Columns[4].HeaderText = "إضافة";
                dataGridView1.Columns[5].HeaderText = "تعديل";
                dataGridView1.Columns[6].HeaderText = "حذف";
                dataGridView1.Columns[2].ReadOnly = true;



            }
            catch (Exception ee)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(list_user.SelectedValue);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    int Screen_No = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    Boolean Dis = dataGridView1.Rows[i].Cells["Priv_Display"].Value.Equals(true || false);
                    Boolean Add = dataGridView1.Rows[i].Cells["Priv_Add"].Value.Equals(true || false);
                    Boolean edit = dataGridView1.Rows[i].Cells["Priv_Edit"].Value.Equals(true || false);
                    Boolean delete = dataGridView1.Rows[i].Cells["Priv_Delete"].Value.Equals(true || false);
                    SqlCommand cmd = new SqlCommand("update TB_Priv set Priv_Display=@Priv_Display,Priv_Add=@Priv_Add,Priv_Edit=@Priv_Edit,Priv_Delete=@Priv_Delete where Priv_User_ID=@ID and Priv_Screen_ID=@Screen_ID", con);
                    cmd.Parameters.Add(new SqlParameter("@Priv_Display", SqlDbType.Bit)).Value = Dis;
                    cmd.Parameters.Add(new SqlParameter("@Priv_Add", SqlDbType.Bit)).Value = Add;
                    cmd.Parameters.Add(new SqlParameter("@Priv_Edit", SqlDbType.Bit)).Value = edit;
                    cmd.Parameters.Add(new SqlParameter("@Priv_Delete", SqlDbType.Bit)).Value = delete;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = userId;
                    cmd.Parameters.Add(new SqlParameter("@Screen_ID", SqlDbType.Int)).Value = Screen_No;
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                MessageBox.Show("تم منح الصلاحية");


            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 controls_user", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
            list_user_SelectedIndexChanged(sender, e);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 controls_user", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void list_mune_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
            list_user_SelectedIndexChanged(sender, e);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 controls_user", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
