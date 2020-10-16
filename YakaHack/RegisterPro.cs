//๖ۣۜʄɛŁŁŐɯ ๖ۣۜɑ§İɑŊ this is not for u too look at, hell no stealing codes..
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YakaHack
{
    public partial class RegisterPro : Form
    {
        string 哈 = "123456789abcdefghijklmnopqrstuvwxyz";
        string 键 = "停下来";
        string 非ASCII = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";
        string 数字 = "1234567890";
        string 所有人物 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string Action = "";
        string key = "A";
        bool 冷却 = false;

        public string Key { get => key; set => key = value; }

        public RegisterPro()
        {
            InitializeComponent();
        }

        private void RegisterPro_Load(object sender, EventArgs e)
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
           if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                
            }
            else
            {
                if (MessageBox.Show("Activation Requires this Program to Run as Administrator, if you would like to Activate and Run as Administrator Click OK", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    this.Close();
                    return;
                }
                //run as Admin
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                startInfo.Verb = "runas";
                try
                {
                    Process p = Process.Start(startInfo);
                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show("Disable your anti virus!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    int num;
                    for (int i = 1; i <= 9; i = num + 1)
                    {
                        Application.Exit();
                        num = i;
                    }
                    return;
                }
                Application.Exit();
            }
        }

        public string Get隐藏的来源(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string 真的停下来 = client.DownloadString("https://pastebin.com/raw/C3vNUGNj"); //idk
            WebClient client1 = new WebClient();
            string DeviceId = client1.DownloadString("https://api.ipify.org/?format=text");
            WebClient client2 = new WebClient();
            if (冷却 == false)
            {
                try
                {
                    string KeyDirLink2 = client.DownloadString("https://pastebin.com/raw/Zd3tKrEH");
                    string KeyStatusTest = client2.DownloadString(KeyDirLink2 + 不错的尝试.Text + ".txt");
                }
                catch
                {
                    冷却 = true;
                    Cooldown.Enabled = true;
                    ErrorForm ShowError = new ErrorForm();
                    ShowError.ShowDialog();
                    return;
                }
                string KeyDirLink = client.DownloadString("https://pastebin.com/raw/Zd3tKrEH");
                string KeyStatus = client2.DownloadString(KeyDirLink + 不错的尝试.Text + ".txt");
                KeyStatus = KeyStatus.Replace("\r\n", string.Empty);
                if (KeyStatus == "NONE")
                {
                    string ActivatePHPLink = client.DownloadString("https://pastebin.com/raw/fitxUgJR");
                    Action = client.DownloadString(ActivatePHPLink + 不错的尝试.Text + "&IP=" + DeviceId);
                    Action = Action.Replace("\r\n", string.Empty);
                    if (Action == "Registered")
                    {
                        Properties.Settings.Default.bois = "a";
                        Properties.Settings.Default.Save();
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(Homepage.YakaHackData, "Key.txt")))
                            outputFile.WriteLine(不错的尝试.Text);
                        Purchased ShowThx = new Purchased();
                        ShowThx.ShowDialog();
                        Close();
                    }
                    else
                    {
                        if (Action == "Already Used")
                        {
                            MessageBox.Show("Key Already Used");
                        }
                        else
                        {
                            MessageBox.Show("Unknown Error Has Occrued, if you see this Please contact me at Yakov#7772.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Key Already Used");
                }
            }
            else
            {
                MessageBox.Show("Please wait around 2 minutes before you can check another key");
                return;
            }
            
        }
        

        private void Cooldown_Tick(object sender, EventArgs e)
        {
            Cooldown.Enabled = false;
            冷却 = false;
        }
    }
}
