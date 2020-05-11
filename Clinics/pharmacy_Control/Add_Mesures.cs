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
        msgShow msg = new msgShow();
        string ID_Pat;
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
                text_ID.Text = string.Empty;
                text_name.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                btn_cancel.Visible = false;
            }
            catch 
            {

            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (text_ID.Text == string.Empty)
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم بطاقة التأمين فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (text_name.Text == string.Empty)
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم الشركة فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("يرجى عدم ترك حقل نسبة التحمل فارغة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم المستفيد فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
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
                if (count == 1)
                {
                    MessageBox.Show("اسم المستفيد موجود مسبقا ، لا يمكن إضافة تأمين بنفس الأسم  " + textBox1.Text.Trim(), "تكرار البيانات اسم المستفيد موجود مسبقا !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch
            {
                msg.Alert("ERROR M-3 Add_Mesures Search Name Pat", Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO Table_PAT
                         (ID_pat,number_Measures, Name_Measures, presnt_Measures, Name_pat)
                            VALUES((select isnull(max(ID_pat+1),1) as ID_pat from Table_PAT),@number_Measures, @Name_Measures, @presnt_Measures, @Name_pat)";

                cmd.Parameters.Add(new SqlParameter("@number_Measures", text_ID.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@Name_Measures", text_name.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@presnt_Measures", textBox2.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@Name_pat", textBox1.Text.Trim()));
                cmd.ExecuteNonQuery();                   

                MessageBox.Show("تم إضافة التأمين بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearScreen();
            }
            catch
            {
                msg.Alert("ERROR M-2 Add_Mesures ADD Data", Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
                LoadDataGrid();
            }
        }
        private void LoadDataGrid()
        {
            try
            {
                con.Open();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select ID_Pat,number_Measures,Name_Measures,presnt_Measures,Name_pat from Table_PAT order by Name_pat";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);
                }
                dataGridView1.DataSource = dataTable;
            }
            catch
            {
                msg.Alert("ERROR M-1 Add_Mesures Load Data", Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }

        }
        private void ClearScreen()
        {
            text_ID.Text = string.Empty;
            text_name.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
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
            catch
            {
                
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {

            if (text_ID.Text == string.Empty)
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم بطاقة التأمين فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (text_name.Text == string.Empty)
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم الشركة فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("يرجى عدم ترك حقل نسبة التحمل فارغة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم المستفيد فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                try
                {
                    if(ID_Pat==string.Empty)
                    {
                        MessageBox.Show("يرجى تحديد المريض من القائمة قبل الحذف", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Table_PAT set number_Measures=@number_Measures,Name_Measures=@Name_Measures,presnt_Measures=@presnt_Measures,Name_pat=@Name_pat where ID_Pat=@ID_Pat", con);
                    cmd.Parameters.Add(new SqlParameter("@number_Measures", text_ID.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@Name_Measures", text_name.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@presnt_Measures", textBox2.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@Name_pat", textBox1.Text.Trim()));
                    cmd.Parameters.AddWithValue("@ID_Pat", ID_Pat);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم تعديل بيانات التأمين بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    msg.Alert("ERROR M-4 Add_Mesures Edit Data", Form_Alert.enumType.Error);
                }
                finally
                {
                    con.Close();
                    LoadDataGrid();
                    ClearScreen();
                    btn_cancel_Click(sender, e);
                }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            if (ID_Pat == string.Empty)
            {
                MessageBox.Show("يرجى تحديد المريض من القائمة قبل الحذف", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from Table_PAT where ID_Pat=@ID_Pat", con);
                    cmd.Parameters.AddWithValue("@ID_Pat",ID_Pat);
                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("تم حذف التأمين بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                msg.Alert("ERROR M-5 Add_Mesures Delete Data", Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
                LoadDataGrid();
                ClearScreen();
                btn_cancel_Click(sender, e);
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
                text_ID.Text = dataGridView1.CurrentRow.Cells[Clm_number_Measures.Name].Value.ToString();
                text_name.Text = dataGridView1.CurrentRow.Cells[clm_Name_Measures.Name].Value.ToString();
                textBox1.Text= dataGridView1.CurrentRow.Cells[clm_Name_pat.Name].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[clm_presnt_Measures.Name].Value.ToString();
                ID_Pat= dataGridView1.CurrentRow.Cells[clm_ID_Pat.Name].Value.ToString();
            }
            catch
            {

            }

        }

        private void Add_Mesures_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
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
            try
            {
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select ID_Pat,number_Measures,Name_Measures,Name_pat,presnt_Measures,phone_pat from Table_PAT  where    number_Measures like @number_Measures or Name_Measures like @Name_Measures or Name_pat like @Name_pat or phone_pat like @phone_pat ";
                    Cmd.Parameters.AddWithValue("@number_Measures", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Name_Measures", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Name_pat", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@phone_pat", "%" + textBox_search.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;

            }
            catch
            {
                msg.Alert("ERROR M-6 Add_Mesures Search Load Data", Form_Alert.enumType.Error);
            }
            finally
            {

            }
        }
    }
}
