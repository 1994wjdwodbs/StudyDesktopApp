using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskedTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string result = $"입사일 : {TxtHiredDate.Text}\n"
                            + $"우편번호 : {TxtZipcode.Text}\n"
                            + $"주소 : {TxtAddress.Text}\n"
                            + $"휴대폰번호 : {TxtMobile.Text}\n"
                            + $"주민번호 : {TxtSocialNumber.Text}\n"
                            + $"이메일 : {TxtEmail.Text}\n";

            MessageBox.Show(result, "개인정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
