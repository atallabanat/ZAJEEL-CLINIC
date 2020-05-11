using Clinics.pharmacy_Control;
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

namespace Clinics.Pharmacy
{
    public partial class SelectPet : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        msgShow msg = new msgShow();
        string Name_pat;
        string Name_Measures;
        string number_Measures;
        string presnt_Measures;
        Boolean CloseForm=false;
        public SelectPet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Mesures ss = new Add_Mesures();
            ss.ShowDialog();
        }

        private void SelectPet_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select number_Measures,Name_Measures,presnt_Measures,Name_pat from Table_PAT order by Name_pat";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;                
            }
            catch
            {
                msg.Alert("Error 1 SelectPet ", Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void textBox_search_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select number_Measures,Name_Measures,Name_pat,presnt_Measures from Table_PAT  where   Name_Measures like @Name_Measures or Name_pat like @Name_pat ";                    
                    Cmd.Parameters.AddWithValue("@Name_Measures", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Name_pat", "%" + textBox_search.Text + "%");                    
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch
            {
                msg.Alert("Error 2 SelectPet ", Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ID_Orders.Text = dataGridView1.CurrentRow.Cells[Clm_number_Measures.Name].Value.ToString();
                textBox_Name_MU.Text = dataGridView1.CurrentRow.Cells[Clm_Name_Measures.Name].Value.ToString();
                textBox_Name_Pat.Text = dataGridView1.CurrentRow.Cells[Clm_Name_pat.Name].Value.ToString();
            }
            catch
            {
                textBox_ID_Orders.Text = string.Empty;
                textBox_Name_MU.Text = string.Empty;
                textBox_Name_Pat.Text = string.Empty;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                CloseForm = false;
                if (dataGridView1.CurrentRow.Cells[Clm_Name_pat.Name].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("عذرا لا يمكنك اختيار اسم مستفيد فارغ", "إدخال خاطئ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dataGridView1.CurrentRow.Cells[Clm_Name_Measures.Name].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("عذرا لا يمكنك اختيار اسم شركة تأمين فارغ", "إدخال خاطئ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dataGridView1.CurrentRow.Cells[Clm_number_Measures.Name].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("عذرا لا يمكنك اختيار اسم رقم بطاقة تأمين فارغ", "إدخال خاطئ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dataGridView1.CurrentRow.Cells[Clm_presnt_Measures.Name].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("عذرا لا يمكنك اختيار نسبة تحمل فارغة", "إدخال خاطئ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Name_pat = dataGridView1.CurrentRow.Cells[Clm_Name_pat.Name].Value.ToString();
                Name_Measures = dataGridView1.CurrentRow.Cells[Clm_Name_Measures.Name].Value.ToString();
                number_Measures = dataGridView1.CurrentRow.Cells[Clm_number_Measures.Name].Value.ToString();
                presnt_Measures = dataGridView1.CurrentRow.Cells[Clm_presnt_Measures.Name].Value.ToString();

                
                POS.pOS.Name_pat = Name_pat;
                POS.pOS.Name_Measures = Name_Measures;
                POS.pOS.number_Measures = number_Measures;
                POS.pOS.presnt_Measures = presnt_Measures;

                POS.pOS.textBox_Name_MU.Text = Name_Measures;
                POS.pOS.textBox_Name_Pat.Text = Name_pat;
                CloseForm = true;
                this.Close();
            }
            catch
            {
                msg.Alert("Error 3 SelectPet ", Form_Alert.enumType.Error);
                Name_pat = string.Empty;
                Name_Measures = string.Empty;
                number_Measures = string.Empty;
                presnt_Measures = string.Empty;

                POS.pOS.Name_pat = string.Empty;
                POS.pOS.Name_Measures = string.Empty;
                POS.pOS.number_Measures = string.Empty;
                POS.pOS.presnt_Measures = string.Empty;

                POS.pOS.textBox_Name_MU.Text = string.Empty;
                POS.pOS.textBox_Name_Pat.Text = string.Empty;
            }
        }

        private void SelectPet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(CloseForm==false)
            {
                POS.pOS.radioCash.Checked = true;
                POS.pOS.radioCash_Click(sender,e);

            }
        }
    }
}
