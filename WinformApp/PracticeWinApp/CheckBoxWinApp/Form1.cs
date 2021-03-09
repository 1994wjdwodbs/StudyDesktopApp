using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckBoxWinApp
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string checkState = string.Empty;

            List<CheckBox> boxes = new List<CheckBox>();
            for (int index = 1; index <= 6; index++)
                boxes.Add(Controls[string.Format("checkBox{0}", index)] as CheckBox);
            
            foreach(var item in boxes)
                checkState += $"{item.Text} : {item.Checked}\n";

            MessageBox.Show(checkState, "체크상태");

            string summary = $"좋아하는 과일은 : ";
            foreach (var item in boxes)
            {
                if (item.Checked)
                    summary += item.Text + ", ";
            }

            MessageBox.Show(summary.Substring(0, summary.Length - 2), "좋아하는 과일 리스트");
        }
    }
}
