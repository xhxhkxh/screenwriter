using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace write_on
{
    public partial class logw : Form
    {
        const int LOGMAXLENGTH = 500000;
        public logw()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (global.log.Length >= LOGMAXLENGTH)
                {
                    global.log = "";
                }
            }
            catch
            {
                global.log+= "Error happened";
            }
            progressBar1.Value = LOGMAXLENGTH - global.log.Length;
            label2.Text = Convert.ToString(LOGMAXLENGTH - global.log.Length);
            richTextBox1.Text = global.log;
        }

        private void logw_Load(object sender, EventArgs e)
        {
            this.TopMost= true;
            timer1.Enabled = true;
            progressBar1.Maximum = LOGMAXLENGTH;
            int Width = Screen.PrimaryScreen.Bounds.Width;
            int Height = Screen.PrimaryScreen.Bounds.Height;
            Point fp = new Point(Width - this.Width,Height-this.Height);
            this.Location = fp;
        }

        private void s(object sender, EventArgs e)
        {

        }
    }
}
