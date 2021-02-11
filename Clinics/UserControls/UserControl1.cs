using System;
using System.Drawing;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Clinics.UserControls
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            timer1.Start();
        }
        int panel1_x = 152;
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1_x -= 4;
            panel1.Size = new Size(panel1.Size.Width, panel1_x);
            if (panel1_x < 1)
            {
                panel1.Hide();
                timer1.Enabled = false;
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            Form1 ss = new Form1();
            ss.Show();
            this.Hide();
            timer2.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            SpeechSynthesizer reder = new SpeechSynthesizer();
            reder.Dispose();
            reder = new SpeechSynthesizer();
            reder.SpeakAsync("Welcome to Quality Software Solutions");
        }
    }
}
