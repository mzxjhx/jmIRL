using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.Util;
using NPOI.SS;
using NPOI.DDF;
using NPOI.SS.Util;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
using System.Collections;
using System.Text.RegularExpressions;

using System.Data;
using System.IO;
using jmILRL.DAL;

namespace jmILRL.common
{
    /// <summary>
    /// NPOI操作Excel类
    /// </summary>
    public class NPOIHelper
    {
        private string fileName = null; //文件名
        private IWorkbook workbook = null;
        private FileStream fs = null;

        public NPOIHelper(string fileName)
        {
            this.fileName = fileName;
        }

        public NPOIHelper() {

        }

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }
		
		 /// <summary>
        /// 
        /// </summary>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public DataTable ReadExcel() {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                sheet = workbook.GetSheetAt(0);
                if (sheet != null) {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    //先写入列标题
                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        ICell cell = firstRow.GetCell(i);
                        if (cell != null)
                        {
                            string cellValue = cell.StringCellValue;
                            if (cellValue != null)
                            {
                                DataColumn column = new DataColumn(cellValue);
                                data.Columns.Add(column);
                            }
                        }
                    }
                    startRow = sheet.FirstRowNum + 1;


                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    //按行写入数据
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
            }

            return data;

        }

        public void dataToExcel(string file,FBT fbt) {
            ISheet sheet = null;

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {

                if (file.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook();
                else if (file.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook();

                try
                {
                    if (workbook != null)
                    {
                        sheet = workbook.CreateSheet("sheet1");
                    }

                    IRow row = sheet.CreateRow(0);
                    int col = 0;
                    row.CreateCell(col++).SetCellValue("制造单号");
                    row.CreateCell(col++).SetCellValue("SN号");
                    row.CreateCell(col++).SetCellValue("工号");
                    row.CreateCell(col++).SetCellValue("日期");
                    row.CreateCell(col++).SetCellValue("产品类型");
                    row.CreateCell(col++).SetCellValue("等级");
                    row.CreateCell(col++).SetCellValue("IL1");
                    row.CreateCell(col++).SetCellValue("IL2");
                    row.CreateCell(col++).SetCellValue("IL3");
                    row.CreateCell(col++).SetCellValue("IL4");
                    row.CreateCell(col++).SetCellValue("RL1");
                    row.CreateCell(col++).SetCellValue("RL2");
                    row.CreateCell(col++).SetCellValue("RL3");
                    row.CreateCell(col++).SetCellValue("RL4");

                    row = sheet.CreateRow(1);
                    col = 0;
                    row.CreateCell(col++).SetCellValue(fbt.batchNumber);
                    row.CreateCell(col++).SetCellValue(fbt.serialNumber);
                    row.CreateCell(col++).SetCellValue(fbt.staff);
                    row.CreateCell(col++).SetCellValue(DateTime.Now.ToString());
                    row.CreateCell(col++).SetCellValue(fbt.PortType);
                    row.CreateCell(col++).SetCellValue(fbt.Level);
                    row.CreateCell(col++).SetCellValue(fbt.IL[0]);
                    row.CreateCell(col++).SetCellValue(fbt.IL[1]);
                    row.CreateCell(col++).SetCellValue(fbt.IL[2]);
                    row.CreateCell(col++).SetCellValue(fbt.IL[3]);
                    row.CreateCell(col++).SetCellValue(fbt.RL[0]);
                    row.CreateCell(col++).SetCellValue(fbt.RL[1]);
                    row.CreateCell(col++).SetCellValue(fbt.RL[2]);
                    row.CreateCell(col++).SetCellValue(fbt.RL[3]);

                    workbook.Write(fs); //写入到excel
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
        }
    }
}