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

namespace Clinics.pharmacy_Control
{
    public partial class Add_Mesures : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public Add_Mesures()
        {
            this.KeyPreview = true;
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
                textBox1.Text = "";
                textBox2.Text = "";
                btn_cancel.Visible = false;





            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Add_mesures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            { 
            if (text_ID.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم بطاقة التأمين فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (text_name.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم الشركة فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل نسبة التحمل فارغة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                if (textBox1.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل اسم المستفيد فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {




                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select Name_pat from Table_PAT where Name_pat=@Name_pat", con);
                    cmd21.Parameters.Add(new SqlParameter("@Name_pat", textBox1.Text.Trim()));
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
                        MessageBox.Show("اسم المستفيد موجود مسبقا ، لا يمكن إضافة تأمين بنفس الأسم  " + textBox1.Text.Trim(), "تكرار البيانات اسم المستفيد موجود مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {












                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo_insertAdd_Mesures";

                        cmd.Parameters.Add(new SqlParameter("@number_Measures", text_ID.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@Name_Measures", text_name.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@presnt_Measures", textBox2.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@Name_pat", textBox1.Text.Trim()));





                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم إضافة التأمين بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        text_ID.Text = "";
                        text_name.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";




                        con.Open();
                        var dataTable = new DataTable();
                        using (SqlCommand Cmd = con.CreateCommand())
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.CommandText = "dboSelect_insertAdd_Mesures";
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 Add_mesures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 Add_mesures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            { 
            if (text_ID.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم بطاقة التأمين فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (text_name.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم الشركة فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل نسبة التحمل فارغة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم المستفيد فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {

               
                    SqlCommand cmd = new SqlCommand("update Table_PAT set number_Measures=@number_Measures,Name_Measures=@Name_Measures,presnt_Measures=@presnt_Measures,Name_pat=@Name_pat where number_Measures=@number_Measures1 and Name_pat=@Name_pat1", con);

                    cmd.Parameters.Add(new SqlParameter("@number_Measures1", textBox4.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@Name_pat1", textBox3.Text.Trim()));


                    cmd.Parameters.Add(new SqlParameter("@number_Measures", text_ID.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@Name_Measures", text_name.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@presnt_Measures", textBox2.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@Name_pat", textBox1.Text.Trim()));



                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                    MessageBox.Show("تم تعديل بيانات التأمين بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    con.Open();
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "dboSelect_insertAdd_Mesures";
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 Add_mesures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            { 
            if (text_ID.Text == "")
            {
                MessageBox.Show("يرجى تحديد رقم بطاقة التأمين قبل الحذف", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
                
                    if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {


                        SqlCommand cmd = new SqlCommand("delete from Table_PAT where number_Measures=" + text_ID.Text + "", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();




                        con.Open();
                        var dataTable = new DataTable();
                        using (SqlCommand Cmd = con.CreateCommand())
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.CommandText = "dboSelect_insertAdd_Mesures";
                            SqlDataAdapter da = new SqlDataAdapter(Cmd);
                            da.Fill(dataTable);


                        }
                        dataGridView1.DataSource = dataTable;
                        con.Close();


                        text_name.Text = "";

                        MessageBox.Show("تم حذف التأمين بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


           

            }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1005 Add_mesures", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            textBox1.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 Add_mesures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Add_Mesures_Load(object sender, EventArgs e)
        {
            try
            { 
            con.Open();
            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "dboSelect_insertAdd_Mesures";
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1007 Add_mesures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Add_Mesures_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select number_Measures,Name_Measures,Name_pat,presnt_Measures,phone_pat from Table_PAT  where    number_Measures like @number_Measures or Name_Measures like @Name_Measures or Name_pat like @Name_pat or phone_pat like @phone_pat ";
                Cmd.Parameters.AddWithValue("@number_Measures", "%" + textBox_search.Text + "%");
                Cmd.Parameters.AddWithValue("@Name_Measures", "%" + textBox_search.Text + "%");
                Cmd.Parameters.AddWithValue("@Name_pat", "%" + textBox_search.Text + "%");
                Cmd.Parameters.AddWithValue("@phone_pat", "%" + textBox_search.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;
        }
    }
}
