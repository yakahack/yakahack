//๖ۣۜʄɛŁŁŐɯ ๖ۣۜɑ§İɑŊ this is not for u too look at
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YakaHack
{
    public partial class Homepage : Form
    {
        public static string CURRENTVERSION = "V38";
        public static string YakaHackData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\YakaHack";
        public static string[] Themes = { "Classic", "Metro", "Visual Studio" };
        int TogMove;
        int MValX;
        int MValY;
        private WebClient client = new WebClient();
        public Homepage()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            Form1 ShowMain = new Form1();
            ShowMain.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "Start YakaHack")
            {
                if (Properties.Settings.Default.Theme == "Metro")
                {
                    this.Hide();
                    Metro ShowMetro = new Metro();
                    ShowMetro.ShowDialog();
                    this.Close();
                    return;
                }
                if (Properties.Settings.Default.Theme == "Visual Studio")
                {
                    this.Hide();
                    YakaHackTheme ShowVS = new YakaHackTheme();
                    ShowVS.ShowDialog();
                    this.Close();
                    return;
                }
                this.Hide();
                Form1 ShowMain = new Form1();
                ShowMain.ShowDialog();
                this.Close();
            }
            else
            {

                DoStuff();
                UpgradeYakaHack Download = new UpgradeYakaHack();
                Download.Show();
                this.Hide();
            }
        }

        public void DoStuff()
        {
            Properties.Settings.Default.urmomLocationJK = this.Location;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        public void CheckDebug()
        {
            foreach (var process in Process.GetProcessesByName("DnSpy"))
            {
                //process.Kill();
                try
                {
                    Process.Start("cmd.exe", "/C echo Debugger detected: '" + "DnSpy" + "' & pause");
                    Process.GetCurrentProcess().Kill();
                }
                catch { }
            }
            foreach (var process in Process.GetProcessesByName("DnSpy-x86"))
            {
                //process.Kill();
                try
                {
                    Process.Start("cmd.exe", "/C echo Debugger detected: '" + "DnSpy-x86" + "' & pause");
                    Process.GetCurrentProcess().Kill();
                }
                catch { }
            }
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            //YakaHackTheme theme = new YakaHackTheme();
            //theme.ShowDialog();
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Focus();
            CheckDebug();
            try
            {
                Directory.CreateDirectory(YakaHackData);
            }
            catch (Exception ex)
            {
                
            }
            if (!File.Exists(YakaHackData + @"\Key.txt"))
            {
                //TextWriter tw = new StreamWriter(YakaHackData + @"\Key.txt", true);
                //tw.WriteLine("NONE");
                //tw.Close();

                string line = "None";
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(YakaHackData, "Key.txt")))
                outputFile.WriteLine(line);
            }
            else
            {
                if (Properties.Settings.Default.bois == "b")
                {
                    WebClient clientTmp = new WebClient();
                    string ActivatedKey = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\YakaHack\Key.txt");
                    ActivatedKey = ActivatedKey.Replace("\r\n", string.Empty);
                    string AllKeyDir = clientTmp.DownloadString("https://pastebin.com/raw/Zd3tKrEH");
                    string MyIp = clientTmp.DownloadString("https://api.ipify.org/?format=text");
                    try
                    {
                        if (clientTmp.DownloadString(AllKeyDir + ActivatedKey + ".txt") == MyIp)
                        {
                            Properties.Settings.Default.bois = "a";
                            Properties.Settings.Default.Save();
                        }
                    }
                    catch
                    {

                    }
                }
            }
                label3.Text = CURRENTVERSION;
            WebClient client = new WebClient();
            try
            {
                string reply = client.DownloadString("https://pastebin.com/raw/vt7qwSLM");
                textBox1.Text = reply;
                textBox1.ReadOnly = true;
                Color MessageColor = Color.FromName(client.DownloadString("https://pastebin.com/raw/AFJkShhE"));
                label7.BackColor = MessageColor;
                textBox1.Text = reply;


                WebClient client2 = new WebClient();
                string reply2 = client2.DownloadString("https://pastebin.com/raw/Sf503nZt");
                if (reply2 == label3.Text) //label3 is holding current version and is matching if it's the same version as the latest one which is stored on my website
                {
                    button1.Text = "Start YakaHack";
                    label8.Visible = false;
                }
                else
                {
                    button1.Text = "Upgrade YakaHack";
                    button2.Enabled = false;
                }
                WebClient client3 = new WebClient();
                string reply3 = client3.DownloadString("https://pastebin.com/raw/g32DHAXU");
                if (reply3 == "False") //label3 is holding current version and is matching if it's the same version as the latest one which is stored on my website
                {

                }
                else
                {
                    label7.Visible = true;
                    label7.Text = reply3;
                }
                string MoreInfo = client.DownloadString("https://pastebin.com/raw/rwpzSKji");
                if (MoreInfo == "False")
                {

                }
                else
                {
                    button3.Visible = true;
                }
                WebClient client4 = new WebClient();
                string reply4 = client4.DownloadString("https://pastebin.com/raw/vwX0nkeV");
                WebClient client5 = new WebClient();
                string reply5 = client5.DownloadString("https://pastebin.com/raw/xiM7mTU8");

                ServerName.Text = reply4;
                ServerLogo.ImageLocation = "https://cdn.discordapp.com/icons/430381037093388289/211b800df926b405a4e88edd2a0628b0.png";
            }
            catch
            {
                //return;
                int num = (int)MessageBox.Show("No Internet", "Error");
                Application.Exit();
            }
            if (Properties.Settings.Default.bois == "a")
            {
                Status.Text = "Activated";
                Status.ForeColor = Color.Green;
                button2.Visible = false;
                label8.Visible = false;
            }

                bool flag = false;

            string str = this.ReadURL("https://cdn.wearedevs.net/software/exploitapi/latestdata.txt");
            if (str.Length > 0)
            {
                flag = Convert.ToBoolean(str.Split(' ')[0]);
                if (flag == false)
                {
                    PatchedImage.Visible = true; //Patch image text
                }
                else
                {
                    //pictureBox2.Location = new Point(531, 256);
                    //pictureBox3.Location = new Point(685, 267);
                    //ServerLogo.Location = new Point(549, 270);
                    //ServerName.Location = new Point(599, 283);
                }
            }
            else
            {
                int num = (int)MessageBox.Show("Could not check for the latest version. Did your fireall block us? Try unblocking discordapp.com and pastebin.com and GitHub.io", "Error");
            }
            if (Environment.UserName == "YakovPC")
            {

            }
            else
            {
                    DeleteSource();
            }
            if (Properties.Settings.Default.bois == "a")
            {
                A();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            label4.BackColor = MouseDown2.Color;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.BackColor = MouseHover2.Color;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Normal.Color;
        }

        private void label4_MouseUp(object sender, MouseEventArgs e)
        {
            label4.BackColor = Normal.Color;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            label5.BackColor = MouseDown2.Color;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.BackColor = MouseHover2.Color;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Normal.Color;
        }

        private void label5_MouseUp(object sender, MouseEventArgs e)
        {
            label5.BackColor = Normal.Color;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private string ReadURL(string url)
        {

            return this.client.DownloadString(url);
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RegisterPro ShowPurchasePage = new RegisterPro();
            ShowPurchasePage.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        public void DeleteSource()
        {
            if (!Debugger.IsAttached)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + @"\DeleteSource.exe");
            }
        }

        public void A()
        {
            WebClient client1 = new WebClient();
            string DeviceId = client1.DownloadString("https://api.ipify.org/?format=text");
            //WebClient client2 = new WebClient();
            //string DeviceIds = client2.DownloadString("https://pastebin.com/raw/EJTMfuQT");
            string Key = File.ReadAllText(YakaHackData + @"\Key.txt", Encoding.UTF8);
            Key = Key.Replace("\r\n", string.Empty);
            try
            {
                string onlineipTest = client.DownloadString("http://yakasoftapi.ml/Files/Keys/" + Key + ".txt");
            }
            catch (Exception ex)
            {
                Properties.Settings.Default.bois = "b";
                Properties.Settings.Default.Save();
                MessageBox.Show("Pro got Detected though, the Key isn't Correct, If you had a Key and it doesn't work, Check the Discord if the keys were Resetted. In the meantime, You can re-open YakaHack and use the free version.");
                Application.Exit();
                return;
            }
            string onlineip = client.DownloadString("http://yakasoftapi.ml/Files/Keys/" + Key + ".txt");
            if (onlineip.Contains(DeviceId))
                {
                   
                }
                else
                {
                    Properties.Settings.Default.bois = "b";
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Pro key detected already used, or your IP Changed, if this is the Case Contact: Yakov#7772, in the mean-time We Downgraded you to Free.");
                    Application.Exit();
                }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("https://discord.gg/link");
            JoinServer.Join(Eramake.eCryptography.Decrypt(client.DownloadString("https://pastebin.com/raw/bKjYeTaY")));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(client.DownloadString("https://pastebin.com/raw/rwpzSKji"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
