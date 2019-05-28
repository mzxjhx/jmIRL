namespace jmILRL.Sections
{
    partial class FormReview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReview));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxPN = new System.Windows.Forms.CheckBox();
            this.checkBoxStaff = new System.Windows.Forms.CheckBox();
            this.checkboxsn = new System.Windows.Forms.CheckBox();
            this.checkboxtim = new System.Windows.Forms.CheckBox();
            this.textBoxPN = new System.Windows.Forms.TextBox();
            this.textBoxstaff = new System.Windows.Forms.TextBox();
            this.textBoxSN = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pager = new jmILRL.UI.PagerEx();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1139, 644);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxPN);
            this.panel1.Controls.Add(this.checkBoxStaff);
            this.panel1.Controls.Add(this.checkboxsn);
            this.panel1.Controls.Add(this.checkboxtim);
            this.panel1.Controls.Add(this.textBoxPN);
            this.panel1.Controls.Add(this.textBoxstaff);
            this.panel1.Controls.Add(this.textBoxSN);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btnsearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 74);
            this.panel1.TabIndex = 3;
            // 
            // checkBoxPN
            // 
            this.checkBoxPN.AutoSize = true;
            this.checkBoxPN.Location = new System.Drawing.Point(599, 13);
            this.checkBoxPN.Name = "checkBoxPN";
            this.checkBoxPN.Size = new System.Drawing.Size(72, 16);
            this.checkBoxPN.TabIndex = 3;
            this.checkBoxPN.Text = "制造单号";
            this.checkBoxPN.UseVisualStyleBackColor = true;
            // 
            // checkBoxStaff
            // 
            this.checkBoxStaff.AutoSize = true;
            this.checkBoxStaff.Location = new System.Drawing.Point(400, 43);
            this.checkBoxStaff.Name = "checkBoxStaff";
            this.checkBoxStaff.Size = new System.Drawing.Size(48, 16);
            this.checkBoxStaff.TabIndex = 3;
            this.checkBoxStaff.Text = "工号";
            this.checkBoxStaff.UseVisualStyleBackColor = true;
            // 
            // checkboxsn
            // 
            this.checkboxsn.AutoSize = true;
            this.checkboxsn.Location = new System.Drawing.Point(400, 13);
            this.checkboxsn.Name = "checkboxsn";
            this.checkboxsn.Size = new System.Drawing.Size(48, 16);
            this.checkboxsn.TabIndex = 3;
            this.checkboxsn.Text = "sn号";
            this.checkboxsn.UseVisualStyleBackColor = true;
            // 
            // checkboxtim
            // 
            this.checkboxtim.AutoSize = true;
            this.checkboxtim.Location = new System.Drawing.Point(20, 14);
            this.checkboxtim.Name = "checkboxtim";
            this.checkboxtim.Size = new System.Drawing.Size(15, 14);
            this.checkboxtim.TabIndex = 3;
            this.checkboxtim.UseVisualStyleBackColor = true;
            // 
            // textBoxPN
            // 
            this.textBoxPN.Font = new System.Drawing.Font("宋体", 11F);
            this.textBoxPN.Location = new System.Drawing.Point(677, 9);
            this.textBoxPN.Name = "textBoxPN";
            this.textBoxPN.Size = new System.Drawing.Size(100, 24);
            this.textBoxPN.TabIndex = 2;
            // 
            // textBoxstaff
            // 
            this.textBoxstaff.Font = new System.Drawing.Font("宋体", 11F);
            this.textBoxstaff.Location = new System.Drawing.Point(455, 39);
            this.textBoxstaff.Name = "textBoxstaff";
            this.textBoxstaff.Size = new System.Drawing.Size(100, 24);
            this.textBoxstaff.TabIndex = 2;
            // 
            // textBoxSN
            // 
            this.textBoxSN.Font = new System.Drawing.Font("宋体", 11F);
            this.textBoxSN.Location = new System.Drawing.Point(455, 9);
            this.textBoxSN.Name = "textBoxSN";
            this.textBoxSN.Size = new System.Drawing.Size(100, 24);
            this.textBoxSN.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(207, 11);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(114, 21);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(46, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(966, 21);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 29);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "导出数据";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(862, 21);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 29);
            this.btnsearch.TabIndex = 0;
            this.btnsearch.Text = "查询";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeight = 40;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 83);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(1133, 518);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pager);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 607);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1133, 34);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(306, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // pager
            // 
            this.pager.BackColor = System.Drawing.SystemColors.Control;
            this.pager.FocusTxtColor = System.Drawing.Color.Black;
            this.pager.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pager.Location = new System.Drawing.Point(3, 4);
            this.pager.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pager.Name = "pager";
            this.pager.NMax = 0;
            this.pager.PageCount = 0;
            this.pager.PageCurrent = 0;
            this.pager.PageSize = 15;
            this.pager.Size = new System.Drawing.Size(264, 27);
            this.pager.TabIndex = 5;
            this.pager.TxtColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            // 
            // FormReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 644);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormReview";
            this.Text = "测试数据查询";
            this.Load += new System.EventHandler(this.FormReview_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnsearch;		
        private jmILRL.UI.PagerEx pager;
        private System.Windows.Forms.TextBox textBoxSN;
        private System.Windows.Forms.CheckBox checkboxtim;
        private System.Windows.Forms.CheckBox checkboxsn;
        private System.Windows.Forms.CheckBox checkBoxPN;
        private System.Windows.Forms.TextBox textBoxPN;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox checkBoxStaff;
        private System.Windows.Forms.TextBox textBoxstaff;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}