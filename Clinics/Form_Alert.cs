using Clinics.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinics
{
    public partial class Form_Alert : Form
    {
        public Form_Alert()
        {
            InitializeComponent();
        }
        public enum enmAction
        {
            wait,
            start,
            close
        }
        public enum enumType
        {
            Success,
            Warning,
            Error,
            Info,
            Edit
        }
        private Form_Alert.enmAction action;
        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;

                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Top++;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;

                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Top -= 5;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                        // home.home2.panel5.Visible = false;
                    }
                    break;
            }

        }
        public void showAlert(string msg, enumType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 0; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Form_Alert frm = (Form_Alert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20;

                    //this.y = Screen.PrimaryScreen.Bounds.Height - this.Height * i -5 * i;
                    //if (fname == "alert0")
                    //{
                    this.y = Screen.PrimaryScreen.Bounds.Top - this.Top * i + 53 * i;
                    //}
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enumType.Success:
                    this.pictureBox1.Image = Resources.Success;
                    this.BackColor = Color.SeaGreen;
                    break;

                case enumType.Error:
                    this.pictureBox1.Image = Resources.Error;
                    this.BackColor = Color.DarkRed;
                    break;

                case enumType.Info:
                    this.pictureBox1.Image = Resources.Info;
                    this.BackColor = Color.RoyalBlue;
                    break;

                case enumType.Warning:
                    this.pictureBox1.Image = Resources.Warning;
                    this.BackColor = Color.DarkOrange;
                    break;

                case enumType.Edit:
                    this.pictureBox1.Image = Resources.Edit;
                    this.BackColor = Color.Black;
                    break;
            }

            this.lbl_Msg.Text = msg;

            // home.home2.addControlsTopanel2(this);
            // home.home2.panel5.Visible = true;
            // home.home2.Show();
            this.Show();

            //this.Focus();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }
    
    private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }
    }
}
