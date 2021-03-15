using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinChartApp
{
    public partial class FrmMain : Form
    {
        public bool flag = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnRegen_Click(object sender, EventArgs e)
        {
            GenNewChart();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "중간고사 성적";
            ChtScore.Titles.Add("중간고사 성적");
            GenNewChart();
        }

        private void GenNewChart()
        {
            ChtScore.Series["Score"].Points.Clear();
            Random rand = new Random();

            // throw new NotImplementedException();
            for(int i = 0; i < 20; i++)
            {
                ChtScore.Series["Score"].Points.Add(rand.Next(10, 100));
            }
            ChtScore.Series["Score"].LegendText = "수학";
            // ChtScore.Series["Score"].ChartType = SeriesChartType.Line;
            ChtScore.Series["Score"].ChartType = SeriesChartType.Column;
            // ChtScore.Series["Score"].ChartType = SeriesChartType.FastLine;
            // ChtScore.Series["Score"].ChartType = SeriesChartType.Spline;
            // ChtScore.Series["Score"].ChartType = SeriesChartType.Area;
            // ChtScore.Series["Score"].ChartType = SeriesChartType.Pie;

            // ChtScore.Series["Score"].ChartType = SeriesChartType.Candlestick;
        }
    }
}
