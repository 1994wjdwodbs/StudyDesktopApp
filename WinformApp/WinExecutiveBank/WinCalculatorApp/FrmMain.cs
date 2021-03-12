using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalculatorApp
{
    public partial class FrmMain : Form
    {
        public double Memory { get; set; }
        public bool MemFlag { get; set; }
        public bool PercentFlag { get; set; }

        public char Op { get; set; }
        public bool OpFlag { get; set; }

        public double saved { get; set; }


        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TxtResult.Text = "";
            BtnMC.Enabled = BtnMR.Enabled = false;
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            var str = btn.Text;

            TxtResult.Text += str;
        }

        private void BtnOp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            saved = double.Parse(TxtResult.Text);
            TxtExp.Text += $"{TxtResult.Text} {btn.Text} ";
            Op = btn.Text[0];
            OpFlag = true;

            TxtResult.Text = "";
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            var value = double.Parse(TxtResult.Text);

            switch (Op)
            {
                case '+':
                    TxtResult.Text = (saved + value).ToString();
                    break;
                case '-':
                    TxtResult.Text = (saved - value).ToString();
                    break;
                case '×':
                    TxtResult.Text = (saved * value).ToString();
                    break;
                case '÷':
                    TxtResult.Text = (saved / value).ToString();
                    break;
            }
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtExp.Text = "";
            saved = 0;
            Op = '\0';
            OpFlag = false;
            PercentFlag = false;
        }

        private void BtnMC_Click(object sender, EventArgs e)
        {
            TxtResult.Text = "";
            Memory = 0;
            BtnMR.Enabled = BtnMC.Enabled = false;
        }

        private void BtnMR_Click(object sender, EventArgs e)
        {
            TxtResult.Text = Memory.ToString();
            MemFlag = true;
        }

        private void BtnMplus_Click(object sender, EventArgs e)
        {

        }

        private void BtnMminus_Click(object sender, EventArgs e)
        {

        }

        private void BtnMS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtResult.Text))
                return;

            Memory = double.Parse(TxtResult.Text);
            BtnMC.Enabled = BtnMR.Enabled = true;
            MemFlag = true;
        }
    }
}
