using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Clinics.adminControls
{
    public partial class FrmBackUp : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        string SRC;
        string ServerName;
        string UserName;
        string Password;
        string PathD;
        public FrmBackUp()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            lbl_Precent.Text = "0 %";
            string Date ="_"+ DateTime.Now.ToString("yyyy-MM-dd");
            string DataBase = "";
            if (comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("يرجى تحديد قاعدة البيانات","عملية خاطئة",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(textSrc.Text==string.Empty)
            {
                MessageBox.Show("يرجى تحديد مسار الحفظ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(PathD=="C:")
            {
                MessageBox.Show("C"+"  لا يمكنك حفظ البيانات في قرص  ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedIndex==0)
            {
                DataBase = "clinic";
            }
            else if(comboBox1.SelectedIndex==1)
            {
                DataBase = "KzPharmacy";
            }
            progressBar1.Value = 0;
            try
            {
                
                SRC = textSrc.Text;
                Server dbServer = new Server(new ServerConnection(ServerName, UserName, Password));
                Backup dbackup = new Backup() { Action = BackupActionType.Database, Database= DataBase };
                dbackup.Devices.AddDevice(SRC + DataBase+Date,DeviceType.File);
                dbackup.Initialize = true;
                dbackup.PercentComplete += DbBackup_PrecentComplete;
                dbackup.Complete += DbBackup_Complete;
                dbackup.SqlBackupAsync(dbServer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if(e.Error !=null)
            {
                lbl_St.Invoke((MethodInvoker)delegate
                {
                    lbl_St.Text = e.Error.Message;
                });
            }
        }

        private void DbBackup_PrecentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.Percent;
                progressBar1.Update();
            });
            lbl_Precent.Invoke((MethodInvoker)delegate
            {
                lbl_Precent.Text = $"{e.Percent}%";
            });
        }

        private void FrmBackUp_Load(object sender, EventArgs e)
        {          
            string[] C1 = new string[] { "" };
            string[] C2 = new string[] { "" };
            string[] C3 = new string[] { "" };
            C1 = constring.Split('=');
            string Server = C1[1];
            string User = C1[3];
            C3 = User.Split(';');
            C2 = Server.Split(';');
            ServerName = C2[0];
            UserName = C3[0];
            Password = C1[4];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    string[] PathW = new string[] { "" };
                    PathW = fbd.SelectedPath.Split('\\');
                    PathD = PathW[0];
                    textSrc.Text = fbd.SelectedPath.ToString();
                }
            }
        }

        private void lbl_Precent_TextChanged(object sender, EventArgs e)
        {
            if (lbl_Precent.Text == "100%")
            {
                lbl_St.BackColor = Color.Green;
            }
        }
    }
}
