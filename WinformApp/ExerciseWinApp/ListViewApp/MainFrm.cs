using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewApp
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            ListViewItem itemNDS = new ListViewItem("Nintendo DS", 0);
            ListViewItem itemNSW = new ListViewItem("Nintendo Switch", 1);
            ListViewItem itemNWII = new ListViewItem("Nintendo Wii", 2);
            ListViewItem itemPS4 = new ListViewItem("PlayStation 4", 3);
            ListViewItem itemXBOX = new ListViewItem("XBOX", 4);

            itemNDS.SubItems.Add("150,000");
            itemNDS.SubItems.Add("50");
            itemNDS.SubItems.Add("7,500,000");

            itemNSW.SubItems.Add("400,000");
            itemNSW.SubItems.Add("50");
            itemNSW.SubItems.Add("20,000,000");

            itemNWII.SubItems.Add("200,000");
            itemNWII.SubItems.Add("30");
            itemNWII.SubItems.Add("6,000,000");

            itemPS4.SubItems.Add("450,000");
            itemPS4.SubItems.Add("10");
            itemPS4.SubItems.Add("4,500,000");

            itemXBOX.SubItems.Add("399,000");
            itemXBOX.SubItems.Add("50");
            itemXBOX.SubItems.Add("19,950,000");


            LsvProducts.Items.AddRange(new ListViewItem[] { itemNDS, itemNSW, itemNWII, itemPS4, itemXBOX });

        }

        // 자세히
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                LsvProducts.View = View.Details;
        }

        // 리스트
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                LsvProducts.View = View.List;
        }

        // 작은 아이콘
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                LsvProducts.View = View.SmallIcon;
        }

        // 큰 아이콘
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                LsvProducts.View = View.LargeIcon;
        }

        private void LsvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtSelected.Text = string.Empty;

            var selected = LsvProducts.SelectedItems;
            foreach(ListViewItem item in selected)
            {
                for(int i = 0; i < 4; i++)
                {
                    TxtSelected.Text += item.SubItems[i].Text + " ";
                }
            }
        }
    }
}
