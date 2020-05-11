﻿using System;
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
    public partial class Item_Order : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public Item_Order()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select Barcode,ItemName,EndDate,Quantity,cost_Parchase,cost_Sales,RetailPrice,TAX,Total from Drugs_NOW2 where EndDate between @Date_order1 and @Date_order2";

                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
                con.Close();
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("لا يوجد مواد", "لا يوجد بيانات لعرضها ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 Item_Order", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
