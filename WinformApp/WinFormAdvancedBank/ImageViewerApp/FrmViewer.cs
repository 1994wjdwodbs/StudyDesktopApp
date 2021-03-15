using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewerApp
{
    public partial class FrmViewer : Form
    {
        public FrmViewer()
        {
            InitializeComponent();
        }

        private void MnuSelectImage_Click(object sender, EventArgs e)
        {
            DlgOpenImage.Filter = "jpg 파일(*.jpg)|*.jpg|png 파일(*.png)|*.png|모든 파일(*.*)|*.*";
            DlgOpenImage.Title = "이미지 열기";

            if(DlgOpenImage.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(DlgOpenImage.FileName);
            }
            // 일반 모드로 열기
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void stretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void autoSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmViewer_Load(object sender, EventArgs e)
        {
            this.Text = "이미지 뷰어";
            pictureBox1.BackColor = Color.White;
        }
    }
}
