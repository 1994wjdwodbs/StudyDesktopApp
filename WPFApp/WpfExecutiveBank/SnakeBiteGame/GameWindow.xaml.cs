using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeBiteGame
{
    /// <summary>
    /// GameWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GameWindow : Window
    {
        Random rand = new Random();

        // 뱀 배열(몸체)
        Ellipse[] snake = new Ellipse[30];
       
        Ellipse egg = new Ellipse();
        private int size = 12; // egg, body
        private int visibleCount = 5;
        private string move = string.Empty;
        private int eaten = 0; // 먹은 양
        DispatcherTimer playTimer = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();
        private bool startFlag = false;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            InitSnake();
            InitEgg();

            playTimer.Interval = new TimeSpan(0, 0, 0, 0, 100); // 0.1초
            playTimer.Tick += playTimer_Tick;
            playTimer.Start();
        }

        private void InitSnake()
        {
            // throw new NotImplementedException();
            // int x = rand.Next(1, Canvas)
        }
        private void InitEgg()
        {
            // throw new NotImplementedException();
        }


        private void playTimer_Tick(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

    }
}
