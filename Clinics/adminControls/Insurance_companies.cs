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
    public partial class Insurance_companies : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public Insurance_companies()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                btn_add.Visible = true;
                btn_delete.Visible = false;
                btn_edit.Visible = false;
                text_ID.Text = "";
                text_name.Text = "";
                btn_cancel.Visible = false;

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Insurance_companies", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Insurance_companies", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_ID.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل رقم الشركة فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (text_name.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل اسم الشركة فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select ID_insurance from insurance where ID_insurance=@ID_insurance", con);
                    cmd21.Parameters.Add(new SqlParameter("@ID_insurance", text_ID.Text));
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
                        MessageBox.Show("رقم الشركة موجود مسبقا ، لا يمكن إضافة شركة بنفس الرقم  " + text_ID.Text.Trim(), "تكرار البيانات رقم الشركة موجود مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {


                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo_insurancee";

                        cmd.Parameters.Add(new SqlParameter("@ID_insurance", text_ID.Text.Trim()));
                        cmd.Parameters.Add("@Name_insurance", SqlDbType.NVarChar).Value = text_name.Text.Trim();





                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم إضافة الشركة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        text_ID.Text = "";
                        text_name.Text = "";



                        con.Open();
                        var dataTable = new DataTable();
                        using (SqlCommand Cmd = con.CreateCommand())
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.CommandText = "dbo_select_insurance";
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Insurance_companies", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Insurance_companies_Load(object sender, EventArgs e)
        {
            try
            { 
            con.Open();
            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "dbo_select_insurance";
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 Insurance_companies", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_ID.Text == "")
                {
                    MessageBox.Show("يرجى تحديد رقم المورد قبل الحذف", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                else
                {
                    if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {


                        SqlCommand cmd = new SqlCommand("delete from insurance where ID_insurance=" + text_ID.Text + "", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم حذف الشركة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Open();
                        var dataTable = new DataTable();
                        using (SqlCommand Cmd = con.CreateCommand())
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.CommandText = "dbo_select_insurance";
                            SqlDataAdapter da = new SqlDataAdapter(Cmd);
                            da.Fill(dataTable);


                        }
                        dataGridView1.DataSource = dataTable;
                        con.Close();
                        
                        text_name.Text = "";

                    }
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 Insurance_companies", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_ID.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل رقم الشركة فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (text_name.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل اسم الشركة فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("update insurance set ID_insurance=@ID_insurance,Name_insurance=@Name_insurance where ID_insurance=" + text_ID.Text.Trim() + "", con);

                    cmd.Parameters.Add(new SqlParameter("@ID_insurance", SqlDbType.Int)).Value = text_ID.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Name_insurance", SqlDbType.NVarChar)).Value = text_name.Text.Trim();



                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                    MessageBox.Show("تم تعديل بيانات الشركة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Open();
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "dbo_select_insurance";
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 Insurance_companies", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 Insurance_companies", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}