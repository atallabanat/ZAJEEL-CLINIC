using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Clinics.Class;

namespace Clinics.adminControls
{
    public partial class Comf : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        OthersDataBase D = new OthersDataBase();
        public Comf()
        {
            InitializeComponent();
        }

        private void Comf_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from "+D.DataPharmacy+"Comf where id=1", con);
                SqlDataReader dr;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox_name.Text = dr["com_name"].ToString();
                    textBox_addres.Text = dr["com_Adress"].ToString();
                    textBox_phone.Text = dr["com_pohne"].ToString();
                    textBox_fax.Text = dr["com_Fax"].ToString();
                    textBox_year.Text = dr["com_year"].ToString();

                    byte[] image = (byte[])dr["img"];

                    if (image == null)
                    {
                        pic.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(image);
                        pic.Image = Image.FromStream(ms);
                    }

                }
                con.Close();

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Comf", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "ALL image |*.PNG; *.JPG; *.BMP; ";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pic.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Comf", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pic.Image.Save(ms, pic.Image.RawFormat);
                byte[] byteimage = ms.ToArray();
                SqlCommand cmd = new SqlCommand("update "+D.DataPharmacy+"Comf set img=@img, com_name=@com_name , com_Adress=@com_Adress , com_pohne=@com_pohne , com_Fax=@com_Fax , com_year=@com_year where id=1 ", con);
                cmd.Parameters.AddWithValue("@img", byteimage);
                cmd.Parameters.AddWithValue("@com_name", textBox_name.Text);
                cmd.Parameters.AddWithValue("@com_Adress", textBox_addres.Text);
                cmd.Parameters.AddWithValue("@com_pohne", textBox_phone.Text);
                cmd.Parameters.AddWithValue("@com_Fax", textBox_fax.Text);
                cmd.Parameters.AddWithValue("@com_year", textBox_year.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم تخزين البيانات بنجاح");
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Comf", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
