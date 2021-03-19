using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ModernUITestApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MnuExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VALUE", typeof(string));
            dt.Columns.Add("NAME", typeof(string));

            dt.Rows.Add(new String[] { "B001", "공포/판타지" });
            dt.Rows.Add(new String[] { "B002", "로맨스" });
            dt.Rows.Add(new String[] { "B003", "SF" });
            dt.Rows.Add(new String[] { "B004", "무협" });

            CboDivision.ItemsSource = dt.DefaultView;
            CboDivision.SelectedValuePath = "VALUE";
            CboDivision.DisplayMemberPath = "NAME";
        }
    }
}
