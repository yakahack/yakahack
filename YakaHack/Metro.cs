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
using ScintillaNET;
using System.Runtime.InteropServices;
using WeAreDevs_API;

namespace YakaHack
{
    public partial class Metro : Form
    {
        ExploitAPI api = new ExploitAPI();
        int TogMove;
        int MValX;
        int MValY;
        private WebClient client = new WebClient();
        public Metro()
        {
            InitializeComponent();
        }
        private string ReadURL(string url)
        {
            return this.client.DownloadString(url);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
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

        private void Metro_Load(object sender, EventArgs e)
        {
            RefreshColor();
            Classic.Text = "Metro";
            label12.Visible = false;
                linkLabel3.Visible = false;
                button11.Enabled = false;
                //button13.Enabled = true;
                button18.Enabled = false;
                Classic.Enabled = true;
            //Start Textbox
            var alphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Not sure what the next 3 lines are :/
            var numericChars = "0123456789";
            var accentedChars = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";

            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            scintilla1.StyleResetDefault();
            scintilla1.Styles[Style.Default].Font = "Consolas";
            scintilla1.Styles[Style.Default].Size = 10;
            scintilla1.Styles[Style.Default].ForeColor = Color.White;
            scintilla1.Styles[Style.Default].BackColor = Color.DarkGray;

            scintilla1.StyleClearAll();



            // Configure the Lua lexer styles
            scintilla1.Styles[Style.Lua.Default].ForeColor = Color.Silver;
            scintilla1.Styles[Style.Lua.Comment].ForeColor = Color.Green;
            scintilla1.Styles[Style.Lua.CommentLine].ForeColor = Color.Green;
            scintilla1.Styles[Style.Lua.Number].ForeColor = Color.Olive;
            scintilla1.Styles[Style.Lua.Word].ForeColor = Color.Blue;
            scintilla1.Styles[Style.Lua.Word2].ForeColor = Color.BlueViolet;
            scintilla1.Styles[Style.Lua.Word3].ForeColor = Color.DarkSlateBlue;
            scintilla1.Styles[Style.Lua.Word4].ForeColor = Color.DarkSlateBlue;
            scintilla1.Styles[Style.Lua.String].ForeColor = Color.Red;
            scintilla1.Styles[Style.Lua.Character].ForeColor = Color.Red;
            scintilla1.Styles[Style.Lua.LiteralString].ForeColor = Color.Red;
            scintilla1.Styles[Style.Lua.StringEol].BackColor = Color.Pink;
            scintilla1.Styles[Style.Lua.Operator].ForeColor = Color.Purple;
            scintilla1.Styles[Style.Lua.Preprocessor].ForeColor = Color.Maroon;
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
            //End textbox
            string Features = client.DownloadString("https://pastebin.com/raw/i4AiA4y5");
            label9.Text = Features;
            string Credits = client.DownloadString("https://pastebin.com/raw/LGRMxE7g");
            label1.Text = Credits;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
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
                        this.Text = "YakaHack [Attached]";
                    }
                }
            }
        }




        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            label12.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Visible = true;
            Properties.Settings.Default.Theme = Classic.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterPro ShowPurchasePage = new RegisterPro();
            ShowPurchasePage.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            api.SendLimitedLuaScript(scintilla1.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox1.Checked == true)
            {
                //Do thing
                TopMost = true;
            }
            if (materialCheckBox1.Checked == false)
            {
                //Undo thing
                TopMost = false;
            }
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            try
            {
                api.LaunchExploit();
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
                        materialLabel5.Text = "YakaHack [Attached]";
                    }
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length > 0)
            {

            }
            else
            {
                materialLabel5.Text = "YakaHack";
            }
        }

        private void materialRaisedButton24_Click(object sender, EventArgs e)
        {
            api.DoKill(materialSingleLineTextField1.Text);
        }

        private void materialRaisedButton22_Click(object sender, EventArgs e)
        {
            api.CreateForceField(materialSingleLineTextField1.Text);
        }

        private void materialRaisedButton23_Click(object sender, EventArgs e)
        {
            api.SendScript("getglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 Humanoid\npushstring x\nsetfield -2 Name\nemptystack\ngetglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 x\ngetfield -1 Clone\npushvalue -2\npcall 1 1 0\npushvalue -3\nsetfield -2 Parent\npushstring Humanoid\nsetfield -2 Name\nemptystack\ngetglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 x\ngetfield -1 Destroy\npushvalue -2\npcall 1 0 0\nemptystack\ngetglobal game\ngetfield -1 Players\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 Humanoid\ngetglobal workspace\ngetfield -1 CurrentCamera\npushvalue -3\nsetfield -2 CameraSubject\nemptystack");
        }

        private void materialRaisedButton21_Click(object sender, EventArgs e)
        {
            api.DoFloat(materialSingleLineTextField1.Text);
        }

        private void materialRaisedButton20_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work-In-Progress");
        }

        private void materialRaisedButton19_Click(object sender, EventArgs e)
        {
            api.SendScript("getglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 2\nsetfield -2 BinType\nemptystack\ngetglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 3\nsetfield -2 BinType\nemptystack\ngetglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Backpack\ngetglobal Instance\ngetfield -1 new\npushstring HopperBin\npushvalue -4\npcall 2 1 0\npushnumber 4\nsetfield -2 BinType\nemptystack");
        }

        private void materialRaisedButton18_Click(object sender, EventArgs e)
        {
            api.AddFire(materialSingleLineTextField1.Text);
        }

        private void materialRaisedButton17_Click(object sender, EventArgs e)
        {
            api.AddSmoke(materialSingleLineTextField1.Text);
        }

        private void materialRaisedButton25_Click(object sender, EventArgs e)
        {
            api.AddSparkles(materialSingleLineTextField1.Text);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            api.SendScript("getglobal game\r\ngetfield -1 GetService\r\npushvalue -2\r\npushstring Players\r\npcall 2 1 0\r\ngetfield -1 LocalPlayer\r\ngetfield -1 Character\r\ngetfield -1 Humanoid\r\npushnumber " + materialSingleLineTextField2.Text + "\r\nsetfield -2 WalkSpeed\r\nemptystack");
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            api.SendScript("getglobal game\ngetfield -1 GetService\npushvalue -2\npushstring Players\npcall 2 1 0\ngetfield -1 LocalPlayer\ngetfield -1 Character\ngetfield -1 Humanoid\npushnumber " + materialSingleLineTextField2.Text + "\nsetfield -2 JumpPower\nemptystack");
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            api.SendScript("getglobal workspace\ngetglobal Instance\ngetfield -1 new\npushstring Sound\npushvalue -4\npcall 2 1 0\npushstring rbxassetid://" + materialSingleLineTextField2.Text + "\nsetfield -2 SoundId\npushstring meme\nsetfield -2 Name\npushnumber 1\nsetfield -2 Volume\ngetfield -1 Play\npushvalue -2\npcall 1 0 0\nsettop 0");
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            api.SetSkyboxImage(materialSingleLineTextField2.Text);
        }

        private void materialRaisedButton16_Click(object sender, EventArgs e)
        {
            api.ConsolePrint(materialSingleLineTextField3.Text);
        }

        private void materialRaisedButton15_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField3.Text == "")
            {
                api.ForceBubbleChat(materialSingleLineTextField2.Text, "Exploit Made by YakaHack");
            }
            else
                api.ForceBubbleChat(materialSingleLineTextField2.Text, materialSingleLineTextField3.Text);
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            api.TeleportMyCharacterTo(materialSingleLineTextField4.Text);
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            api.SendLimitedLuaScript("game.StarterGui:SetCoreGuiEnabled(Enum.CoreGuiType.All,true)");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            api.SendScript(LuaText.Text);
        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            if (scintilla1.TextLength >= 100)
            {
                if (MessageBox.Show("This script is Very long, " + Application.ProductName + " or Roblox might crash if this is Executed", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }
            }
            api.SendLimitedLuaScript(scintilla1.Text);
        }
        public void RefreshColor()
        {
            materialLabel2.ForeColor = Color.White;
            materialLabel3.ForeColor = Color.White;
            materialLabel4.ForeColor = Color.White;
            materialLabel5.ForeColor = Color.White;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.BackColor = ColorHover.Color;
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            label6.BackColor = ColorHold.Color;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.BackColor = Color.DodgerBlue;
        }

        private void label6_MouseUp(object sender, MouseEventArgs e)
        {
            label6.BackColor = Color.DodgerBlue;
        }
    }
}
