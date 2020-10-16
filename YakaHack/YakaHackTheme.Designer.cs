namespace YakaHack
{
    // Token: 0x02000007 RID: 7
    public partial class YakaHackTheme : global::System.Windows.Forms.Form
    {
        // Token: 0x060000BE RID: 190 RVA: 0x00009950 File Offset: 0x00007B50
        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && this.components != null;
            if (flag)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x060000BF RID: 191 RVA: 0x00009988 File Offset: 0x00007B88
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YakaHackTheme));
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.InjectButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CmdBox = new System.Windows.Forms.TextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.PictureBox();
            this.scriptBox = new System.Windows.Forms.ListBox();
            this.FindPanel = new System.Windows.Forms.Panel();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.button21 = new System.Windows.Forms.Button();
            this.FindForward = new System.Windows.Forms.Button();
            this.FindBack = new System.Windows.Forms.Button();
            this.FindClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FindBox = new System.Windows.Forms.TextBox();
            this.searchScriptBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Injector = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ohToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moonyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sADMARGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aFewLeavestoGoInASaladToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bleuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bleuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.windows98ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OutputCheck = new System.Windows.Forms.Timer(this.components);
            this.CmdMatches = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PissOff = new System.Windows.Forms.Timer(this.components);
            this.DELETELOGS = new System.Windows.Forms.Timer(this.components);
            this.TextEditorTick = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.Tab1 = new System.Windows.Forms.Label();
            this.NewTab = new System.Windows.Forms.Label();
            this.Tab2 = new System.Windows.Forms.Label();
            this.Tab3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SaveTab = new System.Windows.Forms.SaveFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.PictureBox();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.accountInfoVS1 = new YakaHack.AccountInfoVS();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitter1)).BeginInit();
            this.FindPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
            this.SuspendLayout();
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Interval = 1;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.InjectButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.CmdBox);
            this.panel1.Controls.Add(this.RegisterButton);
            this.panel1.Controls.Add(this.button19);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.scriptBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 347);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 27);
            this.panel1.TabIndex = 18;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(535, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 18);
            this.label10.TabIndex = 45;
            this.label10.Text = "Inject";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            this.label10.MouseEnter += new System.EventHandler(this.label10_MouseEnter);
            this.label10.MouseLeave += new System.EventHandler(this.label10_MouseLeave);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(581, 22);
            this.label9.TabIndex = 44;
            this.label9.Text = "Not Injected";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(210, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 12);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(143, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 26);
            this.button2.TabIndex = 42;
            this.button2.Text = "Cache";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // InjectButton
            // 
            this.InjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InjectButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.InjectButton.FlatAppearance.BorderSize = 0;
            this.InjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InjectButton.ForeColor = System.Drawing.Color.Lime;
            this.InjectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.InjectButton.Location = new System.Drawing.Point(727, -185);
            this.InjectButton.Name = "InjectButton";
            this.InjectButton.Size = new System.Drawing.Size(41, 19);
            this.InjectButton.TabIndex = 39;
            this.InjectButton.Text = "Inject";
            this.InjectButton.UseVisualStyleBackColor = true;
            this.InjectButton.Visible = false;
            this.InjectButton.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(82, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 26);
            this.button1.TabIndex = 41;
            this.button1.Text = "Wrap ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // CmdBox
            // 
            this.CmdBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CmdBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.CmdBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CmdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.CmdBox.Location = new System.Drawing.Point(621, 4);
            this.CmdBox.MaxLength = 500;
            this.CmdBox.Name = "CmdBox";
            this.CmdBox.Size = new System.Drawing.Size(128, 20);
            this.CmdBox.TabIndex = 40;
            this.CmdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CmdBox.Visible = false;
            this.CmdBox.TextChanged += new System.EventHandler(this.CmdBox_TextChanged);
            this.CmdBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmdBox_KeyDown);
            this.CmdBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmdBox_KeyPress);
            this.CmdBox.Leave += new System.EventHandler(this.CmdBox_Leave);
            // 
            // RegisterButton
            // 
            this.RegisterButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RegisterButton.Image = ((System.Drawing.Image)(resources.GetObject("RegisterButton.Image")));
            this.RegisterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RegisterButton.Location = new System.Drawing.Point(1, 0);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(73, 27);
            this.RegisterButton.TabIndex = 14;
            this.RegisterButton.Text = "Execute";
            this.RegisterButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Visible = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // button19
            // 
            this.button19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button19.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button19.FlatAppearance.BorderSize = 0;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button19.Location = new System.Drawing.Point(769, -185);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(25, 19);
            this.button19.TabIndex = 34;
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Visible = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Gray;
            this.splitter1.Location = new System.Drawing.Point(75, 7);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 12);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // scriptBox
            // 
            this.scriptBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptBox.FormattingEnabled = true;
            this.scriptBox.Location = new System.Drawing.Point(630, -136);
            this.scriptBox.Name = "scriptBox";
            this.scriptBox.Size = new System.Drawing.Size(162, 264);
            this.scriptBox.TabIndex = 37;
            this.scriptBox.Visible = false;
            this.scriptBox.SelectedIndexChanged += new System.EventHandler(this.scriptBox_SelectedIndexChanged);
            // 
            // FindPanel
            // 
            this.FindPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.FindPanel.Controls.Add(this.ResultLabel);
            this.FindPanel.Controls.Add(this.button21);
            this.FindPanel.Controls.Add(this.FindForward);
            this.FindPanel.Controls.Add(this.FindBack);
            this.FindPanel.Controls.Add(this.FindClose);
            this.FindPanel.Controls.Add(this.panel3);
            this.FindPanel.Controls.Add(this.FindBox);
            this.FindPanel.Location = new System.Drawing.Point(610, 59);
            this.FindPanel.Name = "FindPanel";
            this.FindPanel.Size = new System.Drawing.Size(280, 51);
            this.FindPanel.TabIndex = 36;
            this.FindPanel.Visible = false;
            // 
            // ResultLabel
            // 
            this.ResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ResultLabel.ForeColor = System.Drawing.Color.Black;
            this.ResultLabel.Location = new System.Drawing.Point(47, 28);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(0, 13);
            this.ResultLabel.TabIndex = 19;
            // 
            // button21
            // 
            this.button21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.button21.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button21.FlatAppearance.BorderSize = 0;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(24, 28);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(17, 17);
            this.button21.TabIndex = 36;
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button14_Click);
            // 
            // FindForward
            // 
            this.FindForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FindForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.FindForward.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.FindForward.FlatAppearance.BorderSize = 0;
            this.FindForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FindForward.Location = new System.Drawing.Point(237, 8);
            this.FindForward.Name = "FindForward";
            this.FindForward.Size = new System.Drawing.Size(17, 17);
            this.FindForward.TabIndex = 35;
            this.FindForward.UseVisualStyleBackColor = false;
            this.FindForward.Click += new System.EventHandler(this.FindForward_Click);
            // 
            // FindBack
            // 
            this.FindBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FindBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.FindBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.FindBack.FlatAppearance.BorderSize = 0;
            this.FindBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FindBack.Location = new System.Drawing.Point(216, 8);
            this.FindBack.Name = "FindBack";
            this.FindBack.Size = new System.Drawing.Size(17, 17);
            this.FindBack.TabIndex = 34;
            this.FindBack.UseVisualStyleBackColor = false;
            this.FindBack.Click += new System.EventHandler(this.FindBack_Click);
            // 
            // FindClose
            // 
            this.FindClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FindClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.FindClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.FindClose.FlatAppearance.BorderSize = 0;
            this.FindClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FindClose.Location = new System.Drawing.Point(260, 8);
            this.FindClose.Name = "FindClose";
            this.FindClose.Size = new System.Drawing.Size(17, 17);
            this.FindClose.TabIndex = 18;
            this.FindClose.UseVisualStyleBackColor = false;
            this.FindClose.Click += new System.EventHandler(this.FindClose_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Location = new System.Drawing.Point(1, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 4);
            this.panel3.TabIndex = 33;
            // 
            // FindBox
            // 
            this.FindBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FindBox.BackColor = System.Drawing.Color.White;
            this.FindBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FindBox.Location = new System.Drawing.Point(24, 5);
            this.FindBox.Name = "FindBox";
            this.FindBox.Size = new System.Drawing.Size(192, 20);
            this.FindBox.TabIndex = 17;
            this.FindBox.Tag = "";
            this.FindBox.TextChanged += new System.EventHandler(this.FindBox_TextChanged);
            this.FindBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindBox_KeyDown);
            // 
            // searchScriptBox
            // 
            this.searchScriptBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchScriptBox.Location = new System.Drawing.Point(655, 12);
            this.searchScriptBox.Name = "searchScriptBox";
            this.searchScriptBox.Size = new System.Drawing.Size(162, 20);
            this.searchScriptBox.TabIndex = 38;
            this.searchScriptBox.Visible = false;
            this.searchScriptBox.TextChanged += new System.EventHandler(this.searchScriptBox_TextChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Lua files|*.lua;*.txt|All files|*.*";
            this.saveFileDialog1.Title = "Save Script";
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.AddExtension = false;
            this.OpenFileDialog1.Filter = "Lua files|*.lua;*.txt|All files|*.*";
            this.OpenFileDialog1.SupportMultiDottedExtensions = true;
            this.OpenFileDialog1.Title = "Open Script";
            // 
            // Injector
            // 
            this.Injector.Tick += new System.EventHandler(this.Injector_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ohToolStripMenuItem,
            this.moonyToolStripMenuItem,
            this.sADMARGToolStripMenuItem,
            this.aFewLeavestoGoInASaladToolStripMenuItem,
            this.toolStripSeparator1,
            this.redToolStripMenuItem,
            this.bleuToolStripMenuItem,
            this.bleuToolStripMenuItem1,
            this.windows98ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(229, 186);
            // 
            // ohToolStripMenuItem
            // 
            this.ohToolStripMenuItem.Name = "ohToolStripMenuItem";
            this.ohToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.ohToolStripMenuItem.Text = "Zinnia";
            // 
            // moonyToolStripMenuItem
            // 
            this.moonyToolStripMenuItem.Name = "moonyToolStripMenuItem";
            this.moonyToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.moonyToolStripMenuItem.Text = "Moony (my baby)";
            // 
            // sADMARGToolStripMenuItem
            // 
            this.sADMARGToolStripMenuItem.Name = "sADMARGToolStripMenuItem";
            this.sADMARGToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.sADMARGToolStripMenuItem.Text = "SAD MARG";
            // 
            // aFewLeavestoGoInASaladToolStripMenuItem
            // 
            this.aFewLeavestoGoInASaladToolStripMenuItem.Name = "aFewLeavestoGoInASaladToolStripMenuItem";
            this.aFewLeavestoGoInASaladToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.aFewLeavestoGoInASaladToolStripMenuItem.Text = "a few leaves (to go in a salad)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.redToolStripMenuItem.Text = "Red";
            // 
            // bleuToolStripMenuItem
            // 
            this.bleuToolStripMenuItem.Name = "bleuToolStripMenuItem";
            this.bleuToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.bleuToolStripMenuItem.Text = "Green";
            // 
            // bleuToolStripMenuItem1
            // 
            this.bleuToolStripMenuItem1.Name = "bleuToolStripMenuItem1";
            this.bleuToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.bleuToolStripMenuItem1.Text = "Bleu";
            // 
            // windows98ToolStripMenuItem
            // 
            this.windows98ToolStripMenuItem.Name = "windows98ToolStripMenuItem";
            this.windows98ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.windows98ToolStripMenuItem.Text = "Windows 95";
            // 
            // OutputCheck
            // 
            this.OutputCheck.Interval = 50;
            this.OutputCheck.Tick += new System.EventHandler(this.OutputCheck_Tick);
            // 
            // CmdMatches
            // 
            this.CmdMatches.AutoClose = false;
            this.CmdMatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.CmdMatches.Name = "CmdMatches";
            this.CmdMatches.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.CmdMatches.ShowImageMargin = false;
            this.CmdMatches.Size = new System.Drawing.Size(36, 4);
            // 
            // PissOff
            // 
            this.PissOff.Interval = 4000;
            this.PissOff.Tick += new System.EventHandler(this.PissOff_Tick);
            // 
            // DELETELOGS
            // 
            this.DELETELOGS.Interval = 3000;
            this.DELETELOGS.Tick += new System.EventHandler(this.DELETELOGS_Tick);
            // 
            // TextEditorTick
            // 
            this.TextEditorTick.Interval = 500;
            this.TextEditorTick.Tick += new System.EventHandler(this.TextEditorTick_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(-9, -22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(606, 23);
            this.label1.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label2.Location = new System.Drawing.Point(-12, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(606, 23);
            this.label2.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label3.Location = new System.Drawing.Point(-22, -8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 606);
            this.label3.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label4.Location = new System.Drawing.Point(581, -134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 606);
            this.label4.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Miriam", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(548, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 23);
            this.label5.TabIndex = 43;
            this.label5.Text = "X";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label5_MouseDown);
            this.label5.MouseEnter += new System.EventHandler(this.label5_MouseEnter);
            this.label5.MouseLeave += new System.EventHandler(this.label5_MouseLeave);
            this.label5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label5_MouseUp);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Wide Latin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(511, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 23);
            this.label6.TabIndex = 44;
            this.label6.Text = "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label6_MouseDown);
            this.label6.MouseEnter += new System.EventHandler(this.label6_MouseEnter);
            this.label6.MouseLeave += new System.EventHandler(this.label6_MouseLeave);
            this.label6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label6_MouseUp);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label7.Location = new System.Drawing.Point(9, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(566, 2);
            this.label7.TabIndex = 45;
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox1.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>.+)\r\n";
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.fastColoredTextBox1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fastColoredTextBox1.CharHeight = 14;
            this.fastColoredTextBox1.CharWidth = 8;
            this.fastColoredTextBox1.CommentPrefix = "--";
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.ForeColor = System.Drawing.Color.White;
            this.fastColoredTextBox1.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.LeftBracket = '(';
            this.fastColoredTextBox1.LeftBracket2 = '{';
            this.fastColoredTextBox1.Location = new System.Drawing.Point(9, 49);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.RightBracket = ')';
            this.fastColoredTextBox1.RightBracket2 = '}';
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(79)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = null;
            this.fastColoredTextBox1.ServiceLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(566, 292);
            this.fastColoredTextBox1.TabIndex = 46;
            this.fastColoredTextBox1.Zoom = 100;
            this.fastColoredTextBox1.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fastColoredTextBox1_TextChanged);
            this.fastColoredTextBox1.Load += new System.EventHandler(this.fastColoredTextBox1_Load);
            this.fastColoredTextBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.fastColoredTextBox1_Paint);
            this.fastColoredTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fastColoredTextBox1_MouseClick);
            // 
            // Tab1
            // 
            this.Tab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Tab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab1.ForeColor = System.Drawing.Color.White;
            this.Tab1.Location = new System.Drawing.Point(28, 31);
            this.Tab1.Name = "Tab1";
            this.Tab1.Size = new System.Drawing.Size(95, 18);
            this.Tab1.TabIndex = 47;
            this.Tab1.Text = "Untitled";
            this.Tab1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Tab1.Click += new System.EventHandler(this.Tab1_Click);
            // 
            // NewTab
            // 
            this.NewTab.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewTab.ForeColor = System.Drawing.Color.White;
            this.NewTab.Location = new System.Drawing.Point(563, 32);
            this.NewTab.Name = "NewTab";
            this.NewTab.Size = new System.Drawing.Size(13, 13);
            this.NewTab.TabIndex = 48;
            this.NewTab.Text = "+";
            this.NewTab.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NewTab.Click += new System.EventHandler(this.NewTab_Click);
            this.NewTab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewTab_MouseDown);
            this.NewTab.MouseEnter += new System.EventHandler(this.NewTab_MouseEnter);
            this.NewTab.MouseLeave += new System.EventHandler(this.NewTab_MouseLeave);
            this.NewTab.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NewTab_MouseUp);
            // 
            // Tab2
            // 
            this.Tab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Tab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab2.ForeColor = System.Drawing.Color.White;
            this.Tab2.Location = new System.Drawing.Point(129, 31);
            this.Tab2.Name = "Tab2";
            this.Tab2.Size = new System.Drawing.Size(95, 18);
            this.Tab2.TabIndex = 49;
            this.Tab2.Text = "Untitled";
            this.Tab2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Tab2.Visible = false;
            this.Tab2.Click += new System.EventHandler(this.Tab2_Click);
            // 
            // Tab3
            // 
            this.Tab3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Tab3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab3.ForeColor = System.Drawing.Color.White;
            this.Tab3.Location = new System.Drawing.Point(230, 31);
            this.Tab3.Name = "Tab3";
            this.Tab3.Size = new System.Drawing.Size(95, 18);
            this.Tab3.TabIndex = 50;
            this.Tab3.Text = "Untitled";
            this.Tab3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Tab3.Visible = false;
            this.Tab3.Click += new System.EventHandler(this.Tab3_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(372, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 53;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // SaveTab
            // 
            this.SaveTab.FileName = "Untitled.txt";
            this.SaveTab.Filter = "Text Files (*.txt)|*.txt|Lua Scripts (*.Lua)|*.Lua|All Files (*.*)|*.*";
            this.SaveTab.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveTab_FileOk);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 24);
            this.panel2.TabIndex = 55;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Image = global::YakaHack.Properties.Resources.Run_16x;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(164, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 23);
            this.label8.TabIndex = 61;
            this.label8.Text = "      Execute";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label8_MouseDown);
            this.label8.MouseEnter += new System.EventHandler(this.label8_MouseEnter);
            this.label8.MouseLeave += new System.EventHandler(this.label8_MouseLeave);
            this.label8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label8_MouseUp);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(420, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(156, 286);
            this.listBox1.TabIndex = 56;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(372, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 59;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(427, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 14);
            this.label11.TabIndex = 64;
            this.label11.Text = "<UserName>";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(114)))));
            this.label12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(511, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 19);
            this.label12.TabIndex = 65;
            this.label12.Text = "U";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(166, 11);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(2, 14);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 63;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(238, 8);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(18, 18);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 60;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click_1);
            this.pictureBox4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseDown);
            this.pictureBox4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            this.pictureBox4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseUp);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(234, 11);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(2, 14);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 62;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::YakaHack.Properties.Resources.NewFile_16x;
            this.pictureBox5.Location = new System.Drawing.Point(146, 8);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(18, 18);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 61;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::YakaHack.Properties.Resources.Arrow;
            this.pictureBox3.Location = new System.Drawing.Point(539, 31);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 18);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 58;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
            this.pictureBox3.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::YakaHack.Properties.Resources.Slider;
            this.pictureBox2.Location = new System.Drawing.Point(404, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 290);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.DragLeave += new System.EventHandler(this.pictureBox2_DragLeave);
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // SaveButton
            // 
            this.SaveButton.Image = global::YakaHack.Properties.Resources.Save;
            this.SaveButton.Location = new System.Drawing.Point(125, 31);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(18, 18);
            this.SaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SaveButton.TabIndex = 54;
            this.SaveButton.TabStop = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SaveButton_MouseDown);
            this.SaveButton.MouseEnter += new System.EventHandler(this.SaveButton_MouseEnter);
            this.SaveButton.MouseLeave += new System.EventHandler(this.SaveButton_MouseLeave);
            this.SaveButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SaveButton_MouseUp);
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
            this.dotNetBarManager1.BottomDockSite = this.dockSite4;
            this.dotNetBarManager1.EnableFullSizeDock = false;
            this.dotNetBarManager1.LeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ParentForm = this;
            this.dotNetBarManager1.RightDockSite = this.dockSite2;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite8;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite5;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite6;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite7;
            this.dotNetBarManager1.TopDockSite = this.dockSite3;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite4.Location = new System.Drawing.Point(0, 374);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(582, 0);
            this.dockSite4.TabIndex = 70;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 347);
            this.dockSite1.TabIndex = 67;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite2.Location = new System.Drawing.Point(582, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 347);
            this.dockSite2.TabIndex = 68;
            this.dockSite2.TabStop = false;
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(0, 374);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(582, 0);
            this.dockSite8.TabIndex = 74;
            this.dockSite8.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(0, 0);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 374);
            this.dockSite5.TabIndex = 71;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(582, 0);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 374);
            this.dockSite6.TabIndex = 72;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(0, 0);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(582, 0);
            this.dockSite7.TabIndex = 73;
            this.dockSite7.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(582, 0);
            this.dockSite3.TabIndex = 69;
            this.dockSite3.TabStop = false;
            // 
            // accountInfoVS1
            // 
            this.accountInfoVS1.BackColor = System.Drawing.Color.Black;
            this.accountInfoVS1.Location = new System.Drawing.Point(302, 49);
            this.accountInfoVS1.Name = "accountInfoVS1";
            this.accountInfoVS1.Size = new System.Drawing.Size(270, 97);
            this.accountInfoVS1.TabIndex = 66;
            this.accountInfoVS1.Visible = false;
            this.accountInfoVS1.Leave += new System.EventHandler(this.accountInfoVS1_Leave);
            // 
            // YakaHackTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(582, 374);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.accountInfoVS1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Tab3);
            this.Controls.Add(this.Tab2);
            this.Controls.Add(this.NewTab);
            this.Controls.Add(this.Tab1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fastColoredTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FindPanel);
            this.Controls.Add(this.searchScriptBox);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(523, 374);
            this.Name = "YakaHackTheme";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bleu";
            this.TopMost = true;
            this.MaximizedBoundsChanged += new System.EventHandler(this.Main_MaximizedBoundsChanged);
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.Deactivate += new System.EventHandler(this.Main_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.LocationChanged += new System.EventHandler(this.Main_LocationChanged);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Main_DragOver);
            this.MouseEnter += new System.EventHandler(this.Main_MouseEnter);
            this.MouseHover += new System.EventHandler(this.Main_MouseHover);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitter1)).EndInit();
            this.FindPanel.ResumeLayout(false);
            this.FindPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Token: 0x04000084 RID: 132
        private global::System.ComponentModel.IContainer components = null;

        // Token: 0x04000085 RID: 133
        private global::System.Windows.Forms.Timer AnimationTimer;

        // Token: 0x04000086 RID: 134
        private global::System.Windows.Forms.Button RegisterButton;

        // Token: 0x04000087 RID: 135
        private global::System.Windows.Forms.PictureBox splitter1;

        // Token: 0x04000088 RID: 136
        private global::System.Windows.Forms.Panel panel1;

        // Token: 0x0400008B RID: 139
        private global::System.Windows.Forms.SaveFileDialog saveFileDialog1;

        // Token: 0x0400008C RID: 140
        public global::System.Windows.Forms.OpenFileDialog OpenFileDialog1;

        // Token: 0x0400008D RID: 141
        private global::System.Windows.Forms.Panel FindPanel;

        // Token: 0x0400008E RID: 142
        private global::System.Windows.Forms.Label ResultLabel;

        // Token: 0x0400008F RID: 143
        private global::System.Windows.Forms.Button button21;

        // Token: 0x04000090 RID: 144
        private global::System.Windows.Forms.Button FindForward;

        // Token: 0x04000091 RID: 145
        private global::System.Windows.Forms.Button FindBack;

        // Token: 0x04000092 RID: 146
        private global::System.Windows.Forms.Button FindClose;

        // Token: 0x04000093 RID: 147
        private global::System.Windows.Forms.Panel panel3;

        // Token: 0x04000094 RID: 148
        private global::System.Windows.Forms.TextBox FindBox;

        // Token: 0x04000095 RID: 149
        private global::System.Windows.Forms.Timer Injector;

        // Token: 0x04000097 RID: 151
        private global::System.Windows.Forms.TextBox searchScriptBox;

        // Token: 0x04000098 RID: 152
        private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        // Token: 0x04000099 RID: 153
        private global::System.Windows.Forms.ToolStripMenuItem ohToolStripMenuItem;

        // Token: 0x0400009A RID: 154
        private global::System.Windows.Forms.Timer OutputCheck;

        // Token: 0x0400009B RID: 155
        private global::System.Windows.Forms.ToolStripMenuItem moonyToolStripMenuItem;

        // Token: 0x0400009C RID: 156
        private global::System.Windows.Forms.ToolStripMenuItem sADMARGToolStripMenuItem;

        // Token: 0x0400009D RID: 157
        private global::System.Windows.Forms.ToolStripMenuItem aFewLeavestoGoInASaladToolStripMenuItem;

        // Token: 0x0400009E RID: 158
        private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

        // Token: 0x0400009F RID: 159
        private global::System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;

        // Token: 0x040000A0 RID: 160
        private global::System.Windows.Forms.ToolStripMenuItem bleuToolStripMenuItem;

        // Token: 0x040000A1 RID: 161
        private global::System.Windows.Forms.ToolStripMenuItem bleuToolStripMenuItem1;

        // Token: 0x040000A2 RID: 162
        private global::System.Windows.Forms.ToolStripMenuItem windows98ToolStripMenuItem;

        // Token: 0x040000CB RID: 203
        private global::System.Windows.Forms.TextBox CmdBox;

        // Token: 0x040000CC RID: 204
        private global::System.Windows.Forms.ContextMenuStrip CmdMatches;

        // Token: 0x040000CE RID: 206
        private global::System.Windows.Forms.Timer PissOff;

        // Token: 0x040000D1 RID: 209
        private global::System.Windows.Forms.Button button1;

        // Token: 0x040000D2 RID: 210
        private global::System.Windows.Forms.PictureBox pictureBox1;

        // Token: 0x040000D3 RID: 211
        private global::System.Windows.Forms.Button button2;

        // Token: 0x040000D4 RID: 212
        private global::System.Windows.Forms.Timer DELETELOGS;

        // Token: 0x040000D6 RID: 214
        private global::System.Windows.Forms.Timer TextEditorTick;
        private System.Windows.Forms.Button InjectButton;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.ListBox scriptBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private System.Windows.Forms.Label Tab1;
        private System.Windows.Forms.Label NewTab;
        private System.Windows.Forms.Label Tab2;
        private System.Windows.Forms.Label Tab3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox SaveButton;
        private System.Windows.Forms.SaveFileDialog SaveTab;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private AccountInfoVS accountInfoVS1;
        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.DockSite dockSite8;
    }
}
