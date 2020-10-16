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
    public partial class ActualUpdating2 : Form
    {
        public ActualUpdating2()
        {
            InitializeComponent();
        }

        private void ActualUpdating_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
            
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient client5 = new WebClient();
            string reply5 = client5.DownloadString("https://pastebin.com/raw/xiM7mTU8");
            string remoteUri = reply5;
            string fileName = "YakaHack Setup.exe", myStringWebResource = null;
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource, fileName);
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
            Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
            string source = Application.StartupPath + @"\YakaHack Setup.exe";
            //TextWriter tw = new StreamWriter(System.IO.Path.GetTempPath() + "YakaHack Setup.exe", true);
            string dest = System.IO.Path.GetTempPath() + "YakaHack Setup.exe";
            string source2 = Application.StartupPath + @"\YakaHack UpdateExecuter.exe";
            string dest2 = System.IO.Path.GetTempPath() + "YakaHack UpdateExecuter.exe";
            try
            {
                File.Delete(dest);
            }
            catch
            {
            }
            try
            {
                File.Delete(dest2);
            }
            catch
            {
            }
            File.Copy(source, dest);
            File.Copy(source2, dest2);
            Properties.Settings.Default.DoneUpdating = true;
        }
    }
}
