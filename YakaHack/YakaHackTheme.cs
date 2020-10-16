using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using WeAreDevs_API;
using System.Windows.Forms.VisualStyles;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace YakaHack
{
    // Token: 0x02000007 RID: 7
    public partial class YakaHackTheme : Form
    {
        //start
        private bool Drag;
        private int MouseX;
        private int MouseY;
        FastColoredTextBoxNS.Style CommentStyle = new TextStyle(Brushes.ForestGreen, null, FontStyle.Regular);
        FastColoredTextBoxNS.Style Style1 = new TextStyle(Brushes.SkyBlue, null, FontStyle.Regular);
        FastColoredTextBoxNS.Style StringStyle = new TextStyle(Brushes.LightCoral, null, FontStyle.Regular);

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }

        //end
        Color BorderFocus = Color.FromArgb(0, 122, 204);
        Color BorderNonFocus = Color.FromArgb(66, 66, 69);
        private WebClient client = new WebClient();
        private Point Mouselocation;
        ExploitAPI api = new ExploitAPI();
        int Tabs = 1;
        int CurrentTab = 1;
        int UpTo = 1;
        int TogMove;
        int MValX;
        int MValY;
        bool Bleu = false;
        bool Tab1SavedBefore = false;
        bool Tab2SavedBefore = false;
        bool Tab3SavedBefore = false;
        bool Reset = false;
        bool Reset2 = false;
        bool Injected = false;
        string Tab1Dir;
        string Tab2Dir;
        string Tab3Dir;
        string Tab1Data;
        string Tab2Data;
        string Tab3Data;
        // Token: 0x06000033 RID: 51
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string command, string buffer, long bufferSize, long hwndCallback);

        // Token: 0x06000034 RID: 52
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        // Token: 0x06000035 RID: 53
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        // Token: 0x06000036 RID: 54
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        // Token: 0x06000037 RID: 55
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        // Token: 0x06000038 RID: 56
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        // Token: 0x06000039 RID: 57
        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        // Token: 0x0600003A RID: 58
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x0600003B RID: 59 RVA: 0x00005C85 File Offset: 0x00003E85
        public IntPtr MainWindowHandle { get; }

        // Token: 0x0600003C RID: 60 RVA: 0x00005C90 File Offset: 0x00003E90
        public YakaHackTheme()
        {
            this.InitializeComponent();
        }

        // Token: 0x0600003D RID: 61 RVA: 0x00005E20 File Offset: 0x00004020
        private int Inject(string dllName)
        {
            int result;
            try
            {
                Process process = Process.GetProcessesByName("RobloxPlayerBeta")[0];
                bool flag = process != null;
                if (flag)
                {
                    bool flag2 = process.MainWindowHandle.ToInt32() != 0;
                    if (flag2)
                    {
                        IntPtr hProcess = YakaHackTheme.OpenProcess(1082, false, process.Id);
                        IntPtr procAddress = YakaHackTheme.GetProcAddress(YakaHackTheme.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                        IntPtr intPtr = YakaHackTheme.VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), 12288u, 4u);
                        UIntPtr uintPtr;
                        YakaHackTheme.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out uintPtr);
                        YakaHackTheme.CreateRemoteThread(hProcess, IntPtr.Zero, 0u, procAddress, intPtr, 0u, IntPtr.Zero);

                        this.Text = "Bleu [Hooked]";
                    }
                }
                else
                {
                    File.Create("00");
                }
                result = 0;
            }
            catch (Exception ex)
            {

                this.Text = "Bleu";
                result = 0;
            }
            return result;
        }

        // Token: 0x0600003E RID: 62 RVA: 0x00005F88 File Offset: 0x00004188
        public void SendInput(int Mode, int Type, string Data)
        {
            try
            {
                File.WriteAllText("C:/Bleu/INPUT", Mode.ToString() + Type.ToString() + Data);
            }
            catch
            {
            }
        }

        // Token: 0x0600003F RID: 63 RVA: 0x00005FD0 File Offset: 0x000041D0
        public void ReceiveOutput(int Mode, int Type, string Data)
        {
            bool flag = Mode == this.OUTPUT_BLEUOUTPUT;
            if (!flag)
            {
                bool flag2 = Mode == this.OUTPUT_MESSAGE;
                if (flag2)
                {
                    bool flag3 = Type == this.TYPE_WARNINGICON;
                    if (flag3)
                    {
                        MessageBox.Show(Data, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        bool flag4 = Type == this.TYPE_ERRORICON;
                        if (flag4)
                        {
                            MessageBox.Show(Data, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            bool flag5 = Type == this.TYPE_INFORMATIONICON;
                            if (flag5)
                            {
                                MessageBox.Show(Data, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06000040 RID: 64 RVA: 0x00006060 File Offset: 0x00004260
        private async void AnimationTimer_Tick(object sender, EventArgs e)
        {
            this.AnimationTimer.Stop();
            for (int i = 1; i <= 9; i++)
            {
                base.Opacity += 0.1;
                await Task.Delay(1);
            }
            base.Opacity = 0.95;
        }

        // Token: 0x06000041 RID: 65 RVA: 0x000060AC File Offset: 0x000042AC
        private string getOSInfo()
        {
            OperatingSystem osversion = Environment.OSVersion;
            Version version = osversion.Version;
            string text = "";
            bool flag = osversion.Platform == PlatformID.Win32Windows;
            if (flag)
            {
                int minor = version.Minor;
                if (minor != 0)
                {
                    if (minor != 10)
                    {
                        if (minor == 90)
                        {
                            text = "Me";
                        }
                    }
                    else
                    {
                        bool flag2 = version.Revision.ToString() == "2222A";
                        if (flag2)
                        {
                            text = "98SE";
                        }
                        else
                        {
                            text = "98";
                        }
                    }
                }
                else
                {
                    text = "95";
                }
            }
            else
            {
                bool flag3 = osversion.Platform == PlatformID.Win32NT;
                if (flag3)
                {
                    switch (version.Major)
                    {
                        case 3:
                            text = "NT 3.51";
                            break;
                        case 4:
                            text = "NT 4.0";
                            break;
                        case 5:
                            {
                                bool flag4 = version.Minor == 0;
                                if (flag4)
                                {
                                    text = "2000";
                                }
                                else
                                {
                                    text = "XP";
                                }
                                break;
                            }
                        case 6:
                            {
                                bool flag5 = version.Minor == 0;
                                if (flag5)
                                {
                                    text = "Vista";
                                }
                                else
                                {
                                    bool flag6 = version.Minor == 1;
                                    if (flag6)
                                    {
                                        text = "7";
                                    }
                                    else
                                    {
                                        bool flag7 = version.Minor == 2;
                                        if (flag7)
                                        {
                                            text = "8";
                                        }
                                        else
                                        {
                                            text = "8.1";
                                        }
                                    }
                                }
                                break;
                            }
                        case 10:
                            text = "10";
                            break;
                    }
                }
            }
            bool flag8 = text != "";
            if (flag8)
            {
                text = "Windows " + text;
            }
            return text;
        }

        // Token: 0x06000042 RID: 66
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, string lpstrReturnString, uint uReturnLength, uint hWndCallback);

        // Token: 0x06000043 RID: 67 RVA: 0x00006238 File Offset: 0x00004438
        private void Main_Load(object sender, EventArgs e)
        {
            //Light();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            string Username = Environment.UserName;
            label11.Text = Username;
            label12.Text = Username.Substring(0, 1);
            bool flag = this.getOSInfo() == "Windows 7";
            if (flag)
            {
                this.button19.PerformClick();
                this.button19.Visible = false;
                this.InjectButton.Size = this.button19.Size + new Size(40, 0);
            }
            if (Bleu == true)
            {
                this.TextEditorTick.Start();
                this.DELETELOGS.Start();
                YakaHackTheme.SendMessage(this.CmdBox.Handle, 5377, 0, "Command prefix is \";\" ");
                this.OutputCheck.Start();
                this.Injector.Start();
            }
            base.Focus();
            this.AnimationTimer.Start();
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string str2 = "0123456789";
            string str3 = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";
            
        }

        // Token: 0x06000044 RID: 68 RVA: 0x0000678C File Offset: 0x0000498C
        private async void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Process.GetCurrentProcess().Kill();
        }

        // Token: 0x06000045 RID: 69 RVA: 0x000067D8 File Offset: 0x000049D8
        private async void Main_Deactivate(object sender, EventArgs e)
        {
            label1.BackColor = BorderNonFocus;
            label2.BackColor = BorderNonFocus;
            label3.BackColor = BorderNonFocus;
            label4.BackColor = BorderNonFocus;
            this.Active = false;
            base.Opacity = 0.95;
            for (int i = 1; i <= 20; i++)
            {
                bool flag = !this.Active;
                if (flag)
                {
                    base.Opacity -= 0.01;
                    await Task.Delay(1);
                }
            }
        }

        // Token: 0x06000046 RID: 70 RVA: 0x00006824 File Offset: 0x00004A24
        private async void Main_Activated(object sender, EventArgs e)
        {
            label1.BackColor = BorderFocus;
            label2.BackColor = BorderFocus;
            label3.BackColor = BorderFocus;
            label4.BackColor = BorderFocus;
            this.Active = true;
            base.Opacity = 0.75;
            for (int i = 1; i <= 20; i++)
            {
                bool active = this.Active;
                if (active)
                {
                    base.Opacity += 0.01;
                    await Task.Delay(1);
                }
            }
        }

        // Token: 0x06000047 RID: 71 RVA: 0x0000686E File Offset: 0x00004A6E
        private void Main_MouseEnter(object sender, EventArgs e)
        {
            //base.Focus();
        }

        // Token: 0x06000048 RID: 72 RVA: 0x0000686E File Offset: 0x00004A6E
        private void Main_MouseHover(object sender, EventArgs e)
        {
            //base.Focus();
        }

        // Token: 0x06000049 RID: 73 RVA: 0x00006878 File Offset: 0x00004A78
        private async void button12_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x0600004A RID: 74 RVA: 0x000068C4 File Offset: 0x00004AC4
        private async void button13_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x0600004B RID: 75 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        // Token: 0x0600004C RID: 76 RVA: 0x00006910 File Offset: 0x00004B10


        // Token: 0x0600004D RID: 77 RVA: 0x00006984 File Offset: 0x00004B84
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (Bleu == true)
            {
                bool cache = this.Cache;
                if (cache)
                {
                    this.SendInput(this.INPUT_EXECUTE, 0, "spawn(function() " + this.fastColoredTextBox1.Text + "\nend)");
                }
                else
                {
                    this.SendInput(this.INPUT_FASTEXECUTE, 0, "spawn(function() " + this.fastColoredTextBox1.Text + "\nend)");
                }
            }
            else
            {
                if (Injected == false)
                {
                    api.LaunchExploit();
                    Injected = true;
                }
                else
                {
                    api.SendLimitedLuaScript(fastColoredTextBox1.Text);
                }
            }
        }

        // Token: 0x0600004E RID: 78 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button1_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x0600004F RID: 79 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button2_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000050 RID: 80 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button20_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000051 RID: 81 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button10_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000052 RID: 82 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button11_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000053 RID: 83 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button9_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000054 RID: 84 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button3_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000055 RID: 85 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button4_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000056 RID: 86 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button5_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000057 RID: 87 RVA: 0x000069F2 File Offset: 0x00004BF2
        private void button6_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Cut();
        }

        // Token: 0x06000058 RID: 88 RVA: 0x00006A01 File Offset: 0x00004C01
        private void button7_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Copy();
        }

        // Token: 0x06000059 RID: 89 RVA: 0x00006A10 File Offset: 0x00004C10
        private void button8_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Paste();
        }

        // Token: 0x0600005A RID: 90 RVA: 0x00006A20 File Offset: 0x00004C20
        private void button14_Click(object sender, EventArgs e)
        {
            bool matchCase = this.MatchCase;
            if (matchCase)
            {
                this.MatchCase = false;
                this.button21.BackColor = Color.FromArgb(44, 44, 44);
            }
            else
            {
                this.MatchCase = true;
                this.button21.BackColor = Color.FromArgb(64, 64, 64);
            }
        }

        // Token: 0x0600005B RID: 91 RVA: 0x00006A7C File Offset: 0x00004C7C
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Position = 1;
            try
            {
                bool flag = !this.MatchCase;
                string text;
                string value;
                if (flag)
                {
                    text = this.fastColoredTextBox1.Text.ToLower();
                    value = this.FindBox.Text.ToLower();
                }
                else
                {
                    text = this.fastColoredTextBox1.Text;
                    value = this.FindBox.Text;
                }
                bool flag2 = text.LastIndexOf(value) != -1;
                if (flag2)
                {
                    //List<int> list = text.AllIndexesOf(value);
                    //this.fastColoredTextBox1.SelectionStart = list[this.Position - 1];
                    //this.fastColoredTextBox1.SelectionEnd = this.FindBox.Text.Length + list[this.Position - 1];
                    //this.ResultLabel.Text = this.Position.ToString() + " of " + list.Count.ToString() + " matches";
                }
                else
                {
                    this.ResultLabel.Text = "0 matches";
                }
            }
            catch
            {
                this.ResultLabel.Text = "";
            }
        }

        // Token: 0x0600005C RID: 92 RVA: 0x00006BC8 File Offset: 0x00004DC8
        private void FindBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool shift = e.Shift;
            if (shift)
            {
                bool flag = e.KeyCode == Keys.Return;
                if (flag)
                {
                    try
                    {
                        bool flag2 = !this.MatchCase;
                        string str;
                        string value;
                        if (flag2)
                        {
                            str = this.fastColoredTextBox1.Text.ToLower();
                            value = this.FindBox.Text.ToLower();
                        }
                        else
                        {
                            str = this.fastColoredTextBox1.Text;
                            value = this.FindBox.Text;
                        }
                        this.Position--;
                        //List<int> list = str.AllIndexesOf(value);
                        //this.fastColoredTextBox1.SelectionStart = list[this.Position - 1];
                        //this.fastColoredTextBox1.SelectionEnd = this.FindBox.Text.Length + list[this.Position - 1];
                        this.fastColoredTextBox1.Select();
                        //this.fastColoredTextBox1.ScrollCaret();
                        //this.ResultLabel.Text = this.Position.ToString() + " of " + list.Count.ToString() + " matches";
                        e.SuppressKeyPress = true;
                    }
                    catch
                    {
                        try
                        {
                            bool flag3 = !this.MatchCase;
                            string str2;
                            string value2;
                            if (flag3)
                            {
                                str2 = this.fastColoredTextBox1.Text.ToLower();
                                value2 = this.FindBox.Text.ToLower();
                            }
                            else
                            {
                                str2 = this.fastColoredTextBox1.Text;
                                value2 = this.FindBox.Text;
                            }
                            //List<int> list2 = str2.AllIndexesOf(value2);
                            //this.Position = list2.Count<int>();
                            //this.fastColoredTextBox1.SelectionStart = list2[this.Position - 1];
                            //this.fastColoredTextBox1.SelectionEnd = this.FindBox.Text.Length + list2[this.Position - 1];
                            this.fastColoredTextBox1.Select();
                            //this.fastColoredTextBox1.ScrollCaret();
                            //this.ResultLabel.Text = this.Position.ToString() + " of " + list2.Count.ToString() + " matches";
                        }
                        catch
                        {
                        }
                    }
                    this.FindBox.Focus();
                }
            }
            else
            {
                try
                {
                    bool flag4 = !this.MatchCase;
                    string str3;
                    string value3;
                    if (flag4)
                    {
                        str3 = this.fastColoredTextBox1.Text.ToLower();
                        value3 = this.FindBox.Text.ToLower();
                    }
                    else
                    {
                        str3 = this.fastColoredTextBox1.Text;
                        value3 = this.FindBox.Text;
                    }
                    this.Position++;
                    //List<int> list3 = str3.AllIndexesOf(value3);
                    //this.fastColoredTextBox1.SelectionStart = list3[this.Position - 1];
                    //this.fastColoredTextBox1.SelectionEnd = this.FindBox.Text.Length + list3[this.Position - 1];
                    this.fastColoredTextBox1.Select();
                    //this.fastColoredTextBox1.ScrollCaret();
                    //this.ResultLabel.Text = this.Position.ToString() + " of " + list3.Count.ToString() + " matches";
                    bool flag5 = e.KeyCode == Keys.Return;
                    if (flag5)
                    {
                        e.SuppressKeyPress = true;
                    }
                }
                catch
                {
                    try
                    {
                        bool flag6 = !this.MatchCase;
                        string str4;
                        string value4;
                        if (flag6)
                        {
                            str4 = this.fastColoredTextBox1.Text.ToLower();
                            value4 = this.FindBox.Text.ToLower();
                        }
                        else
                        {
                            str4 = this.fastColoredTextBox1.Text;
                            value4 = this.FindBox.Text;
                        }
                        //List<int> list4 = str4.AllIndexesOf(value4);
                        this.Position = 1;
                        //this.fastColoredTextBox1.SelectionStart = list4[this.Position - 1];
                        //this.fastColoredTextBox1.SelectionEnd = this.FindBox.Text.Length + list4[this.Position - 1];
                        this.fastColoredTextBox1.Select();
                        //this.fastColoredTextBox1.ScrollCaret();
                        //this.ResultLabel.Text = this.Position.ToString() + " of " + list4.Count.ToString() + " matches";
                        bool flag7 = e.KeyCode == Keys.Return;
                        if (flag7)
                        {
                            e.SuppressKeyPress = true;
                        }
                    }
                    catch
                    {
                    }
                }
                this.FindBox.Focus();
            }
        }

        // Token: 0x0600005D RID: 93 RVA: 0x000070D8 File Offset: 0x000052D8
        private void FindClose_Click(object sender, EventArgs e)
        {
            //this.FindPanel.Visible = false;
        }

        // Token: 0x0600005E RID: 94 RVA: 0x000070E8 File Offset: 0x000052E8
        private void fastColoredTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //bool flag = e.Control && e.KeyCode == Keys.F;
            //if (flag)
            //{
            //	e.SuppressKeyPress = true;
            //	this.FindPanel.Visible = true;
            //	this.FindBox.Focus();
            //}
        }

        // Token: 0x0600005F RID: 95 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void fastColoredTextBox1_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000060 RID: 96 RVA: 0x00007134 File Offset: 0x00005334
        private void FindBack_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = !this.MatchCase;
                string str;
                string value;
                if (flag)
                {
                    str = this.fastColoredTextBox1.Text.ToLower();
                    value = this.FindBox.Text.ToLower();
                }
                else
                {
                    str = this.fastColoredTextBox1.Text;
                    value = this.FindBox.Text;
                }
                this.Position--;
                //List<int> list = str.AllIndexesOf(value);
                //this.fastColoredTextBox1.SelectionStart = list[this.Position - 1];
                //this.fastColoredTextBox1.SelectionEnd = this.FindBox.Text.Length + list[this.Position - 1];
                this.fastColoredTextBox1.Select();
                //this.fastColoredTextBox1.ScrollCaret();
                //this.ResultLabel.Text = this.Position.ToString() + " of " + list.Count.ToString() + " matches";
            }
            catch
            {
                try
                {
                    bool flag2 = !this.MatchCase;
                    string str2;
                    string value2;
                    if (flag2)
                    {
                        str2 = this.fastColoredTextBox1.Text.ToLower();
                        value2 = this.FindBox.Text.ToLower();
                    }
                    else
                    {
                        str2 = this.fastColoredTextBox1.Text;
                        value2 = this.FindBox.Text;
                    }
                    //List<int> list2 = str2.AllIndexesOf(value2);
                    //this.Position = list2.Count<int>();
                    //this.fastColoredTextBox1.SelectionStart = list2[this.Position - 1];
                    //this.fastColoredTextBox1.SelectionEnd = this.FindBox.Text.Length + list2[this.Position - 1];
                    this.fastColoredTextBox1.Select();
                    //this.fastColoredTextBox1.ScrollCaret();
                    //this.ResultLabel.Text = this.Position.ToString() + " of " + list2.Count.ToString() + " matches";
                }
                catch
                {
                }
            }
            this.FindBox.Focus();
        }

        // Token: 0x06000061 RID: 97 RVA: 0x0000738C File Offset: 0x0000558C
        private void FindForward_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = !this.MatchCase;
                string str;
                string value;
                if (flag)
                {
                    str = this.fastColoredTextBox1.Text.ToLower();
                    value = this.FindBox.Text.ToLower();
                }
                else
                {
                    str = this.fastColoredTextBox1.Text;
                    value = this.FindBox.Text;
                }
                this.Position++;
                //List<int> list = str.AllIndexesOf(value);
                //this.fastColoredTextBox1.SelectionStart = list[this.Position - 1];
                //this.fastColoredTextBox1.SelectionEnd = this.FindBox.Text.Length + list[this.Position - 1];
                //this.fastColoredTextBox1.Select();
                //this.fastColoredTextBox1.ScrollCaret();
                //this.ResultLabel.Text = this.Position.ToString() + " of " + list.Count.ToString() + " matches";
            }
            catch
            {
                try
                {
                    bool flag2 = !this.MatchCase;
                    string str2;
                    string value2;
                    if (flag2)
                    {
                        str2 = this.fastColoredTextBox1.Text.ToLower();
                        value2 = this.FindBox.Text.ToLower();
                    }
                    else
                    {
                        str2 = this.fastColoredTextBox1.Text;
                        value2 = this.FindBox.Text;
                    }
                    //List<int> list2 = str2.AllIndexesOf(value2);
                    this.Position = 1;
                    //this.fastColoredTextBox1.SelectionStart = list2[this.Position - 1];
                    //this.fastColoredTextBox1.SelectionEnd = this.FindBox.Text.Length + list2[this.Position - 1];
                    this.fastColoredTextBox1.Select();
                    //this.fastColoredTextBox1.ScrollCaret();
                    //this.ResultLabel.Text = this.Position.ToString() + " of " + list2.Count.ToString() + " matches";
                }
                catch
                {
                }
            }
            this.FindBox.Focus();
        }

        // Token: 0x06000062 RID: 98 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void FindBox_TextChanged(object sender, EventArgs e)
        {
        }

        // Token: 0x06000063 RID: 99 RVA: 0x000075E0 File Offset: 0x000057E0
        private async void Injector_Tick(object sender, EventArgs e)
        {
            bool injectOk = this.InjectOk;
            if (injectOk)
            {
                try
                {
                    this.Inject("C:/Windows/SysWOW64/msvcd140p.dll");
                }
                catch
                {
                }
            }
        }

        // Token: 0x06000064 RID: 100 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button14_Click_1(object sender, EventArgs e)
        {
        }

        // Token: 0x06000065 RID: 101 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button13_Click_1(object sender, EventArgs e)
        {
        }

        // Token: 0x06000066 RID: 102 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button15_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000067 RID: 103 RVA: 0x0000762C File Offset: 0x0000582C
        public bool Filter1(string s)
        {
            bool flag = s == "" || s == ".txt" || s == ".lua";
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = s.ToLower().LastIndexOf("(1)") != -1;
                if (flag2)
                {
                    result = false;
                }
                else
                {
                    bool flag3 = s.ToLower().LastIndexOf("(2)") != -1;
                    if (flag3)
                    {
                        result = false;
                    }
                    else
                    {
                        bool flag4 = s.ToLower().LastIndexOf("(3)") != -1;
                        if (flag4)
                        {
                            result = false;
                        }
                        else
                        {
                            bool flag5 = s.ToLower().LastIndexOf("(4)") != -1;
                            if (flag5)
                            {
                                result = false;
                            }
                            else
                            {
                                bool flag6 = s.ToLower().LastIndexOf("(5)") != -1;
                                result = !flag6;
                            }
                        }
                    }
                }
            }
            return result;
        }

        // Token: 0x06000068 RID: 104 RVA: 0x00007718 File Offset: 0x00005918
        private string Filter2(string s)
        {
            return s;
        }

        // Token: 0x06000069 RID: 105 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button16_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x0600006A RID: 106 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button17_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x0600006B RID: 107 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void button18_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x0600006C RID: 108 RVA: 0x0000772C File Offset: 0x0000592C
        private void button19_Click(object sender, EventArgs e)
        {
            bool injectOk = this.InjectOk;
            if (injectOk)
            {
                this.InjectOk = false;
                this.InjectButton.Visible = true;
                this.Text = "Bleu";
            }
            else
            {
                this.InjectOk = true;
                this.InjectButton.Visible = false;
            }
        }

        // Token: 0x0600006D RID: 109 RVA: 0x000077A0 File Offset: 0x000059A0
        private void searchScriptBox_TextChanged(object sender, EventArgs e)
        {
            this.scriptBox.Items.Clear();
            bool flag = this.searchScriptBox.Text != "";
            if (flag)
            {
                try
                {
                    char[] separator = new char[]
                    {
                        '!'
                    };
                    string[] array = this.ScriptString.Split(separator);
                    foreach (string text in array)
                    {
                        bool flag2 = text.ToLower().Replace("-", "").Replace(" ", "").LastIndexOf(this.searchScriptBox.Text.ToLower().Replace("-", "").Replace(" ", "")) != -1;
                        if (flag2)
                        {
                            bool flag3 = this.Filter1(text);
                            if (flag3)
                            {
                                this.scriptBox.Items.Add(this.Filter2(text));
                            }
                        }
                    }
                }
                catch
                {
                    this.scriptBox.Items.Add("Unable to fetch script list.");
                }
            }
            else
            {
                try
                {
                    char[] separator2 = new char[]
                    {
                        '!'
                    };
                    string[] array3 = this.ScriptString.Split(separator2);
                    foreach (string s in array3)
                    {
                        bool flag4 = this.Filter1(s);
                        if (flag4)
                        {
                            this.scriptBox.Items.Add(this.Filter2(s));
                        }
                    }
                }
                catch
                {
                    this.scriptBox.Items.Add("Unable to fetch script list.");
                }
            }
        }

        // Token: 0x0600006E RID: 110 RVA: 0x00007970 File Offset: 0x00005B70
        private void scriptBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool library = this.Library;
            if (library)
            {
                try
                {
                    this.fastColoredTextBox1.Text = new WebClient().DownloadString("http://bleu.cloris.co/Scripts/" + this.scriptBox.SelectedItem.ToString());
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    char[] separator = new char[]
                    {
                        '#'
                    };
                    string[] array = this.scriptBox.SelectedItem.ToString().Split(separator);
                    int num;
                    int.TryParse(array[1], out num);
                    this.fastColoredTextBox1.Text = File.ReadAllText(this.StringArray[num - 1]);
                }
                catch
                {
                }
            }
        }

        // Token: 0x0600006F RID: 111 RVA: 0x00007A3C File Offset: 0x00005C3C
        private void OutputCheck_Tick(object sender, EventArgs e)
        {
            try
            {
                bool flag = "~" != File.ReadAllText("C:/Bleu/OUTPUT");
                if (flag)
                {
                    try
                    {
                        string text = File.ReadAllText("C:/Bleu/OUTPUT");
                        File.WriteAllText("C:/Bleu/OUTPUT", "~");
                        this.ReceiveOutput(int.Parse(text.Substring(0, 1)), int.Parse(text.Substring(1, 1)), text.Substring(2));
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        // Token: 0x06000070 RID: 112 RVA: 0x00007AD8 File Offset: 0x00005CD8
        private void scriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        // Token: 0x06000071 RID: 113 RVA: 0x00007AEE File Offset: 0x00005CEE
        private void topKek75ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendInput(this.INPUT_EXECUTE, 0, "loadstring(game:HttpGet(('https://pastebin.com/raw/p7RC7dcc'),true))()");
        }

        // Token: 0x06000072 RID: 114 RVA: 0x00007B04 File Offset: 0x00005D04
        private void dexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendInput(this.INPUT_EXECUTE, 0, "spawn(function() loadstring(game:GetObjects('rbxassetid://418957341')[1].Source)() \nend)");
        }

        // Token: 0x06000073 RID: 115 RVA: 0x00007B1A File Offset: 0x00005D1A
        private void environmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modifications to ROBLOX:\r\n - TrustCheck bypass\r\n - Added GetObjects\r\n - Added GetObjectsLoadScripts\r\n - Level 6 identity\r\n - LoadLibrary support\r\n\r\n Custom Environment:\r\n - Bleu Table\r\n   - ChangeContext Function\r\n   - ExecuteScript Function\r\n - File Table\r\n   - Write Function\r\n   - Read Function\r\n - Clipboard Table\r\n   - Set Function\r\n   - Get Function\r\n - Output Table\r\n   - SyntaxError Function\r\n   - Error Function\r\n   - Warn Function\r\n   - Info Function\r\n   - Normal Function\r\n\r\n Extended ROBLOX Environment:\r\n - dofile Function\r\n   - Compiles and runs as script from a file\r\n - loadfile Function\r\n   - Compiles and returns a script from a file\r\n - loadstring Function\r\n   - Compiles and returns a script from a string\r\n - getrawmetatable Function\r\n   - Returns the raw metatable of a ROBLOX userdata\r\n - getscriptfunction Function\r\n   - Returns the function of a script\r\n - info Function\r\n   - Outputs an info message into the ROBLOX console\r\n- decompile Function\r\n   - Returns decompiled Module or Localscript\r\n- protodump Function\r\n   - Returns dumped Module or Localscript", "Bleu Custom Environment");
        }

        // Token: 0x06000074 RID: 116 RVA: 0x00007B30 File Offset: 0x00005D30
        private void scriptListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StringArray.Clear();
            this.ScriptString = "";
            this.scriptBox.Items.Clear();
            try
            {
                string[] files = Directory.GetFiles("C:/Bleu/AutoExecute", "*.*", SearchOption.AllDirectories);
                int num = 0;
                foreach (string text in files)
                {
                    bool flag = Path.GetExtension(text) == ".lua" || Path.GetExtension(text) == ".txt";
                    if (flag)
                    {
                        num++;
                        this.StringArray.Add(text);
                        this.ScriptString = string.Concat(new object[]
                        {
                            this.ScriptString,
                            Path.GetFileName(text),
                            " #",
                            num,
                            "!"
                        });
                    }
                }
            }
            catch
            {
            }
            try
            {
                char[] separator = new char[]
                {
                    '!'
                };
                string[] array2 = this.ScriptString.Split(separator);
                foreach (string s in array2)
                {
                    bool flag2 = this.Filter1(s);
                    if (flag2)
                    {
                        this.scriptBox.Items.Add(this.Filter2(s));
                    }
                }
            }
            catch
            {
                this.scriptBox.Items.Add("Unable to fetch script list.");
            }
            bool flag3 = !this.OpenScript;
            if (flag3)
            {
                this.OpenScript = true;
                this.fastColoredTextBox1.Size = new Size(this.fastColoredTextBox1.Size.Width - this.scriptBox.Size.Width - 5, this.fastColoredTextBox1.Size.Height);
            }
            else
            {
                bool flag4 = !this.Library;
                if (flag4)
                {
                    this.OpenScript = false;
                    this.fastColoredTextBox1.Size = new Size(this.fastColoredTextBox1.Size.Width + this.scriptBox.Size.Width + 5, this.fastColoredTextBox1.Size.Height);
                }
            }
            this.Library = false;
        }

        // Token: 0x06000075 RID: 117 RVA: 0x00007D9C File Offset: 0x00005F9C
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

        // Token: 0x06000076 RID: 118 RVA: 0x00007DFC File Offset: 0x00005FFC
        private void scriptLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.scriptBox.Items.Clear();
            try
            {
                this.ScriptString = this.getScriptLibrary();
                char[] separator = new char[]
                {
                    '!'
                };
                string[] array = this.ScriptString.Split(separator);
                foreach (string s in array)
                {
                    bool flag = this.Filter1(s);
                    if (flag)
                    {
                        this.scriptBox.Items.Add(this.Filter2(s));
                    }
                }
            }
            catch
            {
                this.scriptBox.Items.Add("Unable to fetch script list.");
            }
            YakaHackTheme.SendMessage(this.searchScriptBox.Handle, 5377, 0, "Search");
            bool flag2 = !this.OpenScript;
            if (flag2)
            {
                this.OpenScript = true;
                this.fastColoredTextBox1.Size = new Size(this.fastColoredTextBox1.Size.Width - this.scriptBox.Size.Width - 5, this.fastColoredTextBox1.Size.Height);
            }
            else
            {
                bool library = this.Library;
                if (library)
                {
                    this.OpenScript = false;
                    this.fastColoredTextBox1.Size = new Size(this.fastColoredTextBox1.Size.Width + this.scriptBox.Size.Width + 5, this.fastColoredTextBox1.Size.Height);
                }
            }
            this.Library = true;
        }

        // Token: 0x06000077 RID: 119 RVA: 0x00007FA4 File Offset: 0x000061A4
        private void killRobloxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName("RobloxPlayerBeta"))
                {
                    process.Kill();
                }
            }
            catch
            {
            }
        }

        // Token: 0x06000078 RID: 120 RVA: 0x00007FF4 File Offset: 0x000061F4
        private void themesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = this.FileLocation == "";
            if (flag)
            {
                this.fastColoredTextBox1.Text = "";
                this.FileLocation = "";
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save your changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                bool flag2 = dialogResult == DialogResult.Yes;
                if (flag2)
                {
                    try
                    {
                        File.WriteAllText(this.FileLocation, this.fastColoredTextBox1.Text);
                    }
                    catch
                    {
                    }
                    this.fastColoredTextBox1.Text = "";
                    this.FileLocation = "";
                }
                else
                {
                    bool flag3 = dialogResult == DialogResult.No;
                    if (flag3)
                    {
                        this.fastColoredTextBox1.Text = "";
                        this.FileLocation = "";
                    }
                }
            }
        }

        // Token: 0x06000079 RID: 121 RVA: 0x000080CC File Offset: 0x000062CC
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = this.FileLocation == "";
            if (flag)
            {
                bool flag2 = this.saveFileDialog1.ShowDialog() != DialogResult.Cancel;
                if (flag2)
                {
                    try
                    {
                        this.FileLocation = this.saveFileDialog1.FileName;
                        File.Create(this.saveFileDialog1.FileName).Close();
                        File.WriteAllText(this.saveFileDialog1.FileName, this.fastColoredTextBox1.Text);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                try
                {
                    File.WriteAllText(this.FileLocation, this.fastColoredTextBox1.Text);
                }
                catch
                {
                }
            }
        }

        // Token: 0x0600007A RID: 122 RVA: 0x00008194 File Offset: 0x00006394
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = this.saveFileDialog1.ShowDialog() != DialogResult.Cancel;
            if (flag)
            {
                try
                {
                    this.FileLocation = this.saveFileDialog1.FileName;
                    File.Create(this.saveFileDialog1.FileName).Close();
                    File.WriteAllText(this.saveFileDialog1.FileName, this.fastColoredTextBox1.Text);
                }
                catch
                {
                }
            }
        }

        // Token: 0x0600007B RID: 123 RVA: 0x00008218 File Offset: 0x00006418
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = this.FileLocation == "";
            if (flag)
            {
                bool flag2 = this.OpenFileDialog1.ShowDialog() != DialogResult.Cancel;
                if (flag2)
                {
                    try
                    {
                        this.FileLocation = this.OpenFileDialog1.FileName;
                        this.fastColoredTextBox1.Text = File.ReadAllText(this.OpenFileDialog1.FileName);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save your changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                bool flag3 = dialogResult == DialogResult.Yes;
                if (flag3)
                {
                    try
                    {
                        File.WriteAllText(this.FileLocation, this.fastColoredTextBox1.Text);
                    }
                    catch
                    {
                    }
                    bool flag4 = this.OpenFileDialog1.ShowDialog() != DialogResult.Cancel;
                    if (flag4)
                    {
                        try
                        {
                            this.FileLocation = this.OpenFileDialog1.FileName;
                            this.fastColoredTextBox1.Text = File.ReadAllText(this.OpenFileDialog1.FileName);
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    bool flag5 = dialogResult == DialogResult.No;
                    if (flag5)
                    {
                        bool flag6 = this.OpenFileDialog1.ShowDialog() != DialogResult.Cancel;
                        if (flag6)
                        {
                            try
                            {
                                this.FileLocation = this.OpenFileDialog1.FileName;
                                this.fastColoredTextBox1.Text = File.ReadAllText(this.OpenFileDialog1.FileName);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x0600007C RID: 124 RVA: 0x000083AC File Offset: 0x000065AC
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        // Token: 0x0600007D RID: 125 RVA: 0x000083BA File Offset: 0x000065BA
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Undo();
        }

        // Token: 0x0600007E RID: 126 RVA: 0x000083C9 File Offset: 0x000065C9
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Redo();
        }

        // Token: 0x0600007F RID: 127 RVA: 0x000083D8 File Offset: 0x000065D8
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.SelectAll();
        }

        // Token: 0x06000080 RID: 128 RVA: 0x000069F2 File Offset: 0x00004BF2
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Cut();
        }

        // Token: 0x06000081 RID: 129 RVA: 0x00006A01 File Offset: 0x00004C01
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Copy();
        }

        // Token: 0x06000082 RID: 130 RVA: 0x00006A10 File Offset: 0x00004C10
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Paste();
        }

        // Token: 0x06000083 RID: 131 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void vavToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000084 RID: 132 RVA: 0x000083E8 File Offset: 0x000065E8
        private void FillMatches(string origstr)
        {
            try
            {
                string text = origstr;
                this.CmdMatches.Items.Clear();
                text = text.ToLower();
                text = text.Split(new char[]
                {
                    ' '
                })[0];
                int num = 0;
                for (int i = 0; i < this.Cmds.Length; i++)
                {
                    try
                    {
                        bool flag = this.Cmds[i].Substring(0, text.Length) == text;
                        if (flag)
                        {
                            num++;
                            bool flag2 = origstr.Split(new char[]
                            {
                                ' '
                            }).Length < 2;
                            if (flag2)
                            {
                                bool flag3 = num <= 5;
                                if (flag3)
                                {
                                    ToolStripItem toolStripItem = this.CmdMatches.Items.Add(this.Cmds[i]);
                                    toolStripItem.ForeColor = Color.FromArgb(224, 224, 224);
                                }
                            }
                            else
                            {
                                bool flag4 = this.Cmds[i].Split(new char[]
                                {
                                    ' '
                                })[0] == text;
                                if (flag4)
                                {
                                    bool flag5 = num <= 5;
                                    if (flag5)
                                    {
                                        ToolStripItem toolStripItem2 = this.CmdMatches.Items.Add(this.Cmds[i]);
                                        toolStripItem2.ForeColor = Color.FromArgb(224, 224, 224);
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                bool flag6 = this.CmdMatches.Items.Count != 0;
                if (flag6)
                {
                    this.CmdMatches.Show(this.CmdBox, new Point(0, 20));
                }
                else
                {
                    this.CmdMatches.Close();
                }
            }
            catch
            {
            }
        }

        // Token: 0x06000085 RID: 133 RVA: 0x000085D0 File Offset: 0x000067D0
        private void CmdBox_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(this.CmdBox.Text, this.CmdBox.Font);
            bool flag = size.Width > 300;
            if (!flag)
            {
                bool flag2 = size.Width > 128;
                if (flag2)
                {
                    this.CmdBox.Size = new Size(size.Width, 20);
                    this.CmdBox.Location = new Point(this.panel1.Size.Width - (size.Width + 2), 4);
                }
                else
                {
                    this.CmdBox.Size = new Size(128, 20);
                    this.CmdBox.Location = new Point(this.panel1.Size.Width - 130, 4);
                }
                try
                {
                    bool flag3 = this.CmdBox.Text.Substring(0, 1) == ";";
                    if (flag3)
                    {
                        this.FillMatches(this.CmdBox.Text.Substring(1));
                    }
                    else
                    {
                        this.CmdMatches.Close();
                    }
                }
                catch
                {
                    this.CmdMatches.Close();
                }
            }
        }

        // Token: 0x06000086 RID: 134 RVA: 0x00008728 File Offset: 0x00006928
        private string FindPlayer(string str, string name)
        {
            return string.Concat(new string[]
            {
                "local ",
                name.ToLower(),
                " = (function() local str = [===[",
                str,
                "]===] if str == 'me' then return game:GetService('Players').LocalPlayer else for i,v in pairs(game:GetService('Players'):GetPlayers()) do  if v.Name:lower():sub(1, str:len()) == str:lower() then return v end end end return game:GetService('Players').LocalPlayer end)();"
            });
        }

        // Token: 0x06000087 RID: 135 RVA: 0x0000876C File Offset: 0x0000696C
        private string FindPlayers(string str, string func)
        {
            string text = "{";
            string[] array = str.Split(new char[]
            {
                ','
            });
            for (int i = 0; i < array.Length; i++)
            {
                text = text + "[===[" + array[i].ToLower() + "]===],";
            }
            text += "}";
            return string.Concat(new string[]
            {
                "local function getPlayers(plrs) local newt = {} for i,v in pairs(plrs) do if v == 'me' then table.insert(newt, game:GetService('Players').LocalPlayer) elseif v == 'all' then for o,b in pairs(game:GetService('Players'):GetPlayers()) do table.insert(newt, b) end elseif v == 'others' then for o,b in pairs(game:GetService('Players'):GetPlayers()) do if b ~= game:GetService('Players').LocalPlayer then table.insert(newt, b) end end else for o,b in pairs(game:GetService('Players'):GetPlayers()) do if b.Name:sub(1, v:len()):lower() == v:lower() then table.insert(newt, b) end end  end end return newt end for i,p in pairs(getPlayers(",
                text,
                ")) do ",
                func,
                " end"
            });
        }

        // Token: 0x06000088 RID: 136 RVA: 0x000087FC File Offset: 0x000069FC
        private void DoCmd(string str)
        {
            this.SendInput(this.INPUT_EXECUTE, 0, "spawn(function()pcall(function() " + str + " end)\nend)");
        }

        // Token: 0x06000089 RID: 137 RVA: 0x00008820 File Offset: 0x00006A20
        private void DoCommand(string str)
        {
            try
            {
                bool flag = str.Substring(0, 1) == ";";
                if (flag)
                {
                    str = str.Substring(1);
                    string[] array = str.Split(new char[]
                    {
                        ' '
                    });
                    string a = array[0].ToLower();
                    bool flag2 = a == "cmds" || a == "cmd" || a == "command" || a == "commands";
                    if (flag2)
                    {
                        this.fastColoredTextBox1.Text = "Total commands: " + this.Cmds.Length.ToString();
                        for (int i = 0; i < this.Cmds.Length; i++)
                        {
                            //Scintilla scintilla = this.fastColoredTextBox1;
                            //scintilla.Text = scintilla.Text + "\n-" + this.Cmds[i];
                        }
                    }
                    else
                    {
                        bool flag3 = a == "kill";
                        if (flag3)
                        {
                            this.DoCmd(this.FindPlayers(array[1], "p.Character:BreakJoints()"));
                        }
                        else
                        {
                            bool flag4 = a == "ff" || a == "forcefield";
                            if (flag4)
                            {
                                this.DoCmd(this.FindPlayers(array[1], "Instance.new('ForceField', p.Character)"));
                            }
                            else
                            {
                                bool flag5 = a == "explode" || a == "xplode" || a == "explosion" || a == "xplosion";
                                if (flag5)
                                {
                                    this.DoCmd(this.FindPlayers(array[1], "local x = Instance.new('Explosion', p.Character) x.Position = p.Character.Head.Position"));
                                }
                                else
                                {
                                    bool flag6 = a == "fire" || a == "flame";
                                    if (flag6)
                                    {
                                        this.DoCmd(this.FindPlayers(array[1], "Instance.new('Fire', p.Character.Head)"));
                                    }
                                    else
                                    {
                                        bool flag7 = a == "sparkles" || a == "sparkle";
                                        if (flag7)
                                        {
                                            this.DoCmd(this.FindPlayers(array[1], "Instance.new('Sparkles', p.Character.Head)"));
                                        }
                                        else
                                        {
                                            bool flag8 = a == "btools" || a == "buildtools" || a == "buildingtools";
                                            if (flag8)
                                            {
                                                this.DoCmd(this.FindPlayers(array[1], "Instance.new('HopperBin', p.Backpack).BinType = 'Hammer' Instance.new('HopperBin', p.Backpack).BinType = 'Clone' Instance.new('HopperBin', p.Backpack).BinType = 'GameTool' "));
                                            }
                                            else
                                            {
                                                bool flag9 = a == "rejoin";
                                                if (flag9)
                                                {
                                                    this.SendInput(this.INPUT_EXECUTE, 0, "game:GetService('TeleportService'):Teleport(game.PlaceId)");
                                                }
                                                bool flag10 = a == "kick";
                                                if (flag10)
                                                {
                                                    string str2 = "\r\n                        local fastwait = function(time)\r\n                            local expire = tick()+(time or 0.02999999999999999889)\r\n                            while game:GetService('RunService').Heartbeat:wait() do\r\n\r\n                                if tick() >= expire then return true end\r\n                            end\r\n                        end\r\n                        local function KICK(P)\r\n\t                        spawn(function()\r\n\t\t                        if true then\r\n\t\t                        for i = 1,5 do\r\n\t\t\t                        if P.Character and P.Character:FindFirstChild('HumanoidRootPart') then\r\n\t\t\t\t                        P.Character.HumanoidRootPart.CFrame = CFrame.new(math.random(999000, 1001000), 1000000, 1000000)\r\n\t\t\t\t                        local SP = Instance.new('SkateboardPlatform', P.Character) SP.Position = P.Character.HumanoidRootPart.Position SP.Transparency = 1\r\n\t\t\t\t                        spawn(function()\r\n\t\t\t\t\t                        repeat fastwait()\r\n\t\t\t\t\t\t                        if P.Character and P.Character:FindFirstChild('HumanoidRootPart') then SP.Position = P.Character.HumanoidRootPart.Position end\r\n\t\t\t\t\t                        until not game:GetService('Players'):FindFirstChild(P.Name)\r\n\r\n                                        end)\r\n\t\t\t\t                        P.Character.HumanoidRootPart.Anchored = true\r\n\r\n                                    end\r\n                                end\r\n\r\n                                end\r\n                            end)\r\n                        end\r\n                        ";
                                                    this.DoCmd(this.FindPlayers(array[1], str2 + " kick(P)"));
                                                }
                                                bool flag11 = a == "run";
                                                if (flag11)
                                                {
                                                    bool flag12 = this.SL == null;
                                                    if (flag12)
                                                    {
                                                        try
                                                        {
                                                            this.SL = new WebClient().DownloadString("http://bleu.cloris.co/FetchScripts.php");
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Unable to fetch script list.");
                                                        }
                                                    }
                                                    try
                                                    {
                                                        try
                                                        {
                                                            string text = "";
                                                            for (int j = 1; j < array.Length; j++)
                                                            {
                                                                text = text + array[j] + " ";
                                                            }
                                                            text = text.Substring(0, text.Length - 1);
                                                            char[] separator = new char[]
                                                            {
                                                                '!'
                                                            };
                                                            string[] array2 = this.SL.Split(separator);
                                                            foreach (string text2 in array2)
                                                            {
                                                                bool flag13 = text2.ToLower().Replace("-", "").Replace(" ", "").LastIndexOf(text.ToLower().Replace("-", "").Replace(" ", "")) != -1;
                                                                if (flag13)
                                                                {
                                                                    bool flag14 = this.Filter1(text2);
                                                                    if (flag14)
                                                                    {
                                                                        this.SendInput(this.INPUT_EXECUTE, 0, new WebClient().DownloadString("http://bleu.cloris.co/Scripts/" + text2).Replace("game.Players.yfc", "game.Players.LocalPlayer").Replace("game.Players.ic3w0lf589", "game.Players.LocalPlayer"));
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                else
                                                {
                                                    bool flag15 = a == "tp" || a == "teleport";
                                                    if (flag15)
                                                    {
                                                        this.DoCmd(this.FindPlayer(array[2], "tp") + this.FindPlayers(array[1], "p.Character:MoveTo(tp.Character.Head.Position)"));
                                                    }
                                                    else
                                                    {
                                                        bool flag16 = a == "ws" || a == "speed" || a == "walkspeed";
                                                        if (flag16)
                                                        {
                                                            this.DoCmd(this.FindPlayers(array[1], "p.Character.Humanoid.WalkSpeed = " + array[2]));
                                                        }
                                                        else
                                                        {
                                                            bool flag17 = a == "jp" || a == "jumppower";
                                                            if (flag17)
                                                            {
                                                                this.DoCmd(this.FindPlayers(array[1], "p.Character.Humanoid.JumpPower = " + array[2]));
                                                            }
                                                            else
                                                            {
                                                                bool flag18 = a == "hh" || a == "hipheight";
                                                                if (flag18)
                                                                {
                                                                    this.DoCmd(this.FindPlayers(array[1], "p.Character.Humanoid.HipHeight = " + array[2]));
                                                                }
                                                                else
                                                                {
                                                                    bool flag19 = a == "kanapapaia" || a == "kana";
                                                                    if (flag19)
                                                                    {
                                                                        this.DoCmd(this.FindPlayers(array[1], "game:GetService('Chat'):Chat(p.Character.Head, 'u kanapapaia?')"));
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    bool flag20 = Uri.IsWellFormedUriString(str, UriKind.Absolute);
                    if (flag20)
                    {
                        this.SendInput(this.INPUT_EXECUTE, 0, "spawn(function() loadstring(game:HttpGet([===[" + str + "]===], true))() \nend)");
                    }
                    else
                    {
                        this.SendInput(this.INPUT_EXECUTE, 0, "spawn(function() " + str + "\nend)");
                    }
                }
            }
            catch
            {
            }
        }

        // Token: 0x0600008A RID: 138 RVA: 0x00008EB4 File Offset: 0x000070B4
        private void CmdBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool flag = e.KeyCode == Keys.Return;
            if (flag)
            {
                e.SuppressKeyPress = true;
                this.DoCommand(this.CmdBox.Text);
                bool flag2 = true;
                for (int i = 0; i < this.Previous.Count; i++)
                {
                    bool flag3 = this.Previous[i] == this.CmdBox.Text;
                    if (flag3)
                    {
                        flag2 = false;
                    }
                }
                bool flag4 = flag2;
                if (flag4)
                {
                    this.Previous.Add(this.CmdBox.Text);
                }
                this.CmdBox.Text = "";
                this.loc = this.Previous.Count;
            }
            else
            {
                bool flag5 = e.KeyCode == Keys.Up;
                if (flag5)
                {
                    bool flag6 = this.Previous.Count != 0 && this.loc != 0;
                    if (flag6)
                    {
                        this.loc--;
                        this.CmdBox.Text = this.Previous[this.loc];
                    }
                }
                else
                {
                    bool flag7 = e.KeyCode == Keys.Down;
                    if (flag7)
                    {
                        bool flag8 = this.Previous.Count != 0 && this.loc != this.Previous.Count - 1 && this.loc != this.Previous.Count;
                        if (flag8)
                        {
                            this.loc++;
                            this.CmdBox.Text = this.Previous[this.loc];
                        }
                    }
                }
            }
        }

        // Token: 0x0600008B RID: 139 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void CmdBox_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        // Token: 0x0600008C RID: 140 RVA: 0x0000905D File Offset: 0x0000725D
        private void CmdBox_Leave(object sender, EventArgs e)
        {
            this.CmdMatches.Close();
        }

        // Token: 0x0600008D RID: 141 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void Main_MaximizedBoundsChanged(object sender, EventArgs e)
        {
        }

        // Token: 0x0600008E RID: 142 RVA: 0x0000905D File Offset: 0x0000725D
        private void Main_LocationChanged(object sender, EventArgs e)
        {
            this.CmdMatches.Close();
        }

        // Token: 0x0600008F RID: 143 RVA: 0x00007AD8 File Offset: 0x00005CD8
        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        // Token: 0x06000090 RID: 144 RVA: 0x0000906C File Offset: 0x0000726C
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            this.Reg = false;
            this.ColorForm(base.Controls, Color.FromArgb(130, 23, 32), Color.FromArgb(224, 224, 224));
        }

        // Token: 0x06000091 RID: 145 RVA: 0x000090A5 File Offset: 0x000072A5
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Reg = false;
            this.ColorForm(base.Controls, Color.FromArgb(38, 15, 91), Color.FromArgb(224, 224, 224));
        }

        // Token: 0x06000092 RID: 146 RVA: 0x000090DB File Offset: 0x000072DB
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            this.Reg = false;
            this.ColorForm(base.Controls, Color.FromArgb(255, 45, 173), Color.FromArgb(224, 224, 224));
        }

        // Token: 0x06000093 RID: 147 RVA: 0x00009117 File Offset: 0x00007317
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            this.Reg = false;
            this.ColorForm(base.Controls, Color.FromArgb(73, 76, 255), Color.FromArgb(224, 224, 224));
        }

        // Token: 0x06000094 RID: 148 RVA: 0x00009150 File Offset: 0x00007350
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            this.Reg = false;
            this.ColorForm(base.Controls, Color.FromArgb(255, 0, 0), Color.FromArgb(224, 224, 224));
        }

        // Token: 0x06000095 RID: 149 RVA: 0x00009187 File Offset: 0x00007387
        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            this.Reg = false;
            this.ColorForm(base.Controls, Color.FromArgb(0, 114, 17), Color.FromArgb(224, 224, 224));
        }

        // Token: 0x06000096 RID: 150 RVA: 0x000091BC File Offset: 0x000073BC
        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            this.Reg = false;
            this.ColorForm(base.Controls, Color.FromArgb(0, 0, 255), Color.FromArgb(224, 224, 224));
        }

        // Token: 0x06000097 RID: 151 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000098 RID: 152 RVA: 0x00007AD8 File Offset: 0x00005CD8
        private void inGameTopBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        // Token: 0x06000099 RID: 153 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void otherScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x0600009A RID: 154 RVA: 0x000091F3 File Offset: 0x000073F3
        private void infiniteYieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendInput(this.INPUT_EXECUTE, 0, "loadstring(game:HttpGet(('https://pastebin.com/raw/MjBzRjmT'),true))()");
        }

        // Token: 0x0600009B RID: 155 RVA: 0x00009209 File Offset: 0x00007409
        private void remoteSpyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendInput(this.INPUT_EXECUTE, 0, "loadstring(game:HttpGet(('https://pastebin.com/raw/BFdPkjDt'),true))()");
        }

        // Token: 0x0600009C RID: 156 RVA: 0x0000921F File Offset: 0x0000741F
        private void roXploit61ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendInput(this.INPUT_EXECUTE, 0, "loadstring(game:GetObjects('rbxassetid://364364477')[1].Source)()");
        }

        // Token: 0x0600009D RID: 157 RVA: 0x00009235 File Offset: 0x00007435
        private void zinniaKickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendInput(this.INPUT_EXECUTE, 0, "loadstring(game:HttpGet('https://bleu.cloris.co/Scripts/zinnia.txt')[1].Source)()");
        }

        // Token: 0x0600009E RID: 158 RVA: 0x00009235 File Offset: 0x00007435
        private void rainingSeagullsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendInput(this.INPUT_EXECUTE, 0, "loadstring(game:HttpGet('https://bleu.cloris.co/Scripts/zinnia.txt')[1].Source)()");
        }

        // Token: 0x0600009F RID: 159 RVA: 0x0000924C File Offset: 0x0000744C
        private void newExecutionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool reg = this.Reg;
            if (reg)
            {
                this.button2.BackColor = Color.FromArgb(64, 64, 64);
                this.button1.BackColor = Color.FromArgb(44, 44, 44);
            }
            this.Cache = true;
        }

        // Token: 0x060000A0 RID: 160 RVA: 0x000092B8 File Offset: 0x000074B8
        private void wrapperToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool reg = this.Reg;
            if (reg)
            {
                this.button1.BackColor = Color.FromArgb(64, 64, 64);
                this.button2.BackColor = Color.FromArgb(44, 44, 44);
            }
            this.Cache = false;
        }

        // Token: 0x060000A1 RID: 161 RVA: 0x00007AD8 File Offset: 0x00005CD8
        private void extendedEnvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        // Token: 0x060000A2 RID: 162 RVA: 0x00009324 File Offset: 0x00007524
        private void trustCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Token: 0x060000A3 RID: 163 RVA: 0x000093B0 File Offset: 0x000075B0
        private void outputErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Token: 0x060000A4 RID: 164 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void toolStripSeparator6_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x060000A5 RID: 165 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void toolStripSeparator9_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x060000A6 RID: 166 RVA: 0x0000943C File Offset: 0x0000763C
        private void doNotClickOnThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("...", "Bleu");
            MessageBox.Show("I warned you...", "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show("...", "Bleu");
            MessageBox.Show("...", "Bleu");
            MessageBox.Show("I TOLD YOU NOT TO PRESS THIS BUTTON.", "...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            MessageBox.Show("WHAT DO YOU MEAN 'OK'???", "...", MessageBoxButtons.OK, MessageBoxIcon.Question);
            MessageBox.Show("The sign CLEARLY says to NOT press the button!", "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show("Piss off.", "...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.PissOff.Start();
        }

        // Token: 0x060000A7 RID: 167 RVA: 0x000094E8 File Offset: 0x000076E8
        public static string RandomString(int length)
        {
            return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
                               select s[YakaHackTheme.random.Next(s.Length)]).ToArray<char>());
        }

        // Token: 0x060000A8 RID: 168 RVA: 0x00009534 File Offset: 0x00007734
        private async void PissOff_Tick(object sender, EventArgs e)
        {
            this.PissOff.Stop();
            MessageBox.Show("Hey..", "...");
            MessageBox.Show("Hey.. I'm sorry about that.. I just didn't get any sleep..", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            while (MessageBox.Show("Do you think you could forgive me? I understand if you don't..", "...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
            {
                int num;
                for (int i = 1; i <= 3; i = num + 1)
                {
                    Console.Beep();
                    num = i;
                }
                for (int j = 1; j <= 5; j = num + 1)
                {
                    this.fastColoredTextBox1.Text = YakaHackTheme.RandomString(10) + " wrong choice " + YakaHackTheme.RandomString(10);
                    await Task.Delay(5);
                    this.fastColoredTextBox1.Text = YakaHackTheme.RandomString(5) + " wrong choice " + YakaHackTheme.RandomString(8);
                    SystemSounds.Hand.Play();
                    await Task.Delay(5);
                    this.fastColoredTextBox1.Text = YakaHackTheme.RandomString(8) + " wrong choice " + YakaHackTheme.RandomString(11);
                    SystemSounds.Asterisk.Play();
                    await Task.Delay(5);
                    this.fastColoredTextBox1.Text = YakaHackTheme.RandomString(12) + " wrong choice " + YakaHackTheme.RandomString(12);
                    SystemSounds.Question.Play();
                    await Task.Delay(5);
                    this.fastColoredTextBox1.Text = YakaHackTheme.RandomString(13) + " wrong choice " + YakaHackTheme.RandomString(5);
                    SystemSounds.Beep.Play();
                    await Task.Delay(5);
                    this.fastColoredTextBox1.Text = YakaHackTheme.RandomString(6) + " wrong choice " + YakaHackTheme.RandomString(6);
                    SystemSounds.Exclamation.Play();
                    num = j;
                }
                for (int k = 1; k <= 3; k = num + 1)
                {
                    Console.Beep();
                    num = k;
                }
                this.fastColoredTextBox1.Text = "";
            }
            MessageBox.Show("Yeah.. I know.. I'm sorry", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (MessageBox.Show("Hey.. Since we started off on the wrong foot, let me take you out to dinner.", "...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
            {
                MessageBox.Show("Noo.. Noo.. It's my fault. I'll pay.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            MessageBox.Show("Great.. I'll see you there.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            await Task.Delay(10000);
            MessageBox.Show("Hey..! I was starting to think that you weren't going to show up..", "?enod uoy evah tahW", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("You know.. I'm sorry for what happened before.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (MessageBox.Show("All of that troub- Is there anything you can says besides 'OK'?", "...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
            {
                MessageBox.Show("How funny.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Yeah, okay.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MessageBox.Show("Yeah, there it is again.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            MessageBox.Show("Anyway..", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("I was wondering if you were interested in this amazing new idea that I have.. Should I go on?", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (MessageBox.Show("Yeah. So basically, it's an something most people would regard as strange and frightening.. Sound interesting?", "...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
            {
                MessageBox.Show("Well here's the thing-", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Yeah, I knew it would sound interesting to you. You just seem like that kind of person.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            MessageBox.Show("Basically, you pay me some money...", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("I send it to people online...", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("And those people somehow double the money and send it back.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("It's pretty cool. I've made a lot off of doing this.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("I really thought you would be interested in doing this with me....", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (MessageBox.Show("Would you like to do this with me? I'm sure you're going to like it.", "...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
            {
                MessageBox.Show("I'm sure you do want to do this. I could easily force you to do it, but I'm very kind to you. I hope you do what's right.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            MessageBox.Show("Awesome. Send 3.08 btc to this address: 1F1tAaz5x1HUXrCNLbtMDqcw6o5GNn4xqX", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("Uhh.. I didn't get the bitcoin.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("What do you mean 'OK'? Are you some kind of robot?", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("Whatever. Fuck off.", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Process.GetCurrentProcess().Kill();
        }

        // Token: 0x060000A9 RID: 169 RVA: 0x0000957E File Offset: 0x0000777E
        private void scriptWareUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendInput(this.INPUT_EXECUTE, 0, "SckripptWear()");
        }

        // Token: 0x060000AA RID: 170 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void Main_DragOver(object sender, DragEventArgs e)
        {
        }

        // Token: 0x060000AB RID: 171 RVA: 0x00009594 File Offset: 0x00007794
        private async void installTimeMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = Process.GetProcessesByName("RobloxPlayerBeta").Length != 0;
            if (flag)
            {
                MessageBox.Show("Please close ROBLOX to install Time Machine.", "FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                //Loading lt = new Loading();
                //lt.Show();
                await Task.Delay(5);
                try
                {
                    string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/../Local/Roblox/Versions";
                    string[] Dirs = Directory.GetDirectories(Path);
                    for (int i = 0; i < Dirs.Length; i++)
                    {
                        if (File.Exists(Dirs[i] + "/RobloxPlayerBeta.exe"))
                        {
                            try
                            {
                                new WebClient().DownloadFile("https://bleu.cloris.co/Release/TimeMachineLauncher.exe", Dirs[i] + "/RobloxPlayerLauncher.exe");
                                new WebClient().DownloadFile("https://bleu.cloris.co/Release/TimeMachine.exe", Dirs[i] + "/RobloxPlayerBeta.exe");
                            }
                            catch
                            {
                                MessageBox.Show("Failed to install Time Machine. Please disable your anti-virus.", "FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                    }
                    Path = null;
                    Dirs = null;
                }
                catch
                {
                    MessageBox.Show("Failed to install Time Machine. Please disable your anti-virus.", "FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                //lt.Close();
                MessageBox.Show("Installed Time Machine.");
            }
        }

        // Token: 0x060000AC RID: 172 RVA: 0x000095E0 File Offset: 0x000077E0
        private async void removeTimeMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = Process.GetProcessesByName("RobloxPlayerBeta").Length != 0;
            if (flag)
            {
                MessageBox.Show("Please close ROBLOX to remove Time Machine.", "FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                //Loading lt = new Loading();
                //lt.Show();
                await Task.Delay(5);
                try
                {
                    string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/../Local/Roblox/Versions";
                    string[] Dirs = Directory.GetDirectories(Path);
                    for (int i = 0; i < Dirs.Length; i++)
                    {
                        if (File.Exists(Dirs[i] + "/RobloxPlayerBeta.exe"))
                        {
                            try
                            {
                                new WebClient().DownloadFile("http://deploy.roblox.com/Roblox.exe", Dirs[i] + "/RobloxPlayerLauncher.exe");
                            }
                            catch
                            {
                                MessageBox.Show("Failed to remove Time Machine. Please disable your anti-virus.", "FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                    }
                    Path = null;
                    Dirs = null;
                }
                catch
                {
                    MessageBox.Show("Failed to remove Time Machine. Please disable your anti-virus.", "FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                //lt.Close();
                MessageBox.Show("Removed Time Machine.");
            }
        }

        // Token: 0x060000AD RID: 173 RVA: 0x0000962A File Offset: 0x0000782A
        private void hTTPRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new HttpRequests().Show();
        }

        // Token: 0x060000AE RID: 174 RVA: 0x00009638 File Offset: 0x00007838
        private void button1_Click_1(object sender, EventArgs e)
        {

            bool reg = this.Reg;
            if (reg)
            {
                this.button1.BackColor = Color.FromArgb(64, 64, 64);
                this.button2.BackColor = Color.FromArgb(44, 44, 44);
            }
            this.Cache = false;
        }

        // Token: 0x060000AF RID: 175 RVA: 0x000096A4 File Offset: 0x000078A4
        private void button2_Click_1(object sender, EventArgs e)
        {

            bool reg = this.Reg;
            if (reg)
            {
                this.button2.BackColor = Color.FromArgb(64, 64, 64);
                this.button1.BackColor = Color.FromArgb(44, 44, 44);
            }
            this.Cache = true;
        }

        // Token: 0x060000B0 RID: 176 RVA: 0x00009710 File Offset: 0x00007910
        private void DELETELOGS_Tick(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
        }

        // Token: 0x060000B1 RID: 177 RVA: 0x00009738 File Offset: 0x00007938
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Inject("C:/Windows/SysWOW64/msvcd140p.dll");
            MessageBox.Show("Injected.");
        }

        // Token: 0x060000B2 RID: 178 RVA: 0x00009754 File Offset: 0x00007954
        private void TextEditorTick_Tick(object sender, EventArgs e)
        {
            try
            {
                string text = File.ReadAllText("C:/Bleu/TEXTEDITOR");
                string z = File.ReadAllText("C:/Bleu/TEXTEDITORNAME");
                bool flag = text != "~";
                if (flag)
                {

                }
                File.WriteAllText("C:/Bleu/TEXTEDITOR", "~");
            }
            catch
            {
            }
        }

        // Token: 0x060000B3 RID: 179 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void loadHackToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x060000B4 RID: 180 RVA: 0x000097C8 File Offset: 0x000079C8
        private void toolStripMenuItem16_Click_1(object sender, EventArgs e)
        {
            //new rc7().Show();
        }

        // Token: 0x060000B5 RID: 181 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x060000B6 RID: 182 RVA: 0x000097D8 File Offset: 0x000079D8
        private void ColorForm(Control.ControlCollection C, Color A, Color B)
        {
            try
            {
                this.BackColor = A;
                foreach (object obj in C)
                {
                    Control control = (Control)obj;
                    bool flag = control != this.FindPanel && control != this.scriptBox;
                    if (flag)
                    {
                        try
                        {
                            bool flag2 = control != this.InjectButton;
                            if (flag2)
                            {
                                control.ForeColor = B;
                            }
                            control.BackColor = A;
                        }
                        catch
                        {
                        }
                        try
                        {
                            bool flag3 = control != this.InjectButton;
                            if (flag3)
                            {
                                control.ForeColor = B;
                            }
                        }
                        catch
                        {
                        }
                        bool hasChildren = control.HasChildren;
                        if (hasChildren)
                        {
                            this.ColorForm(control.Controls, A, B);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        // Token: 0x060000B7 RID: 183 RVA: 0x000098F4 File Offset: 0x00007AF4
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Reg = true;
            this.ColorForm(base.Controls, Color.FromArgb(44, 44, 44), SystemColors.ControlLight);
        }

        // Token: 0x060000B8 RID: 184 RVA: 0x0000991B File Offset: 0x00007B1B
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Reg = false;
        }

        // Token: 0x060000B9 RID: 185 RVA: 0x00002DD4 File Offset: 0x00000FD4
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x060000BA RID: 186 RVA: 0x00009925 File Offset: 0x00007B25
        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            //new Elysian().Show();
        }

        // Token: 0x060000BB RID: 187 RVA: 0x00009933 File Offset: 0x00007B33
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            //new Seven().Show();
        }

        // Token: 0x060000BC RID: 188 RVA: 0x00009941 File Offset: 0x00007B41
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //new Snowfall().Show();
        }

        // Token: 0x060000BD RID: 189 RVA: 0x000097C8 File Offset: 0x000079C8
        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            //new rc7().Show();
        }

        // Token: 0x04000058 RID: 88
        private const int EM_SETCUEBANNER = 5377;

        // Token: 0x0400005A RID: 90
        private bool AutoHook = true;

        // Token: 0x0400005B RID: 91
        private const int PROCESS_CREATE_THREAD = 2;

        // Token: 0x0400005C RID: 92
        private const int PROCESS_QUERY_INFORMATION = 1024;

        // Token: 0x0400005D RID: 93
        private const int PROCESS_VM_OPERATION = 8;

        // Token: 0x0400005E RID: 94
        private const int PROCESS_VM_WRITE = 32;

        // Token: 0x0400005F RID: 95
        private const int PROCESS_VM_READ = 16;

        // Token: 0x04000060 RID: 96
        private const uint MEM_COMMIT = 4096u;

        // Token: 0x04000061 RID: 97
        private const uint MEM_RESERVE = 8192u;

        // Token: 0x04000062 RID: 98
        private const uint PAGE_READWRITE = 4u;

        // Token: 0x04000063 RID: 99
        private int INPUT_EXECUTE = 1;

        // Token: 0x04000064 RID: 100
        private int INPUT_UPDATESETTINGS = 2;

        // Token: 0x04000065 RID: 101
        private int TYPE_TRUSTCHECK = 1;

        // Token: 0x04000066 RID: 102
        private int TYPE_CUSTOMENV = 2;

        // Token: 0x04000067 RID: 103
        private int OUTPUT_BLEUOUTPUT = 1;

        // Token: 0x04000068 RID: 104
        private int TYPE_PRINT = 0;

        // Token: 0x04000069 RID: 105
        private int TYPE_WARN = 1;

        // Token: 0x0400006A RID: 106
        private int TYPE_ERROR = 2;

        // Token: 0x0400006B RID: 107
        private int TYPE_INFO = 3;

        // Token: 0x0400006C RID: 108
        private int OUTPUT_MESSAGE = 2;

        // Token: 0x0400006D RID: 109
        private int TYPE_WARNINGICON = 1;

        // Token: 0x0400006E RID: 110
        private int TYPE_ERRORICON = 2;

        // Token: 0x0400006F RID: 111
        private int TYPE_INFORMATIONICON = 3;

        // Token: 0x04000070 RID: 112
        private int INPUT_FASTEXECUTE = 3;

        // Token: 0x04000071 RID: 113
        private int maxLineNumberCharLength;

        // Token: 0x04000072 RID: 114
        private bool Active = true;

        // Token: 0x04000073 RID: 115
        private bool Open = false;

        // Token: 0x04000074 RID: 116
        private bool Cache = false;

        // Token: 0x04000075 RID: 117
        private string FileLocation = "";

        // Token: 0x04000076 RID: 118
        private int Position = 1;

        // Token: 0x04000077 RID: 119
        private bool MatchCase = false;

        // Token: 0x04000078 RID: 120
        private bool InjectOk = true;

        // Token: 0x04000079 RID: 121
        private bool OpenScript = false;

        // Token: 0x0400007A RID: 122
        private bool Library = false;

        // Token: 0x0400007B RID: 123
        private string ScriptString;

        // Token: 0x0400007C RID: 124
        private List<string> StringArray = new List<string>();

        // Token: 0x0400007D RID: 125
        private string Lib = "";

        // Token: 0x0400007E RID: 126
        private string[] Cmds = new string[]
        {
            "cmds",
            "kill plr",
            "ff plr",
            "explode plr",
            "fire plr",
            "sparkles plr",
            "tp plr plr",
            "ws plr num",
            "jp plr num",
            "hh plr num",
            "kanapapaia plr",
            "btools plr",
            "run script",
            "rejoin",
            "kick plr"
        };

        // Token: 0x0400007F RID: 127
        private string SL = null;

        // Token: 0x04000080 RID: 128
        private List<string> Previous = new List<string>();

        // Token: 0x04000081 RID: 129
        private int loc = 0;

        // Token: 0x04000082 RID: 130
        private static Random random = new Random();

        // Token: 0x04000083 RID: 131
        private bool Reg = true;

        private void label5_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            label5.BackColor = BorderFocus;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.FromArgb(63, 63, 65);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void label5_MouseUp(object sender, MouseEventArgs e)
        {
            label5.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            label6.BackColor = BorderFocus;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.BackColor = Color.FromArgb(63, 63, 65);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void label6_MouseUp(object sender, MouseEventArgs e)
        {
            label6.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void NewTab_MouseDown(object sender, MouseEventArgs e)
        {
            NewTab.BackColor = BorderFocus;
        }

        private void NewTab_MouseEnter(object sender, EventArgs e)
        {
            NewTab.BackColor = Color.FromArgb(63, 63, 65);
        }

        private void NewTab_MouseLeave(object sender, EventArgs e)
        {
            NewTab.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void NewTab_MouseUp(object sender, MouseEventArgs e)
        {
            NewTab.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void NewTab_Click(object sender, EventArgs e)
        {
            if (Tabs == 1)
            {
                Tab1Data = fastColoredTextBox1.Text;
                fastColoredTextBox1.Text = "";
                Tab2.Visible = true;
                Tab1.BackColor = Color.FromArgb(45, 45, 48);
                Tabs = 2;
                CurrentTab = 2;
                SaveButton.Location = new System.Drawing.Point(226, 31);
                return;
            }
            if (Tabs == 2)
            {
                if (CurrentTab == 1)
                {
                    Tab1Data = fastColoredTextBox1.Text;
                    fastColoredTextBox1.Text = "";
                    Tab3.Visible = true;
                    Tab2.BackColor = Color.FromArgb(45, 45, 48);
                    Tab1.BackColor = Color.FromArgb(45, 45, 48);
                    Tabs = 3;
                    CurrentTab = 3;
                }
                if (CurrentTab == 2)
                {
                    Tab2Data = fastColoredTextBox1.Text;
                    fastColoredTextBox1.Text = "";
                    Tab3.Visible = true;
                    Tab2.BackColor = Color.FromArgb(45, 45, 48);
                    Tab1.BackColor = Color.FromArgb(45, 45, 48);
                    Tabs = 3;
                    CurrentTab = 3;
                }
                NewTab.Visible = false;
                pictureBox3.Location = new System.Drawing.Point(555, 29);
                SaveButton.Location = new System.Drawing.Point(327, 31);
                return;
            }
        }

        private void Tab1_Click(object sender, EventArgs e)
        {
            if (Tabs == 1)
            {
                return;
            }
            if (CurrentTab == 1)
            {
                return;
            }
            if (CurrentTab == 2)
            {
                Tab2Data = fastColoredTextBox1.Text;
                fastColoredTextBox1.Text = Tab1Data;
                Tab1.BackColor = BorderFocus;
                Tab2.BackColor = Color.FromArgb(45, 45, 48);
                CurrentTab = 1;
            }
            if (CurrentTab == 3)
            {
                Tab3Data = fastColoredTextBox1.Text;
                fastColoredTextBox1.Text = Tab1Data;
                Tab1.BackColor = BorderFocus;
                Tab2.BackColor = Color.FromArgb(45, 45, 48);
                Tab3.BackColor = Color.FromArgb(45, 45, 48);
                CurrentTab = 1;
            }
        }

        private void Tab2_Click(object sender, EventArgs e)
        {
            if (CurrentTab == 2)
            {
                return;
            }
            if (CurrentTab == 1)
            {
                Tab1Data = fastColoredTextBox1.Text;
                fastColoredTextBox1.Text = Tab2Data;
                Tab2.BackColor = BorderFocus;
                Tab1.BackColor = Color.FromArgb(45, 45, 48);
                Tab3.BackColor = Color.FromArgb(45, 45, 48);
                CurrentTab = 2;
            }
            if (CurrentTab == 3)
            {
                Tab3Data = fastColoredTextBox1.Text;
                fastColoredTextBox1.Text = Tab2Data;
                Tab2.BackColor = BorderFocus;
                Tab1.BackColor = Color.FromArgb(45, 45, 48);
                Tab3.BackColor = Color.FromArgb(45, 45, 48);
                CurrentTab = 2;
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("There are " + Tabs.ToString() + " Tabs");
            MessageBox.Show("Your on Number " + CurrentTab.ToString() + " Tab");
        }

        private void Tab3_Click(object sender, EventArgs e)
        {
            if (CurrentTab == 3)
            {
                return;
            }
            if (CurrentTab == 1)
            {
                Tab1Data = fastColoredTextBox1.Text;
                fastColoredTextBox1.Text = Tab3Data;
                Tab3.BackColor = BorderFocus;
                Tab2.BackColor = Color.FromArgb(45, 45, 48);
                Tab1.BackColor = Color.FromArgb(45, 45, 48);
                CurrentTab = 3;
            }
            if (CurrentTab == 2)
            {
                Tab2Data = fastColoredTextBox1.Text;
                fastColoredTextBox1.Text = Tab3Data;
                Tab3.BackColor = BorderFocus;
                Tab2.BackColor = Color.FromArgb(45, 45, 48);
                Tab1.BackColor = Color.FromArgb(45, 45, 48);
                CurrentTab = 3;
            }
        }

        private void SaveButton_MouseDown(object sender, MouseEventArgs e)
        {
            SaveButton.BackColor = BorderFocus;
        }

        private void SaveButton_MouseEnter(object sender, EventArgs e)
        {
            SaveButton.BackColor = Color.FromArgb(63, 63, 65);
        }

        private void SaveButton_MouseLeave(object sender, EventArgs e)
        {
            SaveButton.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void SaveButton_MouseUp(object sender, MouseEventArgs e)
        {
            SaveButton.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (CurrentTab == 1)
            {
                if (Tab1SavedBefore == false)
                {
                    SaveTab.FileName = "Untitled.txt";
                    SaveTab.ShowDialog();
                }
                else
                {
                    System.IO.File.WriteAllText(Tab1Dir, fastColoredTextBox1.Text);
                }
            }
            if (CurrentTab == 2)
            {
                if (Tab2SavedBefore == false)
                {
                    SaveTab.FileName = "Untitled.txt";
                    SaveTab.ShowDialog();
                }
                else
                {
                    System.IO.File.WriteAllText(Tab2Dir, fastColoredTextBox1.Text);
                }
            }
            if (CurrentTab == 3)
            {
                if (Tab3SavedBefore == false)
                {
                    SaveTab.FileName = "Untitled.txt";
                    SaveTab.ShowDialog();
                }
                else
                {
                    System.IO.File.WriteAllText(Tab3Dir, fastColoredTextBox1.Text);
                }
            }
        }

        private void SaveTab_FileOk(object sender, CancelEventArgs e)
        {
            if (CurrentTab == 1)
            {
                Tab1SavedBefore = true;
                Tab1Dir = SaveTab.FileName;
                Tab1.Text = Path.GetFileName(SaveTab.FileName);
            }
            if (CurrentTab == 2)
            {
                Tab2SavedBefore = true;
                Tab2Dir = SaveTab.FileName;
                Tab2.Text = Path.GetFileName(SaveTab.FileName);
            }
            if (CurrentTab == 3)
            {
                Tab3SavedBefore = true;
                Tab3Dir = SaveTab.FileName;
                Tab3.Text = Path.GetFileName(SaveTab.FileName);
            }
            System.IO.File.WriteAllText(SaveTab.FileName, fastColoredTextBox1.Text);
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
                if (Reset == true)
                {
                    pictureBox2.BackColor = Color.FromArgb(45, 45, 48);
                    pictureBox2.Image = Properties.Resources.Slider;
                    Reset = false;
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
            Reset = true;
        }

        private void pictureBox2_DragLeave(object sender, EventArgs e)
        {
            //pictureBox2.Location.X = Cursor.Position.X;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = BorderFocus;
            pictureBox2.Image = Properties.Resources.Slider2;
        }

        private void fastColoredTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(45, 45, 48);
            pictureBox2.Image = Properties.Resources.Slider;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(45, 45, 48);
            pictureBox2.Image = Properties.Resources.Slider;
            fastColoredTextBox1.Text = client.DownloadString("http://yakasoftapi.ml/Files/Scripts/" + listBox1.GetItemText(listBox1.SelectedItem));
            if (CurrentTab == 1)
            {
                Tab1.Text = listBox1.GetItemText(listBox1.SelectedItem);
            }
            if (CurrentTab == 2)
            {
                Tab2.Text = listBox1.GetItemText(listBox1.SelectedItem);
            }
            if (CurrentTab == 3)
            {
                Tab3.Text = listBox1.GetItemText(listBox1.SelectedItem);
            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.BackColor = BorderFocus;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(63, 63, 65);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
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
            pictureBox3.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            listBox1.TopIndex = UpTo;
            UpTo = UpTo + 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Bleu == true)
            {
                timer1.Enabled = false;
                return;
            }
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length > 0)
            {

            }
            else
            {
                Injected = false;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Mouselocation = e.Location;
                if (Reset2 == false)
                {
                    pictureBox2.BackColor = BorderFocus;
                    pictureBox2.Image = Properties.Resources.Slider2;
                    Reset2 = true;
                }
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //Working - //pictureBox2.Left = e.X + pictureBox2.Left - Mouselocation.X;
                //pictureBox2.Top = e.Y + pictureBox2.Top - Mouselocation.Y;
                //works kinda listBox1.Width = e.X + pictureBox2.Left - Mouselocation.X;
                //works kinda listBox1.Left = e.X + pictureBox2.Left - Mouselocation.X;
            }
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            label8.BackColor = BorderFocus;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.FromArgb(63, 63, 65);
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            //label8.BackColor = Color.FromArgb(45, 45, 48);
            label8.BackColor = Color.Transparent;
        }

        private void label8_MouseUp(object sender, MouseEventArgs e)
        {
            //label8.BackColor = Color.FromArgb(45, 45, 48);
            label8.BackColor = Color.Transparent;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (Injected == false)
            {
                api.LaunchExploit();
                Injected = true;
                label9.Text = "Attached";
                label10.Visible = false;
            }
            else
            {
                api.SendLimitedLuaScript(fastColoredTextBox1.Text);
            }
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            label10.BackColor = Color.FromArgb(51, 149, 214);
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.BackColor = BorderFocus;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
            Injected = true;
            label9.Text = "Attached";
            label10.Visible = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length > 0)
            {
                Injected = true;
                label9.Text = "Attached";
                label10.Visible = false;
            }
            else
            {
                Injected = false;
                label9.Text = "Not Injected";
                label10.Visible = true;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            YakaHackTheme newInstance = new YakaHackTheme();
            newInstance.Show();
        }

        private void accountInfoVS1_Leave(object sender, EventArgs e)
        {
            accountInfoVS1.Visible = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            accountInfoVS1.Visible = true;
            accountInfoVS1.Focus();
        }

        private void Light()
        {
            this.BackColor = Color.FromArgb(238, 238, 242);
            BorderFocus = Color.FromArgb(203, 205, 218);
            BorderNonFocus = Color.FromArgb(237, 237, 241);
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            ChangeTheme CTheme = new ChangeTheme();
            CTheme.ShowDialog();
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox4.BackColor = BorderFocus;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(63, 63, 65);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void fastColoredTextBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            Color StringColor = Color.FromArgb(214, 157, 133);
            e.ChangedRange.SetStyle(CommentStyle, "--.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(Style1, "local", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(StringStyle, "\".*\"", RegexOptions.Multiline);

        }
    }
}
