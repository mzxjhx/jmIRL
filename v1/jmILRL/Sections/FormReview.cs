using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using jmILRL.UI;
using MySql.Data.MySqlClient;
using jmILRL.BAL;
namespace jmILRL.Sections
{
    public partial class FormReview : Form
    {
        public FormReview()
        {
            InitializeComponent();
        }

        FBTService mysqlService = new FBTService();
		
		List<MySqlParameter> listExcel = new List<MySqlParameter>();

        private void FormReview_Load(object sender, EventArgs e)
        {
            pager.PageCount = 1;
            pager.PageSize = 50;
            pager.Bind();
            pager.EventPaging += Pager_EventPaging;

            getRecordBypage(1);

        }

        private bool isSearch = false;

        string sqlSearch = "";
        /// <summary>
        /// 导出Excel时，不带分页
        /// </summary>
        string sqlToExcel = "select * from t_irl";

        string sqlStr = "";

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pager_EventPaging(EventPagingArg e)
        {
            getRecordBypage(e.IntPageIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        private void getRecordBypage(int page)
        {
            int total = 0;
            List<MySqlParameter> list = new List<MySqlParameter>();
            sqlStr = "SELECT batch_number as 单号,serial_number as sn号,staff as 工号,DATE_FORMAT(create_time,'%Y-%m-%d %H:%i:%S') as 时间 ,if(`level`=0,'不合格','合格') as 等级,IL1,IL2,IL3,IL4,RL1,RL2,RL3,RL4  FROM t_irl  where 1=1";


            string sqlCount = "select count(*) from t_irl f where 1=1 ";
            if (checkBoxPN.Checked) {
                sqlStr += " and batch_number=@batch_number";
                sqlCount += " and batch_number=@batch_number";
                list.Add(new MySqlParameter("@batch_number", MySqlDbType.VarChar) { Value = textBoxPN.Text.Trim() });
            }
            if (checkboxtim.Checked == true)
            {
                sqlStr += " and create_time>@time1 and create_time<@time2 ";
                sqlCount += " and create_time>@time1 and create_time<@time2 ";
                list.Add(new MySqlParameter("@time1", MySqlDbType.DateTime) { Value = dateTimePicker1.Value.ToShortDateString() + " 00:00" });
                list.Add(new MySqlParameter("@time2", MySqlDbType.DateTime) { Value = dateTimePicker2.Value.ToShortDateString() + " 23:59" });
            }
            if (checkboxsn.Checked == true) {
                sqlStr += " and serial_number=@sn ";
                sqlCount += " and serial_number=@sn ";
                list.Add(new MySqlParameter("@sn", MySqlDbType.VarChar) { Value = textBoxSN.Text.Trim() });                
            }
            //工号
            if (checkBoxStaff.Checked == true)
            {
                sqlStr += " and staff=@staff ";
                sqlCount += " and staff=@staff ";
                list.Add(new MySqlParameter("@staff", MySqlDbType.VarChar) { Value = textBoxstaff.Text.Trim() });
            }
            sqlToExcel = sqlStr;
			listExcel = list;
            sqlStr += " ORDER BY create_time DESC LIMIT @page,@offset";

            total = mysqlService.getCount(sqlCount, list.ToArray());

            list.Add(new MySqlParameter("@page", MySqlDbType.Int16) { Value = pager.PageSize * (page - 1) });
            list.Add(new MySqlParameter("@offset", MySqlDbType.Int16) { Value = pager.PageSize });  
            DataTable dt = mysqlService.getTableByPage(sqlStr, list.ToArray());

            label1.Text = string.Format("总记录数 = {0}", total);
            if (this.pager.NMax != total)
            {
                this.pager.NMax = total;
                this.pager.BtnInit();
            }

            dataGridView.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getRecordBypage(1);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ToExcel()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "(*.xls)|*.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = mysqlService.getTableByPage(sqlToExcel,listExcel.ToArray());

                    FormFileDown down = new FormFileDown();
                    down.FileName = sfd.FileName;
                    down.Datas = dt;
                    down.ShowDialog();
					listExcel = null;
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ToExcel();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSearch = false;
            sqlToExcel = "select * from t_irl";
            getRecordBypage(1);
        }

        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView.ContextMenuStrip = new MenuFactory().GetMenu(dataGridView, e.RowIndex);
            }
        }
    }
}
