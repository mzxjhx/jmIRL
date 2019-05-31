using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using jmILRL.common;

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
using System.IO;
using System.Threading;

namespace jmILRL
{
    /// <summary>
    /// 多线程导出Excel
    /// </summary>
    public partial class FormFileDown : Form
    {
        public FormFileDown()
        {
            InitializeComponent();
            Load += FormFileDown_Load;
        }
        /// <summary>
        /// 要导出的DataTable
        /// </summary>
        public DataTable Datas { get; set; }
        /// <summary>
        /// 导出文件名
        /// </summary>
        public string FileName { get; set; } //文件名
        /// <summary>
        /// 多线程类
        /// </summary>
        private BackgroundWorker _worker = new BackgroundWorker();

        private IWorkbook workbook = null;
        
        private FileStream fs = null;


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFileDown_Load(object sender, EventArgs e)
        {
            this._worker.WorkerReportsProgress = true;
            this._worker.WorkerSupportsCancellation = true;

            //注册多线程事件
            _worker.DoWork += (object obj, DoWorkEventArgs args) =>
            {
                DataTableToExcel(Datas, "订单列表", true);
            };
            //注册进度变化事件
            _worker.ProgressChanged += (object obj, ProgressChangedEventArgs args) =>
            {
                //进度条显示
                this.progressBar1.Value = args.ProgressPercentage;
            };
            //注册导出完成事件
            _worker.RunWorkerCompleted += (object obj, RunWorkerCompletedEventArgs args) =>
            {
                if (!args.Cancelled)
                {
                    //导出成功
                    this.Close();
                }
                else {
                    //导出异常
                }
            };
            _worker.RunWorkerAsync();
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
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (FileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (FileName.IndexOf(".xls") > 0) // 2003版本
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

                for (int i = 0,len =data.Rows.Count; i < len; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                    //将进度置换成百分比数传给ProgressChanged
                    int percent = (i + 1) * 100 / len;
                    Console.WriteLine(string.Format("ReportProgress i={1} percent={0}", percent,i));
                    _worker.ReportProgress(percent);                    
                }
                workbook.Write(fs); //写入到excel
                //以下关闭释放资源
                workbook.Close();
                fs.Close();
                fs.Dispose();
                return count;
            }
            catch(NPOI.XSSF.XLSBUnsupportedException ex){
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }
    }
}
