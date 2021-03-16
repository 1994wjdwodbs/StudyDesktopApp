using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IoTSensorMonApp
{
    public partial class FrmMain : Form
    {
        private double xCount = 200;

        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            foreach (var port in SerialPort.GetPortNames())
            {
                CboSerialPort.Items.Add(port);
            }
            CboSerialPort.Text = "Select Port";

            // IoT 장비에서 받을 값의 범위
            PrbPhotoResistor.Minimum = 0;
            PrbPhotoResistor.Maximum = 1023;
            PrbPhotoResistor.Value = 0;

            // 차트 모양 초기화
            InitChartStyle();

            // BtnDisplay 초기화
            BtnDisplay.BackColor = Color.BlueViolet;
            BtnDisplay.ForeColor = Color.WhiteSmoke;
            BtnDisplay.Text = "NONE";
            BtnDisplay.Font = new Font("맑은 고딕", 14, FontStyle.Bold);

            // 나머지 초기화
            LblConnectTime.Text = "Connection Time : ";
            TxtSensorNum.TextAlign = HorizontalAlignment.Right;
            TxtSensorNum.Text = "0";
            BtnConnect.Enabled = BtnDisconnect.Enabled = false;
        }

        // 차트 초기 설정
        private void InitChartStyle()
        {
            // throw new NotImplementedException();
            // ChtPhotoResistors.ChartAreas.Clear();
            // ChtPhotoResistors.ChartAreas.Add("Chart");
            ChtPhotoResistors.ChartAreas["ChartArea1"].BackColor = Color.Blue;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Maximum = xCount;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Interval = xCount / 4;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.WhiteSmoke;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisY.Maximum = 1024;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisY.Interval = xCount;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.WhiteSmoke;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            ChtPhotoResistors.ChartAreas["ChartArea1"].CursorX.AutoScroll = true;
            // 마우스 줌 설정
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;

            ChtPhotoResistors.Series.Clear();
            ChtPhotoResistors.Series.Add("PhotoValue");
            ChtPhotoResistors.Series[0].ChartType = SeriesChartType.Line;
            ChtPhotoResistors.Series[0].Color = Color.LightCoral;
            ChtPhotoResistors.Series[0].BorderWidth = 3;

            // 범례(Legend) 삭제
            if (ChtPhotoResistors.Legends.Count > 0)
            {
                // ChtPhotoResistors.Legends.RemoveAt(0);
                // 값을 고정해야되지 않나?
                for(int i = 0; i < ChtPhotoResistors.Legends.Count; i++)
                {
                    ChtPhotoResistors.Legends.RemoveAt(i);
                }
            }
        }

        // 아두이노 연결 해제 버튼
        private void BtnDisconnect_Click(object sender, EventArgs e)
        {

        }

        // 아두이노 연결 버튼
        private void BtnConnect_Click(object sender, EventArgs e)
        {

        }

        private Timer timerSimul = new Timer();
        private Random randPhoto = new Random();
        // flag
        private bool IsSimulation = false;
        private List<SensorData> sensors = new List<SensorData>();

        // 시뮬레이션 시작
        private void MnuBeginSimulation_Click(object sender, EventArgs e)
        {
            IsSimulation = true;
            timerSimul.Enabled = true;
            timerSimul.Interval = 1000; // 1초
            timerSimul.Tick += new EventHandler(TimerSimul_Tick);
            timerSimul.Start();
        }

        private void TimerSimul_Tick(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            int value = randPhoto.Next(1, 1023); // 1 ~ 1023까지 사이의 값
            ShowSensorValue(value.ToString());

        }

        // 센서값 화면 출력메서드
        private void ShowSensorValue(string value)
        {
            // throw new NotImplementedException();
            int.TryParse(value, out int v);

            var currentTime = DateTime.Now;
            SensorData data = new SensorData(DateTime.Now, v, IsSimulation);
            sensors.Add(data);

            // 센서값 갯수
            TxtSensorNum.Text = $"{sensors.Count}";
            // 프로그레스바 현재값 출력
            PrbPhotoResistor.Value = v;
            // 리스트박스에 데이터 출력
            var item = $"{currentTime.ToString("yyyy-MM-dd HH:mm:ss")}\t{v}";
            
            LsbPhotoResistors.Items.Add(item);
            LsbPhotoResistors.SelectedIndex = LsbPhotoResistors.Items.Count - 1; // 스크롤 처리

            // 차트에 데이터 출력
            ChtPhotoResistors.Series[0].Points.Add(v);
        }

        // 시뮬레이션 끝
        private void MnuEndSimulation_Click(object sender, EventArgs e)
        {
            IsSimulation = false;
            timerSimul.Stop();
        }

        // 종료버튼 클릭
        private void MnuExit_Click(object sender, EventArgs e)
        {
            if (IsSimulation)
                MessageBox.Show("시뮬레이션을 멈춘 후 프로그램을 종료하세요.", "종료",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                Environment.Exit(0);
        }
    }
}
