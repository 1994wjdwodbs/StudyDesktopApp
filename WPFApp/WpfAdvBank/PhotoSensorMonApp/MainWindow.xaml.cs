using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using LiveCharts;
using LiveCharts.Wpf;
using System.Threading;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using OxyPlot;

namespace PhotoSensorMonApp
{
    public class SensorData
    {

        public int Idx { get; set; }
        public DateTime CurrentDt { get; set; }
        public int Value { get; set; }
        public bool SimulFlag { get; set; }

        public SensorData(int idx, DateTime currentDt, int value, bool simulFlag)
        {
            Idx = idx;
            CurrentDt = currentDt;
            Value = value;
            SimulFlag = simulFlag;
        }
    }


    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            logger.Info("PhotoSensorMonApp Initialized...");
        }

        public List<DataPoint> Values_ { get; set; }

        public int SensorValue { get; set; }

        public DispatcherTimer CustomTimer { get; set; }

        private string connString = 
            "Data Source=210.119.12.82;" +
            "Initial Catalog=IoTData;" +
            "Persist Security Info=True;" +
            "User ID=sa;Password=mssql_p@ssw0rd!";

        public SensorData GetRealTimeSensor()
        {
            SensorData result = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                        conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    string query = @"SELECT TOP 1 Idx
                                          ,CurrentDt
                                          ,Value
                                          ,SimulFlag
                                      FROM dbo.Tbl_PhotoResistor
                                      ORDER BY Idx DESC ";
                    cmd.CommandText = query;

                    var temp = cmd.ExecuteReader();
                    if(temp.Read())
                    {
                        result = new SensorData(
                            Convert.ToInt32(temp["idx"]), 
                            Convert.ToDateTime(temp["CurrentDt"]),
                            Convert.ToInt32(temp["Value"]),
                            Convert.ToBoolean(temp["SimulFlag"])
                            );

                    }
                    temp.Close();

                    logger.Info("GetRealTimeSensor() Completed.");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"에외발생 : {ex.Message}");
                logger.Error($"GetRealTimeSensor() error occured : {ex.Message}");
            }

            return result;
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            /* * * * *
            var x = Enumerable.Range(0, 1001).Select(i => i / 10.0).ToArray();
            var y = x.Select(v => Math.Abs(v) < 1e-10 ? 1 : Math.Sin(v) / v).ToArray();
            ChtLine.Plot(x, y);
            * * * * */
            // InitializeComponent();

            // Values_ = new ChartValues<int>(); // { 10, 5, 9, 5, 3, 2, 9, 16, 20, 40 };
            // GrdHistory.DataContext = Values_;

            CustomTimer = new DispatcherTimer();
            CustomTimer.Interval = TimeSpan.FromSeconds(1);
            CustomTimer.Tick += CustomTimer_Tick;
            // CustomTimer.Start();
        }

        private void CustomTimer_Tick(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            // new Random().Next(0, 1023);
            
            ChtRealTimeSensor.DataContext = GetRealTimeSensor().Value;
        }

        private void MnuStart_Click(object sender, RoutedEventArgs e)
        {
            CustomTimer.Start();
        }

        private void MnuStop_Click(object sender, RoutedEventArgs e)
        {
            CustomTimer.Stop();
        }

        private void MnuExit_Click(object sender, RoutedEventArgs e)
        {
            // Environment.Exit(0);
            Application.Current.Shutdown(0);
        }

        private void MnuLoad_Click(object sender, RoutedEventArgs e)
        {
            Values_ = GetHistorySensors();
            HistoryValues.ItemsSource = Values_;
        }

        private List<DataPoint> GetHistorySensors()
        {
            List<DataPoint> result = new List<DataPoint>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                        conn.Open();

                    string query = $@"SELECT Idx, Value
                                      FROM dbo.Tbl_PhotoResistor
                                      Where CurrentDt > CONVERT(DATETIME, '2021-03-23 14:00:00')
                                      ORDER BY Idx; ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // 대량으로 쓸 때는 Adapter 사용
                    // SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    // DataSet ds = new DataSet();
                    // adapter.Fill(ds);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(new DataPoint(Convert.ToInt32(reader[0]), Convert.ToDouble(reader[1])));
                    }
                }

                logger.Info("GetHistorySensors() Completed.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"예외 발생 : {ex.Message}");
                logger.Error($"GetHistorySensors() error occured : {ex.Message}");
            }

            return result;
        }
    }
}
