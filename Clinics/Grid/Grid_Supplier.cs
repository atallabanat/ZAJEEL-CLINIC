using Clinics.Pharmacy;
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

namespace Clinics.Grid
{
    public partial class Grid_Supplier : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        msgShow msg = new msgShow();
        //public Virable
        public static Boolean SCR_Invoice_Parchase;
        public static Boolean SCR_Entry_Bond;
        
        string Supplier_no;
        string Supplier_Name;
        public Grid_Supplier()
        {
            InitializeComponent();
        }

        private void Grid_Supplier_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select * from add_Supplier";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);
                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Supplier_no = dataGridView1.CurrentRow.Cells[clm_ID_Supplier.Name].Value.ToString();
                    Supplier_Name = dataGridView1.CurrentRow.Cells[clm_Name_Supplier.Name].Value.ToString();


                    if (SCR_Invoice_Parchase == true)
                    {
                        Invoice_Parchase.Inv_Parchase.textBox_Supplier_No.Text = Supplier_no;
                        Invoice_Parchase.Inv_Parchase.textBox_Supplier_Name.Text = Supplier_Name;
                        SCR_Invoice_Parchase = false;
                    }
                    if (SCR_Entry_Bond == true)
                    {
                        Entry_Bond.entry_Bond.textBox_Supplier_No.Text = Supplier_no;
                        Entry_Bond.entry_Bond.textBox_Supplier_Name.Text = Supplier_Name;
                        SCR_Entry_Bond = false;
                    }

                }
                this.Close();
            }
            catch(Exception ex)
            {
                msg.Alert(ex.Message,Form_Alert.enumType.Error);
            }

        }
    }
}
