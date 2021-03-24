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
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Web.UI.WebControls;
using System.Xml;

namespace FIneDustMonApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private string excelPath = $@"{AppDomain.CurrentDomain.BaseDirectory}busan_station_list.xls";

        public List<string> lstLabs { get; set; }

        private List<FineDustInfo> lstResult { get; set; }

        // 엠퍼센드(&) 빠졌는지 확인
        private string openApiUrl = "http://apis.data.go.kr/B552584/ArpltnInforInqireSvc/getMsrstnAcctoRltmMesureDnsty?" +
                                    "serviceKey=VmMKTgcEcS6WF%2FlI3XbtZdtNggsvYHcWpUPfHZ%2F3uxkQJGTIvUOymqQAQuMLK9FehX7%2FxwebNphSUPlTj9Cilw%3D%3D&" +

                                    "returnType=xml&" +
                                    "numOfRows=100&" +
                                    "pageNo=1&" +
                                    "dataTerm=DAILY&" +
                                    "ver=1.0&" +
                                    "stationName=";


        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Debug.WriteLine(excelPath);

            // 엑셀파일에서 측정소 가져오기 (Microsoft.Office.Interop.Excel은 그냥 쓰지말자)
            /*Excel.Application excelApp = new Excel.Application();
            Workbook workbook = excelApp.Workbooks.Open(Filename: excelPath);
            Worksheet worksheet = (Worksheet) workbook.Worksheets.get_Item(1);
            Range range = worksheet.UsedRange;

            for(int i = 1; i <= range.Rows.Count; i++)
                for(int j = 1; j <= range.Columns.Count; j++)
                {
                    Debug.WriteLine((range.Cells[i, j] as Excel.Range).Value2.ToString());
                    MessageBox.Show((range.Cells[i, j] as Excel.Range).Value2.ToString());
                }

            workbook.Close(true, null, null);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);*/

            IWorkbook wb = null;
            ISheet sh = null;

            using (FileStream fs = new FileStream(excelPath, FileMode.Open, FileAccess.Read))
            {
                wb = new HSSFWorkbook(fs);
            }

            lstLabs = new List<string>();
            sh = wb.GetSheetAt(0); // sheet1
            int rowCount = sh.LastRowNum;
            Debug.WriteLine(rowCount);

            for(int r = 1; r < rowCount - 1; r++)
            {
                lstLabs.Add(sh.GetRow(r).Cells[1].ToString());
            }

            Debug.WriteLine(lstLabs.Count);
            CboStations.ItemsSource = lstLabs;
        }

        private void CboStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstResult = new List<FineDustInfo>();

            if (CboStations.SelectedItem != null)
            {
                MessageBox.Show(CboStations.SelectedItem.ToString());
                openApiUrl = openApiUrl.Substring(0, openApiUrl.LastIndexOf("=") + 1) + CboStations.SelectedItem.ToString();
                MessageBox.Show(openApiUrl);
                // 어차피 인터넷 연결되서 xml 형식 받아올 것이 분명하기 때문...
                XmlDocument xml = new XmlDocument();
                xml.Load(openApiUrl);
                XmlNodeList xnList = xml.SelectNodes("/response/body/items/item");


                foreach (XmlNode item in xnList)
                {
                    // Console.WriteLine($"dateTime : {item.InnerText}");
                    lstResult.Add(new FineDustInfo()
                    {
                        // item["col"] : col 부분 철자 확인!!
                        DataTime = item["dataTime"].InnerText,
                        Khai = item["khaiValue"].InnerText,
                        SO2 = item["so2Value"].InnerText,
                    });
                }
            }
            DgrFineDustInfos.ItemsSource = lstResult;
        }

    }

    public class FineDustInfo
    {
        public string DataTime { get; set; }
        public string Khai { get; set; }
        public string SO2 { get; set; }
    }
}
