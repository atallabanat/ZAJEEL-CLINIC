using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinics.UserControls;
using Microsoft.Reporting.WinForms;
namespace Clinics
{
    public partial class saqwe : Form
    {
        public saqwe()
        {
            InitializeComponent();
        }

        private void saqwe_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = Properties.Resources.s2;
                Image newimage = bmp;
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                //----------------------------------------------------------------------------------------------------------------------------

                reportParameters.Add(new ReportParameter("number", quary_add_file_pat.qq.textBox_Number.Text));
                reportParameters.Add(new ReportParameter("Name", quary_add_file_pat.qq.textBox_Name.Text));
                reportParameters.Add(new ReportParameter("age", quary_add_file_pat.qq.textbox_age.Text));
                reportParameters.Add(new ReportParameter("phone1", quary_add_file_pat.qq.textbox_phone.Text));
                reportParameters.Add(new ReportParameter("end_Date", quary_add_file_pat.qq.textbox_enD_Date.Text));                
                reportParameters.Add(new ReportParameter("Name_Measures", quary_add_file_pat.qq.text_Measures.Text));
                reportParameters.Add(new ReportParameter("presnt_Measures", quary_add_file_pat.qq.text_presnt_Measures.Text));
                reportParameters.Add(new ReportParameter("presnt_Doc", quary_add_file_pat.qq.text_presnt_Doc.Text));
                reportParameters.Add(new ReportParameter("presnt_MM", quary_add_file_pat.qq.text_presnt_MM.Text));
                reportParameters.Add(new ReportParameter("number_Measures", quary_add_file_pat.qq.text_number_Measures.Text));
                reportParameters.Add(new ReportParameter("Adress", quary_add_file_pat.qq.text_address.Text));
                reportParameters.Add(new ReportParameter("city", quary_add_file_pat.qq.text_city.Text));
                reportParameters.Add(new ReportParameter("cuntrey", quary_add_file_pat.qq.textBox_cuntrey.Text));
                reportParameters.Add(new ReportParameter("str", quary_add_file_pat.qq.textBox_str.Text));
                reportParameters.Add(new ReportParameter("NFamiley", quary_add_file_pat.qq.text_Nfamile.Text));
                reportParameters.Add(new ReportParameter("Nwife", quary_add_file_pat.qq.text_Nwife.Text));
                reportParameters.Add(new ReportParameter("wife1", quary_add_file_pat.qq.textBox_wife1.Text));
                reportParameters.Add(new ReportParameter("wife2", quary_add_file_pat.qq.textBox_wife2.Text));
                reportParameters.Add(new ReportParameter("wife3", quary_add_file_pat.qq.textBox_wife3.Text));
                reportParameters.Add(new ReportParameter("wife4", quary_add_file_pat.qq.textBox_wife4.Text));
                reportParameters.Add(new ReportParameter("Nch", quary_add_file_pat.qq.text_Nch.Text));
                reportParameters.Add(new ReportParameter("Ch1", quary_add_file_pat.qq.textBox_ch1.Text));
                reportParameters.Add(new ReportParameter("Ch2", quary_add_file_pat.qq.textBox_ch2.Text));
                reportParameters.Add(new ReportParameter("Ch3", quary_add_file_pat.qq.textBox_ch3.Text));
                reportParameters.Add(new ReportParameter("Ch4", quary_add_file_pat.qq.textBox_ch4.Text));
                reportParameters.Add(new ReportParameter("Ch5", quary_add_file_pat.qq.textBox_ch5.Text));
                reportParameters.Add(new ReportParameter("Ch6", quary_add_file_pat.qq.textBox_ch6.Text));
                reportParameters.Add(new ReportParameter("Ch7", quary_add_file_pat.qq.textBox_ch7.Text));
                reportParameters.Add(new ReportParameter("Ch8", quary_add_file_pat.qq.textBox_ch8.Text));
                reportParameters.Add(new ReportParameter("Ch9", quary_add_file_pat.qq.textBox_ch9.Text));
                reportParameters.Add(new ReportParameter("Ch10", quary_add_file_pat.qq.textBox_ch10.Text));
                reportParameters.Add(new ReportParameter("Ch11", quary_add_file_pat.qq.textBox_ch11.Text));
                reportParameters.Add(new ReportParameter("Ch12", quary_add_file_pat.qq.textBox_ch12.Text));
                reportParameters.Add(new ReportParameter("Ch13", quary_add_file_pat.qq.textBox_ch13.Text));
                reportParameters.Add(new ReportParameter("Ch14", quary_add_file_pat.qq.textBox_ch14.Text));

               

                //--------------------------------------------------------------------------------------------------------------------------

                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 report-file", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}
