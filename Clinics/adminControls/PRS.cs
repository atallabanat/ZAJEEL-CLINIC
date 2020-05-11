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
using Clinics.Class;

namespace Clinics.adminControls
{
    public partial class PRS : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        msgShow msg = new msgShow();
        //public Virable
        string ID;
        int NewRow = 0;
        public PRS()
        {
            InitializeComponent();
        }

        private void PRS_Load(object sender, EventArgs e)
        {
            try
            {
                MaxOrder();
                btn_delete.Visible = false;
                btn_cancel.Visible = false;
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da = new SqlDataAdapter("select ID,username from tbl_User", con);
                    DataSet ds = new DataSet();
                    ds = new DataSet();
                    da.Fill(ds);
                    comboBox1.DataSource = ds.Tables[0];
                    comboBox1.DisplayMember = "username";
                    comboBox1.ValueMember = "ID";
                    comboBox1.SelectedIndex = -1;
                }
                catch
                {

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
                    cmd.CommandText = "select * from "+D.DataPharmacy+"PRS";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    da2.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch
                {

                }
                finally
                {
                    con.Close();
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MaxOrder()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(ID)+1),1) as max from " + D.DataPharmacy + "PRS ", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    ID = dr["max"].ToString();
                }
            }
            catch (Exception ex)
            {
                msg.Alert("حدث خلل بسيط" + ex.Message, Form_Alert.enumType.Error);
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
                btn_delete.Visible = true;
                btn_cancel.Visible = true;
                ID = dataGridView1.CurrentRow.Cells[ClmID.Name].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[clmIDUser.Name].Value.ToString();
                textBox1.Text= dataGridView1.CurrentRow.Cells[ClmPRS_JD.Name].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[Clm_PRS_Precent.Name].Value.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                btn_delete.Visible = false;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                comboBox1.SelectedIndex = -1;
                btn_cancel.Visible = false;
                MaxOrder();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            { 
            if (ID == string.Empty)
            {
                msg.Alert("يرجى تحديد رقم العملية قبل الحذف", Form_Alert.enumType.Warning);
                return;
            
            }
            else
            {
                    if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd2 = new SqlCommand("delete from " + D.DataPharmacy + "PRS where ID=@ID", con);
                            cmd2.Parameters.AddWithValue("@ID", ID);                            
                            cmd2.ExecuteNonQuery();                            

                            msg.Alert("تم حذف نسبة الخصم بنجاح",Form_Alert.enumType.Success);
                        }
                        catch
                        {

                        }
                        finally
                        {
                            con.Close();
                            ClearScreen();
                            PRS_Load(sender, e);
                        }
                        
                    }

            }
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1004 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            { 
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("يرجى عدم ترك حقل اسم الموظف فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("يرجى عدم ترك حقل نسبة الخصم بالدينار فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBox2.Text == string.Empty)
                {
                    MessageBox.Show("يرجى عدم ترك حقل نسبة الخصم بالنسبة فارغ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //----------------------------------------------تفقيد الفاتورة موجودة في الداتا--------------------------------------------------------------
                try
                {
                    con.Open();
                    SqlCommand cmd22 = new SqlCommand("select ID from " + D.DataPharmacy + "PRS where ID=@ID", con);
                    cmd22.Parameters.Add(new SqlParameter("@ID", ID));                    
                    SqlDataReader dr2;
                    dr2 = cmd22.ExecuteReader();

                    if (dr2.Read())
                    {
                        NewRow = 1;

                    }
                    else
                    {
                        NewRow = 0;
                    }

                }
                catch (Exception ex)
                {
                    msg.Alert("حدث خلل بسيط" + ex.Message, Form_Alert.enumType.Error);
                }
                finally
                {
                    con.Close();
                }
                //----------------------------------------------------------------------------------------------------------------
                try
                {
                    if(NewRow==0)
                    {

                        if(ValdUser()==1)
                        {
                            msg.Alert("عذرا لا يمكن إضافة أكثر من نسب خصم لنفس المستخدم",Form_Alert.enumType.Warning);
                            return;
                        }
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO "+D.DataPharmacy+"PRS (ID, IDUser, NameUser, PRS_JD, PRS_Precent) VALUES  (@ID, @IDUser, @NameUser, @PRS_JD, @PRS_Precent)";
                        cmd.Parameters.AddWithValue("@ID",ID);
                        cmd.Parameters.AddWithValue("@IDUser",comboBox1.SelectedValue);
                        cmd.Parameters.AddWithValue("@NameUser",comboBox1.Text);
                        cmd.Parameters.AddWithValue("@PRS_JD",textBox1.Text);
                        cmd.Parameters.AddWithValue("@PRS_Precent", textBox2.Text);
                        cmd.ExecuteNonQuery();
                        msg.Alert("تم إضافة نسبة الخصم المسموحة بنجاح",Form_Alert.enumType.Success);

                    }
                    if (NewRow==1)
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE       "+D.DataPharmacy+"PRS SET  IDUser =@IDUser, NameUser =@NameUser, PRS_JD =@PRS_JD, PRS_Precent =@PRS_Precent where ID=@ID";
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@IDUser", comboBox1.SelectedValue);
                        cmd.Parameters.AddWithValue("@NameUser", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@PRS_JD", textBox1.Text);
                        cmd.Parameters.AddWithValue("@PRS_Precent", textBox2.Text);
                        cmd.ExecuteNonQuery();
                        msg.Alert("تم تعديل نسبة الخصم المسموحة بنجاح", Form_Alert.enumType.Success);
                    }
                }
                catch
                {

                }
                finally
                {
                    con.Close();
                    ClearScreen();
                    PRS_Load(sender,e);
                }
                              
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1006 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private int ValdUser()
        {
            //----------------------------------------------تفقيد الفاتورة موجودة في الداتا--------------------------------------------------------------
            try
            {
                con.Open();
                SqlCommand cmd22 = new SqlCommand("select ID from " + D.DataPharmacy + "PRS where IDUser=@IDUser", con);
                cmd22.Parameters.Add(new SqlParameter("@IDUser", comboBox1.SelectedValue));
                SqlDataReader dr2;
                dr2 = cmd22.ExecuteReader();

                if (dr2.Read())
                {
                    return 1;

                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {                
                msg.Alert("حدث خلل بسيط" + ex.Message, Form_Alert.enumType.Error);
                return 1;
            }
            finally
            {
                con.Close();
            }
            //----------------------------------------------------------------------------------------------------------------
        }
        private void ClearScreen()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;            
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1008 PRS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
