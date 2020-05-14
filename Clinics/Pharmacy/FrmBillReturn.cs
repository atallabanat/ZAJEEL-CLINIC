using Clinics.Class;
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

namespace Clinics.Pharmacy
{
    public partial class FrmBillReturn : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        msgShow msg = new msgShow();
        string ID;
        public FrmBillReturn()
        {
            InitializeComponent();
        }

        private void FrmBillReturn_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select distinct ID,FORMAT (DateInvoice, 'dd-MM-yyyy ') as DateInvoice ,Time,TotalAmount_Invoice from " + D.DataPharmacy+"Invoice_Sales where Bill_Suspension = 1 and ID_User=@ID_User and Myear=@Myear order by ID";
                    Cmd.Parameters.AddWithValue("@ID_User",Program.user_ID);
                    Cmd.Parameters.AddWithValue("@Myear", POS.pOS.MYear);
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch
            {
                msg.Alert("Error 1 FrmBillReturn ", Form_Alert.enumType.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                ID = dataGridView1.CurrentRow.Cells[Clm_ID.Name].Value.ToString();
            }
            catch
            {

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID == string.Empty)
                {
                    MessageBox.Show("يرجى تحديد القاتورة من القائمة السابقة ثم الضغط على زر إسترجاع", "تحديد", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                POS.pOS.addScreen(ID);
            }
            catch
            {

            }
        }
    }
}
