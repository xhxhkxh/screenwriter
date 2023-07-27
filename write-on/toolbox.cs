using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace write_on
{
    public partial class toolbox : Form
    {


        public toolbox()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            global.pen = radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            global.rect = radioButton2.Checked;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Size:" + Convert.ToString(trackBar1.Value);
            global.ps = trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // colorDialog1.ShowDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                global.dc = colorDialog1.Color;
            }
        }

        private void toolbox_Shown(object sender, EventArgs e)
        {
            this.TopMost = true; 
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            global.pen = true;
            Color[] cs = new Color[8];
            cs[0] = Color.Red;
            cs[1] = Color.Green;
            cs[2] = Color.Blue;
            cs[3] = Color.Cyan;
            cs[4] = Color.Magenta;
            cs[5] = Color.AliceBlue;
            cs[6] = Color.Aquamarine;
            cs[7] = Color.Azure;
            while (true)
            {
                foreach (var item in cs)
                {
                    Application.DoEvents();
                    global.dc = item;
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            global.oval = radioButton4.Checked;
        }
    }
}
