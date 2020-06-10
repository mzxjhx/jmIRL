using jmILRL.BAL;
using jmILRL.Sections;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jmILRL
{
    /// <summary>
    /// 托盘菜单
    /// </summary>
    public class MenuFactory
    {
        ContextMenuStrip menu;
        FBTService mysqlService = new FBTService();
        public ContextMenuStrip GetMenu(DataGridView dgv, int index)
        {
            menu = new ContextMenuStrip();
            ToolStripMenuItem tsmi = new ToolStripMenuItem("编辑");
            tsmi.ImageScaling = ToolStripItemImageScaling.None;
            tsmi.Click += new EventHandler((object sender, EventArgs e) =>
            {
                new FrmEdit() {
                    Fbt = new DAL.FBT() {
                        batchNumber = dgv.Rows[index].Cells[0].Value.ToString(),
                        serialNumber = dgv.Rows[index].Cells[1].Value.ToString(),
                        staff = dgv.Rows[index].Cells[2].Value.ToString(),
                        ID = dgv.Rows[index].Cells["id"].Value.ToString(),
                    }

                }.ShowDialog();
            });
            menu.Items.Add(tsmi);

            tsmi = new ToolStripMenuItem("删除");
            tsmi.ImageScaling = ToolStripItemImageScaling.None;
            tsmi.Click += new EventHandler((object sender, EventArgs e) =>
            {
                if(MessageBox.Show("确定要删除该行数据吗？", "提醒", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string id = dgv.Rows[index].Cells["id"].Value.ToString();
                    if(mysqlService.delete(id) > 0)
                    {
                        MessageBox.Show("数据已删除");
                    }
                }


            });
            menu.Items.Add(tsmi);

            return menu;
        }
    }
}
