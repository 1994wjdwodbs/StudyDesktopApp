using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioWinApp
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            string result = " ";
            List<RadioButton> Rdb_Country = new List<RadioButton>();
            for (int index = 1; index <= 6; index++)
                Rdb_Country.Add(groupBox1.Controls[string.Format("radioButton{0}", index)] as RadioButton);

            List<RadioButton> Rdb_Gender = new List<RadioButton>();
            for (int index = 5; index <= 6; index++)
                Rdb_Gender.Add(groupBox2.Controls[string.Format("radioButton{0}", index)] as RadioButton);

            for(int i = 0; i < 4; i++)
            {
                string[] tmp = { "대한민국", "중국", "일본", "그 외 국가" };
                if (Rdb_Country[i].Checked)
                    result = "국적 : " + tmp[i] + '\n';
            }

            for(int i = 0; i < 2; i++)
            {
                string[] tmp = { "남자", "여자" };
                if (Rdb_Gender[i].Checked)
                    result += "성별 : " + tmp[i] + '\n';
            }

            MessageBox.Show(result, "결과");
        }
    }
}
