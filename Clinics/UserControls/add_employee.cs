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

namespace Clinics.userControls
{
    public partial class add_employee : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public add_employee()
        {
            InitializeComponent();

        }

        void LoadData()
        {
            try
            { 
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter("select * from tbl_User", con);
            Da.Fill(Dt);
            listBox1.DataSource = Dt;
            listBox1.DisplayMember = "username";
            listBox1.ValueMember = "ID";
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 add_employee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
            text_number_user.Text = "";
            text_name_user.Text = "";
            text_password_user.Text = "";
            btn_delete.Visible = false;
            btn_edit.Visible = false;
            btn_add.Enabled = true;
            btn_add_emp.Visible = false;

            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (ID)+1,1) from tbl_User", con);
            con.Open();
            SqlDataReader Ra = cmd.ExecuteReader();

            Ra.Read();
            text_number_user.Text = Ra[0].ToString();
            Ra.Close();
            con.Close();

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 add_employee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {


                if (text_number_user.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم المستخدم", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (text_name_user.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم المستخدم", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (text_password_user.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة كلمة المرور", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select ID from tbl_User where ID=@ID", con);
                    cmd21.Parameters.Add(new SqlParameter("@ID", text_number_user.Text));
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
                        MessageBox.Show("رقم الموظف موجود مسبقا ، لا يمكن إضافة موظف بنفس الرقم  " + text_number_user.Text.Trim(), "تكرار البيانات رقم الموظف موجود مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {

                        SqlCommand cmd = new SqlCommand("insert into tbl_User values(@ID,@username,@password)" +
                        "insert into TB_Priv (Priv_Screen_ID,Priv_User_ID) select Screen_ID,@ID from TB_Screen", con);

                        cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = text_number_user.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar)).Value = text_name_user.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar)).Value = text_password_user.Text.Trim();



                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        LoadData();
                        text_name_user.Focus();
                        btn_add.Enabled = false;
                        btn_add_emp.Visible = true;
                        btn_delete.Visible = true;
                        btn_edit.Visible = true;


                        MessageBox.Show("تم إضافة الموظف بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 add_employee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void add_employee_Load(object sender, EventArgs e)
        {
            LoadData();

            text_name_user.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter("select * from tbl_User where ID=" + listBox1.SelectedValue + "", con);
                Da.Fill(Dt);
                text_number_user.Text = Dt.Rows[0]["ID"].ToString();
                text_name_user.Text = Dt.Rows[0]["username"].ToString();
                text_password_user.Text = Dt.Rows[0]["password"].ToString();
            }
            catch (Exception)
            {

            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_number_user.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم المستخدم", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (text_name_user.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم المستخدم", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (text_password_user.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة كلمة المرور", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("update tbl_User set ID=@ID,username=@username,password=@password where ID=" + listBox1.SelectedValue + "", con);

                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = text_number_user.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar)).Value = text_name_user.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar)).Value = text_password_user.Text.Trim();



                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadData();


                    MessageBox.Show("تم تعديل بيانات الموظف بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 add_employee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (text_number_user.Text == "")
            {
                MessageBox.Show("يرجى تحديد رقم المستخدم قبل الحذف", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {


                        SqlCommand cmd = new SqlCommand("delete from tbl_User where ID=" + listBox1.SelectedValue + "", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        LoadData();

                        MessageBox.Show("تم حذف الموظف بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception ee)
                    {
                        con.Close();
                        MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 add_employee", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {
            try
            { 
                int index = listBox1.FindString(text_search.Text, -1);
                if (index != -1)
                {
                    listBox1.SetSelected(index, true);
                }
                else
                {
                    MessageBox.Show("لايوجد موظف يهذا الاسم");
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 add_employee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
    }
}
