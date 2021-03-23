using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

        private Timer timerSimul = new Timer();
        private Random randPhoto = new Random();
        // flag
        private bool IsSimulation = false;
        private List<SensorData> sensors = new List<SensorData>();

        private string connString = "Data Source=127.0.0.1;" +
            "Initial Catalog=IoTData;" +
            "Persist Security Info=True;" +
            "User ID=sa;" +
            "Password=mssql_p@ssw0rd!";

        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            MnuBeginSimulation.Enabled = true;
            MnuEndSimulation.Enabled = false;

            timerSimul.Interval = 1000; // 1초
            timerSimul.Tick += new EventHandler(TimerSimul_Tick);

            CboSerialPort.Text = "Select Port";
            foreach (var port in SerialPort.GetPortNames())
            {
                CboSerialPort.Items.Add(port);
            }

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

        // 시뮬레이션 시작
        private void MnuBeginSimulation_Click(object sender, EventArgs e)
        {
            MnuBeginSimulation.Enabled = false;
            MnuEndSimulation.Enabled = true;
            IsSimulation = true;
            timerSimul.Enabled = true;
            timerSimul.Start();
        }

        private long timeSpan = 0; // 시간흐름값
        private int randMaxVal = 0;        

        private void TimerSimul_Tick(object sender, EventArgs e)
        {
            timeSpan += 1;
            long temp = timeSpan % 30; // 0, 1, 2, ... , 28, 29, 0, 1, 2, ...

            if (temp.ToString().Length == 2)
            {
                randMaxVal = 980;
            }
            else
            {
                randMaxVal = 120;
            }

            Console.WriteLine(timeSpan);
            // throw new NotImplementedException();
            int value = randPhoto.Next(randMaxVal - 40, randMaxVal); // 10 ~ 1023까지 사이의 값
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
            InsertTable(data);

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

            // 200개 초과 시
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Maximum = (sensors.Count >= xCount) ? sensors.Count : xCount;

            // Zoom 처리
            if (sensors.Count > xCount)
                ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoom(sensors.Count - xCount, sensors.Count);
            else
                ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoom(0, xCount);

            // BtnDisplay 표시
            if (IsSimulation)
                BtnDisplay.Text = v.ToString();
            else
                BtnDisplay.Text = "~" + "\n" + v.ToString();
        }

        // DB : IotData의 Tbl_PhotoResistor 테이블에 data값 insert
        private void InsertTable(SensorData data)
        {
            // throw new NotImplementedException();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    char TF = (data.SimulFlag == true) ? '1' : '0';

                    string query = $"INSERT INTO Tbl_PhotoResistor " +
                        $"(CurrentDt, Value, SimulFlag) " +
                        $"VALUES ('{data.Current.ToString("yyyy-MM-dd HH:mm:ss")}', '{data.Value}', '{((data.SimulFlag == true) ? '1' : '0')}')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int x = cmd.ExecuteNonQuery();

                    Debug.WriteLine(x);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"예외 발생 : {ex.Message}");
            }
        }

        // 시뮬레이션 끝
        private void MnuEndSimulation_Click(object sender, EventArgs e)
        {
            MnuEndSimulation.Enabled = false;
            MnuBeginSimulation.Enabled = true;
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

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Maximum = sensors.Count;

            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoom(0, sensors.Count);
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Interval = sensors.Count / 4;
        }

        private void BtnZoom_Click(object sender, EventArgs e)
        {

            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Maximum = sensors.Count;

            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoom(sensors.Count - xCount, sensors.Count);
            ChtPhotoResistors.ChartAreas["ChartArea1"].AxisX.Interval = xCount / 4;
        }
    }
}
