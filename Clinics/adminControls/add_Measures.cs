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

namespace Clinics.adminControls
{
    public partial class add_Measures : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public add_Measures()
        {
            InitializeComponent();
        }

        private void add_Measures_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_Measures)+1,1) from add_Measures", con);
                con.Open();
                SqlDataReader Ra = cmd2.ExecuteReader();

                Ra.Read();
                text_ID.Text = Ra[0].ToString();
                Ra.Close();
                con.Close();

                con.Open();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "dbo_select_Measures";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا"+ee.Message, "ERROR 1001 add_Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            { 
            if(text_ID.Text=="")
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم الاجراء فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            if (text_name.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم الاجراء فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            if (text_price.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل سعر الاجراء فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            else
            {

                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select ID_Measures from add_Measures where ID_Measures=@ID_Measures", con);
                    cmd21.Parameters.Add(new SqlParameter("@ID_Measures", text_ID.Text));
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
                        MessageBox.Show("رقم الاجراء موجود مسبقا ، لا يمكن إضافة إجراء بنفس الرقم  " + text_ID.Text.Trim(), "تكرار البيانات رقم الاجراء موجود مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo_add_Measures";

                        cmd.Parameters.Add(new SqlParameter("@ID_Measures", text_ID.Text.Trim()));
                        cmd.Parameters.Add("@Name_Measures", SqlDbType.NVarChar).Value = text_name.Text.Trim();
                        cmd.Parameters.Add(new SqlParameter("@Price_Measures", text_price.Text.Trim()));





                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم إضافة الاجراء بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        text_ID.Text = "";
                        text_name.Text = "";
                        text_price.Text = "";



                        SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_Measures)+1,1) from add_Measures", con);
                        con.Open();
                        SqlDataReader Ra = cmd2.ExecuteReader();

                        Ra.Read();
                        text_ID.Text = Ra[0].ToString();
                        Ra.Close();
                        con.Close();


                        con.Open();
                        var dataTable = new DataTable();
                        using (SqlCommand Cmd = con.CreateCommand())
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.CommandText = "dbo_select_Measures";
                            SqlDataAdapter da = new SqlDataAdapter(Cmd);
                            da.Fill(dataTable);


                        }
                        dataGridView1.DataSource = dataTable;
                        con.Close();

                    }
            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا"+ee.Message, "ERROR 1002 add_Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
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
                text_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                text_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                text_price.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا"+ee.Message, "ERROR 1003 add_Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            { 
            if (text_ID.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم الاجراء فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            if (text_name.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم الاجراء فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            if (text_price.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل سعر الاجراء فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
            }
                else
                {

                    SqlCommand cmd = new SqlCommand("update add_Measures set ID_Measures=@ID_Measures,Name_Measures=@Name_Measures,Price_Measures=@Price_Measures where ID_Measures=" + text_ID.Text.Trim() + "", con);

                    cmd.Parameters.Add(new SqlParameter("@ID_Measures", SqlDbType.Int)).Value = text_ID.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Name_Measures", SqlDbType.NVarChar)).Value = text_name.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Price_Measures", SqlDbType.Int)).Value = text_price.Text.Trim();



                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                    MessageBox.Show("تم تعديل بيانات الاجراء بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Open();
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "dbo_select_Measures";
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                    con.Close();
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا"+ee.Message, "ERROR 1004 add_Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            { 
            if (text_ID.Text == "")
            {
                MessageBox.Show("يرجى تحديد رقم الاجراء قبل الحذف", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            else
            {
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                   


                        SqlCommand cmd = new SqlCommand("delete from add_Measures where ID_Measures=" + text_ID.Text + "", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم حذف الاجراء بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Open();
                        var dataTable = new DataTable();
                        using (SqlCommand Cmd = con.CreateCommand())
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.CommandText = "dbo_select_Measures";
                            SqlDataAdapter da = new SqlDataAdapter(Cmd);
                            da.Fill(dataTable);


                        }
                        dataGridView1.DataSource = dataTable;
                        con.Close();

                        text_name.Text = "";
                        text_price.Text = "";
                   
                }
            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا"+ee.Message, "ERROR 1005 add_Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                btn_add.Visible = true;
                btn_delete.Visible = false;
                btn_edit.Visible = false;
                text_ID.Text = "";
                text_name.Text = "";
                text_price.Text = "";
                btn_cancel.Visible = false;


                SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_Measures)+1,1) from add_Measures", con);
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا"+ee.Message, "ERROR 1006 add_Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا"+ee.Message, "ERROR 1007 add_Measures", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
