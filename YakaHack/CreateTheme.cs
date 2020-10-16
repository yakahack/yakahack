using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YakaHack
{
    public partial class CreateTheme : Form
    {
        public CreateTheme()
        {
            InitializeComponent();
        }

        public class MyColorTable : ProfessionalColorTable
        {
            public override Color MenuItemBorder
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(217, 217, 217); }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientBegin
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return Color.White; }
            }
        }

        public class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer()
                : base(new MyColorTable())
            {
            }
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var r = new Rectangle(e.ArrowRectangle.Location, e.ArrowRectangle.Size);
                r.Inflate(-2, -6);
                e.Graphics.DrawLines(Pens.Black, new Point[]{
        new Point(r.Left, r.Top),
        new Point(r.Right, r.Top + r.Height /2),
        new Point(r.Left, r.Top+ r.Height)});
            }

            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var r = new Rectangle(e.ImageRectangle.Location, e.ImageRectangle.Size);
                r.Inflate(-4, -6);
                e.Graphics.DrawLines(Pens.Black, new Point[]{
        new Point(r.Left, r.Bottom - r.Height /2),
        new Point(r.Left + r.Width /3,  r.Bottom),
        new Point(r.Right, r.Top)});
            }
        }

        private void CreateTheme_Load(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Renderer = new MyRenderer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void classicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Classic";
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Custom";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox3.Text = colorDialog1.Color.R.ToString() + ", " + colorDialog1.Color.G.ToString() + ", " + colorDialog1.Color.B.ToString();
        }
    }
}
