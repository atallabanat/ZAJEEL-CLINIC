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
    public partial class report_x_Ray : Form
    {
        public report_x_Ray()
        {
            InitializeComponent();
        }

        private void report_x_Ray_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = Properties.Resources.s2;
                Image newimage = bmp;
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                //----------------------------------------------------------------------------------------------------------------------------

                reportParameters.Add(new ReportParameter("x_Ray", x_ray.xx.textBox_x_ray.Text));


                //--------------------------------------------------------------------------------------------------------------------------

                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();

            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 report-X_Ray", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
