using Clinics.Class;
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

namespace Clinics.pharmacy_Control
{
    public partial class count2 : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static count2 count22;
        msgShow msg = new msgShow();
        ConvertDate convertDate = new ConvertDate();
        string R_Barcode;
        string R_ItemName;
        string R_Qty;
        string R_Tax;
        string R_PriceSales;
        string R_DateItem;
        string R_PriceParchase;
        double NrOfDays;
        DateTime d1 = DateTime.Now;
        DateTime d2;
        public count2()
        {
            count22 = this;
            InitializeComponent();
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            { 
                if(dataGridView1.Rows.Count > 0)
                {
                    R_Barcode = dataGridView1.CurrentRow.Cells[Clm_R_Barcode.Name].Value.ToString();
                    R_ItemName = dataGridView1.CurrentRow.Cells[Clm_R_ItemName.Name].Value.ToString();
                    R_Qty = dataGridView1.CurrentRow.Cells[Clm_R_Qty.Name].Value.ToString();
                    R_Tax = dataGridView1.CurrentRow.Cells[Clm_R_Tax.Name].Value.ToString();
                    R_PriceSales = dataGridView1.CurrentRow.Cells[Clm_R_PriceSales.Name].Value.ToString();
                    R_DateItem = dataGridView1.CurrentRow.Cells[Clm_R_DateItem.Name].Value.ToString();
                    R_PriceParchase= dataGridView1.CurrentRow.Cells[clm_R_PriceParchase.Name].Value.ToString();
                    d2 = Convert.ToDateTime(convertDate.TODate(R_DateItem));
                    TimeSpan t = d1 - d2;
                    NrOfDays = t.TotalDays;
                    if (NrOfDays > 0)
                    {
                        msg.Alert("عذرا المادة منتهية الصلاحية ، لا يمكنك بيع مادة منتهية الصلاحية", Form_Alert.enumType.Warning);
                        return;
                    }
                    else
                    {
                        POS.pOS.dataGridView1.Rows.Add(POS.pOS.dataGridView1.Rows.Count + 1, R_Barcode, R_ItemName, 1, R_PriceSales, string.Empty, string.Empty, R_Tax, string.Empty, R_DateItem, R_PriceParchase);
                        if (POS.pOS.ItemMax(R_Barcode) >= Convert.ToDouble(R_Qty))
                        {
                            msg.Alert("تنبيه : المادة وصلت حد الطلب" + " | الكمية المتبقية " + R_Qty, Form_Alert.enumType.Info);
                        }
                        if (NrOfDays > -31)
                        {
                            msg.Alert("تنبيه : المادة بالقرب من إنتهاء الصلاحية "+ " | صالحه لتاريخ "+ R_DateItem, Form_Alert.enumType.Info);                            
                        }
                    }
                }
                 this.Close();
            }
            catch
            {               
                msg.Alert("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + "ERORR count2 1", Form_Alert.enumType.Error);
            }
        }
    }
}
