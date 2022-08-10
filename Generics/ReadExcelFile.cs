using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ExcelRead = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Collections;

namespace MFGAutomation.Generics
{
    class ReadExcelFile : CommonProperties
    {
        #region[Variables]
        public Application xlApp;
        public Workbook xlWorkbook;
        public Worksheet xlSheet;
        public Range xlRange;
        public Workbooks xlWorkbooks;
        private string _filePath = "";
        ExcelRead.Workbook workbook = null;
        ExcelRead.Workbooks workbooks = null;
        Hashtable sheets;
        public List<string> columnvalue = new List<string>();
        Process[] excelProcsOld = Process.GetProcessesByName("EXCEL");
        #endregion[Variables]

        /// <summary>
        /// Provide excel file location
        /// </summary>
        /// <param name="path"></param>
        public ReadExcelFile(String path)
        {
            this._filePath = path;
        }

        /// <summary>
        /// Open specific sheet by providing sheet name
        /// </summary>
        /// <param name="sheetName"></param>
        public void OpenExcelFile(String sheetName)
        {
            try
            {
                xlApp = new ExcelRead.Application();
                xlWorkbooks = xlApp.Workbooks;
                xlWorkbook = xlWorkbooks.Open(_filePath);
                int numSheets = xlWorkbook.Sheets.Count;
                xlSheet = (Worksheet)xlWorkbook.Sheets[sheetName];
                xlRange = xlSheet.UsedRange; // get the entire used range
                RowCount = xlRange.Rows.Count;
                NumberOfCols = xlRange.Columns.Count;
            }
            catch (Exception ex)
            {
                CloseExcelFile();
                throw ex;               
            }
        }
       
        /// <summary>
        /// Get cell data by providing column name and row number
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="rowNum"></param>
        /// <returns></returns>
        public String ReadDataFromColumn(String colName, int rowNum)
        {
            try
            {
                int colIndex = 0;
                String text = "";

                for (int i = 1; i <= NumberOfCols; i++)
                {
                    if (xlRange.Cells[1, i].Value2 != null)
                    {
                        if (xlRange.Cells[1, i].Value2.ToString().Equals(colName))
                        {
                            colIndex = i;
                            break;
                        }
                    }
                }
                if (xlRange.Cells[rowNum, colIndex].value2 != null)
                {
                    text = xlRange.Cells[rowNum, colIndex].value2.ToString();
                }
                else
                {
                    text = "";
                }
                return text;
            }
            catch (Exception e)
            {
                CloseExcelFile();
                throw e;
            }

        }
        /// <summary>
        /// Write data in cell by providing column name, data, row number and save it
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="data"></param>
        /// <param name="row"></param>
        public void writeDataInColumn(string columnName, string data, int row)
        {
            try
            {
                int index = 0;
                for (int i = 1; i <= NumberOfCols; i++)
                {
                    if (xlRange.Cells[1, i].Value2 != null)
                    {
                        if (xlRange.Cells[1, i].Value2.ToString().Equals(columnName))
                        {
                            index = i;
                            break;
                        }
                    }
                }
                xlSheet.Rows.Cells[row, index].value = data;
                xlWorkbook.Save();
            }
            catch (Exception e)
            {
                CloseExcelFile();
                throw e;
            }
        }

        /// <summary>
        /// Closing the workbook
        /// </summary>
        public void CloseExcelFile()
        {
            if (xlWorkbook != null)
            {
                xlWorkbook.Close(true);
                //Quiting the Excel application
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlWorkbooks);
                Marshal.ReleaseComObject(xlApp);
                Marshal.ReleaseComObject(xlSheet);
                Marshal.ReleaseComObject(xlRange);
                try
                {
                    Process[] excelProcsNew = Process.GetProcessesByName("EXCEL");
                    foreach (Process procNew in excelProcsNew)
                    {
                        int exist = 0;
                        foreach (Process procOld in excelProcsOld)
                        {
                            if (procNew.Id == procOld.Id)
                            {
                                exist++;
                            }
                        }
                        if (exist == 0)
                        {
                            procNew.Kill();
                        }
                    }
                }
                catch (Exception e) { throw new Exception($"This is close exception {e}"); }
            }
        }

        /// <summary>
        /// Get Newest File
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static string GetNewestFile(string directory)
        {
            string pattern = "*.xlsx";

            var dirInfo = new System.IO.DirectoryInfo(directory);

            var file = (from f in dirInfo.GetFiles(pattern)
                        orderby f.LastWriteTime descending
                        select f).First();
            string fullath = directory + "\\" + file;
            return fullath;
        }

        /// <summary>
        /// write data into excel sheet
        /// </summary>
        /// <param name="sheetName"></param>
        /// <param name="colName"></param>
        /// <param name="rowNumber"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetCellData(string sheetName, string colName, int rowNumber, string value)
        {
            OpenExcelFileForWriteData();

            int sheetValue = 0;
            int colNumber = 0;
            try
            {
                if (sheets.ContainsValue(sheetName))
                {
                    foreach (DictionaryEntry sheet in sheets)
                    {
                        if (sheet.Value.Equals(sheetName))
                        {
                            sheetValue = (int)sheet.Key;
                        }
                    }

                    Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
                    worksheet = workbook.Worksheets[sheetValue] as ExcelRead.Worksheet;
                    ExcelRead.Range range = worksheet.UsedRange;

                    for (int i = 1; i <= range.Columns.Count; i++)
                    {
                        string colNameValue = Convert.ToString((range.Cells[1, i] as ExcelRead.Range).Value2);
                        if (colNameValue.ToLower() == colName.ToLower())
                        {
                            colNumber = i;
                            break;
                        }
                    }

                    range.Cells[rowNumber, colNumber] = value;
                    workbook.Save();
                    Marshal.FinalReleaseComObject(worksheet);
                    worksheet = null;

                    CloseExcelFile();
                }
            }
            catch (Exception e)
            {
                CloseExcelFile();
                throw e;
            }
            return true;
        }

        /// <summary>
        /// Open Excel File For write Data 
        /// </summary>
        public void OpenExcelFileForWriteData()
        {
            xlApp = new ExcelRead.Application();
            workbooks = xlApp.Workbooks;
            workbook = workbooks.Open(_filePath);
            sheets = new Hashtable();
            int count = 1;
            // Storing worksheet names in Hash table.
            foreach (ExcelRead.Worksheet sheet in workbook.Sheets)
            {
                sheets[count] = sheet.Name;
                count++;
            }
        }
    }
}
