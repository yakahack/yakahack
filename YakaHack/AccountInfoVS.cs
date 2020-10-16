using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace YakaHack
{
    public partial class AccountInfoVS : UserControl
    {
        private WebClient client = new WebClient();
        public AccountInfoVS()
        {
            InitializeComponent();
        }

        private void AccountInfoVS_Load(object sender, EventArgs e)
        {
            string Username = Environment.UserName;
            label11.Text = Username;
            label12.Text = Username.Substring(0, 1);
            label1.Text = "Key: " + System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\YakaHack\Key.txt");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("If you de-activate, anyone else who knows your key can use it and activate Pro to their Computer, You're Sure you want to De-Activate?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string ActivatedKey = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\YakaHack\Key.txt");
                ActivatedKey = ActivatedKey.Replace("\r\n", string.Empty);
                string DeActivateLink = client.DownloadString("https://pastebin.com/raw/6EQpgRUx");
                string MyIP = client.DownloadString("https://api.ipify.org/?format=text");
                string DeActivate = client.DownloadString(DeActivateLink + "Key=" + ActivatedKey + "&MyIP=" + MyIP);
                //MessageBox.Show(client.DownloadString(DeActivateLink + "Key=" + ActivatedKey + "&MyIP=" + MyIP));
                Properties.Settings.Default.bois = "b";
                Properties.Settings.Default.Theme = "Classic";
                Properties.Settings.Default.Save();
                linkLabel1.Visible = false;
            }
        }

    }
}
