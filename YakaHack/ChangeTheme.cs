using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YakaHack
{
    public partial class ChangeTheme : Form
    {
        public ChangeTheme()
        {
            InitializeComponent();
        }

        private void ChangeTheme_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            foreach (string STheme in Homepage.Themes)
            {
                listBox1.Items.Add(STheme);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = listBox1.GetItemText(listBox1.SelectedIndex);
            Properties.Settings.Default.Save();
            MessageBox.Show("Changes will Apply when you Re-open YakaHack", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
