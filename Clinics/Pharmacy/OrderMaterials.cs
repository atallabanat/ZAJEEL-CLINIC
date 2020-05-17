using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinics.Pharmacy
{
    public partial class OrderMaterials : Form
    {
        public OrderMaterials()
        {
            InitializeComponent();
        }
        
        private void OrderMaterials_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(1111,"sassdsad",1.5,3.00,0,12,5,52);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Cells[ClmADD.Name].Selected==true)
            {
                dataGridView2.Rows.Add(dataGridView1.Rows[e.RowIndex].Cells[Clm_R_Barcode.Name].Value, dataGridView1.Rows[e.RowIndex].Cells[Clm_R_ItemName.Name].Value, dataGridView1.Rows[e.RowIndex].Cells[Clm_R_PriceParchase.Name].Value, dataGridView1.Rows[e.RowIndex].Cells[Clm_R_PriceSales.Name].Value, dataGridView1.Rows[e.RowIndex].Cells[Clm_R_Tax.Name].Value, 1, 33);
                int index = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(index);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Cells[Clm_Delete.Name].Selected == true)
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                dataGridView2.Rows.RemoveAt(index);
            }
        }
    }
}
