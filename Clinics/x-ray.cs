﻿using Clinics.report;
using Clinics.UserControls;
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

namespace Clinics
{
    public partial class x_ray : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static x_ray xx;

        public x_ray()
        {
            xx = this;
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("update Table_visit_patient set Xray=@Xray where ID_visit=" + textBox1.Text.Trim() + "", con);

                cmd.Parameters.Add(new SqlParameter("@Xray", SqlDbType.NVarChar)).Value = textBox_x_ray.Text;








                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



                MessageBox.Show("تم إضافة بيانات الاشعة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 x-ray", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void x_ray_Load(object sender, EventArgs e)
        {
            try
            { 
            textBox1.Text = Diagnosis.ss;

            SqlCommand na = new SqlCommand();
            na = new SqlCommand("select Xray from Table_visit_patient where  ID_visit =  '" + textBox1.Text + "' ", con);
            con.Open();
            SqlDataReader dr;

            dr = na.ExecuteReader();
            while (dr.Read())
            {

                string Xray = dr["Xray"].ToString();
                textBox_x_ray.Text = Xray;


            }
            dr.Close();
            con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 x-ray", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            report_x_Ray ss = new report_x_Ray() ;
            ss.Show();
        }
    }
}
