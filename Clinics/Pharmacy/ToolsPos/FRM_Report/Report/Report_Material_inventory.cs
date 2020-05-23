using Clinics.Class;
using Microsoft.Reporting.WinForms;
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

namespace Clinics.Pharmacy.ToolsPos.FRM_Report.Report
{
    public partial class Report_Material_inventory : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        public Report_Material_inventory()
        {
            InitializeComponent();
        }

        private void Report_Material_inventory_Load(object sender, EventArgs e)
        {
            try
            {
                ReportParameterCollection reportParameters = new ReportParameterCollection();

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                DataSet1 m = new DataSet1();
                cmd.CommandType = CommandType.Text;
                if (FRM_Report_Material_inventory.fRM_Report_Material_.radio_All_Item.Checked == true)
                {
                    cmd.CommandText = "select A.* from (SELECT     R_Barcode,R_ItemName,sum(case when Kind = 1  then R_Qty+R_Bouns else 0 end) - sum(case when Kind = 2 then R_Qty else 0 end) as R_Qty,R_PriceSales ,R_PriceParchase,FORMAT (R_DateItem, 'dd-MM-yyyy') as R_DateItem , R_Tax FROM   " + D.DataPharmacy + "i2_trans   group by R_Barcode,R_ItemName,R_PriceSales, R_PriceParchase,R_DateItem,R_Tax)A where A.R_Qty>0 ";

                }
                else if (FRM_Report_Material_inventory.fRM_Report_Material_.radio_ItemNo.Checked == true)
                {
                    cmd.CommandText = "select A.* from (SELECT     R_Barcode,R_ItemName,sum(case when Kind = 1  then R_Qty+R_Bouns else 0 end) - sum(case when Kind = 2 then R_Qty else 0 end) as R_Qty,R_PriceSales ,R_PriceParchase,FORMAT (R_DateItem, 'dd-MM-yyyy') as R_DateItem , R_Tax FROM   "+D.DataPharmacy+"i2_trans   group by R_Barcode,R_ItemName,R_PriceSales, R_PriceParchase,R_DateItem,R_Tax)A where A.R_Qty>0 and A.R_Barcode=@R_Barcode";
                    cmd.Parameters.AddWithValue("@R_Barcode", FRM_Report_Material_inventory.fRM_Report_Material_.textBox_Item_No.Text);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(m, m.Tables[0].TableName);

                ReportDataSource reportDataSource = new ReportDataSource("DS_i2", m.Tables[0]);



                //--------------------------------------------------------------------------------------------------------


                //SP_PictureCompany ms2 = new SP_PictureCompany();
                DataSet1 m2 = new DataSet1();
                con.Close();
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();

                cmd2.CommandType = CommandType.Text;

                cmd2.CommandText = "select img from "+D.DataPharmacy+"Comf where id=@ID";
                cmd2.Parameters.AddWithValue("@ID", 1);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(m2, m2.Tables[0].TableName);

                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                ReportDataSource reportDataSource2 = new ReportDataSource("DS_img", m2.Tables[0]);


                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);

                this.reportViewer1.RefreshReport();
                con.Close();
            }
            catch (Exception ex)

            {

            }

        }
    }
}
