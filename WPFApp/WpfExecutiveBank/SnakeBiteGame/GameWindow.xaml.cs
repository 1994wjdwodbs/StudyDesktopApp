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
            int x = rand.Next(1, 500 / size) * size;
            int y = rand.Next(1, 400 / size) * size;

            for(int i = 0; i < 30; i++)
            {
                snake[i] = new Ellipse();
                snake[i].Width = snake[i].Height = size;
                
                if (i == 0)
                    snake[i].Fill = Brushes.Chocolate;
                else if (i % 5 == 0)
                    snake[i].Fill = Brushes.YellowGreen;
                else
                    snake[i].Fill = Brushes.Gold;

                snake[i].Stroke = Brushes.Black;

                CvsGame.Children.Add(snake[i]);
            }

            // 뱀 길이
            for (int i = visibleCount; i < 30; i++)
            {
                snake[i].Visibility = Visibility.Hidden;
            }
            CreateSnake(x, y);
        }

        private void CreateSnake(int x, int y)
        {
            // throw new NotImplementedException();
            for (int i = 0; i < visibleCount; i++)
            {
                // Tag에 x, y 값이 들어있음 (사용자 지정 정보)
                snake[i].Tag = new Point(x, y + i * size);
                Canvas.SetLeft(snake[i], x);
                Canvas.SetTop(snake[i], y + i * size);
            }
        }

        private void InitEgg()
        {
            // throw new NotImplementedException();
        }


        private void playTimer_Tick(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            if(move != "")
            {
                startFlag = true;

                for(int i = visibleCount; i >= 1; i++)
                {
                    Point p = (Point) snake[i - 1].Tag;
                    snake[i].Tag = new Point(p.X, p.Y);
                }

                // 키보드 옮겼을 때 처리

                // 알을 먹었는 지 체크
            }

            if (startFlag)
            {
                TimeSpan span = stopwatch.Elapsed;
                Txttime.Text = $"Time = {span.Minutes}:{span.Seconds}:{span.Milliseconds / 10}";
                DrawSnake();
            }
        }

        private void DrawSnake()
        {
            // throw new NotImplementedException();
            for(int i = 0; i < visibleCount; i++)
            {
                Point p = (Point)snake[i].Tag;
                Canvas.SetLeft(snake[i], p.X);
                Canvas.SetTop(snake[i], p.Y);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (move == "")
                stopwatch.Start();

            // 키조작
        }

    }
}
