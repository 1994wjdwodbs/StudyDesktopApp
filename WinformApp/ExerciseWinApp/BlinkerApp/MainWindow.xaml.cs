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

namespace BlinkerApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        // System.Windows.Threading
        DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStartBlink_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void BtnStopBlink_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer = new DispatcherTimer();

            // ns : 10^(-9) sec
            // TimeSpan 단위 [100ns = 10^(-7) sec]
            dispatcherTimer.Interval = new TimeSpan(10000000); // 1초
            dispatcherTimer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            if (BtnStartBlink.Background == Brushes.Red)
            {
                BtnStartBlink.ClearValue(Button.BackgroundProperty);
                BtnStopBlink.Background = Brushes.Green;
            }
            else
            {
                BtnStopBlink.ClearValue(Button.BackgroundProperty);
                BtnStartBlink.Background = Brushes.Red;
            }
        }
    }
}
