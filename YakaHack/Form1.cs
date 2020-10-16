//๖ۣۜʄɛŁŁŐɯ ๖ۣۜɑ§İɑŊ this is not for u too look at
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using ScintillaNET;
using System.Runtime.InteropServices;
using WeAreDevs_API;
//using WeAreDevs_APIV2;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using Newtonsoft.Json.Linq;

namespace YakaHack
{
    public partial class Form1 : Form
    {
        ExploitAPI a = new ExploitAPI();
        //ExpIoitAPI api = new ExpIoitAPI();
        Boolean DontShow = false;
        Boolean DLLInstalled = false;
        Boolean Buttonone = false;
        Boolean Buttontwo = false;
        Boolean Buttonthree = false;
        string CButton1 = "";
        string CButton2 = "";
        string CButton3 = "";
        string Rate = "Didn't rate";
        private WebClient client = new WebClient();
        public static String AdminKey;
        [DllImport("WeAreDevs_API.cpp.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LaunchExploit();

        [DllImport("WeAreDevs_API.cpp.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SendLuaCScript(string script);

        [DllImport("WeAreDevs_API.cpp.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SendLimitedLuaScript(string script);

        [DllImport("WeAreDevs_API.cpp.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SendCommand(string script);

        [DllImportAttribute("User32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private void HandleHotkey()
        {
            if (checkBox3.Checked == true)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Activate();
                tabControl1.SelectedIndex = 0;
                textBox11.Visible = true;
                textBox11.Select();
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }
        public static class Constants
        {
            //windows message id for hotkey
            public const int WM_HOTKEY_MSG_ID = 0x0312;
        }
        public Form1()
        {
            InitializeComponent();
        }

        
        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.StartupPath + openFileDialog1.FileName);
            //api.LaunchExploit();
            label14.Text = "Current API: " + Properties.Settings.Default.ApiMode;
            webBrowser2.Refresh();
            if (Properties.Settings.Default.bois == "a")
            {
                linkLabel3.Visible = false;
                button11.Enabled = false;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button18.Enabled = false;
                checkBox2.Enabled = true;
                comboBox1.Enabled = true;
                button12.Enabled = true;
                linkLabel1.Visible = true;
                button30.Enabled = true;
                button32.Enabled = true;
                checkBox3.Enabled = true;
                button41.Enabled = true;
            }
            //Start Textbox
            var alphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Not sure what the next 3 lines are :/
            var numericChars = "0123456789";
            var accentedChars = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";

            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            scintilla1.StyleResetDefault();
            scintilla1.Styles[Style.Default].Font = "Consolas";
            scintilla1.Styles[Style.Default].Size = 10;
            scintilla1.Styles[Style.Default].ForeColor = Color.Black;
            scintilla1.Styles[Style.Default].BackColor = Color.White;

            scintilla1.StyleClearAll();



            // Configure the Lua lexer styles
            this.scintilla1.Styles[0].ForeColor = Color.Silver;
            this.scintilla1.Styles[1].ForeColor = Color.FromArgb(0, 0, (int)sbyte.MaxValue, 0);
            this.scintilla1.Styles[2].ForeColor = Color.FromArgb(0, 0, (int)sbyte.MaxValue, 0);
            this.scintilla1.Styles[4].ForeColor = Color.FromArgb(0, 0, (int)sbyte.MaxValue, (int)sbyte.MaxValue);
            this.scintilla1.Styles[5].ForeColor = Color.FromArgb(0, 0, 0, (int)sbyte.MaxValue);
            this.scintilla1.Styles[13].ForeColor = Color.FromArgb(0, (int)byte.MaxValue, 128, 0);
            this.scintilla1.Styles[14].ForeColor = Color.FromArgb(0, (int)byte.MaxValue, 0, 0);
            this.scintilla1.Styles[15].ForeColor = Color.DarkSlateBlue;
            this.scintilla1.Styles[6].ForeColor = Color.FromArgb(0, (int)sbyte.MaxValue, 0, (int)sbyte.MaxValue);
            this.scintilla1.Styles[7].ForeColor = Color.FromArgb(0, (int)sbyte.MaxValue, 0, (int)sbyte.MaxValue);
            this.scintilla1.Styles[8].ForeColor = Color.FromArgb(0, (int)sbyte.MaxValue, 0, (int)sbyte.MaxValue);
            this.scintilla1.Styles[10].ForeColor = Color.FromArgb(0, (int)sbyte.MaxValue, (int)sbyte.MaxValue, (int)sbyte.MaxValue);
            this.scintilla1.Styles[9].ForeColor = Color.Maroon;
            scintilla1.Lexer = Lexer.Lua;
            scintilla1.WordChars = alphaChars + numericChars + accentedChars;

            // Console.WriteLine(scintilla1.DescribeKeywordSets());

            // Keywords
            scintilla1.SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while" + " false true" + " goto");
            // Basic Functions
            scintilla1.SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug" + " getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
            // String Manipulation & Mathematical
            scintilla1.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan" + " string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult" + " bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift" + " utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
            // Input and Output Facilities and System Facilities
            scintilla1.SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname" + " coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath" + " require package.cpath package.loaded package.loadlib package.path package.preload");

            // Instruct the lexer to calculate folding
            scintilla1.SetProperty("fold", "1");
            scintilla1.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            scintilla1.Margins[2].Type = MarginType.Symbol;
            scintilla1.Margins[2].Mask = Marker.MaskFolders;
            scintilla1.Margins[2].Sensitive = true;
            scintilla1.Margins[2].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                scintilla1.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla1.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            scintilla1.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla1.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla1.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla1.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla1.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla1.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla1.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;




            // Enable automatic folding
            scintilla1.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
            scintilla1.Margins[0].Width = 16;

            //End textbox

            //this.listView1.Items = new WebClient().DownloadString("http://bleu.cloris.co/Scripts/").ToString();
            string Features = client.DownloadString("https://pastebin.com/raw/i4AiA4y5");
            label9.Text = Features;
            string Credits = client.DownloadString("https://pastebin.com/raw/LGRMxE7g");
            label1.Text = Credits;
            string LatestVersion = client.DownloadString("https://pastebin.com/raw/Sf503nZt");
            if (LatestVersion == Homepage.CURRENTVERSION)
            {
            }
            else
            {
                pictureBox2.Visible = true;
            }
            ghk = new KeyHandler(Keys.OemPipe, this);
            ghk.Register();
            string curFile = @"C:\Bleu\Auth.txt";
            if (File.Exists(curFile))
            {
                button12.Text = "Open Full Lua";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
                {
                    a.LaunchExploit();
                }
                else
                {
                    LaunchExploit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Does not have permission and cannot access YakaHack injecting files, Can be due to another YakaHack window being used or a Roblox Patch. To fix it you will need to restart or re-sign in. If you think this is a patch, make sure to check #patch_status at https://goo.gl/QFQJ5e (Error Code: " + ex.Message + ")");
            }
            bool flag = false;
            string str = this.ReadURL("https://cdn.wearedevs.net/software/exploitapi/latestdata.txt");
            if (str.Length > 0)
            {
                flag = Convert.ToBoolean(str.Split(' ')[0]);
                if (flag == true)
                {
                    Process[] _proceses = null;
                    _proceses = Process.GetProcessesByName("RobloxPlayerBeta");
                    foreach (Process proces in _proceses)
                    {
                        this.Text = "YakaHack [Attached]";
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
            LuaText.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //Top most checkbox
        {
            if (checkBox1.Checked == true)
            {
                //Do thing
                TopMost = true;
            }
            if (checkBox1.Checked == false)
            {
                //Undo thing
                TopMost = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.DoKill(textBox2.Text);
            }
            else
            {
                SendCommand("kill " + textBox2.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ws = "getglobal game\r\ngetfield -1 GetService\r\npushvalue -2\r\npushstring Players\r\npcall 2 1 0\r\ngetfield -1 LocalPlayer\r\ngetfield -1 Character\r\ngetfield -1 Humanoid\r\npushnumber " + textBox3.Text + "\r\nsetfield -2 WalkSpeed\r\nemptystack";
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.SendScript(ws);
            }
            else
            {
                MessageBox.Show("Theirs been issues with speed with V2, Switch to V1");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string jp = "getglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 Humanoid\npushnumber " + textBox3.Text + "\nsetfield -2 JumpPower\nemptystack";
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.SendScript(jp);
            }
            else
            {
                MessageBox.Show("Theirs been issues with jump power with V2, Switch to V1");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.ConsolePrint(textBox4.Text);
            }
            else
            {
                SendCommand("print " + textBox4.Text);
            }


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.ToggleClickTeleport();
            }
            else
            {
                MessageBox.Show("Theirs been issues with Ctrl Click Teleport with Api V2, Switch to V1");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TempCustomCode.Text = LuaText.Text;
            a.SendScript(TempCustomCode.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //PurchasePro BuyForm = new PurchasePro();
            //BuyForm.ShowDialog();
            System.Diagnostics.Process.Start("https://selly.gg/p/c1067335");
        }

            private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start("https://discord.gg/link");
            //System.Diagnostics.Process.Start("discord:///invite/zyqZWr2");
            //DIscord.Enabled = true;
            //geckoWebBrowser1.Navigate("http://google.com");
            //JoinServer.Join(Eramake.eCryptography.Decrypt(client.DownloadString("https://pastebin.com/raw/bKjYeTaY")));
            foreach (var process in Process.GetProcessesByName("Discord"))
            {
                Process.Start("discord:///channels/430381037093388289/430381037093388295");
            }
        }

        private void LuaText_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterPro PurchaseDialog = new RegisterPro();
            PurchaseDialog.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //colorDialog1.ShowDialog();

            //tabPage1.BackColor = colorDialog1.Color;
            ////tabPage2.BackColor = colorDialog1.Color;
            //tabPage3.BackColor = colorDialog1.Color;
            //tabPage4.BackColor = colorDialog1.Color;
            //tabPage5.BackColor = colorDialog1.Color;
            MessageBox.Show("This option is in rewritten.");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.AddFire(textBox2.Text);
            }
            else
            {
                SendCommand("fire " + textBox2.Text);
            }
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.AddSmoke(textBox2.Text);
            }
            else
            {
                SendCommand("smoke " + textBox2.Text);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.AddSparkles(textBox2.Text);
            }
            else
            {
                SendCommand("sparkles " + textBox2.Text);
            }
        }

        private void tabPage1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                try
                {
                    bool flag = false;
                    string str = this.ReadURL("https://cdn.wearedevs.net/software/exploitapi/latestdata.txt");
                    if (str.Length > 0)
                    {
                        flag = Convert.ToBoolean(str.Split(' ')[0]);
                        if (flag == true)
                        {
                            Process[] _proceses = null;
                            _proceses = Process.GetProcessesByName("RobloxPlayerBeta");
                            foreach (Process proces in _proceses)
                            {
                                this.Text = "YakaHack Rewritten [Attached]";
                                //System.Threading.Thread.Sleep(5000);
                                if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
                                {
                                    a.LaunchExploit();
                                }
                                else
                                {
                                    LaunchExploit();
                                }
                                timer2.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        int num = (int)MessageBox.Show("Could not check for the latest version. Did your fireall block us?", "Error");
                    }

                }
                catch
                {

                }
            }
            else
            {
                timer2.Enabled = false;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Work-In-Progress");
            //TempCustomCode.Text = "getglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 2\nsetfield -2 BinType\nemptystack\ngetglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 3\nsetfield -2 BinType\nemptystack\ngetglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 4\nsetfield -2 BinType\nemptystack";
            //SendLuaCScript(TempCustomCode.Text);
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                TempCustomCode.Text = "getglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 2\nsetfield -2 BinType\nemptystack\ngetglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 3\nsetfield -2 BinType\nemptystack\ngetglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 4\nsetfield -2 BinType\nemptystack";
                a.SendScript(TempCustomCode.Text);
            }
            else
            {
                SendCommand("btools " + textBox2.Text);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void DoOnStart_Tick(object sender, EventArgs e)
        {

            DoOnStart.Enabled = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.F1)
            {
                //textBox5.Visible = true;
            }
        }

        private void Form1_Show(object sender, EventArgs e)
        {
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://web.roblox.com/games/1626337608/Buy-YakaHack-Pro-Edition");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.DoFloat(textBox2.Text);
            }
            else
            {
                SendCommand("float " + textBox2.Text);
            }
        }

        

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //this.textBox6.Text = new WebClient().DownloadString("http://yakasoft.tk/Scripts/" + this.textBox7.Text).ToString();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://yakasoft.tk/Scripts/");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                if (scintilla1.TextLength >= 100)
                {
                    if (MessageBox.Show("This script is Very long, " + Application.ProductName + " or Roblox might crash if this is Executed", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                a.SendLimitedLuaScript(scintilla1.Text);
            }
            else
            {
                MessageBox.Show("Theirs been issues with Executing Limited Lua Scripts with V2, Switch to V1");
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Process[] _proceses = null;
                _proceses = Process.GetProcessesByName("EasyRP");
                foreach (Process proces in _proceses)
                {
                    proces.Kill();
                }
            }
            catch
            {

            }
            try
            {
                Process[] _proceses = null;
                _proceses = Process.GetProcessesByName("EasyRP Pro");
                foreach (Process proces in _proceses)
                {
                    proces.Kill();
                }
            }
            catch
            {

            }
            Properties.Settings.Default.Save();
        }

        private string ReadURL(string url)
        {
            return this.client.DownloadString(url);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            label12.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.CreateForceField(textBox2.Text);
            }
            else
            {
                SendCommand("ff " + textBox2.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.SendScript("getglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 Humanoid\npushstring x\nsetfield -2 Name\nemptystack\ngetglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 x\ngetfield -1 Clone\npushvalue -2\npcall 1 1 0\npushvalue -3\nsetfield -2 Parent\npushstring Humanoid\nsetfield -2 Name\nemptystack\ngetglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 x\ngetfield -1 Destroy\npushvalue -2\npcall 1 0 0\nemptystack\ngetglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 Humanoid\ngetglobal workspace\ngetfield -1 CurrentCamera\npushvalue -3\nsetfield -2 CameraSubject\nemptystack");
            }
            else
            {
                MessageBox.Show("Theirs been issues with God mode with V2 API, Switch to V1");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Visible = true;
            Properties.Settings.Default.Theme = comboBox1.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.SendScript("getglobal workspace\ngetglobal Instance\ngetfield -1 new\npushstring Sound\npushvalue -4\npcall 2 1 0\npushstring rbxassetid://" + textBox3.Text + "\nsetfield -2 SoundId\npushstring meme\nsetfield -2 Name\npushnumber 1\nsetfield -2 Volume\ngetfield -1 Play\npushvalue -2\npcall 1 0 0\nsettop 0");
            }
            else
            {
                MessageBox.Show("Theirs been issues with Music with V2 API, Switch to V1");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.SetSkyboxImage(textBox3.Text);
            }
            else
            {
                SendCommand("skybox " + textBox3.Text);
            }
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //api.SendScript("getglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetfield -1 Ice Dagger\ngetfield -1 Handle\ngetglobal Instance\ngetfield -1 new\npushstring SelectionBox\npushvalue -4\npcall 2 0 0\nemptystack\ngetglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetfield -1 Ice Dagger\ngetfield -1 Handle\ngetglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetfield -1 Ice Dagger\ngetfield -1 Handle\ngetfield -1 SelectionBox\npushvalue -8\nsetfield -2 Adornee\nemptystack\ngetglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetfield -1 Ice Dagger\ngetfield -1 Handle\ngetfield -1 SelectionBox\ngetglobal Color3\ngetfield -1 new\npushnumber 1\npushnumber 0\npushnumber 0\npcall 3 1 0\nsetfield -3 Color3\nemptystack\ngetglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetfield -1 Ice Dagger\ngetfield -1 Handle\ngetglobal Vector3\ngetfield -1 new\npushnumber 1\npushnumber 1\npushnumber 30\npcall 3 1 0\nsetfield -3 Size\nemptystack");
            MessageBox.Show("Work-In-Progress");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dynamic Plugin = JObject.Parse("{\r\n}");
                try
                {
                    Plugin = JObject.Parse(File.ReadAllText(openFileDialog2.FileName));
                }
                catch  (Exception ex)
                {
                    MessageBox.Show("YakaHack cannot parse plugin file. Error: " + ex.Message, "Cannot Parse Plugin file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //textBox1.Text = File.ReadAllText(openFileDialog2.FileName);
                if (Buttonone == false)
                {
                    CButton1 = File.ReadAllText(openFileDialog2.FileName);
                    button28.Text = Plugin.ButtonName;
                    Buttonone = true;
                    button28.Enabled = true;
                    return;
                }
                else
                {
                    if (Buttontwo == false)
                    {
                        button27.Text = Plugin.ButtonName;
                        CButton2 = File.ReadAllText(openFileDialog2.FileName);
                        Buttontwo = true;
                        button27.Enabled = true;
                        return;
                    }
                    else
                    {
                        if (Buttonthree == false)
                        {
                            button26.Text = Plugin.ButtonName;
                            CButton3 = File.ReadAllText(openFileDialog2.FileName);
                            Buttonthree = true;
                            button26.Enabled = true;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Custom buttons full");
                        }
                    }
                }
            }
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void button28_Click(object sender, EventArgs e)
        {

            //if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            //{
            //    TempCustomCode.Text = CButton1;
            //    SendLuaCScript(TempCustomCode.Text);
            //}
            //else
            //{
            //    MessageBox.Show("Theirs been issues with Plugins with V2 API, Switch to V1");
            //}
            Plugin pluginwindow = new Plugin(CButton1);
            pluginwindow.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                TempCustomCode.Text = CButton2;
                SendLuaCScript(TempCustomCode.Text);
            }
            else
            {
                MessageBox.Show("Theirs been issues with Plugins with V2 API, Switch to V1");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                TempCustomCode.Text = CButton3;
                SendLuaCScript(TempCustomCode.Text);
            }
            else
            {
                MessageBox.Show("Theirs been issues with Plugins with V2 API, Switch to V1");
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
                {
                    a.ForceBubbleChat(textBox2.Text, "Exploit Made by YakaHack");
                }
                else
                {
                    SendCommand("chat " + textBox2.Text + " " + "Exploit Made by YakaHack");
                }
                
            }
            else
            {
                if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
                {
                    a.ForceBubbleChat(textBox2.Text, textBox4.Text);
                }
                else
                {
                    SendCommand("chat " + textBox2.Text + " " + textBox4.Text);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (button12.Text == "Install Full Lua Package (PRO)")
            {
            string remoteUri = "https://yakov5776.github.io/YakaSoft-Products/";
            string fileName = "FullLua.exe", myStringWebResource = null;
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource, fileName);
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
            Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
            System.Threading.Thread.Sleep(3000);
            MessageBox.Show("Installed!");
            button12.Text = "Open Full Lua";
            }
            if (button12.Text == "Open Full Lua")
            {
                label13.Visible = true;
                timer3.Enabled = true;
                string remoteUri = "https://yakov5776.github.io/YakaSoft-Products/";
                string fileName = "DLL.exe", myStringWebResource = null;
                // Create a new WebClient instance.
                WebClient myWebClient = new WebClient();
                // Concatenate the domain with the Web resource filename.
                myStringWebResource = remoteUri + fileName;
                Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
                // Download the Web resource and save it into the current filesystem folder.
                myWebClient.DownloadFile(myStringWebResource, fileName);
                Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
                Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
                try
                {
                    System.Diagnostics.Process.Start(Application.StartupPath + @"\DLL.exe");
                }
                catch
                {
                }
                DLLInstalled = true;
                
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            string curFile3 = @"C:\Bleu\libcurl.dll";
            string curFile2 = @"C:\Bleu\LoadHack.dll";
            if (File.Exists(curFile2))
            {
                if (DLLInstalled == true)
                {
                    System.Diagnostics.Process.Start(Application.StartupPath + @"\Lua executer.exe");
                    label13.Visible = false;
                    DLLInstalled = false;
                    timer3.Enabled = false;
                }
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("If you de-activate, anyone else who knows your key can use it and activate Pro to their Computer, You're Sure you want to De-Activate?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string ActivatedKey = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\YakaHack\Key.txt");
                ActivatedKey = ActivatedKey.Replace("\r\n", string.Empty);
                string DeActivateLink = client.DownloadString("https://pastebin.com/raw/6EQpgRUx"); //Needs fixing
                string MyIP = client.DownloadString("https://api.ipify.org/?format=text");
                string DeActivate = client.DownloadString(DeActivateLink + "Key=" + ActivatedKey + "&MyIP=" + MyIP);
                //MessageBox.Show(client.DownloadString(DeActivateLink + "Key=" + ActivatedKey + "&MyIP=" + MyIP));
                Properties.Settings.Default.bois = "b";
                Properties.Settings.Default.Save();
                linkLabel1.Visible = false;
            }
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                a.SendLimitedLuaScript("game.StarterGui:SetCoreGuiEnabled(Enum.CoreGuiType.All,true)");
            }
            else
            {
                SendLimitedLuaScript("game.StarterGui:SetCoreGuiEnabled(Enum.CoreGuiType.All,true)");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("RobloxPlayerBeta"))
                {
                    process.Kill();
                }
            }
            catch
            {

            }
        }
        private KeyHandler ghk;

        private void timer4_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length > 0)
            {
                
            }
            else
            {
                this.Text = "YakaHack Rewritten";
            }

        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                if (textBox2.Text == "Me")
                {
                    a.SendScript("emptystack\ngetglobal game\ngetfield Workspace\ngetfield LocalPlayer\ngetfield Remove\npushvalue 11\nsetfield Noclip\npcall 2 1 0\nemptystack");
                }
                else
                {
                    if (textBox2.Text == "All")
                    {
                        a.SendScript("emptystack\ngetglobal game\ngetfield Workspace\ngetfield LocalPlayer\ngetfield Remove\npushvalue 11\nsetfield Noclip\npcall 2 1 0\nemptystack");
                    }
                    else
                    {
                        if (textBox2.Text == "me")
                        {
                            a.SendScript("emptystack\ngetglobal game\ngetfield Workspace\ngetfield LocalPlayer\ngetfield Remove\npushvalue 11\nsetfield Noclip\npcall 2 1 0\nemptystack");
                        }
                        else
                        {
                            a.SendScript("emptystack\ngetglobal game\ngetfield Workspace\ngetfield " + textBox2.Text + "\ngetfield Remove\npushvalue 11\nsetfield Noclip\npcall 2 1 0\nemptystack");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Theirs been issues with Noclip with V2 API, Switch to V1");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string PHPSite = client.DownloadString("https://pastebin.com/raw/zJ6QZHCW");
            string IP = client.DownloadString("https://api.ipify.org/?format=text");
            string BlockedIP = client.DownloadString("https://pastebin.com/raw/WP854rHN");
            if (BlockedIP.Contains(IP))
            {
                MessageBox.Show("This PC is Blocked");
                return;
            }
            if (textBox1.Text.Contains("@everyone"))
            {
                MessageBox.Show("No Pings allowed", "Nice try");
                return;
            }
            if (textBox1.Text.Contains("@here"))
            {
                MessageBox.Show("No Pings allowed", "Nice try");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please fill in fields", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (addEmailFieldToolStripMenuItem.Checked == true)
                {
                    if (addDiscordFieldToolStripMenuItem.Checked == true)
                    {
                        //Both fields
                        textBox10.Text = textBox9.Text.Replace("#", "%23");
                        webBrowser2.Navigate(PHPSite + textBox1.Text + "```Which has an email of: `" + textBox8.Text + "` and a discord of `" + textBox10.Text + "` and IP is: `" + IP + "` Rated: **" + Rate + "**");
                        sent();
                    }
                    else
                    {
                        //Only email
                        webBrowser2.Navigate(PHPSite + textBox1.Text + "```Which has an email of: `" + textBox8.Text + "` and IP is: `" + IP + "` Rated: **" + Rate + "**");
                        sent();
                    }
                }
                else
                {
                    if (addDiscordFieldToolStripMenuItem.Checked == true)
                    {
                        //Only Discord field
                        textBox10.Text = textBox9.Text.Replace("#", "%23");
                        webBrowser2.Navigate(PHPSite + textBox1.Text + "```Which has a discord of: `" + textBox10.Text + "` and IP is: `" + IP + "` Rated: **" + Rate + "**");
                        sent();
                    }
                    else
                    {
                        //No Extra fields
                        webBrowser2.Navigate(PHPSite + textBox1.Text + "``` and has a IP of: `" + IP + "` Rated: **" + Rate + "**");
                        sent();
                    }
                }
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            ChooseApi ApiSelection = new ChooseApi();
            ApiSelection.ShowDialog();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            label14.Text = "Current API: " + Properties.Settings.Default.ApiMode;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void addEmailFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addEmailFieldToolStripMenuItem.Checked = !addEmailFieldToolStripMenuItem.Checked;
            CheckCheckForTextbox();
        }

        private void addDiscordFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addDiscordFieldToolStripMenuItem.Checked = !addDiscordFieldToolStripMenuItem.Checked;
            CheckCheckForTextbox();
        }

        public void CheckCheckForTextbox()
        {
            if (addDiscordFieldToolStripMenuItem.Checked == true)
            {
                label17.Visible = true;
                textBox9.Visible = true;
            }
            else
            {
                label17.Visible = false;
                textBox9.Visible = false;
            }
            if (addEmailFieldToolStripMenuItem.Checked == true)
            {
                label16.Visible = true;
                textBox8.Visible = true;
            }
            else
            {
                label16.Visible = false;
                textBox8.Visible = false;
            }
        }
        public void sent()
        {
            MessageBox.Show("Message Sent!",
    "Bug Report", MessageBoxButtons.OK,
        MessageBoxIcon.Information);
            textBox8.Text = "";
            textBox9.Text = "";
            textBox1.Text = "";
            bunifuRating1.Value = 0;
        }
        

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string QuickCommand = textBox11.Text;
                string YCommand = "";
                string YPlayer = "";
                string YValue = "";
                textBox11.Text = "";
                textBox11.Visible = false;
                try
                {
                    YCommand = QuickCommand.Split(' ')[0];
                }
                catch
                {
                }
                try
                {
                    YPlayer = QuickCommand.Split(' ')[1];
                }
                catch
                {
                }
                try
                {
                    YValue = QuickCommand.Split(' ')[2];
                }
                catch
                {
                }
                if (YCommand == "fire")
                {
                    a.AddFire(YPlayer);
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "kill")
                {
                    a.DoKill(YPlayer);
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "sit")
                {
                    a.SendLimitedLuaScript("game.Players.LocalPlayer.Character.Humanoid.Sit = true");
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "ws")
                {
                    string ws = "getglobal game\r\ngetfield -1 GetService\r\npushvalue -2\r\npushstring Players\r\npcall 2 1 0\r\ngetfield -1 LocalPlayer\r\ngetfield -1 Character\r\ngetfield -1 Humanoid\r\npushnumber " + YValue + "\r\nsetfield -2 WalkSpeed\r\nemptystack";
                    a.SendScript(ws);
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "speed")
                {
                    string ws = "getglobal game\r\ngetfield -1 GetService\r\npushvalue -2\r\npushstring Players\r\npcall 2 1 0\r\ngetfield -1 LocalPlayer\r\ngetfield -1 Character\r\ngetfield -1 Humanoid\r\npushnumber " + YValue + "\r\nsetfield -2 WalkSpeed\r\nemptystack";
                    a.SendScript(ws);
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "jp")
                {
                    string jp = "getglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 Humanoid\npushnumber " + YValue + "\nsetfield -2 JumpPower\nemptystack";
                    a.SendScript(jp);
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "ff")
                {
                    a.CreateForceField(YPlayer);
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "smoke")
                {
                    a.AddSmoke(YPlayer);
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "sparkles")
                {
                    a.AddSparkles(YPlayer);
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "btools")
                {
                    TempCustomCode.Text = "getglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 2\nsetfield -2 BinType\nemptystack\ngetglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 3\nsetfield -2 BinType\nemptystack\ngetglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 4\nsetfield -2 BinType\nemptystack";
                    a.SendScript(TempCustomCode.Text);
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "cmds")
                {
                    cmdbarcmds cmds = new cmdbarcmds();
                    cmds.ShowDialog();
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                if (YCommand == "inject")
                {
                    try
                    {
                        if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
                        {
                            a.LaunchExploit();
                        }
                        else
                        {
                            LaunchExploit();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Does not have permission and cannot access YakaHack injecting files, Can be due to another YakaHack window being used or a Roblox Patch. To fix it you will need to restart or re-sign in. If you think this is a patch, make sure to check #patch_status at https://goo.gl/mSYkRS");
                    }
                    bool flag = false;
                    string str = this.ReadURL("https://pastebin.com/raw/Ly9mJwH7");
                    if (str.Length > 0)
                    {
                        flag = Convert.ToBoolean(str.Split(' ')[0]);
                        if (flag == true)
                        {
                            Process[] _proceses = null;
                            _proceses = Process.GetProcessesByName("RobloxPlayerBeta");
                            foreach (Process proces in _proceses)
                            {
                                this.Text = "YakaHack Rewritten [Attached]";
                            }
                        }
                    }
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    return;
                }
                MessageBox.Show("Not a Valid Command");
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;

            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"To Activate Command bar hotkey, Press Backslash '\' anytime to activate Command bar, type 'cmds' in command bar to view all commands. make sure you checked the Command bar Checkbox.");
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string LatestVersion = client.DownloadString("https://pastebin.com/raw/Sf503nZt");
            if (LatestVersion == Homepage.CURRENTVERSION)
            {
            }
            else
            {
                pictureBox2.Visible = true;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default.FeMessage == true)
            //{
            //    FeWarningDialog FeWarning = new FeWarningDialog();
            //    FeWarning.ShowDialog();
            //}
            //if (textBox2.Text == "Me")
            //{
            //    api.SendScript("getglobal game\ngetfield Workspace\ngetfield LocalPlayer\ngetfield Remove\npushvalue -4\npcall 2 1 0\nemptystack");
            //}
            //else
            //{
            //    api.SendScript("getglobal game\ngetfield Workspace\ngetfield " + textBox2.Text + "\ngetfield Remove\npushvalue -4\npcall 2 1 0\nemptystack");
            //}
            a.SendLimitedLuaScript("AnimationId = '248263260'\nlocal Anim = Instance.new('Animation')\nAnim.AnimationId = 'rbxassetid://'..AnimationId\nlocal k = game.Players.LocalPlayer.Character.Humanoid:LoadAnimation(Anim)\nk:Play()\nk:AdjustSpeed(1)");
        }

        private void button37_Click(object sender, EventArgs e)
        {
            string AdminKey = client.DownloadString("http://yakasoftapi.ml/Files/AdminPanel/Check.php?MasterKey=" + textBox12.Text);
            if (AdminKey == "Correct\n")
            {
                AdminKey = textBox12.Text;
                AdminPanel Admin = new AdminPanel();
                Admin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong Code", "Nope");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button is currently broken, we'll fix it as soon as Possible.");
            string Fly = client.DownloadString("https://pastebin.com/raw/Fd5zpdyh");
            a.SendLimitedLuaScript(Fly);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            string admin = client.DownloadString("https://pastebin.com/raw/RRJTKjkj");
            a.SendLimitedLuaScript(admin);
        }
        private string getScriptLibrary()
        {
            string result = "No internet, Cannot Fetch Scripts";
            try
            {
               result = new WebClient().DownloadString("http://yakasoftapi.ml/Files/RawScriptNames.php");
            }
            catch
            {
                result = "No internet, Cannot Fetch Scripts";
            }
            return result;
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            scintilla1.Text = client.DownloadString("http://yakasoftapi.ml/Files/Scripts/" + listBox1.GetItemText(listBox1.SelectedItem));
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == true)
            {
                listBox1.Visible = false;
                return;
            }
            this.listBox1.Items.Clear();
            try
            {
                string ScriptString = this.getScriptLibrary();
                char[] separator = new char[]
                {
                    '!'
                };
                string[] array = ScriptString.Split(separator);
                foreach (string line in array)
                {

                    this.listBox1.Items.Add(line);

                }
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
            }
            catch
            {
                this.listBox1.Items.Add("Unable to fetch script list.");
            }
            listBox1.Visible = true;
        }

        private void DIscord_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("discord:///app");
            DIscord.Enabled = false;
        }

        private void bunifuRating1_onValueChanged(object sender, EventArgs e)
        {
            Rate = bunifuRating1.Value.ToString();
            if (Rate == "0")
            {
                Rate = "Didn't rate";
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(1, label1.Text.Length - 1) + label1.Text.Substring(0, 1);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            button41.Visible = false;
            DontShow = true;
            if (listBox1.Visible == true)
            {
                listBox1.Visible = false;
                splitter1.Visible = false;
                panel3.Visible = false;
                return;
            }
            this.listBox1.Items.Clear();
            try
            {
                string ScriptString = this.getScriptLibrary();
                char[] separator = new char[]
                {
                    '!'
                };
                string[] array = ScriptString.Split(separator);
                foreach (string line in array)
                {

                    this.listBox1.Items.Add(line);

                }
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
            }
            catch
            {
                this.listBox1.Items.Add("Unable to fetch script list.");
            }
            listBox1.Visible = true;
            splitter1.Visible = true;
            panel3.Visible = true;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ApiMode == "WeAreDevs API V1")
            {
                if (scintilla1.TextLength >= 100)
                {
                    if (MessageBox.Show("This script is Very long, " + Application.ProductName + " or Roblox might crash if this is Executed", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                a.SendLimitedLuaScript(scintilla1.Text);
            }
            else
            {
                MessageBox.Show("Theirs been issues with Executing Limited Lua Scripts with V2, Switch to V1");
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                button42.Visible = true;
                if (!DontShow) { button41.Visible = true; }
            }
            else
            {
                button42.Visible = false;
                button41.Visible = false;
            }
        }
    }
}
