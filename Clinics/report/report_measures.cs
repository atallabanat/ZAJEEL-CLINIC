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
    public partial class report_measures : Form
    {
        public report_measures()
        {
            InitializeComponent();
        }

        private void report_measures_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = Properties.Resources.s2;
                Image newimage = bmp;
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                //----------------------------------------------------------------------------------------------------------------------------

                reportParameters.Add(new ReportParameter("n1", Measures.mm.text_Name_Measures1.Text));
                reportParameters.Add(new ReportParameter("n2", Measures.mm.text_Name_Measures2.Text));
                reportParameters.Add(new ReportParameter("n3", Measures.mm.text_Name_Measures3.Text));
                reportParameters.Add(new ReportParameter("n4", Measures.mm.text_Name_Measures4.Text));
                reportParameters.Add(new ReportParameter("nO", Measures.mm.textBox_Name_MeasuresOther.Text));
                reportParameters.Add(new ReportParameter("P1", Measures.mm.t1.Text));
                reportParameters.Add(new ReportParameter("P2", Measures.mm.t2.Text));
                reportParameters.Add(new ReportParameter("P3", Measures.mm.t3.Text));
                reportParameters.Add(new ReportParameter("P4", Measures.mm.t4.Text));
                reportParameters.Add(new ReportParameter("PO", Measures.mm.text_price_Other.Text));

                //--------------------------------------------------------------------------------------------------------------------------

                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 report-measures", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
