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
    public partial class report_visitpatient : Form
    {
        public report_visitpatient()
        {
            InitializeComponent();
        }

        private void report_visitpatient_Load(object sender, EventArgs e)
        {

            try
            {
                Bitmap bmp = Properties.Resources.s2;
                Image newimage = bmp;
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                //----------------------------------------------------------------------------------------------------------------------------

                reportParameters.Add(new ReportParameter("number", quary_visitpatient.qak.textBox_ID_pat.Text));
                reportParameters.Add(new ReportParameter("Name", quary_visitpatient.qak.textBox_Name_pat.Text));
                reportParameters.Add(new ReportParameter("ID_Vist", quary_visitpatient.qak.textBox_ID_visit.Text));
                reportParameters.Add(new ReportParameter("Date", quary_visitpatient.qak.textBox_date_visit.Text));
                reportParameters.Add(new ReportParameter("Reason", quary_visitpatient.qak.textBox_Reason.Text));
                reportParameters.Add(new ReportParameter("AMM", quary_visitpatient.qak.textBox4.Text));
                reportParameters.Add(new ReportParameter("heat", quary_visitpatient.qak.textBox_heat.Text));
                reportParameters.Add(new ReportParameter("Pressure", quary_visitpatient.qak.textBox_Pressure.Text));
                reportParameters.Add(new ReportParameter("weight", quary_visitpatient.qak.textBox_weight.Text));
                reportParameters.Add(new ReportParameter("heart", quary_visitpatient.qak.textBox_heart.Text));
                reportParameters.Add(new ReportParameter("Diagnosis", quary_visitpatient.qak.textBox_Diagnosis.Text));
                reportParameters.Add(new ReportParameter("Notes", quary_visitpatient.qak.textBox_Notes.Text));

                //--------------------------------------------------------------------------------------------------------------------------

                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 report-visitpatient", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
