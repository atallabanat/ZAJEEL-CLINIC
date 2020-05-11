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
    public partial class welcome : Form
    {

        Timer timerback = new Timer();
        Timer timerrocket = new Timer();
        Timer timerball = new Timer();

        public welcome()
        {
            InitializeComponent();
            timerback.Tick += new EventHandler(resource);
            timerball.Tick += new EventHandler(bal);
            timerrocket.Tick += new EventHandler(rocketup);

            defaul();
        }

        void defaul()
        {
            linerocket.Height = 1; linerocket.Width = 0; linerocket.Left = 341;
            ball.Top = 262;ball.Visible = false;ball.BringToFront();
            rocket.Height = 64;rocket.Top = 320;rocket.Visible = false;

            ball.Image = Properties.Resources.circleblue;
            rocket.Image = Properties.Resources.rockwhite;
            anim.HideSync(label1);

            timerback.Interval = 30;
            timerball.Interval = 40;
            timerrocket.Interval = 10;

            timerback.Start();
        }
        int wd = 0;
        void resource(object sender,EventArgs e)
        {
            linerocket.Width += wd;

            if(linerocket.Width<1)
            {
                wd = 8;

            }
            if(linerocket.Width>104)
            {
                timerback.Stop();
                timerrocket.Start();
            }
            anim.ShowSync(label1);
        }
        int down = 1, lt = 5;
        int count = 0;
        void bal(object sender,EventArgs e)
        {
            ball.Top += down;
            if(ball.Top< 265)
            {
                ball.Visible = true;
                down = 1;
            }
            if(ball.Top>305)
            {
                timerball.Interval = 10;
                rocket.Image = Properties.Resources.rockblue2;
                ball.Visible = false;
                down = 5;
                rocket.Top -= down;
                if(rocket.Top<-60)
                {
                    linerocket.Width-= lt;
                    linerocket.Left += lt;
                    if(linerocket.Left>470)
                    {
                        down = 1;
                        timerball.Stop();
                        count += 1;
                        if (count == 2)
                        {
                            this.Hide();
                            Form1 ss = new Form1();
                            ss.Show();

                        }
                        else
                        {
                            defaul();
                        }
                    }
                }
            }

        }
        int rocktop = -1;
        void rocketup(object sender,EventArgs e)
        {
            rocket.Top += rocktop;
            if(rocket.Top>318)
            {
                rocket.Visible = true;
                rocktop = -5;
            }
            if(rocket.Top<250)
            {
                rocktop = -1;
                timerrocket.Stop();
                timerball.Start();
            }
        }
    }
}
