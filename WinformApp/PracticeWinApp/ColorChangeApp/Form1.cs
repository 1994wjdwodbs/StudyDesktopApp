using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorChangeApp
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }
       
        // Trackbar_Scroll 한 번에 구현(이벤트 통일)
        public void Trackbar_Scroll(object sender, EventArgs e)
        {
            TxtRed.Text = trackBar1.Value.ToString();
            TxtGreen.Text = trackBar2.Value.ToString();
            TxtBlue.Text = trackBar3.Value.ToString();
            PnlResult.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            PnlResult.BackColor = Color.FromArgb(0, 0, 0);
        }
        
        // open
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        // save
        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        // show
        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
    }
}
