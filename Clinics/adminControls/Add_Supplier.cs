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
    public partial class Add_Supplier : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        msgShow msg = new msgShow();

        public Add_Supplier()
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
                  text_ID.Text = string.Empty;
                   text_name.Text = string.Empty;
                  btn_cancel.Visible = false;

            
                con.Open();
                SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_Supplier)+1,1) from add_Supplier", con);
                SqlDataReader Ra = cmd2.ExecuteReader();

                 Ra.Read();
                 text_ID.Text = Ra[0].ToString();
                 Ra.Close();                 
            }
            catch (Exception ee)
            {                
                msg.Alert("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا"+ee.Message,Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            { 
            if (text_ID.Text == string.Empty)
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم المورد فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (text_name.Text == string.Empty)
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم المورد فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select ID_Supplier from add_Supplier where ID_Supplier=@ID_Supplier", con);
                    cmd21.Parameters.Add(new SqlParameter("@ID_Supplier", text_ID.Text));
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
                        MessageBox.Show("رقم المورد موجود مسبقا ، لا يمكن إضافة مورد بنفس الرقم  " + text_ID.Text.Trim(), "تكرار البيانات رقم المورد موجود مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {


                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo_add_Supplier";

                        cmd.Parameters.Add(new SqlParameter("@ID_Supplier", text_ID.Text.Trim()));
                        cmd.Parameters.Add("@Name_Supplier", SqlDbType.NVarChar).Value = text_name.Text.Trim();





                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم إضافة المورد بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        text_ID.Text = "";
                        text_name.Text = "";



                        SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_Supplier)+1,1) from add_Supplier", con);
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
                            Cmd.CommandText = "dbo_select_add_Supplier";
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" +ee.Message, "ERROR 1002 Add_Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_ID.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل رقم المورد فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
                if (text_name.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل اسم المورد فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("update add_Supplier set ID_Supplier=@ID_Supplier,Name_Supplier=@Name_Supplier where ID_Supplier=" + text_ID.Text.Trim() + "", con);

                    cmd.Parameters.Add(new SqlParameter("@ID_Supplier", SqlDbType.Int)).Value = text_ID.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@Name_Supplier", SqlDbType.NVarChar)).Value = text_name.Text.Trim();



                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                    MessageBox.Show("تم تعديل بيانات المورد بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Open();
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "dbo_select_add_Supplier";
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Add_Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                   

                        SqlCommand cmd = new SqlCommand("delete from add_Supplier where ID_Supplier=" + text_ID.Text + "", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم حذف المورد بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Open();
                        var dataTable = new DataTable();
                        using (SqlCommand Cmd = con.CreateCommand())
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.CommandText = "dbo_select_add_Supplier";
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 Add_Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 Add_Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 Add_Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Add_Supplier_Load(object sender, EventArgs e)
        {
            try
            { 
            SqlCommand cmd2 = new SqlCommand("select ISNULL (MAX (ID_Supplier)+1,1) from add_Supplier", con);
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
                Cmd.CommandText = "dbo_select_add_Supplier";
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 Add_Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
