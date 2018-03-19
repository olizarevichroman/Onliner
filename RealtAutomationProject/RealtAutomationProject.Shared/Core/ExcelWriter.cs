using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;

namespace RealtAutomationProject.Shared.Core
{
    public class ExcelWriter
    {
        private ExcelPackage excelApp;
        public string FilePath { get; set; }

        public ExcelWriter(string filePath)
        {
            this.FilePath = filePath;
        }

        public void WriteData<T>(IEnumerable<T> apartments)
        {
            var info = new FileInfo(FilePath);
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
                using (var excelApp = new ExcelPackage(info))
                {
                var ws = excelApp.Workbook.Worksheets.Add("Apartments");
                ws.Cells.LoadFromCollection(apartments,true);
                ws.Cells.AutoFitColumns();
                excelApp.Save();     
            }
        }
    }
}