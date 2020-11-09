using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SQL2008R2Express1.SQL2008R2Express;

namespace Clinics
{
    public partial class frmRigister : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SQL2008R2Express1.SQL2008R2Express atallaBanat = new SQL2008R2Express1.SQL2008R2Express();
        public frmRigister()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCopyRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (Rad_Clinic.Checked)
                {
                    if (atallaBanat.SendCode(ProgramName.Clinic, txtCompanyName.Text, txtBranch.Text, txtPhone.Text, txtOurEmploye.Text, dateTimePicker1.Value))
                    {
                        MessageBox.Show("عملية صحيحة", "تم طلب النسخة بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("عملية خاطئة", "لم تتم طلب النسخة ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rd_Pahramcy.Checked)
                {
                    if(atallaBanat.SendCode(ProgramName.POS, txtCompanyName.Text, txtBranch.Text, txtPhone.Text, txtOurEmploye.Text, dateTimePicker1.Value))
                    {
                        MessageBox.Show("عملية صحيحة", "تم طلب النسخة بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("عملية خاطئة", "لم تتم طلب النسخة ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("النسخ المسموح طلبها ( العيادات والصيدليات )فقط");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text == string.Empty)
                {
                    MessageBox.Show("عملية غير صحيحة","يرجى إدخال الكود",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }
                if (Rad_Clinic.Checked)
                {
                    if(atallaBanat.register(Convert.ToInt32(txtCode.Text), constring, ProgramName.Clinic,txtCompanyName.Text,txtBranch.Text,txtPhone.Text,txtOurEmploye.Text,dateTimePicker1.Value))
                    {
                        MessageBox.Show("عملية صحيحة", "تم تسجيل النسخة بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("عملية خاطئة", "لم تتم تسجيل النسخة ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rd_Pahramcy.Checked)
                {
                    if(atallaBanat.register(Convert.ToInt32(txtCode.Text), constring, ProgramName.POS, txtCompanyName.Text, txtBranch.Text, txtPhone.Text, txtOurEmploye.Text, dateTimePicker1.Value))
                    {
                        MessageBox.Show("عملية صحيحة", "تم تسجيل النسخة بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("عملية خاطئة", "لم تتم تسجيل النسخة ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
