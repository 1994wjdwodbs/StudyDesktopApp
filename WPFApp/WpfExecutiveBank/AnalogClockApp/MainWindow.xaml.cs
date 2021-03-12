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
using System.Windows.Threading;

namespace AnalogClockApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
        // 시침
        public int HourHand { get; set; }
        // 분침
        public int MinHand { get; set; }
        // 초침
        public int SecHand { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("윈도우 로드!");
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            SetClock();
            SetTimer();
        }

        private void SetTimer()
        {
            // throw new NotImplementedException();
            DispatcherTimer timer = new DispatcherTimer();
            // timer.Interval = new TimeSpan(0, 0, 1); // 0시 0분 1초를 인터벌 간격으로 지정
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10); // 0.01초
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            DateTime curTime = DateTime.Now;

            // 캔버스 초기화
            CvsClock.Children.Clear();
            // 시계판 그리기
            DrawClockFace();

            double radHour = ((curTime.Hour % 12 + curTime.Minute / 60.0) * 30) * (Math.PI / 180);
            double radMin = ((curTime.Minute + curTime.Second / 60.0) * 6) * (Math.PI / 180);
            double radSec = ((curTime.Second + curTime.Millisecond / 1000.0) * 6) * (Math.PI / 180);
            DrawHands(radHour, radMin, radSec);
        }

        private void DrawHands(double radHour, double radMin, double radSec)
        {
            // throw new NotImplementedException();
            
           // 시침, 분침, 초침 그리기
            DrawLine(HourHand * Math.Sin(radHour), -HourHand * Math.Cos(radHour)
                , 0, 0, Brushes.RoyalBlue, 8
                , new Thickness(Center.X, Center.Y, 0, 0));
            DrawLine(MinHand * Math.Sin(radMin), -MinHand * Math.Cos(radMin)
               , 0, 0, Brushes.SkyBlue, 3
               , new Thickness(Center.X, Center.Y, 0, 0));
            DrawLine(SecHand * Math.Sin(radSec), -SecHand * Math.Cos(radSec)
                , 0, 0, Brushes.OrangeRed, 1
                , new Thickness(Center.X, Center.Y, 0, 0));

            Ellipse core = new Ellipse();
            core.Margin = new Thickness(CvsClock.Width / 2 - 10, CvsClock.Height / 2 - 10, 0, 0);
            core.Stroke = Brushes.RoyalBlue;
            core.Fill = Brushes.RoyalBlue;
            core.Width = 16;
            core.Height = 16;
            CvsClock.Children.Add(core);
        }

        private void DrawLine(double x1, double y1, int x2, int y2, SolidColorBrush color, int thick, Thickness margin)
        {
            // throw new NotImplementedException();
            Line line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;

            line.Stroke = color;
            line.StrokeThickness = thick;
            line.Margin = margin;
            line.StrokeStartLineCap = PenLineCap.Round;
            CvsClock.Children.Add(line);
        }

        private void DrawClockFace()
        {
            // throw new NotImplementedException();
            ElsClock.Stroke = Brushes.LightSteelBlue;
            ElsClock.StrokeThickness = 30;
            CvsClock.Children.Add(ElsClock);
        }

        private void SetClock()
        {
            // throw new NotImplementedException();
            Center = new Point(CvsClock.Width / 2, CvsClock.Height / 2);
            Radius = CvsClock.Width / 2;
            
            HourHand = (int)(Radius * 0.45); // 시침 길이
            MinHand = (int)(Radius * 0.55); // 분침 길이
            SecHand = (int)(Radius * 0.65); // 초침 길이
        }
    }
}
