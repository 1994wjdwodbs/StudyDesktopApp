using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListboxWinApp
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            LsbGoodCity.Items.Add("오스트리아, 빈");
            LsbGoodCity.Items.Add("호주, 맬버른");
            LsbGoodCity.Items.Add("일본, 오사카");
            LsbGoodCity.Items.Add("캐나다, 캘거리");
            LsbGoodCity.Items.Add("호주, 시드니");
            LsbGoodCity.Items.Add("캐나다, 밴쿠버");
            LsbGoodCity.Items.Add("일본, 도쿄");
            LsbGoodCity.Items.Add("캐나다, 토론토");
            LsbGoodCity.Items.Add("덴마크, 코펜하겐");
            LsbGoodCity.Items.Add("호주, 애들레이드");

            List<string> lstCountry = new List<string>()
            {
                "미국",
                "러시아",
                "중국",
                "영국",
                "독일",
                "프랑스",
                "일본",
                "이스라엘",
                "사우디아라비아",
                "UAE",
                "필리핀"
            };
            LsbHappyCountry.DataSource = lstCountry;

            LsbGdpCountry.SelectedIndex = 0;
            LsbGoodCity.SelectedIndex = 0;
            LsbHappyCountry.SelectedIndex = 0;
            
        }

        private void LsbGdpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sender 값 확인
            // MessageBox.Show(sender.ToString());
            // ListBox -> object (업캐스팅)
            // object -> ListBox (다운캐스팅, 원래 ListBox이니 가능)
            var selItem = (ListBox) sender;
            // MessageBox.Show($"{selItem.SelectedIndex} / {selItem.SelectedItem}");
            TxtIndexGdp.Text = selItem.SelectedIndex.ToString();
            TxtItemGdp.Text = selItem.SelectedItem == null ? string.Empty : selItem.SelectedItem.ToString();
        }

        private void LsbGoodCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sender 값 확인
            // MessageBox.Show(sender.ToString());
            // ListBox -> object (업캐스팅)
            // object -> ListBox (다운캐스팅, 원래 ListBox이니 가능)
            var selItem = (ListBox)sender;
            // MessageBox.Show($"{selItem.SelectedIndex} / {selItem.SelectedItem}");
            TxtIndexCity.Text = selItem.SelectedIndex.ToString();
            TxtItemCity.Text = selItem.SelectedItem == null ? string.Empty : selItem.SelectedItem.ToString();
        }

        private void LsbHappyCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sender 값 확인
            // MessageBox.Show(sender.ToString());
            // ListBox -> object (업캐스팅)
            // object -> ListBox (다운캐스팅, 원래 ListBox이니 가능)
            var selItem = (ListBox)sender;
            // MessageBox.Show($"{selItem.SelectedIndex} / {selItem.SelectedItem}");
            TxtIndexCountry.Text = selItem.SelectedIndex.ToString();
            TxtItemCountry.Text = selItem.SelectedItem == null ? string.Empty : selItem.SelectedItem.ToString();
        }

        private void BtnInit_Click(object sender, EventArgs e)
        {
            LsbGdpCountry.SelectedIndex = LsbGoodCity.SelectedIndex = LsbHappyCountry.SelectedIndex = -1;
        }
    }
}
