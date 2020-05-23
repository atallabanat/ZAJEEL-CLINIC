using Clinics.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinics.Pharmacy.ToolsPos.FRM_Report
{
    public partial class FRM_Report_Material_inventory : Form
    {
        public static FRM_Report_Material_inventory fRM_Report_Material_;
        public FRM_Report_Material_inventory()
        {
            fRM_Report_Material_ = this;
            InitializeComponent();
        }

        private void FRM_Report_Material_inventory_Load(object sender, EventArgs e)
        {

        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            try
            {
                Grid_Item.SCR_FRM_Report_Material_inventory = true;
                Grid_Item grid_Item = new Grid_Item();
                grid_Item.ShowDialog();
            }
            catch
            {

            }
        }
    }
}
