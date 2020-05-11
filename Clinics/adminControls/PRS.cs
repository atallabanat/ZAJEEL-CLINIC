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

namespace Clinics.adminControls
{
    public partial class PRS : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public PRS()
        {
            InitializeComponent();
        }

        private void PRS_Load(object sender, EventArgs e)
        {
            try
            { 
            SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_PRS)+1,1) from PRS", con);
            con.Open();
            SqlDataReader Ra = cmd2.ExecuteReader();

            Ra.Read();
            text_ID.Text = Ra[0].ToString();
            Ra.Close();
            con.Close();



            con.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter("select username from tbl_User", con);
            DataSet ds = new DataSet();
            ds = new DataSet();
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "username";
            comboBox1.ValueMember = "username";
            comboBox1.SelectedIndex = -1;

            con.Close();



            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from PRS";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            da2.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            { 
            btn_add.Visible = false;
            btn_edit.Visible = true;
            btn_delete.Visible = true;
            btn_cancel.Visible = true;
            text_ID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                btn_add.Visible = true;
                btn_delete.Visible = false;
                btn_edit.Visible = false;
                text_ID.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                btn_cancel.Visible = false;




                SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_PRS)+1,1) from PRS", con);
                con.Open();
                SqlDataReader Ra = cmd2.ExecuteReader();

                Ra.Read();
                text_ID.Text = Ra[0].ToString();
                Ra.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            { 
            if (text_ID.Text == "")
            {
                MessageBox.Show("يرجى تحديد رقم العملية قبل الحذف", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            
            }
            else
            {
                    if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {


                        SqlCommand cmd2 = new SqlCommand("delete from PRS where ID_PRS=" + text_ID.Text + "", con);

                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from PRS";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        dataGridView1.DataSource = dt;

                        con.Close();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = -1;

                        MessageBox.Show("تم حذف نسبة الخصم بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            { 
            if (text_ID.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم العملية فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم الموظف فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                
                    SqlCommand cmd = new SqlCommand("update PRS set Name_PRS=@Name_PRS,PRS=@PRS,PRS_JD=@PRS_JD where ID_PRS=" + text_ID.Text.Trim() + "", con);

                    cmd.Parameters.Add(new SqlParameter("@Name_PRS", comboBox1.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@PRS", textBox1.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@PRS_JD", textBox2.Text.Trim()));



                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                    MessageBox.Show("تم تعديل بيانات الخصم بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    con.Open();
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select * from PRS";
                    cmd2.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(dt);
                    dataGridView1.DataSource = dt;

                    con.Close();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            { 
            if (text_ID.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم العملية فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم الموظف فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select ID_PRS from PRS where ID_PRS=@ID_PRS", con);
                    cmd21.Parameters.Add(new SqlParameter("@ID_PRS", text_ID.Text));
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
                        MessageBox.Show("رقم العملية موجود مسبقا ، لا يمكن إضافة العملية بنفس الرقم  " + text_ID.Text.Trim(), "تكرار البيانات رقم العملية موجود مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {

                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo_add_PRS";

                        cmd.Parameters.Add(new SqlParameter("@ID_PRS", text_ID.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@Name_PRS", comboBox1.SelectedValue));
                        cmd.Parameters.Add(new SqlParameter("@PRS", textBox2.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@PRS_JD", textBox1.Text.Trim()));




                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم إضافة نسبة الخصم المسموحة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        text_ID.Text = "";
                        textBox2.Text = "";
                        textBox1.Text = "";
                        comboBox1.SelectedIndex = -1;


                        SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_PRS)+1,1) from PRS", con);
                        con.Open();
                        SqlDataReader Ra = cmd2.ExecuteReader();

                        Ra.Read();
                        text_ID.Text = Ra[0].ToString();
                        Ra.Close();
                        con.Close();

                        con.Open();
                        SqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "select * from PRS";
                        cmd3.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
                        da2.Fill(dt);
                        dataGridView1.DataSource = dt;

                        con.Close();
                    }
            
            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void text_ID_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1009 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
    
}
