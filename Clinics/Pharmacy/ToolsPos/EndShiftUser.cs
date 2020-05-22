using Clinics.Class;
using Clinics.Grid;
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

namespace Clinics.Pharmacy.ToolsPos
{
    public partial class EndShiftUser : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        msgShow msg = new msgShow();
        ClsHistory history = new ClsHistory();
        DocType docType = new DocType();
        ConvertDate convertDate = new ConvertDate();
        public static EndShiftUser shiftUser;
        string sqlSelect;
        public EndShiftUser()
        {
            shiftUser = this;
            InitializeComponent();
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    btn_View_Emp_No.Enabled = false;
                    textBox_Emp_No.Enabled = false;
                    textBox_Emp_Name.Enabled = false;
                }
                else
                {
                    btn_View_Emp_No.Enabled = true;
                    textBox_Emp_No.Enabled = true;
                    textBox_Emp_Name.Enabled = true;
                }
            }
            catch
            {

            }            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked == true)
                {
                    dateTime_From_Date.Enabled = false;
                    dateTime_To_Date.Enabled = false;                   
                }
                else
                {
                    dateTime_From_Date.Enabled = true;
                    dateTime_To_Date.Enabled = true;
                }
            }
            catch
            {

            }

        }

        private void btn_View_Emp_No_Click(object sender, EventArgs e)
        {
            try
            {
                Grid_Employee grid = new Grid_Employee();
                grid.ShowDialog();
            }
            catch
            {

            }
        }
        private void Select()
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    sqlSelect = "declare @cash numeric(18,3),@AP numeric(18,3),@Credit numeric(18,3),@IN_INC numeric(18,3),@Out_INC numeric(18,3) set @cash=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=0 and Odate BETWEEN @Odate1 and @Odate2)  set @AP=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=1 and Odate BETWEEN @Odate1 and @Odate2) set @Credit=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=2 and Odate BETWEEN @Odate1 and @Odate2) set @IN_INC=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=3 and Odate BETWEEN @Odate1 and @Odate2) set @Out_INC=(select isnull(sum(TotalDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=3 and Odate BETWEEN @Odate1 and @Odate2) select @cash as Cash ,@AP as AP , @Credit as Credit,@IN_INC as IN_INC , @Out_INC as Out_INC";

                    if (checkBox2.Checked == true)
                    {
                        sqlSelect = "declare @cash numeric(18,3),@AP numeric(18,3),@Credit numeric(18,3),@IN_INC numeric(18,3),@Out_INC numeric(18,3) set @cash=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=0 and Odate BETWEEN (select Format(GETDATE(),'yyyy-MM-dd')) and (select Format(GETDATE(),'yyyy-MM-dd')))  set @AP=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=1 and Odate BETWEEN (select Format(GETDATE(),'yyyy-MM-dd')) and (select Format(GETDATE(),'yyyy-MM-dd'))) set @Credit=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=2 and Odate BETWEEN (select Format(GETDATE(),'yyyy-MM-dd')) and (select Format(GETDATE(),'yyyy-MM-dd'))) set @IN_INC=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=3 and Odate BETWEEN (select Format(GETDATE(),'yyyy-MM-dd')) and (select Format(GETDATE(),'yyyy-MM-dd'))) set @Out_INC=(select isnull(sum(TotalDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=3 and Odate BETWEEN (select Format(GETDATE(),'yyyy-MM-dd')) and (select Format(GETDATE(),'yyyy-MM-dd'))) select @cash as Cash ,@AP as AP , @Credit as Credit,@IN_INC as IN_INC , @Out_INC as Out_INC";
                    }
                }
                else
                {
                    sqlSelect = "declare @cash numeric(18,3),@AP numeric(18,3),@Credit numeric(18,3),@IN_INC numeric(18,3),@Out_INC numeric(18,3) set @cash=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=0 and Odate BETWEEN @Odate1 and @Odate2 and ID_User=@UserID)  set @AP=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=1 and Odate BETWEEN @Odate1 and @Odate2 and ID_User=@UserID) set @Credit=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=2 and Odate BETWEEN @Odate1 and @Odate2 and ID_User=@UserID) set @IN_INC=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=3 and Odate BETWEEN @Odate1 and @Odate2 and ID_User=@UserID) set @Out_INC=(select isnull(sum(TotalDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=3 and Odate BETWEEN @Odate1 and @Odate2 and ID_User=@UserID) select @cash as Cash ,@AP as AP , @Credit as Credit,@IN_INC as IN_INC , @Out_INC as Out_INC";
                    if (checkBox2.Checked == true)
                    {
                        sqlSelect = "declare @cash numeric(18,3),@AP numeric(18,3),@Credit numeric(18,3),@IN_INC numeric(18,3),@Out_INC numeric(18,3) set @cash=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=0 and Odate BETWEEN (select Format(GETDATE(),'yyyy-MM-dd')) and (select Format(GETDATE(),'yyyy-MM-dd')) and ID_User=@UserID)  set @AP=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=1 and Odate BETWEEN (select Format(GETDATE(),'yyyy-MM-dd')) and (select Format(GETDATE(),'yyyy-MM-dd')) and ID_User=@UserID) set @Credit=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=2 and Odate BETWEEN (select Format(GETDATE(),'yyyy-MM-dd')) and (select Format(GETDATE(),'yyyy-MM-dd')) and ID_User=@UserID) set @IN_INC=(select isnull(sum(TotalAfterDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=3 and Odate BETWEEN (select Format(GETDATE(),'yyyy-MM-dd')) and (select Format(GETDATE(),'yyyy-MM-dd')) and ID_User=@UserID) set @Out_INC=(select isnull(sum(TotalDiscount),0)  from " + D.DataPharmacy + "i2_Trans where Screen_Code=5 and status_Order=3 and Odate BETWEEN (select Format(GETDATE(),'yyyy-MM-dd')) and (select Format(GETDATE(),'yyyy-MM-dd')) and ID_User=@UserID) select @cash as Cash ,@AP as AP , @Credit as Credit,@IN_INC as IN_INC , @Out_INC as Out_INC";
                    }
                }
            }
            catch
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Select();
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                if(checkBox1.Checked==false)
                {
                    cmd.Parameters.AddWithValue("@UserID", textBox_Emp_No.Text);
                }
                if(checkBox2.Checked==false)
                {
                    cmd.Parameters.AddWithValue("@Odate1",convertDate.TODate(dateTime_From_Date.Text));
                    cmd.Parameters.AddWithValue("@Odate2", convertDate.TODate(dateTime_To_Date.Text));
                }                
                SqlDataReader dr;                
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Cash.Text = dr["cash"].ToString();
                    textBox_AP.Text = dr["AP"].ToString();
                    textBox_Credit.Text = dr["Credit"].ToString();
                    textBox_IN_Inc.Text = dr["IN_INC"].ToString();
                    textBox_Out_Inc.Text = dr["Out_INC"].ToString();
                }
                dr.Close();                
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
    }
}
