using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace write_on
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static bool act = false;
        public static Point st;
        public static SizeF windowSize = new SizeF(119, 42);
        Graphics gp;
        public static Color dc = Color.Cyan;


        public Bitmap screenShot()
        {
            var res = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppPArgb);
            var g = Graphics.FromImage(res);
            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, 
                Screen.PrimaryScreen.Bounds.Y,
                0,
                0,
                Screen.PrimaryScreen.Bounds.Size,
                CopyPixelOperation.SourceCopy);
            g.Dispose();
            return res;
        }

        Form tb = new toolbox();
        Form logW = new Form();

        private void button1_Click(object sender, EventArgs e)
        {
            tb = new toolbox();
            logW = new logw();
            if (!act)
            {
                
                this.Hide();
                Thread.Sleep(500);
                Bitmap bg = screenShot();

                // Thread.Sleep(1000);
                this.Location = new Point(0, 0);
                this.Show();

                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
                gp = this.CreateGraphics();
                // Thread.Sleep(1000);
                gp.DrawImage(bg, 0, 0, this.Width, this.Height);
                button1.Text = "Close";
                tb.Show();
                logW.Show();
            }
            else
            {
                button1.Text = "Active";
                this.Height = 82;
                this.Width = 136;
                this.Location = st;
                tb.Close();
                logW.Close();
            }
            act = !act;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            st = this.Location;
            
        }
        public static Point mp = new Point(MousePosition.X, MousePosition.Y + 1);
        public static bool md;
        public static Point sp;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            md = true;
            sp = MousePosition;
            
            global.log += "Mouse pressed down!Recording sp at:" + sp.ToString()+"\n";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            global.log += "Mouse movements detected at:" + MousePosition.ToString() + "\n";
            mp = new Point(MousePosition.X-10, MousePosition.Y - 30);
            if (act && md && global.pen)
            {
                // Draw lines
                Rectangle pt = new Rectangle(mp.X,mp.Y, global.ps,global.ps);
                gp.DrawRectangle(new Pen(global.dc,2),pt);
                gp.FillRectangle(new SolidBrush(global.dc),pt);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            md = false;
            if(act && global.rect)
            {
                gp.DrawRectangle(new Pen(global.dc,global.ps),sp.X-30 ,sp.Y-30,MousePosition.X-sp.X,MousePosition.Y-sp.Y);
            }
            else if(act && global.oval)
            {
                gp.DrawArc(new Pen(global.dc, global.ps), sp.X - 30, sp.Y - 30, MousePosition.X - sp.X, MousePosition.Y - sp.Y, 45F,45F);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
