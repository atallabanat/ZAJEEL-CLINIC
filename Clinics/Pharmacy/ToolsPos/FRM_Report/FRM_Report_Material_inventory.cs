using Clinics.Class;
using Clinics.Grid;
using Clinics.Pharmacy.ToolsPos.FRM_Report.Report;
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

namespace Clinics.Pharmacy.ToolsPos.FRM_Report
{
    public partial class FRM_Report_Material_inventory : Form
    {
        public static FRM_Report_Material_inventory fRM_Report_Material_;
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        msgShow msg = new msgShow();
        OthersDataBase D = new OthersDataBase();
        public FRM_Report_Material_inventory()
        {
            fRM_Report_Material_ = this;
            InitializeComponent();
        }

        private void FRM_Report_Material_inventory_Load(object sender, EventArgs e)
        {

        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            try
            {
                Grid_Item.SCR_FRM_Report_Material_inventory = true;
                Grid_Item grid_Item = new Grid_Item();
                grid_Item.ShowDialog();
                Grid_Item.SCR_FRM_Report_Material_inventory = false;
            }
            catch
            {

            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                Report_Material_inventory report = new Report_Material_inventory();
                report.Show();
            }
            catch
            {

            }
        }

        private void radio_ItemNo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio_All_Item.Checked == true)
                {
                    textBox_Item_No.Enabled = false;
                    textBox_Item_Name.Enabled = false;
                    btn_Item.Enabled = false;
                }
                else
                {
                    textBox_Item_No.Enabled = true;
                    textBox_Item_Name.Enabled = true;
                    btn_Item.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void radio_All_Item_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio_All_Item.Checked == true)
                {
                    textBox_Item_No.Enabled = false;
                    textBox_Item_Name.Enabled = false;
                    btn_Item.Enabled = false;
                }
                else
                {
                    textBox_Item_No.Enabled = true;
                    textBox_Item_Name.Enabled = true;
                    btn_Item.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void textBox_Item_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Item_No.Text != string.Empty)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("select Code,ItemName from " + D.DataPharmacy + "Drugs where Code=@Code", con);
                            cmd.Parameters.Add(new SqlParameter("@Code", textBox_Item_No.Text));
                            con.Open();
                            SqlDataReader Ra = cmd.ExecuteReader();

                            if (Ra.Read())
                            {
                                textBox_Item_Name.Text = Ra["ItemName"].ToString();
                            }
                            else
                            {
                                msg.Alert("لا يوجد مادة بهذا الرمز", Form_Alert.enumType.Warning);
                                textBox_Item_No.Text = string.Empty;
                                textBox_Item_Name.Text = string.Empty;
                                textBox_Item_No.Focus();
                            }
                            Ra.Close();


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

                }

            }
            catch (Exception ee)
            {
                msg.Alert("حدث خلل بسيط" + ee.Message, Form_Alert.enumType.Error);
            }
        }
    }
}
