﻿using jmILRL.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace jmILRL
{
    public partial class FrmOption : FrmBase
    {
        public FrmOption()
        {
            InitializeComponent();
            Load += FrmOption_Load;
        }

        private void FrmOption_Load(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            textBoxPath.Text = config.AppSettings.Settings["filePath"].Value;
            textBox1.Text = config.AppSettings.Settings["level_IL"].Value;
            textBox2.Text = config.AppSettings.Settings["level_RL"].Value;
            radioButton1.Checked = config.AppSettings.Settings["portBand"].Value == "zwd" ? true : false;
            radioButton2.Checked = config.AppSettings.Settings["portBand"].Value == "hongshan" ? true : false;
            textBoxreflesh.Text = config.AppSettings.Settings["reflesh"].Value;
            textBoxTimes.Text = config.AppSettings.Settings["times"].Value;
            textBoxdrl.Text = config.AppSettings.Settings["drl"].Value;

            if (config.AppSettings.Settings["type"].Value.ToUpper() == "WDM")
            {
                radioButtonWDM.Checked = true;
            }
            else
            {
                radioButtonFBT.Checked = true;
            }
        }

        public EventHandler OnParamChange;

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    this.textBoxPath.Text = fbd.SelectedPath;
            }
        }
        private void radioButtonWDM_Click(object sender, EventArgs e)
        {            
            Tools.SetConfigValue("type", "WDM");
        }

        private void radioButtonFBT_Click(object sender, EventArgs e)
        {            
            Tools.SetConfigValue("type", "FBT");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxPath.Text.Trim() == "") {
                MessageBox.Show("请选择文件保存路径");
                return;
            }
            //匹配1***(.*)~1***(.*)或1***.*(.*)~1***(.*)&1***.*(.*)~1***(.*)   (\.\d)?小数出现一次或零次
            string patten = @"^\d{2}(\.\d)?$";
            if (!Regex.IsMatch(textBox1.Text.Trim(), patten) || !Regex.IsMatch(textBox2.Text.Trim(), patten))
            {
                MessageBox.Show(" IL、RL不是有效数字！ ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return ;
            }

            if (!Regex.IsMatch(textBoxreflesh.Text.Trim(), @"^\d{2,4}$"))
            {
                MessageBox.Show(" 刷新时间不是有效数字！ ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            Tools.SetConfigValue("filePath", textBoxPath.Text.Trim());
            Tools.SetConfigValue("level_IL", textBox1.Text.Trim());
            Tools.SetConfigValue("level_RL", textBox2.Text.Trim());
            Tools.SetConfigValue("portBand", radioButton1.Checked ? "zwd" : "hongshan");
            Tools.SetConfigValue("reflesh", textBoxreflesh.Text.Trim());
            Tools.SetConfigValue("times", textBoxTimes.Text.Trim());
            Tools.SetConfigValue("drl", textBoxdrl.Text.Trim());
            if (OnParamChange != null) {
                OnParamChange(this, null);
            }
            this.Close();
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
