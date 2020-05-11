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
    public partial class report_Analyzes : Form
    {
        public report_Analyzes()
        {
            InitializeComponent();
        }

        private void report_Analyzes_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = Properties.Resources.s2;
                Image newimage = bmp;
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                //----------------------------------------------------------------------------------------------------------------------------

                reportParameters.Add(new ReportParameter("Analyzes", Analyzes.ss.textBox_analyze.Text));


                //--------------------------------------------------------------------------------------------------------------------------

                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 report-Analyzes", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
