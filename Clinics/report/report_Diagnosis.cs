using Clinics.UserControls;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinics.report
{
    public partial class report_Diagnosis : Form
    {
        public report_Diagnosis()
        {
            InitializeComponent();
        }

        private void report_Diagnosis_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = Properties.Resources.s2;
                Image newimage = bmp;
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                //----------------------------------------------------------------------------------------------------------------------------

                reportParameters.Add(new ReportParameter("number", Diagnosis.Diagnosis1.textBox_ID_pat.Text));
                reportParameters.Add(new ReportParameter("Name", Diagnosis.Diagnosis1.textBox_Name_pat.Text));
                reportParameters.Add(new ReportParameter("ID_Vist", Diagnosis.Diagnosis1.textBox_ID_visit.Text));
                reportParameters.Add(new ReportParameter("Date", Diagnosis.Diagnosis1.textBox_date_visit.Text));
                reportParameters.Add(new ReportParameter("Reason", Diagnosis.Diagnosis1.textBox_Reason.Text));
                reportParameters.Add(new ReportParameter("AMM", Diagnosis.Diagnosis1.textBox4.Text));
                reportParameters.Add(new ReportParameter("heat", Diagnosis.Diagnosis1.textBox_heat.Text));
                reportParameters.Add(new ReportParameter("Pressure", Diagnosis.Diagnosis1.textBox_Pressure.Text));
                reportParameters.Add(new ReportParameter("weight", Diagnosis.Diagnosis1.textBox_weight.Text));
                reportParameters.Add(new ReportParameter("heart", Diagnosis.Diagnosis1.textBox_heart.Text));
                reportParameters.Add(new ReportParameter("Diagnosis", Diagnosis.Diagnosis1.textBox_Diagnosis.Text));
                reportParameters.Add(new ReportParameter("Notes", Diagnosis.Diagnosis1.textBox_Notes.Text));
                reportParameters.Add(new ReportParameter("ACC", Diagnosis.Diagnosis1.textBox_complaint.Text));


                //--------------------------------------------------------------------------------------------------------------------------

                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 report-Diagnosis", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
