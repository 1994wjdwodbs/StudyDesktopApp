using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIneDustMonApp
{
    class test : ObservableCollection<string>
    {
        private string excelPath = $@"{AppDomain.CurrentDomain.BaseDirectory}busan_station_list.xls";

        public test()
        {
            IWorkbook wb = null;
            ISheet sh = null;

            using (FileStream fs = new FileStream(excelPath, FileMode.Open, FileAccess.Read))
            {
                wb = new HSSFWorkbook(fs);
            }

            sh = wb.GetSheetAt(0); // sheet1
            int rowCount = sh.LastRowNum;

            for (int r = 1; r < rowCount - 1; r++)
            {
                this.Add(sh.GetRow(r).Cells[1].ToString());
            }
        }
    }
}
