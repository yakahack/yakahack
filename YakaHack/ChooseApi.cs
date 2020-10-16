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
    public partial class ChooseApi : Form
    {
        public ChooseApi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a API");
            }
            else
            {
                if (Properties.Settings.Default.bois == "a")
                {
                    if (listBox1.SelectedIndex == 0)
                    {
                        Properties.Settings.Default.ApiMode = "WeAreDevs API V1";
                        this.Close();
                    }
                    if (listBox1.SelectedIndex == 1)
                    {
                        Properties.Settings.Default.ApiMode = "WeAreDevs API V2";
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("This is a Pro Feature.");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 2)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
    }
}
