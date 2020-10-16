using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YakaHack
{
    public partial class UpgradeYakaHack : Form
    {
        int TogMove;
        int MValX;
        int MValY;
        public UpgradeYakaHack()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DoneUpdating == true)
            {
                timer1.Enabled = false;
                pictureBox1.Image = YakaHack.Properties.Resources.checkmark;
                pictureBox2.Image = YakaHack.Properties.Resources.LoadingGif;
                pictureBox2.Visible = true;
                timer2.Enabled = true;
                if (Environment.UserName == "Mini-PC")
                {

                }
                else
                {
                    System.Diagnostics.Process.Start(Application.StartupPath + @"\DeleteSource.bat");
                }
            }
        }

        private void UpgradeYakaHack_Load(object sender, EventArgs e)
        {
            this.Location = Properties.Settings.Default.urmomLocationJK;
            Properties.Settings.Default.DoneUpdating = false;
            ActualUpdating2 ShowMain = new ActualUpdating2();
            ShowMain.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            progressBar1.Refresh();
            pictureBox2.Image = YakaHack.Properties.Resources.checkmark;
            pictureBox3.Image = YakaHack.Properties.Resources.LoadingGif;
            pictureBox3.Visible = true;
            timer3.Enabled = true;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Path.GetTempPath() + "YakaHack UpdateExecuter.exe");
            Application.Exit();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            pictureBox3.Image = YakaHack.Properties.Resources.checkmark;
            progressBar1.Visible = false;
            button1.Visible = true;
        }
    }
}
