using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YakaHack
{
    public partial class AdminPanel : Form
    {
        private WebClient client = new WebClient();
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            string Key = client.DownloadString("http://yakasoftapi.ml/Files/AdminPanel/Check.php?MasterKey=" + Form1.AdminKey);
            string[] array = Key.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (String item in array)
                MessageBox.Show(item);

        }
    }
}
