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
                    }

                }.ShowDialog();
            });
            menu.Items.Add(tsmi);

            //tsmi = new ToolStripMenuItem("删除");
            //tsmi.ImageScaling = ToolStripItemImageScaling.None;
            //tsmi.Click += new EventHandler((object sender, EventArgs e) =>
            //{

            //});
            //menu.Items.Add(tsmi);

            return menu;
        }
    }
}
